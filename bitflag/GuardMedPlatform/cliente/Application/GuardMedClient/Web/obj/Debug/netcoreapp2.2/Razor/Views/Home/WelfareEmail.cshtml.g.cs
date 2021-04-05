#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66848413bdc968c74727fe100d235b32fdf930ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WelfareEmail), @"mvc.1.0.view", @"/Views/Home/WelfareEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/WelfareEmail.cshtml", typeof(AspNetCore.Views_Home_WelfareEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66848413bdc968c74727fe100d235b32fdf930ae", @"/Views/Home/WelfareEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WelfareEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web.DTO.Welfare.WelfareEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 524, true);
            WriteLiteral(@"
<div style=""width: 45%; margin-left: 33%; border: 1px solid #cecece; -webkit-box-shadow: -1px -5px 20px 0px #b5b5b5; box-shadow: -1px -5px 20px 0px #b5b5b5; background: linear-gradient(to bottom, #e2e2e2, #e2e2e2 70px, #a8c6e28a 250px, #adc2d8);""> 
    <div style=""padding: 15px; font-weight: bold; font-size: 25px; text-align: center;"">
        <img src=""cid:LogoImg"" width=""300"">
        <div style=""margin-top: 1em;"">
            - Nova Solicitação -<br />
            Atendimento Psicológico<br />
            # ");
            EndContext();
            BeginContext(571, 37, false);
#line 9 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
         Write(Model.SeguradoProfissional.Referencia);

#line default
#line hidden
            EndContext();
            BeginContext(608, 239, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div style=\"padding: 15px; font-size: 16px; line-height: 25px; padding-bottom: 40px;\">\r\n        Foi realizada uma solicitação de agendamento para atendimento psicológico.<br /><br />\r\n        O cliente <b>");
            EndContext();
            BeginContext(848, 31, false);
#line 14 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                Write(Model.SeguradoProfissional.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(879, 44, true);
            WriteLiteral("</b> realizou uma solicitação para o dia <b>");
            EndContext();
            BeginContext(924, 11, false);
#line 14 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                                                                                            Write(Model._Date);

#line default
#line hidden
            EndContext();
            BeginContext(935, 20, true);
            WriteLiteral("</b> no período: <b>");
            EndContext();
            BeginContext(956, 13, false);
#line 14 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                                                                                                                            Write(Model._Period);

#line default
#line hidden
            EndContext();
            BeginContext(969, 13, true);
            WriteLiteral("</b>.<br />\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.SeguradoProfissional.Telefone) || !string.IsNullOrWhiteSpace(Model.SeguradoProfissional.Celular))
        {

#line default
#line hidden
            BeginContext(1138, 88, true);
            WriteLiteral("            <label>É possível entrar em contato com o cliente pelo telefone/celular: <b>");
            EndContext();
            BeginContext(1228, 136, false);
#line 17 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                                                                                    Write(!string.IsNullOrWhiteSpace(Model.SeguradoProfissional.Celular)? Model.SeguradoProfissional.Celular : Model.SeguradoProfissional.Telefone);

#line default
#line hidden
            EndContext();
            BeginContext(1365, 24, true);
            WriteLiteral("</b> ou pelo e-mail: <b>");
            EndContext();
            BeginContext(1390, 32, false);
#line 17 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                                                                                                                                                                                                                                                      Write(Model.SeguradoProfissional.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1422, 15, true);
            WriteLiteral("</b>.</label>\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1473, 78, true);
            WriteLiteral("            <label>É possível entrar em contato com o cliente pelo e-mail: <b>");
            EndContext();
            BeginContext(1552, 32, false);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
                                                                         Write(Model.SeguradoProfissional.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1584, 15, true);
            WriteLiteral("</b>.</label>\r\n");
            EndContext();
#line 22 "C:\repositorios\bitflag\GuardMedPlatform\cliente\Application\GuardMedClient\Web\Views\Home\WelfareEmail.cshtml"
        }

#line default
#line hidden
            BeginContext(1610, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.DTO.Welfare.WelfareEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591