#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbfa0a93f989d4aba3e7fa95b976dd16134627cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductCoverage_Index), @"mvc.1.0.view", @"/Views/ProductCoverage/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProductCoverage/Index.cshtml", typeof(AspNetCore.Views_ProductCoverage_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbfa0a93f989d4aba3e7fa95b976dd16134627cb", @"/Views/ProductCoverage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductCoverage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
  
    ViewData["Title"] = "Coberturas";

#line default
#line hidden
            BeginContext(59, 181, true);
            WriteLiteral("\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_ProductCoverageIndexViewComponent\"></div>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 240, "\"", 277, 1);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
WriteAttributeValue("", 247, Url.Action("Index","Product"), 247, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(278, 194, true);
            WriteLiteral(" class=\"btn btn-secondary float-left\"><i class=\"fa fa-arrow-left\"></i>&nbsp;Voltar</a>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_ProductCoverageIndexViewComponent\').load(\'");
            EndContext();
            BeginContext(473, 62, false);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
                                              Write(Url.Action("ProductCoverageIndexComponent", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(535, 16, true);
            WriteLiteral("\', { productId: ");
            EndContext();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
                                                                                                                                   if (Model.HasValue) {

#line default
#line hidden
            BeginContext(579, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginContext(581, 5, false);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
                                                                                                                                                          Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(586, 1, true);
            WriteLiteral("\"");
            EndContext();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
                                                                                                                                                                             }else{

#line default
#line hidden
            BeginContext(606, 4, true);
            WriteLiteral("null");
            EndContext();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\ProductCoverage\Index.cshtml"
                                                                                                                                                                                                    }

#line default
#line hidden
            BeginContext(618, 15, true);
            WriteLiteral(" });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int?> Html { get; private set; }
    }
}
#pragma warning restore 1591
