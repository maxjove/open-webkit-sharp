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
    public partial class frmSYS_WebBrowerChrome : XtraForm
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
                this._url = value;
            }
        }
        public frmSYS_WebBrowerChrome()
        {
            this._url = "";
            InitializeComponent();

        }
        public frmSYS_WebBrowerChrome(string url)
        {
            this._url = url;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

    }
}
