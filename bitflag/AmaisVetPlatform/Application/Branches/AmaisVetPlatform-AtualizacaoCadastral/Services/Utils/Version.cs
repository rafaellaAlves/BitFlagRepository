using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Utils
{
    public class Version
    {
        public static string Major = "1";
        public static string Minor = "0";
        public static DateTime Build = new DateTime(2021, 2, 1);

        public static string GetVersion()
        {
            return string.Format("{0}.{1}-{2}{3}", Major, Minor, Build.Month, Build.Year);
        }
    }
}
