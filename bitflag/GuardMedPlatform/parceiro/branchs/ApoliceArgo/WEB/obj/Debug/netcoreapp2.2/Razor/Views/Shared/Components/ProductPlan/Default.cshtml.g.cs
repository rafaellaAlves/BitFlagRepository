#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "854ea49c45a0ce3bea26e668c3a455faec85e8b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductPlan_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductPlan/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductPlan/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductPlan_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"854ea49c45a0ce3bea26e668c3a455faec85e8b4", @"/Views/Shared/Components/ProductPlan/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductPlan_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.ProductPlanManageViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 322, true);
            WriteLiteral(@"

<div id=""_ProductPlanAlertError"" class=""alert alert-danger fade show text-center"" style=""display:none;"">
    <b>Houve um erro ao salvar os dados, tente novamente.</b>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <label>Planos:</label>
        <select class=""form-control"" id=""Plans"" multiple>
");
            EndContext();
#line 12 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
             foreach (var plan in (List<DB.Models.Plan>)ViewData["Plans"])
            {
                if (Model.PlanIds.Contains(plan.PlanId))
                {

#line default
#line hidden
            BeginContext(536, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(548, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "854ea49c45a0ce3bea26e668c3a455faec85e8b44215", async() => {
                BeginContext(590, 9, false);
#line 16 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                                                Write(plan.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 16 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                WriteLiteral(plan.PlanId);

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
            BeginContext(609, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                    continue;
                }

#line default
#line hidden
            BeginContext(661, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(673, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "854ea49c45a0ce3bea26e668c3a455faec85e8b46877", async() => {
                BeginContext(706, 9, false);
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                                       Write(plan.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                WriteLiteral(plan.PlanId);

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
            BeginContext(725, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(742, 236, true);
            WriteLiteral("        </select>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#Plans\').select2({\r\n        allowClear: true,\r\n        escapeMarkup: function (markup) { return markup; },\r\n        placeholder: \"Selecione os planos para ");
            EndContext();
            BeginContext(979, 28, false);
#line 29 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                                          Write(Html.Raw(Model.Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1007, 125, true);
            WriteLiteral("\",\r\n        \"language\": {\r\n            \"noResults\": function () {\r\n                return \'Nenhum plano encontrado, <a href=\"");
            EndContext();
            BeginContext(1133, 28, false);
#line 32 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                                                     Write(Url.Action("Manage", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(1161, 185, true);
            WriteLiteral("\">clique aqui</a> para criar novos planos.\';\r\n            }\r\n        },\r\n        closeOnSelect: false\r\n    });\r\n\r\n    function _ProductPlanSave() {\r\n        $.ajax({\r\n            url: \'");
            EndContext();
            BeginContext(1347, 40, false);
#line 40 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
             Write(Url.Action("ProductPlanSave", "Product"));

#line default
#line hidden
            EndContext();
            BeginContext(1387, 94, true);
            WriteLiteral("\',\r\n            type: \'POST\',\r\n            datatype: \'JSON\',\r\n            data: { productId: \'");
            EndContext();
            BeginContext(1482, 23, false);
#line 43 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\ProductPlan\Default.cshtml"
                           Write(Model.Product.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(1505, 371, true);
            WriteLiteral(@"', planIds: $('#Plans').val() },
            success: function (data) {
                if (data.hasError) {
                    $('#_ProductPlanAlertError').show();
                } else {
                    $('#_ProductPlanAlertError').hide();
                    _ProductPlanCallBack(data.code);
                }
            }
        });
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.ProductPlanManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
