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
            :base()
        {
            this.PopupCreated -= Wb_PopupCreated;
            this.CloseWindowRequest -= Wb_CloseWindowRequest;
            this.ShowJavaScriptAlertPanel -= Wb_ShowJavaScriptAlertPanel;
            this.PopupCreated += Wb_PopupCreated;
            this.CloseWindowRequest += Wb_CloseWindowRequest;
            this.ShowJavaScriptAlertPanel += Wb_ShowJavaScriptAlertPanel;
           
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
