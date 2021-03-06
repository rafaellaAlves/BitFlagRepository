#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59dbae5a2c5478d7db83f519f97e17f1a7be327a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DemandDestinationDemand_Default), @"mvc.1.0.view", @"/Views/Shared/Components/DemandDestinationDemand/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59dbae5a2c5478d7db83f519f97e17f1a7be327a", @"/Views/Shared/Components/DemandDestinationDemand/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DemandDestinationDemand_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<DTO.DemandDestination.DemandDestinationDemandParamenterViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "demand-destination-demand", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
  
    var demands = demandDestinationServices.GetDemandForDemandDestinationNotAsync(Model.Model.ResidueFamilyId.Value, Model.Model.DemandDestination.DepartureDate);
    //var demands = await demandListServices.GetViewModelAsNoTrackingAsync(x => !x.IsDeleted && Model.Model.DemandDestination.DepartureDate >= x.DepartureDate);//Obtem apenas as coletas no qual a data ?? anterior a data de destina????o

    double totalWeight = 0;

    var usedDemand = demandDestinationDemandServices.GetUsedDemandsNotAsync(Model.Model.DemandDestination.DemandDestinationId);
    demands = demands.Where(x => !usedDemand.Any(c => c.DemandId == x.DemandId && c.ResidueFamilyId == Model.Model.ResidueFamilyId)).ToList(); //N??o obtem as Coletas j?? utilizadas

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style type=""text/css"">
    .input-group > .select2-container--bootstrap {
        /*width: auto !important;*/
        flex: 1 1 auto;
    }

        .input-group > .select2-container--bootstrap .select2-selection--single {
            height: 37px;
            line-height: inherit;
            padding: 0.5rem 1rem;
        }

    #demand-destination-demand-table td:last-child {
        white-space: nowrap;
    }
</style>

<input type=""hidden"" class=""weight"" />
");
            WriteLiteral("\n<div id=\"demand-destination-demand-form-area\">\n");
#nullable restore
#line 40 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
     if (Model.CanEdit())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\n            <div class=\"col\">\n                <div class=\"input-group mb-3\" id=\"input-group-demand\">\n                    <div class=\"input-group-addon d-none d-sm-block\" style=\" height: 37px;\">\n                        <span");
            BeginWriteAttribute("class", " class=\"", 2110, "\"", 2118, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"inputGroup-sizing-default\" style=\"background-color: #F2F2F2\">Escolha o MTR de Coleta</span>\n                    </div>\n");
#nullable restore
#line 48 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                     if (!Model.Model.DemandDestination.DemandDestinationId.HasValue)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <select name=\"DemandId\" class=\"form-control required\">\n                            <option");
            BeginWriteAttribute("value", " value=\"", 2465, "\"", 2473, 0);
            EndWriteAttribute();
            WriteLiteral(">Selecione</option>\n                        </select>\n");
#nullable restore
#line 53 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                   Write(Html.DropDownList("DemandId", dropDownListHelper.ToSelectListItem(demands, x => x.DemandId, x => $"MTR - {x.DestinaJaDemandId} | Data Sa??da - {x._DepartureDate} | Data Chegada - {x._ArriveDate} | Peso (Kg) - {x.TotalWeight}", ""), "Selecione", new { Class = "form-control, required" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                                                                                                                                                                                                                                                                                                      
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""input-group-append"">
                        <button type=""button"" style=""height: 37px; display: flex;"" class=""btn btn-primary"" onclick=""addDemandToTable()""><i class=""simple-icon-plus""></i><span class=""d-none d-sm-block"">&nbsp;Vincular</span></button>
                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 64 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<hr />
<div class=""row"">
    <div class=""col table-responsive"">
        <table id=""demand-destination-demand-table"" class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important;"">
            <thead>
                <tr>
                    <th style=""text-align:center"">MTR</th>
                    <th style=""text-align:center"">Sa??da</th>
                    <th style=""text-align:center"">Chegada</th>
                    <th style=""text-align:center"">Rota</th>
                    <th style=""text-align:center"">Qtd Geradores</th>
                    <th style=""text-align:center"">Peso (Kg)</th>
                    <th style=""text-align:center"">Status Coleta</th>
                    <th style=""text-align:center"">Status Demanda</th>
                    <th style=""width: 60px !important;"">&nbsp;</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 84 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                 foreach (var item in Model.Model.DemandList)
                {
                    var weight = Model.Model.ResidueFamilyId.HasValue ? demandResidueFamilyTotalWeightServices.GetFirstData(x => x.DemandId == item.DemandId && x.ResidueFamilyId == Model.Model.ResidueFamilyId)?.TotalWeight ?? 0 : item.TotalWeight;

                    totalWeight += weight;


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr data-demand-id=\"");
#nullable restore
#line 90 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                   Write(item.DemandId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-weight=\"");
#nullable restore
#line 90 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                                                Write(weight.ToWeightPtBr());

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                        <td class=\"text-center\">");
#nullable restore
#line 91 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                           Write(item.DestinaJaDemandId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td class=\"text-center\">");
#nullable restore
#line 92 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                           Write(item._DepartureDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td class=\"text-center\">");
#nullable restore
#line 93 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                           Write(item._ArriveDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 94 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                        Write($"{item.RouteId} - {item.RouteName}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td class=\"text-center\">");
#nullable restore
#line 95 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                           Write(item.TotalClient);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td class=\"text-center\">");
#nullable restore
#line 96 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                           Write(weight.ToWeightPtBr());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 97 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                       Write(item.DemandStatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 98 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                        Write(item.Closed? "Fechada" : "Aberta");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                        <td>\n                            <div class=\"text-center\">\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5382, "\"", 5435, 3);
            WriteAttributeValue("", 5389, "javascript:openDemandInfoModal(", 5389, 31, true);
