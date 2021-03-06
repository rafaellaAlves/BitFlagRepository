#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35448302885ec4f458f1c12d1cff1097fdc45049"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ServiceTypeManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ServiceTypeManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ServiceTypeManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ServiceTypeManage_Default))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35448302885ec4f458f1c12d1cff1097fdc45049", @"/Views/Shared/Components/ServiceTypeManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ServiceTypeManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.ServiceType.ServiceTypeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_ServiceTypeManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(45, 936, true);
            WriteLiteral(@"
<script type=""text/javascript"">
function _ServiceTypeManageValidate() {
	var hasError = false;
	$('#_ServiceTypeManageForm .text-danger').remove();

    if (IsNullOrWhiteSpace($('#_ServiceTypeManageName').val())) {
        $('#_ServiceTypeManageName').after('<div class=""text-danger"">Preencha o nome.</div>');
        hasError = true;
    }
    if (IsNullOrWhiteSpace($('#_ServiceTypeManageExternalCode').val())) {
        $('#_ServiceTypeManageExternalCode').after('<div class=""text-danger"">Preencha o c??digo.</div>');
        hasError = true;
    }

    if (hasError) {
        $('#_ServiceTypeManageAlertErrorServiceType').show();
    }
    else {
        $('#_ServiceTypeManageForm .text-danger').remove();
        $('#_ServiceTypeManageAlertErrorServiceType').hide();
    }

	return (!hasError);
}

function _ServiceTypeManageSave() {
var d = $('#_ServiceTypeManageForm').serializeArray();
    $.post('");
            EndContext();
            BeginContext(982, 35, false);
#line 30 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml"
       Write(Url.Action("Manage", "ServiceType"));

#line default
#line hidden
            EndContext();
            BeginContext(1017, 626, true);
            WriteLiteral(@"', d, function (data) {
        console.log(data);
        if (data.hasError) {
            if (data.data != null) $('#_ServiceTypeManage' + data.data).after('<div class=""text-danger"">' + data.message + '</div>'); //data.data contem o nome do campo que ocorreu o erro
            else alert('Houve um erro ao salvar a indica????o.');

            $('#_ServiceTypeManageForm .text-danger').show();
            $('#_ServiceTypeManageAlertErrorServiceType').show();
    } else {
        $('#_ServiceTypeManageServiceTypeId').val(data.code);
            _ServiceTypeManageCallBack(data.code);
    }
});
}
</script>

");
            EndContext();
            BeginContext(1643, 1308, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35448302885ec4f458f1c12d1cff1097fdc450496722", async() => {
                BeginContext(1721, 299, true);
                WriteLiteral(@"
    <div id=""_ServiceTypeManageAlertErrorServiceType"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
        <strong>Aten????o!</strong> O Formul??rio cont??m erros.
    </div>
    <input type=""hidden"" id=""_ServiceTypeManageServiceTypeId"" name=""ServiceTypeId""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2020, "\"", 2048, 1);
#line 50 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml"
WriteAttributeValue("", 2028, Model.ServiceTypeId, 2028, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2049, 223, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-8\">\r\n            <label class=\"control-label\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_ServiceTypeManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2272, "\"", 2291, 1);
#line 54 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml"
WriteAttributeValue("", 2280, Model.Name, 2280, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2292, 246, true);
                WriteLiteral(" placeholder=\"Nome\">\r\n        </div>\r\n        <div class=\"form-group col-md-4\">\r\n            <label class=\"control-label\">C??digo*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_ServiceTypeManageExternalCode\" name=\"ExternalCode\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2538, "\"", 2565, 1);
#line 58 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml"
WriteAttributeValue("", 2546, Model.ExternalCode, 2546, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2566, 309, true);
                WriteLiteral(@" placeholder=""C??digo"">
        </div>
    </div>
    <div class=""row"">
        <div class=""form-group col-md-12"">
            <label class=""control-label"">Descri????o</label>
            <textarea class=""form-control"" id=""_ServiceTypeManageDescription"" name=""Description"" rows=""4"" placeholder=""Descri????o"">");
                EndContext();
                BeginContext(2876, 27, false);
#line 64 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ServiceTypeManage\Default.cshtml"
                                                                                                                             Write(Html.Raw(Model.Description));

#line default
#line hidden
                EndContext();
                BeginContext(2903, 41, true);
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2951, 66, true);
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.ServiceType.ServiceTypeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
