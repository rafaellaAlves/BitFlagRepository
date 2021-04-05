using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class UrlHelpers
    {
        public static string GetBaseUrl(HttpContext httpContext)
        {
            return (httpContext.Request.IsHttps ? "https://" : "http://") + (httpContext.Request.Host.Port == 80 ? httpContext.Request.Host.Host : (httpContext.Request.Host.Host + ":" + httpContext.Request.Host.Port));
        }
    }
}
