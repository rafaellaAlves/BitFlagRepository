using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspNetIdentityDbContext;
using DTO.Shared;
using DTO.Sintegra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Services.Account;
using Services.Client;
using Services.Shared;
using Services.Sintegra;
using Web.Utils;

namespace Web.Controllers.Shared
{
    public abstract class BaseController : Controller
    {
        public readonly UserManager<AspNetIdentityDbContext.User> userManager;


        public BaseController(UserManager<AspNetIdentityDbContext.User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AspNetIdentityDbContext.User> GetUser()
        {
            return await userManager.GetUserAsync(User);
        }

        public async Task<string> RenderPartialViewToString(string viewName, object model, ICompositeViewEngine viewEngine)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }

        [AllowAnonymous]
        public async Task<SintegraResultViewModel> GetCompanyByCNPJ(string cnpj, [FromServices] SintegraService sintegraService)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return new SintegraResultViewModel();

            return await sintegraService.GetDataByCNPJ(cnpj);
        }
    }
}
