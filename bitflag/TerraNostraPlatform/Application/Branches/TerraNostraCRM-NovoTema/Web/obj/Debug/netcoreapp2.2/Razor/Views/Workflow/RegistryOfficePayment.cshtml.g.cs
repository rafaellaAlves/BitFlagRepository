#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\RegistryOfficePayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40a5be624980448701cd37720f7055219d6355a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workflow_RegistryOfficePayment), @"mvc.1.0.view", @"/Views/Workflow/RegistryOfficePayment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workflow/RegistryOfficePayment.cshtml", typeof(AspNetCore.Views_Workflow_RegistryOfficePayment))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40a5be624980448701cd37720f7055219d6355a2", @"/Views/Workflow/RegistryOfficePayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workflow_RegistryOfficePayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\RegistryOfficePayment.cshtml"
  
    ViewData["Title"] = "Efetuar Pagamento de Cartório";

#line default
#line hidden
            BeginContext(65, 1723, true);
            WriteLiteral(@"
<style>
    .to-label {
        height: 30px;
    }

    .select {
        font-size: 11px;
        width: 70px;
        height: 30px;
    }

    #Description, #FullName, #BirthDate, #BirthDocument, #MarriageDate, #MarriageDocument, #DeathDate, #DeathDocument, #CNN, #CNNDocument, #Spouse, #Applicant {
        color: red;
        font-weight: bolder;
    }

    #RegistryOfficeId, #Book, #Page, #Term, #FullNameItalian, #CNNDate {
        color: blue;
        font-weight: bolder;
    }
</style>


