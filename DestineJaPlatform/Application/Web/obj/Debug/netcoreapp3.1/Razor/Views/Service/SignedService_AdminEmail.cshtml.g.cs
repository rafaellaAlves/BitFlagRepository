#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27e776961b698c3d2aa6aaeef5f62d7dbc4bc1d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_SignedService_AdminEmail), @"mvc.1.0.view", @"/Views/Service/SignedService_AdminEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27e776961b698c3d2aa6aaeef5f62d7dbc4bc1d4", @"/Views/Service/SignedService_AdminEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Service_SignedService_AdminEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Service.ServiceViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
  
    var client = await clientServices.GetViewModelByIdAsync(Model.ClientId.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""width: 655px; margin: auto; border: 1px solid #cecece; -webkit-box-shadow: -1px -5px 20px 0px #b5b5b5; box-shadow: -1px -5px 20px 0px #b5b5b5; background: linear-gradient(to bottom, #e2e2e2, #e2e2e2 70px, #01a89c52 250px, #05a09785);"">
    <div style=""padding: 15px; font-weight: bold; font-size: 25px; text-align: center;"">
        <div style=""margin-top: 1em;"">
            - Serviço Assinado -<br />
        </div>
    </div>
    <div style=""padding: 15px; font-size: 16px; line-height: 25px; padding-bottom: 40px;"">
        <div style=""width: 80%; margin-left: 10%; padding: 10px; background: white; border-radius: 7px; box-shadow: inset 0px 0px 7px 2px #d0d0d0; -webkit-box-shadow: inset 0px 0px 7px 2px #d0d0d0; margin-bottom: 1em;"">
            <p style=""margin-bottom: .1em;"">O.S <b>");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                              Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> - <b>");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                                                   Write(client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>, foi assinado digitalmente pelo gerador <b>");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                                                                                                               Write(Model.ContactName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                                                                                                                                   Write(Model.ContactCpf.CPFMask());

#line default
#line hidden
#nullable disable
            WriteLiteral(")</b> às <b>");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                                                                                                                                                                          Write(Model.TermAcceptedDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> em <b>");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Service\SignedService_AdminEmail.cshtml"
                                                                                                                                                                                                                                Write(Model._TermAcceptedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>.</p>\n            <p style=\"margin-bottom: .1em;\">O serviço está em vigor.</p>\n        </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientServices clientServices { get; private set; }
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
