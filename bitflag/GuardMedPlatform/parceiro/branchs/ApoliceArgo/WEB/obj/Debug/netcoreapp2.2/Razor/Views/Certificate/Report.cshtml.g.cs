#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4ff1b22a221a3f3508cb916e185a333de0ba9c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Certificate_Report), @"mvc.1.0.view", @"/Views/Certificate/Report.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Certificate/Report.cshtml", typeof(AspNetCore.Views_Certificate_Report))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4ff1b22a221a3f3508cb916e185a333de0ba9c1", @"/Views/Certificate/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Certificate_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Report.cshtml"
  
    ViewData["Title"] = "Relatórios Certificados";

#line default
#line hidden
            BeginContext(59, 226, true);
            WriteLiteral("<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_CertificateReportViewComponent\"></div>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_CertificateReportViewComponent\').load(\'");
            EndContext();
            BeginContext(286, 55, false);
#line 11 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Report.cshtml"
                                           Write(Url.Action("CertificateReportComponent", "Certificate"));

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