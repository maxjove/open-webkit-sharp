using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChromeForDoNet
{
	public class WebInvoice
	{
		public static void CallWebBrower(string url, int height, int width)
		{
			try
			{
                frmSYS_WebBrowerChrome frmSYS_WebBrowerChrome = new frmSYS_WebBrowerChrome();
                frmSYS_WebBrowerChrome.Text = "Chrome2:" + url;
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
                frmSYS_WebBrowerChrome.ShowDialog();
                frmSYS_WebBrowerChrome.Dispose();
               // System.Diagnostics.Process.Start(url);
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
