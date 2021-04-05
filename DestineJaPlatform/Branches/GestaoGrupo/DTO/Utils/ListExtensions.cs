using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Utils
{
    public static class ListExtensions
    {
        public static List<TResult> GetListFromString<TResult>(this string me, string separetor)
        {
            var data = me.Split(separetor);
            var r = new List<TResult>();

            if (data.Length == 0)
            {
                try
                {
                    r.Add((TResult)Convert.ChangeType(me, typeof(TResult)));
                }
                catch { }

                return r;
            }

            foreach (var item in data)
            {
                try
                {
                    r.Add((TResult)Convert.ChangeType(item, typeof(TResult)));
                }
                catch { }
            }

            return r;
        }
    }
}
