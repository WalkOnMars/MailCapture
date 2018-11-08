using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MailCapture
{

    struct Report
    {
        public int width, hight;
    }

    class Config
    {
        
        public static string xmlpath = "MailCapture.xml";

        public XmlDocument doc= new XmlDocument();

        public Dictionary<string, string> _names = new Dictionary<string, string>();

       // private int _iReport_width, _iReport_hight;

        public string _content_spliter = "";

        public Report _report;

        public void XML_Get_Data()
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("Config");
            _names.Clear();
            foreach (XmlNode node in nodes)
            {
                string id = ((XmlElement)node).GetAttribute("id");
                if (id == "names")
                {
                    foreach (XmlElement ele in node)
                    {
                        string[] pair = ele.InnerText.Split(',');
                        _names.Add(pair[0], pair[1]);                        
                    }                    
                }

                if (id == "report")
                {
                    XmlElement ele = node["size"];
                    string[] pair = ele.InnerText.Split(',');
                    _report.width = Convert.ToInt16(pair[0]);
                    _report.hight = Convert.ToInt16(pair[1]);
                }

                if (id == "content")
                {
                    XmlElement ele = node["spliter"];
                    _content_spliter = ele.InnerText;    
                }
            }
        }

        public void XML_Add_Name(string pair_name)
        {
            string[] pair = pair_name.Split(',');
            _names.Add(pair[0], pair[1]);
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodelist = doc.GetElementsByTagName("Config");
            XmlElement code = doc.CreateElement("item"); 
            XmlText xmlText = doc.CreateTextNode(pair_name);
            code.AppendChild(xmlText);
            nodelist.Item(0).AppendChild(code);
            doc.Save(xmlpath);
        }

        public void XML_Del_Name(string del_node_text)
        {
            _names.Remove(del_node_text.Split(',')[0]);            
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodelist = doc.GetElementsByTagName("Config");
            foreach (XmlElement ele in nodelist.Item(0))
            {
                if (ele.InnerText == del_node_text)
                {
                    nodelist.Item(0).RemoveChild(ele); //执行完成这条指令，将会退出foreach
                }
            }
            doc.Save(xmlpath);
        }

        public void XML_Modify_Report(Report data)
        {
            _report.width = data.width;
            _report.hight = data.hight;

            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("Config");
            foreach (XmlElement ele in nodes[1])
            {
                if (ele.Name == "size")
                {
                    ele.InnerText = data.width.ToString() + "," + data.hight.ToString();
                }
            }

            doc.Save(xmlpath);
        }

        public void XML_Modify_Content(string data)
        {
            _content_spliter = data;
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("Config");
            foreach (XmlElement ele in nodes.Item(2))
            {
                if (ele.Name == "spliter")
                {
                    ele.InnerText = data;
                }
            }
            doc.Save(xmlpath);
        }
    }
}
