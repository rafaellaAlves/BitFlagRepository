#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9ae3699969170ae0c1654ea98c26c4aa1bdab45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Login.cshtml", typeof(AspNetCore.Views_Account_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9ae3699969170ae0c1654ea98c26c4aa1bdab45", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Account.LoginViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom:1em;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_LayoutClean.cshtml";

#line default
#line hidden
            BeginContext(130, 223, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-6 offset-3\">\r\n        <div class=\"card auth-card\">\r\n            <div class=\"form-side\" style=\"width: 100% !important;\">\r\n                <div class=\"text-center\">\r\n                    ");
            EndContext();
            BeginContext(353, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c9ae3699969170ae0c1654ea98c26c4aa1bdab455947", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(435, 87, true);
            WriteLiteral("\r\n                </div>\r\n                <h6 class=\"mb-4\">Login</h6>\r\n                ");
            EndContext();
            BeginContext(522, 948, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9ae3699969170ae0c1654ea98c26c4aa1bdab457457", async() => {
                BeginContext(583, 146, true);
                WriteLiteral("\r\n                    <label class=\"form-group has-float-label mb-4\">\r\n                        <input class=\"form-control\" name=\"Email\" id=\"Email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 729, "\"", 749, 1);
#line 17 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
WriteAttributeValue("", 737, Model.Email, 737, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(750, 244, true);
                WriteLiteral(">\r\n                        <span>E-mail</span>\r\n                    </label>\r\n                    <label class=\"form-group has-float-label mb-4\">\r\n                        <input class=\"form-control\" name=\"Password\" id=\"Password\" type=\"password\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 994, "\"", 1017, 1);
#line 21 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
WriteAttributeValue("", 1002, Model.Password, 1002, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1018, 445, true);
                WriteLiteral(@">
                        <span>Password</span>
                    </label>
                    <div class=""d-flex justify-content-between align-items-center"">
                        <a href=""javascript:void(0)"" data-toggle=""modal"" data-target=""#forgetPasswordModal"">Esqueceu a senha?</a>
                        <button class=""btn btn-primary btn-lg btn-shadow"" type=""submit"">ENTRAR</button>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 15 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
AddHtmlAttributeValue("", 550, Url.Action("Login", "Account"), 550, 31, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1470, 58, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
#line 33 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
 if (ViewData["ErroEmail"] != null)
{
    string messageFile = (string)ViewData["ErroEmail"];

#line default
#line hidden
            BeginContext(1625, 89, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n        $(\'#Email\').after(\'<div class=\"text-danger\">");
            EndContext();
            BeginContext(1715, 11, false);
#line 37 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
                                               Write(messageFile);

#line default
#line hidden
            EndContext();
            BeginContext(1726, 26, true);
            WriteLiteral("</div>\');\r\n    </script>\r\n");
            EndContext();
#line 39 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
}

#line default
#line hidden
#line 40 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
 if (ViewData["ErroPassword"] != null)
{
    string messageFile = (string)ViewData["ErroPassword"];

#line default
#line hidden
            BeginContext(1858, 92, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n        $(\'#Password\').after(\'<div class=\"text-danger\">");
            EndContext();
            BeginContext(1951, 11, false);
#line 44 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
                                                  Write(messageFile);

#line default
#line hidden
            EndContext();
            BeginContext(1962, 26, true);
            WriteLiteral("</div>\');\r\n    </script>\r\n");
            EndContext();
#line 46 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
}

#line default
#line hidden
#line 47 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
 if (ViewData["InactiveUser"] != null)
{
    string messageFile = (string)ViewData["InactiveUser"];

#line default
#line hidden
            BeginContext(2094, 89, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n        $(\'#Email\').after(\'<div class=\"text-danger\">");
            EndContext();
            BeginContext(2184, 11, false);
#line 51 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
                                               Write(messageFile);

#line default
#line hidden
            EndContext();
            BeginContext(2195, 26, true);
            WriteLiteral("</div>\');\r\n    </script>\r\n");
            EndContext();
#line 53 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
}

#line default
#line hidden
            BeginContext(2224, 2473, true);
            WriteLiteral(@"
<div class=""modal fade"" id=""forgetPasswordModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-md"" style=""min-width:300px"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Recupera????o de senha</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""alertSuccessPasswordRecovery"" class=""alert alert-success fade show text-center"" role=""alert"" style=""display: none;"">
                    <strong>Um email foi enviado para voc??, verifique sua caixa de entrada!</strong>
                </div>
                <label>Digite seu e-mail no campo abaixo.</label>
                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" placeholder=""E-mail"" ");
            WriteLiteral(@"id=""recoveryMail"" />
                </div>
                <div class=""form-group"">
                    <button type=""submit"" aria-label=""Close"" class=""btn btn-secondary"" data-dismiss=""modal"">Fechar</button>
                    <button type=""button"" class=""btn btn-primary float-right"" id=""SendMailButton"">Enviar e-mail</button>
                </div>
                <script type=""text/javascript"">
                    $('#SendMailButton').click(function () {

                        var hasError = false;
                        $('#forgetPasswordModal .text-danger').remove();

                        if (IsNullOrWhiteSpace($('#recoveryMail').val())) {
                            hasError = true;
                            $('#recoveryMail').after('<div class=""text-danger"">Digite um e-mail!</div>');
                        }

                        if (!hasError) {
                            SendMail();
                        }
                    });
                </script>
        ");
            WriteLiteral(@"    </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    $('#forgetPasswordModal').on('shown.bs.modal', function () {
        $('#recoveryMail').val("""");
        $('#forgetPasswordModal .text-danger').remove();
        $('#alertSuccessPasswordRecovery').hide();
    });

    function SendMail() {
        var d = { 'mail': $('#recoveryMail').val() };
        $.ajax({
            url: '");
            EndContext();
            BeginContext(4698, 41, false);
#line 107 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Account\Login.cshtml"
             Write(Url.Action("SendRecoveryMail", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(4739, 613, true);
            WriteLiteral(@"',
            type: 'POST',
            dataType: 'json',
            data: d,
            success: function (data) {
                $('#recoveryMail').val("""");
                if (data.hasError) {
                    $('#recoveryMail').after('<div class=""text-danger"">' + data.message + '</div>');
                    $('#alertSuccessPasswordRecovery').hide();
                }
                else {
                    $('#forgetPasswordModal .text-danger').remove();
                    $('#alertSuccessPasswordRecovery').show();
                }
            }
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Account.LoginViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
