#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea6b454001b726b335be6704245bd926160ecec2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_Index), @"mvc.1.0.view", @"/Views/Plan/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Plan/Index.cshtml", typeof(AspNetCore.Views_Plan_Index))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6b454001b726b335be6704245bd926160ecec2", @"/Views/Plan/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Plan_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
  
    ViewData["Title"] = "Planos";

#line default
#line hidden
            BeginContext(55, 129, true);
            WriteLiteral("\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_PlanIndexViewComponent\"></div>\r\n    </div>\r\n");
            EndContext();
#line 10 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
     if (Model.HasValue)
    {

#line default
#line hidden
            BeginContext(217, 49, true);
            WriteLiteral("        <div class=\"card-footer\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 266, "\"", 320, 3);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
WriteAttributeValue("", 273, Url.Action("Index","Product"), 273, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 303, "?productId=", 303, 11, true);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
WriteAttributeValue("", 314, Model, 314, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(321, 104, true);
            WriteLiteral(" class=\"btn btn-secondary float-left\"><i class=\"fa fa-arrow-left\"></i>&nbsp;Voltar</a>\r\n        </div>\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(432, 83, true);
            WriteLiteral("</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_PlanIndexViewComponent\').load(\'");
            EndContext();
            BeginContext(516, 40, false);
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
                                   Write(Url.Action("PlanIndexComponent", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(556, 15, true);
            WriteLiteral("\', {productId: ");
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
                                                                                                 if(Model.HasValue){

#line default
#line hidden
            BeginContext(598, 5, false);
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
                                                                                                                     Write(Model);

#line default
#line hidden
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
                                                                                                                                       }else{

#line default
#line hidden
            BeginContext(622, 4, true);
            WriteLiteral("null");
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Plan\Index.cshtml"
                                                                                                                                                              }

#line default
#line hidden
            BeginContext(634, 16, true);
            WriteLiteral("});\r\n</script>\r\n");
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
