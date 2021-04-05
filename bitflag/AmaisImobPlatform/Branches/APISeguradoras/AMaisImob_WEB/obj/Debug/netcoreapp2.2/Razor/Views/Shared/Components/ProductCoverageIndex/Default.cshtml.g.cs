#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "131c5c55b823d85cfc1d7fa5b1456959ed5550d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductCoverageIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductCoverageIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductCoverageIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductCoverageIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"131c5c55b823d85cfc1d7fa5b1456959ed5550d0", @"/Views/Shared/Components/ProductCoverageIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductCoverageIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(12, 420, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_ProductCoverageIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 432, "\"", 496, 3);
#line 12 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
WriteAttributeValue("", 439, Url.Action("Manage", "ProductCoverage"), 439, 40, false);

#line default
#line hidden
            WriteAttributeValue("", 479, "?productId=", 479, 11, true);
#line 12 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
WriteAttributeValue("", 490, Model, 490, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(497, 1149, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />

<div class=""table-wrapper"">
    <table id=""_ProductCoverageIndexTable"" class=""table display responsive nowrap"" style=""border-collapse: collapse !important;"">
        <thead>
            <tr>
                <th>Nome</th>
                <th>Taxa (%)</th>
                <th>Mínimo (R$)</th>
                <th>Maximo (R$)</th>
                <th>Básica</th>
                <th>Limite Básico (%)</th>
                <th>Opcional</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _ProductCoverageIndexTypingTimer;
    var _ProductCoverageIndexDoneTypingInterval = 500;
    var datatables = $('#_ProductCoverageIndexTable').DataTable({
        ""order"": [[4, ""desc""]],
        columnDefs: [{
            targets: [4],
            orderData: [4, 6]
        }],
		procc");
            WriteLiteral("essing: true,\r\n\t\tserverSide: false,\r\n\t\tsearching: true,\r\n\t\tlengthChange: false,\r\n\t\tdom: \'tip\',\r\n\t\tajax: {\r\n            url: \'");
            EndContext();
            BeginContext(1647, 37, false);
#line 50 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
             Write(Url.Action("List", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(1684, 69, true);
            WriteLiteral("\',\r\n            data: function (d) {\r\n                d.productId = \'");
            EndContext();
            BeginContext(1754, 5, false);
#line 52 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
                          Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(1759, 159, true);
            WriteLiteral("\'\r\n            },\r\n\t\t\ttype: \'POST\'\r\n\t\t},\r\n\t\tcolumns: [\r\n\t\t\t{ data: \'Name\',\r\n            render: function (data, type, row) {\r\n                return \'<a href=\"");
            EndContext();
            BeginContext(1919, 39, false);
#line 59 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
                            Write(Url.Action("Manage", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(1958, 3107, true);
            WriteLiteral(@"?id=' + row.productCoverageId  + '"">' + row.name + '</a>';
                }
            },
            {
                data: 'Taxes',
            render: function (data, type, row) {
                return '<span class=""percent"">' + row._Taxes + '</span>';
                }
            },
            {
                data: 'Minimum',
                render: function (data, type, row) {
                    return row.minimum != null ? '<span class=""money"">' + row._Minimum + '</span>' : '-';
                }
            },
            {
                data: 'Maximum',
                render: function (data, type, row) {
                    return row.maximum != null ? '<span class=""money"">' + row._Maximum + '</span>' : '-';
                }
            },
            {
                data: 'IsBasic',
                render: function (data, type, row) {
                    return row.isBasic ? '<span class=""badge badge-pill badge-success text-center"">Sim</span>' : '<span class=""ba");
            WriteLiteral(@"dge badge-pill badge-danger text-center"">Não</span>';
                }
            },
            {
                data: 'BasicLimit',
                render: function (data, type, row) {
                    return row.basicLimit != null ? '<span class=""percent"">' + row._BasicLimit + '</span>' : '-';
                }
            },
            {
                data: 'IsOptional',
                render: function (data, type, row) {
                    return row.isOptional ? '<span class=""badge badge-pill badge-success text-center"">Sim</span>' : '<span class=""badge badge-pill badge-danger text-center"">Não</span>';
                }
            },
			{
				data: null,
				render: function (data, type, row) {
                    return ""<div class='text-center'><a href='javascript:void(0)' onclick='RemoveProductCoverage("" + row.productCoverageId + "")' title='Excluir' ><i class='far fa-trash-alt'></i></a></div>"";
				}
			}
		]
	});

    function _ProductCoverageIndexDoneTyping() {
 ");
            WriteLiteral(@"       if ($.fn.DataTable.isDataTable('#_ProductCoverageIndexTable')) {
            datatables.search($('#_ProductCoverageIndexSearch').val()).draw();
        }
    }
    $('#_ProductCoverageIndexSearch').keyup(function () {
        clearTimeout(_ProductCoverageIndexDoneTypingInterval);
        _ProductCoverageIndexTypingTimer = setTimeout(_ProductCoverageIndexDoneTyping, _ProductCoverageIndexDoneTypingInterval);
    });
    $('#_ProductCoverageIndexSearch').keydown(function () {
        clearTimeout(_ProductCoverageIndexDoneTyping);
    });

    function RemoveProductCoverage(productCoverageId) {
        if (confirm(""Deseja realmente remover esta cobertura?"")) {
            _RemoveProductCoverage(productCoverageId, function (data) {
                if(!data.hasError)
                    $('#_ProductCoverageIndexTable').DataTable().ajax.reload();
                alert(data.message);
			});
		}
	}

	function _RemoveProductCoverage(_productCoverageId, callback) {
		var d = { id: _productC");
            WriteLiteral("overageId };\r\n\t\t$.ajax({\r\n\t\t\turl: \'");
            EndContext();
            BeginContext(5066, 54, false);
#line 133 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductCoverageIndex\Default.cshtml"
             Write(Url.Action("RemoveProductCoverage", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(5120, 156, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\',\r\n\t\t\tsuccess: function(data){\r\n                callback(data);\r\n            }\r\n\t\t});\r\n\t}\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
