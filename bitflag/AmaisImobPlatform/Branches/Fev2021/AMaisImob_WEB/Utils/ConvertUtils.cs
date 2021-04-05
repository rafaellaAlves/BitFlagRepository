using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Utils
{
    public static class ConvertUtils
    {
        #region [DateTime]
        public static DateTime? FromDatePtBR(this string me)
        {
            if (DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy", "dd/MM/yyyy ss:mm:HH", "dd/MM/yy ss:mm:HH", "MM/yyyy", "MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
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

        public static string ToMonthYearPtBR(this DateTime me)
        {
            return $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(me.Month))} - {me.Year}";
        }

        public static string ToShortDatePtBR(this DateTime me) => me.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        public static string ToShortDatePtBR(this DateTime? me) => me?.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));

        public static string ToDateTimePtBR(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToDateTimePtBR(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
        public static string ToTimePtBR(this DateTime me)
        {
            return me.ToString("HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToTimePtBR(this DateTime? me)
        {
            return me.HasValue ? me.Value.ToString("HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
        #endregion

        #region [Double]
        public static double? FromDoublePtBR(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!double.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out double d)) return null;

            return d;
        }
        public static double? FromDoubleEnUS(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!double.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double d)) return null;

            return d;
        }

        public static string ToPtBR(this double me)
        {
            return me.ToString("#,###,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToPtBR(this double? me)
        {
            return me.HasValue ? me.Value.ToString("#,###,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
        #endregion

        #region [Decimal]
        public static decimal? FromDecimalPtBR(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!decimal.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out decimal d)) return null;

            return d;
        }

        public static string ToMoneyPtBR(this decimal me)
        {
            return me.ToString("#,###,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToMoneyPtBR(this decimal? me)
        {
            return me.HasValue ? me.Value.ToString("#,###,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
        #endregion

        #region [Int]
        public static int? FromIntPtBR(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!int.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out int d)) return null;

            return d;
        }

        public static string ToPtBR(this int me)
        {
            return me.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }
        public static string ToPtBR(this int? me)
        {
            return me.HasValue ? me.Value.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR")) : "";
        }
        #endregion

        public static T1 CopyToEntity<T1>(this object entity1)
        {
            var entity2 = (T1)Activator.CreateInstance(typeof(T1));
            var entity2Proprierties = typeof(T1).GetProperties();

            foreach (var property in entity1.GetType().GetProperties())
            {
                var prop = entity2Proprierties.SingleOrDefault(x => x.Name.Equals(property.Name));
                if (prop == null) continue;

                try
                {
                    prop.SetValue(entity2, property.GetValue(entity1));
                }
                catch { }
            }

            return entity2;
        }
    }
}
