#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Archives.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f8f01f3a9bcf1bfa22347a7b67a886136cd7004"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Archives), @"mvc.1.0.view", @"/Views/Client/Archives.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Client/Archives.cshtml", typeof(AspNetCore.Views_Client_Archives))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f8f01f3a9bcf1bfa22347a7b67a886136cd7004", @"/Views/Client/Archives.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Archives : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Archives.cshtml"
  
    ViewData["Title"] = "Arquivos";
    ViewData["SubTitle"] = Model.ClientName;

#line default
#line hidden
            BeginContext(125, 135, true);
            WriteLiteral("<div id=\"_ClientArchiveIndexViewComponent\"></div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_ClientArchiveIndexViewComponent\').load(\'");
            EndContext();
            BeginContext(261, 46, false);
#line 9 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Archives.cshtml"
                                            Write(Url.Action("ClientArchiveComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(307, 15, true);
            WriteLiteral("\', {clientId: \'");
            EndContext();
            BeginContext(323, 14, false);
#line 9 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Archives.cshtml"
                                                                                                          Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(337, 15, true);
            WriteLiteral("\'});\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Client.ClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591