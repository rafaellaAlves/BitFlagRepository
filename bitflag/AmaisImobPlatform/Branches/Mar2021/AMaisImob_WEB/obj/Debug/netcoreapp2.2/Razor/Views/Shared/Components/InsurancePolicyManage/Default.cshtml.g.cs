#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_InsurancePolicyManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/InsurancePolicyManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/InsurancePolicyManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_InsurancePolicyManage_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e", @"/Views/Shared/Components/InsurancePolicyManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InsurancePolicyManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.InsurancePolicyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_InsurancePolicyManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
  
    var companyOwnerTypes = new AMaisImob_WEB.BLL.CompanyOwnerTypeFunctions(context).GetData();
    var personTypeId = companyOwnerTypes.Single(x => x.ExternalCode == "PERSON").CompanyOwnerTypeId;
    //var companyTypeId = companyOwnerTypes.Single(x => x.ExternalCode == "COMPANY");

#line default
#line hidden
            BeginContext(409, 218, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\nfunction _InsurancePolicyManageSave() {\r\n    var d = $(\'#_InsurancePolicyManageForm\').serializeArray();\r\n    $.post(\'");
            EndContext();
            BeginContext(628, 39, false);
#line 17 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
       Write(Url.Action("Manage", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(667, 1572, true);
            WriteLiteral(@"', d, function (data) {
        if (data.hasError) {
            $('#alertErrorInsurancePolicy').show();
            alert(data.message);
            return;
        }
        _InsurancePolicyManageCallBack(data.code);
	});
}

function _InsurancePolicyManageValidate() {

    var _InsurancePolicyManagehasError = false;
	$('.text-danger').remove();

    if (IsNullOrWhiteSpace($('#_InsurancePolicyManageInsurancePolicyNumber').val())) {
        $('#_InsurancePolicyManageInsurancePolicyNumber').after('<div class=""text-danger"">Preencha o número da apólice.</div>');
        _InsurancePolicyManagehasError = true;
	}

    if (IsNullOrWhiteSpace($('#_InsurancePolicyManageStartDate').val())) {
        $('#_InsurancePolicyManageStartDate').after('<div class=""text-danger"">Preencha o início da vigência.</div>');
        _InsurancePolicyManagehasError = true;
	}

    if (IsNullOrWhiteSpace($('#_InsurancePolicyManageEndDate').val())) {
        $('#_InsurancePolicyManageEndDate').after('<div class=""t");
            WriteLiteral(@"ext-danger"">Preencha o término da vigência.</div>');
        _InsurancePolicyManagehasError = true;
    }

    if (_InsurancePolicyManagehasError) {
        $('#_InsurancePolicyManageAlertError').show();
    } else {
        $('#_InsurancePolicyManageAlertError').hide();
    }

    return (!_InsurancePolicyManagehasError);
}

</script>
<div id=""_InsurancePolicyManageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Atenção!</strong> O Formulário contém erros.
</div>
");
            EndContext();
            BeginContext(2239, 2959, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e7384", async() => {
                BeginContext(2291, 96, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_InsurancePolicyManageInsurancePolicyId\" name=\"InsurancePolicyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2387, "\"", 2419, 1);
#line 61 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 2395, Model.InsurancePolicyId, 2395, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2420, 33, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n");
                EndContext();
#line 63 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
         if (!User.IsInRole("Administrator"))
        {

#line default
#line hidden
                BeginContext(2511, 66, true);
                WriteLiteral("            <input type=\"hidden\" id=\"CorretoraId\" name=\"companyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2577, "\"", 2601, 1);
#line 65 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 2585, Model.CompanyId, 2585, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2602, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 66 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(2643, 193, true);
                WriteLiteral("            <div class=\"form-group col-md-6\">\r\n                <label class=\"control-label\">Corretora*</label>\r\n                <select id=\"CorretoraId\" name=\"companyId\" class=\"form-control\">\r\n");
                EndContext();
#line 72 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                     foreach (var corretora in (List<AMaisImob_DB.Models.Company>)ViewData["Corretoras"])
                    {
                        string corretoraName = corretora.CompanyOwnerTypeId == personTypeId ? corretora.FirstName + " " + corretora.LastName : corretora.NomeFantasia;
                        if (Model.CompanyId == corretora.CompanyId)
                        {

#line default
#line hidden
                BeginContext(3230, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(3258, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e10539", async() => {
                    BeginContext(3307, 13, false);
#line 77 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                                       Write(corretoraName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 77 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                WriteLiteral(corretora.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                BeginContext(3329, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 78 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                            continue;
                        }

#line default
#line hidden
                BeginContext(3397, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(3421, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e13429", async() => {
                    BeginContext(3461, 13, false);
#line 80 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                          Write(corretoraName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 80 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                            WriteLiteral(corretora.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3483, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 81 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                    }

#line default
#line hidden
                BeginContext(3508, 47, true);
                WriteLiteral("                </select>\r\n            </div>\r\n");
                EndContext();
#line 84 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
        }

#line default
#line hidden
                BeginContext(3566, 177, true);
                WriteLiteral("        <div class=\"form-group col-md-6\">\r\n            <label class=\"control-label\">Produto*</label>\r\n            <select id=\"ProductId\" name=\"ProductId\" class=\"form-control\">\r\n");
                EndContext();
#line 88 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                 foreach (var product in (List<AMaisImob_DB.Models.Product>)ViewData["Products"])
                {
                    if (Model.ProductId == product.ProductId)
                    {

#line default
#line hidden
                BeginContext(3947, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(3971, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e16976", async() => {
                    BeginContext(4018, 12, false);
#line 92 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                                 Write(product.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 92 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                            WriteLiteral(product.ProductId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                BeginContext(4039, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 93 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                        continue;
                    }

#line default
#line hidden
                BeginContext(4099, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(4119, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fd88783d72b56fa5064a3d5cec6e2d688e1cd4e19841", async() => {
                    BeginContext(4157, 12, false);
#line 95 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                    Write(product.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 95 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                        WriteLiteral(product.ProductId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4178, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 96 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                }

#line default
#line hidden
                BeginContext(4199, 313, true);
                WriteLiteral(@"            </select>
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Nº Apólice*</label>
            <input type=""text"" class=""form-control"" id=""_InsurancePolicyManageInsurancePolicyNumber"" name=""InsurancePolicyNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4512, "\"", 4548, 1);
#line 103 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 4520, Model.InsurancePolicyNumber, 4520, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4549, 262, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Início da Vigência*</label>
            <input type=""text"" class=""form-control date"" id=""_InsurancePolicyManageStartDate"" name=""_StartDate""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4811, "\"", 4836, 1);
#line 107 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 4819, Model._StartDate, 4819, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4837, 269, true);
                WriteLiteral(@" placeholder=""Data de Início"">
        </div>
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Término da Vigência*</label>
            <input type=""text"" class=""form-control date"" id=""_InsurancePolicyManageEndDate"" name=""_EndDate""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5106, "\"", 5129, 1);
#line 111 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 5114, Model._EndDate, 5114, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5130, 61, true);
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
        public AMaisImob_DB.Models.AMaisImob_HomologContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.InsurancePolicyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
