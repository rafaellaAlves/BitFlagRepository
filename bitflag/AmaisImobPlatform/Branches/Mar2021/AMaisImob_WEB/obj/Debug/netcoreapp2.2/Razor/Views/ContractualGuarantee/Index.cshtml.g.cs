#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ContractualGuarantee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07a65b820c7d13b2fcbaf9db7d08f97ec1289125"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractualGuarantee_Index), @"mvc.1.0.view", @"/Views/ContractualGuarantee/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContractualGuarantee/Index.cshtml", typeof(AspNetCore.Views_ContractualGuarantee_Index))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07a65b820c7d13b2fcbaf9db7d08f97ec1289125", @"/Views/ContractualGuarantee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_ContractualGuarantee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ContractualGuarantee\Index.cshtml"
  
    switch (Model)
    {
        case (int)AMaisImob_WEB.Utils.ContractualGuaranteeTypes.New: ViewData["Title"] = "Nova Garantia"; break;
        case (int)AMaisImob_WEB.Utils.ContractualGuaranteeTypes.Active: ViewData["Title"] = "Garantias Ativas"; break;
        case (int)AMaisImob_WEB.Utils.ContractualGuaranteeTypes.Inactive: ViewData["Title"] = "Garantias Inativas"; break;
        default: ViewData["Title"] = "Garantia Contratual"; break;
    }

#line default
#line hidden
            BeginContext(479, 140, true);
            WriteLiteral(" \r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_ContractualGuaranteeIndexViewComponent\">\r\n            ");
            EndContext();
            BeginContext(621, 84, false);
#line 15 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ContractualGuarantee\Index.cshtml"
        Write( await Component.InvokeAsync("ContractualGuaranteeIndex", new { statusId = Model }) );

#line default
#line hidden
            EndContext();
            BeginContext(706, 40, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
