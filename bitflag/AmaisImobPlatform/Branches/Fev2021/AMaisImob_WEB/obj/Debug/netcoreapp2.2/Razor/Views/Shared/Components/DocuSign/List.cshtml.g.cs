#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f19a66b94961d48591602c70ced0c1bf02127e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DocuSign_List), @"mvc.1.0.view", @"/Views/Shared/Components/DocuSign/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/DocuSign/List.cshtml", typeof(AspNetCore.Views_Shared_Components_DocuSign_List))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f19a66b94961d48591602c70ced0c1bf02127e1", @"/Views/Shared/Components/DocuSign/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DocuSign_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.Shared.BaseViewModel<List<CompanyDocuSignViewModel>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "docusign-index-list", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AMaisImob_WEB.Helpers.Javascript.TagHelperScriptCut __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(82, 303, true);
            WriteLiteral(@"
<table class=""table table-striped table-bordered table-condensed"">
    <thead>
        <tr>
            <td>Imobili??ria</td>
            <td>M??s/Ano</td>
            <td>Categoria</td>
            <td>Benef??cio</td>
            <td>Custo por utiliza????o</td>
            <td>Qtde. de Contratos ");
            EndContext();
            BeginContext(387, 183, false);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                               Write(User.IsInRole("Administrator")? Html.Raw("<span id=\"QtdContratosInfo\" title=\"D?? um clique duplo na c??lula para edit??-la.\"><i class=\"fa fa-info-circle\"></i></span>") : (object)"");

#line default
#line hidden
            EndContext();
            BeginContext(571, 78, true);
            WriteLiteral("</td>\r\n            <td>Fatura</td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
         foreach (var item in Model.ViewModel)
        {

#line default
#line hidden
            BeginContext(708, 34, true);
            WriteLiteral("            <tr data-docusign-id=\"");
            EndContext();
            BeginContext(743, 22, false);
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                             Write(item.CompanyDocuSignId);

#line default
#line hidden
            EndContext();
            BeginContext(765, 19, true);
            WriteLiteral("\" data-company-id=\"");
            EndContext();
            BeginContext(785, 14, false);
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                                                                       Write(item.CompanyId);

#line default
#line hidden
            EndContext();
            BeginContext(799, 23, true);
            WriteLiteral("\" data-reference-date=\"");
            EndContext();
            BeginContext(823, 21, false);
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                                                                                                             Write(item.ReferenceDateISO);

#line default
#line hidden
            EndContext();
            BeginContext(844, 24, true);
            WriteLiteral("\">\r\n                <td>");
            EndContext();
            BeginContext(869, 21, false);
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
               Write(item.CompanyTradeName);

#line default
#line hidden
            EndContext();
            BeginContext(890, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(918, 26, false);
#line 20 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
               Write(item.ReferenceDateFormated);

#line default
#line hidden
            EndContext();
            BeginContext(944, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(972, 24, false);
#line 21 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
               Write(item.CategoryDescription);

#line default
#line hidden
            EndContext();
            BeginContext(996, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1024, 10, false);
#line 22 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
               Write(item.Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(1034, 30, true);
            WriteLiteral("</td>\r\n                <td>R$ ");
            EndContext();
            BeginContext(1065, 18, false);
#line 23 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                  Write(item.PriceFormated);

#line default
#line hidden
            EndContext();
            BeginContext(1083, 46, true);
            WriteLiteral("</td>\r\n                <td><label data-value=\"");
            EndContext();
            BeginContext(1130, 11, false);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                                  Write(item.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1141, 25, true);
            WriteLiteral("\" class=\"editable-label\">");
            EndContext();
            BeginContext(1167, 11, false);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                                                                       Write(item.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1178, 48, true);
            WriteLiteral(" CONTRATOS</label></td>\r\n                <td>R$ ");
            EndContext();
            BeginContext(1227, 18, false);
#line 25 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
                  Write(item.TotalFormated);

#line default
#line hidden
            EndContext();
            BeginContext(1245, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 27 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
        }

#line default
#line hidden
            BeginContext(1282, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
         if (Model.ViewModel.Count == 0)
        {

#line default
#line hidden
            BeginContext(1335, 118, true);
            WriteLiteral("            <tr>\r\n                <td colspan=\"7\" class=\"text-center\">Nenhum item encontrado</td>\r\n            </tr>\r\n");
            EndContext();
#line 33 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
        }

#line default
#line hidden
            BeginContext(1464, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
#line 37 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
 if (User.IsInRole("Administrator"))
{

#line default
#line hidden
            BeginContext(1531, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1535, 1734, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f19a66b94961d48591602c70ced0c1bf02127e111651", async() => {
                BeginContext(1642, 1250, true);
                WriteLiteral(@"
    $(function () {
        initEditableLabel();
        $('#QtdContratosInfo').tooltip();
    });

    function initEditableLabel() {
        $('.editable-label').off('click');

        $("".editable-label"").click(function () {
            var input = $('<input>', { class: 'form-control to-label number', value: $(this).data('value') });
            $(this).replaceWith(input);
            $(input).focus();

            _MaskData();
            initToLabel();
        });
    }

    function initToLabel() {
        $('.to-label').off('blur').off('keypress');

        $('.to-label').blur(function () {
            saveCompanyDocuSign(this);
            toLabel(this);
        }).keypress(function (e) {
            if (e.which == 13) {
                saveCompanyDocuSign(this);
                toLabel(this);
            }
        });
    }

    function toLabel(sel) {
        var value = $(sel).val();
        if (isNaN(value) || !value) value = 0;
        $(sel).replaceWith($('<l");
                WriteLiteral("abel>\', { class: \'editable-label\', \'data-value\': value }).text(value + \' CONTRATOS\'));\r\n        initEditableLabel();\r\n    }\r\n\r\n    function saveCompanyDocuSign(sel) {\r\n        var tr = $(sel).closest(\'tr\');\r\n\r\n        $.post(\'");
                EndContext();
                BeginContext(2893, 45, false);
#line 82 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
           Write(Url.Action("SaveCompanyDocuSign", "DocuSign"));

#line default
#line hidden
                EndContext();
                BeginContext(2938, 322, true);
                WriteLiteral(@"', { amount: $(sel).val(), companyId: $(tr).data('company-id'), docuSignId: $(tr).data('docusign-id'), referenceDate: $(tr).data('reference-date') }, function (d) {
            $(tr).data('docusign-id', d.companyDocuSignId);

            $(tr).find('td:last-child').text('R$ ' + d.totalPrice);
        });
    }
    ");
                EndContext();
            }
            );
            __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut = CreateTagHelper<global::AMaisImob_WEB.Helpers.Javascript.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 39 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
__AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut.CutJavascriptTag = Model.CutScript;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-cut-javascript-tag", __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut.CutJavascriptTag, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3269, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 89 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\List.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.Shared.BaseViewModel<List<CompanyDocuSignViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
