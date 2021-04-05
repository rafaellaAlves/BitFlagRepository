using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BackgroundService
{
    static class Utils
    {
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

        public static T1 CopyToEntity<T1>(this DbDataReader dbReader, string baseName = null)
        {
            var entity2 = (T1)Activator.CreateInstance(typeof(T1));
            var entity2Proprierties = typeof(T1).GetProperties();

            Regex regex = string.IsNullOrWhiteSpace(baseName) ? null : new Regex(Regex.Escape(baseName));

            for (int i = 0; i < dbReader.FieldCount; i++)
            {
                var prop = entity2Proprierties.SingleOrDefault(x => x.Name == (string.IsNullOrWhiteSpace(baseName) ? dbReader.GetName(i) : regex.Replace(dbReader.GetName(i), "", 1)));
                if (prop == null) continue;

                try
                {
                    prop.SetValue(entity2, dbReader.GetValue(i));
                }
                catch { }
            }

            return entity2;
        }
    }
}
