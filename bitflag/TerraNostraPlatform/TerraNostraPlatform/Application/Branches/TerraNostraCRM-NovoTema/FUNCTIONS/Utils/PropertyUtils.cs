using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace FUNCTIONS.Utils
{
    public static  class PropertyUtils
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
