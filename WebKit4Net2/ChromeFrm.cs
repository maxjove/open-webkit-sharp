using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebKit.Interop;
using WebKit;
using System.IO;
using ChromeForDoNet.Properties;
using System.Threading;
using DevExpress.XtraEditors;

namespace ChromeForDoNet
{
    public partial class ChromeFrm : XtraForm
    {

       
        private string _url = "";
        public string URL
        {
            get
            {
                return this._url;
            }
            set
            {
                if (File.Exists(value))
                {
                    string tmpurl = new Uri(value, UriKind.RelativeOrAbsolute).AbsoluteUri;
                    this._url = tmpurl;
                }
                else
                {
                    if (value.StartsWith("http") || value.StartsWith("www"))
                        this._url = value;
                    else if (value.StartsWith("file:"))
                    {
                        Uri rn = new Uri(value, UriKind.RelativeOrAbsolute);
                        if (!File.Exists(rn.LocalPath))
                        {
                            this.URL = Application.StartupPath + @"\404.html";
                        }

                    }
                    else
                        this.URL = Application.StartupPath + @"\404.html";
                }
            }
        }
        public ChromeFrm()
        {
            this._url = "";
            InitializeComponent();

        }
        public ChromeFrm(string url)
        {
            this._url = url;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1.Hide();
            WebKitBrowser wb = this.webKitBrower4Net21;

            if (string.IsNullOrEmpty(this._url))
            {
                wb.Navigate("http://ie.icoa.cn/");
                // wb.Navigate("https://www.baidu.com");
            }
            else
            {
                wb.Navigate(this._url);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebKitBrowser wb = this.webKitBrower4Net21;
            this.URL = textBox1.Text;
            wb.Navigate(this._url);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
