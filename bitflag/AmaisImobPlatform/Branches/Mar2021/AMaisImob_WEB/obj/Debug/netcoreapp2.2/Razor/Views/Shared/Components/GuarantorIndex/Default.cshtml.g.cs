#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "228ce28fbf157d49e9e24e3412b4adf4e03c1804"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GuarantorIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/GuarantorIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/GuarantorIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_GuarantorIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228ce28fbf157d49e9e24e3412b4adf4e03c1804", @"/Views/Shared/Components/GuarantorIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_GuarantorIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(11, 35, true);
            WriteLiteral("\r\n<style type=\"text/css\">\r\n        ");
            EndContext();
            BeginContext(47, 72, true);
            WriteLiteral("@font-face {\r\n            font-family: \'Avenir\';\r\n            src: url(\'");
            EndContext();
            BeginContext(120, 72, false);
#line 9 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
                 Write(Url.Content("~/assets/fonts/0078f486-8e52-42c0-ad81-3c8d3d43f48e.woff2"));

#line default
#line hidden
            EndContext();
            BeginContext(192, 9, true);
            WriteLiteral("\'), url(\'");
            EndContext();
            BeginContext(202, 71, false);
#line 9 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
                                                                                                   Write(Url.Content("~/assets/fonts/bc176270-17fa-4c78-a343-9fe52824e501.woff"));

#line default
#line hidden
            EndContext();
            BeginContext(273, 9, true);
            WriteLiteral("\'), url(\'");
            EndContext();
            BeginContext(283, 72, false);
#line 9 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
                                                                                                                                                                                    Write(Url.Content("~/assets/fonts/d513e15e-8f35-4129-ad05-481815e52625.woff2"));

#line default
#line hidden
            EndContext();
            BeginContext(355, 514, true);
            WriteLiteral(@"');
        }
</style>

<style>
    body {
        font-family: Avenir;
    }
</style>


<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_GuarantorIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 869, "\"", 910, 1);
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
WriteAttributeValue("", 876, Url.Action("Manage", "Guarantor"), 876, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(911, 881, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />

<div class=""table-wrapper"">
    <table id=""_GuarantorIndexTable"" class=""table display responsive nowrap"" style=""border-collapse: collapse !important;"">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <th>Nome Fantasia</th>
                <th>Razão Social</th>
                <th>Ativo?</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>

<script type=""text/javascript"">

    var _GuarantorIndexTypingTimer;
    var _GuarantorIndexDoneTypingInterval = 500;
    var datatables = $('#_GuarantorIndexTable').DataTable({
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
		dom: 'tip',
		ajax: {
			url: '");
            EndContext();
            BeginContext(1793, 31, false);
#line 61 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
             Write(Url.Action("List", "Guarantor"));

#line default
#line hidden
            EndContext();
            BeginContext(1824, 373, true);
            WriteLiteral(@"',
            type: 'POST'

		},
        columns: [
            {
                data: 'Id',
                render: function (data, type, row) {
                return row.guarantorId;
                }
            },
            {
                data: 'NomeFantasia',
                render: function (data, type, row) {
                return '<a href=""");
            EndContext();
            BeginContext(2198, 33, false);
#line 75 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
                            Write(Url.Action("Manage", "Guarantor"));

#line default
#line hidden
            EndContext();
            BeginContext(2231, 1892, true);
            WriteLiteral(@"?id=' + row.guarantorId + '"">' + row.nomeFantasia + '</a>';
                }
            },
            {
                data: 'RazaoSocial',
                render: function (data, type, row) {
                return row.razaoSocial;
                }
            },
            {
                orderable: false,
                data: 'IsActive',
                render: function (data, type, row) {
                    return row.isActive ? '<span class=""badge badge-pill badge-success text-center"">Sim</span>' : '<span class=""badge badge-pill badge-danger text-center"">Não</span>';
                }
            },
            {
                orderable: false,
				data: null,
				render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""RemoveUser(' + row.guarantorId + ')"" title=""Excluir"" ><i class=""far fa-trash-alt""></i></a></div>';
				}
			}



		]
	});

    function _GuarantorIndexDoneTyping() {
        if");
            WriteLiteral(@" ($.fn.DataTable.isDataTable('#_GuarantorIndexTable')) {
            datatables.search($('#_GuarantorIndexSearch').val()).draw();
        }
    }
    $('#_GuarantorIndexSearch').keyup(function () {
        clearTimeout(_GuarantorIndexDoneTypingInterval);
        _GuarantorIndexTypingTimer = setTimeout(_GuarantorIndexDoneTyping, _GuarantorIndexDoneTypingInterval);
    });
    $('#_GuarantorIndexSearch').keydown(function () {
        clearTimeout(_GuarantorIndexDoneTyping);
    });

    function RemoveUser(id) {
		if (confirm(""Deseja realmente excluir esta Garantidora?"")) {
            _RemoveUser(id, function () {
                $('#_GuarantorIndexTable').DataTable().ajax.reload();
				alert(""Garantidora excluída com sucesso!"");
			});
		}
	}

    function _RemoveUser(_id, callback) {
        var d = { id: _id};
		$.ajax({
			url: '");
            EndContext();
            BeginContext(4124, 42, false);
#line 129 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\GuarantorIndex\Default.cshtml"
             Write(Url.Action("RemoveGuarantor", "Guarantor"));

#line default
#line hidden
            EndContext();
            BeginContext(4166, 99, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\',\r\n\t\t\tsuccess: callback\r\n\t\t});\r\n\t}\r\n</script>");
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
