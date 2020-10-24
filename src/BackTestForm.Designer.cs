namespace DayTrader
{
    partial class BackTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Margin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Quantity = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_UseMinute = new System.Windows.Forms.CheckBox();
            this.comboBox_Stock3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Interval = new System.Windows.Forms.ComboBox();
            this.button_Test = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Stock2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Stock1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Duration = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(60, 20);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_Begin.TabIndex = 0;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(60, 50);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_End.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "시작일:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "종료일:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Duration);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_Margin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_Quantity);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox_UseMinute);
            this.groupBox1.Controls.Add(this.comboBox_Stock3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_Interval);
            this.groupBox1.Controls.Add(this.button_Test);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_Stock2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Stock1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_Begin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 241);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "설정";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "마진(%): ";
            // 
            // textBox_Margin
            // 
            this.textBox_Margin.Location = new System.Drawing.Point(235, 174);
            this.textBox_Margin.Name = "textBox_Margin";
            this.textBox_Margin.Size = new System.Drawing.Size(100, 21);
            this.textBox_Margin.TabIndex = 15;
            this.textBox_Margin.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "수량:";
            // 
            // textBox_Quantity
            // 
            this.textBox_Quantity.Location = new System.Drawing.Point(60, 174);
            this.textBox_Quantity.Name = "textBox_Quantity";
            this.textBox_Quantity.Size = new System.Drawing.Size(100, 21);
            this.textBox_Quantity.TabIndex = 13;
            this.textBox_Quantity.Text = "1000";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 201);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(315, 23);
            this.progressBar.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "종목3:";
            // 
            // checkBox_UseMinute
            // 
            this.checkBox_UseMinute.AutoSize = true;
            this.checkBox_UseMinute.Location = new System.Drawing.Point(292, 20);
            this.checkBox_UseMinute.Name = "checkBox_UseMinute";
            this.checkBox_UseMinute.Size = new System.Drawing.Size(76, 16);
            this.checkBox_UseMinute.TabIndex = 11;
            this.checkBox_UseMinute.Text = "분봉 사용";
            this.checkBox_UseMinute.UseVisualStyleBackColor = true;
            this.checkBox_UseMinute.CheckedChanged += new System.EventHandler(this.checkBox_UseMinute_CheckedChanged);
            // 
            // comboBox_Stock3
            // 
            this.comboBox_Stock3.FormattingEnabled = true;
            this.comboBox_Stock3.Location = new System.Drawing.Point(60, 139);
            this.comboBox_Stock3.Name = "comboBox_Stock3";
            this.comboBox_Stock3.Size = new System.Drawing.Size(200, 20);
            this.comboBox_Stock3.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "분봉:";
            // 
            // comboBox_Interval
            // 
            this.comboBox_Interval.FormattingEnabled = true;
            this.comboBox_Interval.Location = new System.Drawing.Point(341, 42);
            this.comboBox_Interval.Name = "comboBox_Interval";
            this.comboBox_Interval.Size = new System.Drawing.Size(62, 20);
            this.comboBox_Interval.TabIndex = 9;
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(328, 201);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(75, 23);
            this.button_Test.TabIndex = 8;
            this.button_Test.Text = "테스트";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "종목2:";
            // 
            // comboBox_Stock2
            // 
            this.comboBox_Stock2.FormattingEnabled = true;
            this.comboBox_Stock2.Location = new System.Drawing.Point(60, 113);
            this.comboBox_Stock2.Name = "comboBox_Stock2";
            this.comboBox_Stock2.Size = new System.Drawing.Size(200, 20);
            this.comboBox_Stock2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "종목1: ";
            // 
            // comboBox_Stock1
            // 
            this.comboBox_Stock1.FormattingEnabled = true;
            this.comboBox_Stock1.Location = new System.Drawing.Point(60, 87);
            this.comboBox_Stock1.Name = "comboBox_Stock1";
            this.comboBox_Stock1.Size = new System.Drawing.Size(200, 20);
            this.comboBox_Stock1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "기간((일):";
            // 
            // textBox_Duration
            // 
            this.textBox_Duration.Location = new System.Drawing.Point(348, 138);
            this.textBox_Duration.Name = "textBox_Duration";
            this.textBox_Duration.Size = new System.Drawing.Size(62, 21);
            this.textBox_Duration.TabIndex = 19;
            this.textBox_Duration.Text = "20";
            // 
            // BackTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 264);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackTestForm";
            this.Text = "BackTestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackTestForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Stock1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Stock2;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Interval;
        private System.Windows.Forms.CheckBox checkBox_UseMinute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Stock3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Quantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Margin;
        private System.Windows.Forms.TextBox textBox_Duration;
        private System.Windows.Forms.Label label9;
    }
}