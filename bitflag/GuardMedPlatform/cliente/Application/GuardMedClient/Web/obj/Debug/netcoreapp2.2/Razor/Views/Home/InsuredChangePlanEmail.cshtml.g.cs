#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c696cc87484cd120497d008d40e5e9a4774db7f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_InsuredChangePlanEmail), @"mvc.1.0.view", @"/Views/Home/InsuredChangePlanEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/InsuredChangePlanEmail.cshtml", typeof(AspNetCore.Views_Home_InsuredChangePlanEmail))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c696cc87484cd120497d008d40e5e9a4774db7f0", @"/Views/Home/InsuredChangePlanEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_InsuredChangePlanEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web.DTO.SeguradoProfissional.InsuredChangePlanEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(69, 495, true);
            WriteLiteral(@"
<div style=""width: 45%; margin-left: 33%; border: 1px solid #cecece; -webkit-box-shadow: -1px -5px 20px 0px #b5b5b5; box-shadow: -1px -5px 20px 0px #b5b5b5; background: linear-gradient(to bottom, #e2e2e2, #e2e2e2 70px, #a8c6e28a 250px, #adc2d8);"">
    <div style=""padding: 15px; font-weight: bold; font-size: 25px; text-align: center;"">
        <img src=""cid:LogoImg"" width=""300"">
        <div style=""margin-top: 1em;"">
            - Alteração de Dados Profissionais -<br />
            #");
            EndContext();
            BeginContext(565, 25, false);
#line 8 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
        Write(Model.Segurado.Referencia);

#line default
#line hidden
            EndContext();
            BeginContext(590, 143, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div style=\"padding: 15px; font-size: 16px; line-height: 25px; padding-bottom: 40px;\">\r\n        O cliente <b>");
            EndContext();
            BeginContext(734, 19, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                Write(Model.Segurado.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(753, 128, true);
            WriteLiteral("</b> realizou uma alteração em seus dados profissionais que ocasionou em um aumento no <b>Preço Total</b> em seu plano de <b>R$ ");
            EndContext();
            BeginContext(882, 15, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                                                                                                                                                    Write(Model._OldPrice);

#line default
#line hidden
            EndContext();
            BeginContext(897, 5, true);
            WriteLiteral(" (R$ ");
            EndContext();
            BeginContext(903, 22, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                                                                                                                                                                         Write(Model._MonthlyOldPrice);

#line default
#line hidden
            EndContext();
            BeginContext(925, 19, true);
            WriteLiteral(" /mês)</b> para <b>");
            EndContext();
            BeginContext(945, 15, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                                                                                                                                                                                                                   Write(Model._NewPrice);

#line default
#line hidden
            EndContext();
            BeginContext(960, 6, true);
            WriteLiteral("  (R$ ");
            EndContext();
            BeginContext(967, 22, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                                                                                                                                                                                                                                         Write(Model._MonthlyNewPrice);

#line default
#line hidden
            EndContext();
            BeginContext(989, 113, true);
            WriteLiteral(" /mês)</b>.<br /><br />\r\n        Alteração(ões) feita(s) pelo cliente:\r\n        <ul style=\"list-style:circle;\">\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
             if (Model.UpgradedPlan != null)
            {

#line default
#line hidden
            BeginContext(1163, 44, true);
            WriteLiteral("                <li>Alterou o plano para <b>");
            EndContext();
            BeginContext(1208, 23, false);
#line 17 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                       Write(Model.UpgradedPlan.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1231, 12, true);
            WriteLiteral("</b>;</li>\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
            }

#line default
#line hidden
            BeginContext(1258, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
             foreach (var item in Model.Especialidades)
            {

#line default
#line hidden
            BeginContext(1330, 49, true);
            WriteLiteral("                <li>Adicionou a especialidade <b>");
            EndContext();
            BeginContext(1380, 9, false);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
                                            Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1389, 12, true);
            WriteLiteral("</b>;</li>\r\n");
            EndContext();
#line 22 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\InsuredChangePlanEmail.cshtml"
            }

#line default
#line hidden
            BeginContext(1416, 33, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.DTO.SeguradoProfissional.InsuredChangePlanEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
