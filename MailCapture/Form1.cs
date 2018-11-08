using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LumiSoft.Net;
using LumiSoft.Net.POP3.Client;
using LumiSoft.Net.MIME;
using LumiSoft.Net.Mail;
using LumiSoft.Net.Log;

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;

namespace MailCapture
{
    public partial class Form1 : Form
    {
        Config config = new Config();
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            toolStripProgressBar1.Size = new System.Drawing.Size(statusStrip1.Width * 2 / 3, 16);
            toolStripStatusLabel1.Text = "0 sec";
            toolStripStatusLabel1.Spring = true;
            timer1.Enabled = false;
            LISTVIEW_NAME.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            LISTVIEW_NAME.View = View.Details;
            LISTVIEW_NAME.HideSelection = false;
            LISTVIEW_NAME.FullRowSelect = true;
            LISTVIEW_NAME.Columns.Add("姓名", LISTVIEW_NAME.Size.Width / 3);
            LISTVIEW_NAME.Columns.Add("邮箱", LISTVIEW_NAME.Size.Width *2 / 3);
            config.XML_Get_Data();            
            foreach (KeyValuePair<string, string> kvp in config._names)
            {
                ListViewItem item = new ListViewItem();
                item.Text = kvp.Key;
                item.SubItems.Add(kvp.Value);
                LISTVIEW_NAME.Items.Add(item);
            }
            TB_DAILYW.Text = config._report.width.ToString();
            TB_DAILYH.Text = config._report.hight.ToString();
            richTextBox1.Text = config._content_spliter;
        }

        private POP3_Client m_pPop3 = null;
        private int time_count = 0;

