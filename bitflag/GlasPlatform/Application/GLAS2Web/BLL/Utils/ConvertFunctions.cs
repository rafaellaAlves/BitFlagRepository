using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Utils
{
    public static class ConvertFunctions
    {
        /// <summary>
        /// Copy all properties values from one object to another.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="entity1"></param>
        /// <returns></returns>
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
    }
}
