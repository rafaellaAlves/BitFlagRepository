using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal me)
        {
            var _id = me.FindFirstValue(ClaimTypes.NameIdentifier);
            return string.IsNullOrWhiteSpace(_id) ? null : (int.TryParse(_id, out int id) ? (int?)id : null);
        }
    }
}
