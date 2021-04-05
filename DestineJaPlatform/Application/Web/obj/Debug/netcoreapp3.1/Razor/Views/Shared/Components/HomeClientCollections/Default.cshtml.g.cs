#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40e3cdf96781509040a46c47bca2a564d9adb3cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HomeClientCollections_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HomeClientCollections/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40e3cdf96781509040a46c47bca2a564d9adb3cf", @"/Views/Shared/Components/HomeClientCollections/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HomeClientCollections_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DTO.Home.HomeDemandClientListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "home-client-collections", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
  
    var clientId = await clientServices.GetClientIdByLoggedUser(Context);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style type=""text/css"">
    #home-client-collections-table td, #home-client-collections-table th {
        text-align: center;
    }
</style>

<div class=""row"">
    <div class=""col table-responsive"">
        <table class=""table nowrap table-condensed table-bordered w-100"" id=""home-client-collections-table"">
            <thead>
                <tr>
                    <th colspan=""8"" class=""text-center"">LISTAGEM DE COLETA</th>
                </tr>
                <tr>
                    <th>MTR</th>
                    <th>Data</th>
                    <th>Peso (Kg)</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                 await foreach (var item in homeServices.GetHomeGetNextVisits(clientId, DateTime.Now.AddDays(7)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>-</td>\n                        <td>");
#nullable restore
#line 32 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                       Write(item.ToBrazilianDateFormat());

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Previsão)</td>\n                        <td>-</td>\n                    </tr>\n");
#nullable restore
#line 35 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                 foreach (var item in Model.OrderByDescending(x => x.VisitedDate))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>");
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                       Write(item.DestineJaDemandId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 40 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                       Write(item._VisitedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                       Write(item.Weight.ToWeightPtBr());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientCollections\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40e3cdf96781509040a46c47bca2a564d9adb3cf7999", async() => {
                WriteLiteral(@"
    $(document).ready(function () {
        $('#home-client-collections-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            ordering: false,
        });
    });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public Services.Client.ClientServices clientServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Home.HomeServices homeServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DTO.Home.HomeDemandClientListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
