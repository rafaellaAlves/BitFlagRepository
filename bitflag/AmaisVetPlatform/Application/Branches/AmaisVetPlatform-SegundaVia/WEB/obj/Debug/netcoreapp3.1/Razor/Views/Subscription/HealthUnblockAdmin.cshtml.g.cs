#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "210d74ab82260834f789a41c30fbbfefb5fa71fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscription_HealthUnblockAdmin), @"mvc.1.0.view", @"/Views/Subscription/HealthUnblockAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"210d74ab82260834f789a41c30fbbfefb5fa71fb", @"/Views/Subscription/HealthUnblockAdmin.cshtml")]
    public class Views_Subscription_HealthUnblockAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["title"] = "Assinatura Suspensa";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"mb-2\">\r\n            <h2>\r\n                Desbloqueio de Assinatura<br /><small><b>");
#nullable restore
#line 11 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
                                                    Write(Context.Request.RouteValues["reference"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></small>\r\n            </h2>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"card card-blue\">\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 20 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
                 if (ViewData["Error"] == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row mb-4"">
                        <div class=""col-md-12 text-center"">
                            <span class=""fa-stack fa-5x"">
                                <i class=""fas fa-circle fa-stack-2x text-green""></i>
                                <i class=""fas fa-check fa-stack-1x fa-inverse""></i>
                            </span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-12 text-center"">
                            <h2>Processo de desbloqueio da assinatura realizada com sucesso!</h2>
                        </div>
                    </div>
");
#nullable restore
#line 35 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row mb-4"">
                        <div class=""col-md-12 text-center"">
                            <span class=""fa-stack fa-5x"">
                                <i class=""fas fa-circle fa-stack-2x""></i>
                                <i class=""fas fa-times fa-stack-1x fa-inverse""></i>
                            </span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-12 text-center"">
                            <h2>Houve um erro ao desbloquear assinatura!</h2>
                        </div>
                    </div>
");
#nullable restore
#line 51 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 2109, "\"", 2144, 1);
#nullable restore
#line 59 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Subscription\HealthUnblockAdmin.cshtml"
WriteAttributeValue("", 2116, Url.Action("Index", "Home"), 2116, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary\">Voltar</a>\r\n    </div>\r\n</div>");
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
