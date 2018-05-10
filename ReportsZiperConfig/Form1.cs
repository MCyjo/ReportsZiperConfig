using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsZiperConfig
{
    public partial class Form1 : Form
    {
        LoadXmlResult xmlResult;

        public Form1()
        {
            InitializeComponent();
            xmlResult = LoadFromXMLConfig.LoadFromXML();

            foreach (string path in xmlResult.PathList)
            {
                listBox1.Items.Add(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveToXmlConfig.saveToXml(xmlResult, this.listBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();
            DialogResult result = openFolderDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(openFolderDialog1.SelectedPath);
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("ReportsZiper.exe");
        }
    }
}
