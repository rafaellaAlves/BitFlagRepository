using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers
{
    public static class Constants
    {
        public static bool IsDEBUG()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
