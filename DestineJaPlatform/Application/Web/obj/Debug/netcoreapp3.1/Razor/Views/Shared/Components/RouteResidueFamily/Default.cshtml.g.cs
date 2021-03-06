#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c04bfccda73b7377de39e4c489292d568c599064"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RouteResidueFamily_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RouteResidueFamily/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c04bfccda73b7377de39e4c489292d568c599064", @"/Views/Shared/Components/RouteResidueFamily/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RouteResidueFamily_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<DTO.Route.RouteResidueFamilyParameterViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "route-client-family", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
<style type=""text/css"">
    #route-client-families-selection-table td:first-child {
        text-align: center;
    }

    #route-client-families-selection-table td {
        cursor: pointer;
    }

    #route-client-families-selection-table {
        max-height: 350px;
        overflow-y: auto;
    }

    #route-client-family-modal thead tr {
        background: #a1a1a1;
        color: white;
    }
</style>

<div class=""row"">
    <div class=""col-12"">
        <table class=""table table-condensed table-striped table-bordered"" id=""route-client-families-selection-table"">
            <thead>
                <tr>
                    <th class=""text-center""><input type=""checkbox"" id=""select-all-families-checkbox"" onclick=""selectAllFamiliesCheckbox(this)"" /></th>
                    <th>Classe</th>
                    <th>Nome</th>
                    <th>Abrevia????o</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 35 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                 foreach (var item in Model.Model.Items)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 1119, "\"", 1208, 6);
            WriteAttributeValue("", 1129, "showResiduesTr(", 1129, 15, true);
#nullable restore
#line 37 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
WriteAttributeValue("", 1144, item.ResidueFamily.ResidueFamilyId, 1144, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1179, ",", 1179, 1, true);
            WriteAttributeValue(" ", 1180, "\'", 1181, 2, true);
#nullable restore
#line 37 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
WriteAttributeValue("", 1182, item.ResidueFamily.Name, 1182, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1206, "\')", 1206, 2, true);
            EndWriteAttribute();
            WriteLiteral(" data-family-id=\"");
#nullable restore
#line 37 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                                                                                                                             Write(item.ResidueFamily.ResidueFamilyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                        <td><input type=\"checkbox\" data-family-id=\"");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                                                              Write(item.ResidueFamily.ResidueFamilyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-name=\"");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                                                                                                               Write(string.IsNullOrWhiteSpace(item.ResidueFamily.NameAbbreviation)? item.ResidueFamily.Name : item.ResidueFamily.NameAbbreviation);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" /></td>\n                        <td>");
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                       Write(item.ResidueFamily.ResidueFamilyClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 40 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                       Write(item.ResidueFamily.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                       Write(item.ResidueFamily.NameAbbreviation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<hr />
<div class=""row"">
    <div class=""col-12"">
        <table class=""table table-condensed table-striped table-bordered"" id=""route-client-residue-table"">
            <thead>
                <tr>
                    <th colspan=""3"" class=""text-center"" style=""border-bottom:0px;"">
                        Residuos a coletar <span id=""route-client-residue-table-family-name""></span>
                    </th>
                </tr>
                <tr>
                    <th>C??digo IBAMA</th>
                    <th>Nome</th>
                </tr>
            </thead>
            <tbody>
                <tr id=""route-client-residue-table-tr-none"">
                    <td colspan=""2"" class=""text-center"">Clique em uma famil??a para visualizar os Res??duos</td>
                </tr>
");
#nullable restore
#line 67 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                 foreach (var item in Model.Model.Items)
                {
                    foreach (var residue in item.Residues)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr style=\"display:none;\" data-family-id=\"");
#nullable restore
#line 71 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                                                             Write(item.ResidueFamily.ResidueFamilyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                            <td>");
#nullable restore
#line 72 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                           Write(residue.IBAMACode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 73 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                           Write(residue.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        </tr>\n");
#nullable restore
#line 75 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c04bfccda73b7377de39e4c489292d568c59906411790", async() => {
                WriteLiteral(@"
    function showResiduesTr(familyId, name)
    {
        $('#select-all-families-checkbox')[0].checked = false;

        $('#route-client-residue-table-family-name').text('(' + name + ')');
        $('#route-client-residue-table tbody tr').hide();

        var trs = $('#route-client-residue-table tbody tr[data-family-id=""' + familyId + '""]');

        $(trs).show();
        if (trs.length == 0) $('#route-client-residue-table-tr-none').show();
    }

    function _selectResidueFamiliesCallback()
    {
        if (typeof selectResidueFamiliesCallback != 'function') return;

        if ($('#route-client-families-selection-table input[type=""checkbox""][data-family-id]:checked').length == 0) {
            bootbox.alert('Selecione ao menos uma fam??lia');
            return;
        }

        var families = []

        $('#route-client-families-selection-table input[type=""checkbox""][data-family-id]:checked').each(function (i, e) {
            families.push({
                id: $(e).data('family-id'),
            ");
                WriteLiteral("    name: $(e).data(\'name\')\n            });\n        });\n\n        selectResidueFamiliesCallback({\n            families,\n            clientCollectionAddressId: ");
#nullable restore
#line 116 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
                                  Write(Model.Model.ClientCollectionAddressId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n        });\n\n        selectAddresses();\n    }\n\n\n    function selectAllFamiliesCheckbox(sel) {\n        $(\'#route-client-families-selection-table input[type=\"checkbox\"]\').each(function (i, e) {\n            e.checked = sel.checked;\n        });\n    }\n\n");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 82 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\RouteResidueFamily\Default.cshtml"
__Web_Utils_TagHelperScriptCut.LoadFromController = Model.LoadFromController;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-cut-key-load-from-controller", __Web_Utils_TagHelperScriptCut.LoadFromController, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<DTO.Route.RouteResidueFamilyParameterViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
