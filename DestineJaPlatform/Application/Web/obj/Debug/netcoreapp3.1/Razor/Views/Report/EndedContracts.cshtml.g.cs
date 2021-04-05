#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74d5ff51961b4190c49ac60b9347630ac476e469"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_EndedContracts), @"mvc.1.0.view", @"/Views/Report/EndedContracts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d5ff51961b4190c49ac60b9347630ac476e469", @"/Views/Report/EndedContracts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_EndedContracts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "ended-contracts-index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Web.Utils.TagHelperScriptPaste __Web_Utils_TagHelperScriptPaste;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml"
  
    var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

    ViewData["Title"] = "Relatório - Contratos a Expirar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col text-center"" style=""font-size: 20px; color: black;"">
                Relatório - Contratos a Expirar
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <form id=""ended-contracts-filter-form"">
            ");
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Report.Filter.FilterViewComponent>(new List<ReportFilterModel> { ReportFilterModel.StartAndEndMonthFilter(new { startDate, endDate }, 4) }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </form>\n        <hr />\n        <div id=\"ended-contracts-view-component\">\n            ");
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Report.EndedContracts.IndexViewComponent>(new { startDate, endDate  } ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n</div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script");
                BeginWriteAttribute("src", " src=\"", 1020, "\"", 1063, 1);
#nullable restore
#line 27 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml"
WriteAttributeValue("", 1026, Url.Content("~/assets/js/report.js"), 1026, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74d5ff51961b4190c49ac60b9347630ac476e4696365", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n    <script type=\"text/javascript\">\n        function reloadByFilter() {\n            if (!validateInputs(\'ended-contracts-filter-form\') || !validateStartAndEndMonth()) return;\n\n            $(\'#ended-contracts-view-component\').load(\'");
#nullable restore
#line 34 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\EndedContracts.cshtml"
                                                  Write(Url.Action("LoadEndedContractsViewComponent", "Report"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', $(\'#ended-contracts-filter-form\').serializeArray());\n        }\n    </script>\n");
            }
            );
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
