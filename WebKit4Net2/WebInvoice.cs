using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ChromeKCore
{
    public class WebInvoice
    {
        public static Form wbfrm = null;
        public static void Navigate(string url)
        {
            CallWebBrower(url, 99999, 99999);
        }

        public static void CallWebBrower(string url, int height, int width)
        {
            try
            {
                //if (Directory.Exists("Chrome_dir"))
                //{

                //}
                //else
                //{
                if (File.Exists("ZipUtils.dll"))
                {
                    // MessageBox.Show("delete2 ZipUtils.dll");
                    File.Delete("ZipUtils.dll");
                }
                ChromeFrm frmSYS_WebBrowerChrome = new ChromeFrm();
                frmSYS_WebBrowerChrome.Text = "Chrome2-->" + url;
                bool flag = height >= 99999 && width >= 99999;
                if (flag)
                {
                    frmSYS_WebBrowerChrome.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    frmSYS_WebBrowerChrome.Size = new Size(width, height);
                }
                frmSYS_WebBrowerChrome.URL = url;
                frmSYS_WebBrowerChrome.Size = new Size(width, height);
                wbfrm = frmSYS_WebBrowerChrome;
                frmSYS_WebBrowerChrome.ShowDialog();
                frmSYS_WebBrowerChrome.Dispose();
                // System.Diagnostics.Process.Start(url);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
