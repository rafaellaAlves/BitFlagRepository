#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71327bc091197d3e9b1354857089326cd309045c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/UserIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_UserIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71327bc091197d3e9b1354857089326cd309045c", @"/Views/Shared/Components/UserIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Web.Utils.UserType>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 224, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-10\">\r\n        <div class=\"input-group mb-3\">\r\n\r\n            <input id=\"_UserIndexSearch\" type=\"text\" class=\"form-control\" placeholder=\"Procurar...\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(472, 38, true);
            WriteLiteral("    <div class=\"col-md-2\">\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 510, "\"", 635, 2);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
WriteAttributeValue("", 517, Url.Action("Manage", "User"), 517, 29, false);

#line default
#line hidden
            WriteAttributeValue("", 546, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                               if(Model.Count > 0){

#line default
#line hidden
                BeginContext(573, 10, true);
                WriteLiteral("?userType=");
                EndContext();
                BeginContext(584, 43, false);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                                              Write(string.Join(";", Model.Select(x => (int)x)));

#line default
#line hidden
                EndContext();
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                                                                                                      }

#line default
#line hidden
                PopWriter();
            }
            ), 546, 89, false);
            EndWriteAttribute();
            BeginContext(636, 427, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""simple-icon-plus""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />
<div class=""table-responsive"">
    <table id=""_UserIndexTable"" class=""table table-striped table-bordered"">
        <thead>
            <tr>
                <th>Nome</th>
                <th>E-mail</th>
                <th>Telefone</th>
                <th>Perfil</th>
                <th>Ativo?</th>
");
            EndContext();
#line 29 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                 if (Model.Contains(Web.Utils.UserType.Agent))
                {

#line default
#line hidden
            BeginContext(1146, 43, true);
            WriteLiteral("                    <th>Data Cria????o</th>\r\n");
            EndContext();
#line 32 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1208, 285, true);
            WriteLiteral(@"                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _UserIndexTypingTimer;
    var _UserIndexDoneTypingInterval = 500;
    var datatables = $('#_UserIndexTable').DataTable({
");
            EndContext();
#line 44 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
         if (Model.Contains(Web.Utils.UserType.Agent))
        {
        

#line default
#line hidden
            BeginContext(1574, 70, true);
            WriteLiteral("\r\n        \"order\": [[5, \"desc\"]],\r\n        serverSide: true,\r\n        ");
            EndContext();
#line 49 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
               
        }
        else
        {
        

#line default
#line hidden
            BeginContext(1703, 38, true);
            WriteLiteral("\r\n        serverSide: false,\r\n        ");
            EndContext();
#line 55 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
               
        }

#line default
#line hidden
            BeginContext(1761, 141, true);
            WriteLiteral("        proccessing: true,\r\n        searching: false,\r\n        lengthChange: false,\r\n        dom: \'tip\',\r\n        ajax: {\r\n            url: \'");
            EndContext();
            BeginContext(1903, 26, false);
#line 62 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
             Write(Url.Action("List", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 79, true);
            WriteLiteral("\',\r\n            type: \'POST\',\r\n            data: {\r\n                userType: \'");
            EndContext();
            BeginContext(2009, 43, false);
#line 65 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                      Write(string.Join(";", Model.Select(x => (int)x)));

#line default
#line hidden
            EndContext();
            BeginContext(2052, 204, true);
            WriteLiteral("\'\r\n            }\r\n\t\t},\r\n\t\tcolumns: [\r\n            {\r\n                data: \'FirstName\',\r\n                render: function (data, type, row) {\r\n                    return \'<a title=\"Editar Registro\" href=\"");
            EndContext();
            BeginContext(2257, 28, false);
#line 72 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                        Write(Url.Action("Manage", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(2285, 21, true);
            WriteLiteral("?id=\' + row.userId + ");
            EndContext();
#line 72 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                                                                                if(Model.Count > 0){

#line default
#line hidden
            BeginContext(2333, 11, true);
            WriteLiteral("\'&userType=");
            EndContext();
            BeginContext(2345, 43, false);
#line 72 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                                                                                                                Write(string.Join(";", Model.Select(x => (int)x)));

#line default
#line hidden
            EndContext();
            BeginContext(2388, 4, true);
            WriteLiteral("\' + ");
            EndContext();
#line 72 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                                                                                                                                                                                                            }

#line default
#line hidden
            BeginContext(2400, 1259, true);
            WriteLiteral(@"'"">' + row.firstName + ' ' + (IsNullOrWhiteSpace(row.lastName) ? '' : row.lastName) + '</a>';
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
                    return row.role != null ? row.role : '-';
                }
            },
            {
                orderable: false,
                data: 'IsActive',
                render: function (data, type, row) {
                    var r = '<div class=""text-center"" style=""white-space:nowrap;"">';
                    r += row.isActive ? '<span class");
            WriteLiteral("=\"badge badge-pill badge-success text-center\">Sim</span>\' : \'<span class=\"badge badge-pill badge-danger text-center\">N??o</span>\';\r\n                    r += \'</div>\';\r\n                    return r;\r\n                }\r\n            },\r\n\r\n");
            EndContext();
#line 104 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
             if (Model.Contains(Web.Utils.UserType.Agent))
            {
                

#line default
#line hidden
            BeginContext(3756, 206, true);
            WriteLiteral("\r\n            {\r\n                data: \'CreatedDate\',\r\n                render: function (data, type, row) {\r\n                    return row._CreatedDate;\r\n                }\r\n            },\r\n                ");
            EndContext();
#line 113 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
                       
            }

#line default
#line hidden
            BeginContext(3986, 1204, true);
            WriteLiteral(@"			{
				data: null,
				render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""RemoveUser(' + row.userId + ')"" class=""btn btn-danger"" style=""padding:5px; vertical-align: middle;"" title=""Excluir""><i class=""simple-icon-trash""></i></a>';
				}
			}
        ]
	});

    function _UserIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_UserIndexTable')) {
            datatables.search($('#_UserIndexSearch').val()).draw();
        }
    }
    $('#_UserIndexSearch').keyup(function () {
        clearTimeout(_UserIndexDoneTypingInterval);
        _UserIndexTypingTimer = setTimeout(_UserIndexDoneTyping, _UserIndexDoneTypingInterval);
    });
    $('#_UserIndexSearch').keydown(function () {
        clearTimeout(_UserIndexDoneTyping);
    });

    function RemoveUser(id) {
		if (confirm(""Deseja realmente excluir este usu??rio?"")) {
            _RemoveUser(id, function () {
                $('#_UserIndexTable').DataT");
            WriteLiteral("able().ajax.reload();\r\n\t\t\t\talert(\"Usu??rio exclu??do com sucesso!\");\r\n\t\t\t});\r\n\t\t}\r\n\t}\r\n\r\n    function _RemoveUser(_id, callback) {\r\n        var d = { id: _id};\r\n\t\t$.ajax({\r\n\t\t\turl: \'");
            EndContext();
            BeginContext(5191, 32, false);
#line 149 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserIndex\Default.cshtml"
             Write(Url.Action("RemoveUser", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(5223, 99, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Web.Utils.UserType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
