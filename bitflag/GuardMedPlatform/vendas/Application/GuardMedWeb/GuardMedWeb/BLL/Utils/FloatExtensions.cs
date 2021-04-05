using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.BLL.Utils
{
    public static class FloatExtensions
    {
        public static string ToPtBr(this float me)
        {
            return me.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToPtBr(this double me)
        {
            return me.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static double? FromDoublePtBR(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!double.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out double d)) return null;

            return d;
        }
    }
}
