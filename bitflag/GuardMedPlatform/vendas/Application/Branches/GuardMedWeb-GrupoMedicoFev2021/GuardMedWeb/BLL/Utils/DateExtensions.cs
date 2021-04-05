using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuardMedWeb.BLL.Utils
{
    public static class DateExtensions
    {
        public static DateTime? FromDatePtBR(this string me)
        {
            if (DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy", "dd/MM/yyyy ss:mm:HH", "dd/MM/yy ss:mm:HH", "MM/yyyy", "MM/yy", "yyyy-mm-dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                return o;

            return null;
        }

        public static string ToDatePtBR(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToDatePtBR(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }

        public static string ToShortDatePtBR(this DateTime me)
        {
            return me.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        }

        public static string ToDateTimePtBR(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToDateTimePtBR(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
    }
}
