#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Mail\Subscription\HealthBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e11a5ae814e70b9857644caaf6f3b5ecd0b01536"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mail_Subscription_HealthBlock), @"mvc.1.0.view", @"/Views/Mail/Subscription/HealthBlock.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e11a5ae814e70b9857644caaf6f3b5ecd0b01536", @"/Views/Mail/Subscription/HealthBlock.cshtml")]
    public class Views_Mail_Subscription_HealthBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Subscription.SubscriptionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Mail\Subscription\HealthBlock.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Mail\Subscription\HealthBlock.cshtml"
   await Html.RenderPartialAsync("/Views/Mail/Subscription/Shared/Header.cshtml"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p>Olá Dr (a) ");
#nullable restore
#line 8 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Mail\Subscription\HealthBlock.cshtml"
         Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",</p>

<p>Por favor, siga as instruções abaixo;</p>

<p>
    <ul>
        <li>Imprima a Declaração Pessoal de Saúde que consta no anexo (modelo)</li>
        <li>Preencha de próprio punho todo o documento</li>
        <li>Seja breve na especificação</li>
        <li>Você deve assinar e datar Scanei em formato pdf e responda neste mesmo e-mail</li>
    </ul>
</p>

<p> Fluxo de análise:</p>

<p>A Seguradora terá 15 dias para analisar a Declaração Pessoal de Saúde após o recebimento deste documento assinado e datado. Caso seja necessário, a Seguradora poderá solicitar mais informações ou documentos.</p>

<p>Fluxo de Desbloqueio:</p>

<p>No prazo de 2 dias uteis, tendo a aprovação de aceitação da Seguradora, a AmaisVet fará o desbloqueio para a contratação do seguro.</p>

");
#nullable restore
#line 29 "C:\repositorios\bitflag\AmaisVetPlatform\Application\Branches\AmaisVetPlatform-SegundaVia\WEB\Views\Mail\Subscription\HealthBlock.cshtml"
   await Html.RenderPartialAsync("/Views/Mail/Subscription/Shared/Signature.cshtml"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
