#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b0123214323f925cc3569ee16e67207272d1f6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Finances_Index), @"mvc.1.0.view", @"/Views/Finances/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Finances/Index.cshtml", typeof(AspNetCore.Views_Finances_Index))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
using WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b0123214323f925cc3569ee16e67207272d1f6b", @"/Views/Finances/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Finances_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
  
    ViewData["Title"] = "Área Financeira";

    int? userRealEstateAgencyId = null;
    int? userRealEstateId = null;
    if (ViewData.ContainsKey("UserRealEstateAgencyId"))
    {
        userRealEstateAgencyId = (int)ViewData["UserRealEstateAgencyId"];
        userRealEstateId = (int)ViewData["UserRealEstateId"];
    }

#line default
#line hidden
            BeginContext(357, 201, true);
            WriteLiteral("\r\n<style type=\"text/css\">\r\n    tbody tr td {\r\n        vertical-align: middle !important;\r\n    }\r\n</style>\r\n\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 23 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(614, 86, true);
            WriteLiteral("                <input type=\"hidden\" id=\"RealEstateAgencyId\" name=\"RealEstateAgencyId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 700, "\"", 731, 1);
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
WriteAttributeValue("", 708, userRealEstateAgencyId, 708, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(732, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 26 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(785, 205, true);
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <div class=\"input-group\">\r\n                        <div class=\"input-group-prepend\">\r\n                            <span class=\"input-group-text\">");
            EndContext();
            BeginContext(991, 61, false);
#line 32 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                      Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1052, 174, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <select class=\"form-control\" id=\"RealEstateAgencyId\" name=\"RealEstateAgencyId\">\r\n                            ");
            EndContext();
            BeginContext(1226, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0123214323f925cc3569ee16e67207272d1f6b6366", async() => {
                BeginContext(1243, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1261, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 36 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                             foreach (var item in (List
               <DB.Models.Company>
                   )ViewData["RealEstateAgency"])
                            {
                                var companyName = string.IsNullOrWhiteSpace(item.RazaoSocial) ? item.FirstName + " " + item.LastName : item.RazaoSocial;
                                if (ViewBag.RealEstateAgencyId != null && (int)ViewBag.RealEstateAgencyId == item.CompanyId)
                                {

#line default
#line hidden
            BeginContext(1753, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(1789, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0123214323f925cc3569ee16e67207272d1f6b8517", async() => {
                BeginContext(1856, 11, false);
#line 43 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                                 Write(companyName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 43 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                       WriteLiteral(item.CompanyId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#line 43 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                   Write(companyName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1876, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 44 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1986, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(2022, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0123214323f925cc3569ee16e67207272d1f6b11838", async() => {
                BeginContext(2080, 11, false);
#line 47 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                        Write(companyName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 47 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                       WriteLiteral(item.CompanyId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 47 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                          Write(companyName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 48 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                }
                            }

#line default
#line hidden
            BeginContext(2168, 87, true);
            WriteLiteral("                        </select>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 53 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2270, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 54 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(2326, 74, true);
            WriteLiteral("                <input id=\"RealEstateId\" name=\"RealEstateId\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2400, "\"", 2425, 1);
#line 56 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
WriteAttributeValue("", 2408, userRealEstateId, 2408, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2426, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 57 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(2479, 216, true);
            WriteLiteral("                <div class=\"form-group col-md-3\">\r\n                    <div class=\"input-group\">\r\n                        <div class=\"input-group-prepend\">\r\n                            <span class=\"input-group-text\">");
            EndContext();
            BeginContext(2696, 59, false);
#line 63 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                      Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(2755, 142, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <select class=\"form-control\" id=\"RealEstateId\">\r\n                            ");
            EndContext();
            BeginContext(2897, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0123214323f925cc3569ee16e67207272d1f6b17049", async() => {
                BeginContext(2914, 23, true);
                WriteLiteral("Selecione uma corretora");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2946, 89, true);
            WriteLiteral("\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 70 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(3050, 382, true);
            WriteLiteral(@"            <div class=""form-group col-md-3"">
                <div class=""input-group"" id=""_CertificateManageReferenceMonthArea"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Mês de Referência</span>
                    </div>
                    <input type=""text"" class=""form-control monthYear"" name=""_refMonth""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3432, "\"", 3463, 1);
#line 76 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
WriteAttributeValue("", 3440, ViewBag.ReferenceMonth, 3440, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3464, 343, true);
            WriteLiteral(@" id=""_CertificateManageReferenceMonth"" placeholder=""Mês de Referência"">
                </div>
            </div>
            <div class=""col-md-2"">
                <button id=""button-charges"" class=""btn btn-primary w-100""><i class='fas fa-search'></i>&nbsp;Buscar Cobranças</button>
            </div>
        </div>
        <hr />

");
            EndContext();
#line 85 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
         if (User.IsInRole("Administrator"))
        {

#line default
#line hidden
            BeginContext(3864, 318, true);
            WriteLiteral(@"            <div class=""row"" style=""margin-bottom:1em; display:none;"" id=""gerar-boleto-area"">
                <div class=""col-md-12 text-center"">
                    <button class=""btn btn-success"" id=""gerar-boleto-botao""><i class=""fas fa-barcode""></i>&nbsp;<span id=""gerar-boleto-texto"">Gerar Boletos para Todas as ");
            EndContext();
            BeginContext(4183, 59, false);
#line 89 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                                                                                                     Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(4242, 280, true);
            WriteLiteral(@"</span></button>
                </div>
            </div>
            <script type=""text/javascript"">
                $('#gerar-boleto-botao').click(function () {
                    if (!confirm('Deseja realmente gerar os boletos?')) return;

                    $.post('");
            EndContext();
            BeginContext(4523, 37, false);
#line 96 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                       Write(Url.Action("ChargeActiveRealEstates"));

#line default
#line hidden
            EndContext();
            BeginContext(4560, 489, true);
            WriteLiteral(@"',
                        {
                            realEstateAgencyId: $('#RealEstateAgencyId').val(),
                            realEstateId: $('#RealEstateId').val(),
                            _mouthRefence: $('#_CertificateManageReferenceMonth').val()
                        },
                        function (d) {
                            alert(d.message);
                            if (!d.hasError) {
                                window.location.href = '");
            EndContext();
            BeginContext(5050, 31, false);
#line 105 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                   Write(Url.Action("Index", "Finances"));

#line default
#line hidden
            EndContext();
            BeginContext(5081, 296, true);
            WriteLiteral(@"?referenceMonth=' + $('#_CertificateManageReferenceMonth').val() + '&realEstateAgencyId=' + $('#RealEstateAgencyId').val() + '&realEstateId=' + $('#RealEstateId').val();
                            }
                        }
                    )
                });
            </script>
");
            EndContext();
#line 111 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(5388, 897, true);
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div id=""no-real-estate"">
                            <div class=""text-center""><i>Por favor, selecione o mês de referência para visualizar suas cobranças.</i></div>
                        </div>
                        <div id=""no-data"" style=""display: none;"">
                            <div class=""text-center""><i>Nenhuma cobrança existente.</i></div>
                        </div>
                        <div id=""table-container"" style=""display: none;"">
                            <table class=""table table-bordered table-striped"" id=""table"" style=""width: 100%;"">
                                <thead>
                                    <tr>
                                        <th style=""width:300px;"">");
            EndContext();
            BeginContext(6286, 59, false);
#line 126 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                            Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(6345, 1369, true);
            WriteLiteral(@"</th>
                                        <th>Descrição</th>
                                        <th>Valor</th>
                                        <th>Mês/Ano Referência</th>
                                        <th>Vencimento</th>
                                        <th>Pago?</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody id=""tbody""></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">
    $('#RealEstateAgencyId').change(function () {
        GetRealEstates();
    });

    $('#button-charges').click(function () {

        if (!$('#_CertificateManageReferenceMonth').val())
        {
            alert('Por favor, selecione o mês de referência.');
            $('#no-real-estat");
            WriteLiteral(@"e').show();
            $('#no-data').hide();
            $('#table-container').hide();
            $('#gerar-boleto-area').hide();

            return false;
        }

        $('#gerar-boleto-area').show();
        if (!IsNullOrWhiteSpace($('#RealEstateId').val())) {
            $('#gerar-boleto-texto').text('Gerar Boletos para '+");
            EndContext();
            BeginContext(7715, 59, false);
#line 164 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                           Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(7774, 205, true);
            WriteLiteral(" + $(\'#RealEstateId :selected\').data(\'name\'));\r\n        }\r\n        else if (!IsNullOrWhiteSpace($(\'#RealEstateAgencyId\').val())) {\r\n            $(\'#gerar-boleto-texto\').text(\'Gerar Boletos para Todas as \'+");
            EndContext();
            BeginContext(7980, 59, false);
#line 167 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                    Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(8039, 8, true);
            WriteLiteral("+\' da \'+");
            EndContext();
            BeginContext(8048, 61, false);
#line 167 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                                                                        Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(8109, 146, true);
            WriteLiteral(" + $(\'#RealEstateAgencyId :selected\').data(\'name\'));\r\n        } else {\r\n            $(\'#gerar-boleto-texto\').text(\'Gerar Boletos para Todas as\' + ");
            EndContext();
            BeginContext(8256, 59, false);
#line 169 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                     Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(8315, 34, true);
            WriteLiteral(");\r\n        }\r\n\r\n\r\n        $.get(\'");
            EndContext();
            BeginContext(8350, 36, false);
#line 173 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
          Write(Url.Action("GetCharges", "Finances"));

#line default
#line hidden
            EndContext();
            BeginContext(8386, 1174, true);
            WriteLiteral(@"', { realEstateAgencyId: $('#RealEstateAgencyId').val(), realEstateId: $('#RealEstateId').val(), _ReferenceMonth: $('#_CertificateManageReferenceMonth').val() }, function (d) {

            $('#table').DataTable().destroy();
            $('#tbody').empty();

            if (d.length == 0) {
                $('#no-real-estate').hide();
                $('#no-data').show();
                $('#table-container').hide();
                return false;
            }

            $.each(d, function (i, e) {
                var tr = $('<tr />', { id: 'tr' + e.chargeId });
                $(tr).append('<td>' + e.companyName + '</td>');
                $(tr).append('<td>' + e.description + '</td>');
                $(tr).append('<td>R$ ' + e._Price + '</td>');
                $(tr).append('<td>' + e._ReferenceDate + '</td>');
                $(tr).append('<td>' + e._DueDate + '</td>');
                $(tr).append('<td id=""isPayed' + e.chargeId + '"">' + (e.isPayed? 'Sim' : 'Não') + '</td>');

     ");
            WriteLiteral("           var actions = \"<td><a target=\'_blank\' class=\'btn btn-primary\' href=\'\" + e.iuguUrl + \"\'><i class=\'fas fa-barcode\'></i>&nbsp;Boleto</a>\";\r\n\r\n");
            EndContext();
#line 196 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                 if (User.IsInRole("Administrator")) {
                

#line default
#line hidden
            BeginContext(9638, 554, true);
            WriteLiteral(@"
                actions += ""&nbsp;"" + (e.isPayed ? """" : ""<a id='pagar"" + e.chargeId + ""' href='javascript:void(0)' class='btn btn-success' onclick='Pagar("" + JSON.stringify({ chargeId: e.chargeId, payedToken: e.payedToken }) + "")'><i class='fas fa-check'></i>&nbsp;Pago</a>"");
                actions += ""&nbsp;"" + (e.isPayed ? """" : ""<a id='excluir"" + e.chargeId + ""' href='javascript:void(0)' class='btn btn-danger' onclick='Excluir("" + JSON.stringify({ chargeId: e.chargeId }) + "")'><i class='fas fa-trash'></i>&nbsp;Excluir</a>"");
                ");
            EndContext();
#line 200 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                       
                }

#line default
#line hidden
            BeginContext(10220, 746, true);
            WriteLiteral(@"                $(tr).append(actions + ""</td>"");
                $('#tbody').append(tr);
            });

            $('#table').DataTable({
                searching: false,
                ordering: false,
                lengthChange: false
            });

            $('#no-real-estate').hide();
            $('#no-data').hide();
            $('#table-container').show();

        });
    });

    function GetRealEstates(realEstateId) {
        if (IsNullOrWhiteSpace($('#RealEstateAgencyId').val())) {
            $('#RealEstateId').empty();
            $('#RealEstateId').append($('<option>', { value: '' }).append('Selecione um corretora.'));
        }
        else {
            $.ajax({
                url: '");
            EndContext();
            BeginContext(10967, 59, false);
#line 226 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                 Write(Url.Action("GetRealEstatesByRealEstateAgencyId", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(11026, 387, true);
            WriteLiteral(@"',
                type: 'POST',
                datatype: 'JSON',
                data: { id: $('#RealEstateAgencyId').val() },
                success: function (data) {
                    $('#RealEstateId').empty();
                    if (data == false || data.length == 0) {
                        $('#RealEstateId').append($('<option>', { value: '' }).append('Nenhuma ' + ");
            EndContext();
            BeginContext(11414, 59, false);
#line 233 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                                                                              Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(11473, 1107, true);
            WriteLiteral(@" + ' encontrada.'));
                    }
                    if (data.length > 0) {
                        $('#RealEstateId').append($('<option>', { value: '' }).append('Selecione'));
                        for (var i = 0; i < data.length; i++) {
                            var companyName = IsNullOrWhiteSpace(data[i].razaoSocial) ? data[i].firstName + "" "" + data[i].lastName : data[i].razaoSocial;
                            var option = $('<option>', { value: data[i].companyId });
                            option.data('name', companyName);
                            option.append(companyName);
                            $('#RealEstateId').append(option);
                        }
                    }

                    if (realEstateId != null) {
                        $('#RealEstateId').val(realEstateId);
                        $('#button-charges').click();
                    }
                }
            });
        }
    }

    function Pagar(d) {
        if (!confir");
            WriteLiteral("m(\'Deseja realemente declarar como paga esta fatura?\')) return;\r\n\r\n        $.post(\'");
            EndContext();
            BeginContext(12581, 23, false);
#line 258 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
           Write(Url.Action("PayCharge"));

#line default
#line hidden
            EndContext();
            BeginContext(12604, 664, true);
            WriteLiteral(@"',
            {
                chargeId: d.chargeId,
                payedToken: d.payedToken
            },
            function (_d) {
                alert(_d.message);
                if (!_d.hasError) {
                    if ($('#pagar' + d.chargeId).length > 0) {
                        $('#pagar' + d.chargeId).remove();
                        $('#isPayed' + d.chargeId).text('Sim');
                        $('#excluir' + d.chargeId).remove();
                    }
                }
            }
        )
    }

    function Excluir(d) {
        if (!confirm('Deseja realemente excluir esta fatura?')) return;

        $.post('");
            EndContext();
            BeginContext(13269, 26, false);
#line 279 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
           Write(Url.Action("RemoveCharge"));

#line default
#line hidden
            EndContext();
            BeginContext(13295, 220, true);
            WriteLiteral("\',\r\n            {\r\n                chargeId: d.chargeId,\r\n            },\r\n            function (_d) {\r\n                alert(_d.message);\r\n                if (!_d.hasError) {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(13516, 31, false);
#line 286 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
                                       Write(Url.Action("Index", "Finances"));

#line default
#line hidden
            EndContext();
            BeginContext(13547, 374, true);
            WriteLiteral(@"?referenceMonth=' + $('#_CertificateManageReferenceMonth').val() + '&realEstateAgencyId=' + $('#RealEstateAgencyId').val() + '&realEstateId=' + $('#RealEstateId').val();
                    //if ($('#tr' + d.chargeId).length > 0) {
                    //    $('#tr' + d.chargeId).remove();
                    //}
                }
            }
        )
    }


");
            EndContext();
#line 296 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
     if (ViewBag.RealEstateId == null && (!string.IsNullOrWhiteSpace(ViewBag.ReferenceMonth) || ViewBag.RealEstateAgencyId != null)) {
        

#line default
#line hidden
            BeginContext(14071, 45, true);
            WriteLiteral("\r\n    $(\'#button-charges\').click();\r\n        ");
            EndContext();
#line 299 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
               
    }

#line default
#line hidden
            BeginContext(14132, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 301 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
     if(ViewBag.RealEstateAgencyId != null)
    {
        

#line default
#line hidden
            BeginContext(14198, 21, true);
            WriteLiteral("\r\n    GetRealEstates(");
            EndContext();
            BeginContext(14220, 20, false);
#line 304 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
              Write(ViewBag.RealEstateId);

#line default
#line hidden
            EndContext();
            BeginContext(14240, 12, true);
            WriteLiteral(");\r\n        ");
            EndContext();
#line 305 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Finances\Index.cshtml"
               
    }

#line default
#line hidden
            BeginContext(14268, 9, true);
            WriteLiteral("</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
