using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FUNCTIONS.Family.FamilyFunctions familyFunctions;
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private DB.TerraNostraContext context;

        public HomeController(FUNCTIONS.Family.FamilyFunctions familyFunctions, DB.TerraNostraContext context, FUNCTIONS.User.UserFunctions userFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager)
        {
            this.familyFunctions = familyFunctions;
            this.context = context;
            this.userFunctions = userFunctions;
            this.userManager = userManager;
        }

        public IActionResult Index(int clientId)
        {
            var x = context.UserIndicators.ToList();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ReturnsFinished()
        {
            List<DB.UserIndicators> result;
            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();

                result = context.UserIndicators.Where(x => x.ResponsibleId == userId).ToList();
            }
            else
            {
                result = context.UserIndicators.ToList();
            }

            return Json(new
            {
                Finished = result.Count(x => x.Finished),
                NotFinished = result.Count(x => !x.Finished)
            });
        }

        public IActionResult ReturnsInvoiceStatus()
        {
            List<DB.InvoiceView> status;
            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();

                status = context.InvoiceView.Where(x => x.ResponsibleId == userId).ToList();
            }
            else
            {
                status = context.InvoiceView.ToList();
            }

            return Json(new
            {
                Undernegotiation = status.Count(x => x.InvoiceStatusId == 1),
                Repproved = status.Count(x => x.InvoiceStatusId == 2),
                Approved = status.Count(x => x.InvoiceStatusId == 3),
                Abandoned = status.Count(x => x.InvoiceStatusId == 4),
            });
        }

        public IActionResult ReturnClientsCurrentStepCount()
        {
            int? userId = null;
            if (User.IsInRole("Salesman"))
            {
                userId = User.GetUserId();
            }

            var result = from ui in context.UserIndicators
                         where ui.ResponsibleId == userId || !userId.HasValue
                         group ui by new { ui.StepId, ui.Step } into g
                         select new
                         {
                             StepName = g.Key.Step,
                             Count = g.Count(),
                         };

            return Json(result);
        }

        public async Task<IActionResult> ChangeSalesmanStatus(bool salesmanAvailable)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var deuCerto = this.userFunctions.SetSalesmanAvailable(user.Id, salesmanAvailable);

            return Json(deuCerto);
        }
    }
}