#nullable restore
#line 102 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
WriteAttributeValue("", 5420, item.DemandId, 5420, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5434, ")", 5434, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-pill badge-primary\" title=\"Visualizar Informa????es\"><i class=\"simple-icon-magnifier\"></i></a>&nbsp;\n");
#nullable restore
#line 103 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                 if (Model.CanEdit())
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 5681, "\"", 5727, 3);
            WriteAttributeValue("", 5688, "javascript:removeDemand(", 5688, 24, true);
#nullable restore
#line 105 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
WriteAttributeValue("", 5712, item.DemandId, 5712, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5726, ")", 5726, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-pill badge-danger\" title=\"Remover\"><i class=\"simple-icon-trash\"></i></a>\n");
#nullable restore
#line 106 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\n                        </td>\n                    </tr>\n");
#nullable restore
#line 110 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n<div class=\"row mt-4\">\n    <div class=\"col\">\n        <h4>Peso Total:&nbsp;<b id=\"total-weight\">");
#nullable restore
#line 117 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                             Write(totalWeight.ToWeightPtBr());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>&nbsp;<b>(Kg)</b></h4>
    </div>
</div>

<div class=""modal fade"" id=""demand-info-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""demand-info-modal-title"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg w-100"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"" id=""demand-info-modal-title"">Informa????es da Demanda</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""demand-info-view-component""></div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""simple-icon-close""></i>&nbsp;Fechar</button>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59dbae5a2c5478d7db83f519f97e17f1a7be327a17975", async() => {
                WriteLiteral("\n    var demandDestinationDemandDatatables;\n    var totalWeight = 0;\n\n    $(document).ready(function () {\n        totalWeight = Globalize.parseFloat(Globalize.format(isNull(\'");
