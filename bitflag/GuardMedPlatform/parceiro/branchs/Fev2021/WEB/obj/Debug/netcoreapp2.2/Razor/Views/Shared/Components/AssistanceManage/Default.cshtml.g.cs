#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ade4734726a03edec27d2a973688a98e0b12f51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AssistanceManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AssistanceManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/AssistanceManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_AssistanceManage_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ade4734726a03edec27d2a973688a98e0b12f51", @"/Views/Shared/Components/AssistanceManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AssistanceManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.AssistanceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_AssistanceManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(39, 208, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\nfunction _AssistanceManageSave() {\r\n    var d = $(\'#_AssistanceManageForm\').serializeArray();\r\n    $.post(\'");
            EndContext();
            BeginContext(248, 34, false);
#line 11 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
       Write(Url.Action("Manage", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(282, 1153, true);
            WriteLiteral(@"', d, function (data) {
        if (data.hasError) {
            $('#alertErrorAssistance').show();
            return;
        }
        _AssistanceManageCallBack(data.code);
	});
}

function _AssistanceManageValidate() {

    var _AssistanceManagehasError = false;
	$('.text-danger').remove();

    if (IsNullOrWhiteSpace($('#_AssistanceManageName').val())) {
        $('#_AssistanceManageName').after('<div class=""text-danger"">Preencha o nome.</div>');
        _AssistanceManagehasError = true;
	}

    if (IsNullOrWhiteSpace($('#_AssistanceManageValue').val())) {
        $('#_AssistanceManageValueArea').after('<div class=""text-danger"">Preencha o valor.</div>');
        _AssistanceManagehasError = true;
    }

    if (_AssistanceManagehasError) {
        $('#_AssistanceManageAlertError').show();
    } else {
        $('#_AssistanceManageAlertError').hide();
    }

    return (!_AssistanceManagehasError);
}

</script>
<div id=""_AssistanceManageAlertError"" class=""alert alert-dange");
            WriteLiteral("r fade show text-center\" role=\"alert\" style=\"display: none;\">\r\n    <strong>Atenção!</strong> O Formulário contém erros.\r\n</div>\r\n");
            EndContext();
            BeginContext(1435, 1223, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ade4734726a03edec27d2a973688a98e0b12f516080", async() => {
                BeginContext(1482, 81, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_AssistanceManageAssistanceId\" name=\"AssistanceId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1563, "\"", 1590, 1);
#line 49 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 1571, Model.AssistanceId, 1571, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1591, 222, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-8\">\r\n            <label class=\"control-label\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_AssistanceManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1813, "\"", 1832, 1);
#line 53 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 1821, Model.Name, 1821, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1833, 454, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Valor*</label>
            <div class=""input-group mb-3"" id=""_AssistanceManageValueArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">R$</span>
                </div>
                <input type=""text"" class=""form-control money"" id=""_AssistanceManageValue"" name=""_Value""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2287, "\"", 2308, 1);
#line 61 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 2295, Model._Value, 2295, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2309, 283, true);
                WriteLiteral(@" placeholder=""Valor"">
            </div>
        </div>
        <div class=""form-group col-md-12"">
            <label class=""control-label"">Descrição</label>
            <textarea class=""form-control"" id=""_AssistanceManageDescription"" name=""Description"" placeholder=""Descrição"">");
                EndContext();
                BeginContext(2593, 17, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
                                                                                                                   Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(2610, 41, true);
                WriteLiteral("</textarea>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.AssistanceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
