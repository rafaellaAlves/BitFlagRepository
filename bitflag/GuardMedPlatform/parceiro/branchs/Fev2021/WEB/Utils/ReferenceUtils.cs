using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Utils
{
    public static class ReferenceUtils
    {
        public static string GetReference()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();
            for (int j = 1; j <= 4; j++)
            {
                var charCode = random.Next(65, 90);
                stringBuilder.Append((char)charCode);
            }
            stringBuilder.Append(string.Format("{0:0000}", random.Next(0, 9999)));
            return stringBuilder.ToString();
        }
    }
}
