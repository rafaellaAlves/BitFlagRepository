#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b98795cc77fe04dba86bbffa0da208ed1b8d15a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HomeClient_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HomeClient/Default.cshtml")]
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
#nullable restore
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b98795cc77fe04dba86bbffa0da208ed1b8d15a3", @"/Views/Shared/Components/HomeClient/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HomeClient_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Home.HomeClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 7 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
  
    var clientId = await clientServices.GetClientIdByLoggedUser(Context);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n");
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
 if (await contractServices.ClientHasAnyContractOrService(clientId))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md form-group"">
            <div class=""card pd-20 tx-white pd-sm-25 bg-primary"">
                <div class=""d-flex align-items-center justify-content-between mg-b-10"">
                    <h6 class=""card-body-title tx-white-8 tx-12 tx-spacing-1"">Coletas Realizadas</h6>
                </div><!-- d-flex -->
                <div class=""d-flex align-items-center pb-2 justify-content-between"">
                    <img");
            BeginWriteAttribute("src", " src=\"", 862, "\"", 916, 1);
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
WriteAttributeValue("", 868, Url.Content("~/Imagens/graficos_home/azul.png"), 868, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\" height: 45px; width: 60px;\" />\n                    <h6 class=\"mg-b-0 mr-3 tx-white tx-lato tx-bold\">");
#nullable restore
#line 23 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                                 Write(Model.FinishedCollections ?? (object)"-");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                </div>
                <div class=""d-flex align-items-center justify-content-between bd-t bd-white-2 pd-t-10"">
                    <div>
                        <span class=""tx-11 tx-white-6"">Coletas do contrato</span>
                        <h6 class=""tx-white mg-b-0"">");
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                Write(Model.TotalCollections ?? (object)"-");

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                    </div>\n                    <div>\n                        <span class=\"tx-11 tx-white-6\">Restante</span>\n                        <h6 class=\"tx-white mg-b-0\">");
#nullable restore
#line 32 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                Write(Model.RemainingCollections ?? (object)"-");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                    </div>
                </div>
            </div><!-- card -->
        </div>
        <div class=""col-md form-group"">
            <div class=""card pd-20 pd-sm-25 bg-info"">
                <div class=""d-flex align-items-center justify-content-between mg-b-10"">
                    <h6 class=""card-body-title tx-white-8 tx-12 tx-spacing-1"">Seu Peso Restante</h6>
                </div><!-- d-flex -->
                <div class=""d-flex align-items-center pb-2 justify-content-between"">
                    <img");
            BeginWriteAttribute("src", " src=\"", 2161, "\"", 2221, 1);
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
WriteAttributeValue("", 2167, Url.Content("~/Imagens/graficos_home/azul_claro.png"), 2167, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\" height: 45px; width: 60px;\" />\n                    <h6 class=\"mg-b-0 mr-3 tx-white tx-lato tx-bold\">");
#nullable restore
#line 44 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                                 Write(!string.IsNullOrWhiteSpace(Model._RemainingWeight)? $"{Model._RemainingWeight} Kg" : "-");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                </div>
                <div class=""d-flex align-items-center justify-content-between bd-t bd-white-2 pd-t-10"">
                    <div>
                        <span class=""tx-11 tx-white-6"">Contratado</span>
                        <h6 class=""tx-white mg-b-0"">");
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                Write(Model._ContractedWeight ?? (object)"-");

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                    </div>\n                    <div>\n                        <span class=\"tx-11 tx-white-6\">Utilizado</span>\n                        <h6 class=\"tx-white mg-b-0\">");
#nullable restore
#line 53 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                Write(string.IsNullOrWhiteSpace(Model._RemainingWeight)? "-" : Model._CollectedWeight);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                    </div>
                </div>
            </div><!-- card -->
        </div>
        <div class=""col-md form-group"">
            <div class=""card pd-20 pd-sm-25 bg-purple"">
                <div class=""d-flex align-items-center justify-content-between mg-b-10"">
                    <h6 class=""card-body-title tx-white-8 tx-12 tx-spacing-1"">Valor da Mensalidade</h6>
                </div><!-- d-flex -->
                <div class=""d-flex align-items-center pb-2 justify-content-between"">
                    <img");
            BeginWriteAttribute("src", " src=\"", 3550, "\"", 3604, 1);
