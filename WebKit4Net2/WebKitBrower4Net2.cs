using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WebKit;
using ChromeForDoNet.Properties;

namespace ChromeForDoNet
{
    class WebKitBrower4Net2: WebKitBrowser
    {
        static WebKitBrower4Net2()
        {
             ResaleFile(null);
            
        }
        public WebKitBrower4Net2()
        {
            this.AllowNewWindows = true;

            this.PopupCreated -= Wb_PopupCreated;
            this.CloseWindowRequest -= Wb_CloseWindowRequest;
            this.ShowJavaScriptAlertPanel -= Wb_ShowJavaScriptAlertPanel;
            this.NewWindowCreated -= WebKitBrower4Net2_NewWindowCreated;

            this.PopupCreated += Wb_PopupCreated;
            this.CloseWindowRequest += Wb_CloseWindowRequest;
            this.ShowJavaScriptAlertPanel += Wb_ShowJavaScriptAlertPanel;
            this.NewWindowCreated += WebKitBrower4Net2_NewWindowCreated;
            this.NewWindowRequest += WebKitBrower4Net2_NewWindowRequest;
            this.CloseWindowRequest += WebKitBrower4Net2_CloseWindowRequest;
           
           
        }

        private string urlnewindowsRst = "";
        private string urloldwindwos = "";
        private void WebKitBrower4Net2_NewWindowRequest(object sender, NewWindowRequestEventArgs e)
        {
            //if (urlnewindowsRst == e.Url)
            //{
            //    urlnewindowsRst = "";
            //}
            //else
            //{
                if (e.Url != null)
                    urlnewindowsRst = e.Url;
            //}
            if (!IsValidUrl(urlnewindowsRst))
                return;

            Form f = new Form();
            f.Text = "NW";
           
            f.Text = "NW:" + this.urlnewindowsRst;
            //f.WindowState = FormWindowState.Maximized;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowIcon = false;
            //f.ShowInTaskbar = false;
            WebKitBrowser wb = new WebKitBrowser();

            wb.AllowDownloads = true;
            wb.Visible = true;
            wb.Name = "browser";
            wb.Dock = DockStyle.Fill;

            wb.DocumentTitleChanged -= new EventHandler(wb_DocumentTitleChanged);
            wb.FaviconAvailable -= new FaviconAvailable(wb_FaviconAvaiable);
            wb.CloseWindowRequest -= Wb_CloseWindowRequest1;

            wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            wb.FaviconAvailable += new FaviconAvailable(wb_FaviconAvaiable);
            wb.CloseWindowRequest += Wb_CloseWindowRequest1;

            f.Controls.Add(wb);
            wb.Navigate(urlnewindowsRst);
            f.Show();


            //throw new NotImplementedException();
        }
        static bool IsValidUrl(string urlString)
        {
            Uri uri;
            return Uri.TryCreate(urlString, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp
                 || uri.Scheme == Uri.UriSchemeHttps
                 || uri.Scheme == Uri.UriSchemeFtp
                 || uri.Scheme == Uri.UriSchemeMailto
                    /*...*/);
        }

