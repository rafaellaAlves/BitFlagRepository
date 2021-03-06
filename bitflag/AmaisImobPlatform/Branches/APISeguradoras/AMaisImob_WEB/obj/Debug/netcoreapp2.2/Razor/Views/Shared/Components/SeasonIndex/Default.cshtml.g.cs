#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61b31ee2fedaf4a72932c06416a698374384abc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SeasonIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SeasonIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/SeasonIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_SeasonIndex_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61b31ee2fedaf4a72932c06416a698374384abc9", @"/Views/Shared/Components/SeasonIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SeasonIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 411, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_SeasonIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 411, "\"", 449, 1);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonIndex\Default.cshtml"
WriteAttributeValue("", 418, Url.Action("Manage", "Season"), 418, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(450, 834, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />
<div class=""table-wrapper"">
    <table id=""_SeasonIndexTable"" class=""table display responsive nowrap"" style=""border-collapse: collapse !important;"">
        <thead>
            <tr>
                <th>Nome</th>
                <th>Data de In??cio</th>
                <th>Data de T??rmino</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _SeasonIndexTypingTimer;
    var _SeasonIndexDoneTypingInterval = 500;
    var datatables = $('#_SeasonIndexTable').DataTable({
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
		dom: 'tip',
		ajax: {
			url: '");
            EndContext();
            BeginContext(1285, 28, false);
#line 39 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonIndex\Default.cshtml"
             Write(Url.Action("List", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(1313, 144, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\'\r\n\t\t},\r\n\t\tcolumns: [\r\n\t\t\t{ data: \'Name\',\r\n            render: function (data, type, row) {\r\n                return \'<a href=\"");
            EndContext();
            BeginContext(1458, 30, false);
#line 45 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonIndex\Default.cshtml"
                            Write(Url.Action("Manage", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(1488, 1621, true);
            WriteLiteral(@"?id=' + row.seasonId + '"">' + row.name + '</a>';
                }
            },
			{ data: 'StartDate',
            render: function (data, type, row) {
                return row._StartDate;
                }
            },
            {
                data: 'EndDate',
                render: function (data, type, row) {
                    return row._EndDate;
                }
            },
			{
				data: null,
				render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""RemoveSeason(' + row.seasonId + ')"" title=""Excluir"" ><i class=""far fa-trash-alt""></i></a></div>';
				}
			}
		]
	});

    function _SeasonIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_SeasonIndexTable')) {
            datatables.search($('#_SeasonIndexSearch').val()).draw();
        }
    }
    $('#_SeasonIndexSearch').keyup(function () {
        clearTimeout(_SeasonIndexDoneTypingInterval);
        _SeasonIndexTypingTi");
            WriteLiteral(@"mer = setTimeout(_SeasonIndexDoneTyping, _SeasonIndexDoneTypingInterval);
    });
    $('#_SeasonIndexSearch').keydown(function () {
        clearTimeout(_SeasonIndexDoneTyping);
    });

    function RemoveSeason(seasonId) {
		if (confirm(""Deseja realmente excluir esta temporada?"")) {
            _RemoveSeason(seasonId, function () {
                $('#_SeasonIndexTable').DataTable().ajax.reload();
                alert(""Temporada exclu??da com sucesso!"");
			});
		}
	}

	function _RemoveSeason(_seasonId, callback) {
        var d = { id: _seasonId };
		$.ajax({
			url: '");
            EndContext();
            BeginContext(3110, 36, false);
#line 93 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonIndex\Default.cshtml"
             Write(Url.Action("RemoveSeason", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(3146, 101, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\',\r\n\t\t\tsuccess: callback\r\n\t\t});\r\n\t}\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