<h1 class=""mb-2""><small>Efetuar Pagamento de Cartório</small></h1>
<div class=""card"">
    <div class=""card-body"">
        <table class=""table table-bordered table-condensed"" style=""font-size:11px"">
            <thead>
                <tr>
                    <td><b>Grau de Parentesco</b></td>
                    <td style=""text-align: center""><b>Nome</b></td>
                    <td style=""text-align: center""><b>Certidão</b></td>
                    <td style=""text-align: center""><b>Dat");
            WriteLiteral(@"a</b></td>
                    <td style=""text-align: center""><b>Cartório / Cidade de Registro</b></td>
                    <td style=""text-align: center""><b>Valor da Certidão (R$)</b></td>
                    <td style=""text-align: center""><b>Correio (R$)</b></td>
                    <td style=""text-align: center""><b>Valor do Pagamento (R$)</b></td>
                    <td style=""text-align: center""><b>Data de Pagamento</b></td>
                    <td style=""text-align: center""><b>Data de envio</b></td>
                    <td style=""text-align: center""><b>Chegada da Certidão</b></td>
                    <td></td>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
            BeginContext(1848, 605, true);
            WriteLiteral(@"
                <tr>
                    <td rowspan=""3"" style=""text-align: center"" id=""Description"" name=""description"">Sarah Reggiani / Pai</td>
                    <td id=""FullName"" name=""FullName"">Dalvo Paulino de Carvalho</td>
                    <td style=""text-align: center;"" id=""BirthDocument"" name=""BirthDocument"">Nascimento</td>
                    <td style=""text-align: center"" id=""BirthDate"" name=""BirthDate"">13/10/1943</td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px;"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(2453, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a26172", async() => {
                BeginContext(2461, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2479, 1525, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
   ");
            WriteLiteral(@"             <tr>
                    <td id=""Spouse"" name=""Spouse"">Conjuge: Roseli R. Reggiani</td>
                    <td style=""text-align: center"" id=""MarriageDocument"" name=""MarriageDocument"">Casamento</td>
                    <td style=""text-align: center"" id=""MarriageDate"" name=""MarriageDate"">05/08/1947</td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px; text-align: center"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(4004, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a28993", async() => {
                BeginContext(4012, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4030, 1511, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
   ");
            WriteLiteral(@"             <tr>
                    <td id=""FullName"" name=""FullName"">Dalvo Paulino de Carvalho</td>
                    <td style=""text-align: center"" id=""DeathDocument"" name=""DeathDocument"">Óbito</td>
                    <td style=""text-align: center"" id=""DeathDate"" name=""DeathDate"">27/03/2004</td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px; text-align: center"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(5541, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a211800", async() => {
                BeginContext(5549, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5567, 1021, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
");
            EndContext();
            BeginContext(6640, 208, true);
            WriteLiteral("                <tr data-docusign-id=\"item.CompanyDocuSignId\" data-company-id=\"item.CompanyId\" data-reference-date=\"item.ReferenceDateISO\">\r\n                    <td colspan=\"13\"></td>\r\n                </tr>\r\n");
            EndContext();
            BeginContext(6937, 589, true);
            WriteLiteral(@"                <tr>
                    <td rowspan=""2"" style=""text-align: center"" id=""Applicant"" name=""Applicant"">Requerente</td>
                    <td id=""FullName"" name=""FullName"">Sarah Reggiani de Carvalho</td>
                    <td style=""text-align: center"" id=""BirthDocument"" name=""BirthDocument"">Nascimento</td>
                    <td style=""text-align: center"" id=""BirthDate"" name=""BirthDate"">05/05/1988</td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px;"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(7526, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a215110", async() => {
                BeginContext(7534, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7552, 1526, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
   ");
            WriteLiteral(@"             <tr>
                    <td id=""Spouse"" name=""Spouse"">Conjuge: Bruno de Z. Amabile</td>
                    <td style=""text-align: center"" id=""MarriageDocument"" name=""MarriageDocument"">Casamento</td>
                    <td style=""text-align: center"" id=""MarriageDate"" name=""MarriageDate"">01/05/2016</td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px; text-align: center"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(9078, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a217933", async() => {
                BeginContext(9086, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9104, 1021, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
");
            EndContext();
            BeginContext(10177, 89, true);
            WriteLiteral("                <tr>\r\n                    <td colspan=\"13\"></td>\r\n                </tr>\r\n");
            EndContext();
            BeginContext(10360, 723, true);
            WriteLiteral(@"                <tr>
                    <td style=""text-align: center"" id=""CNN"" name=""CNN"">CNN</td>
                    <td style=""text-align: center""><label data-value=""Dalvo Paulino de Carvalho"" class=""editable-label"" id=""FullNameItalian"" name=""FullNameItalian"">Dalvo Paulino de Carvalho</label></td>
                    <td style=""text-align: center;"" id=""CNNDocument"" name=""CNNDocument"">CNN</td>
                    <td style=""text-align: center""><label data-value=""05/09/1963"" class=""editable-label"" id=""CNNDate"" name=""CNNDate"">05/09/1963</label></td>
                    <td style=""text-align: center""> <select style=""font-size: 11px; height: 30px;"" class=""form-control"" id=""RegistryOfficeId"" name=""RegistryId"">");
            EndContext();
            BeginContext(11083, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a5be624980448701cd37720f7055219d6355a221262", async() => {
                BeginContext(11091, 9, true);
                WriteLiteral("Selecione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(11109, 1243, true);
            WriteLiteral(@"</select></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""CertificateValue"" name=""CertificateValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""Mail"" name=""Mail"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentValue"" name=""PaymentValue"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""PaymentDate"" name=""PaymentDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""SendDate"" name=""SendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""ArrivalOfCertificate"" name=""ArrivalOfCertificate"">Informar</label></td>
                </tr>
   ");
            WriteLiteral("         </tbody>\r\n        </table>\r\n        &nbsp;\r\n        <div class=\"row\" style=\"width: 100%; margin: 0;\">\r\n            <div class=\"col-md-6\">\r\n                <a class=\"btn btn-secondary float-left\" target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 12352, "\"", 12395, 1);
#line 141 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\RegistryOfficePayment.cshtml"
WriteAttributeValue("", 12359, Url.Action("GetSteps", "Workbench"), 12359, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(12396, 1551, true);
            WriteLiteral(@">Voltar&nbsp;<i class=""fas fa-external-link-alt""></i></a>
            </div>
            <div class=""col-md-6"">
                <button onclick=""PreviousStep()"" type=""button"" class=""btn btn-success float-right"">Salvar</button>
                <button onclick=""PreviousStep()"" style=""margin-left: 40px; margin-right:40px"" type=""button"" class=""btn btn-light float-right"">Imprimir</button>
                <button onclick=""PreviousStep()"" type=""button"" class=""btn btn-info float-right"">Cadastrar Cartório</button>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    $(function () {
        initEditableLabel();
    });

    function initEditableLabel() {
        $('.editable-label').off('click');

        $("".editable-label"").click(function () {
            var input = $('<input>', { class: 'form-control to-label', value: $(this).data('value') });
            $(this).replaceWith(input);
            $(input).focus();


            initToLabel();
        });
");
            WriteLiteral(@"    }

    function initToLabel() {
        $('.to-label').off('blur').off('keypress');

        $('.to-label').blur(function () {
            toLabel(this);
        }).keypress(function (e) {
            if (e.which == 13) {
                toLabel(this);
            }
        });
    }

    function toLabel(sel) {
        var value = $(sel).val();

        $(sel).replaceWith($('<label>', { class: 'editable-label', 'data-value': value }).text(value));
        initEditableLabel();
    }

</script>

");
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
