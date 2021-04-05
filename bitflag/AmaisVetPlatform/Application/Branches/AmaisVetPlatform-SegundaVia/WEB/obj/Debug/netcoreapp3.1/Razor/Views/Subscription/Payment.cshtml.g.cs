#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1be0b7744202f547c64f8b2d254c34ed5d82fd83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscription_Payment), @"mvc.1.0.view", @"/Views/Subscription/Payment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1be0b7744202f547c64f8b2d254c34ed5d82fd83", @"/Views/Subscription/Payment.cshtml")]
    public class Views_Subscription_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Subscription.SubscriptionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["title"] = "Pagamento";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<form id=\"payment-form\"");
            BeginWriteAttribute("action", " action=\"", 164, "\"", 279, 1);
#nullable restore
#line 7 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
WriteAttributeValue("", 173, Url.Action(nameof(WEB.Controllers.PaymentController.Pay), "Payment", new { reference = Model.Reference }), 173, 106, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" method=\"post\">\r\n    <input type=\"hidden\" name=\"Reference\"");
            BeginWriteAttribute("value", " value=\"", 338, "\"", 362, 1);
#nullable restore
#line 8 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
WriteAttributeValue("", 346, Model.Reference, 346, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" name=\"RedirectUrl\"");
            BeginWriteAttribute("value", " value=\"", 411, "\"", 522, 1);
#nullable restore
#line 9 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
WriteAttributeValue("", 419, Url.Action(nameof(WEB.Controllers.Subscription.Confirmation), "Subscription", new { Model.Reference }), 419, 103, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" name=\"FallbackUrl\"");
            BeginWriteAttribute("value", " value=\"", 571, "\"", 677, 1);
