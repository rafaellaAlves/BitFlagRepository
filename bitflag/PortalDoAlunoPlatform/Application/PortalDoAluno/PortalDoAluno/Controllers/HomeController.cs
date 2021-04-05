using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, UserManager<AspNetIdentityDbContext.User> userManager)
        {
            _logger = logger;
            //var result1 = userManager.CreateAsync(new AspNetIdentityDbContext.User() { UserName = "cobranca@ensinoemsaude.com", Email = "cobranca@ensinoemsaude.com" }, "cp7TTq").Result;
            //var result2 = userManager.CreateAsync(new AspNetIdentityDbContext.User() { UserName = "adm@ensinoemsaude.com", Email = "cobranca@ensinoemsaude.com" }, "mrU7tU").Result;
        }

        public IActionResult Index()
        {
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
    }
}
