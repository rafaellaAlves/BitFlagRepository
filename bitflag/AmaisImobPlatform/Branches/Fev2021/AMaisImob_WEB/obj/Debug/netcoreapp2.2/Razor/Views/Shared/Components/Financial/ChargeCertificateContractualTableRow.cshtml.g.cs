#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ChargeCertificateContractualTableRow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7911c0bb4fb2e42c479cb6e57f33f1195c1ece9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Financial_ChargeCertificateContractualTableRow), @"mvc.1.0.view", @"/Views/Shared/Components/Financial/ChargeCertificateContractualTableRow.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Financial/ChargeCertificateContractualTableRow.cshtml", typeof(AspNetCore.Views_Shared_Components_Financial_ChargeCertificateContractualTableRow))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7911c0bb4fb2e42c479cb6e57f33f1195c1ece9f", @"/Views/Shared/Components/Financial/ChargeCertificateContractualTableRow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Financial_ChargeCertificateContractualTableRow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.Charge.ChargePriceItem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 6, true);
            WriteLiteral("\r\n<td>");
            EndContext();
            BeginContext(59, 11, false);
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ChargeCertificateContractualTableRow.cshtml"
Write(Model?.Name);

#line default
#line hidden
            EndContext();
            BeginContext(70, 11, true);
            WriteLiteral("</td>\r\n<td>");
            EndContext();
            BeginContext(82, 18, false);
#line 4 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ChargeCertificateContractualTableRow.cshtml"
Write(Model?.Description);

#line default
#line hidden
            EndContext();
            BeginContext(100, 11, true);
            WriteLiteral("</td>\r\n<td>");
            EndContext();
            BeginContext(113, 198, false);
#line 5 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ChargeCertificateContractualTableRow.cshtml"
Write(Model == null || (ViewBag.ChargeContractualGuarantee == false && Model.CertificateContractual) ? "-" : Model.AlternativeTotalPrice.HasValue? Model.AlternativeTotalPriceFormated : Model.PriceFormated);

#line default
#line hidden
            EndContext();
            BeginContext(312, 5, true);
            WriteLiteral("</td>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.Charge.ChargePriceItem> Html { get; private set; }
    }
}
#pragma warning restore 1591
