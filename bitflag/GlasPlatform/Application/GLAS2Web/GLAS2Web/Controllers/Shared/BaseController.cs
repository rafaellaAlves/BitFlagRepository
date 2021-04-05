using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLAS2Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace GLAS2Web.Controllers.Shared
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.RouteData.Values["action"].ToString().ToUpper() == "INDEX" && !context.HttpContext.Request.Query.ContainsKey("useFilter"))
            {
                context.HttpContext.Session.ClearPageFilterSession(context.RouteData.Values["controller"].ToString());
            }

            if (context.RouteData.Values["action"].ToString().ToUpper() == "LIST")
            {
                try
                {
                    if (context.HttpContext.Request.Form.Keys.Contains("ignoreSessionFilter")) return;

                    foreach (var key in context.HttpContext.Request.Form.Keys.Where(x => !x.Contains("columns") && !x.Contains("order") && !x.Contains("draw") && !x.Contains("search[regex]")))
                    {
                        context.HttpContext.Session.SetPageFilterSession(context.RouteData.Values["controller"].ToString(), key, context.HttpContext.Request.Form[key]);
                    }
                }
                catch { }
            }

            base.OnActionExecuting(context);
        }
    }
}