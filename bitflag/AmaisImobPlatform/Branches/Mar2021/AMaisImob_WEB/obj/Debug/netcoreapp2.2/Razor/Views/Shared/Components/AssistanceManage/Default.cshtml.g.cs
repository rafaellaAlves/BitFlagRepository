#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef79ab97cae3b0f8bd28ca6868c2515d70f926c6"
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef79ab97cae3b0f8bd28ca6868c2515d70f926c6", @"/Views/Shared/Components/AssistanceManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AssistanceManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.AssistanceViewModel>
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
            BeginContext(49, 218, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n    function _AssistanceManageSave() {\r\n        var d = $(\'#_AssistanceManageForm\').serializeArray();\r\n        $.post(\'");
            EndContext();
            BeginContext(268, 34, false);
#line 10 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
           Write(Url.Action("Manage", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(302, 715, true);
            WriteLiteral(@"', d, function (data) {
            if (data.hasError) {
                $('#alertErrorAssistance').show();
                return;
            }
            _AssistanceManageCallBack(data.code);
	    });
    }

    function _AssistanceManageValidate() {
        var r = validateInputs('_AssistanceManageForm');

        if (!r) {
            $('#_AssistanceManageAlertError').show();
        } else {
            $('#_AssistanceManageAlertError').hide();
        }

        return r;
    }

</script>
<div id=""_AssistanceManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Atenção!</strong> O Formulário contém erros.
</div>
");
            EndContext();
            BeginContext(1017, 1509, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef79ab97cae3b0f8bd28ca6868c2515d70f926c65836", async() => {
                BeginContext(1064, 81, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_AssistanceManageAssistanceId\" name=\"AssistanceId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1145, "\"", 1172, 1);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 1153, Model.AssistanceId, 1153, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1173, 231, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-7\">\r\n            <label class=\"control-label\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control required\" id=\"_AssistanceManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1404, "\"", 1423, 1);
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 1412, Model.Name, 1412, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1424, 458, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"">Valor*</label>
            <div class=""input-group"" id=""_AssistanceManageValueArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">R$</span>
                </div>
                <input type=""text"" class=""form-control required money"" id=""_AssistanceManageValue"" name=""_Value""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1882, "\"", 1903, 1);
#line 48 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 1890, Model._Value, 1890, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1904, 252, true);
                WriteLiteral(" placeholder=\"Valor\">\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group col-md-2\">\r\n            <label class=\"control-label\">Código da Exportação*</label>\r\n            <input type=\"text\" class=\"form-control required\" name=\"ReportCode\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2156, "\"", 2181, 1);
#line 53 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
WriteAttributeValue("", 2164, Model.ReportCode, 2164, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2182, 278, true);
                WriteLiteral(@" placeholder=""Código da Exportação"">
        </div>
        <div class=""form-group col-md-12"">
            <label class=""control-label"">Descrição</label>
            <textarea class=""form-control"" id=""_AssistanceManageDescription"" name=""Description"" placeholder=""Descrição"">");
                EndContext();
                BeginContext(2461, 17, false);
#line 57 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\AssistanceManage\Default.cshtml"
                                                                                                                   Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(2478, 41, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.AssistanceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
