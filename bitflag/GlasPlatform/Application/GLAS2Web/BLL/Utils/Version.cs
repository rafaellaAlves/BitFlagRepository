using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Utils
{
    public class Version
    {
        public static string Major = "2";
        public static string Minor = "15";
        public static string Build = "20210115";

        public static string GetVersion()
        {
            return string.Format("{0}.{1}-{2}", Major, Minor, Build);
        }
    }
}
        