#nullable restore
#line 10 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
WriteAttributeValue("", 579, Url.Action(nameof(WEB.Controllers.Subscription.Payment), "Subscription", new { Model.Reference }), 579, 98, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    <input type=""hidden"" id=""Token"" name=""Token"" />
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""mb-2"">
                <h2>
                    Pagamento
                </h2>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card card-blue"">
                <div class=""card-body"">
                    <h5 class=""card-title"">
                        Você escolheu o plano: <b>");
#nullable restore
#line 26 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
                                             Write(Model.PlanName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 26 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
                                                               Write(Model.MonthlyTotalFormatted);

#line default
#line hidden
#nullable disable
            WriteLiteral(" por mês</b>\r\n                        <br />\r\n                        <small>\r\n                            Parabéns pelo sua decisão em se proteger!\r\n                        </small>\r\n                    </h5>\r\n");
#nullable restore
#line 32 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
                     if (TempData["Error"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row\">\r\n                            <div class=\"col-md-12\">\r\n                                <div class=\"alert alert-danger\">\r\n                                    ");
#nullable restore
#line 37 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
                               Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 41 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label class=""control-label"">Forma de Pagamento</label>
                                <select id=""PaymentMethodId"" name=""PaymentMethodId"" class=""form-control"">
                                    <option selected=""selected"" value=""2"">Cartão de Crédito</option>
                                    <option value=""1"">Boleto</option>
                                </select>
                            </div>
                        </div>
                        <div class=""col-md-8"">
                            <div class=""card"" style=""color: black;"">
                                <div class=""card-body"">
                                    <div class=""row"">
                                        <div class=""col-12"" id=""bank-slip"" style=""display: none;"">
                                            <div class=""text-center"">
  ");
            WriteLiteral(@"                                              <h6>BOLETO BANCÁRIO</h6>
                                                <i class=""fa fa-barcode fa-5x"" aria-hidden=""true""></i>
                                                <hr />
                                                <p><b>Mensalmente, 7 dias antes do vencimento você receberá o boleto em seu e-mail.</b></p>
                                            </div>
                                        </div>
                                        <div class=""col-12"" id=""credit-card"">
                                            <div class=""row"">
                                                <div class=""col-md-6"" style=""display: flex; align-items: center;"">
                                                    <div class=""text-center"">
                                                        <h6>CARTÃO DE CRÉDITO</h6>
                                                        <i class=""fa fa-credit-card fa-5x"" aria-hidden=""true""></i>
              ");
            WriteLiteral(@"                                          <hr />
                                                        <i class=""fab fa-cc-visa fa-2x"" aria-hidden=""true""></i>
                                                        <i class=""fab fa-cc-mastercard fa-2x"" aria-hidden=""true""></i>
                                                        <i class=""fab fa-cc-amex fa-2x"" aria-hidden=""true""></i>
                                                        <i class=""fab fa-cc-diners-club fa-2x"" aria-hidden=""true""></i><br />
                                                        <p><b>Essa opção é por débito recorrente, não utilizando seu limite.</b></p>
                                                    </div>
                                                </div>
                                                <div class=""col-md-6"">
                                                    <div>
                                                        <div class=""row"">
                                               ");
            WriteLiteral(@"             <div class=""col-sm-12"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">Número do Cartão de Crédito</label>
                                                                    <input id=""Number"" name=""Number"" type=""text"" maxlength=""16"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class=""row"">
                                                            <div class=""col-sm-6"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">Nome</label>
                                             ");
            WriteLiteral(@"                       <input id=""FirstName"" name=""FirstName"" type=""text"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                            <div class=""col-sm-6"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">Sobrenome</label>
                                                                    <input id=""LastName"" name=""LastName"" type=""text"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class=""row"">
                                                            <div class=""co");
            WriteLiteral(@"l-sm-4"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">Mês</label>
                                                                    <input id=""Month"" name=""Month"" type=""text"" maxlength=""2"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                            <div class=""col-sm-4"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">Ano</label>
                                                                    <input id=""Year"" name=""Year"" type=""text"" maxlength=""4"" class=""form-control"" />
                                                                </div>
                    ");
            WriteLiteral(@"                                        </div>
                                                            <div class=""col-sm-4"">
                                                                <div class=""form-group"">
                                                                    <label class=""control-label"">CVV</label>
                                                                    <input id=""VerificationValue"" name=""VerificationValue"" maxlength=""3"" type=""text"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
              ");
            WriteLiteral(@"              </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-6"">
            <a class=""btn btn-secondary""");
            BeginWriteAttribute("href", " href=\"", 9290, "\"", 9350, 1);
#nullable restore
#line 138 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
WriteAttributeValue("", 9297, Url.Action("Questionnaire", new { Model.Reference }), 9297, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Voltar</a>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            <button id=\"button-pay\" class=\"btn btn-primary\" type=\"submit\">Transmitir</button>\r\n        </div>\r\n    </div>\r\n</form>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        function creditCardIsValid() {
            $('#credit-card .text-danger').remove();
            var hasError = false;

            if (!$('#credit-card #Number').val() || $('#credit-card #Number').val().length != 16) {
                $('#credit-card #Number').after('<div class=""text-danger"">Número de cartão de crédito inválido</div>');
                hasError = true;
            }
            if (!$('#credit-card #FirstName').val() || $('#credit-card #FirstName').val().length < 3) {
                $('#credit-card #FirstName').after('<div class=""text-danger"">Inválido</div>');
                hasError = true;
            }
            if (!$('#credit-card #LastName').val() || $('#credit-card #LastName').val().length < 3) {
                $('#credit-card #LastName').after('<div class=""text-danger"">Inválido</div>');
                hasError = true;
            }
            if (!$('#credit-card #Month').val() || $('#credit-card #Month').val().leng");
                WriteLiteral(@"th != 2) {
                $('#credit-card #Month').after('<div class=""text-danger"">Inválido</div>');
                hasError = true;
            }
            if (!$('#credit-card #Year').val() || ($('#credit-card #Year').val().length < 2 && $('#credit-card #Year').val().length > 4)) {
                $('#credit-card #Year').after('<div class=""text-danger"">Inválido</div>');
                hasError = true;
            }
            if ($('#credit-card #VerificationValue').val().length < 3) {
                $('#credit-card #VerificationValue').after('<div class=""text-danger"">Inválido</div>');
                hasError = true;
            }
            return !hasError;
        }
        function creditCardToken(callback) {
            $.get('");
#nullable restore
#line 178 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\Payment.cshtml"
              Write(Url.Action(nameof(WEB.Controllers.PaymentController.CreditCardToken), "Payment"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?' + $('#payment-form').serialize(), function (d) { callback(d); });
        }
    </script>
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#PaymentMethodId').change(function () {
                if ($(this).val() == '1') {
                    $('#credit-card').hide();
                    $('#bank-slip').show();
                } else {
                    $('#credit-card').show();
                    $('#bank-slip').hide();
                }
            }).change();
            $('#payment-form').on('submit', function (e) {
                $('#button-pay').prop('disabled', true);
                if ($('#PaymentMethodId').val() == '1') {
                    return true;
                } else {
                    if (!$('#Token').val()) {
                        e.preventDefault();

                        if (!creditCardIsValid()) {
                            alert('Por favor, preencha corretamente os dados de seu cartão de crédito.');
   ");
                WriteLiteral(@"                         return false;
                        }
                        creditCardToken(function (d) {
                            if (d.hasError || (d.data == null || d.data == '')) {
                                alert('Atenção, houve um erro ao processar pagamento:\n\n' + d.message);
                                $('#button-pay').prop('disabled', false);
                            } else {
                                $('#Token').val(d.data);
                                $('#payment-form').submit();
                            }
                        });
                    }
                }
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Subscription.SubscriptionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
