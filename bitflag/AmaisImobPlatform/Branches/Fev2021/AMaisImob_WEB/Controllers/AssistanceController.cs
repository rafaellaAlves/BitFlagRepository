using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL;
using AMaisImob_WEB.Utils;
using BackgroundServices.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;

namespace AMaisImob_WEB.Controllers
{
    [Authorize]
    public class AssistanceController : Controller
    {
        private readonly BLL.AssistanceFunctions assistanceFunctions;
        private readonly BLL.ProductAssistanceFunctions productAssistanceFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;

        public AssistanceController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager)
        {
            this.assistanceFunctions = new BLL.AssistanceFunctions(context);
            this.productAssistanceFunctions = new BLL.ProductAssistanceFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AssistanceManageComponent(int? id)
        {
            Models.AssistanceViewModel model = new Models.AssistanceViewModel();

            if (id.HasValue)
                model = assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.Assistance.AssistanceManageViewComponent), new { model = model });
        }

        public async Task<IActionResult> AssistanceReportComponent() => await Task.Run(() => ViewComponent(typeof(AMaisImob_WEB.ViewComponents.Assistance.AssistanceReportViewComponent)));

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AssistanceIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Assistance.AssistanceIndexViewComponent));
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.AssistanceViewModel model)
        {
            Utils.DBActionType actionType;
            if (model.AssistanceId.HasValue) actionType = Utils.DBActionType.UPDATE;
            else actionType = Utils.DBActionType.CREATE;

            var user = await userManager.GetUserAsync(User);

            var productFamilyId = assistanceFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("AssistanceViewModel", productFamilyId, "AssistanceId", actionType, assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(productFamilyId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(productFamilyId, "", false));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            IEnumerable<AMaisImob_WEB.Models.AssistanceViewModel> d = assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveAssistance")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveAssistance(int id)
        {
            if (!assistanceFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Assistência não encontrada para remover.", true));

            if (assistanceFunctions.IsInCertificate(id))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir esta assistência, pois esta em um certificado.", true));
            }

            assistanceFunctions.Delete(id);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("AssistanceViewModel", id, "AssistanceId", Utils.DBActionType.DELETE, assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(id)), user.Id, "Exclusão");
            return Json(new BLL.Shared.ReturnResult(id, "Assistência excluída com sucesso!", false));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductAssistanceComponent(int? productId)
        {
            if (!productId.HasValue) return Forbid();

            var model = productAssistanceFunctions.GetDataManageViewModel(productId.Value);
            ViewData["Assistances"] = assistanceFunctions.GetData(x => !x.IsDeleted).ToList();

            return ViewComponent(typeof(ViewComponents.Assistance.ProductAssistanceViewComponent), new { model = model });
        }

        [HttpPost]
        [ActionName("ProductAssistanceSave")]
        [Authorize(Roles = "Administrator")]
        public IActionResult ProductAssistanceSave(int? productId, List<int> assistanceIds)
        {
            if (!productId.HasValue)
                return Json(new BLL.Shared.ReturnResult(0, "", true));

            productAssistanceFunctions.DeleteByProductId(productId.Value);
            productAssistanceFunctions.Create(productId.Value, assistanceIds);

            return Json(new BLL.Shared.ReturnResult(productId.Value, "", false));
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetAssistancesByProductId(int? productId)
        {
            if (!productId.HasValue) return Json(false);

            var productAssistances = productAssistanceFunctions.GetDataByProductId(productId.Value);
            var assistances = assistanceFunctions.GetData(x => !x.IsDeleted);

            var r = assistanceFunctions.GetDataViewModel((from y in productAssistances
                                                          join a in assistances on y.AssistanceId equals a.AssistanceId
                                                          select a));

            return Json(r);
        }

        public async Task<IActionResult> Export(List<int> companyIds, string refMonth, [FromServices] CompanyFunctions companyFunctions)
        {
            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

            var date = refMonth.FromDatePtBR();
            for (int index = 0; index < companyIds.Count; index++)
            {
                var companyId = companyIds[index];

                var data = assistanceFunctions.GetAssistanceExport(companyId, date.Value);
                var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId));

                var byteArray = System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "template", "Blank.xlsx"));
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(byteArray, 0, (int)byteArray.Length);
                    memoryStream.Position = 0;

                    using (var excelPackage = new ExcelPackage(memoryStream))
                    {
                        //foreach (var item in certificates.GroupBy(x => x.Apolice))
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                        worksheet.Name = $"{company.CompanyName}";
                        worksheet.Column(4).Style.Numberformat.Format = "0000000000";

                        int l = 0;
                        worksheet.Cells[1, ++l].Value = "H";
                        worksheet.Cells[1, ++l].Value = $"00{DateTime.Now:yyyyMMdd}";
                        worksheet.Cells[1, ++l].Value = "AMA";
                        worksheet.Cells[1, ++l].Value = "L1";
                        worksheet.Cells[1, ++l].Value = DateTime.Now.ToString("yyyyMMdd");
                        worksheet.Cells[1, ++l].Value = data.Count.ToString("0000000000");
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";
                        worksheet.Cells[1, ++l].Value = "";

                        int i = 2;
                        foreach (var certificate in data.OrderBy(x => x.DataDeInclusao))
                        {
                            l = 0;
                            var reference = $"XXXXXXXXXXXXXXXXXXXXXX{certificate.Referencia}";
                            var document = Utils.StringExtensions.NumbersOnly(certificate.CPFInquilino);

                            var cep = Utils.StringExtensions.NumbersOnly(certificate.CEP);
                            for (int c = 0; c < (8 - cep.Length); c++) cep = "0" + cep;

                            worksheet.Cells[i, ++l].Value = reference.Length > 30 ? reference.Substring(0, 30) : reference;
                            worksheet.Cells[i, ++l].Value = certificate.NomeInquilino;
                            worksheet.Cells[i, ++l].Value = document.Length > 14 ? document.Substring(0, 14) : document;
                            worksheet.Cells[i, ++l].Value = certificate.VigencyDate.ToString("yyyyMMdd");
                            worksheet.Cells[i, ++l].Value = certificate.VigencyDate.ToString("yyyyMMdd");
                            worksheet.Cells[i, ++l].Value = certificate.VigencyDate.AddYears(1).ToString("yyyyMMdd");
                            worksheet.Cells[i, ++l].Value = certificate.AssistanceReportCode;
                            worksheet.Cells[i, ++l].Value = "I";
                            worksheet.Cells[i, ++l].Value = certificate.LocalDeRisco.Length > 150 ? certificate.LocalDeRisco.Substring(0, 150) : certificate.LocalDeRisco; //Endereço
                            worksheet.Cells[i, ++l].Value = certificate.Numero.Length > 5 ? certificate.Numero.Substring(0, 5) : certificate.Numero;
                            worksheet.Cells[i, ++l].Value = certificate.Complemento.Length > 10 ? certificate.Complemento.Substring(0, 10) : certificate.Complemento;
                            worksheet.Cells[i, ++l].Value = certificate.Bairro.Length > 50 ? certificate.Bairro.Substring(0, 50) : certificate.Bairro;
                            worksheet.Cells[i, ++l].Value = certificate.Cidade.Length > 50 ? certificate.Cidade.Substring(0, 50) : certificate.Cidade;
                            worksheet.Cells[i, ++l].Value = cep;
                            worksheet.Cells[i, ++l].Value = certificate.UF;
                            worksheet.Cells[i, ++l].Value = (i - 1).ToString("000000000");

                            i++;
                        }
                        if (data.Count > 0) i--;

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        files.Add($"{index:00}_{company.CompanyName_TradeName}.xlsx", excelPackage.GetAsByteArray());
                    }
                }
            }

            using (var outputStream = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(outputStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var zipEntry = archive.CreateEntry(file.Key, System.IO.Compression.CompressionLevel.Optimal);
                        using (var zipStream = zipEntry.Open())
                        {
                            zipStream.Write(file.Value, 0, file.Value.Length);
                        }
                    }
                    archive.Dispose();
                }

                return await Task.Run(() => File(outputStream.ToArray(), "application/zip", $"Exportacoes_Assistencias_{date:MM-yyyy}.zip"));
            }
        }

        public async Task<IActionResult> ExportTXT(string refMonth)
        {
            var data = assistanceFunctions.GetAssistanceExport(null, refMonth.FromDatePtBR().Value);
            using (var txtMemoryStream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(txtMemoryStream, Encoding.GetEncoding("windows-1252")))
                {
                    ExportTXTWriteHeader(sw, data.Count);

                    int i = 2;
                    foreach (var certificate in data.OrderBy(x => x.DataDeInclusao))
                    {
                        ExportTXTWriteBodyLine(sw, certificate, i);
                        i++;
                    }
                }

                return await Task.Run(() => File(txtMemoryStream.ToArray(), "text/plain", $"Assistencias_AMAISIMOB_{refMonth.FromDatePtBR().Value:yyyy_MM}.txt"));
            }
        }

        void ExportTXTWriteHeader(StreamWriter sw, int totalCount)
        {
            var strings = new List<string>();

            strings.Add("H");
            strings.Add($"00{DateTime.Now:yyyyMMdd}");
            strings.Add("AMA");
            strings.Add("L1");
            strings.Add(DateTime.Now.ToString("yyyyMMdd"));
            strings.Add(totalCount.ToString("0000000000"));
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");
            strings.Add("");

            sw.WriteLine(string.Join(";", strings));
        }

        void ExportTXTWriteBodyLine(StreamWriter sw, Models.AssistanceExportViewModel certificate, int i)
        {
            var strings = new List<string>();

            var reference = $"XXXXXXXXXXXXXXXXXXXXXX{certificate.Referencia}";
            var document = Utils.StringExtensions.NumbersOnly(certificate.CPFInquilino);
            var cep = Utils.StringExtensions.NumbersOnly(certificate.CEP);
            for (int c = 0; c < (8 - cep.Length); c++) cep = "0" + cep;

            strings.Add(reference.Length > 30 ? reference.Substring(0, 30) : reference);
            strings.Add(certificate.NomeInquilino);
            strings.Add(document.Length > 14 ? document.Substring(0, 14) : document);
            strings.Add(certificate.VigencyDate.ToString("yyyyMMdd"));
            strings.Add(certificate.VigencyDate.ToString("yyyyMMdd"));
            strings.Add(certificate.VigencyDate.AddYears(1).ToString("yyyyMMdd"));
            strings.Add(certificate.AssistanceReportCode);
            strings.Add("I");
            strings.Add(certificate.LocalDeRisco.Length > 150 ? certificate.LocalDeRisco.Substring(0, 150) : certificate.LocalDeRisco);
            strings.Add(certificate.Numero.Length > 5 ? certificate.Numero.Substring(0, 5) : certificate.Numero);
            strings.Add(certificate.Complemento.Length > 10 ? certificate.Complemento.Substring(0, 10) : certificate.Complemento);
            strings.Add(certificate.Bairro.Length > 50 ? certificate.Bairro.Substring(0, 50) : certificate.Bairro);
            strings.Add(certificate.Cidade.Length > 50 ? certificate.Cidade.Substring(0, 50) : certificate.Cidade);
            strings.Add(cep);
            strings.Add(certificate.UF);
            strings.Add((i - 1).ToString("000000000"));

            sw.WriteLine(string.Join(";", strings));
        }
    }
}