using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace ReportsZiperConfig
{
    public static class SaveToXmlConfig
    {
        public static void saveToXml(LoadXmlResult xmlResult, ListBox listBox1)
            {
            //  LoadFromXMLConfig.xmlDocument.r      
            //Removes all old nodes in Config node

            XmlDocument doc = new XmlDocument();
            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //config node
            XmlElement element1 = doc.CreateElement(string.Empty, "config", string.Empty);
            doc.AppendChild(element1);

            /*
            //frequency node
            XmlElement element2 = doc.CreateElement(string.Empty, "frequency", string.Empty);
            XmlText text = doc.CreateTextNode(comboBox1.SelectedItem.ToString());
            element2.AppendChild(text);
            element1.AppendChild(element2);
            */

            List<XmlElement> xElements = new List<XmlElement>();
            foreach (string path in listBox1.Items)
            {
                //frequency node
                xElements.Add(doc.CreateElement(string.Empty, "path", string.Empty));
                XmlText text2 = doc.CreateTextNode(path);
                xElements[xElements.Count - 1].AppendChild(text2);
                element1.AppendChild(xElements[xElements.Count-1]);
            }
            doc.Save("Config.xml");

            /*
            XmlNodeList pathNodes = LoadFromXMLConfig.xmlDocument.SelectNodes("/Config/path");
            foreach (XmlNode path in pathNodes)
            {
                XmlAttribute pathAttribute = path.Attributes["path"];
                path.InnerText = TextBox1.Text;
            }
            doc.Save("D:/WEBROOT/XMLINS/XMLINS/XMLFile1.xml");
            Label1.Text = "XML updated Successfully";
            */
        } 
    }
}
