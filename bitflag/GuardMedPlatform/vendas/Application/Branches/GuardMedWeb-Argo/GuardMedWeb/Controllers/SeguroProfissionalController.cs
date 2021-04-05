using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Mail;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net.Mime;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using GuardMedWeb.BLL.Utils;
using Microsoft.AspNetCore.Http;
using GuardMedWeb.Models;
using Microsoft.Extensions.Configuration;
using iText.Kernel.Pdf;
using GuardMedWeb.BLL.SeguradoProfissional;

namespace GuardMedWeb.Controllers
{
    public class SeguroProfissionalController : Controller
    {
        private readonly DAL.GuardMedWebContext _context;
        private readonly BLL.SeguradoProfissional.SeguradoProfissionalFunctions seguradoProfissionalFunctions;
        private readonly BLL.System.SystemVariableFunctions systemVariableFunctions;
        private readonly BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions seguroProfissionalPrecoFunctions;
        private readonly BLL.Pagamento.PagamentoTipoFunctions pagamentoTipoFunctions;
        private readonly BLL.SeguradoProfissional.SeguradoProfissionalViewFunctions seguradoProfissionalViewFunctions;
        private readonly BLL.SeguradoProfissional.SeguradoProfissionalExtracaoViewFunctions seguradoProfissionalExtracaoViewFunctions;
        private readonly BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions planoSeguroProfissionalFunctions;
        private readonly BLL.SeguradoClinicaVeterinaria.SeguroResponsavelTecnicoPrecoFunctions seguroResponsavelTecnicoPrecoFunctions;
        private readonly BLL.SeguradoProfissional.EspecialidadeFunctions especialidadeFunctions;
        private readonly BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions especialidadeProfissionalFunctions;
        private readonly BLL.SeguradoProfissional.EspecialidadePrecoFunctions especialidadePrecoFunctions;
        private readonly BLL.SeguradoProfissional.MedicGroupCRMFunctions medicGroupCRMFunctions;
        private readonly BLL.SeguradoProfissional.MedicGroupFunctions medicGroupFunctions;
        private readonly BLL.SeguradoProfissional.RendaProtegidaPrecoFunctions rendaProtegidaPrecoFunctions;
        private ICompositeViewEngine _viewEngine;
        private readonly string tokenIUGU;
        private readonly string IUGUID;
        private readonly MailFunctions mailFunctions;
        readonly IConfiguration configuration;

        public SeguroProfissionalController(DAL.GuardMedWebContext context, SeguradoProfissionalFunctions seguradoProfissionalFunctions, ICompositeViewEngine viewEngine, MailFunctions mailFunctions, IConfiguration configuration)
        {
            this._context = context;
            this.systemVariableFunctions = new BLL.System.SystemVariableFunctions(context);
            this.seguradoProfissionalFunctions = seguradoProfissionalFunctions;
            this.seguroProfissionalPrecoFunctions = new BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions(context);
            this.pagamentoTipoFunctions = new BLL.Pagamento.PagamentoTipoFunctions(context);
            this.seguradoProfissionalViewFunctions = new BLL.SeguradoProfissional.SeguradoProfissionalViewFunctions(context);
            this.seguradoProfissionalExtracaoViewFunctions = new BLL.SeguradoProfissional.SeguradoProfissionalExtracaoViewFunctions(context);
            this.planoSeguroProfissionalFunctions = new BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions(context);
            this.seguroResponsavelTecnicoPrecoFunctions = new BLL.SeguradoClinicaVeterinaria.SeguroResponsavelTecnicoPrecoFunctions(context);
            this.especialidadeFunctions = new BLL.SeguradoProfissional.EspecialidadeFunctions(context);
            this.especialidadeProfissionalFunctions = new BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions(context);
            this.especialidadePrecoFunctions = new BLL.SeguradoProfissional.EspecialidadePrecoFunctions(context);
            this.medicGroupCRMFunctions = new BLL.SeguradoProfissional.MedicGroupCRMFunctions(context);
            this.medicGroupFunctions = new BLL.SeguradoProfissional.MedicGroupFunctions(context);
            this.rendaProtegidaPrecoFunctions = new BLL.SeguradoProfissional.RendaProtegidaPrecoFunctions(context);
            this._viewEngine = viewEngine;
            this.tokenIUGU = systemVariableFunctions.GetSystemVariable("TokenIUGU");
            this.IUGUID = systemVariableFunctions.GetSystemVariable("IUGUID");
            this.mailFunctions = mailFunctions;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Retornar(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                ViewData["notFound"] = true;
                return await Task.Run<IActionResult>(() => { return View("Index"); });
            }

            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference))
            {
                ViewData["notFound"] = true;
                return await Task.Run<IActionResult>(() => { return View("Index"); });
            }

