using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Route;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Route;
using Services.Contract;
using Services.Shared;
using Services.Service;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Web.Utils;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Services.Email;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class RouteController : Shared.BaseCRUDController<Route, RouteViewModel, int>
    {
        private readonly RouteServices routeServices;
        private readonly ContractClientCollectionAddressService contractClientCollectionAddressService;
        private readonly ServiceClientCollectionAddressServices serviceClientCollectionAddressServices;
        private readonly BaseRouteClientListServices baseRouteClientListServices;
        private readonly RouteClientServices routeClientServices;
        private readonly RouteResidueFamilyServices routeResidueFamilyServices;
        private readonly RouteListServices routeListServices;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;
        private readonly ICompositeViewEngine viewEngine;

        public RouteController(RouteServices service, UserManager<User> userManager, ContractClientCollectionAddressService contractClientCollectionAddressService, ServiceClientCollectionAddressServices serviceClientCollectionAddressServices, BaseRouteClientListServices baseRouteClientListServices, RouteClientServices routeClientServices, RouteResidueFamilyServices routeResidueFamilyServices, RouteListServices routeListServices, EmailServices emailServices, IConfiguration configuration, ICompositeViewEngine viewEngine) : base(service, userManager)
        {
            routeServices = service;
            this.contractClientCollectionAddressService = contractClientCollectionAddressService;
            this.serviceClientCollectionAddressServices = serviceClientCollectionAddressServices;
            this.baseRouteClientListServices = baseRouteClientListServices;
            this.routeClientServices = routeClientServices;
            this.routeResidueFamilyServices = routeResidueFamilyServices;
            this.routeListServices = routeListServices;
            this.emailServices = emailServices;
            this.configuration = configuration;
            this.viewEngine = viewEngine;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> Manage(int? id) => await Task.Run(() => View(id));

        public override async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => routeListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters));
        }
        public async Task<IActionResult> GetClientsByAddress(List<DTO.Shared.AddressBaseViewModel> address, int? clientType)
        {
            var r = await routeServices.GetContractAndServiceAvailbleCities(address);

            return await Task.Run(() => Json(r.Where(x => !clientType.HasValue || (clientType == 1 && x.IsContract) || (clientType == 2 && !x.IsContract))));
        }

        public async Task<IActionResult> GetClientAddresses(List<int> clientCollectionAddressIds) => await Task.Run(async () => Json(await baseRouteClientListServices.GetDataAsNoTrackingAsync(x => clientCollectionAddressIds.Contains(x.ClientCollectionAddressId))));

        public async Task<IActionResult> RouteResidueFamilyViewComponent(int addressId, int? contractId, int? serviceId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Route.RouteResidueFamilyViewComponent), new { addressId, contractId, serviceId, loadFromController = true }));

        public async Task<IActionResult> _ManageForm(RouteViewModel model, List<ApplicationDbContext.Models.RouteClient> clients, List<ApplicationDbContext.Models.RouteResidueFamily> routeResidueFamily)
        {
            var r = (JsonResult)(await base.ManageAjax(model));
            var value = (dynamic)r.Value;
            var id = (int)value.id;

            await routeResidueFamilyServices.DeleteByRouteIdAsync(id);
            routeResidueFamily.ForEach(x => x.RouteId = id);
            await routeResidueFamilyServices.CreateRange(routeResidueFamily);

            await routeClientServices.DeleteByRouteIdAsync(id);
            clients.ForEach(x => x.RouteId = id);
            await routeClientServices.CreateRange(clients);

            if (!model.RouteId.HasValue)
                await SendNewRouteEmail(id);

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
        }
        async Task SendNewRouteEmail(int routeId)
        {
            if (!configuration.GetValue<bool>("Emails:SendNewRouteEmail"))
                return;

            var model = await service.GetViewModelByIdAsync(routeId);

            var html_Admin = await RenderPartialViewToString("NewRouteEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{model.RouteId}, {model.Name} - Nova Rota Criada", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"{model.RouteId}, {model.Name} - Nova Rota Criada", html_Admin, new List<string> { "operacional@destineja.com.br" });
#endif
        }

        public async Task Cancel(int routeId, string reason) => await routeServices.Cancel(routeId, reason);
        public async Task Suspend(int routeId, string reason) => await routeServices.Suspend(routeId, reason);
        public async Task Unsuspend(int routeId, string reason) => await routeServices.Suspend(routeId, reason, false);
        public async Task<IActionResult> GetResidueFamiliesByRouteId(int id) => await Task.Run(async () => Json(await routeServices.GetResidueFamiliesByRouteId(id)));
    }
}