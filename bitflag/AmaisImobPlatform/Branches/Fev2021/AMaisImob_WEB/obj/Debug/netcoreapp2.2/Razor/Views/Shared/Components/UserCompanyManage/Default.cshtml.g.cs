#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dd67bc9078a835e4ea3402fac060112da748e16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserCompanyManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserCompanyManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/UserCompanyManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_UserCompanyManage_Default))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dd67bc9078a835e4ea3402fac060112da748e16", @"/Views/Shared/Components/UserCompanyManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserCompanyManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.UserCompanyManageViewModel>
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
            BeginContext(56, 333, true);
            WriteLiteral(@"

<div id=""_UserCompanyManageAlertError"" class=""alert alert-danger fade show text-center"" style=""display:none;"">
    <b>Houve um erro ao salvar os dados, tente novamente.</b>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <label>Usuários:</label>
        <select class=""form-control"" id=""Usuarios"" multiple>
");
            EndContext();
#line 12 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
             foreach (var user in (List<AMaisImob_DB.Models.User>)ViewData["Users"])
            {
                if (Model.UserIds.Contains(user.Id))
                {

#line default
#line hidden
            BeginContext(563, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(583, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dd67bc9078a835e4ea3402fac060112da748e164496", async() => {
                BeginContext(621, 36, false);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                                                    Write(user.FirstName + " " + user.LastName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                        WriteLiteral(user.Id);

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
            BeginContext(667, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                    continue;
                }

#line default
#line hidden
            BeginContext(719, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(735, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dd67bc9078a835e4ea3402fac060112da748e167213", async() => {
                BeginContext(764, 36, false);
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                                       Write(user.FirstName + " " + user.LastName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                    WriteLiteral(user.Id);

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
            BeginContext(810, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(827, 241, true);
            WriteLiteral("        </select>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#Usuarios\').select2({\r\n        allowClear: true,\r\n        escapeMarkup: function (markup) { return markup; },\r\n        placeholder: \"Selecione os usuários para ");
            EndContext();
            BeginContext(1069, 145, false);
#line 29 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                                            Write(Html.Raw(string.IsNullOrWhiteSpace(Model.Company.RazaoSocial)?Model.Company.FirstName + " " + Model.Company.LastName : Model.Company.RazaoSocial));

#line default
#line hidden
            EndContext();
            BeginContext(1214, 127, true);
            WriteLiteral("\",\r\n        \"language\": {\r\n            \"noResults\": function () {\r\n                return \'Nenhum usuário encontrado, <a href=\"");
            EndContext();
            BeginContext(1342, 31, false);
#line 32 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                                                       Write(Url.Action("Manage", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(1373, 184, true);
            WriteLiteral("\">clique aqui</a> para criar novos.\';\r\n            }\r\n        },\r\n        closeOnSelect: false\r\n    });\r\n\r\n    function _UserCompanyManageSave() {\r\n        $.ajax({\r\n            url: \'");
            EndContext();
            BeginContext(1558, 35, false);
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
             Write(Url.Action("Manage", "UserCompany"));

#line default
#line hidden
            EndContext();
            BeginContext(1593, 94, true);
            WriteLiteral("\',\r\n            type: \'POST\',\r\n            datatype: \'JSON\',\r\n            data: { companyId: \'");
            EndContext();
            BeginContext(1688, 23, false);
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\UserCompanyManage\Default.cshtml"
                           Write(Model.Company.CompanyId);

#line default
#line hidden
            EndContext();
            BeginContext(1711, 392, true);
            WriteLiteral(@"', userIds: $('#Usuarios').val() },
            success: function (data) {
                if (data.hasError) {
                    $('#_UserCompanyManageAlertError').show();
                } else {
                    $('#_UserCompanyManageAlertError').hide();
                    _UserCompanyManageCallBack(data.code);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.UserCompanyManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
