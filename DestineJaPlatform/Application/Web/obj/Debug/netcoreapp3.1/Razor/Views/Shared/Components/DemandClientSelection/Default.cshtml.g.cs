#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "598e290185df8fcec5221ed8e7416750bcc9e011"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DemandClientSelection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/DemandClientSelection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"598e290185df8fcec5221ed8e7416750bcc9e011", @"/Views/Shared/Components/DemandClientSelection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DemandClientSelection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<DTO.Demand.DemandClientSelectionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "demand-client-selection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 6 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
  
	var usingRouteForContract = (await routeTypeServices.GetDataByExternalCode("CONTRATO"))?.RouteTypeId == Model.Model.Route.RouteTypeId;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style type=""text/css"">
	#demand-client-add-table tr:not(.group-start) td:last-child {
		text-align: center;
	}

	#demand-client-add-table_wrapper .dataTables_scrollHead, #demand-client-add-table_wrapper .dataTables_scrollHeadInner,
	#demand-client-address-add-table_wrapper .dataTables_scrollHead, #demand-client-address-add-table_wrapper .dataTables_scrollHeadInner {
		min-width: 910px;
	}

	");
            WriteLiteral(@"@media (min-width: 992px) {
		#demand-client-modal .modal-lg, .modal-xl {
			max-width: 1000px;
		}
	}

	button.badge-primary[disabled=""disabled""] {
		background-color: #9e9e9e !important;
	}

	#demand-client-add-table tr.error {
		outline: 2px solid #de6060;
		outline-offset: -2px;
	}
</style>

