using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO.Utils
{
    public static class StringUtils
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
            return me == null ? "" : Int64.Parse(me).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string CPFMask(this string me)
        {
            return me == null ? "" : Int64.Parse(me).ToString(@"000\.000\.000\-00");
        }

        public static string CNPJOrCPFmask(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return "";
            if (me.Length > 11) return me == null ? "" : Int64.Parse(me).ToString(@"00\.000\.000\/0000\-00");

            return me == null ? "" : Int64.Parse(me).ToString(@"000\.000\.000\-00");
        }

        public static string RGMask(this string me)
        {
            return me == null ? "" : Int64.Parse(me).ToString(@"00\.000\.000\-00");
        }

        public static string CEPMask(this string me)
        {
            return me == null ? "" : Int64.Parse(me).ToString(@"00000\-000");
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

        public static void GetName(this string me, out string firstName, out string lastName)
        {
            firstName = null; lastName = null;

            if (string.IsNullOrEmpty(me)) return;

            firstName = me.Split(" ")[0];
            lastName = me.Replace(firstName, "")?.TrimStart();
        }

    }
}
