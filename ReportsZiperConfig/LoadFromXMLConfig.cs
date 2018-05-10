using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace ReportsZiperConfig
{
    public static class LoadFromXMLConfig
    {
        public static XmlDocument xmlDocument;
        

        public static LoadXmlResult LoadFromXML()
        {
            LoadXmlResult loadXmlResult= new LoadXmlResult();

            xmlDocument = new XmlDocument();    //creates xml doc
            try
            {
                xmlDocument.Load("Config.xml"); //loads config file to xml doc
            }
            catch
            {
                MessageBox.Show("Nie odnaleziono pliku z konfiguracją. W folderze z programem ReportsZiperConfig.exe powinien znajdowac sie odpowiedni plik Config.xml");
            }

            XmlNodeList pathsList = xmlDocument.GetElementsByTagName("path");
            foreach(XmlNode path in pathsList)      //creates a list of paths to folders
            {
                loadXmlResult.PathList.Add(path.InnerText.ToString());
            }

            /*
            XmlNodeList freq = xmlDocument.GetElementsByTagName("frequency");
            loadXmlResult.frequency = freq[0].InnerText.ToString();
            */

            return loadXmlResult;
        }
       
        
    }
}
