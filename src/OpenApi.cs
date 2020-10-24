using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace DayTrader
{
    public delegate void TrCallback(_DKHOpenAPIEvents_OnReceiveTrDataEvent e);

    public static class OpenApi
    {
        public const int RealPriceCount = 5;

        public const double Fee = 0.00015;

        public static event Action<string[], string, string> Connected;
        public static event Action<_DKHOpenAPIEvents_OnReceiveRealDataEvent> ReceivedRealData;

        private static AxKHOpenAPI _api;
        private static bool _loginSucceed;

        private static Timer _timer = new Timer();
        private static DateTime _beginTime;
        private static List<TimerAction> _actions = new List<TimerAction>();

        private static readonly Dictionary<string, TrCallback> _trs = new Dictionary<string, TrCallback>();
        private static readonly List<Stock> _etfs = new List<Stock>();
        private static readonly List<Stock> _stocks = new List<Stock>();

        public static void Init(AxKHOpenAPI api)
        {
            _api = api;

            _api.OnEventConnect += AxKHOpenAPI1_OnEventConnect;
            _api.OnReceiveTrData += AxKHOpenAPI1_OnReceiveTrData;
            _api.OnReceiveRealData += AxKHOpenAPI1_OnReceiveRealData;
            _api.OnReceiveMsg += AxKHOpenAPI1_OnReceiveMsg;
            _api.OnReceiveChejanData += AxKHOpenAPI1_OnReceiveChejanData;
            _api.CommConnect();

            _timer.Tick += Timer_Tick;
            _timer.Interval = 200;
            _timer.Start();
            _beginTime = Time();
        }

        public static bool IsConnected()
        {
            return _api.GetConnectState() == 1;
        }

        public static void RegisterAction(int interval, Action action)
        {
            if (_actions.Any(x => x.Action == action))
            {
                return;
            }

            var item = new TimerAction();
            item.Interval = interval;
            item.Action = action;
            item.LastTime = Time();
            _actions.Add(item);

            action();
        }

        public static int GetRepeatCnt(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            return _api.GetRepeatCnt(e.sTrCode, e.sRecordName);
        }

        public static string GetTrData(_DKHOpenAPIEvents_OnReceiveTrDataEvent e, string sName, int index = 0)
        {
            var data = _api.GetCommData(e.sTrCode, e.sRecordName, index, sName);
            return data.Trim();
        }

        public static string GetTrNum(_DKHOpenAPIEvents_OnReceiveTrDataEvent e, string sName, int index = 0)
        {
            return Prettify(GetTrData(e, sName, index));
        }

        private static string Prettify(string number)
        {
            long num;
            long.TryParse(number, out num);
            return string.Format("{0:N0}", num);
        }

        public static void UpdateBalances(string account, TrCallback callback)
        {
            SetInputValue("계좌번호", account);
            SetInputValue("비밀번호", "");
            SetInputValue("상장폐지조회구분", "1");
            SetInputValue("비밀번호입력매체구분", "00");
            CommRqData("계좌평가", "OPW00004", callback);
        }

        public static IEnumerable<Stock> GetETFs()
        {
            return _etfs;
        }

        public static IEnumerable<Stock> GetStocks()
        {
            return _stocks;
        }

        private static void AxKHOpenAPI1_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode != 0)
            {
                Application.Exit();
            }

            _loginSucceed = true;

            string acclist = _api.GetLoginInfo("ACCLIST");
            string[] accounts = acclist.Trim().Split(';').Where(x => x.Length > 0).ToArray();

            var userId = _api.GetLoginInfo("USER_ID");
            var server = _api.GetLoginInfo("GetServerGubun") == "0" ? "모의" : "실제";

            // fill etfs
            FillStocks("8", _etfs);

            // fill stocks
            FillStocks("0", _stocks);        

            if (Connected != null)
            {
                Connected(accounts, userId, server);
            }
        }

        private static void FillStocks(string marketCode, List<Stock> fillList)
        {
            fillList.Clear();

            string[] list = _api.GetCodeListByMarket(marketCode).Trim().Split(';');
            foreach (var code in list)
            {
                if (string.IsNullOrEmpty(code))
                {
                    continue;
                }

                fillList.Add(new Stock
                {
                    Code = code,
                    Name = _api.GetMasterCodeName(code)
                });
            }

            fillList.Sort(delegate (Stock x, Stock y)
            {
                return string.Compare(x.Name, y.Name);
            });
        }

        private static void AxKHOpenAPI1_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            Debug.Info(e.sRQName + ":" + e.sTrCode + ":" + e.sMessage);

            if (_trs.TryGetValue(e.sTrCode, out TrCallback callback))
            {
                _trs.Remove(e.sTrCode);
                callback(e);
            }
        }

        private static void AxKHOpenAPI1_OnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if(ReceivedRealData != null)
            {
                ReceivedRealData(e);
            }
        }

        private static void AxKHOpenAPI1_OnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            Debug.Info("RQ: {0}, TR: {1} - {2}", e.sRQName, e.sTrCode, e.sMsg);
        }

        private static void AxKHOpenAPI1_OnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            Debug.Info(e.sGubun + ":" + e.sFIdList + "," + e.nItemCnt);
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (CheckDisconnected())
            {
                _timer.Stop();
                MessageBox.Show("접속이 종료되었습니다.\n 프로그램을 종료합니다.");
                Application.Exit();
                return;
            }

            if (!IsConnected())
            {
                return;
            }

            DateTime now = Time();
            foreach (var item in _actions)
            {
                TimeSpan span = now - item.LastTime;
                if (span.TotalMilliseconds >= item.Interval)
                {
                    item.LastTime = now;
                    item.Action();
                }
            }
        }

        private static bool CheckDisconnected()
        {
            TimeSpan span = TimeElapsed();
            bool notConnectedYet = span.TotalSeconds > 20 && !_loginSucceed;
            bool disconnected = _loginSucceed && !IsConnected();
            return notConnectedYet || disconnected;
        }

        private static TimeSpan TimeElapsed()
        {
            return Time() - _beginTime;
        }

        private static DateTime Time()
        {
            return DateTime.Now;
        }

        public static bool IsTradeable()
        {
            var now = Time();
            if (now.Hour <= 9 && now.Minute < 5)
            {
                return false;
            }

            if (now.Hour >= 15 && now.Minute >= 19)
            {
                return false;
            }

            return true;
        }

        public static void SetInputValue(string sID, string sValue)
        {
            _api.SetInputValue(sID, sValue);
        }

        public static void CommRqData(string rq, string sTrCode, TrCallback callback, int seq = 0)
        {
            if (_trs.ContainsKey(sTrCode))
            {
                Debug.Warn("Previous {0} is not finished yet. Request will be ignored", sTrCode);
                return;
            }

            _api.CommRqData(rq, sTrCode, seq, "6000");
            _trs[sTrCode] = callback;
        }

        public static void SetRealReg(IEnumerable<string> codes)
        {
            string sell = string.Empty;
            for(int i = 0; i < RealPriceCount; ++i)
            {
                sell += ";";
                sell += (i + 41).ToString();
                sell += ";";
                sell += (i + 61).ToString();
            }

            string buy = string.Empty;
            for (int i = 0; i < RealPriceCount; ++i)
            {
                buy += ";";
                buy += (i + 51).ToString();
                buy += ";";
                buy += (i + 71).ToString();
            }

            string fids = "36" + buy + sell;       

            _api.SetRealReg("6001", codes.FirstOrDefault(), fids, "0");            
            foreach(var code in codes.Skip(1))
            {
                _api.SetRealReg("6001", code, fids, "1");
            }
        }

        public static string GetRealData(string code, int fid)
        {
            return _api.GetCommRealData(code, fid);
        }

        public static int Sell(string account, string code, int quantity)
        {
            return _api.SendOrder("주식주문", "6002", account, 2, code, quantity, 0, "03", "");
        }

        public static int Buy(string account, string code, int quantity)
        {
            return _api.SendOrder("주식주문", "6002", account, 1, code, quantity, 0, "03", "");
        }

        public static void Clear()
        {
            _trs.Clear();
            _actions.Clear();
            _api.SetRealRemove("ALL", "ALL");
        }

        private class TimerAction
        {
            // in ms
            public int Interval;
            public Action Action;

            public DateTime LastTime;
        }
    }
}
