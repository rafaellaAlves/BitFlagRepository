using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Transporter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using AspNetIdentityDbContext;
using Services.Transporter;
using DTO.Shared;
using Web.Helpers;
using DTO.Utils;
using Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class TransporterController : Shared.BaseCRUDController<Transporter, TransporterViewModel, int>
    {
        private readonly TransporterServices transporterServices;
        private readonly TransporterDriverServices transporterDriverServices;
        private readonly TransporterVehicleServices transporterVehicleServices;
        private readonly DropDownListHelper dropDownListHelper;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;
        private readonly ICompositeViewEngine viewEngine;

        public TransporterController(TransporterServices service, UserManager<User> userManager, TransporterDriverServices transporterDriverServices, TransporterVehicleServices transporterVehicleServices, DropDownListHelper dropDownListHelper, EmailServices emailServices, IConfiguration configuration, ICompositeViewEngine viewEngine) : base(service, userManager)
        {
            this.transporterDriverServices = transporterDriverServices;
            this.transporterVehicleServices = transporterVehicleServices;
            this.dropDownListHelper = dropDownListHelper;
            this.transporterServices = service;
            this.emailServices = emailServices;
            this.configuration = configuration;
            this.viewEngine = viewEngine;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> Manage(int? id) => await Task.Run(() => View(id));

        public override Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return base.List(filter);
        }

        public async Task<IActionResult> ValidateTransporter(TransporterViewModel model)
        {
            var r = await transporterServices.ExistTransporter(model);

            return await Task.Run(() => Json(new { hasError = r, message = r ? $"O CPF/CNPJ informado já está cadastrado." : "" }));
        }

        public async Task<IActionResult> GetTransporterAssociatedDataById(int id, int? transporterDriverId, int? transporterVehicleId)
        {
            var vehicles = await transporterVehicleServices.GetDataAsNoTrackingAsync(x => (!x.IsDeleted && x.IsActive && x.TransporterId == id) || x.TransporterVehicleId == transporterVehicleId);
            var drivers = await transporterDriverServices.GetDataAsNoTrackingAsync(x => (!x.IsDeleted && x.IsActive && x.TransporterId == id) || x.TransporterDriverId == transporterDriverId);

            return await Task.Run(() => Json(new
            {
                vehicles = dropDownListHelper.ToSelectListItem(vehicles, x => x.TransporterVehicleId, x => $"Modelo: {x.Model} - Placa: {x.LicensePlate}", transporterVehicleId?.ToString()),
                drivers = dropDownListHelper.ToSelectListItem(drivers, x => x.TransporterDriverId, x => $"{x.DriverName} - CNH: {x.CNH} - MOPP: {x.MOPP.IfNullChange("-")}", transporterDriverId?.ToString()),
            }));
        }

        public async Task<IActionResult> CreationComplete(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            if (!entity.CreationComplete)
            {
                await SendNewTransporterEmail(id);
                await transporterServices.CreationComplete(id);
            }

            return RedirectToAction("Index");
        }

        async Task SendNewTransporterEmail(int id)
        {
            if (!configuration.GetValue<bool>("Emails:SendNewTransporterEmail"))
                return;

            var model = await service.GetViewModelByIdAsync(id);

            var html_Admin = await RenderPartialViewToString("NewTransporterEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{model.Name} foi cadastrado.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"{model.Name} foi cadastrado.", html_Admin, new List<string> { "operacional@destineja.com.br" });
#endif

        }

        public async Task Active(int id) => await transporterServices.ChangeActivity(id, true);
        public async Task Inactive(int id) => await transporterServices.ChangeActivity(id, false);
    }
}