<div class=""row"" id=""demand-client-modal-inputs-get-clients"">
	<div class=""col-12"">
		<div class=""input-group mb-3"">
			<input class=""form-control required"" data-error-message=""Insira algum dado para buscar um gerador"" placeholder=""Procurar por Cliente/C??digo"" id=""client-selection-search"" />
			<div class=""input-group-append"">
				<button type=""button"" class=""btn btn-primary"" onclick=""getClients()""><i class=""simple-icon-magnifier""></i>&nbsp;Buscar</button>
			</div>
		</div>
	</div>
	<div class=""col-12 form-group"">
        <div class=""table-responsive"">
            <table class=""table table-bordered table-condensed"" id=""demand-client-add-table"">
                <thead>
                    <tr style=""background: #a1a1a");
            WriteLiteral(@"1; color: white;"">
                        <th class=""text-center""><input type=""checkbox"" id=""select-all-clients-checkbox"" onclick=""selectAllClientsCheckbox(this)"" style=""display: none;"" /></th>
                        <th>C??digo</th>
                        <th>Gerador</th>
                        <th>Endere??o</th>
                        <th>Situa????o</th>
                        <th>Periodicidade</th>
");
            WriteLiteral("                    </tr>\n                </thead>\n            </table>\n        </div>\n\t</div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "598e290185df8fcec5221ed8e7416750bcc9e0116873", async() => {
                WriteLiteral("\n    var demandClientAddTable, clientsSearched = [];\n    var routeFamilyIds = [");
#nullable restore
#line 65 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
                      Write(string.Join(",", Model.Model.ResidueFamilyIds));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"];//Famil??as existentes na rota selecionada

    $(document).ready(function () {
        demandClientAddTable = $('#demand-client-add-table').DataTable({
            proccessing: true,
            serverSide: false,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            ""paging"": true,
            ""info"": false,
            //scrollY: '400px',
            //scrollCollapse: true,
            paging: false,
            'language': {
                ""sEmptyTable"": ""Nenhum gerador encontrado (Altere o filtro e tente novamente) 1""
            },
            ""columnDefs"": [{ orderable: false, targets: [0] }],
            drawCallback: function () {
                $('#select-all-clients-checkbox')[0].checked = false;

                if (typeof _setSelectedClientAsUnselectable == 'function') _setSelectedClientAsUnselectable();
            }
        });

        updateCitySelect();

        setTimeout(function () {
            //$('#demand-client-add-table').DataTable().col");
                WriteLiteral(@"umns.adjust();
        }, 1000); //atualiza a largura das colunas
    });


    function updateCitySelect() {
        $('#demand-client-modal [name=""City""]').val('');

        var state = $('#demand-client-modal [name=""State""]').val();

        $('#demand-client-modal [name=""City""] option').hide();

        $('#demand-client-modal [name=""City""] option').each(function (i, e) {
            if ($(e).data('state') == state) $(e).show();
        });
        $('#demand-client-modal [name=""City""] option[value=""""]').show();
    }

    function AddAddressToTable() {
        var state = $('#demand-client-modal [name=""State""]').val();
        var city = $('#demand-client-modal [name=""City""]').val();

        if (!validateInputs('demand-client-modal-inputs-set-city') || $('[data-state=""' + state + '""][data-city=""' + city + '""]').length > 0) return;

        var r = demandClientAddressAddTable.row.add({
            0: state,
            1: city,
            2: '<div class=""text-center""><a href=""javascript:removeAddress(\'");
                WriteLiteral(@"' + state + '\', \'' + city + '\')"" class=""badge badge-danger badge-pill""><i class=""fa fa-trash-o""></i> Remover</a></div>'
        });

        $(r.node()).attr('data-state', state);
        $(r.node()).attr('data-city', city);

        demandClientAddressAddTable.draw();
    }

    function removeAddress(state, city) {
        var row = demandClientAddressAddTable.row($('[data-state=""' + state + '""][data-city=""' + city + '""]'));
        row.remove();

        demandClientAddressAddTable.draw();
    }

    function getClients() {
        if (!validateInputs('demand-client-modal-inputs-get-clients')) return;

		$.post('");
#nullable restore
#line 139 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
           Write(Url.Action("GetClients", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { routeId: $('#demand-manage-form-area [name=""RouteId""]').val(), Search: $('#client-selection-search').val(), notValidateFamily: $('#demand-manage-form-area [name=""NotValidateFamily""]')[0].checked }, function (d) {
            demandClientAddTable.rows().remove();
            clientsSearched = d;

            $.each(d, function (i, element) {
                var e = element.item;

                var r = demandClientAddTable.row.add({
                    0: '<div class=""text-center""><input type=""checkbox"" data-company-name=""' + e.companyName + '"" data-address-id=""' + e.clientCollectionAddressId + '"" data-family-length=""' + element.families.length + '"" data-contract-id=""' + isNull(e.contractId, 'null') + '"" data-service-id=""' + isNull(e.serviceId, 'null') + '"" /></div>',
                    1: '<div class=""text-center"">' + e.clientId + '</div>',
                    2: e.companyName,
                    3: e.address + ', ' + (isNullOrWhiteSpace(e.number) ? 'S/N' : e.number) + ' ' + e.city + ' - ' + e.state,
");
                WriteLiteral(@"                    4: isNull(e.situationName, '-'),
                    5: e.periodicityName,
                    //6: '<div class=""text-center""><button type=""button"" onclick=""openSelectResidueFamilyModal(' + e.clientCollectionAddressId + ', ' + isNull(e.contractId, 'null') + ', ' + isNull(e.serviceId, 'null') + ', ' + element.families.length + ')"" class=""badge badge-pill badge-primary"" disabled=""disabled"">Famil??as</button></div>',
                });

                $(r.node()).css('background-color', e.rowColor);
            });

            demandClientAddTable.draw();
            $('#demand-client-add-table').DataTable().columns.adjust();

            if (typeof _setSelectedClientAsUnselectable == 'function') _setSelectedClientAsUnselectable();//desabilita os checkbox selecionados

            initCheckboxFunc();
        });
    }

    function selectAddresses() {
        if (typeof setAddressInDemand != 'function' || !selectAdderssesValidate()) return;

        var p = [];
        $.each($('#demand-cli");
                WriteLiteral(@"ent-add-table input[type=""checkbox""]:checked'), function (i, e) { //la??o usado para possibilidade de varios geradores serem adicionados ao mesmo tempo (atualmente a regra permite apenas um gerador por vez)
            if ($(e).attr('disabled') == 'disabled') return;

            p.push({ name: 'ClientCollectionAddressIds.Index', value: i });
            p.push({ name: 'ClientCollectionAddressIds[' + i + ']', value: $(e).data('address-id') });
        });

        setAddressInDemand(p);

        if (typeof _setSelectedClientAsUnselectable == 'function') _setSelectedClientAsUnselectable();//desabilita os checkbox selecionados
    }

    function selectAdderssesValidate() {
        $('#demand-client-add-table tr').removeClass('error');

        var hasError = false;

        $.each($('#demand-client-add-table input[type=""checkbox""]:checked'), function (i, e) {
            if ($(e).attr('disabled') == 'disabled' || addressFamilyIds.findIndex(x => x.clientCollectionAddressId == $(e).data('address-id')) != -1) retu");
                WriteLiteral(@"rn;

            var clientSearchedIndex = clientsSearched.findIndex(x => x.addressId == $(e).data('address-id')); //caso n??o tenha selecionado nenhuma familia, tenta obter as possiveis familias desse contrato/servi??o e ent??o vincula todas familias ao endere??o
            if (clientSearchedIndex != -1) {
                if (clientsSearched[clientSearchedIndex].families.length > 0) {
                    selectResidueFamiliesCallback({
                        families: clientsSearched[clientSearchedIndex].families,
                        clientCollectionAddressId: $(e).data('address-id')
                    });

                    return;
                }
            }

            $(e).closest('tr').addClass('error');
            hasError = true;
        });

        if (hasError) {
            bootbox.alert('Selecione as fam??lias vinculadas ao Gerador a ser adicionado.');
        }

        return !hasError;
    }

    function setSelectedClientAsUnselectable(addressIds)
    {
        if (addressIds.length");
                WriteLiteral(@" == 0) return;

        $.each(addressIds, function (i, e) {
            try {
                $('#demand-client-add-table input[type=""checkbox""][data-address-id=""' + e.addressId + '""]').attr('disabled', 'disabled');
                $('#demand-client-add-table input[type=""checkbox""][data-address-id=""' + e.addressId + '""]')[0].checked = true;
            } catch {}//?? possivel que alguns checkbox n??o existam caso estejam em outras paginas da tabela
        });
    }

    function selectAllClientsCheckbox(sel) {
        $('#demand-client-add-table input[type=""checkbox""]').each(function (i, e) {
            if ($(e).attr('disabled') == 'disabled') return;

            e.checked = sel.checked;
            $(e).closest('tr').find('button').attr('disabled', !this.checked);
        });
    }

    function initCheckboxFunc() {
        $('#demand-client-add-table input[type=""checkbox""][data-address-id]').click(function () {
            var checked = this.checked;

            $('#demand-client-add-table input[type=""ch");
                WriteLiteral(@"eckbox""]').each(function (i, e) {
                if ($(e).attr('disabled') == 'disabled') return;

                e.checked = false;
                $(e).closest('tr').find('button').attr('disabled', true);
            });

            $(this).closest('tr').find('button').attr('disabled', !checked);
            this.checked = checked;


            if ($(this).data('family-length') == 0 && !$('#demand-manage-form-area [name=""NotValidateFamily""]')[0].checked) {
                $(this).closest('tr').find('button').attr('disabled', true);
                this.checked = false;

                bootbox.alert('Este gerador n??o possu?? nenhuma famil??a compativel.');
            }
        });
    }

    function openSelectResidueFamilyModal(addressId, contractId, serviceId, totalFamilies, editing) {
        if (addressId == null) {
            if ($('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').length == 0) {
                bootbox.alert('Nenhum gerador selecionado.');
                re");
                WriteLiteral(@"turn;
            }
            addressId = $('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').data('address-id');
            totalFamilies = $('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').data('family-length');
            contractId = $('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').data('contract-id');

            serviceId = $('#demand-client-so-selection-table input[type=""checkbox""]:not(:disabled):checked').length > 0 ? $('#demand-client-so-selection-table input[type=""checkbox""]:not(:disabled):checked').data('selection-service-id') : $('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').data('service-id');
        }

        if (totalFamilies == 0 && !$('#demand-manage-form-area [name=""NotValidateFamily""]')[0].checked) {
            bootbox.alert('Este gerador n??o possu?? nenhuma famil??a compativel.');
            return;
        }

        if (editing == true) {
            $('#demand-client-family-mo");
                WriteLiteral(@"dal-save-button').text('Salvar');
        } else {
            $('#demand-client-family-modal-save-button').text('Incluir Gerador');
        }

        $('#demand-client-modal').css('opacity', 0);

        $('#route-residue-family-view-component').empty();

		$('#route-residue-family-view-component').load('");
#nullable restore
#line 288 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
                                                   Write(Url.Action("RouteResidueFamilyViewComponent", "Route"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', { addressId, contractId, serviceId }, function () {\n            $(\'#demand-client-family-modal\').modal(\'show\');\n\n");
#nullable restore
#line 291 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
             if (usingRouteForContract) {
            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
			if (!$('#demand-manage-form-area [name=""NotValidateFamily""]')[0].checked) {
                $.each($('#route-client-families-selection-table tbody tr[data-family-id]'), function (i, e) {// Caso seja rota de contrato - Se alguma famil??a n??o existe dentre as selecionadas na rota, ela ser?? removida da listagem
                    if (routeFamilyIds.indexOf($(e).data('family-id')) != -1) return;

                    $(e).remove();
                });
            }

            if ($('#route-client-families-selection-table tbody tr[data-family-id]').length == 0) {
                $('#route-client-families-selection-table tbody').append($('<tr>').append($('<td>', {colspan: '4' }).append('<i>N??o h?? nenhuma famil??a compativel para este gerador.</i>')));
            }
            ");
#nullable restore
#line 304 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
                   
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            //Setar fam??lias j?? selecionadas
            var index = addressFamilyIds.findIndex(x => (x.clientCollectionAddressId == addressId));

            if (index != -1) {
                $.each(addressFamilyIds[index].familyIds, function (i, e) {
                    var elem = $('#route-client-families-selection-table input[type=""checkbox""][data-family-id=""' + e + '""]');
                    if (elem.length > 0)
                        $(elem)[0].checked = true;
                });
            }
        });
    }

    function openSelectOSModal()
    {
		if ($('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').length == 0) {
			bootbox.alert('Nenhum gerador selecionado.');
			return;
		}

        $('#demand-client-modal').css('opacity', 0);

		$('#demand-client-so-select-view-component').empty();

		$('#demand-client-so-select-view-component').load('");
#nullable restore
#line 331 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
                                                      Write(Url.Action("LoadDemandClientSOSelectionViewComponent", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { addressId: $('#demand-client-add-table input[type=""checkbox""]:not(:disabled):checked').data('address-id') }, function () {
			$('#demand-client-so-select-modal').modal('show');
        });
    }

    function selectResidueFamiliesCallback(d) {
        //remove o dado do cliente caso ele j?? exista
        var index = addressFamilyIds.findIndex(x => x.clientCollectionAddressId == d.clientCollectionAddressId);
        var demandClientId = null;

        if (index != -1) {
            demandClientId = addressFamilyIds[index].demandClientId;
            addressFamilyIds.splice(index, 1);
        }

        if (d.families.length > 0) { //caso n??o tenha adicionado fam??lia e clique em salvar n??o seta os dados
            addressFamilyIds.push({
                familyIds: d.families.map(function (e, i) { return e.id; }),//apenas o Id da familia
                familyNames: d.families.map(function (e, i) { return e.name; }),//apenas o nome da familia
                clientCollectionAddressId: d.clientCollectionAdd");
                WriteLiteral(@"ressId
            });
        }

        if (typeof setFamilyNames == 'function') {
            var names = [];
            addressFamilyIds.forEach(function (e, i) { names = names.concat(e.familyNames); });
            setFamilyNames(names);
        }

        $('#demand-client-family-modal').modal('hide');
    }

	$('#demand-client-family-modal').on('hidden.bs.modal', function () {
        $('#demand-client-modal').css('opacity', 1);

        //$('#demand-client-modal').modal('show');
    });


	$('#demand-client-so-select-modal').on('hidden.bs.modal', function () {
        if (!isNullOrWhiteSpace($(this).attr('not-open-demand-client-modal'))) {
            $(this).removeAttr('not-open-demand-client-modal')
        } else {
            $('#demand-client-modal').css('opacity', 1);
        }
	});

    $(document).ready(function () {
        $('#client-selection-search').bind(""keypress"", function (e) {
            if (e.keyCode == 13) {
                getClients();
            }
        });
    });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
#nullable restore
#line 63 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSelection\Default.cshtml"
__Web_Utils_TagHelperScriptCut.LoadFromController = Model.LoadFromController;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-cut-key-load-from-controller", __Web_Utils_TagHelperScriptCut.LoadFromController, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public Services.Demand.DemandServices demandServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Web.Helpers.DropDownListHelper dropDownListHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<DTO.Demand.DemandClientSelectionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
