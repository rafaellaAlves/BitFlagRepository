using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using WEB.Utils;
using System.Globalization;
using VendasDbContext.Models;

namespace WEB.Controllers
{
    [Authorize]
    public class RedirectController : Controller
    {
        private readonly BLL.CertificateFunctions certificateFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly Insurance_HomologContext context;
        private readonly VendasContext vendas;
        private readonly BLL.SeguradoProfissionalExtracaoFunctions seguradoProfissionalExtracaoFunctions;

        public RedirectController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager, VendasContext vendas)
        {
            this.context = context;
            this.certificateFunctions = new BLL.CertificateFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
            this.vendas = vendas;
            this.seguradoProfissionalExtracaoFunctions = new BLL.SeguradoProfissionalExtracaoFunctions(vendas);

        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();


            return View();
        }

        public async Task<IActionResult> RedirectIndexViewComponent()
        {
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId && c.TermAccepted).ToList();

            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    ViewData["UserRealEstateAgencyId"] = companyUser.CompanyId;

                }
            }
            else if (User.IsInRealEstate())
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstateAgencyId = companyFunctions.GetDataByID(companyUser.CompanyId).ParentCompanyId;
                    ViewData["UserRealEstateAgencyId"] = userRealEstateAgencyId;
                    ViewData["UserRealEstateId"] = companyUser.CompanyId;
                }
            }

            return ViewComponent(typeof(ViewComponents.Redirect.RedirectIndexViewComponent));
        }
    }
}