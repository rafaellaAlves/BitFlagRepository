using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GuardMedWeb.Models;

namespace GuardMedWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
#if DEBUG
            return View();
#else
            return Redirect("https://www.guardmed.com.br/");
#endif

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
