using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Client;
using Services.Home;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeServices homeServices;
        private readonly ClientUserServices clientUserServices;
        private readonly UserManager<AspNetIdentityDbContext.User> userManager;

        public HomeController(ILogger<HomeController> logger, HomeServices homeServices, ClientUserServices clientUserServices, UserManager<AspNetIdentityDbContext.User> userManager)
        {
            _logger = logger;
            this.homeServices = homeServices;
            this.clientUserServices = clientUserServices;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index([FromServices] ClientServices clientServices)
        {
            if (User.IsClient() && await clientServices.GetClientIdByLoggedUser(HttpContext) == -1)
                RedirectToAction("Logout", "Account");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetHomeDemandClientResidueFamilyCollectedViewModel([FromServices] ClientServices clientServices)
        {
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            return await Task.Run(async () => Json(await homeServices.GetHomeDemandClientResidueFamilyCollectedViewModel(clientId)));
        }
        public async Task<IActionResult> GetHomeLastMonthlyCollections(int? year, [FromServices] ClientServices clientServices)
        {
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            return await Task.Run(async () => Json(await homeServices.GetHomeLastMonthlyCollections(clientId, year ?? DateTime.Now.Year)));
        }
    }
}