        private void WebKitBrower4Net2_NewWindowCreated(object sender, NewWindowCreatedEventArgs e)
        {
           // urlnewindowsRst = "";
            //    if (!IsValidUrl(urlnewindowsRst))
            //        return;

            //    Form f = new Form();
            //    f.Text = "NW";
            //    if (e.WebKitBrowser.Url != null && !string.IsNullOrEmpty(e.WebKitBrowser.Url.ToString()))
            //    {
            //        f.Text = "NW:" + e.WebKitBrowser.Url.ToString();
            //        this.urlnewindowsRst = e.WebKitBrowser.Url.ToString();
            //    }
            //    else
            //        f.Text = "NW:" + this.urlnewindowsRst;
            //    //f.WindowState = FormWindowState.Maximized;
            //    f.StartPosition = FormStartPosition.CenterParent;
            //    f.ShowIcon = false;
            //    //f.ShowInTaskbar = false;
            //    WebKitBrowser wb = e.WebKitBrowser;

            //    wb.AllowDownloads = true;
            //    wb.Visible = true;
            //    wb.Name = "browser";
            //    wb.Dock = DockStyle.Fill;

            //    wb.DocumentTitleChanged -= new EventHandler(wb_DocumentTitleChanged);
            //    wb.FaviconAvailable -= new FaviconAvailable(wb_FaviconAvaiable);
            //    wb.CloseWindowRequest -= Wb_CloseWindowRequest1;

            //    wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            //    wb.FaviconAvailable += new FaviconAvailable(wb_FaviconAvaiable);
            //    wb.CloseWindowRequest += Wb_CloseWindowRequest1;

            //    f.Controls.Add(wb);
            //    wb.Navigate(urlnewindowsRst);
            //    f.ShowDialog();
            //    // wb.Navigate(urlnewindowsRst);

            //    //urlnewindowsRst = "";
            //    //throw new NotImplementedException();
        }

        private void WebKitBrower4Net2_CloseWindowRequest(object sender, EventArgs e)
        {
            WebKitBrowser wb = (sender as WebKitBrowser);
            //throw new NotImplementedException();
        }

       

        private void Wb_ShowJavaScriptAlertPanel(object sender, ShowJavaScriptAlertPanelEventArgs e)
        {
            MessageBox.Show(e.Message, "网页信息");
            // throw new NotImplementedException();
        }

        private void Wb_CloseWindowRequest(object sender, EventArgs e)
        {
           
                this.ParentForm.Close();
            
        }

        private void Wb_PopupCreated(object sender, NewWindowCreatedEventArgs e)
        {
            if (e.WebKitBrowser.Url==null || !IsValidUrl(e.WebKitBrowser.Url.ToString()))
                return;
           
            Form f = new Form();
            f.Text = e.WebKitBrowser.Url.ToString();
            f.WindowState = FormWindowState.Maximized;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowIcon = false;
            f.ShowInTaskbar = false;
            WebKitBrowser wb = e.WebKitBrowser;
            wb.AllowDownloads = true;
            wb.Visible = true;
            wb.Name = "browser";
            wb.Dock = DockStyle.Fill;
            wb.DocumentTitleChanged -= new EventHandler(wb_DocumentTitleChanged);
            wb.FaviconAvailable -= new FaviconAvailable(wb_FaviconAvaiable);
            wb.CloseWindowRequest -= Wb_CloseWindowRequest1;
            wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            wb.FaviconAvailable += new FaviconAvailable(wb_FaviconAvaiable);
            wb.CloseWindowRequest += Wb_CloseWindowRequest1;
           
            f.Controls.Add(wb);
            f.ShowDialog();
            f.Close();
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
            if (((WebKitBrowser)sender).Parent != null)
            {
                ((Form)((WebKitBrowser)sender).Parent).Text = ((WebKitBrowser)sender).DocumentTitle+" :" +((WebKitBrowser)sender).Url;
            }
        }

        void wb_FaviconAvaiable(object sender, FaviconAvailableEventArgs e)
        {
            if (((WebKitBrowser)sender).Parent != null)
                ((Form)((WebKitBrowser)sender).Parent).Icon = e.Favicon;
        }
       static void  ResaleFile(object stat)
        {
            try
            {
                if (!File.Exists("costura32.zip"))
                {
                    byte[] array3 = (byte[])Resources.ResourceManager.GetObject("costura32");
                    FileStream fileStream = new FileStream("costura32.zip", FileMode.CreateNew);
                    fileStream.Write(array3, 0, array3.Length);
                    fileStream.Close();
                }
                ZipUtils.BonkerZip bp = new ZipUtils.BonkerZip();
                bp.DeCompressionZip("costura32.zip", "");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }
    }
}
