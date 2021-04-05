#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "436496cfa01e908237d7ce48bdd4c26b2523d038"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_Filter_Route), @"mvc.1.0.view", @"/Views/Shared/Components/Report/Filter/Route.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"436496cfa01e908237d7ce48bdd4c26b2523d038", @"/Views/Shared/Components/Report/Filter/Route.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_Filter_Route : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<label>Rotas</label>\n<select name=\"RouteIds\" class=\"form-control filter-input\" data-filter-name=\"Rotas\" multiple>\n    <option");
            BeginWriteAttribute("value", " value=\"", 177, "\"", 185, 0);
            EndWriteAttribute();
            WriteLiteral(">Selecione</option>\n");
#nullable restore
#line 6 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
      
        foreach (var item in await routeServices.GetDataAsNoTrackingAsync(x => !x.IsDeleted))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <option");
            BeginWriteAttribute("value", " value=\"", 336, "\"", 357, 1);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
WriteAttributeValue("", 344, item.RouteId, 344, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-name=\"#");
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
                                                 Write(item.RouteId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
                                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\n");
#nullable restore
#line 10 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\Route.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</select>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Route.RouteServices routeServices { get; private set; }
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
