using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DTO.Utils
{
    public static class DateTimeExtensions
    {
        public static string ToAmericanDateFormat(this DateTime me)
        {
            return me.ToString("yyyy/MM/dd/", CultureInfo.InvariantCulture);
        }

        public static string ToAmericanDateFormat(this DateTime? me)
        {
            if (me.HasValue)
                return me.Value.ToString("yyyy/MM/dd/", CultureInfo.InvariantCulture);
            else
                return null;
        }

        public static string ToBrazilianDateFormat(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToBrazilianDateTimeFormat(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string ToBrazilianTime1Format(this DateTime me)
        {
            return me.ToString("HH:mm", CultureInfo.InvariantCulture);
        }

        public static string ToBrazilianDateFormat(this DateTime? me)
        {
            if (me.HasValue)
                return me.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                return null;
        }

        public static string ToBrazilianDateTimeFormat(this DateTime? me)
        {
            if (me.HasValue)
                return me.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            else
                return null;
        }

        public static DateTime FromBrazilianDateFormat(this string me)
        {
            DateTime outValue = DateTime.MinValue;
            DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue);
            return outValue;
        }

        public static DateTime FromBrazilianDateTimeFormat(this string me)
        {
            DateTime outValue = DateTime.MinValue;
            DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yy HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue);
            return outValue;
        }

        public static DateTime? FromBrazilianDateFormatNullable(this string me)
        {
            if (string.IsNullOrWhiteSpace(me))
                return null;

            DateTime outValue;
            if (DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue))
                return (DateTime?)outValue;
            else
                return null;
        }

        public static DateTime? FromBrazilianDateTimeFormatNullable(this string me)
        {
            if (string.IsNullOrWhiteSpace(me))
                return null;

            DateTime outValue;
            if (DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yy HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue))
                return (DateTime?)outValue;
            else
                return null;
        }
    }
}
