using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Mail;
using System.IO;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;
using Microsoft.Extensions.Configuration;

namespace GuardMedWeb.Controllers
{
    public class SeguroAparelhoController : Controller
    {
        DAL.GuardMedWebContext _context;
        private readonly BLL.SeguradoEquipamento.SeguradoEquipamentoFunctions seguradoEquipamentoFunctions;
        private readonly BLL.SeguradoEquipamento.EquipamentoFunctions equipamentoFunctions;
        private readonly BLL.Pagamento.PagamentoTipoFunctions pagamentoTipoFunctions;
        private readonly BLL.SeguradoEquipamento.TipoEquipamentoFunctions tipoEquipamentoFunctions;
        private readonly BLL.SeguradoEquipamento.SeguradoAparelhoViewFunctions seguradoAparelhoViewFunctions;
        private readonly BLL.System.SystemVariableFunctions systemVariableFunctions;
        private readonly MailFunctions mailFunctions;
        private ICompositeViewEngine _viewEngine;
        readonly IConfiguration configuration;

        public SeguroAparelhoController(DAL.GuardMedWebContext context, ICompositeViewEngine viewEngine, MailFunctions mailFunctions, IConfiguration configuration)
        {
            this._context = context;
            this.seguradoEquipamentoFunctions = new BLL.SeguradoEquipamento.SeguradoEquipamentoFunctions(context);
            this.equipamentoFunctions = new BLL.SeguradoEquipamento.EquipamentoFunctions(context);
            this.pagamentoTipoFunctions = new BLL.Pagamento.PagamentoTipoFunctions(context);
            this.tipoEquipamentoFunctions = new BLL.SeguradoEquipamento.TipoEquipamentoFunctions(context);
            this.seguradoAparelhoViewFunctions = new BLL.SeguradoEquipamento.SeguradoAparelhoViewFunctions(context);
            this.systemVariableFunctions = new BLL.System.SystemVariableFunctions(context);
            this._viewEngine = viewEngine;
            this.mailFunctions = mailFunctions;
            this.configuration = configuration;
        }


        #region [SHARED]
        private IActionResult GetSeguradoAparelhoViewModel(string reference, ref Models.SeguradoEquipamentoViewModel model, bool ignoreCertificate = false)
        {
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoEquipamentoFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoEquipamento = seguradoEquipamentoFunctions.GetDataViewModel(seguradoEquipamentoFunctions.GetDataByID(seguradoEquipamentoFunctions.GetByReference(reference)));
            if (seguradoEquipamento == null) return NotFound();
            if (!ignoreCertificate)
                if (seguradoEquipamento.CertificadoGerado.HasValue && seguradoEquipamento.CertificadoGerado.Value)
                    return Forbid();

            model = seguradoEquipamento;
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
        #endregion

        #region [STEP 1]
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["PlanoSeguroEquipamento"] = _context.PlanoSeguroEquipamento.Where(x => x.EstaAtivo == true).ToList();
            return await Task.Run<IActionResult>(() => { return View(); });
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> _Index(Models.SeguradoEquipamentoViewModel model)
        {

            int maxTries = 10;
            for (int i = 0; i <= maxTries; i++)
            {
                if (i == maxTries) throw new Exception("Reference max tries reached.");
                var reference = BLL.Utils.Utils.GetReference();
                if (!seguradoEquipamentoFunctions.ReferenciaExiste(reference))
                {
                    model.Referencia = reference;
                    break;
                }
            }

            model.SeguradoEquipamentoId = seguradoEquipamentoFunctions.CreateOrUpdate(model);
            return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });
        }
        #endregion

