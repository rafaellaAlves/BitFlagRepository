using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class RelationshipProgramController : Controller
    {
        public IActionResult IndexRelationshipProgram()
        {
            return View();
        }
        public IActionResult Rules()
        {
            return View();
        }
        public IActionResult IndicationVet()
        {
            return View();
        }
    }
}
