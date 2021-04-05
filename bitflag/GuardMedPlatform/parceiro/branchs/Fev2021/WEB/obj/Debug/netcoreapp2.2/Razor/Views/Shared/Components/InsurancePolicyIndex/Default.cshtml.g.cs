#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bec719467ab3198c03708ea8b3c1815d12a7912"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_InsurancePolicyIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/InsurancePolicyIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/InsurancePolicyIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_InsurancePolicyIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bec719467ab3198c03708ea8b3c1815d12a7912", @"/Views/Shared/Components/InsurancePolicyIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InsurancePolicyIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 420, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_InsurancePolicyIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 420, "\"", 467, 1);
#line 11 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml"
WriteAttributeValue("", 427, Url.Action("Manage", "InsurancePolicy"), 427, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(468, 459, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />
<div class=""table-wrapper"">
    <table id=""_InsurancePolicyIndexTable"" class=""table display responsive nowrap"" style=""border-collapse: collapse !important;"">
        <thead>
            <tr>
                <th>Nº Apólice</th>
                <th>Início de Vigência</th>
                <th>Fim de Vigência</th>
                <th>");
            EndContext();
            BeginContext(928, 61, false);
#line 22 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml"
               Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(989, 482, true);
            WriteLiteral(@"</th>
                <th>Produto</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _InsurancePolicyIndexTypingTimer;
    var _InsurancePolicyIndexDoneTypingInterval = 500;
    var datatables = $('#_InsurancePolicyIndexTable').DataTable({
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
		dom: 'tip',
		ajax: {
			url: '");
            EndContext();
            BeginContext(1472, 37, false);
#line 41 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml"
             Write(Url.Action("List", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(1509, 187, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\'\r\n\t\t},\r\n\t\tcolumns: [\r\n            {\r\n                data: \'InsurancePolicyNumber\',\r\n            render: function (data, type, row) {\r\n                return \'<a href=\"");
            EndContext();
            BeginContext(1697, 39, false);
#line 48 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml"
                            Write(Url.Action("Manage", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 2250, true);
            WriteLiteral(@"?id=' + row.insurancePolicyId + '"">' + row.insurancePolicyNumber + '</a>';
                }
            },
            {
                data: 'StartDate',
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
                data: 'CorretoraName',
                render: function (data, type, row) {
                    return row.corretoraName;
                }
            },
            {
                data: 'ProductName',
                render: function (data, type, row) {
                    return row.productName;
                }
            },
			{
				data: null,
				render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""RemoveInsurancePoli");
            WriteLiteral(@"cy(' + row.insurancePolicyId + ')"" title=""Excluir"" ><i class=""far fa-trash-alt""></i></a></div>';
				}
			}
		]
	});

    function _InsurancePolicyIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_InsurancePolicyIndexTable')) {
            datatables.search($('#_InsurancePolicyIndexSearch').val()).draw();
        }
    }
    $('#_InsurancePolicyIndexSearch').keyup(function () {
        clearTimeout(_InsurancePolicyIndexDoneTypingInterval);
        _InsurancePolicyIndexTypingTimer = setTimeout(_InsurancePolicyIndexDoneTyping, _InsurancePolicyIndexDoneTypingInterval);
    });
    $('#_InsurancePolicyIndexSearch').keydown(function () {
        clearTimeout(_InsurancePolicyIndexDoneTyping);
    });

    function RemoveInsurancePolicy(insurancePolicyId) {
		if (confirm(""Deseja realmente excluir esta apólice?"")) {
            _RemoveInsurancePolicy(insurancePolicyId, function (data) {
                if(!data.hasError)
                    $('#_InsurancePolicyIndexTable').DataTable");
            WriteLiteral("().ajax.reload();\r\n                alert(data.message);\r\n\t\t\t});\r\n\t\t}\r\n\t}\r\n\r\n\tfunction _RemoveInsurancePolicy(_InsurancePolicyId, callback) {\r\n\t\tvar d = { id: _InsurancePolicyId };\r\n\t\t$.ajax({\r\n\t\t\turl: \'");
            EndContext();
            BeginContext(3987, 54, false);
#line 110 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyIndex\Default.cshtml"
             Write(Url.Action("RemoveInsurancePolicy", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(4041, 155, true);
            WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\',\r\n\t\t\tsuccess: function(data){\r\n                callback(data)\r\n            }\r\n\t\t});\r\n\t}\r\n</script>\r\n");
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
