#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\LatestJobInfo\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15a21faa41f8143d79b1b32a0fc02665976f4ffd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LatestJobInfo_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LatestJobInfo/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/LatestJobInfo/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_LatestJobInfo_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a21faa41f8143d79b1b32a0fc02665976f4ffd", @"/Views/Shared/Components/LatestJobInfo/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LatestJobInfo_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Job.JobInteractionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 100, true);
            WriteLiteral("\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-4\">Etapa Atual</dt>\r\n        <dd class=\"col-sm-8\">");
            EndContext();
            BeginContext(142, 59, false);
#line 5 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\LatestJobInfo\Default.cshtml"
                         Write(Model.StepDescription == null ? "-" : Model.StepDescription);

#line default
#line hidden
            EndContext();
            BeginContext(202, 85, true);
            WriteLiteral("</dd>\r\n\r\n        <dt class=\"col-sm-4\">Responsável</dt>\r\n        <dd class=\"col-sm-8\">");
            EndContext();
            BeginContext(289, 45, false);
#line 8 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\LatestJobInfo\Default.cshtml"
                         Write(Model.UserName == null ? "-" : Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(335, 90, true);
            WriteLiteral("</dd>\r\n\r\n        <dt class=\"col-sm-4\">Última Interação</dt>\r\n        <dd class=\"col-sm-8\">");
            EndContext();
            BeginContext(427, 53, false);
#line 11 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\LatestJobInfo\Default.cshtml"
                         Write(Model._CreatedDate == null ? "-" : Model._CreatedDate);

#line default
#line hidden
            EndContext();
            BeginContext(481, 88, true);
            WriteLiteral("</dd>\r\n\r\n        <dt class=\"col-sm-4\">Observações</dt>\r\n        <dd class=\"col-sm-8\"><p>");
            EndContext();
            BeginContext(571, 43, false);
#line 14 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\LatestJobInfo\Default.cshtml"
                            Write(Model.Message == null ? "-" : Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(615, 20, true);
            WriteLiteral("</p></dd>\r\n    </dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Job.JobInteractionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
