#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\ProductFamilyManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac0069b0066320e76c3fa9ac0fbdac494561d2ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductFamilyManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductFamilyManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductFamilyManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductFamilyManage_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac0069b0066320e76c3fa9ac0fbdac494561d2ba", @"/Views/Shared/Components/ProductFamilyManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductFamilyManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.ProductFamilyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_ProductFamilyManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(52, 224, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n    function _ProductFamilyManageSave() {\r\n        var d = $(\'#_ProductFamilyManageForm\').serializeArray();\r\n        $.post(\'");
            EndContext();
            BeginContext(277, 37, false);
#line 10 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\ProductFamilyManage\Default.cshtml"
           Write(Url.Action("Manage", "ProductFamily"));

#line default
#line hidden
            EndContext();
            BeginContext(314, 736, true);
            WriteLiteral(@"', d, function (data) {
            if (data.hasError) {
                $('#alertErrorProductFamily').show();
                return;
            }
            _ProductFamilyManageCallBack(data.code);
	    });
    }

    function _ProductFamilyManageValidate() {
        var r = validateInputs('_ProductFamilyManageForm');

        if (!r) {
            $('#_ProductFamilyManageAlertError').show();
        } else {
            $('#_ProductFamilyManageAlertError').hide();
        }

        return r;
    }

</script>
<div id=""_ProductFamilyManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Aten????o!</strong> O Formul??rio cont??m erros.
</div>
");
            EndContext();
            BeginContext(1050, 757, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac0069b0066320e76c3fa9ac0fbdac494561d2ba5895", async() => {
                BeginContext(1100, 90, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_ProductFamilyManageProductFamilyId\" name=\"ProductFamilyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1190, "\"", 1220, 1);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\ProductFamilyManage\Default.cshtml"
WriteAttributeValue("", 1198, Model.ProductFamilyId, 1198, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1221, 235, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-12\">\r\n            <label class=\"control-label\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control required\" id=\"_ProductFamilyManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1456, "\"", 1475, 1);
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\ProductFamilyManage\Default.cshtml"
WriteAttributeValue("", 1464, Model.Name, 1464, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1476, 265, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-12"">
            <label class=""control-label"">Descri????o</label>
            <textarea class=""form-control"" id=""_ProductFamilyManageDescription"" name=""Description"" placeholder=""Descri????o"">");
                EndContext();
                BeginContext(1742, 17, false);
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\ProductFamilyManage\Default.cshtml"
                                                                                                                      Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(1759, 41, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.ProductFamilyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
