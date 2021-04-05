using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMaisImob_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace AMaisImob_WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BLL.CertificateFunctions certificateFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.ChargeFunctions chargeFunctions;
        private IMemoryCache cache;

        public HomeController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager, IMemoryCache cache)
        {
            certificateFunctions = new BLL.CertificateFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.chargeFunctions = new BLL.ChargeFunctions(context);
            this.userManager = userManager;
            this.cache = cache;
        }

        public async Task<IActionResult> Index(string message, int companyId)
        {
            if (!string.IsNullOrWhiteSpace(message))
                ViewData["AcceptRealEstateMessage"] = message;



            //COMBO PARA SELECIONAR ID CORRETO DE CORRETOR OU IMOBILIARIA

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId).ToList();
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
                }
            }

            return View();
        }

        public async Task<IActionResult> LoadHomeVIPViewComponent(int? realEstateId, int? realEstateAgencyId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Home.HomeVIPViewComponent), new { realEstateAgencyId, realEstateId }));


        public async Task<IActionResult> GetPainelGestao(int? companyId)
        {
            int? type = null;
            var painel = certificateFunctions.GetPainel(companyId);

            if (companyId.HasValue)
            {
                type = companyFunctions.GetDataByID(companyId).CompanyTypeId;
            }
            List<AMaisImob_DB.Models.Certificate> certificates = null;

            int cacheExpirationMinutes = 30;
            if (type == 2)
            {
                if (!cache.TryGetValue("certificates-type-2-" + (companyId.HasValue ? companyId.ToString() : "0"), out certificates))
                {
                    certificates = certificateFunctions.GetData(x => x.RealEstateId == companyId).AsNoTracking().ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                    cache.Set("certificates-type-2" + (companyId.HasValue ? companyId.ToString() : "0"), certificates, cacheEntryOptions);
                }
            }
            else if (type == 1)
            {
                if (!cache.TryGetValue("certificates-type-1" + (companyId.HasValue ? companyId.ToString() : "0"), out certificates))
                {
                    certificates = certificateFunctions.GetData(x => x.RealEstateAgencyId == companyId).ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                    cache.Set("certificates-type-1" + (companyId.HasValue ? companyId.ToString() : "0"), certificates, cacheEntryOptions);
                }
            }
            else
            {
                if (!cache.TryGetValue("certificates-no-type", out certificates))
                {
                    certificates = certificateFunctions.GetData().AsNoTracking().ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                    cache.Set("certificates-no-type", certificates, cacheEntryOptions);
                }
            }

            //FATURAS (ULTIMA E PROXIMA)
            var currentDate = DateTime.Now;
            var previousDate = currentDate.AddMonths(-1);
            var previousMonth = currentDate.AddMonths(-1).Month;
            var previousYear = currentDate.AddMonths(-1).Year;
            var ultimaFatura = chargeFunctions.GetPrice(previousMonth, previousDate.Year, companyId).ToPtBR();
            var proximaFatura = chargeFunctions.GetPrice(currentDate.Month, currentDate.Year, companyId).ToPtBR();

            bool? previousStatus = null;
            bool? currentStatus = null;
            if (companyId.HasValue)
            {
                var company = companyFunctions.GetDataByID(companyId);
                if (company.ParentCompanyId != null)
                {
                    currentStatus = chargeFunctions.WasPaid(company.CompanyId, currentDate);
                    previousStatus = chargeFunctions.WasPaid(company.CompanyId, previousDate);
                }

            }


            return await Task.Run<IActionResult>(() => Json(new Models.HomeViewModel
            {
                CertificadosPendentes = certificates.Count(x => x.IsSimulation && !x.IsDeleted),
                CertificadosAtivos = certificates.Count(x => !x.IsSimulation && !x.IsDeleted && x.AdherenceDate.IsActive()),
                CertificadosRenovar = certificates.Count(x => !x.IsSimulation && !x.IsDeleted && x.VigencyDate.IsInTimeToRenovate()),
                CertificadosAderidos = painel,
                TaxaInquilinoTotal = painel.Sum(x => x.TotalInquilino).ToPtBR(),
                TaxaInquilinoUltimoMes = painel.FirstOrDefault(x => x.MesAtual.Month == (previousMonth) && x.MesAtual.Year == previousYear).TotalInquilino.ToPtBR(),
                ValorUltimaFatura = ultimaFatura,
                ValorProximaFatura = proximaFatura,
                PreviousStatus = previousStatus,
                CurrentStatus = currentStatus
            }));
        }

        public async Task<IActionResult> GetRank(int companyId)
        {
            int cacheExpirationMinutes = 30;

            List<CompanyRankData> certificateCount = null;
            List<CompanyRankData> certificateTaxaInquilino = null;
            List<CompanyRankData> certificateCharges = null;


            if (!cache.TryGetValue("rankingCertificateCount" + companyId, out certificateCount))
            {
                certificateCount = certificateFunctions.GetActiveCertificatesByCompany().OrderByDescending(x => x.Count).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                cache.Set("rankingCertificateCount" + companyId, certificateCount, cacheEntryOptions);
            }
            if (!cache.TryGetValue("rankingCertificateTaxaInquilino" + companyId, out certificateTaxaInquilino))
            {
                certificateTaxaInquilino = certificateFunctions.GetCertificatesTaxaInquilinoByCompany().OrderByDescending(x => x.InquilinoAnual).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                cache.Set("rankingCertificateTaxaInquilino" + companyId, certificateTaxaInquilino, cacheEntryOptions);
            }
            if (!cache.TryGetValue("rankingCertificateCharges" + companyId, out certificateCharges))
            {
                certificateCharges = certificateFunctions.GetCertificatesOrderByCharges().OrderByDescending(x => x.ProximaFatura).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));
                cache.Set("rankingCertificateCharges" + companyId, certificateCharges, cacheEntryOptions);
            }



            //var certificateCount = certificateFunctions.GetActiveCertificatesByCompany().OrderByDescending(x => x.Count).ToList();
            //var certificateTaxaInquilino = certificateFunctions.GetCertificatesTaxaInquilinoByCompany().OrderByDescending(x => x.InquilinoAnual).ToList();
            //var certificateCharges = certificateFunctions.GetCertificatesOrderByCharges().OrderByDescending(x => x.ProximaFatura).ToList();

            return await Task.Run<IActionResult>(() => Json(new List<RankingViewModel>()
            {
                certificateFunctions.GetRanking(certificateCount, companyId),
                certificateFunctions.GetRanking(certificateTaxaInquilino, companyId),
                certificateFunctions.GetRanking(certificateCharges, companyId)
            }));

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
