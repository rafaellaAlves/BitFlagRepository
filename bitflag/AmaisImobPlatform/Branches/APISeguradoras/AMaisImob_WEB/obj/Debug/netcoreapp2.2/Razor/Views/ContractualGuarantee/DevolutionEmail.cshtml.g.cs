#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24212c9d3dec588c37a0a039ddc86ca36d3fdb0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractualGuarantee_DevolutionEmail), @"mvc.1.0.view", @"/Views/ContractualGuarantee/DevolutionEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContractualGuarantee/DevolutionEmail.cshtml", typeof(AspNetCore.Views_ContractualGuarantee_DevolutionEmail))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24212c9d3dec588c37a0a039ddc86ca36d3fdb0e", @"/Views/ContractualGuarantee/DevolutionEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_ContractualGuarantee_DevolutionEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.CertificateContractualViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 251, true);
            WriteLiteral("\r\n<div style=\"font-size: 15px !important; max-width: 750px; margin-left: auto !important; margin-right: auto !important;padding: 15px; border-radius: 5px; background: #e4e4e4;\">\r\n    <label>Olá,</label>\r\n    <br />\r\n    <br />\r\n    <label>O processo #");
            EndContext();
            BeginContext(313, 15, false);
#line 7 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml"
                  Write(Model.Reference);

#line default
#line hidden
            EndContext();
            BeginContext(328, 161, true);
            WriteLiteral(" foi definido como \"Devolução\" pela seguinte razão:</label>\r\n    <br />\r\n    <br />\r\n    <div style=\"background: #ffffff; padding: 15px; border-radius: 12px;\">\r\n");
            EndContext();
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.DevolutionReason))
        {
            

#line default
#line hidden
            BeginContext(579, 56, false);
#line 13 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml"
       Write(Html.Raw(Model.DevolutionReason?.Replace("\n", "<br/>")));

#line default
#line hidden
            EndContext();
#line 13 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml"
                                                                     
        }
        else
        {

#line default
#line hidden
            BeginContext(673, 45, true);
            WriteLiteral("            <i>Nenhuma razão informada.</i>\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ContractualGuarantee\DevolutionEmail.cshtml"
        }

#line default
#line hidden
            BeginContext(729, 77, true);
            WriteLiteral("    </div>\r\n    <br />\r\n    <br />\r\n    <label>Equipe A+Imob.</label>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.CertificateContractualViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
