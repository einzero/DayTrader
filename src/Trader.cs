using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayTrader
{
    class Trader
    {
        public event Action<EPhase> Processed;
        public enum EPhase
        {
            Begin,
            OrderConfirm,
            Balance,            
            Price,
            Order,     
        }

        public EPhase Phase
        {
            get;
            private set;
        }

        public string Error
        {
            get;
            private set;
        }

        private class StockInfo
        {
            public StockInfo(Stock stock)
            {
                Stock = stock;
            }

            public Stock Stock;
            public int Quantity;
            public AskingPrice AskingPrice;
        }

        private class Order
        {
            public Stock Stock;
            public int Quantity;
        }

        private readonly string _account;
        private readonly int _quantity;
        private readonly StockInfo _target;       
        private readonly List<StockInfo> _stockInfos = new List<StockInfo>();

        private bool _wait;
        private readonly List<Order> _buyOrders = new List<Order>();
        private readonly List<Order> _sellOrders = new List<Order>();
        private bool _priceCollected;

        public Trader(string account, int quantity, Stock target)
        {
            _account = account;
            _quantity = quantity;
            _target = new StockInfo(target);
            Phase = EPhase.Begin;
        }

        public void SetAskingPrice(string code, AskingPrice price)
        {
            foreach(var balance in _stockInfos)
            {
                if(balance.Stock.Code == code)
                {
                    balance.AskingPrice = price;                    
                }
            }

            if(Phase == EPhase.Price)
            {
                ProcessPhase();
            }            
        }

        public void Process()
        {
            if(Phase == EPhase.Begin)
            {
                MoveState(EPhase.OrderConfirm);
            }

            ProcessPhase();

            if (Processed != null)
            {
                Processed(Phase);
            }
        }

        private void MoveState(EPhase phase)
        {
            if (phase != Phase)
            {
                Debug.Info("Phase: " + phase.ToString());
            }

            Phase = phase;
            ProcessPhase();
        }

        private void ProcessPhase()
        {
            if (_wait || !OpenApi.IsTradeable())
            {
                return;
            }

            switch (Phase)
            {
                case EPhase.OrderConfirm:
                    OnOrderConfirm();
                    break;
                case EPhase.Balance:
                    OnBalance();
                    break;
                case EPhase.Price:
                    OnPrice();
                    break;
                case EPhase.Order:
                    OnOrder();
                    break;
            }
        }

        private void OnOrderConfirm()
        {            
            _wait = true;

            OpenApi.SetInputValue("계좌번호", _account);
            OpenApi.SetInputValue("전체종목구분", "0");
            OpenApi.SetInputValue("매매구분", "0");
            OpenApi.SetInputValue("체결구분", "1");
            OpenApi.CommRqData("실시간미체결요청", "opt10075", delegate(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
            {
                int count = OpenApi.GetRepeatCnt(e);
                bool hasRemain = false;
                for(int i = 0; i < count; ++i)
                {
                    var name = OpenApi.GetTrData(e, "종목명", i);
                    var remain = OpenApi.GetTrData(e, "미체결수량", i).ToInt();
                    if(remain > 0)
                    {
                        hasRemain = true;
                        break;
                    }
                }

                _wait = false;                        
                MoveState(hasRemain ? EPhase.Begin : EPhase.Balance);
            });            
        }

        private void OnBalance()
        {
            _wait = true;

            OpenApi.UpdateBalances(_account, delegate (AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
            {
                int count = OpenApi.GetRepeatCnt(e);
                for (int i = 0; i < count; ++i)
                {
                    string 종목명 = OpenApi.GetTrData(e, "종목명", i);
                    string 보유수량 = OpenApi.GetTrData(e, "보유수량", i);
                    foreach(var stock in _stockInfos)
                    {
                        if(stock.Stock.ToString() == 종목명)
                        {
                            int quantity;
                            if (int.TryParse(보유수량, out quantity))
                            {
                                stock.Quantity = quantity;
                            }
                            else
                            {
                                // something wrong;
                                Error = "보유수량 오류: " + 보유수량;
                                return;
                            }
                            break;
                        }
                    }
                }

                _wait = false;
                MoveState(EPhase.Price);
            });
        }

        private void OnPrice()
        {
            var now = DateTime.Now;
            foreach(var info in _stockInfos)
            {
                if(info.AskingPrice == null)
                {
                    return;
                }

                TimeSpan span = now - info.AskingPrice.Time;
                if(Math.Abs(span.TotalSeconds) > 1)
                {
                    return;
                }
            }
            
            if(!_priceCollected)
            {
                Debug.Warn("Price Colleted!");
                _priceCollected = true;
            }

            bool buyTime = now.Hour >= 13 && now.Minute >= 30;
            if (buyTime && _target.Quantity == 0)
            {
                _buyOrders.Add(new Order
                {
                    Stock = _target.Stock,
                    Quantity = _quantity
                });
            }
            else if(!buyTime && _target.Quantity > 0)
            {
                _sellOrders.Add(new Order
                {
                    Stock = _target.Stock,
                    Quantity = _target.Quantity
                });
            }

            if (_buyOrders.Count > 0 || _sellOrders.Count > 0)
            {
                MoveState(EPhase.Order);
            }
        }

        private int CalculateTotalPrice(int quantity, List<Asking> askings)
        {
            int sum = 0;
            foreach(var asking in askings)
            {
                int num = Math.Min(quantity, asking.Quantity);
                quantity -= num;
                sum += asking.Price * num;
                if(quantity <= 0)
                {
                    return sum;
                }
            }

            return -1;
        }

        private void OnOrder()
        {
            for (int i = _sellOrders.Count - 1; i >= 0; --i)
            {
                var order = _sellOrders[i];
                var result = OpenApi.Sell(_account, order.Stock.Code, order.Quantity);
                Debug.Warn("Sell: {0}, {1}, Result: {2}", order.Stock, order.Quantity, result);
            }

            for (int i = _buyOrders.Count - 1; i >= 0; --i)
            {
                var order = _buyOrders[i];
                var result = OpenApi.Buy(_account, order.Stock.Code, order.Quantity);
                Debug.Warn("Buy: {0}, {1}, Result: {2}", order.Stock, order.Quantity, result);
            }

            _sellOrders.Clear();
            _buyOrders.Clear();
            MoveState(EPhase.OrderConfirm);
        }
    }
}

