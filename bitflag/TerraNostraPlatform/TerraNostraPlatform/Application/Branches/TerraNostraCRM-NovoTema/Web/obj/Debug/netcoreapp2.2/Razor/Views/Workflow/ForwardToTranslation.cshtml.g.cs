#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\ForwardToTranslation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bec2faf87f6aa04ef6820c1bc78b33fc747968f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workflow_ForwardToTranslation), @"mvc.1.0.view", @"/Views/Workflow/ForwardToTranslation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workflow/ForwardToTranslation.cshtml", typeof(AspNetCore.Views_Workflow_ForwardToTranslation))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bec2faf87f6aa04ef6820c1bc78b33fc747968f4", @"/Views/Workflow/ForwardToTranslation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workflow_ForwardToTranslation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\ForwardToTranslation.cshtml"
  
    ViewData["Title"] = "Encaminhamento para Tradução";

#line default
#line hidden
            BeginContext(64, 1229, true);
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


<h1 class=""mb-2""><small>Encaminhamento para Tradução</small></h1>
<div class=""card"">
    <div class=""card-body"">
        <table class=""table table-bordered table-condensed"" style=""font-size:11px"">
            <thead>
                <tr>
                    <td style=""text-align: center""><b>Grau de Parentesco</b></td>
                    <td style=""text-align: center""><b>Nome</b></td>
                    <td style=""text-align: center""><b>Certidão</b></td>
                    <td");
            WriteLiteral(" style=\"text-align: center\"><b>Data de Envio</b></td>\r\n                    <td style=\"text-align: center\"><b>Data de Recebimento</b></td>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
            BeginContext(1353, 2012, true);
            WriteLiteral(@"
                <tr>
                    <td rowspan=""3"" style=""text-align: center"" id=""Description"" name=""description"">Sarah Reggiani / Pai</td>
                    <td style=""text-align: center;"" id=""FullName"" name=""FullName"">Dalvo Paulino de Carvalho</td>
                    <td style=""text-align: center;"" id=""BirthDocument"" name=""BirthDocument"">Nascimento</td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
                </tr>
                <tr>
                    <td style=""text-align: center"" id=""Spouse"" name=""Spouse"">Conjuge: Roseli R. Reggiani</td>
                    <td style=""text-align: center"" id=""MarriageDocument"" name=""MarriageDocument"">Casamento</td>
                    ");
            WriteLiteral(@"<td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
                </tr>
                <tr>
                    <td style=""text-align: center"" id=""FullName"" name=""FullName"">Dalvo Paulino de Carvalho</td>
                    <td style=""text-align: center"" id=""DeathDocument"" name=""DeathDocument"">Óbito</td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                    <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
                </tr>
");
            EndContext();
            BeginContext(3417, 208, true);
            WriteLiteral("                <tr data-docusign-id=\"item.CompanyDocuSignId\" data-company-id=\"item.CompanyId\" data-reference-date=\"item.ReferenceDateISO\">\r\n                    <td colspan=\"13\"></td>\r\n                </tr>\r\n");
            EndContext();
            BeginContext(3714, 1322, true);
            WriteLiteral(@"            <tr>
                <td rowspan=""2"" style=""text-align: center"" id=""Applicant"" name=""Applicant"">Requerente</td>
                <td style=""text-align: center"" id=""FullName"" name=""FullName"">Sarah Reggiani de Carvalho</td>
                <td style=""text-align: center"" id=""BirthDocument"" name=""BirthDocument"">Nascimento</td>
                <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
            </tr>
            <tr>
                <td style=""text-align: center;"" id=""Spouse"" name=""Spouse"">Conjuge: Bruno de Z. Amabile</td>
                <td style=""text-align: center"" id=""MarriageDocument"" name=""MarriageDocument"">Casamento</td>
                <td style=""text-align: center""><label data-value=""Informar""");
            WriteLiteral(@" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
            </tr>
");
            EndContext();
            BeginContext(5088, 89, true);
            WriteLiteral("                <tr>\r\n                    <td colspan=\"13\"></td>\r\n                </tr>\r\n");
            EndContext();
            BeginContext(5271, 984, true);
            WriteLiteral(@"            <tr>
                <td style=""text-align: center"" id=""CNN"" name=""CNN"">CNN</td>
                <td style=""text-align: center""><label data-value=""Dalvo Paulino de Carvalho"" class=""editable-label"" id=""FullNameItalian"" name=""FullNameItalian"">Dalvo Paulino de Carvalho</label></td>
                <td style=""text-align: center;"" id=""CNNDocument"" name=""CNNDocument"">CNN</td>
                <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationSendDate"" name=""TranslationSendDate"">Informar</label></td>
                <td style=""text-align: center""><label data-value=""Informar"" class=""editable-label"" id=""TranslationReceiptDate"" name=""TranslationReceiptDate"">Informar</label></td>
            </tr>
            </tbody>
        </table>
        &nbsp;
        <div class=""row"" style=""width: 100%; margin: 0;"">
            <div class=""col-md-6"">
                <a class=""btn btn-secondary float-left"" target=""_blank""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6255, "\"", 6298, 1);
#line 100 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workflow\ForwardToTranslation.cshtml"
WriteAttributeValue("", 6262, Url.Action("GetSteps", "Workbench"), 6262, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6299, 1428, true);
            WriteLiteral(@">Voltar&nbsp;<i class=""fas fa-external-link-alt""></i></a>
            </div>
            <div class=""col-md-6"">
                <button onclick=""PreviousStep()"" type=""button"" class=""btn btn-success float-right"">Salvar</button>
                <button onclick=""PreviousStep()"" style=""margin-left: 40px; margin-right:40px"" type=""button"" class=""btn btn-light float-right"">Imprimir</button>
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
    }

    function initToLabel() {
        $('.to-label').off('blur').off('keypress');

        $('.to-label').blur(fun");
            WriteLiteral(@"ction () {
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
