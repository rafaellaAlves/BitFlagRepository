#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f2f2a5ac03aff58e81eba1f17242e5ee4539fb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Company_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Company/Default.cshtml")]
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
#nullable restore
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f2f2a5ac03aff58e81eba1f17242e5ee4539fb6", @"/Views/Shared/Components/Company/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Company_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.CompanyBaseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "company-script", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Web.Utils.TagHelperScriptCut __Web_Utils_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"col-md-3\">\n    <div class=\"form-group\">\n        <label class=\"control-label\">Tipo</label>\n        <select class=\"form-control\" id=\"company-type\">\n            <option ");
#nullable restore
#line 7 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
                Write(Model.IsCompany ? "selected" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" value=\"1\">Pessoa Juridica</option>\n            <option ");
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
                Write(!Model.IsCompany ? "selected" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(@" value=""2"">Pessoa Fisica</option>
        </select>
    </div>
</div>
<div class=""col-md-3 pj-area"">
    <div class=""form-group"">
        <label class=""control-label required"">CNPJ</label>
        <input class=""form-control cnpj"" placeholder=""CNPJ"" name=""CNPJ""");
            BeginWriteAttribute("value", " value=\"", 607, "\"", 626, 1);
#nullable restore
#line 15 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 615, Model.CNPJ, 615, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" onblur=""getCompanyBySintegra('[name=\'CNPJ\']', '[name=\'CompanyName\']', '[name=\'TradeName\']', '[name=\'IE\']', '[name=\'CEP\']', '[name=\'Address\']', '[name=\'Neighborhood\']', '[name=\'City\']', '[name=\'State\']', '[name=\'Complement\']', '[name=\'Number\']');"" />
    </div>
</div>

<div class=""col-md-3 pj-area"">
    <div class=""form-group"">
        <label class=""control-label required"">Razão Social</label>
        <input class=""form-control"" placeholder=""Razão Social"" name=""CompanyName""");
            BeginWriteAttribute("value", " value=\"", 1127, "\"", 1153, 1);
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 1135, Model.CompanyName, 1135, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n<div class=\"col-md-3 pj-area\">\n    <div class=\"form-group\">\n        <label class=\"control-label required\">Nome Fantasia</label>\n        <input class=\"form-control\" placeholder=\"Nome Fantasia\" name=\"TradeName\"");
            BeginWriteAttribute("value", " value=\"", 1384, "\"", 1408, 1);
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 1392, Model.TradeName, 1392, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n<div class=\"col-md-3 pj-area\">\n    <div class=\"form-group\">\n        <label id=\"ISENTO\" class=\"control-label\">Inscrição Estadual</label> <input type=\"checkbox\" name=\"IEExempted\" class=\"float mr-1 ml-2\" ");
#nullable restore
#line 33 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
                                                                                                                                         Write(Model.IEExempted.HasValue && Model.IEExempted.Value ? "checked" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" /> <label class=\"float checkbox\">ISENTO</label>\n        <input id=\"InscricaoEstadual\" class=\"form-control required\" placeholder=\"Inscrição Estadual\" name=\"IE\"");
            BeginWriteAttribute("value", " value=\"", 1862, "\"", 1879, 1);
#nullable restore
#line 34 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 1870, Model.IE, 1870, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n\n<div class=\"col-md-3 pf-area\">\n    <div class=\"form-group\">\n        <label class=\"control-label required\">CPF</label>\n        <input class=\"form-control cpf\" placeholder=\"CPF\" name=\"CPF\"");
            BeginWriteAttribute("value", " value=\"", 2089, "\"", 2107, 1);
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 2097, Model.CPF, 2097, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n<div class=\"col-md-3 pf-area\">\n    <div class=\"form-group\">\n        <label class=\"control-label required\">Nome Completo</label>\n        <input class=\"form-control\" placeholder=\"Nome Completo\" name=\"FullName\"");
            BeginWriteAttribute("value", " value=\"", 2337, "\"", 2360, 1);
#nullable restore
#line 47 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 2345, Model.FullName, 2345, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    </div>
</div>
<div class=""col-md-3 pf-area"">
    <div class=""form-group"">
        <label class=""control-label required"">Como gostaria de ser chamado(a)</label>
        <input class=""form-control"" placeholder=""Como gostaria de ser chamado(a)"" name=""NickName""");
            BeginWriteAttribute("value", " value=\"", 2626, "\"", 2649, 1);
#nullable restore
#line 53 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 2634, Model.NickName, 2634, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n<div class=\"col-md-3 pf-area\">\n    <div class=\"form-group\">\n        <label class=\"control-label required\">RG</label>\n        <input class=\"form-control\" placeholder=\"RG\" name=\"RG\"");
            BeginWriteAttribute("value", " value=\"", 2851, "\"", 2868, 1);
#nullable restore
#line 59 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Company\Default.cshtml"
WriteAttributeValue("", 2859, Model.RG, 2859, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f2f2a5ac03aff58e81eba1f17242e5ee4539fb610675", async() => {
                WriteLiteral(@"
    $('#company-type').on('change', function () {
        if ($(this).val() == '1') {
            $('.pf-area input, .pf-area select').val('');

            $('.pf-area').hide();
            $('.pj-area').show();
        } else {
            $('.pj-area input, .pj-area select').val('');

            $('.pj-area').hide();
            $('.pf-area').show();
        }
    }).change();
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.CompanyBaseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
