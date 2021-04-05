using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO.Extensions
{
    public static class DTOExtensions
    {
        private static Regex numbersOnlyRegex = new Regex("[^0-9]");
        public static string ToDateOnly(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy");
        }
        public static string ToDateOnly(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy") : "-";
        }
        public static string ToDateTime(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy H:mm") : "-";
        }
        public static string ToCurrentInfo(this double me)
        {
            return me.ToString("#,##0.00");
        }
        public static string ToMoney(this double me)
        {
            return string.Format("R$ {0}", me.ToCurrentInfo());
        }
        public static string ToMoney(this double? me)
        {
            return me.HasValue ? string.Format("R$ {0}", me.Value.ToCurrentInfo()) : "R$ -";
        }
        public static string NumbersOnly(this string me)
        {
            return numbersOnlyRegex.Replace(me, string.Empty);
        }
    }
}
