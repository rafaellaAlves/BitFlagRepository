using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspNetIdentityDbContext;
using DTO.Shared;
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
using Web.Utils;

namespace Web.Controllers.Shared
{
    public abstract class BaseCRUDController<TEntity, TModel, Key> : BaseController
        where TEntity : class
        where TModel : class
    {
        public readonly BaseServices<TEntity, TModel, Key> service;
        public Models.Parameters ListParameters;


        public BaseCRUDController(BaseServices<TEntity, TModel, Key> service, UserManager<AspNetIdentityDbContext.User> userManager) : base(userManager)
        {
            this.service = service;

            ListParameters = new Models.Parameters();
        }

        public virtual async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            var data = service.ToViewModel(service.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, ListParameters.GetQuery(), ListParameters.GetParameters()));

            return await Task.Run(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }

        public virtual async Task<IActionResult> AlternativeList(DataTablesAjaxPostModel filter, Func<DataTablesAjaxPostModel, int, int, string, SqlParameter[], IEnumerable<object>> expr)
        {
            IEnumerable<object> data;
            int recordsTotal = 0, recordsFiltered = 0;

            data = expr(filter, recordsTotal, recordsFiltered, ListParameters.GetQuery(), ListParameters.GetParameters());

            return await Task.Run(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }

        [HttpPost]
        public virtual async Task<IActionResult> ManageForm(TModel model)
        {
            var key = await service.CreateOrUpdateAsync(model);

            return await Task.Run(() => RedirectToAction("Manage", new { id = key, success = true }));
        }

        [HttpPost]
        public virtual async Task<IActionResult> ManageAjax(TModel model)
        {
            var key = await service.CreateOrUpdateAsync(model);

            return await Task.Run(() => Json(new { id = key, success = true }));
        }

        public virtual async Task Delete(Key id)
        {
            var user = await userManager.GetUserAsync(User);
            await service.DeleteAsync(id, user.Id);
        }

        public virtual async Task DeleteDefinitively(Key id)
        {
            await service.DeleteDefinitivelyAsync(id);
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

        public virtual async Task<IActionResult> GetViewModelById(Key id) => await Task.Run(async () => Json(await service.GetViewModelByIdAsync(id)));

    }
}
