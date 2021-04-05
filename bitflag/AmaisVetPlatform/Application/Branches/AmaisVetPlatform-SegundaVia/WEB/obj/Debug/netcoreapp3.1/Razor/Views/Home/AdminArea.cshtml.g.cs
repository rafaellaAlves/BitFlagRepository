#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Home\AdminArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcf2e503985c4f83e8a40392ca40bffabe5cca72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AdminArea), @"mvc.1.0.view", @"/Views/Home/AdminArea.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf2e503985c4f83e8a40392ca40bffabe5cca72", @"/Views/Home/AdminArea.cshtml")]
    public class Views_Home_AdminArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/Utils.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Home\AdminArea.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Area do Administrador";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style type=\"text/css\">\r\n        #menu {\r\n            background-image: url(\'");
#nullable restore
#line 8 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Home\AdminArea.cshtml"
                              Write(Url.Content("~/assets/image/home-background-cover.jpeg"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            background-repeat: no-repeat;\r\n            background-size: cover;\r\n            min-height: 100%;\r\n        }\r\n        .form_error{\r\n            color: red;\r\n            display: none;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <div id=\"menu\" class=\"card\">\r\n            <div class=\"card-body\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12 text-center\">\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 39 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Home\AdminArea.cshtml"
                   Write(await Html.PartialAsync("../Shared/_LayoutMenuHome.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""mb-2"">
                    <h2>
                        Confirmação de Acesso
                    </h2>
                </div>
                <hr />
            </div>
        </div>
        <form id=""FormLogin"" method=""post""");
            BeginWriteAttribute("action", " action=\"", 1967, "\"", 1976, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <div class=""form-group"">
                                        <label class=""control-label "">Login</label>
                                        <input name=""Username"" id=""Username"" type=""text"" class=""form-control "" />
                                        <span class=""form_error"">Campo obrigatório</span>
                                        <span class=""form_error"" id=""invalid-user"">Digite um nome entre 5 e 20 caracteres</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <div class=""f");
            WriteLiteral(@"orm-group"">
                                        <label class=""control-label"">Senha</label>
                                        <input name=""Password"" id=""Password"" type=""password"" class=""form-control"" />
                                        <span class=""form_error"">Campo obrigatório</span>
                                        <span class=""form_error"" id=""invalid-pass"">A senha deve ter 8 caracteres</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <div class=""btn-group"">
                                        <button type=""submit"" onclick=""return validateLogin()"" class=""btn btn-success"">Acessar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </d");
            WriteLiteral("iv>\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcf2e503985c4f83e8a40392ca40bffabe5cca728030", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"">
        function validateLogin() {
            var user = $('#Username').val();
            var senha = $('#Password').val();
            var cont = 0;

            //USER
            if (user == '') {
                $('#Username').next().show();
                $('#invalid-user').hide();
                focus('#Username');
                cont = cont + 1;
            } else if (user.length < 5 || user.length > 20) {
                $('#invalid-user').show();
                $('#Username').next().hide();
                focus('#Username');
                cont = cont + 1;
            } else {
                forceFocus('#Username');
                $('#Username').next().hide();
                $('#invalid-user').hide();
            }

            //SENHA
            if (senha == '') {
                $('#Password').next().show();
                $('#invalid-pass').hide();
                focus('#Password');
                cont = cont + 1;
  ");
                WriteLiteral(@"          } else if (!senha.length == 8) {
                $('#invalid-pass').show();
                $('#Password').next().hide();
                focus('#Password');
                cont = cont + 1;
            } else {
                forceFocus('#Password');
                $('#Password').next().hide();
                $('#invalid-pass').hide();
            }

            if (cont = 0) {
                $(""#FormLogin"").submit();
            } else {
                return false;
            }
        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591