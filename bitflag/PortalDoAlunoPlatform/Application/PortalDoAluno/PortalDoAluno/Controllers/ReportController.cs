using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private Services.Student.StudentService studentService;
        public ReportController(Services.Student.StudentService studentService)
        {
            this.studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region [PRESENCE]
        public async Task<IActionResult> PresenceIndex()
        {
            return await Task.Run(() => View());
        }

        public IActionResult PresenceList(int classId, DateTime date, int periodId)
        {


            return View();
        }
        #endregion
        public IActionResult CertificatesDelivered()
        {
            return View();
        }

        public IActionResult InstituteDocumentation()
        {
            return View();
        }

        public IActionResult PersonalDocumentation()
        {
            return View();
        }

        public IActionResult ProfessionalDocumentation()
        {
            return View();
        }

        public IActionResult PresentialSituation()
        {
            return View();
        }

        public IActionResult EmailList()
        {
            return View();
        }

        public IActionResult PhotosList()
        {
            return View();
        }
        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult PresenceListReport()
        {
            return View();
        }

        public IActionResult Pimaco()
        {
            return View();
        }
    }
}
