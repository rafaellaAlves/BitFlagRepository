#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac63e20ff82c40d7f2dba5b2d2fed38389216e9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DemandClientSOSelection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/DemandClientSOSelection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac63e20ff82c40d7f2dba5b2d2fed38389216e9d", @"/Views/Shared/Components/DemandClientSOSelection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DemandClientSOSelection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntityViewMode<List<ApplicationDbContext.Models.Service>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "demand-client-so-selection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<table class=\"table table-condensed table-striped table-bordered\" id=\"demand-client-so-selection-table\">\n\t<thead>\n\t\t<tr>\n\t\t\t<td></td>\n\t\t\t<td>Código</td>\n\t\t\t<td>Status</td>\n\t\t</tr>\n\t</thead>\n\t<tbody>\n");
#nullable restore
#line 14 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
         foreach (var item in Model.Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\n\t\t\t\t<td><input type=\"checkbox\" data-selection-service-id=\"");
#nullable restore
#line 17 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
                                                                 Write(item.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" /></td>\n\t\t\t\t<td>");
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
               Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t\t<td>");
#nullable restore
#line 19 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
                Write((await serviceStatusServices.GetDataByIdAsync(item.ServiceStatusId)).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t</tr>\n");
#nullable restore
#line 21 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\n</table>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac63e20ff82c40d7f2dba5b2d2fed38389216e9d6254", async() => {
                WriteLiteral(@"
	var orderServicesSelected = null;

	$('#demand-client-so-selection-table input[type=""checkbox""][data-selection-service-id]').click(function () {
		var checked = this.checked;

		$('#demand-client-so-selection-table input[type=""checkbox""]').each(function (i, e) {
			e.checked = false;
		});

		this.checked = checked;
		orderServicesSelected = $(this).data('selection-service-id');
	});
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 25 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\DemandClientSOSelection\Default.cshtml"
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
        public Services.Service.ServiceStatusServices serviceStatusServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntityViewMode<List<ApplicationDbContext.Models.Service>>> Html { get; private set; }
    }
}
#pragma warning restore 1591