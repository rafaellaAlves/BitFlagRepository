#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca1a1028eb62827132b787401e5dade797e41e78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TransporterVehicleIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TransporterVehicleIndex/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca1a1028eb62827132b787401e5dade797e41e78", @"/Views/Shared/Components/TransporterVehicleIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TransporterVehicleIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "transporter-vehicle-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md form-group"">
        <div class=""input-group"">
            <div class=""input-group-addon"">
                <i class=""simple-icon-magnifier""></i>
            </div>
            <input type=""text"" class=""form-control"" id=""transporter-vehicle-index-search"" placeholder=""Pesquisar..."" data-toggle=""search-datatable"" data-target=""#transporter-vehicle-index-table"">
        </div>
    </div>
    <div class=""col-md-auto col form-group"">
        <a href=""javascript:openTransporterVehicleEditModal()"" class=""btn btn-primary text-nowrap w-100""><i class=""simple-icon-plus""></i>&nbsp;Adicionar Documento</a>
    </div>
</div>
<hr />
<div id=""success-area-transporter-vehicle-index""></div>
<div class=""row"">
    <div class=""col-md-12 table-responsive"">
        <table id=""transporter-vehicle-index-table"" class=""display nowrap table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; min-width: 100%;"">
            <thead>
                <tr>
         ");
            WriteLiteral(@"           <th>Placa</th>
                    <th>DUT</th>
                    <th>Modelo</th>
                    <th>Fabricante</th>
                    <th>CIV</th>
                    <th>Vencimento</th>
                    <th>Dias para o Vencimento</th>
                    <th>CIPP</th>
                    <th>Vencimento</th>
                    <th>Dias para o Vencimento</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
</div>

<div class=""modal fade"" id=""transporter-vehicle-index-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""transporter-vehicle-index-modal-title"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg w-100"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"" id=""transporter-vehicle-index-modal-title""></h5>
                <button type=""button"" class=""close"" data-di");
            WriteLiteral("smiss=\"modal\" aria-label=\"Close\">\n                    <span aria-hidden=\"true\">&times;</span>\n                </button>\n            </div>\n            <div class=\"modal-body\">\n                ");
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
            Write(await Component.InvokeAsync("TransporterVehicleManage", new { transporterId = Model }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-6"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""simple-icon-close""></i>&nbsp;Fechar</button>
                </div>
                <div class=""col-md-6"">
                    <button type=""button"" class=""btn btn-success float-right"" id=""transporter-vehicle-index-modal-save-button""><i class=""simple-icon-cloud-upload""></i>&nbsp;Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca1a1028eb62827132b787401e5dade797e41e787332", async() => {
                WriteLiteral(@"
    var transporterVehicleDatatables;
    $(document).ready(function () {
        transporterVehicleDatatables = $('#transporter-vehicle-index-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            scrollX: true,
            ajax: {
                url: '");
#nullable restore
#line 76 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
                 Write(Url.Action("List", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\n                data: function (d) {\n                    d.transporterId = \'");
#nullable restore
#line 78 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
                                  Write(Model);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
                },
                type: 'POST'
            },
            columns: [
                { render: function (data, type, row) { return row.licensePlate + getDownloadIconVehicle(row, 'LicensePlate'); } },
                { render: function (data, type, row) { return isNull(row.dut, '-') + getDownloadIconVehicle(row, 'DUT'); } },
                { render: function (data, type, row) { return isNull(row.model, '-'); } },
                { render: function (data, type, row) { return isNull(row.manufacturer, '-'); } },
                { render: function (data, type, row) { return isNull(row.civ, '-') + getDownloadIconVehicle(row, 'CIV'); } },
                { render: function (data, type, row) { return isNull(formatDate(row.civDueDate), '-'); } },
                { render: function (data, type, row) { return isNullOrWhiteSpace(row.civDueDate)? '-' : getDaysFromToday(moment(row.civDueDate)._d); } },
                { render: function (data, type, row) { return isNull(row.cippModel, '-') + getDownload");
                WriteLiteral(@"IconVehicle(row, 'CIPP'); } },
                { render: function (data, type, row) { return isNull(formatDate(row.cippDueDate), '-') } },
                { render: function (data, type, row) { return isNullOrWhiteSpace(row.cippDueDate)? '-' : getDaysFromToday(moment(row.cippDueDate)._d); } },
");
                WriteLiteral(@"                {
                    render: function (data, type, row)
                    {
                        var r = `<div class=""text-center text-nowrap"">
                            &nbsp;<a href=\'javascript:openTransporterVehicleEditModal(` + JSON.stringify(row) + `)\' title=""Editar""><span class=""badge badge-pill badge-success""><i class=""simple-icon-note""></i></span></a>`;

                        if (row.isActive) r += '&nbsp;<a href=\'javascript:inactiveTransporterVehicle(' + JSON.stringify(row) + ')\' title=""Inativar""><span class=""badge badge-pill badge-warning""><i class=""fa fa-unlock""></i></span></a>';
                        else r += '&nbsp;<a href=\'javascript:activeTransporterVehicle(' + JSON.stringify(row) + ')\' title=""Ativar""><span class=""badge badge-pill badge-danger""><i class=""simple-icon-lock""></i></span></a>';

                        r += '&nbsp;<a href=\'javascript:removeTransporterVehicle(' + JSON.stringify(row) + ')\' title=""Excluir""><span class=""badge badge-pill badge-danger""");
                WriteLiteral(@"><i class=""simple-icon-trash""></i></span></a>' +
                        '</div>';

                        return r;
                    }
                }
            ]
        });
    });

    function getDownloadIconVehicle(transporterVehicle, archive)
    {
        var success = false;
        var fileName = """", mimeType = """";

        if (archive == 'LicensePlate' && transporterVehicle.licensePlateGuidName != null) { success = true; fileName = transporterVehicle.licensePlateFileName; mimeType = transporterVehicle.licensePlateMimeType; }
        if (archive == 'DUT' && transporterVehicle.dutGuidName != null) { success = true; fileName = transporterVehicle.dutFileName; mimeType = transporterVehicle.dutMimeType; }
        if (archive == 'CIPP' && transporterVehicle.cippGuidName != null) { success = true; fileName = transporterVehicle.cippFileName; mimeType = transporterVehicle.cippMimeType; }
        if (archive == 'CIV' && transporterVehicle.civGuidName != null) { success = true; fileName = transporterVe");
                WriteLiteral(@"hicle.civFileName; mimeType = transporterVehicle.civMimeType; }

        if (success) return ' <a href=\'javascript:vehicleDownloadBootbox(' + JSON.stringify({ transporterVehicleId: transporterVehicle.transporterVehicleId, archive, fileName, mimeType  }) + ')\' class=""simple-icon-cloud-download""></a>'

        return '';
    }

    function vehicleDownloadBootbox(d) {
        var size = 'medium';

        var message = $('<div>');
        message.append($('<h4>').append('Arquivo <b>(' + d.fileName + ')</b>'));


        if (d.mimeType.indexOf('image') != -1) {
            var row = $('<div>', { class: 'row mt-3' });
            var col = $('<div>', { class: 'col-md-12 text-center' });
            var img = $('<img>', { class: 'transporter-vehicle-image', src: '");
#nullable restore
#line 138 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
                                                                        Write(Url.Action("GetArchive", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + d.transporterVehicleId + '&archive=' + d.archive, style: 'min-height:150px; max-height: 400px; max-width: 750px;' });
            img.on(""error"", function () { imageNotFound('.transporter-vehicle-image') });

            message.append(row.append(col.append(img)));

            size = 'large';
        }

         bootbox.dialog({
            message: message.html(),
             size: size,
            buttons: {
                delete: {
                    label: ""<i class=\""simple-icon-close\""></i> Excluir"",
                    className: 'btn-danger mr-auto float-left',
                    callback: function () {
                        deleteVehicleFile(d)
                    }
                },
                download: {
                    label: ""<i class=\""simple-icon-cloud-download\""></i> Download"",
                    className: 'btn-success',
                    callback: function () {
                        window.location.href = '");
#nullable restore
#line 161 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
                                           Write(Url.Action("GetArchive", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + d.transporterVehicleId + '&archive=' + d.archive;
                    }
                }
            }
        });
    }

    function deleteVehicleFile(d) {
        bootboxConfirm(""Deseja realmente excluir o arquivo \"""" + d.fileName + ""\""?"", function(result){
            if (!result) {
                vehicleDownloadBootbox(d)
                return;
            }

            $.post('");
#nullable restore
#line 175 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
               Write(Url.Action("RemoveFile", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: d.transporterVehicleId, archive: d.archive }, function () {
                bootbox.alert(""Arquivo \"""" + d.fileName + ""\"" excluído com sucesso!"");
                transporterVehicleDatatables.ajax.reload();
            });
        });
    }

    function removeTransporterVehicle(transporterVehicle) {
        bootboxConfirm(""Deseja realmente excluir o veículo de placa \"""" + transporterVehicle.licensePlate + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 186 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
               Write(Url.Action("DeleteDefinitively", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: transporterVehicle.transporterVehicleId }, function () {

                bootbox.alert(""Veículo de placa \"""" + transporterVehicle.licensePlate + ""\"" excluído com sucesso!"");
                transporterVehicleDatatables.ajax.reload();
            });
        });
    }

    function inactiveTransporterVehicle(transporterVehicle) {
        bootboxConfirm(""Deseja realmente desativar o veículo de placa \"""" + transporterVehicle.licensePlate + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 198 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
               Write(Url.Action("Inactive", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: transporterVehicle.transporterVehicleId }, function () {

                bootbox.alert(""Veículo de placa \"""" + transporterVehicle.licensePlate + ""\"" desativado com sucesso!"");
                transporterVehicleDatatables.ajax.reload();
            });
        });
    }

    function activeTransporterVehicle(transporterVehicle) {
        bootboxConfirm(""Deseja realmente ativar o veículo de placa \"""" + transporterVehicle.licensePlate + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 210 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
               Write(Url.Action("Active", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: transporterVehicle.transporterVehicleId }, function () {

                bootbox.alert(""Veículo de placa \"""" + transporterVehicle.licensePlate + ""\"" ativado com sucesso!"");
                transporterVehicleDatatables.ajax.reload();
            });
        });
    }

    function openTransporterVehicleEditModal(data) {
        $('#form-transporter-vehicle [name=\'TransporterVehicleId\']').val(data == null? '' : data.transporterVehicleId);

        $('#form-transporter-vehicle [name=\'LicensePlate\']').val(data == null? '' : data.licensePlate);
        $('#form-transporter-vehicle [name=\'DUT\']').val(data == null? '' : data.dut);
        $('#form-transporter-vehicle [name=\'ActivityName\']').val(data == null? '' : data.activityName);
        $('#form-transporter-vehicle [name=\'Model\']').val(data == null? '' : data.model);
        $('#form-transporter-vehicle [name=\'Manufacturer\']').val(data == null? '' : data.manufacturer);
        $('#form-transporter-vehicle [name=\'ManufacturingDate\']').val(");
                WriteLiteral(@"data == null? '' : data.manufacturingDate);
        $('#form-transporter-vehicle [name=\'CIV\']').val(data == null? '' : data.civ);
        $('#form-transporter-vehicle [name=\'_CIVDueDate\']').val(data == null? '' : moment(data.civDueDate).format('DD/MM/YYYY'));
        $('#form-transporter-vehicle [name=\'CIPPModel\']').val(data == null? '' : data.cippModel);
        $('#form-transporter-vehicle [name=\'_CIPPDueDate\']').val(data == null? '' : moment(data.cippDueDate).format('DD/MM/YYYY'));
        $('#form-transporter-vehicle [name=\'LicensePlateArchive\']').val('');
        $('#form-transporter-vehicle [name=\'DUTArchive\']').val('');
        $('#form-transporter-vehicle [name=\'CIVArchive\']').val('');
        $('#form-transporter-vehicle [name=\'CIPPArchive\']').val('');

        var r = getDaysToDueDate(moment($('#form-transporter-vehicle input[name=\'_CIVDueDate\']').val(), 'DD/MM/YYYY')._d);
        $('#CIV-days-for-due-date').val(data == null ? '' : parseInt(r));

        r = getDaysToDueDate(moment");
                WriteLiteral(@"($('#form-transporter-vehicle input[name=\'_CIPPDueDate\']').val(), 'DD/MM/YYYY')._d);
        $('#CIPP-days-for-due-date').val(data == null? '' : parseInt(r));

        //remove arquivos selecionado no FilePound
        $('.filepond--file-action-button.filepond--action-remove-item').click();

        $('#transporter-vehicle-index-modal-title').text(data == null ? 'Novo Veículo' : 'Editar Veículo');

        $('#transporter-vehicle-index-modal').modal('show');

        InitializeFunctions();
    }

    $('#transporter-vehicle-index-modal-save-button').click(function () {
        if(!validateInputs('form-transporter-vehicle')) return;

        var formData = new FormData();

        $('#form-transporter-vehicle').serializeArray().forEach(function (e) {
            formData.append(e.name, e.value);
        });


        if ($('#form-transporter-vehicle [name=\'LicensePlateArchive\']')[0].files.length > 0) {
            formData.append('LicensePlate', $('#form-transporter-vehicle [name=\'LicensePlateArchive\']')");
                WriteLiteral(@"[0].files[0]);
        }
        if ($('#form-transporter-vehicle [name=\'DUTArchive\']')[0].files.length > 0) {
            formData.append('DUT', $('#form-transporter-vehicle [name=\'DUTArchive\']')[0].files[0]);
        }
        if ($('#form-transporter-vehicle [name=\'CIVArchive\']')[0].files.length > 0) {
            formData.append('CIV', $('#form-transporter-vehicle [name=\'CIVArchive\']')[0].files[0]);
        }

        if ($('#form-transporter-vehicle [name=\'CIPPArchive\']')[0].files.length > 0) {
            formData.append('CIPP', $('#form-transporter-vehicle [name=\'CIPPArchive\']')[0].files[0]);
        }

        $('#success-area-transporter-vehicle-index').empty();

        $.ajax({
            url: '");
#nullable restore
#line 279 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleIndex\Default.cshtml"
             Write(Url.Action("ManageAjax", "TransporterVehicle"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
			type: 'POST',
			contentType: false,
			processData: false,
            data: formData,
            success: function (d) {
                if (!d.success) {
                    var div = $('<div>');
                    var row = $('<div>', { class: 'row' });
                    var title = $('<div>', { class: 'col-md-12' }).append($('<h5>').append('O arquivo foi salvo com sucesso, porem os seguintes arquivos não foram inseridos.'));

                    var table = $('<table>', { class: 'table table-bordered table-striped' });
                    var tHead = $('<thead>').append($('<tr>').append($('<td>').append('Arquivo'), $('<td>').append('Motivo')));
                    var tBody = $('<tbody>');

                    $.each(e.erros, function (i, e) {
                        tBody.append($('<tr>').append($('<td>').append(e.item), $('<td>').append(e.message)));
                    });

                    div.append(row.append(title, $('<div>', { class: 'col-md-12' }).append(table.append(tHead, tBody)))");
                WriteLiteral(@");

                    bootbox.alert(div.html());
                    return;
                }

                formDataTransporterVehicle = new FormData();

                transporterVehicleDatatables.ajax.reload();
                transporterVehicleDatatables.search($('#transporter-vehicle-index-search').val()).draw();

                $('#success-area-transporter-vehicle-index').empty().append(successMessage());

                $('#transporter-vehicle-index-modal').modal('hide');
            }
        });
    })

    $('.nav-link').on('shown.bs.tab', function () {
        $('#transporter-vehicle-index-table').DataTable().columns.adjust();
    });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
