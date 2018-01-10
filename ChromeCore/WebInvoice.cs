using System;
using System.IO;
using ChromeKCore;


namespace ChromeForDoNet
{
    public class WebInvoice
    {
        
        public static void Navigate(string url)
        {
            CallWebBrower(url, 99999, 99999);
        }

        public static void CallWebBrower(string url, int height, int width)
        {
            ChromeKCore.WebInvoice.CallWebBrower(url, height, width);
        }
    }
}
