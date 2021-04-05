using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BackgroundServices.Utils
{
    public static class ConvertUtils
    {
        public static string NumbersOnly(this string me)
        {
            return string.IsNullOrWhiteSpace(me) ? null : Regex.Replace(me, @"[^\d]", string.Empty);
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
            return me == DBNull.Value ? null : (DateTime?)me;
        }

        public static bool? GetBool(this object me)
        {
            return me == DBNull.Value ? null : (bool?)me;
        }
    }
}
