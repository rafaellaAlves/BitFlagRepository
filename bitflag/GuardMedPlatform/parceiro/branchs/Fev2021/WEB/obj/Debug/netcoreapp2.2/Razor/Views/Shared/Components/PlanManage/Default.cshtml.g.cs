#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b91785123b54cecf5b21bdd923c12dcf02e63207"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PlanManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PlanManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/PlanManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_PlanManage_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b91785123b54cecf5b21bdd923c12dcf02e63207", @"/Views/Shared/Components/PlanManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_PlanManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.PlanViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_PlanManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(33, 216, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\nfunction _PlanManageSave() {\r\n    ShowLoading();\r\n    var d = $(\'#_PlanManageForm\').serializeArray();\r\n    $.post(\'");
            EndContext();
            BeginContext(250, 28, false);
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml"
       Write(Url.Action("Manage", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(278, 757, true);
            WriteLiteral(@"', d, function (data) {
            _PlanManageCallBack(data);
	});
}

function _PlanManageValidate() {
    var _PlanManagehasError = false;
    $('.text-danger').remove();

    if (IsNullOrWhiteSpace($('#_PlanManageName').val())) {
        $('#_PlanManageName').after('<div class=""text-danger"">Preencha o nome.</div>');
        _PlanManagehasError = true;
	}

    if (_PlanManagehasError) {
        $('#_PlanManageAlertError').show();
    } else {
        $('#_PlanManageAlertError').hide();
    }

    return (!_PlanManagehasError);
}

</script>
<div id=""_PlanManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Atenção!</strong> O Formulário contém erros.
</div>
");
            EndContext();
            BeginContext(1035, 884, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b91785123b54cecf5b21bdd923c12dcf02e632075587", async() => {
                BeginContext(1076, 69, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_PlanManageProductId\" name=\"ProductId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1145, "\"", 1169, 1);
#line 40 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml"
WriteAttributeValue("", 1153, Model.ProductId, 1153, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1170, 66, true);
                WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"_PlanManagePlanId\" name=\"PlanId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1236, "\"", 1257, 1);
#line 41 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml"
WriteAttributeValue("", 1244, Model.PlanId, 1244, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1258, 244, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-12\">\r\n            <label class=\"control-label\" for=\"_PlanManageFirstName\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_PlanManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1502, "\"", 1521, 1);
#line 45 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml"
WriteAttributeValue("", 1510, Model.Name, 1510, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1522, 331, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-12"">
            <label class=""control-label"" for=""_PlanManageEmail"">Descrição</label>
            <textarea type=""text"" class=""form-control"" id=""_PlanManageDescription"" name=""Description"" placeholder=""Descrição"">");
                EndContext();
                BeginContext(1854, 17, false);
#line 51 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\PlanManage\Default.cshtml"
                                                                                                                         Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(1871, 41, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.PlanViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
