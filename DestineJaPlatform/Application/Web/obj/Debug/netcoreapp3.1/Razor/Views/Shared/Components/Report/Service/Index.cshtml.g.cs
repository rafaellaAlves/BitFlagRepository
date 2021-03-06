#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e2a9b33fb659ba83a6d7982abd52f1246697227"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_Service_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Report/Service/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e2a9b33fb659ba83a6d7982abd52f1246697227", @"/Views/Shared/Components/Report/Service/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_Service_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<List<DTO.Service.ServiceListViewModel>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "service-report-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Web.Utils.TagHelperScriptCut __Web_Utils_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
  
    var sendedStatusId = (await serviceStatusServices.GetDataByExternalCode("OSENVIADA")).ServiceStatusId;
    var signedStatusId = (await serviceStatusServices.GetDataByExternalCode("OSASSINADA")).ServiceStatusId;
    var scheduledStatusId = (await serviceStatusServices.GetDataByExternalCode("COLETAAGENDADA")).ServiceStatusId;
    var concludedStatusId = (await serviceStatusServices.GetDataByExternalCode("COLETACONCLUIDA")).ServiceStatusId;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header card-header-default card-header-destineja-green tx-uppercase justify-content-between  bg-gray-400"">
        <h6 class=""mg-b-0 tx-14 tx-inverse""><i class=""fa fa-table""></i>&nbsp;Tabela</h6>
        <div class=""card-option d-flex"">
            <button type=""button"" class=""btn btn-sm btn-primary d-flex mr-2"" style=""border-radius: 3px;"" onclick=""downloadListPrint(serviceReportTable, null, 'Relat??rio - Servi??os Avulsos')""><i class=""simple-icon-cloud-download""></i><span class=""d-none d-sm-block"">&nbsp;Download</span></button>
            <button type=""button"" class=""btn btn-sm btn-primary d-flex"" style=""border-radius: 3px;"" onclick=""openListPrint(serviceReportTable, null, 'Relat??rio - Servi??os Avulsos')""><i class=""simple-icon-printer""></i><span class=""d-none d-sm-block"">&nbsp;Imprimir</span></button>
            <a");
            BeginWriteAttribute("href", " href=\"", 1463, "\"", 1470, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""tx-gray-600 hover-white mg-l-10"" data-toggle=""collapse"" aria-expanded=""true"" data-target=""#service-report-table-area""><i class=""simple-icon-arrow-up lh-0""></i></a>
        </div>
    </div>
    <div class=""card-body bd collapse show"" id=""service-report-table-area"">
        <div class=""row"">
            <div class=""col table-responsive"">
                <table class=""table table-bordered table-striped table-condensed"" id=""service-report-table"">
                    <thead>
                        <tr>
                            <th>Ordem de Servi??o</th>
                            <th>Gerador</th>
                            <th>Valor do Frete</th>
                            <th>Valor do kg do res??duo</th>
                            <th>Peso (Kg)</th>
                            <th>Valor do Servi??o</th>
                            <th>Status</th>
                            <th>Servi??o feito em:</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                         foreach (var item in Model.Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>");
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                               Write(item.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 42 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                               Write(item.ClientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>R$ ");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                  Write(item._FreightPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>R$ ");
#nullable restore
#line 44 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                  Write(item._ResiduePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                               Write(item.WeightFormated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>R$ ");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                  Write(item._TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 47 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                               Write(item.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 48 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                               Write(item._LastDemandDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            </tr>\n");
#nullable restore
#line 50 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\n                </table>\n            </div>\n        </div>\n        <hr />\n        <div class=\"row\">\n            <div class=\"col-12 col-sm text-center\">\n                <label>O S Total: <b>");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                Write(Model.Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            </div>\n            <div class=\"col-12 col-sm text-center\">\n                <label>O S Assinada: <b>");
#nullable restore
#line 61 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                   Write(Model.Model.Count(x => x.ServiceStatusId == signedStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            </div>\n            <div class=\"col-12 col-sm text-center\">\n                <label>Coleta Agendada: <b>");
#nullable restore
#line 64 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                      Write(Model.Model.Count(x => x.ServiceStatusId == scheduledStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            </div>\n            <div class=\"col-12 col-sm text-center\">\n                <label>Coleta Conclu??da: <b>");
#nullable restore
#line 67 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                       Write(Model.Model.Count(x => x.ServiceStatusId == concludedStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            </div>\n            <div class=\"col-12 col-sm text-center\">\n                <label>Valor dos Servi??os: <b>");
#nullable restore
#line 70 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
                                         Write(Model.Model.Sum(x => x.TotalPrice).ToPtBR());

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></label>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e2a9b33fb659ba83a6d7982abd52f124669722712673", async() => {
                WriteLiteral(@"
    var serviceReportTable;

    $(document).ready(function () {
        serviceReportTable = $('#service-report-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            dom: 'tip',
            ordering: false
        });
    });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 76 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Service\Index.cshtml"
__Web_Utils_TagHelperScriptCut.LoadFromController = Model.LoadFromController;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-cut-key-load-from-controller", __Web_Utils_TagHelperScriptCut.LoadFromController, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Service.ServiceStatusServices serviceStatusServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<List<DTO.Service.ServiceListViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
