using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL;
using AMaisImob_WEB.Helpers;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Models.IUGU;
using AMaisImob_WEB.Utils;
using iText.Kernel.Geom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OfficeOpenXml;
using Remotion.Linq.Clauses.ResultOperators;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = ClaimUtils.AllRolesExceptSeller)]
    public class FinancialController : Controller
    {
        private readonly ChargeCertificateContractualFunctions chargeCertificateContractualFunctions;
        private readonly ChargeFunctions chargeFunctions;
        private readonly FinancialFunctions financialFunctions;
        private readonly CompanyFunctions companyFunctions;
        private readonly UserCompanyFunctions userCompanyFunctions;
        private readonly CertificateFunctions certificateFunctions;
        private ICompositeViewEngine viewEngine;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.MailFunctions mailFunctions;

        private readonly string pathFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Archives", "Invoice", "CertificateContractual");
        private readonly string pathInvoiceFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Archives", "Invoice", "CertificateContractual", "Invoice");

        public FinancialController(ChargeCertificateContractualFunctions chargeCertificateContractualFunctions, ChargeFunctions chargeFunctions, FinancialFunctions financialFunctions, CompanyFunctions companyFunctions, UserCompanyFunctions userCompanyFunctions, UserManager<AMaisImob_DB.Models.User> userManager, ICompositeViewEngine viewEngine, CertificateFunctions certificateFunctions, BLL.MailFunctions mailFunctions)
        {
            this.chargeCertificateContractualFunctions = chargeCertificateContractualFunctions;
            this.chargeFunctions = chargeFunctions;
            this.financialFunctions = financialFunctions;
            this.companyFunctions = companyFunctions;
            this.userCompanyFunctions = userCompanyFunctions;
            this.userManager = userManager;
            this.viewEngine = viewEngine;
            this.certificateFunctions = certificateFunctions;
            this.mailFunctions = mailFunctions;
        }

        public async Task<IActionResult> Index(int? realEstateId, DateTime? referenceDate, bool? chargeContractualGuarantee)
        {
            if (realEstateId.HasValue && !await ValidateUser(realEstateId.Value))
                return await Task.Run(() => Forbid());

            ViewBag.RealEstateId = realEstateId;
            ViewBag.ReferenceDate = referenceDate;
            ViewBag.ChargeContractualGuarantee = chargeContractualGuarantee;

            return await Task.Run(() => View(false));
        }
        public async Task<IActionResult> Extract() => await Task.Run(() => View("Index", true));

        public async Task<IActionResult> LoadListViewComponent(FinancialFilterViewModel filter, bool? extract) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Financial.ListViewComponent), new { filter, extract = extract ?? false, cutScript = false }));
        public async Task<IActionResult> LoadChargeAnalyseViewComponent(DateTime? referenceDate, int? companyId, int? chargeId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Financial.ChargeAnalyseViewComponent), new { referenceDate, companyId, chargeId, cutScript = false }));

        [RequireRouteValues(new string[] { "chargeCertificateContractuals" })]
        public async Task<IActionResult> SaveChargeCertificateContractual([FromForm] ChargeViewModel charge, [FromForm] List<ChargeCertificateContractualViewModel> chargeCertificateContractuals)
        {
            if (!User.IsInRole("Administrator"))
                return await Task.Run(() => Forbid());

            if (!Directory.Exists(pathFile)) Directory.CreateDirectory(pathFile);
            if (!Directory.Exists(pathInvoiceFile)) Directory.CreateDirectory(pathInvoiceFile);

            var company = companyFunctions.GetDataByID(charge.RealEstateId);
            var values = await financialFunctions.GetValuesForCharge(charge.RealEstateId, charge.ReferenceDate);

            if (values.Any(x => x.Certificate))
            {
                var certificate = values.First(x => x.Certificate);
                charge.PriceCertificate = certificate.Price;
                charge.TotalCertificate = certificate.Amount;
            }
            if (values.Any(x => x.DocuSign))
            {
                var docuSign = values.First(x => x.DocuSign);
                charge.PriceDocuSign = docuSign.Price;
                charge.TotalDocuSign = docuSign.Amount;
            }

            charge.RealStateChargeContractualGuarantee = company.ChargeContractualGuarantee ?? false;
            charge.ChargeId = chargeFunctions.CreateOrUpdate(charge);

            foreach (var chargeCertificateContractual in chargeCertificateContractuals)
            {
                if (values.Any(x => x.CertificateContractual && x.GuarantorId == chargeCertificateContractual.GuarantorId))
                {
                    ChargePriceItem certificateContractual = values.First(x => x.CertificateContractual && x.GuarantorId == chargeCertificateContractual.GuarantorId);
                    chargeCertificateContractual.Price = certificateContractual.Price;
                    chargeCertificateContractual.Total = certificateContractual.Amount;
                }

                chargeCertificateContractual.ChargeId = charge.ChargeId.Value;

                chargeCertificateContractual.ChargeCertificateContractualId = chargeCertificateContractualFunctions.CreateOrUpdate(chargeCertificateContractual);

                if (chargeCertificateContractual.File != null) SaveChargeCertificateContractualFile(chargeCertificateContractual.ChargeCertificateContractualId.Value, chargeCertificateContractual.File);
                if (chargeCertificateContractual.FileInvoice != null) SaveChargeCertificateContractualFileInvoice(chargeCertificateContractual.ChargeCertificateContractualId.Value, chargeCertificateContractual.FileInvoice);
            }

            return await Task.Run(() => Json(new { charge.ChargeId, charge.RealEstateId }));
        }

        public async Task<IActionResult> SaveChargeCertificateContractual([FromForm] ChargeViewModel charge)
        {
            if (!User.IsInRole("Administrator"))
                return await Task.Run(() => Forbid());

            var company = companyFunctions.GetDataByID(charge.RealEstateId);
            var values = await financialFunctions.GetValuesForCharge(charge.RealEstateId, charge.ReferenceDate);

            if (values.Any(x => x.Certificate))
            {
                var certificate = values.First(x => x.Certificate);
                charge.PriceCertificate = certificate.Price;
                charge.TotalCertificate = certificate.Amount;
            }
            if (values.Any(x => x.DocuSign))
            {
                var docuSign = values.First(x => x.DocuSign);
                charge.PriceDocuSign = docuSign.Price;
                charge.TotalDocuSign = docuSign.Amount;
            }

            charge.RealStateChargeContractualGuarantee = company.ChargeContractualGuarantee ?? false;
            charge.RealStateChargeCertificate = company.ChargeCertificate ?? false;
            charge.RealStateChargeDocuSign = company.ChargeDocuSign ?? false;
            charge.ChargeId = chargeFunctions.CreateOrUpdate(charge);

            return await Task.Run(() => Json(new { charge.ChargeId, charge.RealEstateId }));
        }

        private bool SaveChargeCertificateContractualFile(int chargeCertificateContractualId, IFormFile file)
        {
            AMaisImob_DB.Models.ChargeCertificateContractual chargeCertificateContractual = chargeCertificateContractualFunctions.GetDataByID(chargeCertificateContractualId);

            if (!string.IsNullOrWhiteSpace(chargeCertificateContractual.GuidFileName) && System.IO.File.Exists(System.IO.Path.Combine(pathFile, chargeCertificateContractual.GuidFileName)))
            {
                System.IO.File.Delete(System.IO.Path.Combine(pathFile, chargeCertificateContractual.GuidFileName));
                chargeCertificateContractualFunctions.DeleteFile(chargeCertificateContractualId);
            }

            string guidName;
            try
            {
                guidName = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(file.FileName)}";

                string filePath = System.IO.Path.Combine(pathFile, guidName);

                using (Stream strArchive = file.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }
            }
            catch { return false; }

            chargeCertificateContractualFunctions.UpdateFile(new ChargeCertificateContractualViewModel
            {
                ChargeCertificateContractualId = chargeCertificateContractualId,
                FileName = file.FileName,
                GuidFileName = guidName,
                MimeType = file.ContentType,

            });

            return true;
        }

        private bool SaveChargeCertificateContractualFileInvoice(int chargeCertificateContractualId, IFormFile file)
        {
            AMaisImob_DB.Models.ChargeCertificateContractual chargeCertificateContractual = chargeCertificateContractualFunctions.GetDataByID(chargeCertificateContractualId);

            if (!string.IsNullOrWhiteSpace(chargeCertificateContractual.GuidFileName) && System.IO.File.Exists(System.IO.Path.Combine(pathInvoiceFile, chargeCertificateContractual.GuidFileName)))
            {
                System.IO.File.Delete(System.IO.Path.Combine(pathInvoiceFile, chargeCertificateContractual.GuidFileName));
                chargeCertificateContractualFunctions.DeleteInvoiceFile(chargeCertificateContractualId);
            }

            string guidName;
            try
            {
                guidName = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(file.FileName)}";

                string filePath = System.IO.Path.Combine(pathInvoiceFile, guidName);

                using (Stream strArchive = file.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }
            }
            catch { return false; }

            chargeCertificateContractualFunctions.UpdateInvoiceFile(new ChargeCertificateContractualViewModel
            {
                ChargeCertificateContractualId = chargeCertificateContractualId,
                InvoiceFileName = file.FileName,
                InvoiceGuidFileName = guidName,
                InvoiceMimeType = file.ContentType,

            });

            return true;
        }

        public async Task<IActionResult> GetChargeCertificateContractualFile(int chargeCertificateContractualId)
        {
            var entity = chargeCertificateContractualFunctions.GetDataByID(chargeCertificateContractualId);
            if (!User.IsInRole("Administrator"))
            {
                var charge = chargeFunctions.GetDataByID(entity.ChargeId);

                if (!await ValidateUser(charge.RealEstateId))
                    return await Task.Run(() => Forbid());
            }

            var filePath = System.IO.Path.Combine(pathFile, entity.GuidFileName);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), entity.MimeType, entity.FileName));
        }

        public async Task<IActionResult> GetChargeCertificateContractualInvoiceFile(int chargeCertificateContractualId)
        {
            var entity = chargeCertificateContractualFunctions.GetDataByID(chargeCertificateContractualId);

            if (!User.IsInRole("Administrator"))
            {
                var charge = chargeFunctions.GetDataByID(entity.ChargeId);

                if (!await ValidateUser(charge.RealEstateId))
                    return await Task.Run(() => Forbid());
            }

            var filePath = System.IO.Path.Combine(pathInvoiceFile, entity.InvoiceGuidFileName);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), entity.InvoiceMimeType, entity.InvoiceFileName));
        }

        public async Task<IActionResult> ResetChargeContractualGuarantee(int chargeId)
        {
            if (!User.IsInRole("Administrator")) return Forbid();
            var charge = chargeFunctions.GetDataByID(chargeId);

            if (charge.IsLocked)
                return await Task.Run(() => Json(new { hasError = true, message = "Não é possível recalcular, pois já existe um boleto para este item." }));

            var chargeCertificateContractuals = chargeCertificateContractualFunctions.GetDataAsNoTracking(x => x.ChargeId == chargeId);

            foreach (var item in chargeCertificateContractuals)
            {
                if (!string.IsNullOrWhiteSpace(item.GuidFileName) && System.IO.File.Exists(System.IO.Path.Combine(pathInvoiceFile, item.GuidFileName)))
                    System.IO.File.Delete(System.IO.Path.Combine(pathInvoiceFile, item.GuidFileName));
            }

            chargeCertificateContractualFunctions.DeleteRange(chargeCertificateContractuals);

            chargeFunctions.Delete(charge.ChargeId);

            return await Task.Run(() => Json(new { hasError = false }));
        }

        public async Task<IActionResult> GenerateInvoices(List<int> realEstateIds, DateTime referenceDate)
        {
            if (!User.IsInRole("Administrator"))
                return await Task.Run(() => Forbid());

            var chargeResults = new List<ChargeResult>();

            foreach (var realEstateId in realEstateIds)
                chargeResults.Add(await GenerateInvoiceForRealEstate(realEstateId, referenceDate));


            return await Task.Run(() => Json(Newtonsoft.Json.JsonConvert.SerializeObject(chargeResults)));
        }

        private async Task<ChargeResult> GenerateInvoiceForRealEstate(int realEstateId, DateTime referenceDate)
        {
            if (!User.IsInRole("Administrator"))
                return await Task.Run(() => new ChargeResult
                {
                    Message = "Este usuário não possui permissão para gerar boletos.",
                    Success = false,
                });

            var charge = chargeFunctions.GetDataAsNoTracking(x => x.RealEstateId == realEstateId && x.ReferenceDate == referenceDate).FirstOrDefault();

            if (charge != null) // Caso a imobilíaria não tenho nenhuma garantia contratual o admin não é obrigado a editar os valores, dessa forma alguns itens podem vir sem o "Charge" previamente criado.
                return await GenerateInvoiceForCharge(charge.ChargeId);

            #region [Criar Charge]
            var chargeViewModel = new ChargeViewModel();

            var company = companyFunctions.GetDataByID(realEstateId);
            var values = await financialFunctions.GetValuesForCharge(realEstateId, referenceDate);

            if (values.Any(x => x.Certificate))
            {
                var certificate = values.First(x => x.Certificate);
                chargeViewModel.PriceCertificate = certificate.Price;
                chargeViewModel.TotalCertificate = certificate.Amount;
            }
            if (values.Any(x => x.DocuSign))
            {
                var docuSign = values.First(x => x.DocuSign);
                chargeViewModel.PriceDocuSign = docuSign.Price;
                chargeViewModel.TotalDocuSign = docuSign.Amount;
            }

            chargeViewModel.RealStateChargeContractualGuarantee = company.ChargeContractualGuarantee ?? false;
            chargeViewModel.ReferenceDate = referenceDate;
            chargeViewModel.RealEstateId = realEstateId;

            chargeViewModel.ChargeId = chargeFunctions.CreateOrUpdate(chargeViewModel);

            if (values.Any(x => x.CertificateContractual))
            {
                foreach (var value in values.Where(x => x.CertificateContractual))
                {
                    chargeCertificateContractualFunctions.CreateOrUpdate(new ChargeCertificateContractualViewModel
                    {
                        ChargeId = chargeViewModel.ChargeId.Value,
                        GuarantorId = value.GuarantorId.Value,
                        Price = value.Price,
                        Total = value.Amount
                    });
                }
            }
            #endregion

            return await GenerateInvoiceForCharge(chargeViewModel.ChargeId.Value);
        }

        private async Task<ChargeResult> GenerateInvoiceForCharge(int chargeId)
        {
            var result = await financialFunctions.Charge(chargeId);

            if (result.Success)
                await SendChargeEmail(result.ChargeId);

            return result;
        }

        private async Task SendChargeEmail(int chargeId)
        {
            var chargeViewModel = chargeFunctions.GetDataViewModel(chargeFunctions.GetDataByID(chargeId));
            var realEstate = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(chargeViewModel.RealEstateId));
            var realEstateAgency = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(realEstate.ParentCompanyId));

            var html = await RenderPartialViewToString("Email", chargeViewModel);
            List<Attachment> attachments = new List<Attachment>();

            if (chargeViewModel.RealStateChargeCertificate == true)
            {
                //Relatório de certificados
                var excelBytes = await CertificateController.GetReportRealEstate(certificateFunctions.GetCertificateExport(realEstate.ParentCompanyId, realEstate.CompanyId, null, chargeViewModel.ReferenceDate), realEstateAgency, realEstate, chargeViewModel.ReferenceDate);
                attachments.Add(new Attachment(new MemoryStream(excelBytes), $"relatorio-certificados-{chargeViewModel.ReferenceDate:MM/yyyy}.xlsx", "application/vnd.ms-excel"));
            }

            foreach (var item in chargeCertificateContractualFunctions.GetDataAsNoTracking(x => x.ChargeId == chargeId)) //uploads feitos
            {
                //if (!string.IsNullOrWhiteSpace(item.GuidFileName))
                //{
                //    var path = System.IO.Path.Combine(pathFile, item.GuidFileName);
                //    if (System.IO.File.Exists(path))
                //        attachments.Add(new Attachment(new MemoryStream(System.IO.File.ReadAllBytes(path)), $"{item.FileName}", item.MimeType));
                //}

                if (!string.IsNullOrWhiteSpace(item.InvoiceGuidFileName))
                {
                    var pathInvoice = System.IO.Path.Combine(pathInvoiceFile, item.InvoiceGuidFileName);
                    if (System.IO.File.Exists(pathInvoice))
                        attachments.Add(new Attachment(new MemoryStream(System.IO.File.ReadAllBytes(pathInvoice)), $"{item.InvoiceFileName}", item.InvoiceMimeType));
                }
            }

            //Boleto
            if (!string.IsNullOrWhiteSpace(chargeViewModel.IUGUUrl)) {
                byte[] bytes = new WebClient().DownloadData($"{chargeViewModel.IUGUUrl}.pdf");
                attachments.Add(new Attachment(new MemoryStream(bytes), $"Boleto-{chargeViewModel.ReferenceDate:MM/yyyy}.pdf", "application/pdf"));
            }

