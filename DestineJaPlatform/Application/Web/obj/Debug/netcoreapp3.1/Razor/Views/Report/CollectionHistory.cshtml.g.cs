#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "320408c75a1d4ee539873f1c9789dccec928da32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_CollectionHistory), @"mvc.1.0.view", @"/Views/Report/CollectionHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"320408c75a1d4ee539873f1c9789dccec928da32", @"/Views/Report/CollectionHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_CollectionHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "client-collection-list", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "report-filter-client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
  DTO.Client.ClientViewModel userClient = null;

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
     if (User.IsClient())
    {
        userClient = await clientServices.GetViewModelByIdAsync(await clientServices.GetClientIdByLoggedUser(Context));
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
   ViewData["Title"] = "Relat??rio - Hist??rico de Coletas"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
             if (User.IsClient())
            {
                var client = await clientServices.GetViewModelByIdAsync(await clientServices.GetClientIdByLoggedUser(Context));
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
           Write(await Html.PartialAsync("Heading.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
                                                          ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    
        <div class=""row"">
            <br />
            <div class=""col-12 text-center"" style=""font-size: 20px !important; color: black;"">
                Relat??rio - Hist??rico de Coletas
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <form id=""client-collection-filter-form"">
");
#nullable restore
#line 33 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
               var filters = new List<ReportFilterModel>() { ReportFilterModel.StartAndEndDateFilter(null, 4) };

                            if (User.IsInRole("Administrator"))
                            {
                                filters.Add(ReportFilterModel.ClientFilter(null, 3));
                            } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
                          Write(await Component.InvokeAsync<Web.ViewComponents.Report.Filter.FilterViewComponent>(filters));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </form>\r\n        <hr />\r\n        <div id=\"client-report-collection-list-view-component\">\r\n            ");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Report.CollectionHistory.IndexViewComponent>());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1721, "\"", 1764, 1);
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
WriteAttributeValue("", 1727, Url.Content("~/assets/js/report.js"), 1727, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "320408c75a1d4ee539873f1c9789dccec928da328205", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "320408c75a1d4ee539873f1c9789dccec928da329316", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script type=""text/javascript"">
       
        function reloadByFilter() {
            if (!validateInputs('client-collection-filter-form') || !validateStartAndEndDate()) return;

            $('#client-report-collection-list-view-component').load('");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
                                                                Write(Url.Action("LoadCollectionHistoryViewComponent"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', $(\'#client-collection-filter-form\').serializeArray());\r\n        }\r\n\r\n        function collectionHistoryDownload(title) {\r\n            collectionHistoryPrintAndDownload(title, \'");
#nullable restore
#line 62 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
                                                 Write(Url.Action("CollectionHistoryDownload", "Report"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n        }\r\n\r\n        function collectionHistoryPrint(title) {\r\n            collectionHistoryPrintAndDownload(title, \'");
#nullable restore
#line 66 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\CollectionHistory.cshtml"
                                                 Write(Url.Action("CollectionHistoryPrint", "Report"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
        }
        function collectionHistoryPrintAndDownload(title, url) {
            var form = $('<form>', { target: ""_blank"", method: ""post"", action: url });
            form.append($('<input>', { type: 'hidden', value: title, name: 'Title' }));

            setFilterIntoForm(form);
            setChartIntoForm(form, [collectionListChart]);
            setTableHeaderIntoForm(form, collectionListTable);

            form.append($('<input>', { type: 'hidden', value: $('[name=""StartDate""]').val(), name: 'StartDateFormated' }));
            form.append($('<input>', { type: 'hidden', value: $('[name=""EndDate""]').val(), name: 'EndDateFormated' }));
            form.append($('<input>', { type: 'hidden', value: $('[name=""ClientId""]').val(), name: 'ClientId' }));

            $('body').append(form);

            form.submit();
            form.remove();
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientServices clientServices { get; private set; }
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
