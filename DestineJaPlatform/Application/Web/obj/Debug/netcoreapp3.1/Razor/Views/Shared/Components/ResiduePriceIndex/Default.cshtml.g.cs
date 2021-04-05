#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResiduePriceIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be00bcbb697a8e21be2983e39bd70fdc0e49607b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ResiduePriceIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ResiduePriceIndex/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be00bcbb697a8e21be2983e39bd70fdc0e49607b", @"/Views/Shared/Components/ResiduePriceIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ResiduePriceIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "residue-price-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md form-group"">
        <div class=""input-group"">
            <div class=""input-group-addon"">
                <i class=""simple-icon-magnifier""></i>
            </div>
            <input type=""text"" class=""form-control"" id=""residue-price-index-search"" placeholder=""Pesquisar..."" data-toggle=""search-datatable"" data-target=""#residue-price-index-table"">
        </div>
    </div>
    <div class=""col-md-auto col form-group"">
        <a href=""javascript:openResiduePriceEditModal()"" class=""btn btn-primary float-right text-nowrap w-100""><i class=""simple-icon-plus""></i>&nbsp;Adicionar</a>
    </div>
</div>
<hr />
<div id=""success-area-residue-price""></div>
<div class=""row"">
    <div class=""col-md-12 table-responsive"">
        <table id=""residue-price-index-table"" class=""display table table-striped table-bordered table-condensed w-100"" style=""border-collapse: collapse !important;"">
            <thead>
                <tr>
                    <th>Código ONU</th>
                    <");
            WriteLiteral(@"th>Nome da Famíla</th>
                    <th>Unidade de Medida</th>
                    <th>Preço</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
</div>

<div class=""modal fade"" id=""residue-price-index-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""residue-price-index-modal-title"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"" id=""residue-price-index-modal-title""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResiduePriceIndex\Default.cshtml"
            Write(await Component.InvokeAsync("ResiduePriceManage", new { recipientId = Model }));

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
                    <button type=""button"" class=""btn btn-success float-right"" id=""residue-price-index-modal-save-button""><i class=""simple-icon-cloud-upload""></i>&nbsp;Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be00bcbb697a8e21be2983e39bd70fdc0e49607b6959", async() => {
                WriteLiteral(@"
    var residuePriceDatatables;
    $(document).ready(function () {
        residuePriceDatatables = $('#residue-price-index-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            ajax: {
                url: '");
#nullable restore
#line 73 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResiduePriceIndex\Default.cshtml"
                 Write(Url.Action("List", "ResiduePrice"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\n                data: function (d) {\n                    d.recipientId = \'");
#nullable restore
#line 75 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResiduePriceIndex\Default.cshtml"
                                Write(Model);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
                },
                type: 'POST'
            },
            columns: [
                { render: function (data, type, row) { return isNull(row.onuCode, '-'); } },
                { render: function (data, type, row) { return isNull(row.residueFamilyName, '-'); } },
                { render: function (data, type, row) { return isNull(row.unitOfMeansurementName, '-'); } },
                { render: function (data, type, row) { return isNull(row._Price, '-'); } },
               {
                    render: function (data, type, row)
                    {
                        return '<div class=""text-center text-nowrap"">' +
                            '&nbsp;<a href=\'javascript:openResiduePriceEditModal(' + JSON.stringify(row) + ')\' title=""Editar""><span class=""badge badge-pill badge-success""><i class=""simple-icon-note""></i></span></a>' +
                            '&nbsp;<a href=\'javascript:removeResiduePrice(' + JSON.stringify(row) + ')\' title=""Excluir""><span class=""badge badge-pill b");
                WriteLiteral(@"adge-danger""><i class=""simple-icon-trash""></i></span></a>' +
                            '</div>';
                    }
                }
            ]
        });
    });

    function removeResiduePrice(residuePrice) {
        bootboxConfirm(""Deseja realmente excluir este preço do resíduo \"""" + residuePrice.residueName + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 101 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResiduePriceIndex\Default.cshtml"
               Write(Url.Action("DeleteDefinitively", "ResiduePrice"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: residuePrice.residuePriceId }, function () {

                bootbox.alert(""Preço do resíduo \"""" + residuePrice.residueName + ""\"" excluído com sucesso!"");
                residuePriceDatatables.ajax.reload();
            });
        });
    }

    function openResiduePriceEditModal(data) {
        $('#residue-price-manage-form [name=\'ResiduePriceId\']').val(data == null ? '' : data.residuePriceId);
        $('#residue-price-manage-form [name=\'ResidueFamilyId\']').val(data == null ? $('#residue-price-manage-form [name=\'ResidueFamilyId\'] option:first').val() : data.residueFamilyId);
        $('#residue-price-manage-form [name=\'ResidueId\']').val(data == null ? '' : data.residueId);
        $('#residue-price-manage-form [name=\'ResidueId\']').data('value', data == null ? '' : data.residueId);
        $('#residue-price-manage-form [name=\'UnitOfMeasurementId\']').val(data == null ? $('#residue-price-manage-form [name=\'UnitOfMeasurementId\'] option:first').val() : data.unitOfMeasurementId);
       ");
                WriteLiteral(@" $('#residue-price-manage-form [name=\'_Price\']').val(data == null ? '' : data._Price);

        $('#residue-price-index-modal-title').text(data == null ? 'Novo Preço' : 'Editar Preço');

        $('#residue-price-index-modal').modal('show');
        InitializeFunctions();
        loadResidues();
    }

    $('#residue-price-index-modal-save-button').click(function () {
   
        saveResiduePrice(function (d) {
            if (!d.success) {
                $('#residue-price-index-modal').modal('hide');
                bootbox.alert(d.message);
                return;
            }

            residuePriceDatatables.ajax.reload();
            residuePriceDatatables.search($('#residue-price-index-search').val()).draw();

            $('#success-area-residue-price').empty().append(successMessage());
            $('#residue-price-index-modal').modal('hide');
        });
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
        public Services.Residue.ResidueServices residueServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Residue.ResidueFamilyServices residueFamilyServices { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
