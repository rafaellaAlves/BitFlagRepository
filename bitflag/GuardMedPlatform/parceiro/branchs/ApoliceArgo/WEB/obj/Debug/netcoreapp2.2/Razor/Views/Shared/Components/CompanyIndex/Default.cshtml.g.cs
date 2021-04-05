#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56f41e4b7d5d15ac492010280859c3f94f6988f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CompanyIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CompanyIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CompanyIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CompanyIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56f41e4b7d5d15ac492010280859c3f94f6988f9", @"/Views/Shared/Components/CompanyIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CompanyIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.CompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
   
    var companyTypeFunctions = new WEB.BLL.CompanyTypeFunctions(context);
    var imobiliariaTypeId = companyTypeFunctions.GetData().Single(c => c.ExternalCode == "IMOBILIARIA").CompanyTypeId;

#line default
#line hidden
            BeginContext(291, 476, true);
            WriteLiteral(@"<script type=""text/javascript"">
    _MaskData();
</script>

<div class=""row"">
    <div class=""col-md-10"">
        <div class=""input-group mb-3"">
            <div class=""input-group-prepend"">
                <span class=""input-group-text""><i class=""fa fa-search""></i></span>
            </div>
            <input id=""_CompanyIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 767, "\"", 932, 4);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
WriteAttributeValue("", 774, Url.Action("Manage", "Company"), 774, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 806, "?companyTypeId=", 806, 15, true);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
WriteAttributeValue("", 821, Model.CompanyTypeId, 821, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 841, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                     if (Model.ParentCompanyId.HasValue) {

#line default
#line hidden
                BeginContext(885, 17, true);
                WriteLiteral("&parentCompanyId=");
                EndContext();
                BeginContext(903, 21, false);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                                                                            Write(Model.ParentCompanyId);

#line default
#line hidden
                EndContext();
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                                                                                                              }

#line default
#line hidden
                PopWriter();
            }
            ), 841, 91, false);
            EndWriteAttribute();
            BeginContext(933, 375, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />

<div class=""table-wrapper"" style=""margin-top:1em; white-space:nowrap; overflow-x:auto;"">
    <table id=""_CompanyIndexTable"" class=""table display responsive"" style=""border-collapse: collapse !important; width:100%;"">
        <thead>
            <tr>
");
            EndContext();
#line 30 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                 if (!Model.ParentCompanyId.HasValue && Model.CompanyTypeId == imobiliariaTypeId)
                {

#line default
#line hidden
            BeginContext(1426, 20, true);
            WriteLiteral("                <th>");
            EndContext();
            BeginContext(1447, 61, false);
#line 32 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
               Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1508, 5, true);
            WriteLiteral("</th>");
            EndContext();
#line 32 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                       }

#line default
#line hidden
            BeginContext(1516, 500, true);
            WriteLiteral(@"                <th>Razão social/Nome</th>
                <th>Nome</th>
                <th>CNPJ/CPF</th>
                <th>CPF</th>
                <th>Cidade</th>
                <th>UF</th>
                <th>Termo Aceito</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _CompanyIndexTypingTimer;
    var _CompanyIndexDoneTypingInterval = 500;
    var increaseIndex = ");
            EndContext();
#line 50 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                         if (!Model.ParentCompanyId.HasValue && Model.CompanyTypeId == imobiliariaTypeId) {

#line default
#line hidden
            BeginContext(2105, 1, true);
            WriteLiteral("1");
            EndContext();
#line 50 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                                                         } else {

#line default
#line hidden
            BeginContext(2127, 1, true);
            WriteLiteral("0");
            EndContext();
#line 50 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                                                                               }

#line default
#line hidden
            BeginContext(2136, 460, true);
            WriteLiteral(@";
    var datatables = $('#_CompanyIndexTable').DataTable({
        ""columnDefs"": [

            {
                ""targets"": [1 + increaseIndex],
                ""visible"": false
            },
            {
                ""targets"": [3 + increaseIndex],
                ""visible"": false
            }
        ],
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
		dom: 'tip',
		ajax: {
            url: '");
            EndContext();
            BeginContext(2597, 29, false);
#line 69 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
             Write(Url.Action("List", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(2626, 73, true);
            WriteLiteral("\',\r\n            data: function (d) {\r\n                d.companyTypeId = \'");
            EndContext();
            BeginContext(2700, 19, false);
#line 71 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                              Write(Model.CompanyTypeId);

#line default
#line hidden
            EndContext();
            BeginContext(2719, 41, true);
            WriteLiteral("\',\r\n                d.parentCompanyId = \'");
            EndContext();
            BeginContext(2761, 21, false);
#line 72 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                Write(Model.ParentCompanyId);

#line default
#line hidden
            EndContext();
            BeginContext(2782, 62, true);
            WriteLiteral("\'\r\n            },\r\n\t\t\ttype: \'POST\'\r\n\t\t},\r\n        columns: [\r\n");
            EndContext();
#line 77 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
             if(!Model.ParentCompanyId.HasValue && Model.CompanyTypeId == imobiliariaTypeId)
            {
            

#line default
#line hidden
            BeginContext(2971, 410, true);
            WriteLiteral(@"
            {
                data: 'ParentCompany',
                render: function (data, type, row) {
                    if (row.parentRazaoSocial != null)
                        return '<i>' + row.parentNomeFantasia + '</i>';
                    else
                        return '<i>' + row.parentFirstName + ' ' + row.parentLastName + '</i>';
                }
            },
            ");
            EndContext();
#line 89 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                   
            }

#line default
#line hidden
            BeginContext(3405, 158, true);
            WriteLiteral("\t\t\t{ data: \'firstName\',\r\n            render: function (data, type, row) {\r\n                if (row.razaoSocial != null)\r\n                    return \'<a href=\"");
            EndContext();
            BeginContext(3564, 31, false);
#line 94 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                Write(Url.Action("Manage", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(3595, 117, true);
            WriteLiteral("?id=\' + row.companyId + \'\">\' + row.razaoSocial + \'</a>\';\r\n                else\r\n                    return \'<a href=\"");
            EndContext();
            BeginContext(3713, 31, false);
#line 96 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                Write(Url.Action("Manage", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(3744, 1728, true);
            WriteLiteral(@"?id=' + row.companyId + '"">' + row.firstName + "" "" + row.lastName + '</a>';
                }
            },
            {
                data: 'FirstName',
                render: function (data, type, row) {
                    return row.firstName;
                }
            },
            {
                data: 'CNPJ',
                render: function (data, type, row) {
                    if (row.cnpj != null)
                        return '<span class=""cnpj"">' + row.cnpj + '</span>';
                    else
                        return '<span class=""cpf"">' + row.cpf + '</span>';
                }
            },
            {
                data: 'Cpf',
                render: function (data, type, row) {
                    return row.cpf;
                }
            },
            {
                data: 'Cidade',
                render: function (data, type, row) {
                    return row.cidade;
                }
            },
            {
        ");
            WriteLiteral(@"        data: 'UF',
                render: function (data, type, row) {
                    return row.uf;
                }
            },
                {
                    orderable: false,
                    data: 'TermAccepted',
                    render: function (data, type, row) {
                        return row.termAccepted ? '<span class=""badge badge-pill badge-success text-center"">Sim</span>' : '<span class=""badge badge-pill badge-danger text-center"">Não</span>';
                    }
                },
			{
				data: null,
                render: function (data, type, row) {
                    var hasParent = false;
                    var isAdmin = false;
");
            EndContext();
#line 144 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                     if (!Model.ParentCompanyId.HasValue && Model.CompanyTypeId != imobiliariaTypeId) { 

#line default
#line hidden
            BeginContext(5582, 19, true);
            WriteLiteral(" hasParent = true; ");
            EndContext();
#line 144 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                                                                                                                         }

#line default
#line hidden
            BeginContext(5612, 302, true);
            WriteLiteral(@"
                    var r = '<div class=""text-center"" style=""white-space:nowrap;""><a href=""javascript:void(0)"" onclick=""RemoveCompany(' + row.companyId + ')"" title=""Excluir"" ><i class=""far fa-trash-alt""></i></a>';

                    if (hasParent) {
                        r += ""&nbsp;<a href='");
            EndContext();
            BeginContext(5915, 36, false);
#line 149 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                        Write(Url.Action("Imobiliaria", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(5951, 1234, true);
            WriteLiteral(@"?parentCompanyId="" + row.companyId + ""' title='Escritório'><i class='fas fa-building'></i></a></div>"";
                    }

                    return r;
				}
			}
        ],
        initComplete: function () {
            _MaskData();
        }
	});

    function _CompanyIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_CompanyIndexTable')) {
            datatables.search($('#_CompanyIndexSearch').val()).draw();
        }
    }
    $('#_CompanyIndexSearch').keyup(function () {
        clearTimeout(_CompanyIndexDoneTypingInterval);
        _CompanyIndexTypingTimer = setTimeout(_CompanyIndexDoneTyping, _CompanyIndexDoneTypingInterval);
    });
    $('#_CompanyIndexSearch').keydown(function () {
        clearTimeout(_CompanyIndexDoneTyping);
    });

    function RemoveCompany(companyId) {
		if (confirm(""Deseja realmente excluir esta empresa?"")) {
            _RemoveCompany(companyId, function (data) {
                if(!data.hasError)
                    $('#_Compan");
            WriteLiteral("yIndexTable\').DataTable().ajax.reload();\r\n                alert(data.message);\r\n\t\t\t});\r\n\t\t}\r\n\t}\r\n\r\n    function _RemoveCompany(_CompanyId, callback) {\r\n        var d = { id: _CompanyId };\r\n\t\t$.ajax({\r\n\t\t\turl: \'");
            EndContext();
            BeginContext(7186, 38, false);
#line 187 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
             Write(Url.Action("RemoveCompany", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(7224, 1419, true);
            WriteLiteral(@"',
			type: 'POST',
			data: d,
            dataType: 'Json',
            success: function (data) {
                callback(data)
            }
		});
    }
</script>


<div class=""modal fade"" id=""UserCompanyModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" style=""width:100%;"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h6 class=""tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"">Associação de Usuários</h6>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""_UserCompanyManageViewComponent""></div>
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-6"">
                    <button type=""submit"" aria-label=""Close"" class=""btn btn-secondary");
            WriteLiteral(@""" data-dismiss=""modal""><i class=""fa fa-times""></i>&nbsp;Fechar</button>
                </div>
                <div class=""col-md-6"">
                    <a href=""javacsropt:void(0)"" id=""_UserCompanyManageButtonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</a>
                </div>
            </div>
        </div>
    </div>
</div>
");
            EndContext();
#line 222 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
 if (User.IsInRole("Administrator"))
{

#line default
#line hidden
            BeginContext(8684, 122, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function OpenModal(companyId) {\r\n        $(\'#_UserCompanyManageViewComponent\').load(\'");
            EndContext();
            BeginContext(8807, 55, false);
#line 226 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
                                               Write(Url.Action("UserCompanyManageComponent", "UserCompany"));

#line default
#line hidden
            EndContext();
            BeginContext(8862, 311, true);
            WriteLiteral(@"', { ""companyId"": companyId });
        $('#UserCompanyModal').modal('show');
    }

    $('#_UserCompanyManageButtonSubmit').click(function () {
        _UserCompanyManageSave();
    });

    function _UserCompanyManageCallBack(data) {
        $('#UserCompanyModal').modal('hide');
    }
</script>
");
            EndContext();
#line 238 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CompanyIndex\Default.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public DB.Models.Insurance_HomologContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
