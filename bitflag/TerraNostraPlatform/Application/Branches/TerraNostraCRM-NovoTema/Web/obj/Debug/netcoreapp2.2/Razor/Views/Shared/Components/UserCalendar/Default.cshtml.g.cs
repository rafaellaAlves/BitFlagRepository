#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "303530e10654a33f5fe40d52556c8dfe8a27ae4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserCalendar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserCalendar/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/UserCalendar/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_UserCalendar_Default))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"303530e10654a33f5fe40d52556c8dfe8a27ae4e", @"/Views/Shared/Components/UserCalendar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserCalendar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DTO.Client.ClientCalendarViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
 if (Model.Count > 0)
{

    

#line default
#line hidden
#line 6 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(120, 77, true);
            WriteLiteral("        <div class=\"d-flex flex-row mb-3 pb-3 border-bottom\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 197, "\"", 311, 1);
#line 9 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
WriteAttributeValue("", 204, Url.Action("ClientCalendar", "Client", new { clientId = item.ClientId, clientTaskId = item.ClientTaskId }), 204, 107, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(312, 54, true);
            WriteLiteral(">\r\n                <p class=\"font-weight-medium mb-0\">");
            EndContext();
            BeginContext(367, 10, false);
#line 10 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
                                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(377, 63, true);
            WriteLiteral("</p>\r\n                <p class=\"text-muted mb-0 text-small\"><i>");
            EndContext();
            BeginContext(441, 12, false);
#line 11 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
                                                    Write(item.Message);

#line default
#line hidden
            EndContext();
            BeginContext(453, 91, true);
            WriteLiteral("</i></p>\r\n                <br />\r\n                <p class=\"text-muted mb-0 text-small\"><b>");
            EndContext();
            BeginContext(545, 15, false);
#line 13 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
                                                    Write(item.ClientName);

#line default
#line hidden
            EndContext();
            BeginContext(560, 7, true);
            WriteLiteral("</b> | ");
            EndContext();
            BeginContext(568, 14, false);
#line 13 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
                                                                           Write(item._TaskDate);

#line default
#line hidden
            EndContext();
            BeginContext(582, 40, true);
            WriteLiteral("</p>\r\n            </a>\r\n        </div>\r\n");
            EndContext();
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
    }

#line default
#line hidden
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"
     
}
else
{

#line default
#line hidden
            BeginContext(641, 114, true);
            WriteLiteral("    <div style=\"line-height: 342px;\" class=\"text-center\">\r\n        <i>Nenhuma tarefa programada.</i>\r\n    </div>\r\n");
            EndContext();
#line 23 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserCalendar\Default.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DTO.Client.ClientCalendarViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
