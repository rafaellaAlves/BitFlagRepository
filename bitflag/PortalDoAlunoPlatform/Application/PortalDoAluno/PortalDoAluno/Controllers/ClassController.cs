using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class ClassController : Controller
    {
        private Services.Class.ClassService classService;
        public ClassController(Services.Class.ClassService classService)
        {
            this.classService = classService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DTO.Class.ClassViewModel model)
        {
            try
            {
                var classId = await classService.Add(model);
                return Json(new DTO.Shared.ReturnResult(classId, "Turma cadastrada com sucesso!", false));
            }
            catch (Exception exception)
            {
                return Json(new DTO.Shared.ReturnResult(-1, exception.Message, true));
            }
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var data = await classService.List();
                return Json(new DTO.Shared.ReturnResult(data, null, false));
            }
            catch (Exception exception)
            {
                return Json(new DTO.Shared.ReturnResult(-1, exception.Message, true));
            }
        }
    }
}