#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\InsurancePolicy\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "571d859cfddf2469d6a1f1c767fa68eb492802c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InsurancePolicy_Index), @"mvc.1.0.view", @"/Views/InsurancePolicy/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InsurancePolicy/Index.cshtml", typeof(AspNetCore.Views_InsurancePolicy_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571d859cfddf2469d6a1f1c767fa68eb492802c5", @"/Views/InsurancePolicy/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_InsurancePolicy_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\InsurancePolicy\Index.cshtml"
  
    ViewData["Title"] = "Ap??lices";

#line default
#line hidden
            BeginContext(44, 234, true);
            WriteLiteral("\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_InsurancePolicyIndexViewComponent\"></div>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_InsurancePolicyIndexViewComponent\').load(\'");
            EndContext();
            BeginContext(279, 62, false);
#line 12 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\InsurancePolicy\Index.cshtml"
                                              Write(Url.Action("InsurancePolicyIndexComponent", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(341, 14, true);
            WriteLiteral("\');\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
