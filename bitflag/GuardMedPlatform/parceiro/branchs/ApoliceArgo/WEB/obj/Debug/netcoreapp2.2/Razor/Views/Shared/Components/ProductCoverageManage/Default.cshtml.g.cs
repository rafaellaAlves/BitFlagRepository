#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52df9d01a9824a90664cc1b8cc78d73217a0d47d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductCoverageManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductCoverageManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductCoverageManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductCoverageManage_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52df9d01a9824a90664cc1b8cc78d73217a0d47d", @"/Views/Shared/Components/ProductCoverageManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductCoverageManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.ProductCoverageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_ProductCoverageManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2014, true);
            WriteLiteral(@"
<style type=""text/css"">
    .margin-top-text-danger {
        margin-top: -15px;
    }
</style>

<script type=""text/javascript"">
    _MaskData();
</script>

<script type=""text/javascript"">

function _ProductCoverageManageValidate() {

	var hasError = false;
	$('#_ProductCoverageManageForm .text-danger').remove();

    if (IsNullOrWhiteSpace($('#_ProductCoverageManageName').val())) {
        $('#_ProductCoverageManageName').after('<div class=""text-danger"">Preencha o Nome.</div>');
        hasError = true;
    }

    if (IsNullOrWhiteSpace($('#_ProductCoverageManageTaxes').val())) {
        $('#_ProductCoverageManageTaxesArea').after('<div class=""text-danger margin-top-text-danger"">Preencha a taxa.</div>');
        hasError = true;
    }

    if ($('#_ProductCoverageManageIsOptional').val() == 'false' && IsNullOrWhiteSpace($('#_ProductCoverageManageMinimum').val())) {
        $('#_ProductCoverageManageMinimumArea').after('<div class=""text-danger margin-top-text-danger"">Preencha o v");
            WriteLiteral(@"alor mínimo.</div>');
        hasError = true;
    }

    if (IsNullOrWhiteSpace($('#_ProductCoverageManageMaximum').val())) {
        $('#_ProductCoverageManageMaximumArea').after('<div class=""text-danger margin-top-text-danger"">Preencha o valor máximo.</div>');
        hasError = true;
    }

    if ($('#_ProductCoverageManageIsBasic').val() == 'false' && IsNullOrWhiteSpace($('#_ProductCoverageManageBasicLimit').val())) {
        $('#_ProductCoverageManageBasicLimitArea').after('<div class=""text-danger margin-top-text-danger"">Preencha o limite básico.</div>');
        hasError = true;
    }

    if (hasError) {
        $('#_ProductCoverageManageAlertError').show();
    }
    else {
        $('#_ProductCoverageManageForm .text-danger').remove();
        $('#_ProductCoverageManageAlertError').hide();
    }

	return (!hasError);
}

    function _ProductCoverageManageSave() {
	var d = $('#_ProductCoverageManageForm').serializeArray();
        $.post('");
            EndContext();
            BeginContext(2059, 39, false);
#line 58 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
           Write(Url.Action("Manage", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(2098, 160, true);
            WriteLiteral("\', d, function (data) {\r\n        $(\'#_ProductCoverageManageProductCoverageId\').val(data);\r\n        _ProductCoverageManageCallBack(data);\r\n\t});\r\n}\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(2258, 5359, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52df9d01a9824a90664cc1b8cc78d73217a0d47d8044", async() => {
                BeginContext(2340, 288, true);
                WriteLiteral(@"
    <div id=""_ProductCoverageManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
        <strong>Atenção!</strong> O Formulário contém erros.
    </div>
    <input type=""hidden"" id=""_ProductCoverageManageProductId"" name=""ProductId""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2628, "\"", 2652, 1);
#line 69 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 2636, Model.ProductId, 2636, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2653, 99, true);
                WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"_ProductCoverageManageProductCoverageId\" name=\"ProductCoverageId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2752, "\"", 2784, 1);
#line 70 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 2760, Model.ProductCoverageId, 2760, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2785, 226, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-6\">\r\n            <label class=\"control-label\">Nome</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_ProductCoverageManageName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3011, "\"", 3030, 1);
#line 74 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 3019, Model.Name, 3019, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3031, 227, true);
                WriteLiteral(" placeholder=\"Nome\">\r\n        </div>\r\n\r\n        <div class=\"form-group col-md-3\">\r\n            <label>Basico</label>\r\n            <select class=\"form-control\" name=\"IsBasic\" id=\"_ProductCoverageManageIsBasic\">\r\n                ");
                EndContext();
                BeginContext(3258, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52df9d01a9824a90664cc1b8cc78d73217a0d47d10765", async() => {
                    BeginContext(3279, 3, true);
                    WriteLiteral("Sim");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3291, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(3309, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52df9d01a9824a90664cc1b8cc78d73217a0d47d12244", async() => {
                    BeginContext(3340, 3, true);
                    WriteLiteral("Não");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3352, 25, true);
                WriteLiteral("\r\n            </select>\r\n");
                EndContext();
#line 83 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
             if (Model.ProductCoverageId.HasValue)
            {
                if (Model.IsBasic)
                {

#line default
#line hidden
                BeginContext(3499, 252, true);
                WriteLiteral("                    <script type=\"text/javascript\">\r\n                        $(\'#_ProductCoverageManageIsBasic\').val(\'true\');\r\n                        $(\'#_ProductCoverageManageBasicLimit\').attr(\'disabled\', \'disabled\');\r\n                    </script>\r\n");
                EndContext();
#line 91 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(3811, 159, true);
                WriteLiteral("                    <script type=\"text/javascript\">\r\n                        $(\'#_ProductCoverageManageIsBasic\').val(\'false\');\r\n                    </script>\r\n");
                EndContext();
#line 97 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
                    if (bool.Parse(ViewData["IsBasicUsed"].ToString()))
                    {

#line default
#line hidden
                BeginContext(4066, 187, true);
                WriteLiteral("                        <script type=\"text/javascript\">\r\n                            $(\'#_ProductCoverageManageIsBasic\').attr(\'disabled\', \'disabled\');\r\n                        </script>\r\n");
                EndContext();
#line 102 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
                    }
                }
            }
            else if (bool.Parse(ViewData["IsBasicUsed"].ToString()))
            {

#line default
#line hidden
                BeginContext(4395, 234, true);
                WriteLiteral("                <script type=\"text/javascript\">\r\n                    $(\'#_ProductCoverageManageIsBasic\').val(\'false\');\r\n                    $(\'#_ProductCoverageManageIsBasic\').attr(\'disabled\', \'disabled\');\r\n                </script>\r\n");
                EndContext();
#line 111 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
            }

#line default
#line hidden
                BeginContext(4644, 233, true);
                WriteLiteral("        </div>\r\n        <div class=\"form-group col-md-3\">\r\n            <label class=\"control-label\">Opcional</label>\r\n            <select class=\"form-control\" id=\"_ProductCoverageManageIsOptional\" name=\"IsOptional\">\r\n                ");
                EndContext();
                BeginContext(4877, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52df9d01a9824a90664cc1b8cc78d73217a0d47d17101", async() => {
                    BeginContext(4898, 3, true);
                    WriteLiteral("Sim");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4910, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(4928, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52df9d01a9824a90664cc1b8cc78d73217a0d47d18580", async() => {
                    BeginContext(4959, 3, true);
                    WriteLiteral("Não");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4971, 322, true);
                WriteLiteral(@"
            </select>
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"">Taxa</label>
            <div class=""input-group mb-3"" id=""_ProductCoverageManageTaxesArea"">
                <input type=""text"" class=""form-control"" id=""_ProductCoverageManageTaxes"" name=""_Taxes""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5293, "\"", 5314, 1);
#line 123 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 5301, Model._Taxes, 5301, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5315, 546, true);
                WriteLiteral(@" placeholder=""Taxa"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"">%</span>
                </div>
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <label>Valor mínimo</label>
            <div class=""input-group mb-3"" id=""_ProductCoverageManageMinimumArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">R$</span>
                </div>
                <input class=""form-control money""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5861, "\"", 5884, 1);
#line 135 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 5869, Model._Minimum, 5869, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5885, 484, true);
                WriteLiteral(@" id=""_ProductCoverageManageMinimum"" name=""_Minimum"" type=""text"" placeholder=""Valor mínimo"" />
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <label>Valor máximo</label>
            <div class=""input-group mb-3"" id=""_ProductCoverageManageMaximumArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">R$</span>
                </div>
                <input class=""form-control money""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6369, "\"", 6392, 1);
#line 144 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 6377, Model._Maximum, 6377, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6393, 445, true);
                WriteLiteral(@" name=""_Maximum"" id=""_ProductCoverageManageMaximum"" type=""text"" placeholder=""Valor máximo"" />
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"">Limite Básico</label>
            <div class=""input-group mb-3"" id=""_ProductCoverageManageBasicLimitArea"">
                <input type=""text"" class=""form-control percent2"" id=""_ProductCoverageManageBasicLimit"" name=""_BasicLimit""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6838, "\"", 6864, 1);
#line 150 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 6846, Model._BasicLimit, 6846, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6865, 400, true);
                WriteLiteral(@" placeholder=""Limite Básico"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"">%</span>
                </div>
            </div>
        </div>
        <div class=""col-md-12"">
            <label class=""control-label"">Franquias</label>
            <input type=""text"" class=""form-control"" id=""_ProductCoverageManageFranquias"" name=""Franquias""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 7265, "\"", 7289, 1);
#line 158 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
WriteAttributeValue("", 7273, Model.Franquias, 7273, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(7290, 261, true);
                WriteLiteral(@" placeholder=""Franquias"">
        </div>
        <div class=""col-md-12"">
            <label class=""control-label"">Descrição</label>
            <textarea class=""form-control"" id=""_ProductCoverageManageDescription"" name=""Description"" placeholder=""Descrição"">");
                EndContext();
                BeginContext(7552, 17, false);
#line 162 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductCoverageManage\Default.cshtml"
                                                                                                                        Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(7569, 41, true);
                WriteLiteral("</textarea>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7617, 371, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    $('#_ProductCoverageManageIsBasic').change(function () { 
        if ($('#_ProductCoverageManageIsBasic').val() == 'true') {
            $('#_ProductCoverageManageBasicLimit').attr('disabled', 'disabled');
        } else {
            $('#_ProductCoverageManageBasicLimit').removeAttr('disabled');
        }
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.ProductCoverageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
