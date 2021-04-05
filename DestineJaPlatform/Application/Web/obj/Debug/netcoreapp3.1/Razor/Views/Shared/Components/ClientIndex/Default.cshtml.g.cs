#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2a45c6b72962e379923bdb0f7f37478e3480261"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ClientIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ClientIndex/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2a45c6b72962e379923bdb0f7f37478e3480261", @"/Views/Shared/Components/ClientIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ClientIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "script-client-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""row"">
    <div class=""col"">
        <div class=""table-responsive"">
            <table id=""client-table"" class=""display table table-sm table-striped table-bordered table-condensed w-100 tablesizeline"" style=""border-collapse: collapse !important;"">
                <thead>
                    <tr>
                        <th style=""text-align:center"" width=""100px"">Cód Gerador</th>
                        <th>Razão Social / Nome</th>
                        <th>Fantasia</th>
                        <th>CNPJ / CPF</th>
                        <th>Status</th>
                        <th width=""80px"">&nbsp;</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2a45c6b72962e379923bdb0f7f37478e34802614740", async() => {
                WriteLiteral(@"
    var clientDatatables;
    $(document).ready(function () {
        clientDatatables = $('#client-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            pageLength: 30,
            dom: 'tip',
            ajax: {
                url: '");
#nullable restore
#line 32 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
                 Write(Url.Action("List", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                type: 'POST'
            },
            columns: [
                { render: function (data, type, row) { return '<div class=""text-center"">' + row.clientId; } },
                { render: function (data, type, row) { return '<a class=""text-uppercase"" href=""");
#nullable restore
#line 37 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
                                                                                          Write(Url.Action("Manage", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + row.clientId + '"" >' + row.name + '</a>'; } },
                { render: function (data, type, row) { return row.alternativeName; } },
                { render: function (data, type, row) { return '<div class=""' + (row.isCompany? 'cnpj' : 'cpf') + '"">' + row.document + '</div>'; } },
                { render: function (data, type, row) { return '<div data-client-status-id=""' + (row.solicitation ? 2 : 1) + '"" class=""text-center"">' + (row.solicitation ? ""Simulação"" : ""Gerador"") + '</div>'; } },
                {
                    render: function (data, type, row)
                    {
                        return '<div class=""text-center"">' +
                            '&nbsp;<a href=""");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
                                       Write(Url.Action("Manage", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\' + row.clientId + \'\"  title=\"Visualizar\"><span class=\"badge badge-pill badge-primary\"><i class=\"simple-icon-magnifier\"></i></span></a>\' +\n                            \'&nbsp;<a href=\"");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
                                       Write(Url.Action("Manage", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + row.clientId + '""  title=""Editar""><span class=""badge badge-pill badge-success""><i class=""simple-icon-note""></i></span></a>' +
                            '&nbsp;<a href=\'javascript:removeClient(' + JSON.stringify(row) + ')\' title=""Excluir""><span class=""badge badge-pill badge-danger""><i class=""simple-icon-trash""></i></span></a>' +
                            '</div>';
                    }
                }
            ]
        });
    });

    function removeClient(client) {
        bootboxConfirm(""Deseja realmente excluir o cliente \"""" + client.name + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 59 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
               Write(Url.Action("_Delete", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', { id: client.clientId }, function (d) {\n                if (d.hasError) {\n                    bootboxConfirm(d.message, function (d) {\n                        if(d) window.location.href = \'");
#nullable restore
#line 62 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientIndex\Default.cshtml"
                                                 Write(Url.Action("Manage", "Client"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + client.clientId;
                    })
                    return;
                }

                bootbox.alert(""Cliente \"""" + client.name + ""\"" excluído com sucesso!"");
                clientDatatables.ajax.reload();
            });
        });
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
