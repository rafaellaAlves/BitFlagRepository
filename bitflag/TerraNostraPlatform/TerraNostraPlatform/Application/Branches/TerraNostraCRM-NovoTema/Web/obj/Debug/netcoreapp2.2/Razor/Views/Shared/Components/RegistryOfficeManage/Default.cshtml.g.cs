#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a26b47edd365e1b8f1b5b516e03cde0aa307f474"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RegistryOfficeManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RegistryOfficeManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/RegistryOfficeManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_RegistryOfficeManage_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a26b47edd365e1b8f1b5b516e03cde0aa307f474", @"/Views/Shared/Components/RegistryOfficeManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RegistryOfficeManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.RegistryOffice.RegistryOfficeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("RegistryOfficeManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(53, 2038, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a26b47edd365e1b8f1b5b516e03cde0aa307f4744095", async() => {
                BeginContext(89, 50, true);
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"RegistryOfficeId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 139, "\"", 170, 1);
#line 4 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 147, Model.RegistryOfficeId, 147, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(171, 502, true);
                WriteLiteral(@" />
    <div id=""RegistryOfficeManageError"" style=""display: none;"" class=""row"">
        <div class=""col-md-12"">
            <div class=""alert alert-danger"">
                Por favor, preencha um nome para o cartório.
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-4"">
            <div class=""form-group"">
                <label class=""control-label"">Nome do Cartório</label>
                <input class=""form-control"" type=""text"" name=""Name""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 673, "\"", 692, 1);
#line 16 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 681, Model.Name, 681, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(693, 239, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Cidade</label>\r\n                <input class=\"form-control\" type=\"text\" name=\"City\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 932, "\"", 951, 1);
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 940, Model.City, 940, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(952, 236, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">UF</label>\r\n                <input class=\"form-control\" type=\"text\" name=\"State\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1188, "\"", 1208, 1);
#line 28 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 1196, Model.State, 1196, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1209, 240, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">País</label>\r\n                <input class=\"form-control\" type=\"text\" name=\"Country\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1449, "\"", 1471, 1);
#line 34 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 1457, Model.Country, 1457, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1472, 275, true);
                WriteLiteral(@" />
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label class=""control-label"">E-mail</label>
                <input class=""form-control"" type=""text"" name=""Email""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1747, "\"", 1767, 1);
#line 42 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 1755, Model.Email, 1755, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1768, 242, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Telefone</label>\r\n                <input class=\"form-control\" type=\"text\" name=\"Phone\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2010, "\"", 2030, 1);
#line 48 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
WriteAttributeValue("", 2018, Model.Phone, 2018, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2031, 53, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2091, 351, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    function RegistryOfficeManageFormSave(success, error) {
        $('#RegistryOfficeManageError').hide();

        if (!$('#RegistryOfficeManageForm input[name=""Name""]').val()) {
            $('#RegistryOfficeManageError').show();
            error();
            return false;
        }

        $.post('");
            EndContext();
            BeginContext(2443, 38, false);
#line 63 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\RegistryOfficeManage\Default.cshtml"
           Write(Url.Action("Manage", "RegistryOffice"));

#line default
#line hidden
            EndContext();
            BeginContext(2481, 121, true);
            WriteLiteral("\', $(\'#RegistryOfficeManageForm\').serializeArray(), function (d) {\r\n            success();\r\n        });\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.RegistryOffice.RegistryOfficeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
