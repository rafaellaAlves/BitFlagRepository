#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48f09a951512355b868e9a1437b2f40deddc3c8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mail_Subscription_Start), @"mvc.1.0.view", @"/Views/Mail/Subscription/Start.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f09a951512355b868e9a1437b2f40deddc3c8d", @"/Views/Mail/Subscription/Start.cshtml")]
    public class Views_Mail_Subscription_Start : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Subscription.SubscriptionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
   await Html.RenderPartialAsync("/Views/Mail/Subscription/Shared/Header.cshtml"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n    Olá Dr(a). ");
#nullable restore
#line 7 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
          Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n</p>\r\n<p>\r\n    Agradecemos por seu interesse.\r\n</p>\r\n<p>\r\n    Bem vinda (o) a maior empresa do Brasil em seguros para área da Medicina Veterinária.\r\n</p>\r\n<p>\r\n    Anote esse número de referência ");
#nullable restore
#line 16 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
                               Write(Model.Reference);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", para que possa acessar a cotação no futuro.
</p>
<p>
    Clique nas opções abaixo se quiser saber sobre:
    <ul>
        <li><a href=""https://www.amaisvet.com.br/duvidas-adesao-sinistro-cobertura"">Dúvidas frequentes</a></li>
        <li><a href=""https://www.amaisvet.com.br/condicoesgerais-particulares"">Condições Gerais e Particulares</a></li>
        <li><a href=""https://www.amaisvet.com.br/veterinario-parceiros-convenio"">Parcerias e Convênios</a></li>
        <li><a href=""https://www.amaisvet.com.br/veterinario-oquefazemos"">O que fazemos</a></li>
    </ul>
</p>
<p>
    <a");
            BeginWriteAttribute("href", " href=\"", 1004, "\"", 1112, 1);
#nullable restore
#line 28 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
WriteAttributeValue("", 1011, Url.Action("Goto", "Subscription", new { reference = Model.Reference }, this.Context.Request.Scheme), 1011, 101, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Voltar para a cotação</a>\r\n</p>\r\n");
#nullable restore
#line 30 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-AtualizacaoCadastral\WEB\Views\Mail\Subscription\Start.cshtml"
   await Html.RenderPartialAsync("/Views/Mail/Subscription/Shared/Signature.cshtml"); 

#line default
#line hidden
#nullable disable
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
