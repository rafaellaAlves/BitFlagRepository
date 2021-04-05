using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.BLL.Shared;
using Microsoft.Extensions.Configuration;
using VendasDbContext.Models;

namespace WEB.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.UserMedicGroupFunctions userMedicGroupFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly Insurance_HomologContext context;
        private readonly BLL.SeguradoProfissionalExtracaoFunctions seguradoProfissionalExtracaoFunctions;
        private readonly BLL.ReportFunctions reportFunctions;
        private readonly BLL.SeguradoProfissionalFunctions seguradoProfissionalFunctions;
        private readonly string retroactivityPath;

        public ReportController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager, VendasContext vendas, IConfiguration iConfiguration, BLL.SeguradoProfissionalFunctions seguradoProfissionalFunctions, BLL.UserMedicGroupFunctions userMedicGroupFunctions)
        {
            this.context = context;
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.userManager = userManager;
            this.seguradoProfissionalExtracaoFunctions = new BLL.SeguradoProfissionalExtracaoFunctions(vendas);
            this.reportFunctions = new BLL.ReportFunctions(vendas);
            this.seguradoProfissionalFunctions = seguradoProfissionalFunctions;
            this.userMedicGroupFunctions = userMedicGroupFunctions;

            retroactivityPath = Path.Combine(Directory.GetCurrentDirectory(), iConfiguration.GetValue<string>("FilePath:Retroactivity"));
        }
        public async Task<IActionResult> Index(int status)
        {
            var user = await userManager.GetUserAsync(User);

            if (User.IsInCompanyRole())
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser == null)
                    return RedirectToAction("NoCompany", "Account");
            }

            // if (certificadoGerado == 0) certificateType = (int)CertificateTypes.Emitidos;

            return View(status);
        }

        public async Task<IActionResult> ReportIndexViewComponent(int status) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.ReportIndexViewComponent), new { status }));

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int status, int? productName, int? realEstateAgencyId, int? realEstateId, string startDate, string endDate, int? motivo, int? origemId, int? situacaoId)
        {
            if (filter == null)
                filter = new DataTablesAjaxPostModel();

            var parameters = new SqlParameterList();

            if (status == (int)InsuranceStatus.Inactive && !situacaoId.HasValue)
                parameters.AddQuery("True", "(IsDeleted = @True OR Inactive = @True)", true);

            if (status == (int)InsuranceStatus.Active) parameters.AddParameter("ForaDeVigencia", false);

            if (status != (int)InsuranceStatus.Inactive)
            {
                parameters.AddParameter("CertificadoGerado", status != (int)InsuranceStatus.New);
                parameters.AddParameter("PodeRenovar", status == (int)InsuranceStatus.Renew);
                parameters.AddParameter("IsDeleted", false);
                parameters.AddParameter("Inactive", false);
            }

            if(status == (int)InsuranceStatus.New)
                parameters.AddQuery("@O", "Origem <> 'Renovado'", "");

            var user = await userManager.GetUserAsync(User);

            if (productName.HasValue)
                parameters.AddParameter("PlanoSeguroProfissionalId", productName);

            var _startDate = startDate.FromDatePtBR();
            if (_startDate.HasValue)
                parameters.AddQuery("DataCriacao", "DataCriacao >= @DataCriacao", _startDate);

            var _endDate = endDate.FromDatePtBR();
            if (_endDate.HasValue)
                parameters.AddQuery("DataCriacao1", "DataCriacao >= @DataCriacao1", new DateTime(_endDate.Value.Year, _endDate.Value.Month, _endDate.Value.Day, 23, 59, 59));

            if (origemId.HasValue)
                parameters.AddParameter("OrigemId", origemId);

            if (situacaoId.HasValue)
            {
                switch (situacaoId)
                {
                    case 1: parameters.AddQuery("FALSE", "RetroatividadeArquivoPendente = @FALSE AND CotacaoRenovacao = @FALSE", false); break;
                    case 2: parameters.AddParameter("CotacaoRenovacao", true); break;
                    case 3: parameters.AddParameter("RetroatividadeArquivoPendente", true); break;
                    case 4: parameters.AddParameter("Inactive", true); break;
                    case 5: parameters.AddParameter("IsDeleted", true); break;
                }
            }

            if (User.IsInCompanyRole())
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser == null)
                    return await Task.Run<IActionResult>(() => Json(new
                    {
                        recordsTotal = 0,
                        recordsFiltered = 0,
                        data = new List<DB.Models.Certificate>()
                    }));

                if (User.IsInRole("Corretor"))
                {
                    if (companyUser != null)
                        parameters.AddParameter("PlataformaId", companyUser.CompanyId);
                    if (realEstateId.HasValue)
                        parameters.AddParameter("EscritorioId", realEstateId);
                }
                else if (User.IsInRealEstate() && companyUser != null)
                    parameters.AddParameter("EscritorioId", companyUser.CompanyId);
            }
            else if (User.IsInRole("GrupoMedico"))
            {
                var medicGroupId = await userMedicGroupFunctions.GetMedicGroupIdByUserId(user.Id);
                parameters.AddParameter("MedicGroupId", medicGroupId);
            }

            if (!User.IsInCompanyRole())
            {
                if (realEstateAgencyId.HasValue)
                    parameters.AddParameter("PlataformaId", realEstateAgencyId);
                if (realEstateId.HasValue)
                    parameters.AddParameter("EscritorioId", realEstateId);
            }

            var d = this.seguradoProfissionalExtracaoFunctions.GetDataViewModel(this.seguradoProfissionalExtracaoFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, parameters.GetQuery(), parameters.GetParameters())).OrderByDescending(x => x.DataCriacao).ToList();

            var companies = context.Company.ToList();

            // COMISSAO PADRAO NO SISTEMA
            double comissaoPadrao = Configuration.InsuranceConfiguration.ComissaoPadrao;

            foreach (var item in d)
            {
                var plataforma = companies.SingleOrDefault(x => x.CompanyId == item.PlataformaId);
                var escritorio = companies.SingleOrDefault(x => x.CompanyId == item.EscritorioId);

                if (plataforma != null)
                {
                    item.PlataformaName = string.IsNullOrWhiteSpace(plataforma.NomeFantasia) ? string.Format("{0} {1}", plataforma.FirstName, plataforma.LastName) : plataforma.NomeFantasia;
                }
                if (escritorio != null)
                {
                    item.EscritorioName = string.IsNullOrWhiteSpace(escritorio.NomeFantasia) ? string.Format("{0} {1}", escritorio.FirstName, escritorio.LastName) : escritorio.NomeFantasia;
                }


                if (User.IsInRole("Administrator"))
                {
                    if (plataforma != null && plataforma.Comissao.HasValue)
                    {
                        if (status == (int)InsuranceStatus.New)
                        {
                            item.ComissaoAno = item.ValorTotalAnualComDesconto / 100d * (plataforma.Comissao);
                        }
                        else
                        {
                            item.ComissaoAno = item.PrecoTotal / 100d * (plataforma.Comissao);
                        }
                    }
                    else if (plataforma == null)
                    {
                        if (status == (int)InsuranceStatus.New)
                        {
                            item.ComissaoAno = item.ValorTotalAnualComDesconto / 100d * comissaoPadrao;
                        }
                        else
                        {
                            item.ComissaoAno = item.PrecoTotal / 100d * comissaoPadrao;
                        }
                    }
                    else
                    {
                        item.ComissaoAno = 0;
                    }

                }
                else if (User.IsInRole("Corretor"))
                {

                    if (plataforma != null && plataforma.Comissao.HasValue)
                    {
                        if (status == (int)InsuranceStatus.New)
                        {
                            if (escritorio != null)
                            {
                                item.ComissaoAno = item.ValorTotalAnualComDesconto / 100d * (plataforma.Comissao - escritorio.Comissao);
                            }
                            else
                            {
                                item.ComissaoAno = item.ValorTotalAnualComDesconto / 100d * (plataforma.Comissao);
                            }

                        }
                        else
                        {
                            if (escritorio != null)
                            {
                                item.ComissaoAno = item.PrecoTotal / 100d * (plataforma.Comissao - escritorio.Comissao);
                            }
                            else
                                item.ComissaoAno = item.PrecoTotal / 100d * (plataforma.Comissao);
                        }
                    }
                    else
                    {
                        item.ComissaoAno = 0;
                    }

                }
                else if (User.IsInRealEstate())
                {
                    if (escritorio != null && escritorio.Comissao.HasValue)
                    {
                        if (status == (int)InsuranceStatus.New)
                        {
                            item.ComissaoAno = item.ValorTotalAnualComDesconto / 100d * escritorio.Comissao;
                        }
                        else
                        {
                            item.ComissaoAno = item.PrecoTotal / 100d * escritorio.Comissao;
                        }
                    }
                    else
                    {
                        item.ComissaoAno = 0;
                    }

                }
            }

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveVenda")]
        public async Task<IActionResult> RemoveVenda(int id)
        {
            var user = await userManager.GetUserAsync(User);


            if (user != null && User.IsInRole("Administrator"))
            {
                reportFunctions.DeleteSeguradoProfissional(id, user.Id);
            }

            return Json(new BLL.Shared.ReturnResult(0, "Venda excluída com sucesso", false));
        }

        public async Task<IActionResult> InsertRetroactivityFile(int seguradoProfissionalId)
        {
            var validation = await ValidateRetroactivityFile();
            if (validation.HasError)
                return await Task.Run(() => Json(validation));

            await SaveRetroactivityFile(seguradoProfissionalId);

            return await Task.Run(() => Json(new ReturnResult(0, "Arquivo inserido com sucesso!", false)));

        }

        async Task<ReturnResult> ValidateRetroactivityFile()
        {
            if (HttpContext.Request.Form.Files.Count == 0)
                return await Task.Run(() => new ReturnResult(0, "Nenhum arquivo foi enviado.", true));

            if (HttpContext.Request.Form.Files[0].ContentType != "application/pdf")
                return new ReturnResult(0, "O arquivo deve ser um pdf.", true);

            return await Task.Run(() => new ReturnResult(0, null, false));
        }

        async Task<ReturnResult> SaveRetroactivityFile(int seguradoProfissionalId)
        {
            if (!Directory.Exists(retroactivityPath))
                Directory.CreateDirectory(retroactivityPath);

            var archive = Request.Form.Files[0];

            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(retroactivityPath, fileName);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                await seguradoProfissionalFunctions.UpdateRetroactivityFile(seguradoProfissionalId, filePath, fileName);

                return new ReturnResult(0, null, false);
            }
            catch { return new ReturnResult(0, "Houve um erro ao importar o arquivo.", true); }
        }
        public async Task<IActionResult> LoadInsuranceLogViewComponent(int seguradoProfissionalId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.InsuranceLog.InsuranceLogViewComponent), new { seguradoProfissionalId }));

        public async Task<IActionResult> GetOldApolice(string filePath) => await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), "application/pdf", "ApoliceAnterior.pdf"));
    }
}