using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Recipient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using AspNetIdentityDbContext;
using Services.Recipient;
using DTO.Shared;
using Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class RecipientController : Shared.BaseCRUDController<Recipient, RecipientViewModel, int>
    {
        private readonly RecipientServices recipientServices;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;
        private readonly ICompositeViewEngine viewEngine;

        public RecipientController(RecipientServices service, UserManager<User> userManager, EmailServices emailServices, IConfiguration configuration, ICompositeViewEngine viewEngine) : base(service, userManager)
        {
            recipientServices = service;
            this.emailServices = emailServices;
            this.configuration = configuration;
            this.viewEngine = viewEngine;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> Manage(int? id) => await Task.Run(() => View(id));

        public async Task<IActionResult> ValidateRecipient(RecipientViewModel model)
        {
            var r = await recipientServices.ExistRecipient(model);

            return await Task.Run(() => Json(new { hasError = r, message = r ? $"O CPF/CNPJ informado já está cadastrado." : "" }));
        }

        public override Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return base.List(filter);
        }

        public async Task<IActionResult> CreationComplete(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            if (!entity.CreationComplete)
            {
                await SendNewRecipientEmail(id);
                await recipientServices.CreationComplete(id);
            }

            return RedirectToAction("Index");
        }


        async Task SendNewRecipientEmail(int id)
        {
            if (!configuration.GetValue<bool>("Emails:SendNewRecipientEmail"))
                return;

            var model = await service.GetViewModelByIdAsync(id);

            var html_Admin = await RenderPartialViewToString("NewRecipientEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{model.Name} foi cadastrado.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"{model.Name} foi cadastrado.", html_Admin, new List<string> { "operacional@destineja.com.br" });
#endif
        }

        public async Task Active(int id) => await recipientServices.ChangeActivity(id, true);
        public async Task Inactive(int id) => await recipientServices.ChangeActivity(id, false);
    }
}