#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a1352df15480fd2620698a8c16e28ffa4603124"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workbench_Index), @"mvc.1.0.view", @"/Views/Workbench/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workbench/Index.cshtml", typeof(AspNetCore.Views_Workbench_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a1352df15480fd2620698a8c16e28ffa4603124", @"/Views/Workbench/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workbench_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\Index.cshtml"
  

    ViewData["Title"] = "Processos";

#line default
#line hidden
            BeginContext(47, 119, true);
            WriteLiteral("<div id=\"_ActiveJobsViewComponent\"></div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_ActiveJobsViewComponent\').load(\'");
            EndContext();
            BeginContext(167, 50, false);
#line 8 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\Index.cshtml"
                                    Write(Url.Action("ActiveJobsViewComponent", "Workbench"));

#line default
#line hidden
            EndContext();
            BeginContext(217, 14, true);
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
