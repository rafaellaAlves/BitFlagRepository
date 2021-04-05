using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WEB.Utils
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

        public static string CNPJMask(this string me)
        {
            try
            {
                return Int64.Parse(me).ToString(@"00\.000\.000\/0000\-00");
            }
            catch
            {
                return me;
            }
        }

        public static string CPFMask(this string me)
        {
            try
            {
                return Int64.Parse(me).ToString(@"000\.000\.000\-00");
            }
            catch
            {
                return me;
            }
        }

        public static string CNPJOrCPFmask(this string me)
        {
            try
            {
                if (me.Length > 11) return Int64.Parse(me).ToString(@"00\.000\.000\/0000\-00");

                return Int64.Parse(me).ToString(@"000\.000\.000\-00");
            }
            catch
            {
                return me;
            }
        }

        public static string CEPMask(this string me)
        {
            try
            {
                return Int64.Parse(me).ToString(@"00000\-000");
            }
            catch
            {
                return me;
            }
        }

        public static string MoneyMask(this string me)
        {
            try
            {
                var val = me.FromDoubleEnUS();
                if (val.HasValue)
                {
                    return val.Value.ToString("C0", CultureInfo.GetCultureInfo("pt-BR"));
                }
                return me;
            }
            catch
            {
                return me;
            }
        }

        public static string MoneyMask2(this string me)
        {
            try
            {
                var val = me.FromDoubleEnUS();
                if (val.HasValue)
                {
                    return val.Value.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                }
                return me;
            }
            catch
            {
                return me;
            }
        }

        public static bool ContainNumbers(this string me)
        {
            return me.Contains("1") || me.Contains("2") || me.Contains("3") || me.Contains("4") || me.Contains("5") || me.Contains("6") || me.Contains("7") || me.Contains("8") || me.Contains("9") || me.Contains("0");
        }

        public static string RemoveAccents(this string me)
        {
            byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(me);
            return System.Text.Encoding.UTF8.GetString(tempBytes);
        }

        public static string GetString(this object me)
        {
            return me == DBNull.Value ? "-" : (string)me;
        }

        public static string GetNullableString(this object me)
        {
            return me == DBNull.Value ? null : (string)me;
        }

        public static double GetDouble(this object me)
        {
            return me == DBNull.Value ? 0 : (double)me;
        }

        public static int GetInt(this object me)
        {
            return me == DBNull.Value ? 0 : (int)me;
        }

        public static int? GetNullableInt(this object me)
        {
            return me == DBNull.Value ? null : (int?)me;
        }


        public static DateTime? GetDateTime(this object me)
        {
            return me == DBNull.Value? null : (DateTime?)me;
        }

        public static bool? GetBool(this object me)
        {
            return me == DBNull.Value ? null : (bool?)me;
        }
    }
}
