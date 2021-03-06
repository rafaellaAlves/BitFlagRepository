#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ServiceEmail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5d3fd2ee58f39b246c2328582a543f00ea62876"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ServiceEmail_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ServiceEmail/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5d3fd2ee58f39b246c2328582a543f00ea62876", @"/Views/Shared/Components/ServiceEmail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ServiceEmail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Service.ServiceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "service-email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<form id=\"service-email\"");
            BeginWriteAttribute("action", " action=\"", 61, "\"", 70, 0);
            EndWriteAttribute();
            WriteLiteral(" method=\"post\">\n    <input type=\"hidden\" name=\"ServiceId\"");
            BeginWriteAttribute("value", " value=\"", 128, "\"", 152, 1);
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ServiceEmail\Default.cshtml"
WriteAttributeValue("", 136, Model.ServiceId, 136, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <div class=\"alert alert-warning alert-dismissible fade show\" id=\"service-email-sended-alert\" role=\"alert\" ");
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ServiceEmail\Default.cshtml"
                                                                                                          Write(!Model.AcceptTermEmailSended? Html.Raw("style=\"display:none\"") : (object)"");

#line default
#line hidden
#nullable disable
            WriteLiteral(@">
        Esta <b>Ordem de Servi??o</b> j?? foi enviado por e-mail.
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
    <div class=""row mb-2"">
        <div class=""col"">
            <label class=""text-warning"">No caso de envio para m??ltiplos e-mails utilize <b>; (ponto e v??rgula)</b> para separar um e-mail de outro.</label>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <label class=""required"">Destinat??rio</label>
            <input class=""form-control"" placeholder=""Destinat??rio"" name=""To""");
            BeginWriteAttribute("value", " value=\"", 995, "\"", 1022, 1);
#nullable restore
#line 19 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ServiceEmail\Default.cshtml"
WriteAttributeValue("", 1003, Model.ContactEmail, 1003, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
        </div>
        <div class=""col"">
            <label>C??pia</label>
            <input class=""form-control"" placeholder=""C??pia"" name=""ReplyTo"" />
        </div>
        <div class=""col"">
            <label>C??pia Oculta</label>
            <input class=""form-control"" placeholder=""C??pia Oculta"" name=""BCC"" />
        </div>
        <div class=""col-2"">
            <label>&nbsp;</label>
            <button class=""btn btn-success"" type=""button"" onclick=""sendOSEmail()""><i class=""simple-icon-envelope-letter""></i>&nbsp;Enviar</button>
        </div>
    </div>
</form>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5d3fd2ee58f39b246c2328582a543f00ea628767151", async() => {
                WriteLiteral("\n    function sendOSEmail() {\n     \n        if (!validateInputs(\'service-email\')) return;\n\n        $.post(\'");
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ServiceEmail\Default.cshtml"
           Write(Url.Action("SendServiceEmail", "Service"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', $('#service-email').serializeArray(), function (d) {
            bootbox.alert(d.message);

            if (d.success) {
                $('#service-email-sended-alert').show();

                if (typeof emailSendedCallback == 'function') emailSendedCallback();
            }
        });
    }
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
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Service.ServiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
