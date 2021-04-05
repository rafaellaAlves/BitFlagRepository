using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Utils
{
    public static class DictionaryExtensions
    {
        public static List<T2> GetValues<T1, T2>(this Dictionary<T1, T2> dic)
        {
            List<T2> r = new List<T2>();

            foreach (var item in dic)
            {
                r.Add(item.Value);
            }
            return r;
        }


        public static List<T2> GetValues<T1, T2>(this Dictionary<T1, List<T2>> dic, Func<T2, bool> func = null)
        {
            List<T2> r = new List<T2>();

            foreach (var item in dic)
            {
                if (func == null)
                    r.AddRange(item.Value);
                else
                    r.AddRange(item.Value.Where(func));
            }
            return r;
        }
    }
}
