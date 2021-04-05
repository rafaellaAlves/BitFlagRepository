using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO.Utils
{
    public static class StringExtensions
    {
        public static string NumbersOnly(this string me)
        {
            return string.IsNullOrWhiteSpace(me) ? null : Regex.Replace(me, @"[^\d]", string.Empty);
        }

        public static string ToBrazilianDateString(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy");
        }
        public static string ToBrazilianDateString(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy") : string.Empty;
        }
        public static string ToBrazilian(this double me)
        {
            return me.ToString("0.0");
        }
        public static string ToBrazilian(this double? me)
        {
            return me.HasValue ? me.Value.ToString("0.0") : string.Empty;
        }
    }
}
