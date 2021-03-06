#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cac1303883e9b9f97821d4d0e30c12f9ed73b05e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Route_NewRouteEmail), @"mvc.1.0.view", @"/Views/Route/NewRouteEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cac1303883e9b9f97821d4d0e30c12f9ed73b05e", @"/Views/Route/NewRouteEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Route_NewRouteEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Route.RouteViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
  
    var routeType = await routeTypeServices.GetDataByIdAsync(Model.RouteTypeId);
    var routePeriodicity = await routePeriodicityServices.GetDataByIdAsync(Model.RoutePeriodicityId);

    var routeClients = await routeClientServices.GetDataAsNoTrackingAsync(x => x.RouteId == Model.RouteId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""width: 655px; margin: auto; border: 1px solid #cecece; -webkit-box-shadow: -1px -5px 20px 0px #b5b5b5; box-shadow: -1px -5px 20px 0px #b5b5b5; background: linear-gradient(to bottom, #e2e2e2, #e2e2e2 70px, #01a89c52 250px, #05a09785);"">
    <div style=""padding: 15px; font-weight: bold; font-size: 25px; text-align: center;"">
        <div style=""margin-top: 1em;"">
            - Nova Rota -<br />
        </div>
    </div>
    <div style=""padding: 15px; font-size: 16px; line-height: 25px; padding-bottom: 40px;"">
        <div style=""width: 80%; margin-left: 10%; padding: 10px; background: white; border-radius: 7px; box-shadow: inset 0px 0px 7px 2px #d0d0d0; -webkit-box-shadow: inset 0px 0px 7px 2px #d0d0d0; margin-bottom: 1em;"">
            <p style=""margin-bottom: .3em;"">Uma nova rota foi criada.</p>
            <p style=""margin-bottom: .1em;"">Dados informados:</p>
            <ul>
                <li><b>C??digo</b>: ");
#nullable restore
#line 26 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                              Write(Model.RouteId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n                <li><b>Nome</b>: ");
#nullable restore
#line 27 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n                <li><b>Tipo</b>: ");
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                            Write(routeType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n                <li><b>Periodicidade</b>: ");
#nullable restore
#line 29 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                                     Write(routePeriodicity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n                <li><b>Observa????o</b>: ");
#nullable restore
#line 30 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                                  Write(Model.Observation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            </ul>\n            <p style=\"margin-bottom: .1em;\">Nas cidades:</p>\n            <ul>\n");
#nullable restore
#line 34 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                 foreach (var routeClient in routeClients)
                {
                    var address = await clientCollectionAddressServices.GetDataByIdAsync(routeClient.ClientCollectionAddressId);


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><b>");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                      Write(address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                                    Write(address.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\n");
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                 if (routeClients.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><b>Nenhum item inserido.</b></li>\n");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Route\NewRouteEmail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\n        </div>\n    </div>\n</div>\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientCollectionAddressServices clientCollectionAddressServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Route.RouteClientServices routeClientServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Route.RoutePeriodicityServices routePeriodicityServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Route.RouteTypeServices routeTypeServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Route.RouteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
