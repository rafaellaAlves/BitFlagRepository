#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4613929daa82f03ccb5192b4c646c6c656adff48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SeasonManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SeasonManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/SeasonManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_SeasonManage_Default))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4613929daa82f03ccb5192b4c646c6c656adff48", @"/Views/Shared/Components/SeasonManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SeasonManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.SeasonViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_SeasonManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 200, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\nfunction _SeasonManageSave() {\r\n    var d = $(\'#_SeasonManageForm\').serializeArray();\r\n    $.post(\'");
            EndContext();
            BeginContext(246, 30, false);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml"
       Write(Url.Action("Manage", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(276, 1319, true);
            WriteLiteral(@"', d, function (data) {
        if (data.hasError) {
            $('#alertErrorSeason').show();
            return;
        }
        _SeasonManageCallBack(data.code);
	});
}

function _SeasonManageValidate() {

    var _SeasonManagehasError = false;
	$('.text-danger').remove();

    if (IsNullOrWhiteSpace($('#_SeasonManageName').val())) {
        $('#_SeasonManageName').after('<div class=""text-danger"">Preencha o nome.</div>');
        _SeasonManagehasError = true;
	}

    if (IsNullOrWhiteSpace($('#_SeasonManageStartDate').val())) {
        $('#_SeasonManageStartDate').after('<div class=""text-danger"">Preencha a data de início.</div>');
        _SeasonManagehasError = true;
	}

    if (IsNullOrWhiteSpace($('#_SeasonManageEndDate').val())) {
        $('#_SeasonManageEndDate').after('<div class=""text-danger"">Preencha a data de término.</div>');
        _SeasonManagehasError = true;
    }
    if (_SeasonManagehasError) {
        $('#_SeasonManageAlertError').show();
    } else {
  ");
            WriteLiteral(@"      $('#_SeasonManageAlertError').hide();
    }

    return (!_SeasonManagehasError);
}

</script>
<div id=""_SeasonManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Atenção!</strong> O Formulário contém erros.
</div>
");
            EndContext();
            BeginContext(1595, 995, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4613929daa82f03ccb5192b4c646c6c656adff486449", async() => {
                BeginContext(1638, 69, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_SeasonManageSeasonId\" name=\"SeasonId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1707, "\"", 1730, 1);
#line 53 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml"
WriteAttributeValue("", 1715, Model.SeasonId, 1715, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1731, 218, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-6\">\r\n            <label class=\"control-label\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_SeasonManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1949, "\"", 1968, 1);
#line 57 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml"
WriteAttributeValue("", 1957, Model.Name, 1957, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1969, 248, true);
                WriteLiteral(" placeholder=\"Nome\">\r\n        </div>\r\n        <div class=\"form-group col-md-3\">\r\n            <label class=\"control-label\">Data de Início*</label>\r\n            <input type=\"text\" class=\"form-control date\" id=\"_SeasonManageStartDate\" name=\"StartDate\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2217, "\"", 2242, 1);
#line 61 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml"
WriteAttributeValue("", 2225, Model._StartDate, 2225, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2243, 255, true);
                WriteLiteral(" placeholder=\"Data de Início\">\r\n        </div>\r\n        <div class=\"form-group col-md-3\">\r\n            <label class=\"control-label\">Data de Término*</label>\r\n            <input type=\"text\" class=\"form-control date\" id=\"_SeasonManageEndDate\" name=\"EndDate\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2498, "\"", 2521, 1);
#line 65 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\SeasonManage\Default.cshtml"
WriteAttributeValue("", 2506, Model._EndDate, 2506, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2522, 61, true);
                WriteLiteral(" placeholder=\"Data de Término\">\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.SeasonViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
