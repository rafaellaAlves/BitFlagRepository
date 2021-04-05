using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Account;
using DTO.Admin;
using DTO.Subscription;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult ValidateCPF([FromBody] SubscriptionViewModel model)
        {
            try
            {
                if (model.Cpf == "102.733.078-94")
                    return Json(true);
                else
                    return Json(false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        [HttpPost]
        public IActionResult UpdateDataAccount([FromBody] SubscriptionViewModel model)
        {
            try
            {
                if (model.Email == "rafaa.silvaa199@gmail.com" && model.MobileNumber == "996759557" && model.PhoneNumber == "32256582")
                    return Json(true);
                else
                    return Json(false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var model = new DTO.Admin.LoginViewModel()
            {
                Username = username,
                Password = password,
                Type = 1
            };

            return RedirectToAction("Index", "Home", new {model.Type, model.Username});

        }
    }
}
