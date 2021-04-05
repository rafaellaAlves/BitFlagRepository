#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfa52d9775009196748c00f8d58a3c77972212b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RouteClient_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RouteClient/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfa52d9775009196748c00f8d58a3c77972212b3", @"/Views/Shared/Components/RouteClient/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RouteClient_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Route.RouteClientParametersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/route.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "route-client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Web.Utils.TagHelperScriptCut __Web_Utils_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 6 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
  
    var contratoTypeId = (await routeTypeServices.GetDataByExternalCode("CONTRATO"))?.RouteTypeId;

    var perDemandStatus = await contractPeriodicityServices.GetDataByExternalCode("PORDEMANDA");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bfa52d9775009196748c00f8d58a3c77972212b35654", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""row align-items-end justify-content-between"" id=""route-client-table-filter-area"">
    <div class=""col-md-auto form-group"">
        <button type=""button"" onclick=""openRouteClientModal()"" class=""btn btn-primary w-100""><i class=""simple-icon-plus""></i>&nbsp;Adicionar Geradores na Rota</button>
    </div>
    <div class=""col-md-auto form-group"">
        <label>Periodicidade (Filtro)</label>
        <select class=""form-control"" name=""FilterPeriodicity"" data-disabledAll=""false"" onchange=""routeClientTable.draw();"">
            <option");
            BeginWriteAttribute("value", " value=\"", 995, "\"", 1003, 0);
            EndWriteAttribute();
            WriteLiteral(">Selecione</option>\n");
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
             foreach (var item in (await contractPeriodicityServices.GetDataAsNoTrackingAsync()).OrderBy(x => x.Order))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <option");
            BeginWriteAttribute("value", " value=\"", 1181, "\"", 1216, 1);
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 1189, item.ContractPeriodicityId, 1189, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\n");
#nullable restore
#line 25 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </select>
    </div>
</div>
<div class=""row"">
    <div class=""col-12"">
        <div class=""alert alert-success"" role=""alert"" id=""client-table-insert-success-alert"" style=""display:none;""></div>
    </div>