        #region [STEP 2]
        [HttpGet]
        [ActionName("Cotacao")]
        public async Task<IActionResult> Cotacao(string reference)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            return await Task.Run<IActionResult>(() => { return View(model); });
        }

        [HttpPost]
        [ActionName("Cotacao")]
        public async Task<IActionResult> _Cotacao(string reference, string PrecoSeguro)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            model.PrecoSeguro = PrecoSeguro;
            seguradoEquipamentoFunctions.UpdateCotacao(model);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });
        }
        #endregion

        #region [STEP 3]
        [HttpGet]
        [ActionName("Formulario")]
        public async Task<IActionResult> Formulario(string reference)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (!model.SeguradoEquipamentoId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });

            ViewData["TipoEquipamento"] = tipoEquipamentoFunctions.GetData().ToList();
            return await Task.Run<IActionResult>(() => { return View(model); });
        }

        [HttpPost]
        [ActionName("Formulario")]
        public async Task<IActionResult> _Formulario(string reference, Models.SeguradoEquipamentoViewModel _model)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            model.SeguradoEquipamentoId = _model.SeguradoEquipamentoId;
            model.Nome = _model.Nome;
            model.DataNascimento = _model.DataNascimento;
            model.CPF = _model.CPF;
            model.CRMV = _model.CRMV;
            model.CEP = _model.CEP;
            model.Cidade = _model.Cidade;
            model.Complemento = _model.Complemento;
            model.Endereco = _model.Endereco;
            model.EnderecoNumero = _model.EnderecoNumero;
            model.Estado = _model.Estado;
            model.Email = _model.Email;
            model.Telefone = _model.Telefone;
            model.Celular = _model.Celular;
            model.Bairro = _model.Bairro;

            seguradoEquipamentoFunctions.UpdateFormulario(model);

            return await Task.Run<IActionResult>(() => { return RedirectToAction("Pagamento", new { reference = reference }); });
        }

        [HttpPost]
        [ActionName("SalvarEquipamento")]
        public async Task<IActionResult> SalvarEquipamento([FromBody]List<Models.EquipamentoViewModel> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var id = equipamentoFunctions.CreateOrUpdate(item);
                }
                return await Task.Run<IActionResult>(() => { return Json(true); });
            }
            catch (Exception ex)
            {
                return await Task.Run<IActionResult>(() => { return Json(false); });
            }

        }

        #endregion

        #region [STEP 4]
        [HttpGet]
        [ActionName("Pagamento")]
        public async Task<IActionResult> Pagamento(string reference)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            if (!model.SeguradoEquipamentoId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });

            ViewData["PagamentoTipos"] = pagamentoTipoFunctions.GetData().ToList();
            ViewData["TipoEquipamento"] = tipoEquipamentoFunctions.GetData().ToList();

            return await Task.Run<IActionResult>(() => { return View(model); });
        }
        [HttpPost]
        [ActionName("Pagamento")]
        public async Task<IActionResult> _Pagamento(string reference, int? VezesPagamento, int? PagamentoTipoId)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            model.VezesPagamento = VezesPagamento;
            model.PagamentoTipoId = PagamentoTipoId;

            seguradoEquipamentoFunctions.UpdatePagamento(model);

            #region [CERTIFICADO]
            var html = await RenderPartialViewToString("Certificado", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);
            System.Net.Mail.Attachment attachment1 = new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), "Certificado - Seguro Aparelho.pdf", MediaTypeNames.Application.Octet);
            #endregion

            #region [DECLARACAO]
            var docDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "archives", "MODELO_DE_DECLARACAO_DE_BENS_APARELHOS_VETERINARIOS.docx");
            System.Net.Mail.Attachment attachment2 = new System.Net.Mail.Attachment(docDirectory, System.Net.Mime.MediaTypeNames.Application.Octet);
            #endregion

            await mailFunctions.SendAsync("Bem vindo a AmaisVet! Proposta de Seguro de Aparelho Veterinário", ConteudoEmail(model), new List<string>() { model.Email }, new List<System.Net.Mail.Attachment>() { attachment1, attachment2 }, false);
            return await Task.Run<IActionResult>(() => { return RedirectToAction("Impressao", new { reference = reference }); });
        }
        private string ConteudoEmail(Models.SeguradoEquipamentoViewModel model)
        {
            return "Olá Dr. (a) <strong>" + model.Nome + "</strong>,<br/><br/>" +
                "Agradecemos a confiança.<br/><br/>" +
                "Agora você faz parte de um grupo seleto de <strong>médico-veterinário</strong> que confiaram a gestão da sua apólice de Seguro na maior empresa deste segmento.<br/><br/>" +
                "Confira nos arquivos anexos a sua Proposta e o <b>Modelo de Declaração de Bens</b> que deverá ser usado para os Aparelhos que não possuem Nota Fiscal.<br/><br/>" +
                "A <strong>AmaisVet</strong> está presente nos principais <strong>CRMV’s</strong> do país com Produtos e Serviços exclusivos para a área da Medicina Veterinária, trazendo mais tranquilidade e segurança no exercício da profissão.<br/><br/><br/>" +
                "<div align='center'><strong><u>ORIENTAÇÕES GERAIS AMAISVET</u></strong></div><br/>" +
                "<div align='center'><label>A vigência deste seguro se dará em até 2 úteis após a análise de aceitação da seguradora. O seguro será garantido pela Axa Seguros Brasil S.A, CNPJ 19.329.190/0001-06, SUSEP 0285-2.</label><br/><br/>" +
                "Os Aparelhos que não possuem Nota Fiscal, devem conter a <strong><u>Declaração de Bens – Aparelhos Veterinários</u></strong> com firma reconhecida em cartório e anexo a foto panorâmica do aparelho e da placa ou gravação do número de série / chassi. Por favor, encaminhar esses documentos scaneados para o e-mail <a href=\"mailto:contato@amaisvet.com.br\">contato@amaisvet.com.br</a></div><br/><br/><br/>" +
                    "<div align='center'><strong><u>CONTATO AMAISVET</u></strong></div><br/>" +
                    "<div align='center'><label><strong>São Paulo</strong> - Rua Manoel da Nobrega, 354 – 8º andar – Paraiso - Fone.: 11 3253-2284 |  <strong>Campinas</strong> - Rua Dr Osvaldo Cruz, 505 – Taquaral - Fone: 19 3291-1241</label></div><br/>" +
                    "<div align='center'><label><a href='mailto:contato@amaisvet.com.br'>contato@amaisvet.com.br</a></label></div>";
        }
        #endregion

        #region [STEP 5]
        public async Task<IActionResult> Impressao(string reference)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoEquipamentoFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoEquipamento = seguradoEquipamentoFunctions.GetDataViewModel(seguradoEquipamentoFunctions.GetDataByID(seguradoEquipamentoFunctions.GetByReference(reference)));
            if (seguradoEquipamento == null) return NotFound();

            model = seguradoEquipamento;

            if (!model.SeguradoEquipamentoId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Pagamento", new { reference = reference }); });

            ViewData["TipoEquipamento"] = tipoEquipamentoFunctions.GetData().ToList();

            return await Task.Run<IActionResult>(() => { return View(model); });
        }
        #endregion

        public async Task<IActionResult> Retornar(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                ViewData["notFound"] = true;
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Index"); });
            }

            if (!seguradoEquipamentoFunctions.ReferenciaExiste(reference))
            {
                ViewData["notFound"] = true;
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Index"); });
            }

            Models.SeguradoEquipamentoViewModel model = null;
            if (string.IsNullOrWhiteSpace(reference)) return NotFound();
            if (!seguradoEquipamentoFunctions.ReferenciaExiste(reference)) return NotFound();
            var seguradoEquipamento = seguradoEquipamentoFunctions.GetDataViewModel(seguradoEquipamentoFunctions.GetDataByID(seguradoEquipamentoFunctions.GetByReference(reference)));
            if (seguradoEquipamento == null) return NotFound();

            model = seguradoEquipamento;

            if (model.PagamentoTipoId.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Impressao", new { reference = model.Referencia }); });
            if (!string.IsNullOrWhiteSpace(model.CPF))
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Pagamento", new { reference = model.Referencia }); });
            else if (!string.IsNullOrWhiteSpace(model.PrecoSeguro))
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Formulario", new { reference = model.Referencia }); });
            else if (model.DataCriacao.HasValue)
                return await Task.Run<IActionResult>(() => { return RedirectToAction("Cotacao", new { reference = model.Referencia }); });


            ViewData["notFound"] = true;
            return await Task.Run<IActionResult>(() => { return RedirectToAction("Index"); });
        }

        #region [CERTIFICADO]
        public async Task<IActionResult> Certificado(string reference)
        {
            Models.SeguradoEquipamentoViewModel model = null;
            var r = GetSeguradoAparelhoViewModel(reference, ref model, true);
            if (r != null) return await Task.Run<IActionResult>(() => { return r; });

            ViewData["TipoEquipamento"] = tipoEquipamentoFunctions.GetData().ToList();
            return await Task.Run<IActionResult>(() => { return View(model); });
        }



        #endregion


        public IActionResult Exportar(string token)
        {
            var tokenExportar = systemVariableFunctions.GetSystemVariable("TokenExportar");
            if (tokenExportar != token)
                return Forbid();

            var byteArray = System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Templates", "Modelo.xlsx"));
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, (int)byteArray.Length);
                memoryStream.Position = 0;
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    using (var worksheet1 = excelPackage.Workbook.Worksheets.First())
                    {
                        for (int j = 1; j <= 33; j++)
                        {
                            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#b2a1c7");
                            worksheet1.Cells[1, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet1.Cells[1, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                        }

                        worksheet1.Cells[1, 1].Value = "Referência";
                        worksheet1.Cells[1, 2].Value = "Data de Criação";
                        worksheet1.Cells[1, 3].Value = "Nome";
                        worksheet1.Cells[1, 4].Value = "E-mail";
                        worksheet1.Cells[1, 5].Value = "Celular";
                        worksheet1.Cells[1, 6].Value = "Telefone";
                        worksheet1.Cells[1, 7].Value = "Plano";
                        worksheet1.Cells[1, 8].Value = "Qtd. de Equipamentos";
                        worksheet1.Cells[1, 9].Value = "Preço dos Equipamentos";
                        worksheet1.Cells[1, 10].Value = "CRMV";
                        worksheet1.Cells[1, 11].Value = "Estado do CRMV";
                        worksheet1.Cells[1, 12].Value = "CPF";
                        worksheet1.Cells[1, 13].Value = "Data de Nascimento";
                        worksheet1.Cells[1, 14].Value = "CEP";
                        worksheet1.Cells[1, 15].Value = "Endereço";
                        worksheet1.Cells[1, 16].Value = "Número";
                        worksheet1.Cells[1, 17].Value = "Complemento";
                        worksheet1.Cells[1, 18].Value = "Bairro";
                        worksheet1.Cells[1, 19].Value = "Cidade";
                        worksheet1.Cells[1, 20].Value = "Estado";
                        worksheet1.Cells[1, 21].Value = "Marca";
                        worksheet1.Cells[1, 22].Value = "Modelo";
                        worksheet1.Cells[1, 23].Value = "Serie";
                        worksheet1.Cells[1, 24].Value = "Preço";
                        worksheet1.Cells[1, 25].Value = "Possui NF?";
                        worksheet1.Cells[1, 26].Value = "Tipo de Equipamento";
                        worksheet1.Cells[1, 27].Value = "Especificação do Tipo";
                        worksheet1.Cells[1, 28].Value = "Ano";
                        worksheet1.Cells[1, 29].Value = "Tipo de Pagamento";
                        worksheet1.Cells[1, 30].Value = "Preço do Seguro";
                        worksheet1.Cells[1, 31].Value = "Parcelas do Pagamento";
                        worksheet1.Cells[1, 32].Value = "Data de Atualização";
                        worksheet1.Cells[1, 33].Value = "Passo Em Que Parou";

                        int i = 2;
                        foreach (var segurado in seguradoAparelhoViewFunctions.GetData().OrderByDescending(x => x.DataCriacao))
                        {
                            if (i % 2 == 0)
                            {
                                for (int j = 1; j <= 33; j++)
                                {
                                    Color colFromHex = ColorTranslator.FromHtml("#efedf2");
                                    worksheet1.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet1.Cells[i, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                                }
                            }

                            worksheet1.Cells[i, 1].Hyperlink = new Uri(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Retornar", "SeguroAparelho") + "?reference=" + segurado.Referencia);
                            worksheet1.Cells[i, 1].Value = segurado.Referencia;
                            worksheet1.Cells[i, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            worksheet1.Cells[i, 2].Value = segurado.DataCriacao.HasValue ? segurado.DataCriacao : null;
                            worksheet1.Cells[i, 3].Value = segurado.Nome;
                            worksheet1.Cells[i, 4].Value = segurado.Email;
                            worksheet1.Cells[i, 5].Value = segurado.Celular;
                            worksheet1.Cells[i, 6].Value = segurado.Telefone;
                            worksheet1.Cells[i, 7].Value = segurado.PlanoSeguroEquipamentoNome;
                            worksheet1.Cells[i, 8].Value = segurado.QtdEquipamento;
                            worksheet1.Cells[i, 9].Style.Numberformat.Format = "R$ #,##0.00";
                            worksheet1.Cells[i, 9].Value = segurado.PrecoEquipamento.HasValue ? segurado.PrecoEquipamento : null;
                            worksheet1.Cells[i, 10].Value = segurado.CRMV;
                            worksheet1.Cells[i, 11].Value = segurado.CRMVEstado;
                            worksheet1.Cells[i, 12].Value = segurado.CPF;
                            worksheet1.Cells[i, 13].Style.Numberformat.Format = "dd/MM/yyyy";
                            worksheet1.Cells[i, 13].Value = segurado.DataNascimento.HasValue ? segurado.DataNascimento : null;
                            worksheet1.Cells[i, 14].Value = segurado.CEP;
                            worksheet1.Cells[i, 15].Value = segurado.Endereco;
                            worksheet1.Cells[i, 16].Value = segurado.EnderecoNumero;
                            worksheet1.Cells[i, 17].Value = segurado.Complemento;
                            worksheet1.Cells[i, 18].Value = segurado.Bairro;
                            worksheet1.Cells[i, 19].Value = segurado.Cidade;
                            worksheet1.Cells[i, 20].Value = segurado.Estado;
                            worksheet1.Cells[i, 21].Value = segurado.Marca;
                            worksheet1.Cells[i, 22].Value = segurado.Modelo;
                            worksheet1.Cells[i, 23].Value = segurado.Serie;
                            worksheet1.Cells[i, 24].Style.Numberformat.Format = "R$ #,##0.00";
                            worksheet1.Cells[i, 24].Value = segurado.Preco.HasValue ? segurado.Preco : null;
                            if (segurado.NF.HasValue)
                                worksheet1.Cells[i, 25].Value = segurado.NF.Value ? "Sim" : "Não";
                            else
                                worksheet1.Cells[i, 25].Value = "";
                            worksheet1.Cells[i, 26].Value = segurado.TipoEquipamentoNome;
                            worksheet1.Cells[i, 27].Value = segurado.EspecificacaoTipo;
                            worksheet1.Cells[i, 28].Value = segurado.Ano;
                            worksheet1.Cells[i, 29].Value = segurado.PagamentoTipoNome;
                            worksheet1.Cells[i, 30].Style.Numberformat.Format = "R$ #,##0.00";
                            worksheet1.Cells[i, 30].Value = segurado.PrecoSeguro.HasValue ? segurado.PrecoSeguro : null;
                            worksheet1.Cells[i, 31].Value = segurado.VezesPagamento;
                            worksheet1.Cells[i, 32].Style.Numberformat.Format = "dd/MM/yyyy";
                            worksheet1.Cells[i, 32].Value = segurado.DataAtualizacao.HasValue ? segurado.DataAtualizacao : null;
                            worksheet1.Cells[i, 33].Value = segurado.StopedStep;

                            i++;
                        }

                        var tabela = worksheet1.Cells["A1:AG" + (i - 1).ToString()];
                        var ultimaLinha = worksheet1.Cells["A" + (i - 1).ToString() + ":AG" + (i - 1).ToString()];

                        tabela.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        tabela.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ultimaLinha.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        
                        worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                        return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "SeguroAparelho.xlsx");
                    }
                }
            }
        }
    }
}
