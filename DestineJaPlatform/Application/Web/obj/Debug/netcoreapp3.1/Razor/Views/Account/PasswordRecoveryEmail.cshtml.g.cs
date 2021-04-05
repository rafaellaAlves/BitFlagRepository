#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\PasswordRecoveryEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e57e2bee74e6042fb649627da15c9cef9ff4d21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_PasswordRecoveryEmail), @"mvc.1.0.view", @"/Views/Account/PasswordRecoveryEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e57e2bee74e6042fb649627da15c9cef9ff4d21", @"/Views/Account/PasswordRecoveryEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_PasswordRecoveryEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Account.PasswordRecoveryEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div style=""max-width: 500px; margin-left: auto; margin-right: auto; padding: 15px; border: 1px solid #bbbbbb; background-color: #f1f1f152;"">
    <div style=""width:100%; text-align: center; margin-bottom: 3em;"">
        <img style=""width:400px;"" src=""cid:Logo"" />
    </div>
    <div style=""margin-bottom: 2em;"">
        <label style=""font-size: 14px;"">Olá, ");
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\PasswordRecoveryEmail.cshtml"
                                        Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\PasswordRecoveryEmail.cshtml"
                                                              Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</label>\n    </div>\n    <div style=\"margin-bottom: 2em;\">\n        <label style=\"font-size: 14px;\">Para redefinir sua senha <a");
            BeginWriteAttribute("href", " href=\"", 578, "\"", 605, 1);
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\PasswordRecoveryEmail.cshtml"
WriteAttributeValue("", 585, Model.EmailCallback, 585, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">clique aqui</a>.</label>
    </div>
    <div style=""margin-bottom: 2em;"">
        <label style=""font-size: 14px;"">Em caso de dúvidas, entre em contato conosco pelos canais abaixo:</label>
        <ul>
            <li><a href=""https://api.whatsapp.com/send?1=pt_BR&phone=552730290907"" style=""font-size: 14px;"">(27) 3029-0907</a></li>
            <li><a href=""mailto:contato@destineja.com.br"" style=""font-size: 14px;"">contato@destineja.com.br</a></li>
            <li><a href=""www.destineja.com.br"" style=""font-size: 14px;"">www.destineja.com.br</a></li>
        </ul>
    </div>
    <div style=""font-size: 14px;"">
        Atenciosamente,
        <br />
        Equipe Destine Já.
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Account.PasswordRecoveryEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591