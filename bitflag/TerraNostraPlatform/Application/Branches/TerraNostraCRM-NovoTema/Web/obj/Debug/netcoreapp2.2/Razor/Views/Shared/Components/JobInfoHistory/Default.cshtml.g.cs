#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0ed4ca80bdb2ecef872461e816d9671cf78747d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_JobInfoHistory_Default), @"mvc.1.0.view", @"/Views/Shared/Components/JobInfoHistory/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/JobInfoHistory/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_JobInfoHistory_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0ed4ca80bdb2ecef872461e816d9671cf78747d", @"/Views/Shared/Components/JobInfoHistory/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_JobInfoHistory_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DTO.Job.JobInteractionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 412, true);
            WriteLiteral(@"
<table class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
    <thead>
        <tr>
            <th class=""text-center"">Etapa</th>
            <th class=""text-center"">Respons??vel</th>
            <th class=""text-center text-nowrap"">??ltima Intera????o</th>
            <th>Observa????es</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 13 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(507, 62, true);
            WriteLiteral("        <tr>\r\n            <td class=\"text-center text-nowrap\">");
            EndContext();
            BeginContext(570, 20, false);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
                                           Write(item.StepDescription);

#line default
#line hidden
            EndContext();
            BeginContext(590, 55, true);
            WriteLiteral("</td>\r\n            <td class=\"text-center text-nowrap\">");
            EndContext();
            BeginContext(646, 13, false);
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
                                           Write(item.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(659, 55, true);
            WriteLiteral("</td>\r\n            <td class=\"text-center text-nowrap\">");
            EndContext();
            BeginContext(715, 17, false);
#line 18 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
                                           Write(item._CreatedDate);

#line default
#line hidden
            EndContext();
            BeginContext(732, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(756, 12, false);
#line 19 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
           Write(item.Message);

#line default
#line hidden
            EndContext();
            BeginContext(768, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 21 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\JobInfoHistory\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(801, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DTO.Job.JobInteractionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
