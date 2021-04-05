#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f9cce147f57118531bee607da032b1b04e2c89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workbench_CertificateStatus), @"mvc.1.0.view", @"/Views/Workbench/CertificateStatus.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workbench/CertificateStatus.cshtml", typeof(AspNetCore.Views_Workbench_CertificateStatus))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f9cce147f57118531bee607da032b1b04e2c89", @"/Views/Workbench/CertificateStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workbench_CertificateStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
  
    ViewData["Title"] = "Status das Certidões";
    var date = jobFunctions.ItalyProtocolModuleGetSentDate(Model);

#line default
#line hidden
            BeginContext(185, 221, true);
            WriteLiteral("\r\n<div class=\"card d-print-block\">\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div id=\"JobFreezedFamilyItemInfoManageViewComponent\">\r\n                    ");
            EndContext();
            BeginContext(408, 397, false);
#line 13 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
                Write(await Component.InvokeAsync<Web.ViewComponents.Job.JobFreezedFamilyItemInfoManageViewComponent>(new { id = Model, title = "Status das Certidões", columns = new List<string>() { "RegistryOfficeId", "RegistryOfficeRequirementSentDate", "RegistryOfficeCertificateShippingArrivalDate", "TranslationSentDate", "TranslationReceiveDate", "HaiaHandoutSentDate", "HaiaHandoutReceiveDate" }, block = true }));

#line default
#line hidden
            EndContext();
            BeginContext(806, 78, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
         if (date.HasValue)
        {
            int day = date.Value.Day;
            string month = System.Globalization.CultureInfo.GetCultureInfo("pt-br").DateTimeFormat.GetMonthName(date.Value.Month);
            int year = date.Value.Year;


#line default
#line hidden
            BeginContext(1138, 221, true);
            WriteLiteral("            <div class=\"text-center\">\r\n                <div style=\"border: 1px solid #f3f3f3 !important; padding: 1em;\">\r\n                    <h5>\r\n                        As certidões foram enviadas para a Itália no dia ");
            EndContext();
            BeginContext(1360, 52, false);
#line 27 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
                                                                    Write(string.Format("{0} de {1} de {2}", day, month, year));

#line default
#line hidden
            EndContext();
            BeginContext(1412, 93, true);
            WriteLiteral("\r\n                    </h5>\r\n                </div>\r\n            </div>\r\n            <hr />\r\n");
            EndContext();
#line 32 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
        }

#line default
#line hidden
            BeginContext(1516, 81, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1597, "\"", 1688, 1);
#line 35 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
WriteAttributeValue("", 1604, Url.Action("GetSteps", "Workbench", new { jobId = Context.Request.Query["jobId"] }), 1604, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1689, 175, true);
            WriteLiteral(" class=\"btn btn-secondary\"><span class=\"simple-icon-action-undo\"></span>&nbsp;Voltar</a>\r\n            </div>\r\n            <div class=\"col-md-6 text-right\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1864, "\"", 1969, 1);
#line 38 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatus.cshtml"
WriteAttributeValue("", 1871, Url.Action("CertificateStatusPrint", "Workbench", new { jobId = Context.Request.Query["jobId"] }), 1871, 98, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1970, 154, true);
            WriteLiteral(" target=\"_blank\" class=\"btn btn-light\"><span class=\"simple-icon-printer\"></span>&nbsp;Imprimir</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FUNCTIONS.Job.JobFunctions jobFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
