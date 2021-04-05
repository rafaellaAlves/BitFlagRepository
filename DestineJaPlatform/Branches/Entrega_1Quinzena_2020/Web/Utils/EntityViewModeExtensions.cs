using DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils
{
    public static class EntityViewModeExtensions
    {
        public static bool CanEdit<T>(this EntityViewMode<T> me)
        {
            return me.ViewMode == ViewMode.Editable;
        }
    }
}
