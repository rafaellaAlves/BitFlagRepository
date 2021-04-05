using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO.Utils
{
    public static class ConvertExtensions
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

        /// <summary>
        /// Copy all properties values from one object to another, only properties setted with update attribute are computed (if no proprierty has update attribute all wiil be computed).
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="entity1"></param>
        /// <param name="t1"></param>
        public static void CopyToEntity<T1>(this object entity1, ref T1 t1, bool update = true)
        {
            var entity2Proprierties = typeof(T1).GetProperties();
            
            var props = entity1.GetType().GetProperties();
            foreach (var property in props.Any(x => update && Attribute.IsDefined(x, typeof(Update))) ? props.Where(x => Attribute.IsDefined(x, typeof(Update))) : props)
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
        public static DateTime? GetDateTimeFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (DateTime?)reader;
        public static TimeSpan? GetTimeSpanFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (TimeSpan?)reader;
        public static int? GetIntFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (int?)reader;
        public static double? GetDoubleFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (double?)reader;
        public static string GetStringFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (string)reader;
        public static bool? GetBoolFromDbDataReader(this object reader) => reader == DBNull.Value ? null : (bool?)reader;
    }
}
