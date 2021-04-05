using DTO.Account;
using DTO.Subscription;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Admin;
namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        #region [Redirects]
        [Route("SeguroProfissional")]
        public async Task<IActionResult> SeguroProfissional()
        {
            return await Task.Run(() => RedirectToAction(nameof(Index)));
        }
        [Route("SeguroClinicaVeterinaria")]
        public async Task<IActionResult> SeguroClinicaVeterinaria()
        {
            return await Task.Run(() => Redirect("https://vendas.amaisvet.com.br/antigo/SeguroClinicaVeterinaria"));
        }
        #endregion

        public IActionResult Index()
        {
            return View();
 
        }
        //public IActionResult Index1()
        //{
        //    return View();
 
        //}
        
        //public IActionResult UpgradeSubscription(SubscriptionDetailViewModel model)
        //{
        //    return View(model);
        //}
        
        //public IActionResult RelationshipProgram()
        //{
        //    return View();
        //}      
        //public IActionResult UpdateAccount()
        //{
        //    return View();
        //}
        //public IActionResult AdminArea()
        //{
        //    return View();
        //}
    }
}

