#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Log.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2346d0bdebb021abde10d9daa6d9c43dd73b1948"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Log), @"mvc.1.0.view", @"/Views/Client/Log.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Client/Log.cshtml", typeof(AspNetCore.Views_Client_Log))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2346d0bdebb021abde10d9daa6d9c43dd73b1948", @"/Views/Client/Log.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Log : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Log.cshtml"
  
    ViewData["Title"] = "Histórico";
    ViewData["SubTitle"] = Model.ClientName;

#line default
#line hidden
            BeginContext(126, 117, true);
            WriteLiteral("<div id=\"_ClientLogViewComponent\"></div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_ClientLogViewComponent\').load(\'");
            EndContext();
            BeginContext(244, 42, false);
#line 9 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Log.cshtml"
                                   Write(Url.Action("ClientLogComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(286, 15, true);
            WriteLiteral("\', {clientId: \'");
            EndContext();
            BeginContext(302, 14, false);
#line 9 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Client\Log.cshtml"
                                                                                             Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(316, 15, true);
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