#if DEBUG
            await mailFunctions.SendAsync($"FATURAMENTO A+ IMOB {chargeViewModel._ReferenceDate.ToUpper()} - {realEstate.CompanyName_TradeName.ToUpper()}", html, (await GetAllEmailFromRealEstate(chargeViewModel.RealEstateId)).Distinct(), attachments, false, null);
#else
            await mailFunctions.SendAsync($"FATURAMENTO A+ IMOB {chargeViewModel._ReferenceDate.ToUpper()} - {realEstate.CompanyName_TradeName.ToUpper()}", html, (await GetAllEmailFromRealEstate(chargeViewModel.RealEstateId)).Distinct(), attachments, false, null, new List<string> { "financeiro@amaisseg.com.br" });
#endif
        }

        private async Task<bool> ValidateUser(int realEstateId)
        {
            if (User.IsInRole("Administrator")) return true;

            var userId = (await userManager.GetUserAsync(User)).Id;
            var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

            if (User.IsInRole("Corretor"))
            {
                var realState = companyFunctions.GetDataByID(realEstateId);

                if (realState.ParentCompanyId != companyUser.CompanyId) // verifica se o corretor tem acesso a imobiliria informada
                    return false;
            }
            else if (companyUser.CompanyId != realEstateId)
                return false;

            return true;
        }

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }

        #region [SHARED]
        private async Task<List<string>> GetAllEmailFromRealEstate(int realEstateId)
        {
            var emailToSend = new List<string>();

            emailToSend.AddRange((await userCompanyFunctions.GetRealEstateAdministratorUser(realEstateId)).Select(x => x.Email));
            emailToSend.AddRange(userCompanyFunctions.GetUsersByCompanyIdWithoutRealStateSellers(realEstateId).Select(x => x.Email));

            return emailToSend;
        }
        #endregion
    }
}
