using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DayTrader
{
    public partial class BackTestForm : Form
    {
        private static int[] Intervals =
        {
            1,
            3,
            5,
            10,
            15,
            30,
            45,
            60            
        };

        private static BackTestForm _instance;
        public static BackTestForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BackTestForm();
                    _instance.Hide();
                }

                return _instance;
            }
        }

        public BackTestForm()
        {
            InitializeComponent();

            var stocks = OpenApi.GetStocks();
            foreach(var stock in stocks)
            {
                if(stock.Name.Contains("삼성전자"))
                {
                    comboBox_Stock1.Items.Add(stock);
                    comboBox_Stock2.Items.Add(stock);
                    comboBox_Stock3.Items.Add(stock);
                }
            }

            comboBox_Stock1.SelectedItem = stocks.FirstOrDefault(x => x.Name.Contains("삼성전자"));
            comboBox_Stock2.SelectedItem = stocks.FirstOrDefault(x => x.Name.Contains("삼성전자우"));
            comboBox_Stock3.SelectedItem = stocks.FirstOrDefault();

            foreach (var interval in Intervals)
            {
                comboBox_Interval.Items.Add(interval);
            }
            comboBox_Interval.SelectedIndex = 0;
            comboBox_Interval.Enabled = false;
        }

        private void BackTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private class IntProgress : IProgress<int>
        {
            public IntProgress(ProgressBar bar, int target)
            {
                _bar = bar;
                _bar.Minimum = 0;
                _bar.Maximum = 100;
                _bar.Value = 0;
                _target = target;
            }

            public void Report(int value)
            {
                int percent = _target > 0 ? value * 100 / _target : 100;
                _bar.Value = percent;
            }

            ProgressBar _bar;
            int _target;
        }

        private async void button_Test_Click(object sender, EventArgs e)
        {
            var stock1 = comboBox_Stock1.SelectedItem as Stock;
            var stock2 = comboBox_Stock2.SelectedItem as Stock;
            if (stock1 == null || stock2 == null) return;

            int duration = textBox_Duration.Text.ToInt();
            DateTime begin = dateTimePicker_Begin.Value;
            DateTime end = dateTimePicker_End.Value;

            var avgGaps = CalculateAvgGaps(stock1, stock2, duration, ref begin, end);

            string interval = checkBox_UseMinute.Checked ? comboBox_Interval.SelectedItem.ToString() : "";
            int gap = interval.ToInt();

            int target = CalculateTarget(interval, begin, end);
            var progress = new IntProgress(progressBar, target);

            var collection1 = await StockPriceCollection.Get(stock1.Code, begin, end, interval, progress);
            progressBar.Value = 0;
            Debug.Info("{0}", collection1.Items.Count);

            var collection2 = await StockPriceCollection.Get(stock2.Code, begin, end, interval, progress);
            Debug.Info("{0}", collection2.Items.Count);
            progressBar.Value = 100;

            float margin = textBox_Margin.Text.ToFloat();
            margin /= 100;

            var items1 = collection1.Items;
            var items2 = collection2.Items;
            if (items1.Count <= 0 || items2.Count <= 0)
            {
                Debug.Warn("No data");
                return;
            }

            int i = 0;
            int j = 0;
            while (items1[i].Time != items2[j].Time)
            {
                if (items1[i].Time < items2[j].Time)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            float baseGap = avgGaps[items1[i].Time.Date];
            float currentGap = (float)items2[j].Price / items1[i].Price;

            bool isItem1 = baseGap <= currentGap;            
            int quantity = textBox_Quantity.Text.ToInt();

            long cash = 0;
            long stock = quantity;
            long initialAmount = quantity * (isItem1 ? items1[i].Price : items2[j].Price);
            long totalAmount = initialAmount;
            long comparison = quantity * (isItem1 ? items1.Last().Price : items2.Last().Price);

            i++;
            j++;

            while (i < items1.Count && j < items2.Count)
            {
                var item1 = items1[i];
                var item2 = items2[j];
                if (item1.Time != item2.Time)
                {
                    if (item1.Time < item2.Time)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                    continue;
                }

                i++;
                j++;

                if (item1.Time.Hour == 9 && item1.Time.Minute < 5) continue;
                if (item1.Time.Hour >= 15 && item1.Time.Minute >= 20) continue;

                var price1 = item1.Price;
                var price2 = item2.Price;

                baseGap = avgGaps[item1.Time.Date];
                currentGap = (float)price2 / price1;

                // 우선주가 더 싸짐
                if(isItem1 && currentGap + margin <= baseGap)
                {
                    cash += stock * price1;
                    stock = cash / price2;
                    cash -= (long)(stock * price2 * 1.003f);

                    totalAmount = cash + stock * price2;
                    isItem1 = false;
                    Debug.Info("Stock2 / Date: {0} - Item1: {1}, Item2: {2}, Total: {3}", item1.Time, price1, price2, totalAmount);
                }
                else if(!isItem1 && currentGap >= baseGap + margin)
                {
                    cash += stock * price2;
                    stock = cash / price1;
                    cash -= (long)(stock * price1 * 1.003f);

                    totalAmount = cash + stock * price1;
                    isItem1 = true;
                    Debug.Info("Stock1 / Date: {0} - Item1: {1}, Item2: {2}, Total: {3}", item1.Time, price1, price2, totalAmount);
                }         
            }

            Debug.Info("Initial Amount: {0}", initialAmount);
            Debug.Info("Total Amount: {0}", totalAmount);
            Debug.Info("Comparison Amount: {0}", comparison);
        }

        private Dictionary<DateTime, float> CalculateAvgGaps(Stock stock1, Stock stock2, int duration, 
            ref DateTime begin, DateTime end)
        {
            string interval = "";
            int target = CalculateTarget(interval, begin, end);
            var progress = new IntProgress(progressBar, target);

            var collection1 = StockPriceCollection.Get(stock1.Code, begin, end, interval, progress).Result;
            progressBar.Value = 0;

            var collection2 = StockPriceCollection.Get(stock2.Code, begin, end, interval, progress).Result;
            progressBar.Value = 100;

            var avgGaps = new Dictionary<DateTime, float>();
            if (collection1.Items.Count <= duration)
            {
                return avgGaps;
            }

            long price1Sum = 0;
            long price2Sum = 0;

            for (int i = 0; i < duration; ++i)
            {
                price1Sum += collection1.Items[i].Price;
                price2Sum += collection2.Items[i].Price;                
            }

            begin = collection1.Items[duration].Time.Date;

            for(int i = duration; i < collection1.Items.Count || i < collection2.Items.Count; ++i)
            {
                avgGaps[collection1.Items[i].Time.Date] = (float)price2Sum / price1Sum;

                price1Sum -= collection1.Items[i - duration].Price;
                price2Sum -= collection2.Items[i - duration].Price;

                price1Sum += collection1.Items[i].Price;
                price2Sum += collection2.Items[i].Price;
            }

            return avgGaps;
        }

        private static int CalculateTarget(string interval, DateTime begin, DateTime end)
        {
            int gap;
            int.TryParse(interval, out gap);

            int target = 0;
            for (; begin <= end; begin = begin.AddDays(1))
            {
                if(begin.DayOfWeek == DayOfWeek.Sunday ||
                   begin.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                if (gap == 0)
                {
                    target++;
                }
                else
                {
                    target += 390 / gap;
                }
            }

            return target;
            
        }

        private void checkBox_UseMinute_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_Interval.Enabled = checkBox_UseMinute.Checked;
        }
    }
}