#nullable restore
#line 64 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
WriteAttributeValue("", 3556, Url.Content("~/Imagens/graficos_home/roxo.png"), 3556, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\" height: 45px; width: 60px;\" />\n                    <h6 class=\"mg-b-0 mr-3 tx-white tx-lato tx-bold\">R$ ");
#nullable restore
#line 65 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                                   Write(Model._ContractMonthlyPrice.IfNullChange("-"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                </div>
                <div class=""d-flex align-items-center justify-content-between bd-t bd-white-2 pd-t-10"">
                    <div>
                        <span class=""tx-11 tx-white-6"">&nbsp;</span>
                        <h6 class=""tx-white mg-b-0"">&nbsp;</h6>
                    </div>
                    <div>
                        <span class=""tx-11 tx-white-6"">&nbsp;</span>
                        <h6 class=""tx-white mg-b-0"">&nbsp;</h6>
                    </div>
                </div>
            </div><!-- card -->
        </div>
        <div class=""col-md form-group"">
            <div class=""card pd-20 pd-sm-25 bg-sl-primary"">
                <div class=""d-flex align-items-center justify-content-between mg-b-10"">
                    <h6 class=""card-body-title tx-white-8 tx-12 tx-spacing-1"">previs??o da pr??xima coleta</h6>
                </div><!-- d-flex -->
                <h5 class=""tx-white tx-center"" style=""margin-bottom: 30px;"">");
#nullable restore
#line 84 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                                       Write(Model._NextColletionDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                <div class=""d-flex align-items-center justify-content-between bd-t bd-white-2 pd-t-10"">
                    <div>
                        <span class=""tx-11 tx-white-6"">Sua Rota</span>
                        <h6 class=""tx-white mg-b-0"">");
#nullable restore
#line 88 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                                Write(Model.Route ?? (object)"-");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                    </div>
                    <div>
                        <span class=""tx-11 tx-white-6"">Ver Listagem</span>
                        <h6 class=""tx-white mg-b-0 text-center""><i style=""cursor:pointer;"" data-toggle=""modal"" data-target=""#collections-modal"" class=""fa fa-external-link""></i></h6>
                    </div>
                </div>
            </div><!-- card -->
        </div>
    </div>
");
            WriteLiteral("    <div class=\"row mt-2\">\n        <div class=\"col form-group\">\n            ");
#nullable restore
#line 101 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Home.HomeLastMonthlyCollectionsViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\"w-100\"></div>\n        <div class=\"col form-group\">\n            ");
#nullable restore
#line 105 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Home.HomeClientDemandClientTableViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\"w-100\"></div>\n        <div class=\"col-md-6 col-12 form-group\">\n            ");
#nullable restore
#line 109 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Home.HomeClientResidueFamilyChartViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\"col-md-6 col-12 form-group\">\n            ");
#nullable restore
#line 112 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Home.HomeClientResidueTableViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n");
            WriteLiteral(@"    <div class=""modal fade"" id=""collections-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""collections-modal-title"" aria-hidden=""true"">
        <div class=""modal-dialog"" style=""width: 500px;"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""collections-modal-title"">Coletas</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    ");
#nullable restore
#line 126 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                Write(await Component.InvokeAsync<Web.ViewComponents.Home.HomeClient.HomeClientCollectionsViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""simple-icon-close""></i> Fechar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 134 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\n        <div class=\"col text-center text-destineja-xl\">\n");
#nullable restore
#line 139 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
               var user = await userManager.FindByNameAsync(User.Identity.Name); 

#line default
#line hidden
#nullable disable
            WriteLiteral("            Seja Bem-Vindo(a) ");
#nullable restore
#line 140 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                         Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 140 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
                                         Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <hr />\n    <div class=\"alert alert-destineja tx-22 text-center mt-5\" role=\"alert\">\n        Ops!!! Voc?? ainda n??o solicitou a sua coleta.\n    </div>\n");
#nullable restore
#line 147 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClient\Default.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientServices clientServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Contract.ContractServices contractServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.UserManager<AspNetIdentityDbContext.User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Home.HomeClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
