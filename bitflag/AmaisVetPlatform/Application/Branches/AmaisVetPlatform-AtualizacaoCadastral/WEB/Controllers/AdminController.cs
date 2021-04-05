using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Campaign()
        {
            return View();
        }
        public IActionResult UserRegistration()
        {
            return View();
        }
    }
}
