#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fb647d457dc47bd8a4d653a57612019b199d536"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_InvoiceIndex_Default), @"mvc.1.0.view", @"/Views/Shared/Components/InvoiceIndex/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/InvoiceIndex/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_InvoiceIndex_Default))]
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
#line 4 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fb647d457dc47bd8a4d653a57612019b199d536", @"/Views/Shared/Components/InvoiceIndex/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InvoiceIndex_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(86, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(106, 21, true);
            WriteLiteral("<div class=\"row\">\r\n\r\n");
            EndContext();
#line 7 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
     if (User.InvoiceCanAccessEdition())
    {

#line default
#line hidden
            BeginContext(176, 241, true);
            WriteLiteral("        <div class=\"col-md-7\">\r\n            <div class=\"input-group mb-3\">\r\n                \r\n                <input id=\"_InvoiceIndexSearch\" type=\"text\" class=\"form-control\" placeholder=\"Procurar...\" />\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(441, 395, true);
            WriteLiteral(@"        <div class=""col-md-9"">
            <div class=""input-group mb-3"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text""><i class=""simple-icon-magnifier""></i></span>
                </div>
                <input id=""_InvoiceIndexSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
            </div>
        </div>
");
            EndContext();
#line 26 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(843, 106, true);
            WriteLiteral("\r\n    <div class=\"col-md-3\">\r\n        <select id=\"InvoiceStatusFilter\" class=\"form-control\">\r\n            ");
            EndContext();
            BeginContext(949, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fb647d457dc47bd8a4d653a57612019b199d5365898", async() => {
                BeginContext(966, 15, true);
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
            BeginContext(990, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 31 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
             foreach (var item in invoiceStatusFunctions.GetData())
            {
                if (Model.HasValue && Model == item.InvoiceStatusId)
                {

#line default
#line hidden
            BeginContext(1165, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1185, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fb647d457dc47bd8a4d653a57612019b199d5367775", async() => {
                BeginContext(1233, 9, false);
#line 35 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                                                              Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 35 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                       WriteLiteral(item.InvoiceStatusId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1251, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 36 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1313, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1333, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fb647d457dc47bd8a4d653a57612019b199d53610582", async() => {
                BeginContext(1372, 9, false);
#line 39 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                                                     Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 39 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                       WriteLiteral(item.InvoiceStatusId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1390, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 40 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                }

            }

#line default
#line hidden
            BeginContext(1428, 31, true);
            WriteLiteral("        </select>\r\n    </div>\r\n");
            EndContext();
#line 45 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
     if (User.InvoiceCanAccessEdition())
    {

#line default
#line hidden
            BeginContext(1508, 46, true);
            WriteLiteral("        <div class=\"col-md-2\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1554, "\"", 1593, 1);
#line 48 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
WriteAttributeValue("", 1561, Url.Action("Manage", "Invoice"), 1561, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1594, 106, true);
            WriteLiteral(" class=\"btn btn-success pull-right w-100\"><i class=\"simple-icon-plus\"></i>&nbsp;Novo</a>\r\n        </div>\r\n");
            EndContext();
#line 50 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(1707, 827, true);
            WriteLiteral(@"</div>
<hr />
<div class=""table-responsive"">
    <table id=""_InvoiceIndexTable"" class=""table table-striped table-bordered"" >
        <thead>
            <tr>
                <th style=""white-space: nowrap"">&nbsp;</th>
                <th>Cliente</th>
                <th>Data</th>
                <th>Status</th>
                <th>Valor Total</th>
                <th>Imposto</th>
                <th>Valor Final</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>

<script type=""text/javascript"">
    var _InvoiceIndexTypingTimer;
    var _InvoiceIndexDoneTypingInterval = 500;
    var _InvoiceIndexDatatables = $('#_InvoiceIndexTable').DataTable({
		proccessing: true,
		serverSide: true,
		searching: false,
		lengthChange: false,
	
		ajax: {
            url: '");
            EndContext();
            BeginContext(2535, 29, false);
#line 80 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
             Write(Url.Action("List", "Invoice"));

#line default
#line hidden
            EndContext();
            BeginContext(2564, 398, true);
            WriteLiteral(@"',
            data: function (d) {
                d.invoiceStatusFilter = $('#InvoiceStatusFilter').val()
            },
			type: 'POST'
        },
        order: [[0, 'desc']],
        columns: [
            {
                data: 'InvoiceId',
                render: function (data, type, row) {
                    return '<div class=""text-center""><a title=""Editar Registro"" href=""");
            EndContext();
            BeginContext(2963, 31, false);
#line 91 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\InvoiceIndex\Default.cshtml"
                                                                                 Write(Url.Action("Manage", "Invoice"));

#line default
#line hidden
            EndContext();
            BeginContext(2994, 2317, true);
            WriteLiteral(@"?invoiceId=' + row.invoiceId + '"">' + row.invoiceTerraNostraId + '</a></div>';
                }
            },
            {
                data: 'ClientName',
                
                render: function (data, type, row) {
                    return row.clientName;
                }
            },
            {
                data: '_CreatedDate',
                render: function (data, type, row) {
                    return row._CreatedDate;
                }
            },
            {
                data: 'StatusName',
                render: function (data, type, row) {
                    console.log(row);
                    return row.statusName == null ? 'Novo' : row.statusName;
                }
            },
            {
                data: 'Cost',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + (!row.cost ? '-' : 'R$ ' + row._Cost) + '</div>';
                }
            },
            {
 ");
            WriteLiteral(@"               data: 'Tax',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + (!row.tax ? '-' : row._Tax + '%') + '</div>';
                }
            },
            {
                data: 'GrandTotal',
                render: function (data, type, row) {
                    return '<div class=""text-center"">' + (!row.grandTotal ? '-' : 'R$ ' + row._GrandTotal) + '</div>';
                }
            },
            
        ]
	});
    function _InvoiceIndexDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_InvoiceIndexTable')) {
            _InvoiceIndexDatatables.search($('#_InvoiceIndexSearch').val()).draw();
        }
    }
    $('#_InvoiceIndexSearch').keyup(function () {
        clearTimeout(_InvoiceIndexDoneTypingInterval);
        _InvoiceIndexTypingTimer = setTimeout(_InvoiceIndexDoneTyping, _InvoiceIndexDoneTypingInterval);
    });
    $('#_InvoiceIndexSearch').keydown(function () {
        clearTimeout(_In");
            WriteLiteral(@"voiceIndexDoneTyping);
    });
    $('#InvoiceStatusFilter').on('change', function() {
        if ($.fn.DataTable.isDataTable('#_InvoiceIndexTable')) {
            _InvoiceIndexDatatables.search($('#_InvoiceIndexTable').val()).draw();
        }
    });
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FUNCTIONS.Invoice.InvoiceStatusFunctions invoiceStatusFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int?> Html { get; private set; }
    }
}
#pragma warning restore 1591