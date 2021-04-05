#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\AccountIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "031a335cbc64eddc233df17d3b2bfb122b6b3ced"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AccountIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AccountIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/AccountIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_AccountIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"031a335cbc64eddc233df17d3b2bfb122b6b3ced", @"/Views/Shared/Components/AccountIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AccountIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 412, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_AccountIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 412, "\"", 451, 1);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\AccountIndex\Default.cshtml"
WriteAttributeValue("", 419, Url.Action("Manage", "Account"), 419, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(452, 923, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />
<div class=""table-wrapper"">
    <table id=""_AccountIndexTable"" class=""table display responsive nowrap"" style=""border-collapse: collapse !important;"">
        <thead>
            <tr>
                <th>Nome</th>
                <th>E-mail</th>
                <th>Telefone</th>
                <th>Perfil</th>
                <th>Empresa</th>
                <th>Ativo?</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _AccountIndexTypingTimer;
    var _AccountIndexDoneTypingInterval = 500;
    var datatables = $('#_AccountIndexTable').DataTable({
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
		dom: 'tip',
		ajax: {
			url: '");
            EndContext();
            BeginContext(1376, 29, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\AccountIndex\Default.cshtml"
             Write(Url.Action("List", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(1405, 149, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\'\r\n\t\t},\r\n\t\tcolumns: [\r\n\t\t\t{ data: \'FirstName\',\r\n            render: function (data, type, row) {\r\n                return \'<a href=\"");
            EndContext();
            BeginContext(1555, 31, false);
#line 48 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\AccountIndex\Default.cshtml"
                            Write(Url.Action("Manage", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(1586, 2496, true);
            WriteLiteral(@"?id=' + row.userId + '"">' + row.firstName + ' ' + row.lastName + '</a>';
                }
            },
            {
                data: 'Email',
                render: function (data, type, row) {
                    return row.email != null? row.email : '-';
                }
            },
            {
                data: 'PhoneNumber',
                render: function (data, type, row) {
                    return row.phoneNumber != null ? row.phoneNumber : '-';
                }
            },
            {
                data: 'Role',
                render: function (data, type, row) {
                    return row.role != null ? '<span>' + row.role + '</span>' : '-';
                }
            },
            {
                data: 'CompanyName',
                render: function (data, type, row) {
                    return row.companyName != null ? row.companyName : '-';
                }
            },
            {
                orderable: false,
      ");
            WriteLiteral(@"          data: 'IsActive',
                render: function (data, type, row) {
                    return row.isActive ? '<span class=""badge badge-pill badge-success text-center"">Sim</span>' : '<span class=""badge badge-pill badge-danger text-center"">Não</span>';
                }
            },
			{
				data: null,
				render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""RemoveUser(' + row.userId + ')"" title=""Excluir"" ><i class=""far fa-trash-alt""></i></a></div>';
				}
			}
		]
	});

    function _AccountIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_AccountIndexTable')) {
            datatables.search($('#_AccountIndexSearch').val()).draw();
        }
    }
    $('#_AccountIndexSearch').keyup(function () {
        clearTimeout(_AccountIndexDoneTypingInterval);
        _AccountIndexTypingTimer = setTimeout(_AccountIndexDoneTyping, _AccountIndexDoneTypingInterval);
    });
    $('#_AccountIndexSea");
            WriteLiteral(@"rch').keydown(function () {
        clearTimeout(_AccountIndexDoneTyping);
    });

    function RemoveUser(id) {
		if (confirm(""Deseja realmente excluir este usuário?"")) {
            _RemoveUser(id, function () {
                $('#_AccountIndexTable').DataTable().ajax.reload();
				alert(""Usuário excluído com sucesso!"");
			});
		}
	}

    function _RemoveUser(_id, callback) {
        var d = { id: _id};
		$.ajax({
			url: '");
            EndContext();
            BeginContext(4083, 35, false);
#line 116 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\AccountIndex\Default.cshtml"
             Write(Url.Action("RemoveUser", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(4118, 101, true);
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
