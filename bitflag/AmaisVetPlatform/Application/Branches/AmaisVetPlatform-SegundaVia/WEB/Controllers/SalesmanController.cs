using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class SalesmanController : Controller
    {
        public IActionResult FundClient()
        {
            return View();
        }
    }
}
