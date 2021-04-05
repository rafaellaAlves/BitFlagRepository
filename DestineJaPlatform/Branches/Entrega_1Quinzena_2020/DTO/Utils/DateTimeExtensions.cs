using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Utils
{
    public static class DateTimeExtensions
    {
        public static string ToAmericanDateFormat(this DateTime me)
        {
            return me.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }

        public static string ToAmericanDateFormat(this DateTime? me)
        {
            if (me.HasValue)
                return me.Value.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            else
                return null;
        }

        public static string ToBrazilianDateFormat(this DateTime me)
        {
            return me.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToBrazilianDateFormatNoDay(this DateTime me)
        {
            return me.ToString("MM/yyyy", CultureInfo.InvariantCulture);
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
            DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy", "MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue);
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
            if (DateTime.TryParseExact(me, new string[] { "dd/MM/yyyy", "dd/MM/yy", "MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue))
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

        public static string ToBrazilianTimeFormat(this DateTime? me)
        {
            return me?.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        }
        public static string ToBrazilianTimeNoSecondsFormat(this DateTime? me)
        {
            return me?.ToString("HH:mm", CultureInfo.InvariantCulture);
        }
        public static string ToBrazilianTimeFormat(this TimeSpan? me)
        {
            return me?.ToString(@"hh\:mm:ss", CultureInfo.InvariantCulture);
        }
        public static string ToBrazilianTimeNoSecondsFormat(this TimeSpan? me)
        {
            return me?.ToString(@"hh\:mm", CultureInfo.InvariantCulture);
        }

        public static TimeSpan? FromBrazilianTimeFormat(this string me)
        {
            TimeSpan outValue = TimeSpan.MinValue;
            if (TimeSpan.TryParseExact(me, @"hh\:mm:ss", CultureInfo.InvariantCulture, out outValue)) return outValue;

            return null;
        }

        public static TimeSpan? FromBrazilianTimeNoSecondsFormat(this string me)
        {
            TimeSpan outValue = TimeSpan.MinValue;
            if (TimeSpan.TryParseExact(me, @"hh\:mm", CultureInfo.InvariantCulture, out outValue)) return outValue;

            return null;
        }
    }
}
