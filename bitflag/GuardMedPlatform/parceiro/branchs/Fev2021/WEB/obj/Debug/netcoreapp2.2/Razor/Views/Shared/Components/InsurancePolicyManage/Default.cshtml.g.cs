#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c6f1eb496137ce12bc079ee736ea66a1b774d08"
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c6f1eb496137ce12bc079ee736ea66a1b774d08", @"/Views/Shared/Components/InsurancePolicyManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InsurancePolicyManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.InsurancePolicyViewModel>
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
#line 3 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
  
    var companyOwnerTypes = new WEB.BLL.CompanyOwnerTypeFunctions(context).GetData();
    var personTypeId = companyOwnerTypes.Single(x => x.ExternalCode == "PERSON").CompanyOwnerTypeId;
    //var companyTypeId = companyOwnerTypes.Single(x => x.ExternalCode == "COMPANY");

#line default
#line hidden
            BeginContext(379, 218, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    _MaskData();\r\n</script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\nfunction _InsurancePolicyManageSave() {\r\n    var d = $(\'#_InsurancePolicyManageForm\').serializeArray();\r\n    $.post(\'");
            EndContext();
            BeginContext(598, 39, false);
#line 17 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
       Write(Url.Action("Manage", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(637, 1572, true);
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
            BeginContext(2209, 2992, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c6f1eb496137ce12bc079ee736ea66a1b774d087147", async() => {
                BeginContext(2261, 96, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_InsurancePolicyManageInsurancePolicyId\" name=\"InsurancePolicyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2357, "\"", 2389, 1);
#line 61 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 2365, Model.InsurancePolicyId, 2365, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2390, 33, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n");
                EndContext();
#line 63 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
         if (!User.IsInRole("Administrator"))
        {

#line default
#line hidden
                BeginContext(2481, 66, true);
                WriteLiteral("            <input type=\"hidden\" id=\"CorretoraId\" name=\"companyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2547, "\"", 2571, 1);
#line 65 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 2555, Model.CompanyId, 2555, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2572, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(2613, 92, true);
                WriteLiteral("            <div class=\"form-group col-md-6\">\r\n                <label class=\"control-label\">");
                EndContext();
                BeginContext(2706, 61, false);
#line 70 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                        Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(2767, 92, true);
                WriteLiteral("*</label>\r\n                <select id=\"CorretoraId\" name=\"companyId\" class=\"form-control\">\r\n");
                EndContext();
#line 72 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                     foreach (var corretora in (List<DB.Models.Company>)ViewData["Corretoras"])
                    {
                        string corretoraName = corretora.CompanyOwnerTypeId == personTypeId ? corretora.FirstName + " " + corretora.LastName : corretora.NomeFantasia;
                        if (Model.CompanyId == corretora.CompanyId)
                        {

#line default
#line hidden
                BeginContext(3243, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(3271, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c6f1eb496137ce12bc079ee736ea66a1b774d0810744", async() => {
                    BeginContext(3320, 13, false);
#line 77 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                                       Write(corretoraName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 77 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
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
                BeginContext(3342, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 78 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                            continue;
                        }

#line default
#line hidden
                BeginContext(3410, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(3434, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c6f1eb496137ce12bc079ee736ea66a1b774d0813625", async() => {
                    BeginContext(3474, 13, false);
#line 80 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                          Write(corretoraName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 80 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
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
                BeginContext(3496, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 81 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                    }

#line default
#line hidden
                BeginContext(3521, 47, true);
                WriteLiteral("                </select>\r\n            </div>\r\n");
                EndContext();
#line 84 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
        }

#line default
#line hidden
                BeginContext(3579, 177, true);
                WriteLiteral("        <div class=\"form-group col-md-6\">\r\n            <label class=\"control-label\">Produto*</label>\r\n            <select id=\"ProductId\" name=\"ProductId\" class=\"form-control\">\r\n");
                EndContext();
#line 88 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                 foreach (var product in (List<DB.Models.Product>)ViewData["Products"])
                {
                    if (Model.ProductId == product.ProductId)
                    {

#line default
#line hidden
                BeginContext(3950, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(3974, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c6f1eb496137ce12bc079ee736ea66a1b774d0817147", async() => {
                    BeginContext(4021, 12, false);
#line 92 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                                 Write(product.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 92 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
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
                BeginContext(4042, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 93 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                        continue;
                    }

#line default
#line hidden
                BeginContext(4102, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(4122, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c6f1eb496137ce12bc079ee736ea66a1b774d0820003", async() => {
                    BeginContext(4160, 12, false);
#line 95 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                                                    Write(product.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 95 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
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
                BeginContext(4181, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 96 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
                }

#line default
#line hidden
                BeginContext(4202, 313, true);
                WriteLiteral(@"            </select>
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Nº Apólice*</label>
            <input type=""text"" class=""form-control"" id=""_InsurancePolicyManageInsurancePolicyNumber"" name=""InsurancePolicyNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4515, "\"", 4551, 1);
#line 103 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 4523, Model.InsurancePolicyNumber, 4523, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4552, 262, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Início da Vigência*</label>
            <input type=""text"" class=""form-control date"" id=""_InsurancePolicyManageStartDate"" name=""_StartDate""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4814, "\"", 4839, 1);
#line 107 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 4822, Model._StartDate, 4822, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4840, 269, true);
                WriteLiteral(@" placeholder=""Data de Início"">
        </div>
        <div class=""form-group col-md-4"">
            <label class=""control-label"">Término da Vigência*</label>
            <input type=""text"" class=""form-control date"" id=""_InsurancePolicyManageEndDate"" name=""_EndDate""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5109, "\"", 5132, 1);
#line 111 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Shared\Components\InsurancePolicyManage\Default.cshtml"
WriteAttributeValue("", 5117, Model._EndDate, 5117, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5133, 61, true);
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
        public DB.Models.Insurance_HomologContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.InsurancePolicyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591