#nullable restore
#line 145 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                                               Write(totalWeight.ToWeightPtBr());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', 0)));

        demandDestinationDemandDatatables = $('#demand-destination-demand-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            scrollY: '400px',
            scrollCollapse: true,
            paging: false,
            drawCallback: function () {
                $('#demand-destination-demand-table').DataTable().columns.adjust();
            }
        });

        $('#demand-destination-demand-form-area [name=""DemandId""]').select2({
            theme: ""bootstrap"",
            placeholder: ""Selecione"",
            allowClear: true,
            ""language"": {
                ""noResults"": function () {
                    return ""Nenhum resultado encontrado."";
                }
            }
        });
    });

    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            if (settings.sInstance != ""demand-destination-demand-table"") return true;

 ");
                WriteLiteral(@"           var r = true;

            var demandStatusId = $('#demand-index-table-filter-area [name=""DemandStatusId""]').val();

            var statusID = $('#demand-index-table-filter-area [name=""StatusId""]').val();

            r = isNullOrWhiteSpace(statusID) || statusID == $(settings.aoData[dataIndex].anCells[6]).find('[data-status-id]').data('status-id');

            return r;
        }
    );

    function addDemandToTable()
    {
        if (!validateInputs('demand-destination-demand-form-area')) return;
        if ($('#demand-destination-demand-table tr[data-demand-id=""' + $('#demand-destination-demand-form-area [name=""DemandId""]').val() + '""]').length > 0) {
            $('#input-group-demand').after('<small class=""text-danger"">Esta demanda j?? est?? selecionada.</small>');
            return;
        }

        $.post('");
#nullable restore
#line 197 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
           Write(Url.Action("GetViewModelByIdForDemandDestination", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { demandId: $('#demand-destination-demand-form-area [name=""DemandId""]').val(), residueFamilyId: $('#demand-destination-manage-form-area [name=""ResidueFamilyId""]').val() }, function (d) {
            if (d.hasError) {
                bootbox.alert(d.message);
                return;
            }

            if (!isNaN(Globalize.parseFloat(Globalize.format(isNull(d.demandResidueFamilyTotalWeight, 0))))) {
                increaseTotalWeight(Globalize.parseFloat(Globalize.format(isNull(d.demandResidueFamilyTotalWeight, 0))));
            }

            var r = demandDestinationDemandDatatables.row.add(
                $('<tr>').append(
                    $('<td>', { class: ""text-center"" }).append(d.data.destinaJaDemandId),
                    $('<td>', { class: ""text-center"" }).append(d.data._DepartureDate),
                    $('<td>', { class: ""text-center"" }).append(d.data._ArriveDate),
                    $('<td>').append(d.data.routeId + ' - ' + d.data.routeName),
                    $('<td>', { clas");
                WriteLiteral(@"s: ""text-center"" }).append(d.data.totalClient),
                    $('<td>', { class: ""text-center"" }).append(d.demandResidueFamilyTotalWeight),
                    $('<td>').append(d.data.demandStatusName),
                    $('<td>').append(d.data.closed ? 'Fechada' : 'Aberta'),
                    $('<td>').append('<div class=""text-center""><a href=""javascript:openDemandInfoModal(' + d.data.demandId + ')"" class=""badge badge-pill badge-primary"" title=""Visualizar Informa????es""><i class=""simple-icon-magnifier""></i></a>&nbsp;<a href=""javascript:removeDemand(' + d.data.demandId + ')"" class=""badge badge-pill badge-danger"" title=""Remover""><i class=""simple-icon-trash""></i></a></div>')
                )
            );

            $(r.node()).attr('data-demand-id', d.data.demandId);
            $(r.node()).attr('data-weight', d.demandResidueFamilyTotalWeight);

            demandDestinationDemandDatatables.draw(false);
            demandDestinationDemandDatatables.columns.adjust();

            $('#demand-destinat");
                WriteLiteral(@"ion-demand-form-area [name=""DemandId""]').val('').trigger('change');
        });
    }

    function removeDemand(demandId) {

        if (!isNaN(Globalize.parseFloat(Globalize.format(isNull($('#demand-destination-demand-table tr[data-demand-id=""' + demandId + '""]').data('weight'), 0))))) {
            decreaseTotalWeight(Globalize.parseFloat(Globalize.format(isNull($('#demand-destination-demand-table tr[data-demand-id=""' + demandId + '""]').data('weight'), 0))));
        }

        demandDestinationDemandDatatables.row($('#demand-destination-demand-table tr[data-demand-id=""' + demandId + '""]')).remove();
        demandDestinationDemandDatatables.draw(false);

        //reloadDemandSelect();
    }

");
                WriteLiteral("\n    function openDemandInfoModal(demandId) {\n        $(\'#demand-info-modal\').modal(\'show\');\n\n        $(\'#demand-info-view-component\').load(\'");
#nullable restore
#line 259 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                          Write(Url.Action("LoadDemandInfoViewComponent", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', { demandId, residueFamilyId: \'");
#nullable restore
#line 259 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                                                                                                               Write(Model.Model.ResidueFamilyId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' });
    }

    function increaseTotalWeight(weight) {
        totalWeight += weight;
        $('#total-weight').text(totalWeight.toFixed(totalWeight % 1 === 0? 0 : 1).replace('.', ','));
    }

    function decreaseTotalWeight(weight) {
        totalWeight -= weight;
        $('#total-weight').text(totalWeight.toFixed(totalWeight % 1 === 0 ? 0 : 1).replace('.', ','));
    }

    function reloadDemandIdSelection(departureDate, residueFamilyId) {
        $('#demand-destination-demand-form-area [name=""DemandId""]').empty().trigger('change');

        $.post('");
#nullable restore
#line 275 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
           Write(Url.Action("GetDemands", "DemandDestination"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', { departureDate, residueFamilyId, demandDestinationId: \'");
#nullable restore
#line 275 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
                                                                                                                    Write(Model.Model.DemandDestination.DemandDestinationId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' }, function (d) {
            $.each(d, function (i, x) {
                $('#demand-destination-demand-form-area [name=""DemandId""]').append(new Option(x.description, x.demandId));
            });
        });

        $('#demand-destination-demand-form-area [name=""DemandId""]').trigger('change');
    }

    function hideSelectedDemands()
    {
        $('#demand-destination-demand-form-area .select2-results__option').show();

        $.each($('tr[data-demand-id]').map(function (i, e) { return $(e).data('demand-id'); }), function (j, demandId) {
            $.each($('.select2-results__option'), function (k, option) {
                if ($(option).data('data').id != demandId) return;

                $(option).hide();
            })
        });
    }

    $('#demand-destination-demand-form-area [name=""DemandId""]').on('select2:open', function () { setTimeout(hideSelectedDemands, 50); });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 140 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandDestinationDemand\Default.cshtml"
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
        public Web.Helpers.DropDownListHelper dropDownListHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Demand.DemandResidueFamilyTotalWeightServices demandResidueFamilyTotalWeightServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.DemandDestination.DemandDestinationDemandServices demandDestinationDemandServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.DemandDestination.DemandDestinationServices demandDestinationServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Demand.DemandListServices demandListServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<DTO.DemandDestination.DemandDestinationDemandParamenterViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
