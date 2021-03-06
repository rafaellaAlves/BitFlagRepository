#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "512651a5976e03fbc888ca1b2349ade024f7fe9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AlternativeLogin), @"mvc.1.0.view", @"/Views/Account/AlternativeLogin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512651a5976e03fbc888ca1b2349ade024f7fe9a", @"/Views/Account/AlternativeLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AlternativeLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Account.LoginViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"login-wrapper wd-300 wd-xs-350 pd-25 pd-xs-40 bg-white\">\n        <img src=\"/Imagens/logo3.png\" style=\"width: 260px;\" class=\"mb-5\">\n        <form method=\"post\"");
            BeginWriteAttribute("action", " action=\"", 298, "\"", 338, 1);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
WriteAttributeValue("", 307, Url.Action("Login", "Account"), 307, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 10 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
             if (ViewData["ErrorMessage"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-danger\" role=\"alert\">");
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
                                                        Write(ViewData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\n                <input class=\"form-control\" name=\"Email\" id=\"Email\"");
            BeginWriteAttribute("value", " value=\"", 617, "\"", 637, 1);
#nullable restore
#line 15 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
WriteAttributeValue("", 625, Model.Email, 625, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Insira seu e-mail\">\n            </div><!-- form-group -->\n            <div class=\"form-group\">\n                <input class=\"form-control\" name=\"Password\" id=\"Password\" type=\"password\"");
            BeginWriteAttribute("value", " value=\"", 836, "\"", 859, 1);
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\AlternativeLogin.cshtml"
WriteAttributeValue("", 844, Model.Password, 844, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Insira sua senha\">\n");
            WriteLiteral("            </div><!-- form-group -->\n            <button type=\"submit\" class=\"btn btn-info btn-block\">Fazer Login</button>\n        </form>\n    </div><!-- login-wrapper -->");
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
