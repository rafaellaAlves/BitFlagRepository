#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResidueFamilyIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab263f49403de7eded47cbf8e5e31a68ae5fe2be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ResidueFamilyIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ResidueFamilyIndex/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab263f49403de7eded47cbf8e5e31a68ae5fe2be", @"/Views/Shared/Components/ResidueFamilyIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ResidueFamilyIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "residue-family-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""row"">
    <div class=""col table-responsive"">
        <table id=""family-table"" class=""display table table-striped table-bordered table-condensed w-100 tablesizeline"" style=""border-collapse: collapse !important;"">
            <thead>
                <tr>
                    <th>Fam??lia</th>
                    <th style=""text-align:center"">Abrevia????o</th>
                    <th>Classe</th>
                    <th style=""text-align:center"">Risco</th>
                    <th style=""text-align:center"">Cl. Risco</th>
                    <th style=""text-align:center"">C??d ONU</th>
                    <th style=""text-align:center"">Res??duos</th>
                    <th style=""width:60px !important;"">&nbsp;</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab263f49403de7eded47cbf8e5e31a68ae5fe2be4849", async() => {
                WriteLiteral(@"
    var familyDatatables;
    $(document).ready(function () {
        familyDatatables = $('#family-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            pageLength: 30,
            dom: 'tip',
            ajax: {
                url: '");
#nullable restore
#line 33 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResidueFamilyIndex\Default.cshtml"
                 Write(Url.Action("List", "ResidueFamily"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                type: 'POST'
            },
            columns: [
                { render: function (data, type, row) { return row.name; } },
                { render: function (data, type, row) { return  '<div class=""text-center"">' + isNull(row.nameAbbreviation, '-'); } },
                { render: function (data, type, row) { return row.residueFamilyClassName; } },
                { render: function (data, type, row) { return '<div class=""text-center"">' + row.risk; } },
                { render: function (data, type, row) { return '<div class=""text-center"">' + row.riskClass; } },
                { render: function (data, type, row) { return '<div class=""text-center"">' + row.onuCode; } },
                { render: function (data, type, row) { return '<div class=""text-center"">' + row.residueCount; } },
                {
                    render: function (data, type, row)
                    {
                        return '<div class=""text-center"">' +
");
                WriteLiteral("                            \'&nbsp;<a href=\"");
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResidueFamilyIndex\Default.cshtml"
                                       Write(Url.Action("Index", "Residues"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?ResidueFamilyId=' + row.residueFamilyId + '"" title=""Inserir Res??duo""><span class=""badge badge-pill badge-primary""><i class=""simple-icon-plus""></i></span></a>' +
                            '&nbsp;<a href=\'javascript:openResidueFamilyModal(' + JSON.stringify(row) + ')\' title=""Editar""><span class=""badge badge-pill badge-success""><i class=""simple-icon-note""></i></span></a>' +
                            '&nbsp;<a href=\'javascript:removeFamily(' + JSON.stringify(row) + ')\' title=""Excluir""><span class=""badge badge-pill badge-danger""><i class=""simple-icon-trash""></i></span></a>' +
                            '</div>';
                    }
                }
            ]
        });
    });

    function removeFamily(entity) {
        bootboxConfirm(""Deseja realmente excluir a Fam??lia \"""" + entity.name + ""\""?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 63 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ResidueFamilyIndex\Default.cshtml"
               Write(Url.Action("Delete", "ResidueFamily"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: entity.residueFamilyId }, function () {
                alert(""A Fam??lia \"""" + entity.name + ""\"" foi exclu??da com sucesso!"");
                familyDatatables.ajax.reload();
            });
        });
    }

    function openResidueFamilyModal(data) {
        loadResidueFamilyData(data);

        $('#add-family-modal').modal('show');
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
            WriteLiteral("\n\n");
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
