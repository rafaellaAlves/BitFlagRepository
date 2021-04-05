#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "947ff96beff734494c11cd2c283569e5ff6167cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_NewClient_ClientEmail), @"mvc.1.0.view", @"/Views/Account/NewClient_ClientEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"947ff96beff734494c11cd2c283569e5ff6167cd", @"/Views/Account/NewClient_ClientEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_NewClient_ClientEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.NewClientEmailViewModel>
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
        <label style=""font-size: 14px;"">Olá, <b>");
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                           Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                                                 Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>.</label>\n        <br />\n        <label style=\"font-size: 14px;\">Seja bem-vindo(a) à Destine Já.</label>\n    </div>\n    <div style=\"margin-bottom: 2em;\">\n        <label style=\"font-size: 14px;\">A partir de agora a ");
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                                       Write(Model.Client.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" está cadastrada no sistema da Destine Já.</label>
    </div>
    <div style=""margin-bottom: 2em;"">
        <label style=""font-size: 14px;"">Clique no botão para confirmar o seu email.</label>
    </div>
    <div style=""text-align: center;margin-top: 50px;margin-bottom: 50px;""><a");
            BeginWriteAttribute("href", " href=\"", 968, "\"", 1107, 1);
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
WriteAttributeValue("", 975, Url.Action("EmailConfirm", "Account", new { userId = Model.User.UserId, token = Model.User.CreationToken }, Context.Request.Scheme), 975, 132, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""color: white; background: #04ab9f; text-decoration: none; padding: 15px; border-radius: 7px;"">Confirmar E-mail</a></div>
    <div style=""margin-bottom: 2em;"">
        <label style=""font-size: 14px;"">Para acessar o sistema utilize o link: <a style=""font-size: 14px;""");
            BeginWriteAttribute("href", " href=\"", 1381, "\"", 1470, 1);
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
WriteAttributeValue("", 1388, Url.Action("Login", "Account", new { Model.User.UserId }, Context.Request.Scheme), 1388, 82, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                                                                                                                                                                                Write(Url.Action("", "", null, Context.Request.Scheme));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></label>\n        <br />\n        <label style=\"font-size: 14px;\"><b>Seu login é:</b> ");
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                                       Write(Model.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n        <br />\n        <label style=\"font-size: 14px;\"><b>Sua senha provisória é:</b> ");
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\NewClient_ClientEmail.cshtml"
                                                                  Write(Model.User.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
    </div>
    <div style=""margin-bottom: 2em;"">
        <label style=""font-size: 14px;"">A sua senha é pessoal e intransferível. Guarde-a com cuidado.</label>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Client.NewClientEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591