</div>
<div class=""row"">
    <div class=""col table-responsive"">
        <table class=""nowrap table table-bordered table-condensed w-100"" id=""route-client-table"">
            <thead>
                <tr style=""background: #a1a1a1; color: white;"">
                    <th></th>
                    <th>Sequência</th>
                    <th>Código</th>
                    <th>Razão Social</th>
                    <th>Nome Fantasia</th>
                    <th>Cidade</th>
                    <th>Bairro</th>
                    <th>Endereço</th>
                    <th>Família</th>
                    <th>Periodicidade</th>
                    <th>Situação</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 54 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                 foreach (var item in Model.RouteClient.OrderBy(x => x.Order))
                {
                    var addressId = item.ClientCollectionAddressId;


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr data-addressId=\"");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                   Write(addressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("style", " style=\"", 2438, "\"", 2478, 2);
            WriteAttributeValue("", 2446, "background-color:", 2446, 17, true);
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue(" ", 2463, item.RowColor, 2464, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-contractId=\"");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                                         Write(item.ContractId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-serviceId=\"");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                                                                           Write(item.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                        <td><i class=\"simple-icon-shuffle\"></i></td>\n                        <td class=\"text-center\">");
#nullable restore
#line 60 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                           Write(item.Order);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td><a data-disabledAll=\"false\"");
            BeginWriteAttribute("href", " href=\"", 2738, "\"", 2803, 1);
#nullable restore
#line 61 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 2745, Url.Action("Manage", "Client", new { id = item.ClientId}), 2745, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 61 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                                                                     Write(item.ClientId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\n                        <td>");
#nullable restore
#line 62 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write(item.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 63 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write(item.TradeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 64 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 65 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write(item.Neighborhood);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 66 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 66 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                      Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>\n                            <span class=\"address-family-name\" data-addressId=\"");
#nullable restore
#line 68 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                         Write(addressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 68 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                     Write(item.ResidueFamilyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                        </td>\n");
#nullable restore
#line 70 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                         if (Model.Route.RouteTypeId == contratoTypeId)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td data-filter=\"");
#nullable restore
#line 72 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                        Write(item.PeriodicityId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 72 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                             Write(item.PeriodicityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 73 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td data-filter=\"");
#nullable restore
#line 76 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                        Write(perDemandStatus.ContractPeriodicityId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 76 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                Write(perDemandStatus.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 77 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 78 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                        Write(item.InOtherRoutesCount > 1? "Em mais de uma rota" : item.SituationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>\n                            <div class=\"text-center\">\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3917, "\"", 4014, 9);
            WriteAttributeValue("", 3924, "javascript:openSelectResidueFamilyModal(", 3924, 40, true);
#nullable restore
#line 81 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 3964, addressId, 3964, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3974, ",", 3974, 1, true);
            WriteAttributeValue(" ", 3975, "\'", 3976, 2, true);
#nullable restore
#line 81 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 3977, item.ContractId, 3977, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3993, "\',", 3993, 2, true);
            WriteAttributeValue(" ", 3995, "\'", 3996, 2, true);
#nullable restore
#line 81 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 3997, item.ServiceId, 3997, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4012, "\')", 4012, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-pill badge-info\"><i class=\"simple-icon-basket-loaded\"></i></a>&nbsp;\n                                <a");
            BeginWriteAttribute("href", " href=\"", 4138, "\"", 4187, 3);
            WriteAttributeValue("", 4145, "javascript:removeClientAddress(", 4145, 31, true);
#nullable restore
#line 82 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
WriteAttributeValue("", 4176, addressId, 4176, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4186, ")", 4186, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-pill badge-danger\"><i class=\"simple-icon-trash\"></i></a>\n                            </div>\n                        </td>\n                    </tr>\n");
#nullable restore
#line 86 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<hr />
<div class=""row"">
    <div class=""col-md-2"">
        <b style=""display: inline-flex; margin-bottom: 10px; margin-top: 7px;"">Totalizador da Rota</b>
        <input id=""route-manage-address-count"" class=""form-control"" disabled />
    </div>
    <div class=""col-md-10"">
        <div class=""card card-body tx-mutted bd-0"" style="" padding-bottom: 1px; padding-top: 7px;"">
            <div class=""row"" style=""padding: 5px;"">
                <div class=""col-6 col-md legend text-md-center"" style=""padding-top: 0;"">
                    <b style=""display: inline-flex; margin-bottom: 10px;"">Legendas</b>
                    <br />
                    <div style=""background: #8ccee6;""></div>
                    <label style=""margin-left:0;"">Encerrado</label>
                </div>
                <div class=""col-6 col-md legend text-md-center"">
                    <div style=""background: #f0a1a1;""></div>
                    <label>Inadimplente</label>
             ");
            WriteLiteral(@"   </div>
                <div class=""col-6 col-md legend text-md-center"">
                    <div style=""background: #f9d5ad;""></div>
                    <label>Sem Contrato</label>
                </div>
                <div class=""col-6 col-md legend text-md-center"">
                    <div style=""background: #d1d1d1;""></div>
                    <label>Suspenso</label>
                </div>
                <div class=""col-6 col-md legend text-md-center"">
                    <div style=""background: #c9adf0;""></div>
                    <label>A expirar</label>
                </div>
                <div class=""col-6 col-md legend text-md-center"">
                    <div style=""background:white;""></div>
                    <label>Regular</label>
                </div>
            </div>
        </div>
    </div>
</div>

<modal id=""route-client-modal"" title-id=""route-client-modal-title"" title=""Adicionar Geradores na Rota"" modal-lg=""true"" hide-footer=""true"">
    ");
#nullable restore
#line 132 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
Write(await Component.InvokeAsync<Web.ViewComponents.Route.RouteClientSelectionViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</modal>

<div class=""modal fade"" id=""route-client-family-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""route-client-modal-family-title"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"" id=""route-client-modal-family-title"">Familías vinculadas ao Contrato/Serviço do Gerador</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""route-client-family-modal-view-component""></div>
            </div>
            <div class=""modal-footer"">
                <button class=""btn btn-success"" type=""button"" onclick=""_selectResidueFamiliesCallback()"">Salvar</button>
            </div>
        </div>
    </d");
            WriteLiteral("iv>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfa52d9775009196748c00f8d58a3c77972212b324084", async() => {
                WriteLiteral("\n    //guarda as familias selecionadas para cada cliente\n    var addressFamilyIds = [];\n    var routeClientTable;\n");
#nullable restore
#line 158 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
     foreach (var item in Model.RouteClient)
    {
        var addressId = item.ClientCollectionAddressId;
        if (item._RouteResidueFamilyIds.Count == 0){ continue; }

        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            addressFamilyIds.push({\n                familyIds: ");
#nullable restore
#line 165 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                       Write($"[{string.Join(",", item._RouteResidueFamilyIds)}]");

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n                clientCollectionAddressId: \'");
#nullable restore
#line 166 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                        Write(item.ClientCollectionAddressId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\n            });\n        ");
#nullable restore
#line 168 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
               
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    $(document).ready(function () {
        routeClientTable = $('#route-client-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            scrollY: '400px',
            scrollCollapse: true,
            paging: false,
            columnDefs: [
                { orderable: true, className: 'text-center reorder', targets: 1 },
                { targets: [0], orderData: [1] },
                { orderable: false, targets: [0, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
            ],
            rowReorder: { dataSrc: 1 },
            drawCallback: function () {
                $('#route-manage-address-count').val($(this).DataTable().rows().count());

                //Atualza visualmente os numeros da coluna ""Sequência""
                $('#route-client-table').DataTable().rows({ order: 'applied' }).nodes().each(function (e, i) {
                    var td = $(e).find('td')[1];
                    if(td != ");
                WriteLiteral(@"null) td.innerHTML = i + 1;
                });

                setTimeout(function () {
                    $('#route-client-table').DataTable().columns.adjust();
                }, 1); //atualiza a largura das colunas
            }
        });
    });

    function openRouteClientModal() {
        $('#route-client-modal .text-danger').remove();
        $('#route-client-modal input, #route-client-modal select').val('');//limpa os campos

        if (routeClientAddTable != null) {
            routeClientAddTable.rows().remove();
            routeClientAddTable.draw();
        }
        if (routeClientAddressAddTable != null) {
            routeClientAddressAddTable.rows().remove();
            routeClientAddressAddTable.draw();
        }

        $('#route-client-modal').modal('show');

        $('#route-client-modal').on('shown.bs.modal', function () {
            routeClientAddressAddTable.columns.adjust(); //atualiza a largura das colunas
            routeClientAddTable.columns.adjust();

            init");
                WriteLiteral("SearchDataTable();\n        });\n    }\n\n    function setAddressInRoute(p)\n    {\n        if (p.length == 0) return;\n        var index = $(\'#route-client-table\').DataTable().rows().count() + 1;\n        $.post(\'");
#nullable restore
#line 230 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
           Write(Url.Action("GetClientAddresses", "Route"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', p, function (d) {
            $.each(d, function (i, e) {
                var isContract = e.contractId != null;

                if ($('#route-client-table tr[data-addressId=""' + e.clientCollectionAddressId + '""]').length > 0) return;

                var r = $('#route-client-table').DataTable().row.add(
                    $('<tr>').append(
                        $('<td>').append('<i class=""simple-icon-shuffle""></i>'),
                        $('<td>').append(index + i),
");
                WriteLiteral("                        $(\'<td>\').append(\'<a href=\"");
#nullable restore
#line 241 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                              Write(Url.Action("Manage","Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + e.clientId + '"" target=""_blank"">' + e.clientId + '</a>'),
                        $('<td>').append(e.companyName),
                        $('<td>').append(e.tradeName),
                        $('<td>').append(e.city),
                        $('<td>').append(e.neighborhood),
                        $('<td>').append(e.address + ', ' + e.number),
                        $('<td>').append('<span class=""address-family-name"" data-addressId=""' + e.clientCollectionAddressId + '""""></span>'),
                        ($('#RouteTypeId').val() == '");
#nullable restore
#line 248 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                Write(contratoTypeId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' ? $(\'<td>\', { \'data-filter\': e.periodicityId }).append(e.periodicityName) : $(\'<td>\', { \'data-filter\': \'");
#nullable restore
#line 248 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                                                                                                         Write(perDemandStatus.ContractPeriodicityId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' }).append(\'");
#nullable restore
#line 248 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                                                                                                                                                                            Write(perDemandStatus.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"')),
                        $('<td>').append(e.inOtherRoute ? 'Em mais de uma rota' : e.situationName),
                        $('<td>').append('<div class=""text-center""><a data-address-id=""' + e.clientCollectionAddressId + '"" href=""javascript:openSelectResidueFamilyModal(' + e.clientCollectionAddressId + ', ' + isNull(e.contractId, null) + ', ' + isNull(e.serviceId, null) + ')"" class=""badge badge-pill btn-teal badge-insert-families""><i class=""simple-icon-basket-loaded""></i></a>&nbsp;<a href=""javascript:removeClientAddress(' + e.clientCollectionAddressId + ')"" class=""badge badge-pill badge-danger""><i class=""simple-icon-trash""></i></a></div>')
                    )
                );

                $(r.node()).attr('data-addressId', e.clientCollectionAddressId);
                $(r.node()).attr('data-contractId', e.contractId);
                $(r.node()).attr('data-serviceId', e.serviceId);

                $(r.node()).css('background-color', e.rowColor);
            });

            $('#route-client-tabl");
                WriteLiteral(@"e').DataTable().draw();
            $('#route-client-table').DataTable().columns.adjust();

            _setSelectedClientAsUnselectable();

            $('#client-table-insert-success-alert').show();
            $('#client-table-insert-success-alert').text(d.length + ' geradores foram incluídos na rota!');
            setTimeout(function () { $('#client-table-insert-success-alert').fadeOut(2000); }, 8000);
            $('#route-client-modal').modal('hide');
        });
    }

    //desabilita os checkboxes de endereços adicionados a lista
    function _setSelectedClientAsUnselectable()
    {
        setSelectedClientAsUnselectable($('#route-client-table tr[data-addressId]').map(function (i, e) {
            return {
                addressId: $(e).data('addressid')
            }
        }));
    }

    function openSelectResidueFamilyModal(addressId, contractId, serviceId) {
        $('#route-client-family-modal-view-component').empty();

        if ($('#RouteTypeId').length > 0 && $('#RouteTypeId').val() ==");
                WriteLiteral(" \'");
#nullable restore
#line 286 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                                   Write(contratoTypeId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\') {\n            serviceId = null;\n        } else {\n            contractId = null;\n        }\n\n        $(\'#route-client-family-modal-view-component\').load(\'");
#nullable restore
#line 292 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteClient\Default.cshtml"
                                                        Write(Url.Action("RouteResidueFamilyViewComponent", "Route"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { addressId, contractId, serviceId }, function () {
            $('#route-client-family-modal').modal('show');

            //Setar famílias já selecionadas
            var index = addressFamilyIds.findIndex(x => (x.clientCollectionAddressId == addressId));

            if (index != -1) {
                $.each(addressFamilyIds[index].familyIds, function (i, e) {
                    var elem = $('#route-client-families-selection-table input[type=""checkbox""][data-family-id=""' + e + '""]');
                    if (elem.length == 0) return;

                    elem[0].checked = true;
                });
            }
        });
    }

    function selectResidueFamiliesCallback(d)
    {
        //remove o dado do cliente caso ele já exista
        var index = addressFamilyIds.findIndex(x => x.clientCollectionAddressId == d.clientCollectionAddressId);

        if (index != -1) addressFamilyIds.splice(index, 1);

        if (d.families.length > 0) { //caso não tenha adicionado família e clique em salvar não set");
                WriteLiteral(@"a os dados
            addressFamilyIds.push({
                familyIds: d.families.map(function (e, i) { return e.id; }),//apenas o Id da familia vai ser usado para salvar
                clientCollectionAddressId: d.clientCollectionAddressId
            });
        }

        //Colocando a classe das famílias selecionadas na lista
        var spanFamilyName = $('.address-family-name[data-addressId=""' + (d.clientCollectionAddressId) + '""]');

        spanFamilyName.text(
            d.families.map(function (e, i) { return e.name; })//obtendo o nome das classes das famílias selecionadas
            .join('/')
        );

        $('#route-client-family-modal').modal('hide');

        //mensagem de sucesso
        $('#client-table-insert-success-alert').show();
        $('#client-table-insert-success-alert').text('Famílias inseridas com sucesso!');
        setTimeout(function () { $('#client-table-insert-success-alert').fadeOut(2000); }, 8000);

        //altera o estilo do botão
        $('.badge-insert-fami");
                WriteLiteral(@"lies[data-address-id=""' + d.clientCollectionAddressId + '""]').removeClass('btn-teal').addClass('badge-info');
    }

    function removeClientAddress(addressId)
    {
        bootboxConfirm('Deseja realmente remover este endereço da Rota?', function (d) {
            if (!d) return;

            routeClientTable.row($('#route-client-table tr[data-addressId=""' + addressId + '""]')).remove();
            routeClientTable.draw();

            //remove as familias do cliente caso exista
            var index = addressFamilyIds.findIndex(x => x.clientCollectionAddressId == addressId);

            if (index != -1) addressFamilyIds.splice(index, 1);

            $('#route-client-table').DataTable().columns.adjust();
        });
    }

    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            if (settings.sInstance != ""route-client-table"") return true;

            var periodicity = $('#route-client-table-filter-area [name=""FilterPeriodicity""]').val();

            return isNullOr");
                WriteLiteral("WhiteSpace(periodicity) || periodicity == $(settings.aoData[dataIndex].anCells[9]).data(\'filter\');\n        }\n    );\n");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
        public Services.Route.RouteTypeServices routeTypeServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Contract.ContractPeriodicityServices contractPeriodicityServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Route.RouteClientParametersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
