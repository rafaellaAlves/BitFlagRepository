#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\ContractualGuarantee\ApprovedOrReprovedEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a299846d584a27d13c5d9cd27f065d4ef35f440"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractualGuarantee_ApprovedOrReprovedEmail), @"mvc.1.0.view", @"/Views/ContractualGuarantee/ApprovedOrReprovedEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContractualGuarantee/ApprovedOrReprovedEmail.cshtml", typeof(AspNetCore.Views_ContractualGuarantee_ApprovedOrReprovedEmail))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a299846d584a27d13c5d9cd27f065d4ef35f440", @"/Views/ContractualGuarantee/ApprovedOrReprovedEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_ContractualGuarantee_ApprovedOrReprovedEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.CertificateContractualViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\ContractualGuarantee\ApprovedOrReprovedEmail.cshtml"
  
    var status = statusTypeFunctions.GetDataByID(Model.StatusTypeId);

#line default
#line hidden
            BeginContext(208, 224, true);
            WriteLiteral("<div style=\"font-size: 15px !important; max-width: 750px; margin-left: auto !important; margin-right: auto !important;\">\r\n    <label>Olá,</label>\r\n    <br />\r\n    <br />\r\n    <label>Seu pedido foi analisado e o status é de \"");
            EndContext();
            BeginContext(433, 27, false);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\ContractualGuarantee\ApprovedOrReprovedEmail.cshtml"
                                                Write(status.StatusName.ToUpper());

#line default
#line hidden
            EndContext();
            BeginContext(460, 129, true);
            WriteLiteral("\".</label>\r\n    <br />\r\n    <label>Informamos que a carta encontra-se disponível no sistema para impressão.</label>\r\n    <br />\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\ContractualGuarantee\ApprovedOrReprovedEmail.cshtml"
     if (status.ExternalCode == "APROVADO")
    {

#line default
#line hidden
            BeginContext(641, 830, true);
            WriteLiteral(@"        <label>No prazo de até 30 dias a partir da data de hoje o contrato de locação devidamente assinado e com firma reconhecida em cartório deverá ser encaminhado através de upload no sistema, para isto basta clicar sobre a palavra “aprovado” e incluir o documento.</label>
        <br />
        <br />
        <div style=""text-align:center"">
            <b style=""font-size: 20px; text-decoration: underline;"">**BENEFÍCIO**</b>
        </div>
        <label>Oferecemos um super benefício às imobiliárias parceiras para utilização da plataforma de assinatura digital DocuSign. A assinatura eletrônica é uma realidade e otimiza o processo e o tempo de todos os envolvidos sem a necessidade do registro em cartório. Entre em contato com o seu gestor comercial e peça informações de como utilizar.</label>
        <br />
");
            EndContext();
#line 25 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\ContractualGuarantee\ApprovedOrReprovedEmail.cshtml"
    }

#line default
#line hidden
            BeginContext(1478, 162, true);
            WriteLiteral("    <label>Agradecemos sua consulta e nos colocamos à disposição ao que for necessário.</label>\r\n    <br />\r\n    <br />\r\n    <label>Equipe A+Imob.</label>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.StatusTypeFunctions statusTypeFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.CertificateContractualViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
