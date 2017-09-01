using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebKit.Interop;
using WebKit;

namespace WebKit4Net2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebKitBrowser wb = new WebKitBrowser();
            wb.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(wb);
            wb.PopupCreated += Wb_PopupCreated;
            wb.CloseWindowRequest += Wb_CloseWindowRequest;
          
            wb.Navigate("https://www.quirksmode.org/js/popup.html");


        }

        private void Wb_CloseWindowRequest(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Wb_PopupCreated(object sender, NewWindowCreatedEventArgs e)
        {
            //throw new NotImplementedException();
            Form f = new Form();
            
            f.Show();
            WebKitBrowser wb = e.WebKitBrowser;
            wb.AllowDownloads = true;
            wb.Visible = true;
            wb.Name = "browser";
            wb.Dock = DockStyle.Fill;
            wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            wb.FaviconAvailable += new FaviconAvailable(wb_FaviconAvaiable);
            wb.CloseWindowRequest += Wb_CloseWindowRequest1;
            f.Controls.Add(wb);
        }

        private void Wb_CloseWindowRequest1(object sender, EventArgs e)
        {
            WebKitBrowser wbclild = (sender as WebKitBrowser);
            if (wbclild != null)
            {
               
                wbclild.ParentForm.Close();
            }
           
        }

        void wb_DocumentTitleChanged(object sender, EventArgs e)
        {
            ((Form)((WebKitBrowser)sender).Parent).Text = ((WebKitBrowser)sender).DocumentTitle;
        }

        void wb_FaviconAvaiable(object sender, FaviconAvailableEventArgs e)
        {
            ((Form)((WebKitBrowser)sender).Parent).Icon = e.Favicon;
        }
    }
}
