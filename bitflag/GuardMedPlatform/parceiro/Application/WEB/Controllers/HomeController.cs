using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using Microsoft.AspNetCore.Authorization;
using WEB.Utils;

namespace WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BLL.CertificateFunctions certificateFunctions;

        public HomeController(DB.Models.Insurance_HomologContext context)
        {
            certificateFunctions = new BLL.CertificateFunctions(context);
        }

        public IActionResult Index(string message)
        {
            if(!string.IsNullOrWhiteSpace(message))
                ViewData["AcceptRealEstateMessage"] = message;

            var oneYearAgo = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year - 1, DateTime.Now.Month));
            Dictionary<string, int> adhenrencesCount = new Dictionary<string, int>();
            for (int i = 0; i <= 12; i++)
            {
                adhenrencesCount.Add(oneYearAgo.AddMonths(i).ToMonthYearPtBR(), certificateFunctions.CountAdherencesInMonth(oneYearAgo.AddMonths(i)));
            }


            var certificates = certificateFunctions.GetData().ToList();

            return View(new Models.HomeViewModel {
                CertificadosPendentes = certificates.Count(x => x.IsSimulation && !x.IsDeleted),
                CertificadosAtivos = certificates.Count(x => !x.IsSimulation && !x.IsDeleted  && x.AdherenceDate.IsActive()),
                CertificadosRenovar = certificates.Count(x => !x.IsSimulation && !x.IsDeleted && x.AdherenceDate.IsInTimeToRenovate()),
                CertificadosAderidos = adhenrencesCount
            });
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
