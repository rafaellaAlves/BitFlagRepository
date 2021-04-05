#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8882f5c95ea624a8d346e1f8e420bfb4530a8e4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HomeClientResidueTable_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HomeClientResidueTable/Default.cshtml")]
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
#nullable restore
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8882f5c95ea624a8d346e1f8e420bfb4530a8e4d", @"/Views/Shared/Components/HomeClientResidueTable/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HomeClientResidueTable_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "home-demand-residue", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 6 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
  
    var clientId = await clientServices.GetClientIdByLoggedUser(Context);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <style type=""text/css"">
        #home-demand-residue-table td, #home-demand-residue-table th {
            font-size: 11px;
            padding-top: 10px;
            padding-bottom: 10px;
        }

        #home-demand-residue-table_wrapper .dataTables_scroll {
            overflow-x: auto;
        }
    </style>

<div class=""row"">
	<div class=""col table-responsive"">
		<table class=""table nowrap table-condensed table-bordered w-100 tablesizeline"" id=""home-demand-residue-table"">
			<thead>
				<tr>
					<th colspan=""8"" class=""text-center"">RESÍDUOS MAIS ENVIADOS</th>
				</tr>
				<tr>
					<th>Peso</th>
					<th>Resíduos</th>
					<th>Família</th>
				</tr>
			</thead>
			<tbody>
");
#nullable restore
#line 35 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
                 await foreach (var item in homeServices.GetHomeDemandClientResidueCollectedViewModel(clientId))
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<tr>\n\t\t\t\t\t\t<td>");
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
                       Write(item._Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t\t\t\t<td>");
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
                       Write(item.ResidueName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t\t\t\t<td>");
#nullable restore
#line 40 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
                       Write(item.ResidueFamilyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t\t\t</tr>\n");
#nullable restore
#line 42 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\HomeClientResidueTable\Default.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\n\t\t</table>\n\t</div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8882f5c95ea624a8d346e1f8e420bfb4530a8e4d7187", async() => {
                WriteLiteral(@"
    $(document).ready(function () {
        $('#home-demand-residue-table').DataTable({
            serverSide: false,
            proccessing: true,
            searching: true,
            lengthChange: false,
            dom: 'tip',
            ordering: false,
            scrollY: '190px',
            scrollX: true,
            paging: false,
            info: false
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591