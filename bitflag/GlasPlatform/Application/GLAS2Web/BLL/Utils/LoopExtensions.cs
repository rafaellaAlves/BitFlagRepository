using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public static class LoopExtensions
    {
        public static void Loop<T>(this IEnumerable<T> me, Action<T> func)
        {
            foreach (var item in me) func.Invoke(item);
        }
    }
}
