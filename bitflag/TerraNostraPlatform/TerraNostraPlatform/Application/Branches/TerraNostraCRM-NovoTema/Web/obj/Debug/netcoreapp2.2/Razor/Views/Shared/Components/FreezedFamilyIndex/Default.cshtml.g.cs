#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d0a02be9a84c77bdcf17944f86be155616dcbbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FreezedFamilyIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FreezedFamilyIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FreezedFamilyIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FreezedFamilyIndex_Default))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d0a02be9a84c77bdcf17944f86be155616dcbbd", @"/Views/Shared/Components/FreezedFamilyIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FreezedFamilyIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "APPROVED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "REPROVED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "PENDING", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 418, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    _MaskData();
</script>

<div class=""row"">
    <div class=""col-md-9"">
        <div class=""input-group mb-3"">
            
            <input id=""_FreezedFamilyIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
        </div>
    </div>
    <div class=""col-md-3"">
        <select id=""FreezedFamilyStatusFilter"" class=""form-control"">
            ");
            EndContext();
            BeginContext(436, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0a02be9a84c77bdcf17944f86be155616dcbbd5378", async() => {
                BeginContext(453, 15, true);
                WriteLiteral("Todos os Status");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(477, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(491, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0a02be9a84c77bdcf17944f86be155616dcbbd6774", async() => {
                BeginContext(516, 8, true);
                WriteLiteral("Aprovado");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(533, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(547, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0a02be9a84c77bdcf17944f86be155616dcbbd8162", async() => {
                BeginContext(572, 9, true);
                WriteLiteral("Reprovado");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(590, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(604, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0a02be9a84c77bdcf17944f86be155616dcbbd9551", async() => {
                BeginContext(628, 8, true);
                WriteLiteral("Pendente");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(645, 622, true);
            WriteLiteral(@"
        </select>
    </div>
</div>
<hr />
<div class=""table-wrapper"">
    <table id=""_FreezedFamilyIndexTable"" class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
        <thead>
            <tr>
                <th style=""white-space: nowrap"">&nbsp;</th>
                <th>Cliente</th>
                <th style=""white-space: nowrap"">Qtd. Membros&nbsp;</th>
                <th style=""white-space: nowrap"">Gerado por</th>
                <th>Aprovado?&nbsp;</th>
                <th style=""white-space: nowrap"">Responsável</th>
");
            EndContext();
#line 34 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
                 if (User.FreezedFamilyCanAccessEdition())
                {

#line default
#line hidden
            BeginContext(1346, 65, true);
            WriteLiteral("                    <th style=\"white-space: nowrap\">&nbsp;</th>\r\n");
            EndContext();
#line 37 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1430, 465, true);
            WriteLiteral(@"            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _FreezedFamilyIndexTypingTimer;
    var _FreezedFamilyIndexDoneTypingInterval = 500;
    var _FreezedFamilyIndexDatatables = $('#_FreezedFamilyIndexTable').DataTable({
        proccessing: true,
        serverSide: true,
        searching: true,
        lengthChange: false,
        dom: 'tip',
        ajax: {
            url: '");
            EndContext();
            BeginContext(1896, 48, false);
#line 54 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
             Write(Url.Action("FreezedFamilyList", "FreezedFamily"));

#line default
#line hidden
            EndContext();
            BeginContext(1944, 436, true);
            WriteLiteral(@"',
            data: function (d) {
                d.freezedFamilyStatusFilter = $('#FreezedFamilyStatusFilter').val()
            },
            type: 'POST'
        },
        order: [[0, 'desc']],
        columns: [
            {
                data: 'FreezedFamilyTerraNostraId',
                render: function (data, type, row) {
                    return '<div class=""text-center""><a title=""Editar Registro"" href=""");
            EndContext();
            BeginContext(2381, 37, false);
#line 65 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
                                                                                 Write(Url.Action("Manage", "FreezedFamily"));

#line default
#line hidden
            EndContext();
            BeginContext(2418, 1566, true);
            WriteLiteral(@"?freezedFamilyId=' + row.freezedFamilyId + '"">' + row.freezedFamilyTerraNostraId + '</a></div>';
                }
            },
            {
                data: 'ClientName',
                render: function (data, type, row) {
                    return '<div  style=""white-space: nowrap"">' + row.clientName + '</div>';
                }
            },
            {
                data: 'MemberCount',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + row.memberCount + '</div>';
                }
            },
            {
                data: '_CreatedBy',
                render: function (data, type, row) {
                    return '<div><b>' + row._CreatedBy + '</b> em <b>' + row._CreatedDate + '</div>';
                }
            },
            {
                data: 'Accepted',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + (row.acceptedBy == null");
            WriteLiteral(@" ? '<span class=""badge badge-warning"">Pendente</span>' : (row.accepted ? '<span class=""badge badge-success"">Sim</span>' : '<span class=""badge badge-danger"">Não</span>')) + '</div>';
                }
            },
            {
                data: '_AcceptedBy',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + (row.acceptedBy == null ? '-' : ('<div><b>' + row._AcceptedBy + '</b> em <b>' + row._AcceptedDate) + '</div>'  ) + '</div>';
                }
            }
");
            EndContext();
#line 98 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
             if (User.FreezedFamilyCanAccessEdition())
            {
            

#line default
#line hidden
            BeginContext(4073, 135, true);
            WriteLiteral("\r\n            , {\r\n                render: function (data, type, row) {\r\n                    return \'<div style=\"text-align: center\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4208, "\"", 4321, 10);
#line 103 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
WriteAttributeValue("", 4215, Url.Action("Manage", "Invoice"), 4215, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 4247, "?clientId=\'", 4247, 11, true);
            WriteAttributeValue(" ", 4258, "+", 4259, 2, true);
            WriteAttributeValue(" ", 4260, "row.clientId", 4261, 13, true);
            WriteAttributeValue(" ", 4273, "+", 4274, 2, true);
            WriteAttributeValue(" ", 4275, "\'&freezedFamilyId=\'", 4276, 20, true);
            WriteAttributeValue(" ", 4295, "+", 4296, 2, true);
            WriteAttributeValue(" ", 4297, "row.freezedFamilyId", 4298, 20, true);
            WriteAttributeValue(" ", 4317, "+", 4318, 2, true);
            WriteAttributeValue(" ", 4319, "\'", 4320, 2, true);
            EndWriteAttribute();
            BeginContext(4322, 174, true);
            WriteLiteral(" class=\"btn btn-primary\" style=\"padding: 5px;\" title=\"Gerar Novo Orçamento\"><i class=\"simple-icon-calculator\"></i></a></div>\';\r\n                }\r\n            }\r\n            ");
            EndContext();
#line 106 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyIndex\Default.cshtml"
                   
            }

#line default
#line hidden
            BeginContext(4520, 1073, true);
            WriteLiteral(@"            , { data: '_AcceptedDate', visible: false }
            , { data: '_CreatedDate', visible: false }
        ],
        drawCallback: function () {
            _MaskData();
        }
	});

    function _FreezedFamilyIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_FreezedFamilyIndexTable')) {
            _FreezedFamilyIndexDatatables.search($('#_FreezedFamilyIndexSearch').val()).draw();
        }
    }
    $('#_FreezedFamilyIndexSearch').keyup(function () {
        clearTimeout(_FreezedFamilyIndexDoneTypingInterval);
        _FreezedFamilyIndexTypingTimer = setTimeout(_FreezedFamilyIndexDoneTyping, _FreezedFamilyIndexDoneTypingInterval);
    });
    $('#_FreezedFamilyIndexSearch').keydown(function () {
        clearTimeout(_FreezedFamilyIndexDoneTyping);
    });

    $('#FreezedFamilyStatusFilter').change(function() {
        if ($.fn.DataTable.isDataTable('#_FreezedFamilyIndexTable')) {
            _FreezedFamilyIndexDatatables.search($('#_FreezedFamilyIndexSearc");
            WriteLiteral("h\').val()).draw();\r\n        }\r\n    });\r\n</script>");
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