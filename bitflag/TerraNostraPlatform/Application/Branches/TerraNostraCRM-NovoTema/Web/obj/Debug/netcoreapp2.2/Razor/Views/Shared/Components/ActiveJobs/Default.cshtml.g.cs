#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bd43dfa1d92eb81f227ce24d3249d2c3bb565bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ActiveJobs_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ActiveJobs/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ActiveJobs/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ActiveJobs_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bd43dfa1d92eb81f227ce24d3249d2c3bb565bd", @"/Views/Shared/Components/ActiveJobs/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ActiveJobs_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            BeginContext(52, 29, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 81, "\"", 206, 2);
            WriteAttributeValue("", 89, "col-md-", 89, 7, true);
            WriteAttributeValue("", 96, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 4 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                        if (User.IsInRole("Administrator") || User.IsInRole("Contact Manager")) {

#line default
#line hidden
                BeginContext(176, 1, true);
                WriteLiteral("9");
                EndContext();
#line 4 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                                                                               }else{

#line default
#line hidden
                BeginContext(196, 2, true);
                WriteLiteral("12");
                EndContext();
#line 4 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                                                                                                    }

#line default
#line hidden
                PopWriter();
            }
            ), 96, 110, false);
            EndWriteAttribute();
            BeginContext(207, 173, true);
            WriteLiteral(">\r\n        <div class=\"input-group mb-3\">\r\n\r\n            <input id=\"search-table\" type=\"text\" class=\"form-control\" placeholder=\"Procurar...\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 10 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
     if (User.IsInRole("Administrator") || User.IsInRole("Contact Manager"))
    {

#line default
#line hidden
            BeginContext(465, 131, true);
            WriteLiteral("        <div class=\"col-md-3\">\r\n            <select id=\"ResponsibleId\" class=\"form-control\" name=\"ResponsibleId\">\r\n                ");
            EndContext();
            BeginContext(596, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bd43dfa1d92eb81f227ce24d3249d2c3bb565bd5866", async() => {
                BeginContext(604, 21, true);
                WriteLiteral("Todos os Responsáveis");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(634, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 15 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                 foreach (var item in userFunctions.GetDataByRole("Administrator", "Salesman"))
                {

#line default
#line hidden
            BeginContext(752, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(772, 113, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bd43dfa1d92eb81f227ce24d3249d2c3bb565bd7477", async() => {
                BeginContext(846, 14, false);
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                                                        Write(item.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(860, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(862, 13, false);
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                                                                        Write(item.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(875, 1, true);
                WriteLiteral(" ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                       Write(item.FirstName);

#line default
#line hidden
            WriteLiteral(" ");
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                       Write(item.LastName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-full-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 17 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                                       WriteLiteral(item.Id);

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
            BeginContext(885, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(906, 39, true);
            WriteLiteral("            </select>\r\n        </div>\r\n");
            EndContext();
#line 21 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"

    }

#line default
#line hidden
            BeginContext(954, 784, true);
            WriteLiteral(@"</div>
<hr />
<div class=""table-responsive"">
    <table class=""table table-striped table-bordered"" id=""table-active-jobs"">
        <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Cliente</th>
                <th>Serviço</th>
                <th>Etapa</th>
                <th>Responsável</th>
                <th>Última Interação</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">

    var _ActiveJobsTypingTimer;
    var _ActiveJobsDoneTypingInterval = 1000;

    var tableActiveJobs = $('#table-active-jobs').DataTable({
		proccessing: true,
        serverSide: true,
        searching: false,
		lengthChange: false,
		dom: 'tip',
		ajax: {
            url: '");
            EndContext();
            BeginContext(1739, 40, false);
#line 52 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
             Write(Url.Action("GetActiveJobs", "Workbench"));

#line default
#line hidden
            EndContext();
            BeginContext(1779, 368, true);
            WriteLiteral(@"',
            data: function (d) {
                d.responsibleId = $('#ResponsibleId').val()
            },
			type: 'POST'
        },
        order: [[0, 'desc']],
        columns: [
            {
                data: 'JobTerraNostraId',
                render: function (data, type, row) {
                    return '<a title=""Editar Registro"" href=""");
            EndContext();
            BeginContext(2148, 35, false);
#line 63 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ActiveJobs\Default.cshtml"
                                                        Write(Url.Action("GetSteps", "Workbench"));

#line default
#line hidden
            EndContext();
            BeginContext(2183, 1864, true);
            WriteLiteral(@"?jobId=' +  row.jobId + '"">' + (row.jobTerraNostraId != null ? row.jobTerraNostraId + '/' + row._CreatedDateYear : ""[SEM NÚMERO]"")  + '</a>';
                }
            },
            {
                data: 'ClientName',
                render: function (data, type, row) {
                    return row.clientName;
                }
            }, {
                data: 'JobDescription',
                render: function (data, type, row) {
                    return row.jobDescription;
                }
            }, {
                data: 'StepDescription',
                render: function (data, type, row) {
                    return !row.jobInteractionViewModel ? '-' : row.jobInteractionViewModel.stepDescription;
                }
            }, {
                data: 'UserName',
                render: function (data, type, row) {
                    return !row.jobInteractionViewModel ? '-' : row.jobInteractionViewModel.userName;
                }
            }, {
       ");
            WriteLiteral(@"         data: 'JobInteractionCreatedDate',
                render: function (data, type, row) {
                    return !row.jobInteractionViewModel ? '-' : row.jobInteractionViewModel._CreatedDate;
                }
            }
        ]
    });

    function _ActiveJobsDoneTyping() {
        if ($.fn.DataTable.isDataTable('#table-active-jobs')) {
            tableActiveJobs.search($('#search-table').val()).draw();
        }
    }
    $('#search-table').keyup(function () {
        clearTimeout(_ActiveJobsDoneTypingInterval);
        _ActiveJobsTypingTimer = setTimeout(_ActiveJobsDoneTyping, _ActiveJobsDoneTypingInterval);
    });
    $('#search-table').keydown(function () {
        clearTimeout(_ActiveJobsDoneTyping);
    });


    $('#ResponsibleId').on('change', _ActiveJobsDoneTyping);
</script>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FUNCTIONS.User.UserFunctions userFunctions { get; private set; }
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