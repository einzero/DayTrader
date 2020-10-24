namespace DayTrader
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axKHOpenAPI = new AxKHOpenAPILib.AxKHOpenAPI();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Server = new System.Windows.Forms.Label();
            this.label_UserId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Account = new System.Windows.Forms.ComboBox();
            this.dataGridView_Balance = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.분석ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.백테스터열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox_Logs = new System.Windows.Forms.RichTextBox();
            this.button_LogClear = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.dataGridView_Stocks = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Quantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Stock1 = new System.Windows.Forms.ComboBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.groupBox_Trade = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Balance)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stocks)).BeginInit();
            this.groupBox_Trade.SuspendLayout();
            this.SuspendLayout();
            // 
            // axKHOpenAPI
            // 
            this.axKHOpenAPI.Enabled = true;
            this.axKHOpenAPI.Location = new System.Drawing.Point(603, 203);
            this.axKHOpenAPI.Name = "axKHOpenAPI";
            this.axKHOpenAPI.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI.OcxState")));
            this.axKHOpenAPI.Size = new System.Drawing.Size(67, 17);
            this.axKHOpenAPI.TabIndex = 0;
            this.axKHOpenAPI.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_Server, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_UserId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_Account, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(182, 111);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_Server
            // 
            this.label_Server.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(94, 77);
            this.label_Server.Margin = new System.Windows.Forms.Padding(3);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(85, 31);
            this.label_Server.TabIndex = 4;
            this.label_Server.Text = "label_Server";
            this.label_Server.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_UserId
            // 
            this.label_UserId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_UserId.AutoSize = true;
            this.label_UserId.Location = new System.Drawing.Point(94, 40);
            this.label_UserId.Margin = new System.Windows.Forms.Padding(3);
            this.label_UserId.Name = "label_UserId";
            this.label_UserId.Size = new System.Drawing.Size(85, 31);
            this.label_UserId.TabIndex = 4;
            this.label_UserId.Text = "label_Name";
            this.label_UserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "서버";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "계좌번호";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "아이디";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Account
            // 
            this.comboBox_Account.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Account.FormattingEnabled = true;
            this.comboBox_Account.Location = new System.Drawing.Point(94, 3);
            this.comboBox_Account.Name = "comboBox_Account";
            this.comboBox_Account.Size = new System.Drawing.Size(85, 20);
            this.comboBox_Account.TabIndex = 5;
            // 
            // dataGridView_Balance
            // 
            this.dataGridView_Balance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Balance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Balance.Location = new System.Drawing.Point(11, 232);
            this.dataGridView_Balance.Name = "dataGridView_Balance";
            this.dataGridView_Balance.RowTemplate.Height = 23;
            this.dataGridView_Balance.Size = new System.Drawing.Size(740, 61);
            this.dataGridView_Balance.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.분석ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 분석ToolStripMenuItem
            // 
            this.분석ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.백테스터열기ToolStripMenuItem});
            this.분석ToolStripMenuItem.Name = "분석ToolStripMenuItem";
            this.분석ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.분석ToolStripMenuItem.Text = "분석";
            // 
            // 백테스터열기ToolStripMenuItem
            // 
            this.백테스터열기ToolStripMenuItem.Name = "백테스터열기ToolStripMenuItem";
            this.백테스터열기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.백테스터열기ToolStripMenuItem.Text = "백테스터 열기";
            this.백테스터열기ToolStripMenuItem.Click += new System.EventHandler(this.백테스터열기ToolStripMenuItem_Click);
            // 
            // richTextBox_Logs
            // 
            this.richTextBox_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Logs.Location = new System.Drawing.Point(12, 479);
            this.richTextBox_Logs.Name = "richTextBox_Logs";
            this.richTextBox_Logs.ReadOnly = true;
            this.richTextBox_Logs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Logs.Size = new System.Drawing.Size(740, 130);
            this.richTextBox_Logs.TabIndex = 8;
            this.richTextBox_Logs.Text = "";
            // 
            // button_LogClear
            // 
            this.button_LogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LogClear.Location = new System.Drawing.Point(677, 615);
            this.button_LogClear.Name = "button_LogClear";
            this.button_LogClear.Size = new System.Drawing.Size(75, 23);
            this.button_LogClear.TabIndex = 9;
            this.button_LogClear.Text = "Clear";
            this.button_LogClear.UseVisualStyleBackColor = true;
            this.button_LogClear.Click += new System.EventHandler(this.button_LogClear_Click);
            // 
            // button_Update
            // 
            this.button_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Update.Location = new System.Drawing.Point(676, 203);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 23);
            this.button_Update.TabIndex = 10;
            this.button_Update.Text = "갱신";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // dataGridView_Stocks
            // 
            this.dataGridView_Stocks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Stocks.Location = new System.Drawing.Point(12, 299);
            this.dataGridView_Stocks.Name = "dataGridView_Stocks";
            this.dataGridView_Stocks.RowTemplate.Height = 23;
            this.dataGridView_Stocks.Size = new System.Drawing.Size(740, 174);
            this.dataGridView_Stocks.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "수량:";
            // 
            // textBox_Quantity
            // 
            this.textBox_Quantity.Location = new System.Drawing.Point(57, 111);
            this.textBox_Quantity.Name = "textBox_Quantity";
            this.textBox_Quantity.Size = new System.Drawing.Size(100, 21);
            this.textBox_Quantity.TabIndex = 23;
            this.textBox_Quantity.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "ETF:";
            // 
            // comboBox_Stock1
            // 
            this.comboBox_Stock1.FormattingEnabled = true;
            this.comboBox_Stock1.Location = new System.Drawing.Point(57, 24);
            this.comboBox_Stock1.Name = "comboBox_Stock1";
            this.comboBox_Stock1.Size = new System.Drawing.Size(200, 20);
            this.comboBox_Stock1.TabIndex = 17;
            // 
            // button_Start
            // 
            this.button_Start.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Start.Location = new System.Drawing.Point(415, 16);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(114, 80);
            this.button_Start.TabIndex = 27;
            this.button_Start.Text = "거래 시작";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // groupBox_Trade
            // 
            this.groupBox_Trade.Controls.Add(this.button_Start);
            this.groupBox_Trade.Controls.Add(this.label7);
            this.groupBox_Trade.Controls.Add(this.textBox_Quantity);
            this.groupBox_Trade.Controls.Add(this.label5);
            this.groupBox_Trade.Controls.Add(this.comboBox_Stock1);
            this.groupBox_Trade.Location = new System.Drawing.Point(216, 38);
            this.groupBox_Trade.Name = "groupBox_Trade";
            this.groupBox_Trade.Size = new System.Drawing.Size(535, 146);
            this.groupBox_Trade.TabIndex = 28;
            this.groupBox_Trade.TabStop = false;
            this.groupBox_Trade.Text = "자동 거래";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 650);
            this.Controls.Add(this.dataGridView_Stocks);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_LogClear);
            this.Controls.Add(this.richTextBox_Logs);
            this.Controls.Add(this.dataGridView_Balance);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.axKHOpenAPI);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox_Trade);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(780, 636);
            this.Name = "MainForm";
            this.Text = "Arbitrader";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Balance)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stocks)).EndInit();
            this.groupBox_Trade.ResumeLayout(false);
            this.groupBox_Trade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label label_UserId;
        private System.Windows.Forms.ComboBox comboBox_Account;
        private System.Windows.Forms.DataGridView dataGridView_Balance;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 분석ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 백테스터열기ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_Logs;
        private System.Windows.Forms.Button button_LogClear;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.DataGridView dataGridView_Stocks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Quantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Stock1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.GroupBox groupBox_Trade;
    }
}

