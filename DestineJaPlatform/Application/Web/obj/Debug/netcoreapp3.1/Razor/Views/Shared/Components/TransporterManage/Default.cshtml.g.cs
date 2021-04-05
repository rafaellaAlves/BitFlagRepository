#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0baa6c991eded3377a20fbb1781a87ba20ba23ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TransporterManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TransporterManage/Default.cshtml")]
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
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0baa6c991eded3377a20fbb1781a87ba20ba23ca", @"/Views/Shared/Components/TransporterManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TransporterManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Transporter.TransporterViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "transporter-manage-script", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<style type=\"text/css\">\n    .col-md-3, .col-md-4, .col-md-6, .col-md-9 {\n        margin-bottom: .5em !important;\n    }\n</style>\n\n<form id=\"form-transporter-manage\"");
            BeginWriteAttribute("action", " action=\"", 283, "\"", 332, 1);
#nullable restore
#line 11 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
WriteAttributeValue("", 292, Url.Action("ManageForm", "Transporter"), 292, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" method=\"post\">\n    <input type=\"hidden\" name=\"TransporterId\"");
            BeginWriteAttribute("value", " value=\"", 394, "\"", 422, 1);
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
WriteAttributeValue("", 402, Model.TransporterId, 402, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <div class=\"row\">\n        ");
#nullable restore
#line 14 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
    Write( await Component.InvokeAsync<Web.ViewComponents.Shared.CompanyViewComponent>(new { model = Model.CopyToEntity<DTO.Shared.CompanyBaseViewModel>() }) );

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-3\">\n            <div class=\"form-group\">\n                <label class=\"control-label\">Telefone Central</label>\n                <input class=\"form-control\" placeholder=\"Telefone Central\" name=\"Phone\"");
            BeginWriteAttribute("value", " value=\"", 834, "\"", 854, 1);
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
WriteAttributeValue("", 842, Model.Phone, 842, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            </div>\n");
            WriteLiteral("        </div>\n    </div>\n    <hr />\n    ");
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
Write( await Component.InvokeAsync<Web.ViewComponents.Shared.AddressViewComponent>(new { model = Model.CopyToEntity<DTO.Shared.AddressBaseViewModel>(), formId = "#form-transporter-manage" }) );

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</form>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0baa6c991eded3377a20fbb1781a87ba20ba23ca7039", async() => {
                WriteLiteral("\n    $(\'#transporter-save-button\').click(function () {\n    \n  \n         if (!validateInputs(\'form-transporter-manage\')) return;\n\n        $.post(\'");
#nullable restore
#line 36 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
           Write(Url.Action("ValidateTransporter"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', $('#form-transporter-manage').serializeArray(), function (d) {
            if (d.hasError) {
                bootbox.alert(d.message);
                return;
            }

            $('#form-transporter-manage').submit();
            
        });
    });
    $('#form-transporter-manage [name=""IEExempted""]').change(function () {
        if ($(this).is(':checked')) {
            $('#form-transporter-manage [name=""IE""]').val('ISENTO');
        } else {
            $('#form-transporter-manage [name=""IE""]').val('');
        }
    });

   $('#form-transporter-manage [name=""CNPJ""], #form-transporter-manage [name=""CPF""]').blur(function ()
   {
       $('.cnpj-error').remove();

       $.post('");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterManage\Default.cshtml"
          Write(Url.Action("ValidateTransporter"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', $('#form-transporter-manage').serializeArray(), function (d) {
           if (d.hasError) {
               if ($('#form-transporter-manage [name=""CNPJ""]').is(':visible')) {
                   $('#form-transporter-manage [name=""CNPJ""]').after('<small class=""text-danger cnpj-error"">' + d.message + '</small>');
               } else {
                   $('#form-transporter-manage [name=""CPF""]').after('<small class=""text-danger cnpj-error"">' + d.message + '</small>');
               }
           }
       });
   });

");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public Web.Helpers.DropDownListHelper dropDownListHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Transporter.TransporterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
