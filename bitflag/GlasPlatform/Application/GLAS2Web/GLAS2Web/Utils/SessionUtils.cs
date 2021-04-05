using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.Utils
{
    public static class SessionUtils
    {
        public static string GetSessionListFilter(this ViewContext viewContext, string inputId)
        {
            var key = viewContext.HttpContext.Session.Keys.SingleOrDefault(x => x == $"Session_Filter_{viewContext.RouteData.Values["controller"]}_{inputId}");

            if (key != null) return viewContext.HttpContext.Session.GetString(key);

            return "";
        }

        public static void ClearPageFilterSession(this ISession session, string controller)
        {
            foreach (var key in session.Keys.Where(x => x.Contains($"Session_Filter_{controller}")).ToList())
            {
                session.Remove(key);
            }
        }

        public static void SetPageFilterSession(this ISession session, string controller, string inputId, string value)
        {
            session.SetString($"Session_Filter_{controller}_{inputId}", value ?? "");
        }

        public static bool PageHasSessionFilters(this ISession session, string controller)
        {
            return session.Keys.Any(x => x.Contains($"Session_Filter_{controller}"));
        }
    }
}
