using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace DayTrader
{
    public class StockPrice
    {
        public DateTime Time;
        public long StartPrice;
        public long HighPrice;
        public long LowPrice;
        public long Price;
    }

    public class StockPriceCollection
    {
        private TaskCompletionSource<StockPriceCollection> _source = new TaskCompletionSource<StockPriceCollection>();
        private string _code;
        private DateTime _begin;
        private DateTime _end;
        private string _interval;
        private IProgress<int> _progress;

        public List<StockPrice> Items = new List<StockPrice>();

        public static Task<StockPriceCollection> Get(string code, DateTime begin, DateTime end, string interval, IProgress<int> progress = null)
        {
            var collection = new StockPriceCollection();
            collection.Request(code,
                new DateTime(begin.Year, begin.Month, begin.Day),
                new DateTime(end.Year, end.Month, end.Day),
                collection, interval, progress);

            return collection._source.Task;
        }

        private void Request(string code, DateTime begin, DateTime end, StockPriceCollection collection,  string interval, 
            IProgress<int> progress, int seq = 0)
        {
            _code = code;
            _begin = begin;
            _end = end;
            _progress = progress;
            _interval = interval;

            OpenApi.SetInputValue("종목코드", code);
            if (IsDaily())
            {
                OpenApi.SetInputValue("기준일자", _end.ToString("yyyyMMdd"));
            }
            else
            {
                OpenApi.SetInputValue("틱범위", interval);
            }

            OpenApi.SetInputValue("수정주가구분", "0");
            OpenApi.CommRqData("차트구하기", IsDaily() ? "opt10081" : "opt10080", collection.PriceCallback, seq);
        }

        private bool IsDaily()
        {
            return string.IsNullOrEmpty(_interval);
        }

        private void PriceCallback(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            bool continued = true;

            int count = OpenApi.GetRepeatCnt(e);
            for(int i = 0; i < count; ++i)
            {
                string date = OpenApi.GetTrData(e, IsDaily() ? "일자" : "체결시간", i);
                string startPrice = OpenApi.GetTrData(e, "시가", i);
                string highPrice = OpenApi.GetTrData(e, "고가", i);
                string lowPrice = OpenApi.GetTrData(e, "저가", i);
                string price = OpenApi.GetTrData(e, "현재가", i);

                var stock = new StockPrice();

                if (IsDaily())
                {
                    DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out stock.Time);
                }
                else
                {
                    DateTime.TryParseExact(date, "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.None, out stock.Time);
                }
                
                long.TryParse(startPrice, out stock.StartPrice);
                stock.StartPrice = Math.Abs(stock.StartPrice);

                long.TryParse(highPrice, out stock.HighPrice);
                stock.HighPrice = Math.Abs(stock.HighPrice);

                long.TryParse(lowPrice, out stock.LowPrice);
                stock.LowPrice = Math.Abs(stock.LowPrice);

                long.TryParse(price, out stock.Price);
                stock.Price = Math.Abs(stock.Price);

                if (stock.Time < _begin)
                {
                    continued = false;
                    break;
                }

                var nextEnd = _end.AddDays(1);
                if (stock.Time >= nextEnd) continue;

                Items.Add(stock);

                if(_progress != null) _progress.Report(Items.Count);
            }

            int seq;
            int.TryParse(e.sPrevNext, out seq);
            if (seq != 0 && continued)
            {
                Thread.Sleep(300);
                Request(_code, _begin, _end, this, _interval, _progress, seq);
            }
            else
            {
                Items.Reverse();
                _source.SetResult(this);
 
           }
        }
    }
}
