using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Utils
{
    public static class PropertyMethods
    {
        public static string GetDisplayName(this MemberInfo property)
        {
            if (!(property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute display)) return null;

            return display.Name;
        }

        public static string GetDisplayDescription(this MemberInfo property)
        {
            if (!(property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute display) || display.Description == null) return null;

            return display.Description;
        }
    }
}
