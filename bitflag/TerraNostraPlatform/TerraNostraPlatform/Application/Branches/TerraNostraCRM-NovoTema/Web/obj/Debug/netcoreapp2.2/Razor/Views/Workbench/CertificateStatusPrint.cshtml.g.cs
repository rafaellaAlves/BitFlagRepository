#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b828e3e56d804fc826040eb0da7b64ea22370957"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workbench_CertificateStatusPrint), @"mvc.1.0.view", @"/Views/Workbench/CertificateStatusPrint.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workbench/CertificateStatusPrint.cshtml", typeof(AspNetCore.Views_Workbench_CertificateStatusPrint))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b828e3e56d804fc826040eb0da7b64ea22370957", @"/Views/Workbench/CertificateStatusPrint.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workbench_CertificateStatusPrint : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml"
  
    Layout = "~/Views/Shared/_LayoutPrint.cshtml";
    var date = jobFunctions.ItalyProtocolModuleGetSentDate(Model);

#line default
#line hidden
            BeginContext(188, 31, true);
            WriteLiteral("\r\n<style type=\"text/css\">\r\n    ");
            EndContext();
            BeginContext(220, 396, true);
            WriteLiteral(@"@media print {
        .no-print, .no-print * {
            display: none !important;
        }
    }

    body {
        background-color: white;
    }

    main {
        margin: 0;
        padding: 1em;
    }
</style>

<button class=""btn btn-primary float-right no-print"" style=""margin-bottom:1em;"" id=""button-print""><i class=""simple-icon-printer""></i>&nbsp;Imprimir</button>
");
            EndContext();
            BeginContext(618, 417, false);
#line 26 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml"
Write(await Component.InvokeAsync<Web.ViewComponents.Job.JobFreezedFamilyItemInfoManageViewComponent>(new { id = Model, title = "Status das Certidões", columns = new List<string>() { "RegistryOfficeId", "RegistryOfficeRequirementSentDate", "RegistryOfficeCertificateShippingArrivalDate", "TranslationSentDate", "TranslationReceiveDate", "HaiaHandoutSentDate", "HaiaHandoutReceiveDate" }, block = true, isPrintMode = true }));

#line default
#line hidden
            EndContext();
            BeginContext(1036, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 27 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml"
 if (date.HasValue)
{
    int day = date.Value.Day;
    string month = System.Globalization.CultureInfo.GetCultureInfo("pt-br").DateTimeFormat.GetMonthName(date.Value.Month);
    int year = date.Value.Year;


#line default
#line hidden
            BeginContext(1252, 189, true);
            WriteLiteral("    <div class=\"text-center\">\r\n        <div style=\"border: 1px solid #f3f3f3 !important; padding: 1em;\">\r\n            <h5>\r\n                As certidões foram enviadas para a Itália no dia ");
            EndContext();
            BeginContext(1442, 52, false);
#line 36 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml"
                                                            Write(string.Format("{0} de {1} de {2}", day, month, year));

#line default
#line hidden
            EndContext();
            BeginContext(1494, 61, true);
            WriteLiteral("\r\n            </h5>\r\n        </div>\r\n    </div>\r\n    <hr />\r\n");
            EndContext();
#line 41 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\CertificateStatusPrint.cshtml"
}

#line default
#line hidden
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
