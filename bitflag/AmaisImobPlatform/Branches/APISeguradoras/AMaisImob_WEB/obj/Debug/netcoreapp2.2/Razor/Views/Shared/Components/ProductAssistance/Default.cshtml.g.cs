#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa85c8a758467eae70023089fdcb8074c1d1919f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductAssistance_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductAssistance/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ProductAssistance/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ProductAssistance_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa85c8a758467eae70023089fdcb8074c1d1919f", @"/Views/Shared/Components/ProductAssistance/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductAssistance_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.ProductAssistanceManageViewModel>
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
            BeginContext(62, 343, true);
            WriteLiteral(@"

<div id=""_ProductAssistanceManageAlertError"" class=""alert alert-danger fade show text-center"" style=""display:none;"">
    <b>Houve um erro ao salvar os dados, tente novamente.</b>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <label>Assistências:</label>
        <select class=""form-control"" id=""Usuarios"" multiple>
");
            EndContext();
#line 12 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
             foreach (var assistance in (List<AMaisImob_DB.Models.Assistance>)ViewData["Assistances"])
            {
                if (Model.AssistanceIds.Contains(assistance.AssistanceId))
                {

#line default
#line hidden
            BeginContext(619, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(639, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa85c8a758467eae70023089fdcb8074c1d1919f4587", async() => {
                BeginContext(693, 15, false);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                                                                    Write(assistance.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                        WriteLiteral(assistance.AssistanceId);

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
            BeginContext(718, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                    continue;
                }

#line default
#line hidden
            BeginContext(770, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(786, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa85c8a758467eae70023089fdcb8074c1d1919f7336", async() => {
                BeginContext(831, 15, false);
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                                                       Write(assistance.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                    WriteLiteral(assistance.AssistanceId);

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
            BeginContext(856, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(873, 256, true);
            WriteLiteral(@"        </select>
    </div>
</div>

<script type=""text/javascript"">
    $('#Usuarios').select2({
        allowClear: true,
        escapeMarkup: function (markup) { return markup; },
        placeholder: ""Selecione as assistências para o produto: ");
            EndContext();
            BeginContext(1130, 28, false);
#line 29 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                                                           Write(Html.Raw(Model.Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1158, 132, true);
            WriteLiteral("\",\r\n        \"language\": {\r\n            \"noResults\": function () {\r\n                return \'Nenhuma assistência encontrado, <a href=\"");
            EndContext();
            BeginContext(1291, 34, false);
#line 32 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                                                            Write(Url.Action("Manage", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(1325, 190, true);
            WriteLiteral("\">clique aqui</a> para criar novos.\';\r\n            }\r\n        },\r\n        closeOnSelect: false\r\n    });\r\n\r\n    function _ProductAssistanceManageSave() {\r\n        $.ajax({\r\n            url: \'");
            EndContext();
            BeginContext(1516, 49, false);
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
             Write(Url.Action("ProductAssistanceSave", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(1565, 94, true);
            WriteLiteral("\',\r\n            type: \'POST\',\r\n            datatype: \'JSON\',\r\n            data: { productId: \'");
            EndContext();
            BeginContext(1660, 23, false);
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\ProductAssistance\Default.cshtml"
                           Write(Model.Product.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(1683, 416, true);
            WriteLiteral(@"', assistanceIds: $('#Usuarios').val() },
            success: function (data) {
                if (data.hasError) {
                    $('#_ProductAssistanceManageAlertError').show();
                } else {
                    $('#_ProductAssistanceManageAlertError').hide();
                    _ProductAssistanceManageCallBack(data.code);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.ProductAssistanceManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
