#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c8727f4f8da35a4dd1eaa9b7fe209762ada5a7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demand_CloseDemandEmail), @"mvc.1.0.view", @"/Views/Demand/CloseDemandEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c8727f4f8da35a4dd1eaa9b7fe209762ada5a7f", @"/Views/Demand/CloseDemandEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Demand_CloseDemandEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Demand.CloseDemandEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div style=""width: 655px; margin: auto; border: 1px solid #cecece; -webkit-box-shadow: -1px -5px 20px 0px #b5b5b5; box-shadow: -1px -5px 20px 0px #b5b5b5; background: linear-gradient(to bottom, #e2e2e2, #e2e2e2 70px, #01a89c52 250px, #05a09785);"">
    <div style=""padding: 15px; font-weight: bold; font-size: 25px; text-align: center;"">
        <div style=""margin-top: 1em;"">
            - Coleta Finalizada -<br />
        </div>
    </div>
    <div style=""padding: 15px; font-size: 16px; line-height: 25px; padding-bottom: 40px;"">
        <div style=""width: 80%; margin-left: 10%; padding: 10px; background: white; border-radius: 7px; box-shadow: inset 0px 0px 7px 2px #d0d0d0; -webkit-box-shadow: inset 0px 0px 7px 2px #d0d0d0; margin-bottom: 1em;"">
            <p style=""margin-bottom: .3em;"">Prezado(a) cliente, <b>");
#nullable restore
#line 11 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
                                                              Write(Model.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\n            <p style=\"margin-bottom: .1em;\">Sua coleta do dia <b>");
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
                                                            Write(Model.DemandClient._VisitedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>, no MTR <b>");
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
                                                                                                            Write(Model.Demand.DestinaJaDemandId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> foi finalizada e o certificado <b>");
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
                                                                                                                                                                                  Write(Model.DemandClient.DestineJaCertificateId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> está no sistema.</p>\n            <p style=\"margin-bottom: .1em;\">Acesse <a");
            BeginWriteAttribute("href", " href=\"", 1196, "\"", 1264, 1);
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
WriteAttributeValue("", 1203, Url.Action("Login", "Account", null, Context.Request.Scheme), 1203, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\CloseDemandEmail.cshtml"
                                                                                                                      Write(Url.Action("", "", null, Context.Request.Scheme));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> e faça o download.</p>\n            <br />\n            <p style=\"margin-bottom: .1em;\">Atenciosamente,</p>\n            <p style=\"margin-bottom: .1em;\">Destine Já.</p>\n        </div>\n    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Demand.CloseDemandEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591