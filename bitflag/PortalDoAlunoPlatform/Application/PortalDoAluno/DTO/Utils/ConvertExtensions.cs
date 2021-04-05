using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DTO.Utils
{
    public static class ConvertExtensions
    {
        public static double? ToDouble(this string me)
        {
            if (string.IsNullOrWhiteSpace(me)) return null;
            if (!double.TryParse(me, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out double d)) return null;

            return d;
        }
        public static T1 CopyToEntity<T1>(this object entity1)
        {
            var entity2 = (T1)Activator.CreateInstance(typeof(T1));
            var entity2Proprierties = typeof(T1).GetProperties();

            foreach (var property in entity1.GetType().GetProperties())
            {
                var prop = entity2Proprierties.SingleOrDefault(x => x.Name == property.Name);
                if (prop == null) continue;

                try
                {
                    prop.SetValue(entity2, property.GetValue(entity1));
                }
                catch { }
            }

            return entity2;
        }


        public static void CopyToEntity<T1>(this object entity1, ref T1 t1)
        {
            var entity2Proprierties = typeof(T1).GetProperties();

            foreach (var property in entity1.GetType().GetProperties())
            {
                var prop = entity2Proprierties.SingleOrDefault(x => x.Name == property.Name);
                if (prop == null) continue;

                try
                {
                    prop.SetValue(t1, property.GetValue(entity1));
                }
                catch { }
            }
        }
    }
}
