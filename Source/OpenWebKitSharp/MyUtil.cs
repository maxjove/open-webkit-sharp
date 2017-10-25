using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WebKit
{
   internal class MyUtil
    {
        public static bool IsWellFormedUriString(string p_strValue, UriKind ud)
        {
            if (File.Exists(p_strValue))
                return true;
            if (Uri.IsWellFormedUriString(p_strValue, UriKind.RelativeOrAbsolute))
            {
                Uri l_strUri = new Uri(p_strValue);
                return (l_strUri.Scheme == Uri.UriSchemeHttp || l_strUri.Scheme == Uri.UriSchemeHttps);
            }
            else
            {
                return false;
            }
        }
    }
}
