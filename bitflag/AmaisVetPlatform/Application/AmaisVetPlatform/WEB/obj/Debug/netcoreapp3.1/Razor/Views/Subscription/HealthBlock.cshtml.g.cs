#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Subscription\HealthBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77df18be8fae5ef40ad5e8cb8df8c51063ad69de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscription_HealthBlock), @"mvc.1.0.view", @"/Views/Subscription/HealthBlock.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77df18be8fae5ef40ad5e8cb8df8c51063ad69de", @"/Views/Subscription/HealthBlock.cshtml")]
    public class Views_Subscription_HealthBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Subscription.SubscriptionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Subscription\HealthBlock.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["title"] = "Assinatura Suspensa";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""mb-2"">
            <h2>
                Assinatura em Análise
            </h2>
        </div>
    </div>
</div>
<hr />
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-blue"">
            <div class=""card-body"">
                <div class=""row mb-4"">
                    <div class=""col-md-12 text-center"">
                        <span class=""fa-stack fa-5x"">
                            <i class=""fas fa-circle fa-stack-2x text-green""></i>
                            <i class=""fas fa-user-clock fa-stack-1x fa-inverse""></i>
                        </span>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-12 text-center"">
                        <h2>Olá, <b>Dr(a). ");
#nullable restore
#line 32 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Subscription\HealthBlock.cshtml"
                                      Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>!<br /><small>Como houve pelo menos uma resposta <b>NÃO</b> no questionário simplificado, a sua adesão ficará suspensa até que a sua seguradora analise a Declaração Pessoal de Saúde que enviamos em seu e-mail.</small></h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<hr />
<div class=""row"">
    <div class=""col-md-6"">
        <a");
            BeginWriteAttribute("href", " href=\"", 1428, "\"", 1463, 1);
#nullable restore
#line 42 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Subscription\HealthBlock.cshtml"
WriteAttributeValue("", 1435, Url.Action("Index", "Home"), 1435, 28, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Subscription.SubscriptionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