            Models.SeguradoProfissionalViewModel model = null;
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));
            if (seguradoProfissional == null) return NotFound();
            model = seguradoProfissional;

            if (model == null)
            {
                ViewData["notFound"] = true;
                return await Task.Run<IActionResult>(() => { return View("Index"); });
            }

            if (model.PagamentoTipoId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Impressao", new { reference = model.Referencia }); });
            if (!string.IsNullOrWhiteSpace(model.CPF))
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Pagamento", new { reference = model.Referencia }); });
            else if (model.PlanoSeguroProfissionalId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });
            else if (!string.IsNullOrWhiteSpace(model.Nome))
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });

            ViewData["notFound"] = true;
            return await Task.Run<IActionResult>(() => { return View("Index"); });
        }
        public async Task<IActionResult> VerifyIsLocked(string reference)
        {

            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if ((model.Fumante.Value || !string.IsNullOrWhiteSpace(model.Doencas) || !string.IsNullOrWhiteSpace(model.DoencasAtuais) || !string.IsNullOrWhiteSpace(model.Medicamentos)) && !model.IsLocked.HasValue)
                seguradoProfissionalFunctions.SetIsLocked(reference, true);

            return await Task.Run<IActionResult>(() => { return Json(true); });
        }
        [ActionName("LockedPage")]
        public async Task<IActionResult> LockedPage(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));
            if (seguradoProfissional == null) return NotFound();

            if (seguradoProfissional.PlanoSeguroProfissionalId.HasValue)
            {
                var grupo = await seguradoProfissionalFunctions.ObterGrupo(seguradoProfissional.SeguradoProfissionalId.Value);
                var precos = especialidadePrecoFunctions.GetDataViewModel(especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == seguradoProfissional.PlanoSeguroProfissionalId));

                seguradoProfissional.PrecoTotal = precos.PrecoMensal;

                ViewData["PrecoMensal"] = precos.PrecoMensal;
            }

            return await Task.Run<IActionResult>(() => { return View(seguradoProfissional); });
        }
        [ActionName("Unlock")]
        public async Task<IActionResult> Unlock(string reference, Guid token)
        {
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));
            if (seguradoProfissional == null) return NotFound();

            if (seguradoProfissional.LockedToken == token)
            {
                seguradoProfissionalFunctions.SetIsLocked(reference, false);

                return await Task.Run<IActionResult>(() => { return Json("Usuário desbloqueado"); });
            }
            return await Task.Run<IActionResult>(() => { return Json("Erro ao desbloquear usuário"); });
        }
        [ActionName("Lock")]
        public async Task<IActionResult> Lock(string reference, Guid token)
        {
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));
            if (seguradoProfissional == null) return NotFound();

            if (seguradoProfissional.LockedToken == token)
                seguradoProfissionalFunctions.SetIsLocked(reference, true);

            return await Task.Run<IActionResult>(() => { return Json(true); });
        }

       

        #region [SHARED]
        private IActionResult GetSeguradoProfissionalViewModel(string reference, ref Models.SeguradoProfissionalViewModel model, bool ignoreCertificate = false, Guid? token = null)
        {
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoProfissionalFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));
            if (seguradoProfissional == null) return NotFound();

            if (!ignoreCertificate)
                if (seguradoProfissional.CertificadoGerado.HasValue && seguradoProfissional.CertificadoGerado.Value)
                    return Forbid();

            if (!token.HasValue && seguradoProfissional.LockedToken != token)
                if (seguradoProfissional.IsLocked.HasValue && seguradoProfissional.IsLocked.Value)
                    return RedirectToAction("LockedPage", new { reference = reference });


            model = seguradoProfissional;
            return null;
        }
        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }

        public async Task<IActionResult> ConsultaPorDataNascimento(DateTime? dataNascimento)
        {
            if (!dataNascimento.HasValue)
                return await Task.Run<IActionResult>(() => { return Json(false); });

            var idade = new DateTime(DateTime.Now.Subtract(dataNascimento.Value).Ticks).Year - 1;

            return await Task.Run<IActionResult>(() => { return Json(seguroProfissionalPrecoFunctions.GetDataViewModel(seguroProfissionalPrecoFunctions.GetData().Where(x => idade >= x.IdadeMin && idade <= x.IdadeMax))); });
        }

        public async Task<IActionResult> Consulta(int? seguradoProfissionalId, int? discount, string medicGroupDiscount)
        {
            if (!seguradoProfissionalId.HasValue)
                return await Task.Run<IActionResult>(() => { return Json(false); });

            var grupo = await seguradoProfissionalFunctions.ObterGrupo(seguradoProfissionalId.Value);

            var precos = especialidadePrecoFunctions.GetData().Where(x => x.Grupo == grupo).ToList();
            var model = seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalId);

            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.Crm, model.EstadoCrm);

            if (discount.HasValue)
                model.DescontoPlataforma = discount;

            if (medicGroupDiscount.FromDoublePtBR().HasValue)
                model.DescontoGrupoMedico = medicGroupDiscount.FromDoublePtBR();

            if ((medicGroups == null || medicGroups.Count == 0) && !model.DescontoPlataforma.HasValue)
                return await Task.Run<IActionResult>(() => { return Json(especialidadePrecoFunctions.GetDataViewModel(precos)); });

            DAL.MedicGroup medicGroup = null;
            if (medicGroups != null && medicGroups.Count > 0)
            {
                medicGroup = medicGroups.OrderByDescending(x => x.Discount).First();
            }

            var _precos = especialidadePrecoFunctions.GetDataViewModel(precos);

            var desconto = seguradoProfissionalFunctions.ObterDesconto(model.SeguradoProfissionalId);

            return await Task.Run<IActionResult>(() =>
            {
                return Json(from y in _precos
                            select new
                            {
                                y.EspecialidadePrecoId,
                                y.Gropo,
                                y.PlanoSeguroProfissionalId,
                                y.PrecoAdmAnual,
                                y.PrecoAdmMensal,
                                y.PrecoAnual,
                                y.PrecoMensal,
                                _PrecoMensal = y.PrecoMensal.ToPtBr(),
                                _PrecoAnual = y.PrecoAnual.ToPtBr(),
                                PrecoAdmAnualDesconto = (y.PrecoAdmAnual * desconto).ToPtBr(),
                                PrecoAdmMensalDesconto = (y.PrecoAdmMensal * desconto).ToPtBr(),
                                PrecoAnualDesconto = (y.PrecoAnual * desconto).ToPtBr(),
                                PrecoMensalDesconto = (y.PrecoMensal * desconto).ToPtBr(),
                                PrecoMensalDescontoCobertura = ((y.PrecoMensal * desconto) / 100d * 10d).ToPtBr(),
                                PrecoMensalCom10 = ((y.PrecoMensal / 100d * 10d) + y.PrecoMensal).ToPtBr(),
                                PrecoMensalDescontoCom10 = ((y.PrecoMensal * desconto) + ((y.PrecoMensal * desconto) / 100d * 10d)).ToPtBr(),
                                PrecoMensalCom20 = ((y.PrecoMensal / 100d * 20d) + y.PrecoMensal).ToPtBr(),
                                PrecoMensalDescontoCom20 = ((y.PrecoMensal * desconto) + ((y.PrecoMensal * desconto) / 100d * 20d)).ToPtBr(),
                                PrecoAnualCom10 = (y.PrecoAnual + (y.PrecoAnual / 100d * 10d)).ToPtBr(),
                                PrecoAnualDescontoCom10 = ((y.PrecoAnual * desconto) + ((y.PrecoAnual * desconto) / 100d * 10d)).ToPtBr(),
                                PrecoAnualCom20 = (y.PrecoAnual + (y.PrecoAnual / 100d * 20d)).ToPtBr(),
                                PrecoAnualDescontoCom20 = ((y.PrecoAnual * desconto) + ((y.PrecoAnual * desconto) / 100d * 20d)).ToPtBr(),
                                _PrecoMensalCobertura = (y.PrecoMensal / 100d * 10d).ToPtBr(),
                                _PrecoCoberturaDesconto = ((y.PrecoMensal * desconto) / 100d * 10d).ToPtBr()
                            });
            });
        }

        public double PrecoProtecaoRenda(int idade)
        {
            return (double)rendaProtegidaPrecoFunctions.GetData().Single(x => x.IdadeMin <= idade && x.IdadeMax >= idade).PrecoMensal;
        }

        public double ObterPrecoMensalFormulario(double precoMensal, SeguradoProfissionalViewModel model)
        {
            double valorMensalCoberturaAdicional = precoMensal / 100d * 10d;

            if (model.DiretorChefeEquipe == true && model.CoberturaAdicionalDiretorChefeEquipe == true)
                precoMensal += valorMensalCoberturaAdicional;
            if (model.SocioEmpresaAreaMedica == true && model.CoberturaAdicionalSocioEmpresaAreaMedica == true)
                precoMensal += valorMensalCoberturaAdicional;

            return precoMensal;
        }
        public void ObterPrecoMensalPagamento(SeguradoProfissionalViewModel model, double especialidadePrecoMensal, out double precoMensal, out double precoTotal)
        {
            precoTotal = model.PrecoTotal.Value;
            precoMensal = especialidadePrecoMensal;

            double valorMensalCoberturaAdicional = precoMensal / 100d * 10d;
            double valorTotalCoberturaAdicional = (float)model.PrecoTotal.Value / 100f * 10f;

            if (model.DiretorChefeEquipe == true && model.CoberturaAdicionalDiretorChefeEquipe == true)
            {
                precoMensal += valorMensalCoberturaAdicional;
                precoTotal += valorTotalCoberturaAdicional;
            }
            if (model.SocioEmpresaAreaMedica == true && model.CoberturaAdicionalSocioEmpresaAreaMedica == true)
            {
                precoMensal += valorMensalCoberturaAdicional;
                precoTotal += valorTotalCoberturaAdicional;
            }
        }

        #endregion

        #region [STEP 1]
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() => { return View(); });
        }
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> _Index(Models.SeguradoProfissionalViewModel model)
        {
            if (model.DescontoPlataforma.HasValue && !model.PlataformaId.HasValue) return Forbid();

            int maxTries = 10;
            for (int i = 0; i <= maxTries; i++)
            {
                if (i == maxTries) throw new Exception("Reference max tries reached.");
                var reference = BLL.Utils.Utils.GetReference();
                if (!seguradoProfissionalFunctions.ReferenciaExiste(reference))
                {
                    model.Referencia = reference;
                    break;
                }
            }
            model.Idade = new DateTime(DateTime.Now.Subtract(model.DataNascimento.Value).Ticks).Year - 1;
            model.Conveniado = "SP" == model.EstadoCRM || "GO" == model.EstadoCRM || "PR" == model.EstadoCRM || "SE" == model.EstadoCRM;
            if (model.DescontoPlataforma.HasValue && model.DescontoPlataforma.Value > 10) model.DescontoPlataforma = 0;
            model.SeguradoProfissionalId = seguradoProfissionalFunctions.CreateOrUpdate(model);

            if (!model.DescontoPlataforma.HasValue)
            {
                seguradoProfissionalFunctions.UpdateGrupoMedico(model.SeguradoProfissionalId.Value, medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM));
            }

            return await Task.Run<IActionResult>(() => { return Json(model); });
            //return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });
        }

        [HttpPost]
        public async Task<IActionResult> SaveIndexRenew(Models.SeguradoProfissionalViewModel model)
        {
            model.Idade = new DateTime(DateTime.Now.Subtract(model.DataNascimento.Value).Ticks).Year - 1;

            await seguradoProfissionalFunctions.UpdateIndexRenew(model);

            if (!model.DescontoPlataforma.HasValue)
                seguradoProfissionalFunctions.UpdateGrupoMedico(model.SeguradoProfissionalId.Value, medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM));

            return await Task.Run<IActionResult>(() => { return Json(seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(model.SeguradoProfissionalId.Value))); });
        }
        #endregion

        #region [STEP 2]
        [HttpGet]
        [ActionName("Cotacao")]
        public async Task<IActionResult> Cotacao(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

            if (medicGroups != null && medicGroups.Count > 0)
                ViewData["MedicGroup"] = medicGroupFunctions.GetDataViewModel(medicGroups.OrderByDescending(x => x.Discount).First());

            return View(new CotacaoPageViewModel()
            {
                SeguradoProfissionalViewModel = model,
                Cotacoes = await seguradoProfissionalFunctions.ObterCotacoes(model.SeguradoProfissionalId.Value)
            });
        }
        [HttpPost]
        [ActionName("Cotacao")]
        public async Task<IActionResult> _Cotacao(string reference, int PlanoSeguroProfissionalId, bool protecaoRenda, bool DiretorChefeEquipe, bool? CoberturaAdicionalDiretorChefeEquipe, bool SocioEmpresaAreaMedica, bool? CoberturaAdicionalSocioEmpresaAreaMedica)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            model.PlanoSeguroProfissionalId = PlanoSeguroProfissionalId;
            model.ProtecaoRenda = protecaoRenda;
            seguradoProfissionalFunctions.UpdateCotacao(model);
            seguradoProfissionalFunctions.UpdateCoberturasAdicionais(model.SeguradoProfissionalId.Value, DiretorChefeEquipe, CoberturaAdicionalDiretorChefeEquipe, SocioEmpresaAreaMedica, CoberturaAdicionalSocioEmpresaAreaMedica);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });
        }
        public async Task<IActionResult> CotacaoViewComponent(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            return await Task.Run<IActionResult>(() => { return ViewComponent(typeof(ViewComponents.SeguroProfissional.CotacaoSeguroProfissionalViewComponent), new { model = model }); });
        }
        #endregion

        #region [STEP 2.2]
        //[HttpGet]
        //[ActionName("CoberturasAdicionais")]
        //public async Task<IActionResult> CoberturasAdicionais(string reference)
        //{
        //    Models.SeguradoProfissionalViewModel model = null;
        //    var r = GetSeguradoProfissionalViewModel(reference, ref model);
        //    if (r != null) return await Task.Run<IActionResult>(() => { return r; });

        //    return await Task.Run<IActionResult>(() => { return View(model); });
        //}
        //[HttpPost]
        //[ActionName("CoberturasAdicionais")]
        //public async Task<IActionResult> _CoberturasAdicionais(string reference , bool DiretorChefeEquipe , bool? CoberturaAdicionalDiretorChefeEquipe , bool SocioEmpresaAreaMedica , bool? CoberturaAdicionalSocioEmpresaAreaMedica)
        //{
        //    Models.SeguradoProfissionalViewModel model = null;
        //    var r = GetSeguradoProfissionalViewModel(reference, ref model);
        //    if (r != null) return await Task.Run<IActionResult>(() => { return r; });

        //    seguradoProfissionalFunctions.UpdateCoberturasAdicionais(model.SeguradoProfissionalId.Value, DiretorChefeEquipe , CoberturaAdicionalDiretorChefeEquipe , SocioEmpresaAreaMedica , CoberturaAdicionalSocioEmpresaAreaMedica);

        //    return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });
        //}
        #endregion

        #region [STEP 3]
        [HttpGet]
        [ActionName("Formulario")]
        public async Task<IActionResult> Formulario(string reference, Guid? token)
        {
            Models.SeguradoProfissionalViewModel model = null;
            IActionResult r;
            if (token.HasValue)
                r = GetSeguradoProfissionalViewModel(reference, ref model, false, token);
            else
                r = GetSeguradoProfissionalViewModel(reference, ref model);

            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (!model.PlanoSeguroProfissionalId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });

            return await RedirectToFormulario(model);
        }
        public async Task<IActionResult> RedirectToFormulario(SeguradoProfissionalViewModel model)
        {
            var precos = await seguradoProfissionalFunctions.ObterPreco(model.SeguradoProfissionalId.Value, model.PlanoSeguroProfissionalId.Value);
            ViewData["Precos"] = precos;

            var seguroProfissionalPreco = planoSeguroProfissionalFunctions.GetData().Where(x => x.PlanoSeguroProfissionalId == model.PlanoSeguroProfissionalId).First();
            model.PrecoTotal = precos.PrecoAnual;

            var precoMensal = precos.PrecoMensal;

            ViewData["PrecoMensal"] = precoMensal;

            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

            if (medicGroups != null && medicGroups.Count > 0)
                ViewData["MedicGroup"] = medicGroupFunctions.GetDataViewModel(medicGroups.OrderByDescending(x => x.Discount).First());

            return await Task.Run<IActionResult>(() => { return View("Formulario", model); });
        }
        [HttpPost]
        public async Task<IActionResult> SalvarEspecialidades([FromBody] List<Models.EspecialidadeProfissionalViewModel> especialidades)
        {
            especialidadeProfissionalFunctions.DeleteBySegurado(especialidades.First().SeguradoProfissionalId);

            foreach (var especialidade in especialidades)
            {
                if (!especialidade.EspecialidadeId.HasValue || !especialidade.Invasivo.HasValue) continue;

                especialidadeProfissionalFunctions.Create(new Models.EspecialidadeProfissionalViewModel
                {
                    EspecialidadeId = especialidade.EspecialidadeId,
                    Invasivo = especialidade.Invasivo,
                    SeguradoProfissionalId = especialidade.SeguradoProfissionalId
                });
                seguradoProfissionalFunctions.UpdateEspecialidades(especialidade.SeguradoProfissionalId, especialidades);

            }

            return await Task.Run<IActionResult>(() => { return Json(true); });
        }
        [HttpPost]
        [ActionName("Formulario")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> _Formulario(string reference, Models.SeguradoProfissionalViewModel model, [FromForm] IFormFile file)
        {
            Models.SeguradoProfissionalViewModel _model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref _model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (file != null)
            {
                if (file.Length > 5000000)
                {
                    return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = reference, fileError = "O tamanho do arquivo excede o tamanho máximo limite (5MB)." }); });
                }

                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RetroatividadeSegurado");

                if (!string.IsNullOrWhiteSpace(_model.RetroatividadeFileName))
                {
                    System.IO.File.Delete(Path.Combine(directory, _model.RetroatividadeFileName));
                }

                var guid = Guid.NewGuid();

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var stream = file.OpenReadStream();
                using (Stream _file = System.IO.File.Create(Path.Combine(directory, guid + System.IO.Path.GetExtension(file.FileName))))
                {
                    stream.CopyTo(_file);
                }

                model.RetroatividadeFileName = guid.ToString() + System.IO.Path.GetExtension(file.FileName);
                model.RetroatividadeFilePath = Path.Combine(directory, model.RetroatividadeFileName);
            }

            model.SeguradoProfissionalId = _model.SeguradoProfissionalId;
            seguradoProfissionalFunctions.UpdateFormulario(model);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("Pagamento", new { reference = reference }); });
        }

        private string LockedEmailMessage(Models.SeguradoProfissionalViewModel model)
        {

            return "Clique no link abaixo para visualizar a proposta: <br/>" +
               "<a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Formulario", "SeguroProfissional") + "?reference=" + model.Referencia + "&token=" + model.LockedToken + "\">Ver Proposta.</a><br/><br/>" +
                    "Clique no lnk abaixo para desbloquear a proposta: <br/>" +
               "<a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Unlock", "SeguroProfissional") + "?reference=" + model.Referencia + "&token=" + model.LockedToken + "\">Desbloquear Proposta.</a><br/><br/>";
        }

        #endregion

        #region [STEP 4]
        [HttpGet]
        [ActionName("Pagamento")]
        public async Task<IActionResult> Pagamento(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (!model.PlanoSeguroProfissionalId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });

            return await RedirectToPagamento(model);
        }

        async Task<IActionResult> RedirectToPagamento(SeguradoProfissionalViewModel model)
        {
            if (model.PlanoSeguroProfissionalId.HasValue)
            {
                var precos = await seguradoProfissionalFunctions.ObterPreco(model.SeguradoProfissionalId.Value, model.PlanoSeguroProfissionalId.Value);
                ViewData["Precos"] = precos;

                model.PrecoTotal = precos.PrecoAnual;

                ObterPrecoMensalPagamento(model, precos.PrecoMensal, out double precoMensal, out double precoTotal);

                model.PrecoTotal = precoTotal;
                ViewData["PrecoMensal"] = precoMensal;
            }

            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

            if (model.DescontoPlataforma.HasValue || (medicGroups != null && medicGroups.Count > 0))
                ViewData["Desconto"] = seguradoProfissionalFunctions.ObterNumeroDoDesconto(model.SeguradoProfissionalId.Value);

            // COBRANCA UNIFICADA
            if(model.MedicGroupRevenuesFormId.HasValue && model.MedicGroupRevenuesFormId.Value == 2)
            {
                await seguradoProfissionalFunctions.ByPassPayment(model.SeguradoProfissionalId.Value);
                return await _Pagamento(model.Referencia, 2, 12);
            }

            return await Task.Run<IActionResult>(() => { return View("Pagamento", model); });
        }

        [HttpPost]
        [ActionName("Pagamento")]
        public async Task<IActionResult> _Pagamento(string reference, int? PagamentoTipoId, int? vezesPagamento)
        {
            Models.SeguradoProfissionalViewModel seguradoProfissionalViewModel = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref seguradoProfissionalViewModel);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            #region [DESCONTO GRUPO MEDICO]
            var medicGroup = medicGroupFunctions.GetMedicGroupByInsurance(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);
            #endregion

            #region [INFORMACOES DO SEGURO RCP]
            var grupoSeguroRCP = await seguradoProfissionalFunctions.ObterGrupo(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);
            var precoSeguroRCP = especialidadePrecoFunctions.GetData(x => x.Grupo == grupoSeguroRCP && x.PlanoSeguroProfissionalId == seguradoProfissionalViewModel.PlanoSeguroProfissionalId).Single();
            #endregion

            #region [INFORMACOES DO SEGURO RENDA PROTEGIDA]
            var precoSeguroRendaProtegida = seguroProfissionalPrecoFunctions.GetDataByID(seguradoProfissionalViewModel.PlanoSeguroProfissionalId);
            #endregion

            #region [PREENCHER INFORMACOES DE PAGAMENTO DO SEGURADO]
            double desconto = seguradoProfissionalFunctions.ObterDesconto(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);
            double precoTotalComDescontoSeguroRCP = (precoSeguroRCP.PrecoAnual * desconto);
            double precoMensalComDescontoSeguroRCP = (precoSeguroRCP.PrecoMensal * desconto);

            double valorCoberturaAdicional = precoTotalComDescontoSeguroRCP / 100 * 10;
            double valorMensalCoberturaAdicional = precoMensalComDescontoSeguroRCP / 100 * 10;

            if (seguradoProfissionalViewModel.DiretorChefeEquipe == true && seguradoProfissionalViewModel.CoberturaAdicionalDiretorChefeEquipe == true)
            {
                precoTotalComDescontoSeguroRCP += valorCoberturaAdicional;
                precoMensalComDescontoSeguroRCP += valorMensalCoberturaAdicional;
            }
            if (seguradoProfissionalViewModel.SocioEmpresaAreaMedica == true && seguradoProfissionalViewModel.CoberturaAdicionalSocioEmpresaAreaMedica == true)
            {
                precoTotalComDescontoSeguroRCP += valorCoberturaAdicional;
                precoMensalComDescontoSeguroRCP += valorMensalCoberturaAdicional;
            }
            #endregion

            seguradoProfissionalFunctions.UpdatePagamento(seguradoProfissionalViewModel.SeguradoProfissionalId.Value, PagamentoTipoId.Value, PagamentoTipoId == 1 ? 1 : 12, precoTotalComDescontoSeguroRCP, precoSeguroRCP);

            if (seguradoProfissionalViewModel.EmProcessoDeRenovacao) //Renovação
                await seguradoProfissionalFunctions.FinishRenew(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);

            #region [CERTIFICADO]
            seguradoProfissionalViewModel = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalViewModel.SeguradoProfissionalId));

            seguradoProfissionalViewModel.VezesPagamento = PagamentoTipoId.Value == 1 ? 1 : 12;
            seguradoProfissionalViewModel.PrecoTotal = precoTotalComDescontoSeguroRCP;
            seguradoProfissionalViewModel.PrecoMensalDoPlano = precoMensalComDescontoSeguroRCP.ToString("#,##0.00");

            if (PagamentoTipoId.Value == 1)
            {
                seguradoProfissionalViewModel.PrecoTotalComDesconto = precoSeguroRCP.PrecoAnual * desconto;
                seguradoProfissionalViewModel.PrecoTotalMenosAdm = precoSeguroRCP.PrecoAnual - precoSeguroRCP.PrecoAdmAnual;
                seguradoProfissionalViewModel.PrecoAdm = (seguradoProfissionalViewModel.PrecoTotalComDesconto - seguradoProfissionalViewModel.PrecoTotalMenosAdm);
            }
            else
            {
                seguradoProfissionalViewModel.PrecoTotalComDesconto = precoSeguroRCP.PrecoMensal * desconto;
                seguradoProfissionalViewModel.PrecoTotalMenosAdm = precoSeguroRCP.PrecoMensal - precoSeguroRCP.PrecoAdmMensal;
                seguradoProfissionalViewModel.PrecoAdm = (seguradoProfissionalViewModel.PrecoTotalComDesconto - seguradoProfissionalViewModel.PrecoTotalMenosAdm);
            }

            var attachments = new List<System.Net.Mail.Attachment>();

            var html = await RenderPartialViewToString("Certificado", seguradoProfissionalViewModel);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);
            attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), "Certificado - Seguro Profissional.pdf", MediaTypeNames.Application.Octet));

            if (seguradoProfissionalViewModel.RenovadoPor.HasValue) //Renovação
            {
                await mailFunctions.SendAsync("Renovação GuardMed", await RenderPartialViewToString("RenewCompletedEmail", seguradoProfissionalViewModel), new List<string>() { seguradoProfissionalViewModel.Email }, attachments, true);
            }
            else //Criação de certificado
            {
                var docDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "archives", "Contrato de adesão GM.pdf");
                attachments.Add(new System.Net.Mail.Attachment(docDirectory, System.Net.Mime.MediaTypeNames.Application.Octet));

                var password = await seguradoProfissionalFunctions.GetAndGenerateNewPassword(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);

                await mailFunctions.SendAsync("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(seguradoProfissionalViewModel, password), new List<string>() { seguradoProfissionalViewModel.Email }, attachments, true);

                if (!string.IsNullOrWhiteSpace(seguradoProfissionalViewModel.RetroatividadeFileName))
                {
                    var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RetroatividadeSegurado", seguradoProfissionalViewModel.RetroatividadeFileName);
                    var attachment = new System.Net.Mail.Attachment(directory, System.Net.Mime.MediaTypeNames.Application.Octet);
                    attachment.Name = "Retroatividade" + System.IO.Path.GetExtension(seguradoProfissionalViewModel.RetroatividadeFileName);
                    attachments.Add(attachment);
                }

                mailFunctions.Send("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(seguradoProfissionalViewModel, password), new List<string>() { "contato@guardmed.com.br" }, attachments, false);
            }
            #endregion

            return await Task.Run<IActionResult>(() => { return RedirectToAction("Impressao", new { reference = reference }); });
        }

        [HttpPost]
        [ActionName("PagamentoFromClinica")]
        public async Task<IActionResult> _Pagamento(List<string> references)
        {
            foreach (var reference in references)
            {
                Models.SeguradoProfissionalViewModel model = null;
                var r = GetSeguradoProfissionalViewModel(reference, ref model);
                if (r != null) return await Task.Run<IActionResult>(() => { return r; });

                //Informações do segurado

                var grupo = await seguradoProfissionalFunctions.ObterGrupo(model.SeguradoProfissionalId.Value);
                var especialidadePreco = especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == model.PlanoSeguroProfissionalId);
                var especialidadePrecoViewModel = especialidadePrecoFunctions.GetDataViewModel(especialidadePreco);

                seguradoProfissionalFunctions.UpdatePagamento(model.SeguradoProfissionalId.Value, 1, 12, especialidadePrecoViewModel.PrecoAnual, especialidadePreco);
                var password = await seguradoProfissionalFunctions.GetAndGenerateNewPassword(model.SeguradoProfissionalId.Value);

                var _model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(model.SeguradoProfissionalId));
                _model.PagamentoTipoId = 1;

                var tiposPagamento = pagamentoTipoFunctions.GetData();

                _model.PrecoMensalDoPlano = especialidadePrecoViewModel._PrecoMensal;
                _model.PrecoTotal = especialidadePrecoViewModel.PrecoAnual;

                //SendMail(model.Referencia, model.SeguradoProfissionalId);

                var attachments = new List<System.Net.Mail.Attachment>();

                var html = await RenderPartialViewToString("Certificado", _model);
                var stream = new MemoryStream();
                iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);
                attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), "Certificado - Seguro Profissional.pdf", MediaTypeNames.Application.Octet));

                var docDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "archives", "Contrato de adesão GM.pdf");
                attachments.Add(new System.Net.Mail.Attachment(docDirectory, System.Net.Mime.MediaTypeNames.Application.Octet));

                await mailFunctions.SendAsync("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(_model, password), new List<string>() { _model.Email }, attachments, false);

                if (!string.IsNullOrWhiteSpace(model.RetroatividadeFileName))
                {
                    var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RetroatividadeSegurado", model.RetroatividadeFileName);
                    attachments.Add(new System.Net.Mail.Attachment(docDirectory, System.Net.Mime.MediaTypeNames.Application.Octet));
                }

                await mailFunctions.SendAsync("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(_model, password), new List<string>() { "contato@guardmed.com.br" }, attachments, false);
            }
            return await Task.Run<IActionResult>(() => { return Json(true); });
        }
        #region [STEP 6]

        public async Task<IActionResult> ApoliceArgo(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model, true);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

           
            


            return await Task.Run<IActionResult>(() => { return View(model); });
        }
        #endregion
        #region [CARTAO DE CREDITO]
        public async Task<IActionResult> TokenCartaoDeCredito(string reference, string numero, string nome, string mes, string ano, string cvv)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.CertificadoGerado == true) return Forbid();

            var first_name = nome.Split(' ')[0];
            var last_name = nome.Replace(first_name + " ", string.Empty);

            var iugu = new BLL.IUGU.IUGU(this.tokenIUGU, this.IUGUID, configuration);
            var token = await iugu.PaymentToken(numero, first_name, last_name, mes, ano, cvv);

            return await Task.Run<IActionResult>(() => { return Json(token); });
        }

        public async Task<IActionResult> PagamentoCartaoDeCredito(string reference, string token)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.CertificadoGerado == true) return Forbid();

            var seguradoProfissionalId = seguradoProfissionalFunctions.GetByReference(reference);
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalId);

            var grupo = await seguradoProfissionalFunctions.ObterGrupo(seguradoProfissional.SeguradoProfissionalId);
            var precos = especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == seguradoProfissional.PlanoSeguroProfissionalId);
            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(seguradoProfissional.Crm, seguradoProfissional.EstadoCrm);

            DAL.MedicGroup medicGroup = null;

            if (medicGroups != null && medicGroups.Count > 0)
                medicGroup = medicGroups.OrderByDescending(x => x.Discount).First();

            var _desconto = seguradoProfissionalFunctions.ObterNumeroDoDesconto(seguradoProfissional.SeguradoProfissionalId);
            double desconto = _desconto.HasValue ? precos.PrecoMensal * (_desconto.Value / 100d) : 0d;

            double protecaoRenda = model.ProtecaoRenda.Value ? PrecoProtecaoRenda(model.Idade.Value) : 0;
            double precoTotal = precos.PrecoMensal - desconto;

            double? coberturaAdicionalDiretorChefeEquipe = null;
            if (model.CoberturaAdicionalDiretorChefeEquipe.HasValue && model.CoberturaAdicionalDiretorChefeEquipe.Value)
                coberturaAdicionalDiretorChefeEquipe = precoTotal * (10d / 100d);

            double? coberturaAdicionalSocioEmpresaAreaMedica = null;
            if (model.CoberturaAdicionalSocioEmpresaAreaMedica.HasValue && model.CoberturaAdicionalSocioEmpresaAreaMedica.Value)
                coberturaAdicionalSocioEmpresaAreaMedica = precoTotal * (10d / 100d);

            if (!string.IsNullOrWhiteSpace(token)) seguradoProfissional.IuguToken = token;

            // STEP0 - Custom API IUGU
            var iugu = new BLL.IUGU.IUGU(this.tokenIUGU, this.IUGUID, configuration);

            if (string.IsNullOrWhiteSpace(seguradoProfissional.IuguCustomerId))
            {
                #region [STEP1 - CRIAR USUARIO]
                BLL.IUGU.IUGU.ResponseData iuguUser;
                try
                {
                    iuguUser = await iugu.AddCustomer(model);
                    if (iuguUser.Status != System.Net.HttpStatusCode.OK)
                        return Json(new { HasError = true, Message = "CC001" });
                }
                catch
                {
                    return Json(new { HasError = true, Message = "CC002" });
                }
                seguradoProfissional.IuguCustomerId = (iuguUser.Data["id"] as string);
            }
            #endregion

            if (string.IsNullOrWhiteSpace(seguradoProfissional.IuguCustomerPaymentMethodId) || seguradoProfissional.RenovacaoPagamentoBloqueado)
            {
                #region [STEP2 - CRIAR FORMA DE PAGAMENTO PARA USUARIO]
                BLL.IUGU.IUGU.ResponseData iuguCustomerDefaultPaymentMethod;
                try
                {
                    iuguCustomerDefaultPaymentMethod = await iugu.AddCustomerPaymentMethod(seguradoProfissional.IuguCustomerId, "Cartão de Crédito - Padrão", seguradoProfissional.IuguToken, true);
                    if (iuguCustomerDefaultPaymentMethod.Status != System.Net.HttpStatusCode.OK)
                    {
                        if (!seguradoProfissional.EmProcessoDeRenovacao)
                            await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                        return Json(new { HasError = true, Message = "CC003" });
                    }

                }
                catch
                {
                    if (!seguradoProfissional.EmProcessoDeRenovacao)
                        await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                    return Json(new { HasError = true, Message = "CC004" });
                }
                seguradoProfissional.IuguCustomerPaymentMethodId = (iuguCustomerDefaultPaymentMethod.Data["id"] as string);
                #endregion
            }

            #region [STEP3 - ASSOCIAR USUARIO AO PLANO]
            BLL.IUGU.IUGU.ResponseData iuguSubscription;
            try
            {
                DateTime? expires_at = null; //Se houver uma assinatura antiga, a data de vencimento do mês será utilizada na nova assinatura

                if (seguradoProfissional.RenovadoPor.HasValue && await seguradoProfissionalFunctions.HasSubscription(seguradoProfissional.RenovadoPor.Value)) //Suspende a assinatura anterior do segurado
                {
                    var oldSubscription = await iugu.GetSubscriptionById(await seguradoProfissionalFunctions.GetSubscription(seguradoProfissional.RenovadoPor.Value));

                    if (oldSubscription.Status == System.Net.HttpStatusCode.OK)
                    {
                        expires_at = oldSubscription.Data["expires_at"]?.ToString().FromDatePtBR();
                        if (expires_at.HasValue) expires_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, expires_at.Value.Day);
                    }
                }

                iuguSubscription = await iugu.AddSubscription(precos.CodIugu.Trim(), seguradoProfissional.IuguCustomerId, "credit_card", desconto, model.DescontoPlataforma.HasValue ? $"Desconto" : (medicGroup != null ? $"Desconto do grupo médico '{medicGroup.MedicGroupName}'." : ""), protecaoRenda, coberturaAdicionalDiretorChefeEquipe, coberturaAdicionalSocioEmpresaAreaMedica, expires_at);
                if (iuguSubscription.Status != System.Net.HttpStatusCode.OK)
                {
                    if (seguradoProfissional.RenovacaoPagamentoBloqueado)
                        await iugu.RemoveCustomerPaymentMethod(seguradoProfissional.IuguCustomerId, seguradoProfissional.IuguCustomerPaymentMethodId);

                    if (!seguradoProfissional.EmProcessoDeRenovacao)
                        await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                    return Json(new { HasError = true, Message = "CC005" });
                }
            }
            catch
            {
                if (seguradoProfissional.RenovacaoPagamentoBloqueado)
                    await iugu.RemoveCustomerPaymentMethod(seguradoProfissional.IuguCustomerId, seguradoProfissional.IuguCustomerPaymentMethodId);

                if (!seguradoProfissional.EmProcessoDeRenovacao)
                    await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                return Json(new { HasError = true, Message = "CC006" });
            }

            seguradoProfissional.IuguSubscriptionId = (iuguSubscription.Data["id"] as string);
            #endregion


            if (seguradoProfissional.RenovadoPor.HasValue && await seguradoProfissionalFunctions.HasSubscription(seguradoProfissional.RenovadoPor.Value)) //Suspende a assinatura anterior do segurado
                await iugu.SuspendSubscription(await seguradoProfissionalFunctions.GetSubscription(seguradoProfissional.RenovadoPor.Value));

            try
            {
                this._context.SaveChanges();
            }
            catch
            {
                return Json(new { HasError = true, Message = "CC007" });
            }

            return await Task.Run<IActionResult>(() => { return Json(new { HasError = false, Message = "OK" }); });
        }
        #endregion

        #region [BOLETO BANCARIO]
        public async Task<IActionResult> PagamentoBoletoBancario(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.CertificadoGerado == true) return Forbid();

            var seguradoProfissionalId = seguradoProfissionalFunctions.GetByReference(reference);
            var seguradoProfissional = seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalId);

            // STEP0 - Custom API IUGU
            var iugu = new BLL.IUGU.IUGU(this.tokenIUGU, this.IUGUID, configuration);


            if (string.IsNullOrWhiteSpace(seguradoProfissional.IuguCustomerId))
            {
                #region [STEP1 - CRIAR USUARIO]
                BLL.IUGU.IUGU.ResponseData iuguUser;
                try
                {
                    iuguUser = await iugu.AddCustomer(model);
                    if (iuguUser.Status != System.Net.HttpStatusCode.OK)
                        return Json(new { HasError = true, Message = "BS001" });
                }
                catch
                {
                    return Json(new { HasError = true, Message = "BS002" });
                }
                seguradoProfissional.IuguCustomerId = (iuguUser.Data["id"] as string);
                #endregion
            }

            #region [STEP2 - CRIAR COBRANCA DIRETA]

            var grupo = await seguradoProfissionalFunctions.ObterGrupo(seguradoProfissional.SeguradoProfissionalId);
            var precos = especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == seguradoProfissional.PlanoSeguroProfissionalId);
            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

            DAL.MedicGroup medicGroup = null;

            if (medicGroups != null && medicGroups.Count > 0)
                medicGroup = medicGroups.OrderByDescending(x => x.Discount).First();


            var _desconto = seguradoProfissionalFunctions.ObterNumeroDoDesconto(seguradoProfissional.SeguradoProfissionalId);
            double desconto = _desconto.HasValue ? precos.PrecoAnual * (_desconto.Value / 100d) : 0d;

            double protecaoRenda = model.ProtecaoRenda.Value ? (double)PrecoProtecaoRenda(model.Idade.Value) * 12d : 0;
            var plano = planoSeguroProfissionalFunctions.GetDataByID(model.PlanoSeguroProfissionalId);

            //double preco = double.Parse(precos.PrecoAnual) * (medicGroup != null ? (100 - medicGroup.Discount) / 100 : 1);
            //preco = double.Parse((preco + (model.ProtecaoRenda.Value ? PrecoProtecaoRenda(model.Idade.Value) * 12 : 0)).ToString("0.00"));

            var price_cents = Convert.ToInt32(Math.Round((precos.PrecoAnual), 2) * 100d);
            var return_url = Url.Action("Impressao", "SeguroProfissional", new { reference = model.Referencia }, Request.Scheme);
            BLL.IUGU.IUGU.ResponseData iuguInvoice;
            try
            {
                iuguInvoice = await iugu.AddInvoice(model, plano.Nome + " (" + precos.CodIugu + ")", price_cents, return_url, desconto, model.DescontoPlataforma.HasValue ? $"Desconto" : (medicGroup != null ? $"Desconto do grupo médico '{medicGroup.MedicGroupName}'." : ""), protecaoRenda);
                if (iuguInvoice.Status != System.Net.HttpStatusCode.OK)
                {
                    if (!seguradoProfissional.EmProcessoDeRenovacao)
                        await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                    return Json(new { HasError = true, Message = "BS003" });
                }

            }
            catch
            {
                if (!seguradoProfissional.EmProcessoDeRenovacao)
                    await iugu.RemoveCustomer(seguradoProfissional.IuguCustomerId);

                return Json(new { HasError = true, Message = "BS004" });
            }
            seguradoProfissional.IuguInvoiceId = (iuguInvoice.Data["id"] as string);
            seguradoProfissional.IuguInvoiceSecureUrl = (iuguInvoice.Data["secure_url"] as string);
            #endregion

            if (seguradoProfissional.RenovadoPor.HasValue && await seguradoProfissionalFunctions.HasSubscription(seguradoProfissional.RenovadoPor.Value)) //Suspende a assinatura anterior do segurado
                await iugu.SuspendSubscription(await seguradoProfissionalFunctions.GetSubscription(seguradoProfissional.RenovadoPor.Value));

            try
            {
                this._context.SaveChanges();
            }
            catch
            {
                return Json(new { HasError = true, Message = "BS005" });
            }

            return await Task.Run<IActionResult>(() => { return Json(new { HasError = false, Message = "OK" }); });
        }
        #endregion

        private string PagamentoEmailMessage(Models.SeguradoProfissionalViewModel model, string password)
        {
            return "Olá Dr. (a) <strong>" + model.Nome + "</strong>,<br/><br/>" +
                    "Agradecemos a confiança.<br/><br/>" +
                    "Agora você faz parte de um grupo seleto de médicos que confiaram a proteção da sua atividade à GuardMed.<br/><br/>" +
                    "Confira no arquivo anexo o seu Certificado Individual de Proteção.<br/><br/><br/>" +

                    "Acesse sua área de cliente e verifique as funcionalidades e benefícios junto a parceiros,<br/><br/>" +
                    "Lá você também tem toda sua documentação arquivada para consulta e download a qualquer tempo.<br/><br/><br/>" +

                    "A GuardMed oferece Produtos e Serviços exclusivos para a área da Medicina, trazendo mais tranquilidade e segurança no exercício da profissão.<br/><br/><br/>" +

                    "GuardMed<br/>" +
                    "“Inovando e protegendo”<br/><br/>" +

                    "<div align='center'><strong><u>ORIENTAÇÕES GERAIS GUARDMED</u></strong></div><br/>" +
                    "<div align='center'><label>Não se preocupe. Em caso de Notificação Judicial, Extrajudicial, ou Notificação do Conselho Regional de Medicina, entre imediatamente em contato com a GuardMed.</label></div><br/><br/>" +
                    "<div align='center'><strong><u>ÁREA EXCLUSIVA DO CLIENTE GUARDMED</u></strong></div><br/>" +
                    "<div align='center' style='text-align: center;'>" +
                    $"<div>Para acessar clique no link: <a href=\"{GuardMedWeb.Configuration.InsuranceConfiguration.ClientWebsite}\">{GuardMedWeb.Configuration.InsuranceConfiguration.ClientWebsite}</a></div>" +
                    $"<div>Utilize seu e-mail: <b>{model.Email}</b></div>" +
                    $"<div>Utilize a senha: <b>{password}</b></div>" +
                    "</div><br/><br/>" +
                    "<div align='center'><strong><u>CONTATO GUARDMED</u></strong></div><br/>" +
                    "<div align='center'><label><strong>São Paulo</strong> - Rua Manuel da Nóbrega, 354 – 8º andar – Paraíso - Fone.: 11 3253-2284</label></div><br/>" +
                    "<div align='center'><label><a href='mailto:contato@guardmed.com.br'>contato@guardmed.com.br</a></label></div>";
        }

        private string PagamentoEmailMessageMais40(Models.SeguradoProfissionalViewModel model, string password)
        {
            return "Olá Dr. (a) <strong>" + model.Nome + "</strong>,<br/><br/>" +
                    "Agradecemos a confiança.<br/><br/>" +
                    "Agora você faz parte de um grupo seleto de médicos que confiaram a gestão da sua apólice de Seguro na maior empresa deste segmento.<br/><br/>" +
                    "Confira no arquivo anexo o seu Certificado Individual de Seguro.<br/><br/>" +
                    "A <strong>GuardMed</strong> está presente nos principais <strong>CRM’s</strong> do país com Produtos e Serviços exclusivos para a área da Medicina, trazendo mais tranquilidade e segurança no exercício da profissão.<br/><br/><br/>" +
                    "<div align='center'><strong><u>ORIENTAÇÕES GERAIS GUARDMED</u></strong></div><br/>" +
                    "<div align='center'><label>Em caso de Notificação Judicial, Extrajudicial, ou Notificação do Conselho Regional de Medicina, o segurado deverá entrar em contato com a GuardMed que fará as orientações jurídicas para cada caso.</label></div><br/><br/><br/>" +
                    "<div align='center'><strong><u>NECESSÁRIO PARA OS CASOS ACIMA DE 40 ANOS</u></strong></div><br/>" +
                    "<div align='center'><label>Para todas as contratações com idade igual ou acima de 40 anos nos Planos Profissional I, II e III, conforme exigência da parceira PAN Seguros S/A, é necessário o envio da Proposta com a DPS (Declaração Pessoal de Saúde) preenchido e assinado. Esse documento será exigido na abertura de um eventual sinistro. Para baixar o documento acesse o link <a href='www.amaisvet.com.br/pandps'>www.amaisvet.com.br/pandps</a>. Por favor, enviar scaneado para <a href='mailto:contato@guardmed.com.br'>contato@guardmed.com.br</a> ou pelo whatsapp 19 9 5321-0138.</label></div><br/><br/>" +
                    "<div align='center'><strong><u>ÁREA EXCLUSIVA DO CLIENTE GUARDMED</u></strong></div><br/>" +
                    "<div align='center' style='text-align: center;'>" +
                    "<div>Para acessar clique no link: <a href=\"https://vendas.guardmed.com.br/cliente\">https://vendas.guardmed.com.br/cliente</a></div>" +
                    $"<div>Utilize seu e-mail: <b>{model.Email}</b></div>" +
                    $"<div>Utilize a senha: <b>{password}</b></div>" +
                    "</div><br/><br/>" +
                    "<div align='center'><strong><u>CONTATO GUARDMED</u></strong></div><br/>" +
                    "<div align='center'><label><strong>São Paulo</strong> - Rua Manoel da Nobrega, 354 – 8º andar – Paraiso - Fone.: 11 3253-2284 |  <strong>Campinas</strong> - Rua Dr Osvaldo Cruz, 505 – Taquaral - Fone: 19 3291-1241</label></div><br/>" +
                    "<div align='center'><label><a href='mailto:contato@guardmed.com.br'>contato@guardmed.com.br</a></label></div>";
        }
        #endregion

        #region [STEP 5]
        public async Task<IActionResult> Impressao(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model, true);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.PlanoSeguroProfissionalId.HasValue)
            {
                var tiposPagamento = pagamentoTipoFunctions.GetData();
                var grupo = await seguradoProfissionalFunctions.ObterGrupo(model.SeguradoProfissionalId.Value);
                var precos = especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == model.PlanoSeguroProfissionalId);

                var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

                DAL.MedicGroup medicGroup = null;

                if (medicGroups != null && medicGroups.Count > 0)
                    medicGroup = medicGroups.OrderByDescending(x => x.Discount).First();

                double desconto = seguradoProfissionalFunctions.ObterDesconto(model.SeguradoProfissionalId.Value);

                model.PrecoMensalDoPlano = (precos.PrecoMensal * desconto).ToString("#,##0.00");

                if (model.PagamentoTipoId == tiposPagamento.First(x => x.ExternalCode == "CARTAO").PagamentoTipoId)
                {
                    model.PrecoTotalComDesconto = precos.PrecoMensal * desconto;
                    model.PrecoTotalMenosAdm = precos.PrecoMensal - precos.PrecoAdmMensal;
                    model.PrecoAdm = (model.PrecoTotalComDesconto - model.PrecoTotalMenosAdm);
                }
                else
                {
                    model.PrecoTotalComDesconto = precos.PrecoAnual * desconto;
                    model.PrecoTotalMenosAdm = precos.PrecoAnual - precos.PrecoAdmAnual;
                    model.PrecoAdm = (model.PrecoTotalComDesconto - model.PrecoTotalMenosAdm);
                }
            }


            return await Task.Run<IActionResult>(() => { return View(model); });
        }
        #endregion

       

        #region [CERTIFICADO]
        public async Task<IActionResult> Certificado(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model, true);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.PlanoSeguroProfissionalId.HasValue)
            {
                var tiposPagamento = pagamentoTipoFunctions.GetData();
                var grupo = await seguradoProfissionalFunctions.ObterGrupo(model.SeguradoProfissionalId.Value);
                var precos = especialidadePrecoFunctions.GetData().Single(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == model.PlanoSeguroProfissionalId);

                var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

                DAL.MedicGroup medicGroup = null;

                if (medicGroups != null && medicGroups.Count > 0)
                    medicGroup = medicGroups.OrderByDescending(x => x.Discount).First();

                double desconto = seguradoProfissionalFunctions.ObterDesconto(model.SeguradoProfissionalId.Value);

                model.PrecoMensalDoPlano = (precos.PrecoMensal * desconto).ToString("#,##0.00");

                if (model.PagamentoTipoId == tiposPagamento.First(x => x.ExternalCode == "CARTAO").PagamentoTipoId)
                {
                    model.PrecoTotalComDesconto = precos.PrecoMensal * desconto;
                    model.PrecoTotalMenosAdm = precos.PrecoMensal - precos.PrecoAdmMensal;
                    model.PrecoAdm = (model.PrecoTotalComDesconto - model.PrecoTotalMenosAdm);
                }
                else
                {
                    model.PrecoTotalComDesconto = precos.PrecoAnual * desconto;
                    model.PrecoTotalMenosAdm = precos.PrecoAnual - precos.PrecoAdmAnual;
                    model.PrecoAdm = (model.PrecoTotalComDesconto - model.PrecoTotalMenosAdm);
                }
            }

            return await Task.Run<IActionResult>(() => { return View(model); });
        }
        #endregion

        #region [View]

        [ActionName("View")]
        public async Task<IActionResult> _View(string reference)
        {
            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model, true);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (model.PagamentoTipoId.HasValue)
                ViewData["StopedStep"] = "Impressão";
            else if (!string.IsNullOrWhiteSpace(model.CPF))
                ViewData["StopedStep"] = "Pagamento";
            else if (model.PlanoSeguroProfissionalId.HasValue)
                ViewData["StopedStep"] = "Formulário";
            else if (!string.IsNullOrWhiteSpace(model.Nome))
                ViewData["StopedStep"] = "Cotação";

            if (model.PlanoSeguroProfissionalId.HasValue)
            {
                var seguroProfissionalPreco = planoSeguroProfissionalFunctions.GetData().Where(x => x.PlanoSeguroProfissionalId == model.PlanoSeguroProfissionalId).First();
                model.PrecoMensalDoPlano = seguroProfissionalPreco.PrecoMensal.ToString("0.00");
            }

            return View(model);
        }

        #endregion

        #region [RENEW]
        public async Task<IActionResult> Renew(int seguradoProfissionalId, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            var segurado = await seguradoProfissionalFunctions.GetDataByRenewedBy(seguradoProfissionalId);

            if (segurado != null && segurado.DataCompra.HasValue)//Já foi totalmente renovado
                return await Task.Run(() => Forbid());

            if (segurado == null)
                segurado = await seguradoProfissionalFunctions.CreateForRenew(seguradoProfissionalId);

            segurado.GrupoMedico = seguradoProfissionalFunctions.UpdateGrupoMedico(segurado.SeguradoProfissionalId, medicGroupFunctions.GetMedicGroupsByCRM(segurado.Crm, segurado.EstadoCrm));

            var model = seguradoProfissionalFunctions.GetDataViewModel(segurado);

            model.PodeRenovar = await seguradoProfissionalFunctions.CanRenew(seguradoProfissionalId);

            return await Task.Run(() => View("Index", model));
        }

        public async Task<IActionResult> QuoteRenew(string reference, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            var model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));

            model.PodeRenovar = await seguradoProfissionalFunctions.CanRenew(model.RenovadoPor.Value);

            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(model.CRM, model.EstadoCRM);

            if (medicGroups != null && medicGroups.Count > 0)
                ViewData["MedicGroup"] = medicGroupFunctions.GetDataViewModel(medicGroups.OrderByDescending(x => x.Discount).First());

            return await Task.Run(() => View("Cotacao", model));
        }

        [HttpPost]
        public async Task<IActionResult> SaveRenewDiscount(string reference, int? discount, string medicGroupDiscount, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Json(new { message = "Você não possuí permissão para esta ação." }));

            await seguradoProfissionalFunctions.UpdateDiscount(seguradoProfissionalFunctions.GetByReference(reference), discount);
            await seguradoProfissionalFunctions.UpdateMedicGroupDiscount(seguradoProfissionalFunctions.GetByReference(reference), medicGroupDiscount.FromDoublePtBR());

            return await Task.Run(() => Json(new { message = "Cotação salva com sucesso!" }));
        }

        [HttpPost]
        public async Task<IActionResult> QuoteRenew(string reference, int PlanoSeguroProfissionalId, bool protecaoRenda, bool DiretorChefeEquipe, bool? CoberturaAdicionalDiretorChefeEquipe, bool SocioEmpresaAreaMedica, bool? CoberturaAdicionalSocioEmpresaAreaMedica, int? discount, string medicGroupDiscount, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            Models.SeguradoProfissionalViewModel model = null;
            var r = GetSeguradoProfissionalViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            model.PlanoSeguroProfissionalId = PlanoSeguroProfissionalId;
            model.ProtecaoRenda = protecaoRenda;
            seguradoProfissionalFunctions.UpdateCotacao(model);
            await seguradoProfissionalFunctions.UpdateDiscount(model.SeguradoProfissionalId.Value, discount);
            await seguradoProfissionalFunctions.UpdateMedicGroupDiscount(model.SeguradoProfissionalId.Value, medicGroupDiscount.FromDoublePtBR());
            seguradoProfissionalFunctions.UpdateCoberturasAdicionais(model.SeguradoProfissionalId.Value, DiretorChefeEquipe, CoberturaAdicionalDiretorChefeEquipe, SocioEmpresaAreaMedica, CoberturaAdicionalSocioEmpresaAreaMedica);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("DetailRenew", new { reference = model.Referencia, renewToken }); });
        }

        public async Task<IActionResult> DetailRenew(string reference, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            var model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));

            model.PodeRenovar = await seguradoProfissionalFunctions.CanRenew(model.RenovadoPor.Value);

            return await RedirectToFormulario(model);
        }

        [HttpPost]
        public async Task<IActionResult> DetailRenew(string reference, Models.SeguradoProfissionalViewModel model, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            model.SeguradoProfissionalId = seguradoProfissionalFunctions.GetByReference(reference);

            seguradoProfissionalFunctions.UpdateDetailRenew(model);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("PaymentRenew", new { reference, renewToken }); });
        }

        public async Task<IActionResult> PaymentRenew(string reference, string renewToken)
        {
            if (renewToken != systemVariableFunctions.GetSystemVariable("RenewToken"))
                return await Task.Run(() => Forbid());

            var model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));

            model.PodeRenovar = await seguradoProfissionalFunctions.CanRenew(model.RenovadoPor.Value);

            return await RedirectToPagamento(model);
        }

        public async Task<IActionResult> RenewPaymentClient(string reference)
        {
            var model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalFunctions.GetByReference(reference)));

            if (!model.EmProcessoDeRenovacao)
                return await Task.Run(() => Forbid());

            return await RedirectToPagamento(model);
        }

        public async Task<IActionResult> SendCreditCardEmail(string reference)
        {
            try
            {
                var seguradoProfissionalId = seguradoProfissionalFunctions.GetByReference(reference);

                await seguradoProfissionalFunctions.BlockPayment(seguradoProfissionalId);

                var model = seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalId));

                var html = await RenderPartialViewToString("RenewPaymentEmail", model);

                await mailFunctions.SendAsync("Atualização de dados GuardMed", html, new List<string>() { model.Email }, null);

                return await Task.Run(() => Json(new BLL.Shared.ReturnResult(0, "E-mail enviado com sucesso!", false)));
            }
            catch
            {
                return await Task.Run(() => Json(new BLL.Shared.ReturnResult(0, "Houve um erro ao enviar o e-mail", true)));
            }
        }

        //public async Task<IActionResult> RenewPaymentEmail(int seguradoProfissionalId) => await Task.Run(() => View(seguradoProfissionalFunctions.GetDataViewModel(seguradoProfissionalFunctions.GetDataByID(seguradoProfissionalId))));
        #endregion

        public IActionResult Exportar(string token)
        {
            var tokenExportar = systemVariableFunctions.GetSystemVariable("TokenExportar");
            if (tokenExportar != token)
                return Forbid();

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#2e5071");
            Color colFromHex2 = ColorTranslator.FromHtml("#E8EEF8");

            var byteArray = System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Templates", "Modelo.xlsx"));
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, (int)byteArray.Length);
                memoryStream.Position = 0;
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    // DADOS COMPARTILHADOS ENTRE AS DUAS PLANILHAS
                    var segurados = seguradoProfissionalExtracaoViewFunctions.GetData().OrderByDescending(x => x.DataCriacao);

                    // EXPORTACAO DA PLANILHA 1
                    var worksheet1 = excelPackage.Workbook.Worksheets[0];

                    worksheet1.Cells[1, 1, 1, 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[1, 1, 1, 30].Style.Fill.BackgroundColor.SetColor(colFromHex);

                    int c = 1;

                    worksheet1.Cells[1, c++].Value = "Referência";
                    worksheet1.Cells[1, c++].Value = "Data de Adesão";
                    worksheet1.Cells[1, c++].Value = "Plataforma";
                    worksheet1.Cells[1, c++].Value = "Escritório";
                    worksheet1.Cells[1, c++].Value = "Grupo Medico";
                    worksheet1.Cells[1, c++].Value = "Nome";
                    worksheet1.Cells[1, c++].Value = "CPF";
                    worksheet1.Cells[1, c++].Value = "Data de Nascimento";
                    worksheet1.Cells[1, c++].Value = "Email";
                    worksheet1.Cells[1, c++].Value = "Endereço";
                    worksheet1.Cells[1, c++].Value = "Telefone";
                    worksheet1.Cells[1, c++].Value = "Celular";
                    worksheet1.Cells[1, c++].Value = "CRM";
                    worksheet1.Cells[1, c++].Value = "Estado CRM";
                    worksheet1.Cells[1, c++].Value = "Especialidade 1";
                    worksheet1.Cells[1, c++].Value = "Especialidade 2";
                    worksheet1.Cells[1, c++].Value = "Especialidade 3";
                    worksheet1.Cells[1, c++].Value = "Nome Plano";
                    worksheet1.Cells[1, c++].Value = "Tipo de Pagamento";
                    worksheet1.Cells[1, c++].Value = "Vezes do Pagamento";
                    worksheet1.Cells[1, c++].Value = "Desconto(%)";
                    worksheet1.Cells[1, c++].Value = "Adicional ChefeEquipe 10%";
                    worksheet1.Cells[1, c++].Value = "Adicional SocioEmpresa 10%";
                    // worksheet1.Cells[1, 20].Value = "Preço Anual C/ Desconto";
                    worksheet1.Cells[1, c++].Value = "Custo Adesão Anual";
                    // worksheet1.Cells[1, 23].Value = "Preço Mensal C/ Desconto";
                    worksheet1.Cells[1, c++].Value = "Custo Adesão Mensal";
                    worksheet1.Cells[1, c++].Value = "Valor Adm Anual";
                    worksheet1.Cells[1, c++].Value = "Valor Adm Mensal";
                    worksheet1.Cells[1, c++].Value = "Prêmio do Seguro Anual";
                    worksheet1.Cells[1, c++].Value = "Prêmio do Seguro Mensal";
                    worksheet1.Cells[1, c++].Value = "Retroatividade";

                    int i = 2;
                    foreach (var segurado in segurados.Where(x => x.CertificadoGerado && !x.IsDeleted))
                    {
                        c = 1;

                        if (i % 2 == 0)
                        {
                            worksheet1.Cells[i, 1, i, 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet1.Cells[i, 1, i, 30].Style.Fill.BackgroundColor.SetColor(colFromHex2);
                        }

                        worksheet1.Cells[i, c].Hyperlink = new Uri(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Retornar", "SeguroProfissional") + "?reference=" + segurado.Referencia);
                        worksheet1.Cells[i, c++].Value = segurado.Referencia;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                        worksheet1.Cells[i, c++].Value = segurado.DataCompra.HasValue ? segurado.DataCompra : null;
                        if (segurado.EscritorioId.Equals(null) && segurado.PlataformaId.Equals(null))
                        {
                            worksheet1.Cells[i, c++].Value = "-";
                            worksheet1.Cells[i, c++].Value = "-";
                        }
                        else if (string.IsNullOrEmpty(segurado.PlataformaPF) && string.IsNullOrEmpty(segurado.EscritorioPF))
                        {
                            worksheet1.Cells[i, c++].Value = segurado.PlataformaPJ;
                            worksheet1.Cells[i, c++].Value = segurado.EscritorioPJ;
                        }
                        else if (string.IsNullOrEmpty(segurado.PlataformaPJ) && string.IsNullOrEmpty(segurado.EscritorioPJ))
                        {
                            worksheet1.Cells[i, c++].Value = $"{segurado.PlataformaPF} {segurado.PlataformaPFLast}";
                            worksheet1.Cells[i, c++].Value = $"{segurado.EscritorioPF} {segurado.EscritorioPFLast}";
                        }
                        else if (!string.IsNullOrEmpty(segurado.PlataformaPF) && !string.IsNullOrEmpty(segurado.EscritorioPJ))
                        {
                            worksheet1.Cells[i, c++].Value = $"{segurado.PlataformaPF} {segurado.PlataformaPFLast}";
                            worksheet1.Cells[i, c++].Value = segurado.EscritorioPJ;
                        }
                        else if (!string.IsNullOrEmpty(segurado.PlataformaPJ) && !string.IsNullOrEmpty(segurado.EscritorioPF))
                        {
                            worksheet1.Cells[i, c++].Value = segurado.PlataformaPJ;
                            worksheet1.Cells[i, c++].Value = $"{segurado.EscritorioPF} {segurado.EscritorioPFLast}";
                        }

                        worksheet1.Cells[i, c++].Value = segurado.MedicGroupName;
                        worksheet1.Cells[i, c++].Value = segurado.Nome;
                        worksheet1.Cells[i, c++].Value = segurado.CPF;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/MM/yyyy";
                        worksheet1.Cells[i, c++].Value = segurado.DataNascimento;
                        worksheet1.Cells[i, c++].Value = segurado.Email;
                        worksheet1.Cells[i, c++].Value = $"{segurado.Endereco}, {segurado.EnderecoNumero}{(string.IsNullOrWhiteSpace(segurado.Complemento) ? "" : $" - {segurado.Complemento}")}{(string.IsNullOrWhiteSpace(segurado.Bairro) ? "" : $" - {segurado.Bairro}")}{(string.IsNullOrWhiteSpace(segurado.Cidade) ? "" : $" - {segurado.Cidade}")}{(string.IsNullOrWhiteSpace(segurado.Estado) ? "" : $" - {segurado.Estado}")} - {segurado.CEP}";
                        worksheet1.Cells[i, c++].Value = segurado.Telefone;
                        worksheet1.Cells[i, c++].Value = segurado.Celular;
                        worksheet1.Cells[i, c++].Value = segurado.CRM;
                        worksheet1.Cells[i, c++].Value = segurado.EstadoCRM;
                        worksheet1.Cells[i, c++].Value = segurado.Especialidade1;
                        worksheet1.Cells[i, c++].Value = segurado.Especialidade2;
                        worksheet1.Cells[i, c++].Value = segurado.Especialidade3;
                        worksheet1.Cells[i, c++].Value = segurado.NomePlano;
                        worksheet1.Cells[i, c++].Value = segurado.PagamentoTipoId.HasValue ? (segurado.PagamentoTipoId == 1 ? "Boleto" : "Cartao") : null;
                        worksheet1.Cells[i, c++].Value = segurado.VezesPagamento;
                        worksheet1.Cells[i, c++].Value = segurado.Desconto.HasValue ? segurado.Desconto : null;
                        worksheet1.Cells[i, c++].Value = segurado.CoberturaAdicionalDiretorChefeEquipe.HasValue ? (segurado.CoberturaAdicionalDiretorChefeEquipe == true ? "Sim" : "Nao") : "Nao";
                        worksheet1.Cells[i, c++].Value = segurado.CoberturaAdicionalSocioEmpresaAreaMedica.HasValue ? (segurado.CoberturaAdicionalSocioEmpresaAreaMedica == true ? "Sim" : "Nao") : "Nao";
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.ValorTotalAnualComDesconto.HasValue ? segurado.ValorTotalAnualComDesconto : null;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.ValorTotalMensalComDesconto.HasValue ? segurado.ValorTotalMensalComDesconto : null;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.PrecoAdmAnual;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.PrecoAdmMensal;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.PremioAnual;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet1.Cells[i, c++].Value = segurado.PremioMensal;
                        worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/MM/yyyy";
                        worksheet1.Cells[i, c++].Value = segurado.DataRetroatividade;

                        i++;
                    }

                    var tabela = worksheet1.Cells["A1:AC" + (i - 1).ToString()];
                    var ultimaLinha = worksheet1.Cells["A" + (i - 1).ToString() + ":AC" + (i - 1).ToString()];

                    tabela.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    tabela.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ultimaLinha.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();


                    // EXPORTACAO DA PLANILHA 2
                    var worksheet2 = excelPackage.Workbook.Worksheets[1];

                    worksheet2.Cells[1, 1, 1, 20].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet2.Cells[1, 1, 1, 20].Style.Fill.BackgroundColor.SetColor(colFromHex);

                    worksheet2.Cells[1, c++].Value = "Referência";
                    worksheet2.Cells[1, c++].Value = "Data Status";
                    worksheet2.Cells[1, c++].Value = "Status";
                    worksheet2.Cells[1, c++].Value = "Plataforma";
                    worksheet2.Cells[1, c++].Value = "Consultor GuardMed";
                    worksheet2.Cells[1, c++].Value = "Grupo Medico";
                    worksheet2.Cells[1, c++].Value = "Especialidade 1";
                    worksheet2.Cells[1, c++].Value = "Especialidade 2";
                    worksheet2.Cells[1, c++].Value = "Especialidade 3";
                    worksheet2.Cells[1, c++].Value = "Nome";
                    worksheet2.Cells[1, c++].Value = "Data de Nascimento";
                    worksheet2.Cells[1, c++].Value = "CRM";
                    worksheet2.Cells[1, c++].Value = "Estado CRM";
                    worksheet2.Cells[1, c++].Value = "Nome Plano";
                    worksheet2.Cells[1, c++].Value = "Telefone";
                    worksheet2.Cells[1, c++].Value = "Celular";
                    worksheet2.Cells[1, c++].Value = "Email";
                    worksheet2.Cells[1, c++].Value = "Tipo de Pagamento";
                    worksheet2.Cells[1, c++].Value = "Vezes do Pagamento";
                    worksheet2.Cells[1, c++].Value = "Valor Total";

                    int z = 2;
                    foreach (var segurado in segurados.Where(x => !x.CertificadoGerado))
                    {
                        c = 1;

                        if (z % 2 == 0)
                        {
                            worksheet2.Cells[z, 1, z, 20].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet2.Cells[z, 1, z, 20].Style.Fill.BackgroundColor.SetColor(colFromHex2);
                        }

                        worksheet2.Cells[z, c].Hyperlink = new Uri(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Retornar", "SeguroProfissional") + "?reference=" + segurado.Referencia);
                        worksheet2.Cells[z, c++].Value = segurado.Referencia;
                        worksheet2.Cells[z, c++].Value = segurado.DataAtualizacao.HasValue ? segurado.DataAtualizacao.Value.ToString("dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) : null;
                        worksheet2.Cells[z, c++].Value = segurado.Status;
                        worksheet2.Cells[z, c++].Value = "-";
                        worksheet2.Cells[z, c++].Value = segurado.ConsultorGuardMed;
                        worksheet2.Cells[z, c++].Value = segurado.MedicGroupName;
                        worksheet2.Cells[z, c++].Value = segurado.Especialidade1;
                        worksheet2.Cells[z, c++].Value = segurado.Especialidade2;
                        worksheet2.Cells[z, c++].Value = segurado.Especialidade3;
                        worksheet2.Cells[z, c++].Value = segurado.Nome;
                        worksheet2.Cells[z, c].Style.Numberformat.Format = "dd/MM/yyyy";
                        worksheet2.Cells[z, c++].Value = segurado.DataNascimento;
                        worksheet2.Cells[z, c++].Value = segurado.CRM;
                        worksheet2.Cells[z, c++].Value = segurado.EstadoCRM;
                        worksheet2.Cells[z, c++].Value = segurado.NomePlano;
                        worksheet2.Cells[z, c++].Value = segurado.Telefone;
                        worksheet2.Cells[z, c++].Value = segurado.Celular;
                        worksheet2.Cells[z, c++].Value = segurado.Email;
                        worksheet2.Cells[z, c++].Value = segurado.PagamentoTipoId.HasValue ? (segurado.PagamentoTipoId == 1 ? "Boleto" : "Cartao") : null;
                        worksheet2.Cells[z, c++].Value = segurado.VezesPagamento;
                        worksheet2.Cells[z, c].Style.Numberformat.Format = "R$ #,##0.00";
                        worksheet2.Cells[z, c++].Value = segurado.ValorTotalAnualComDesconto.HasValue ? segurado.ValorTotalAnualComDesconto : null;
                        z++;
                    }

                    var tabela2 = worksheet2.Cells["A1:T" + (z - 1).ToString()];
                    var ultimaLinha2 = worksheet2.Cells["A" + (z - 1).ToString() + ":T" + (z - 1).ToString()];

                    tabela2.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    tabela2.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ultimaLinha2.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet2.Cells[worksheet2.Dimension.Address].AutoFitColumns();

                    return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "SeguroProfissional.xlsx");

                }
            }
        }

        public async Task<IActionResult> a2dfc3925382436e922c1ab1b3a4e89e(string reference)
        {
            try
            {
                Models.SeguradoProfissionalViewModel seguradoProfissionalViewModel = null;
                GetSeguradoProfissionalViewModel(reference, ref seguradoProfissionalViewModel, true);

                var attachments = new List<System.Net.Mail.Attachment>();

                var html = await RenderPartialViewToString("Certificado", seguradoProfissionalViewModel);
                using (var memoryStream = new MemoryStream())
                {
                    using (var pdfWriter = new PdfWriter(memoryStream))
                    {
                        iText.Html2pdf.HtmlConverter.ConvertToPdf(html, pdfWriter);
                        attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(memoryStream.ToArray()), "Certificado - Seguro Profissional.pdf", MediaTypeNames.Application.Octet));
                    }
                }

                if (seguradoProfissionalViewModel.RenovadoPor.HasValue) //Renovação
                {
                    await mailFunctions.SendAsync("Renovação GuardMed", await RenderPartialViewToString("RenewCompletedEmail", seguradoProfissionalViewModel), new List<string>() { seguradoProfissionalViewModel.Email }, attachments, true);
                }
                else //Criação de certificado
                {
                    var docDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "archives", "Contrato de adesão GM.pdf");
                    attachments.Add(new System.Net.Mail.Attachment(docDirectory, System.Net.Mime.MediaTypeNames.Application.Octet));

                    var password = await seguradoProfissionalFunctions.GetAndGenerateNewPassword(seguradoProfissionalViewModel.SeguradoProfissionalId.Value);

                    await mailFunctions.SendAsync("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(seguradoProfissionalViewModel, password), new List<string>() { seguradoProfissionalViewModel.Email }, attachments, false);

                    if (!string.IsNullOrWhiteSpace(seguradoProfissionalViewModel.RetroatividadeFileName))
                    {
                        var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RetroatividadeSegurado", seguradoProfissionalViewModel.RetroatividadeFileName);
                        var attachment = new System.Net.Mail.Attachment(directory, System.Net.Mime.MediaTypeNames.Application.Octet);
                        attachment.Name = "Retroatividade" + System.IO.Path.GetExtension(seguradoProfissionalViewModel.RetroatividadeFileName);
                        attachments.Add(attachment);
                    }

                    mailFunctions.Send("Bem vindo a GuardMed! Certificado Individual de Proteção", PagamentoEmailMessage(seguradoProfissionalViewModel, password), new List<string>() { seguradoProfissionalViewModel.Email }, attachments, true);
                }

                return Content("Certificado enviado com sucesso!");
            }
            catch (Exception exception)
            {
                return Content(exception.Message);
            }
        }
    }
}
