namespace MailCapture
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_DAILYW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_DAILYH = new System.Windows.Forms.TextBox();
            this.LISTVIEW_NAME = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_ShowName = new System.Windows.Forms.TextBox();
            this.TB_RealName = new System.Windows.Forms.TextBox();
            this.BTN_NAME_ADD = new System.Windows.Forms.Button();
            this.BTN_NAME_DL = new System.Windows.Forms.Button();
            this.DatePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.DatePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Green;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.settingToolStripMenuItem.Text = "File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(515, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 337);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(480, 82);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "正文中需要过滤的文本(以分号隔开)";
            // 
            // TB_DAILYW
            // 
            this.TB_DAILYW.Location = new System.Drawing.Point(70, 278);
            this.TB_DAILYW.Name = "TB_DAILYW";
            this.TB_DAILYW.Size = new System.Drawing.Size(100, 21);
            this.TB_DAILYW.TabIndex = 8;
            this.TB_DAILYW.TextChanged += new System.EventHandler(this.TB_DAILYW_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "日志宽度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "日志高度";
            // 
            // TB_DAILYH
            // 
            this.TB_DAILYH.Location = new System.Drawing.Point(248, 278);
            this.TB_DAILYH.Name = "TB_DAILYH";
            this.TB_DAILYH.Size = new System.Drawing.Size(100, 21);
            this.TB_DAILYH.TabIndex = 10;
            this.TB_DAILYH.TextChanged += new System.EventHandler(this.TB_DAILYH_TextChanged);
            // 
            // LISTVIEW_NAME
            // 
            this.LISTVIEW_NAME.Location = new System.Drawing.Point(14, 96);
            this.LISTVIEW_NAME.Name = "LISTVIEW_NAME";
            this.LISTVIEW_NAME.Size = new System.Drawing.Size(480, 166);
            this.LISTVIEW_NAME.TabIndex = 12;
            this.LISTVIEW_NAME.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "姓名邮箱对应表";
            // 
            // TB_ShowName
            // 
            this.TB_ShowName.Location = new System.Drawing.Point(222, 68);
            this.TB_ShowName.Name = "TB_ShowName";
            this.TB_ShowName.Size = new System.Drawing.Size(108, 21);
            this.TB_ShowName.TabIndex = 14;
            // 
            // TB_RealName
            // 
            this.TB_RealName.Location = new System.Drawing.Point(106, 68);
            this.TB_RealName.Name = "TB_RealName";
            this.TB_RealName.Size = new System.Drawing.Size(108, 21);
            this.TB_RealName.TabIndex = 15;
            // 
            // BTN_NAME_ADD
            // 
            this.BTN_NAME_ADD.Location = new System.Drawing.Point(338, 67);
            this.BTN_NAME_ADD.Name = "BTN_NAME_ADD";
            this.BTN_NAME_ADD.Size = new System.Drawing.Size(75, 23);
            this.BTN_NAME_ADD.TabIndex = 16;
            this.BTN_NAME_ADD.Text = "添加";
            this.BTN_NAME_ADD.UseVisualStyleBackColor = true;
            this.BTN_NAME_ADD.Click += new System.EventHandler(this.BTN_NAME_ADD_Click);
            // 
            // BTN_NAME_DL
            // 
            this.BTN_NAME_DL.Location = new System.Drawing.Point(419, 67);
            this.BTN_NAME_DL.Name = "BTN_NAME_DL";
            this.BTN_NAME_DL.Size = new System.Drawing.Size(75, 23);
            this.BTN_NAME_DL.TabIndex = 17;
            this.BTN_NAME_DL.Text = "删除";
            this.BTN_NAME_DL.UseVisualStyleBackColor = true;
            this.BTN_NAME_DL.Click += new System.EventHandler(this.BTN_NAME_DL_Click);
            // 
            // DatePicker_Start
            // 
            this.DatePicker_Start.Location = new System.Drawing.Point(106, 34);
            this.DatePicker_Start.Name = "DatePicker_Start";
            this.DatePicker_Start.Size = new System.Drawing.Size(108, 21);
            this.DatePicker_Start.TabIndex = 18;
            this.DatePicker_Start.ValueChanged += new System.EventHandler(this.DataPicker_Start_ValueChanged);
            // 
            // DatePicker_End
            // 
            this.DatePicker_End.Location = new System.Drawing.Point(222, 34);
            this.DatePicker_End.Name = "DatePicker_End";
            this.DatePicker_End.Size = new System.Drawing.Size(108, 21);
            this.DatePicker_End.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "起始终止日期";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 447);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DatePicker_End);
            this.Controls.Add(this.DatePicker_Start);
            this.Controls.Add(this.BTN_NAME_DL);
            this.Controls.Add(this.BTN_NAME_ADD);
            this.Controls.Add(this.TB_RealName);
            this.Controls.Add(this.TB_ShowName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LISTVIEW_NAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_DAILYH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_DAILYW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MailCapture V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_DAILYW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_DAILYH;
        private System.Windows.Forms.ListView LISTVIEW_NAME;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_ShowName;
        private System.Windows.Forms.TextBox TB_RealName;
        private System.Windows.Forms.Button BTN_NAME_ADD;
        private System.Windows.Forms.Button BTN_NAME_DL;
        private System.Windows.Forms.DateTimePicker DatePicker_Start;
        private System.Windows.Forms.DateTimePicker DatePicker_End;
        private System.Windows.Forms.Label label5;
    }
}

