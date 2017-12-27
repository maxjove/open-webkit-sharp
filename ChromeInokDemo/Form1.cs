using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChromeInokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            ChromeForDoNet.WebInvoice.CallWebBrower(@"E:\nl_ychz(1).html", 99999, 99999);
            else
                ChromeForDoNet.WebInvoice.CallWebBrower(textBox1.Text, 99999, 99999);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChromeForDoNet.WebInvoice.CallWebBrower("http://ultrasounds.com/", 99999, 99999);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //ChromeForDoNet.fileCutCombine.CutFile("costura32.zip", 2048000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string[] strpath = Directory.GetFiles("ChromeOrn");
            //Array.Sort(strpath, string.CompareOrdinal);
            //ChromeForDoNet.fileCutCombine.CombineFiles(strpath, "costura32.zip");
        }
    }
}
