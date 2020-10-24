using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace DayTrader
{
    public partial class MainForm : Form
    {
        public static MainForm Instance
        {
            get;
            private set;
        }

        private const int LogPriceCount = 2;

        private readonly List<Control> _tradeControls = new List<Control>();
        private Trader _trader;

        public MainForm()
        {
            Instance = this;

            InitializeComponent();
            OpenApi.Init(axKHOpenAPI);
            OpenApi.Connected += OpenApi_Connected;
            OpenApi.ReceivedRealData += OpenApi_ReceivedRealData;

            Debug.Logged += delegate (DateTime time, Debug.LogLevel level, string text)
            {
                try
                {
                    if (!string.IsNullOrEmpty(richTextBox_Logs.Text))
                    {
                        richTextBox_Logs.AppendText(Environment.NewLine);
                    }

                    Color color = Color.Black;
                    switch (level)
                    {
                        case Debug.LogLevel.Warning:
                            color = Color.DarkOrange;
                            break;
                        case Debug.LogLevel.Error:
                            color = Color.DarkRed;
                            break;
                    }

                    var fullText = string.Format("{0}: {1}", time, text);
                    richTextBox_Logs.AppendText(fullText, color);
                    richTextBox_Logs.ScrollToCaret();

                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        w.WriteLine(fullText);
                    }
                }
                catch(Exception e)
                {
                    File.WriteAllText("exception.txt", e.ToString());
                }
            };

            dataGridView_Balance.Columns.Add("예수금", "예수금");
            dataGridView_Balance.Columns.Add("D+2추정예수금", "D+2추정예수금");
            dataGridView_Balance.Columns.Add("유가잔고평가액", "유가잔고평가액");
            dataGridView_Balance.Columns.Add("예탁자산평가액", "예탁자산평가액");
            dataGridView_Balance.Columns.Add("총매입금액", "총매입금액");
            dataGridView_Balance.Rows.Add();

            dataGridView_Stocks.Columns.Add("종목명", "종목명");
            dataGridView_Stocks.Columns.Add("보유수량", "보유수량");
            dataGridView_Stocks.Columns.Add("평균단가", "평균단가");
            dataGridView_Stocks.Columns.Add("현재가", "현재가");
            dataGridView_Stocks.Columns.Add("평가금액", "평가금액");
            dataGridView_Stocks.Columns.Add("손익금액", "손익금액");

            _tradeControls.Add(comboBox_Stock1);
            _tradeControls.Add(textBox_Quantity);
        }

        private void OpenApi_Connected(string[] accounts, string userId, string server)
        {
            comboBox_Account.Items.AddRange(accounts);
            comboBox_Account.SelectedIndex = 0;

            label_UserId.Text = userId;
            label_Server.Text = server;

            UpdateBalances();

            var etfs = OpenApi.GetETFs();
            foreach (var etf in etfs)
            {
                if (etf.Name.Contains("200") || etf.Name.Contains("150"))
                {
                    comboBox_Stock1.Items.Add(etf);
                }                    
            }

            comboBox_Stock1.SelectedItem = etfs.FirstOrDefault(x => x.Name == "KODEX 코스닥 150");
            Show();
        }

        private void OpenApi_ReceivedRealData(_DKHOpenAPIEvents_OnReceiveRealDataEvent real)
        {   
            DateTime now = DateTime.Now;

            //DateTime time;
            //var strTime = OpenApi.GetRealData(real.sRealKey, 21);
            //if (DateTime.TryParseExact(strTime,
            //    "HHmmss", CultureInfo.CurrentCulture, DateTimeStyles.None, out time))
            //{
            //    now = new DateTime(now.Year, now.Month, now.Day, time.Hour, time.Minute, time.Second);
            //}

            var askingPrice = new AskingPrice(now);
            for (int i = 0; i < OpenApi.RealPriceCount; ++i)
            {
                askingPrice.Sell.Add(new Asking
                {
                    Price = Math.Abs(OpenApi.GetRealData(real.sRealKey, i + 41).ToInt()),
                    Quantity = OpenApi.GetRealData(real.sRealKey, i + 61).ToInt(),
                });

                askingPrice.Buy.Add(new Asking
                {
                    Price = Math.Abs(OpenApi.GetRealData(real.sRealKey, i + 51).ToInt()),
                    Quantity = OpenApi.GetRealData(real.sRealKey, i + 71).ToInt(),
                });
            }

            if (_trader != null)
            {
                _trader.SetAskingPrice(real.sRealKey, askingPrice);
            }
        }

        private void UpdateBalances()
        {
            OpenApi.UpdateBalances(GetAccount(), delegate (_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
            {
                string 예수금 = OpenApi.GetTrNum(e, "예수금");
                string D2추정예수금 = OpenApi.GetTrNum(e, "D+2추정예수금");
                string 유가잔고평가액 = OpenApi.GetTrNum(e, "유가잔고평가액");
                string 예탁자산평가액 = OpenApi.GetTrNum(e, "예탁자산평가액");
                string 총매입금액 = OpenApi.GetTrNum(e, "총매입금액");

                var row = dataGridView_Balance.Rows[0];
                row.SetValues(예수금, D2추정예수금, 유가잔고평가액, 예탁자산평가액, 총매입금액);


                int count = OpenApi.GetRepeatCnt(e);
                dataGridView_Stocks.RowCount = count;

                for (int i = 0; i < count; ++i)
                {                    
                    string 종목명 = OpenApi.GetTrData(e, "종목명", i);
                    string 보유수량 = OpenApi.GetTrNum(e, "보유수량", i);
                    string 평균단가 = OpenApi.GetTrNum(e, "평균단가", i);
                    string 현재가 = OpenApi.GetTrNum(e, "현재가", i);
                    string 평가금액 = OpenApi.GetTrNum(e, "평가금액", i);
                    string 손익금액 = OpenApi.GetTrNum(e, "손익금액", i);

                    row = dataGridView_Stocks.Rows[i];
                    row.SetValues(종목명, 보유수량, 평균단가, 현재가, 평가금액, 손익금액);
                }
            });
        }

        private void 백테스터열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackTestForm.Instance.Show();
        }
    
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            Visible = OpenApi.IsConnected();
        }

        private string GetAccount()
        {
            return (string)comboBox_Account.SelectedItem;
        }

        private void button_LogClear_Click(object sender, EventArgs e)
        {
            richTextBox_Logs.Text = "";
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            UpdateBalances();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            ToggleStart();
        }

        private void ToggleStart()
        {
            var stocks = new[]
            {
                comboBox_Stock1.SelectedItem as Stock,
            };

            if (_trader == null)
            {
                _trader = new Trader(GetAccount(), textBox_Quantity.Text.ToInt(), stocks[0]);
            }
            else
            {
                _trader = null;
            }

            // 현재 시작여부
            var started = _trader != null;

            button_Start.Text = started ? "거래 종료" : "거래 시작";
            EnableTradeControls(!started);

            OpenApi.Clear();

            if (_trader == null)
            {
                return;
            }

            OpenApi.SetRealReg(stocks.Select(x => x.Code));
            OpenApi.RegisterAction(1000, delegate ()
            {
                try
                {
                    _trader.Process();
                }
                catch (Exception ex)
                {
                    Debug.Error(ex.Message);
                    ToggleStart();
                }
            });
        }

        private void EnableTradeControls(bool enabled)
        {
            _tradeControls.ForEach(x => x.Enabled = enabled);
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
  