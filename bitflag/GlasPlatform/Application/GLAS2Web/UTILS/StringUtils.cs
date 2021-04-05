using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringExtensions
    {
        public static string NumbersOnly(this string me)
        {
            return string.IsNullOrWhiteSpace(me) ? null : Regex.Replace(me, @"[^\d]", string.Empty);
        }

        public static bool Contains_InvariantCultureIgnoreCase(this string me, string s)
        {
            return me.IndexOf(me, StringComparison.InvariantCultureIgnoreCase) > 0;
        }
    }
}