        public void AnalysisLog_Thread()
        {
            DateTime dt_start = DatePicker_Start.Value;
            DateTime dt_end = DatePicker_End.Value;
            if(dt_start.Date > dt_end.Date)
            {
                return;
            }
            
            ListView[] all_item = new ListView[12];
            for(int item_index=0;item_index<12;item_index++)
            {
                all_item[item_index] = new ListView();
            }

            POP3_Client pop3 = new POP3_Client();
            
            try
            {
                pop3.Connect("pop.qiye.163.com", WellKnownPorts.POP3, false);
                pop3.Login("panruyang@lx-rs.com", "Lxrs1243");
                m_pPop3 = pop3;
                try
                {
                    int count = 0;
                    this.Invoke(new Action(delegate() //多线程的处理
                    {
                        timer1.Enabled = true;
                        time_count = 0;
                        toolStripProgressBar1.Value = 0;
                        toolStripProgressBar1.Minimum = 0;
                        toolStripProgressBar1.Maximum = m_pPop3.Messages.Count;
                        toolStripProgressBar1.Step = 1;
                    }));
                    foreach (POP3_ClientMessage message in m_pPop3.Messages)
                    {
                        this.Invoke(new Action(delegate() //多线程的处理
                        {
                            toolStripProgressBar1.Value++;
                        }));
                        Mail_Message mime = Mail_Message.ParseFromByte(message.HeaderToByte());
                        ListViewItem item = new ListViewItem();
                        if (string.IsNullOrEmpty(mime.Subject) || !mime.Subject.Contains("工作日"))
                        {
                            continue;
                        }                      
                        
                        if(mime.Date > dt_start.Date && mime.Date < dt_end.AddDays(1).Date)
                        {
                            item.Text = mime.Subject.ToString();    //1.subject
                            item.SubItems.Add(mime.Date.ToString()); //2.date
                        }
                        else
                        {
                            continue;
                        }

                        if (mime.From != null) //3.sender
                        {
                            string addr = mime.From.ToString();
                            string show_name = addr.Substring(addr.IndexOf("<")+1,addr.IndexOf(">")-addr.IndexOf("<") - 1);
                            bool exist = false;
                            foreach (KeyValuePair<string, string> kvp in config._names)
                            {
                                if (kvp.Value.Equals(show_name))
                                {
                                    item.SubItems.Add(kvp.Key);
                                    exist = true;
                                    break;
                                }                               
                            }    
                            if(!exist)
                                item.SubItems.Add(show_name);
                        }
                        else
                        {
                            item.SubItems.Add("<none>");
                        }
                        
                        item.SubItems.Add(((decimal)(message.Size / (decimal)1000)).ToString("f2") + " kb"); //4. size                        
                        Mail_Message mimeBody = Mail_Message.ParseFromByte(message.MessageToByte());
                        if (mimeBody.BodyText != null)
                        {
                            item.SubItems.Add(mimeBody.BodyText); //5.content
                        }
                        else
                        {
                            mimeBody = Mail_Message.ParseFromByte(message.MessageToByte());
                            string content = null;
                            this.Invoke(new Action(delegate() //多线程的处理
                            {
                                HtmlToText convert = new HtmlToText();
                                content = convert.Convert(mimeBody.BodyHtmlText);                                
                            }));
                            item.SubItems.Add(content); //5.content
                        }
                      
                        string date_time = item.SubItems[1].Text;
                        int index = date_time.IndexOf("/");
                        string month = date_time.Substring(index + 1, date_time.IndexOf("/", index + 1) - index - 1);
                        month.Trim();
                        all_item[Convert.ToInt16(month) - 1].Items.Add(item);
                        if (count > 10)
                            break;
                        //count++;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(this, "POP3 server returned: " + x.Message + " !", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pop3.Dispose();
            }

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

                int month_count = 0;
                int month = 0;
                for (; month < 12; month++)
                {
                    if (all_item[month].Items.Count == 0)
                        continue; 

                    month_count++;
                    if (month_count <= 3)
                    { 
                        oSheet = (Excel._Worksheet)oWB.Worksheets[month_count];
                    }
                    else
                    { 
                        oSheet = oWB.Worksheets.Add(); 
                    }
                    //oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                    oSheet.Activate();
                    oSheet.Name = (month + 1).ToString() + "月份";
                 
                    oRng = oSheet.get_Range("A1:BA1", Missing.Value);
                    if (TB_DAILYW.Text != "")
                        oRng.ColumnWidth = Convert.ToInt16(TB_DAILYW.Text);
                    else
                        oRng.ColumnWidth = 40;
                  //  oRng.Interior.ColorIndex = 35;

                    oRng = oSheet.get_Range("A1:A30", Missing.Value);
                    if (TB_DAILYH.Text != "")
                        oRng.RowHeight = Convert.ToInt16(TB_DAILYH.Text);
                    else
                        oRng.RowHeight = 25;
                   
                  //  oRng.Interior.ColorIndex = 36;
                    oRng.Font.Bold = true;

                    oRng = oSheet.get_Range("A1:BA50", Missing.Value);
                    oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                   // oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    oRng = oSheet.get_Range("B2:BA50", Missing.Value);
                    oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                                                          
                    int iRow = 1, iColumn = 1;
                    ArrayList send_name = new ArrayList();
                    ArrayList send_date = new ArrayList();
                    string name = null;
                    send_name.Add("No1"); send_date.Add("No1");
                    foreach (ListViewItem item in all_item[month].Items)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            if (i == 1) //date
                            {
                                string date_time = item.SubItems[1].Text;
                                string date = date_time.Substring(0, date_time.IndexOf(":") - 2).Trim();
                                date.Trim();
                                bool date_exist = false;
                                for (int j = 0; j < send_date.Count; j++)
                                {
                                    if (send_date[j].ToString() == date)
                                    {
                                        date_exist = true;
                                        iColumn = j + 1;
                                    }
                                }
                                if (!date_exist)
                                {
                                    send_date.Add(date);
                                    iColumn = send_date.Count;
                                }
                                oSheet.Cells[1, iColumn] = date;
                            }

                            if (i == 2) //sender
                            {
                                name = item.SubItems[2].Text.ToString().Trim();                               
                                bool name_exist = false;
                                for (int j = 0; j < send_name.Count; j++)
                                {
                                    if (send_name[j].ToString() == name)
                                    {
                                        name_exist = true;
                                        iRow = j + 1;
                                    }
                                }
                                if (!name_exist)
                                {
                                    send_name.Add(name);
                                    iRow = send_name.Count;
                                }
                                oSheet.Cells[iRow, 1] = name.Replace(" ","");
                            }

                            if (i == 4) //content
                            {
                                string content = item.SubItems[4].Text;
                                if(content.Contains(name))
                                {
                                    content = content.Substring(0, content.IndexOf(name));
                                }

                                if (content.Contains(name.Substring(0,1) + " " + name.Substring(1)))
                                {
                                    content = content.Substring(0, content.IndexOf(name.Substring(0, 1) + " " + name.Substring(1)));
                                }


                                string[] words=null;                                
                                this.Invoke(new Action(delegate() 
                                {
                                    words = richTextBox1.Text.Split(';');
                                    for (int index = 0; index < words.Count(); index++)
                                    {
                                        if (words[index]!="")
                                            content = content.Replace(words[index], "");
                                    }    
                                }));
                                string[] sentence =null;
                                if (!content.Contains("\r\n") && content.Contains("\n"))
                                {
                                    sentence = Regex.Split(content, "\n");
                                }
                                else
                                {
                                    sentence = Regex.Split(content, "\r\n");
                                }
                                content = "";
                                foreach(string sen in sentence)
                                {                                   
                                    const string pattern = @"[~ ,，:：.\.><]"; //删除数字和小数点，其他保留
                                    Regex rx = new Regex(pattern);
                                    string result = rx.Replace(sen, "");
                                    if (result != "")
                                    {                                        
                                        content += sen.Trim() + "\r\n";
                                    }
                                }                             
                                oSheet.Cells[iRow, iColumn] = content;
                            }                            
                        }
                    }                    
                    oXL.UserControl = true;
                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
            timer1.Enabled = false;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            time_count++;
            toolStripStatusLabel1.Text = time_count.ToString() + " sec";
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread m_thread = new Thread(AnalysisLog_Thread);
            m_thread.Start();
        }

        private void BTN_NAME_ADD_Click(object sender, EventArgs e)
        {
            string show_name = TB_ShowName.Text;//邮箱
            string real_name = TB_RealName.Text;//姓名
            if (real_name == "" || show_name == "") 
            {
                return;
            }
            ListViewItem item = new ListViewItem();
            item.Text = real_name;
            item.SubItems.Add(show_name);
            LISTVIEW_NAME.Items.Add(item);
            config.XML_Add_Name(real_name + "," + show_name);
            TB_ShowName.Text = "";
            TB_RealName.Text = "";
        }

        private void BTN_NAME_DL_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LISTVIEW_NAME.SelectedItems)  //选中项遍历
            {
                LISTVIEW_NAME.Items.Remove(lvi); // 按索引移除  
                config.XML_Del_Name(lvi.SubItems[0].Text + "," + lvi.SubItems[1].Text);
            }
        }

        private void TB_DAILYW_TextChanged(object sender, EventArgs e)
        {
            Report data=new Report();
            if (TB_DAILYW.Text != "")
                data.width=Convert.ToInt16( TB_DAILYW.Text);
            if (TB_DAILYH.Text != "")
                data.hight=Convert.ToInt16( TB_DAILYH.Text);
            if (TB_DAILYW.Text != "" && TB_DAILYH.Text != "")
            config.XML_Modify_Report(data);
        }

        private void TB_DAILYH_TextChanged(object sender, EventArgs e)
        {
            Report data;
            data.width = Convert.ToInt16(TB_DAILYW.Text);
            data.hight = Convert.ToInt16(TB_DAILYH.Text);
            config.XML_Modify_Report(data);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            config.XML_Modify_Content(richTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DataPicker_Start_ValueChanged(object sender, EventArgs e)
        {

        }
        
    }
}
