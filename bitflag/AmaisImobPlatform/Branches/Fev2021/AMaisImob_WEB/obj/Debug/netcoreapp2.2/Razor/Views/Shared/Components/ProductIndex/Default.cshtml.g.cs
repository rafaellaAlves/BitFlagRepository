#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41e0fb838b5cfe2a1cf7509d8d9ab55ad08b9087"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductIndex_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41e0fb838b5cfe2a1cf7509d8d9ab55ad08b9087", @"/Views/Shared/Components/ProductIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            <input id=""ProductIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-2"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 411, "\"", 450, 1);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
WriteAttributeValue("", 418, Url.Action("Manage", "Product"), 418, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(451, 991, true);
            WriteLiteral(@" class=""btn btn-success pull-right w-100"" style=""color:white;""><i class=""fas fa-plus-circle""></i>&nbsp;Novo</a>
    </div>
</div>
<hr />

<div class=""table-wrapper"">
    <table id=""ProductIndexTable"" class=""table display responsive"" style=""border-collapse: collapse !important; width:100%"">
        <thead>
            <tr>
                <td>Nome</td>
                <td>Descrição</td>
                <td>Qtd. Coberturas</td>
                <td>Qtd. Planos</td>
                <td>Gerenciar</td>
                <td style=""min-width: 80px;"">&nbsp;</td>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>

<script type=""text/javascript"">
    var ProductIndexTypingTimer;
    var ProductIndexDoneTypingInterval = 500;
    var ProductDatatables = $('#ProductIndexTable').DataTable({
	    proccessing: true,
        serverSide: true,
	    searching: true,
	    lengthChange: false,
	    dom: 'tip',
	    ajax: {
            url: '");
            EndContext();
            BeginContext(1443, 29, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
             Write(Url.Action("List", "Product"));

#line default
#line hidden
            EndContext();
            BeginContext(1472, 195, true);
            WriteLiteral("\',\r\n\t\t    type: \'POST\'\r\n        },\r\n\t    columns: [\r\n            {\r\n                data: \'ProductId\',\r\n                render: function (data, type, row) {\r\n                    return \"<a href=\'");
            EndContext();
            BeginContext(1668, 30, false);
#line 49 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                                Write(Url.Action("Manage","Product"));

#line default
#line hidden
            EndContext();
            BeginContext(1698, 907, true);
            WriteLiteral(@"?id="" + row.productId + ""')'>"" + row.name + ""</a>"";
                    return ;
                }
            },
            {
                data: 'Description',
                render: function (data, type, row) {
                    return row.description;
                }
            },
            {
                data: 'QtdCoverage',
                render: function (data, type, row) {
                    return row.qtdCoverage;
                }
            },
            {
                data: 'QtdPlan',
                render: function (data, type, row) {
                    return row.qtdPlan;
                }
            }
            ,
            {
                data: '',
                orderable: false,
                render: function (data, type, row) {
                    return ""<div class='text-center' style='white-space:nowrap;'><a  href='");
            EndContext();
            BeginContext(2606, 37, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                                                                                      Write(Url.Action("Index","ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(2643, 106, true);
            WriteLiteral("?ProductId=\" + row.productId + \"\')\'><span class=\'badge badge-primary\'>Coberturas</span></a>&nbsp;<a href=\'");
            EndContext();
            BeginContext(2750, 26, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                                                                                                                                                                                                                                      Write(Url.Action("Index","Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(2776, 1386, true);
            WriteLiteral(@"?productId="" + row.productId + ""'><span class='badge badge-primary'>Planos</span></a>&nbsp;<a href='javascript:OpenProductAssistanceModal("" + row.productId + "")' title='produto x assistência'><span class='badge badge-primary'>Assistências</span></a></div>"";
                }
            },
            {
                data: '',
                orderable: false,
                render: function (data, type, row) {

                   return ""<div class='text-center'><a href='javascript:void(0)' title='Excluir' class='fas fa-trash ' onclick='RemoveProduct("" + JSON.stringify({ productId: row.productId, name: row.name }) + "")'></a></div>"";
                   
                }
            }
	    ]
    });

    function ProductIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#ProductIndexTable')) {
            ProductDatatables.search($('#ProductIndexSearch').val()).draw();
        }
    }
    $('#ProductIndexSearch').keyup(function () {
        clearTimeout(ProductIndexTypingTimer");
            WriteLiteral(@");
        ProductIndexTypingTimer = setTimeout(ProductIndexDoneTyping, ProductIndexDoneTypingInterval);
    });
    $('#ProductIndexSearch').keydown(function () {
        clearTimeout(ProductIndexTypingTimer);
    });


    function RemoveProduct(data) {
        if (confirm(""Deseja remover o produto?"")) {
            $.ajax({
                url: '");
            EndContext();
            BeginContext(4163, 38, false);
#line 108 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                 Write(Url.Action("RemoveProduct", "Product"));

#line default
#line hidden
            EndContext();
            BeginContext(4201, 1750, true);
            WriteLiteral(@"',
                type: 'POST',
                datatype: 'JSON',
                data: { id: data.productId },
                success: function (data) {
                    if(!data.hasError){
                        $('#ProductIndexTable').DataTable().ajax.reload();
                    }
                    alert(data.message);
                }
            });
        }
    }

  
</script>
<div class=""modal fade"" id=""ProductPlanModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" style=""width:100%;"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h6 class=""tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"">Associação de Planos</h6>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div ");
            WriteLiteral(@"id=""_ProductPlanViewComponent""></div>
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-6"">
                    <button type=""submit"" aria-label=""Close"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""fa fa-times""></i>&nbsp;Fechar</button>
                </div>
                <div class=""col-md-6"">
                    <a href=""javacsropt:void(0)"" id=""_ProductPlanButtonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</a>
                </div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function OpenModal(data) {
        $('#_ProductPlanViewComponent').load('");
            EndContext();
            BeginContext(5952, 45, false);
#line 150 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                                         Write(Url.Action("ProductPlanComponent", "Product"));

#line default
#line hidden
            EndContext();
            BeginContext(5997, 1770, true);
            WriteLiteral(@"', { ""productId"": data.productId });
        $('#ProductPlanModal').modal('show');
    }

    $('#_ProductPlanButtonSubmit').click(function () {
        _ProductPlanSave();
    });

    function _ProductPlanCallBack(data) {
        $('#ProductPlanModal').modal('hide');
        $('#ProductIndexTable').DataTable().ajax.reload();
    }
</script>



<div class=""modal fade"" id=""ProductAssistanceModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" style=""width:100%;"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h6 class=""tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"">Associação de Assistências</h6>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""_ProductAssistanceManageViewCompon");
            WriteLiteral(@"ent""></div>
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-6"">
                    <button type=""submit"" aria-label=""Close"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""fa fa-times""></i>&nbsp;Fechar</button>
                </div>
                <div class=""col-md-6"">
                    <a href=""javacsropt:void(0)"" id=""_ProductAssistanceManageButtonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</a>
                </div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function OpenProductAssistanceModal(productId) {
        $('#_ProductAssistanceManageViewComponent').load('");
            EndContext();
            BeginContext(7768, 54, false);
#line 192 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\ProductIndex\Default.cshtml"
                                                     Write(Url.Action("ProductAssistanceComponent", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(7822, 339, true);
            WriteLiteral(@"', { ""productId"": productId });
        $('#ProductAssistanceModal').modal('show');
    }

    $('#_ProductAssistanceManageButtonSubmit').click(function () {
        _ProductAssistanceManageSave();
    });

    function _ProductAssistanceManageCallBack(data) {
        $('#ProductAssistanceModal').modal('hide');
    }
</script>");
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