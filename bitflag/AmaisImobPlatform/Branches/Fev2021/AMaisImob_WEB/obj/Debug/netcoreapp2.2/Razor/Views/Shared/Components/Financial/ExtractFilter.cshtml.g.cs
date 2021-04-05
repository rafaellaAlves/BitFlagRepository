#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f09a2d01b2fad7b01d9e9013adec0c82137af94b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Financial_ExtractFilter), @"mvc.1.0.view", @"/Views/Shared/Components/Financial/ExtractFilter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Financial/ExtractFilter.cshtml", typeof(AspNetCore.Views_Shared_Components_Financial_ExtractFilter))]
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
#line 8 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
using AMaisImob_WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f09a2d01b2fad7b01d9e9013adec0c82137af94b", @"/Views/Shared/Components/Financial/ExtractFilter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Financial_ExtractFilter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.Charge.FinancialFilterViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("charge-filter-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "charge-filter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AMaisImob_WEB.Helpers.Javascript.TagHelperScriptCut __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(351, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(382, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
  
    var realEstateTypeId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
    var realEstateAgencyTypeId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
    var user = await userManager.GetUserAsync(User);

    int? realEstateId = null, realEstateAgencyId = null;
    if (User.IsInRealEstate())
    {
        var realEstate = companyFunctions.GetDataByID(userCompanyFunctions.GetDataByUserId(user.Id).First().CompanyId);
        realEstateId = realEstate.CompanyId;
        realEstateAgencyId = realEstate.ParentCompanyId;
    }
    else if (User.IsInRole("Corretor"))
    {
        realEstateAgencyId = companyFunctions.GetDataByID(userCompanyFunctions.GetDataByUserId(user.Id).First().CompanyId).CompanyId;
    }

#line default
#line hidden
            BeginContext(1172, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1174, 4274, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b6863", async() => {
                BeginContext(1204, 25, true);
                WriteLiteral("\r\n    <div class=\"row\">\r\n");
                EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
         if (User.IsInRole("Administrator"))
        {

#line default
#line hidden
                BeginContext(1286, 431, true);
                WriteLiteral(@"            <div class=""col"">
                <div class=""input-group"" id=""financial-filter-real-estate-agency-area"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Corretora</span>
                    </div>
                    <select class=""form-control"" name=""RealEstateAgencyId"" onchange=""hideRealEstateOptionsByRealEstateAgency();"">
                        ");
                EndContext();
                BeginContext(1717, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b8064", async() => {
                    BeginContext(1734, 9, true);
                    WriteLiteral("Selecione");
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
                BeginContext(1752, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 39 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                         foreach (var item in companyFunctions.GetDataAsNoTracking(x => x.CompanyTypeId == realEstateAgencyTypeId && !x.IsDeleted && x.IsActive))
                        {
                            if (Model.RealEstateAgencyId == item.CompanyId)
                            {

#line default
#line hidden
                BeginContext(2052, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2084, 109, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b10146", async() => {
                    BeginContext(2127, 56, false);
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                                     Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                   WriteLiteral(item.CompanyId);

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
                BeginContext(2193, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                continue;
                            }


#line default
#line hidden
                BeginContext(2271, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(2299, 100, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b13072", async() => {
                    BeginContext(2333, 56, false);
#line 47 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                        Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 47 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                               WriteLiteral(item.CompanyId);

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
                BeginContext(2399, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 48 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                        }

#line default
#line hidden
                BeginContext(2428, 75, true);
                WriteLiteral("                    </select>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 52 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(2539, 58, true);
                WriteLiteral("            <input type=\"hidden\" name=\"RealEstateAgencyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2597, "\"", 2624, 1);
#line 55 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
WriteAttributeValue("", 2605, realEstateAgencyId, 2605, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2625, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 56 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
        }

#line default
#line hidden
                BeginContext(2641, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 57 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
         if (!User.IsInRealEstate())
        {

#line default
#line hidden
                BeginContext(2690, 366, true);
                WriteLiteral(@"            <div class=""col"">
                <div class=""input-group"" id=""financial-filter-real-estate-area"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Imobiliária</span>
                    </div>
                    <select class=""form-control"" name=""RealEstateId"">
                        ");
                EndContext();
                BeginContext(3056, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b17538", async() => {
                    BeginContext(3073, 9, true);
                    WriteLiteral("Selecione");
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
                BeginContext(3091, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 66 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                         foreach (var item in companyFunctions.GetDataAsNoTracking(x => x.CompanyTypeId == realEstateTypeId && x.ParentCompanyId.HasValue && !x.IsDeleted && x.IsActive))
                        {
                            if (realEstateAgencyId == item.CompanyId || Model.RealEstateId == item.CompanyId)
                            {

#line default
#line hidden
                BeginContext(3449, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(3481, 148, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b19679", async() => {
                    BeginContext(3563, 56, false);
#line 70 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                                                                            Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#line 70 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                            WriteLiteral(item.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 70 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                                                    Write(item.ParentCompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-parent-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3629, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 71 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                continue;
                            }


#line default
#line hidden
                BeginContext(3707, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(3735, 139, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b23270", async() => {
                    BeginContext(3808, 56, false);
#line 74 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                                                               Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 74 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                               WriteLiteral(item.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 74 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                                                       Write(item.ParentCompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-parent-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3874, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 75 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                        }

#line default
#line hidden
                BeginContext(3903, 75, true);
                WriteLiteral("                    </select>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 79 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(4014, 52, true);
                WriteLiteral("            <input type=\"hidden\" name=\"RealEstateId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4066, "\"", 4087, 1);
#line 82 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
WriteAttributeValue("", 4074, realEstateId, 4074, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4088, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 83 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
        }

#line default
#line hidden
                BeginContext(4104, 385, true);
                WriteLiteral(@"        <div class=""col"">
            <div class=""input-group"" id=""financial-filter-date-area"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">Data</span>
                </div>
                <input type=""hidden"" name=""StartDate"" />
                <input class=""form-control monthYear"" name=""_StartDate"" placeholder=""Data""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4489, "\"", 4528, 1);
#line 90 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
WriteAttributeValue("", 4497, $"{Model.StartDate:MM/yyyy}", 4497, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4529, 314, true);
                WriteLiteral(@" />
                <div class=""input-group-append"">
                    <span class=""input-group-text""><i class=""fas fa-calendar""></i></span>
                </div>
                <input type=""hidden"" name=""EndDate"" />
                <input class=""form-control monthYear"" name=""_EndDate"" placeholder=""Data""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4843, "\"", 4880, 1);
#line 95 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
WriteAttributeValue("", 4851, $"{Model.EndDate:MM/yyyy}", 4851, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4881, 25, true);
                WriteLiteral(" />\r\n            </div>\r\n");
                EndContext();
                BeginContext(4990, 451, true);
                WriteLiteral(@"        </div>
        <div class=""col-auto"" style=""min-width: 100px;"">
            <a class=""btn btn-primary w-100"" href=""javascript:set12months()""><i class=""fa fa-filter""></i>&nbsp;Últimos 12 meses</a>
        </div>
        <div class=""col-auto"" style=""min-width: 100px;"">
            <button class=""btn btn-primary w-100"" type=""button"" id=""charge-filter-button""><i class=""fa fa-filter""></i>&nbsp;Filtrar</button>
        </div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5448, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(5452, 3435, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f09a2d01b2fad7b01d9e9013adec0c82137af94b31117", async() => {
                BeginContext(5511, 1044, true);
                WriteLiteral(@"
    function hideRealEstateOptionsByRealEstateAgency(notClear) {
        $.each($('[name=""RealEstateId""] option'), function (i, e) {
            $(e).hide();
            if ($(e).data('parent-id') != $('[name=""RealEstateAgencyId""]').val() && !IsNullOrWhiteSpace($(e).val())) return;

            $(e).show();
        });

        if (notClear != true) $('[name=""RealEstateId""]').val('');
    }

    $(document).ready(function () { hideRealEstateOptionsByRealEstateAgency(true); });

    $('#charge-filter-button').click(tryReloadChargeList);

    function tryReloadChargeList(callback) {
        $('[name=""StartDate""]').val('');
        $('[name=""EndDate""]').val('');

        if (!IsNullOrWhiteSpace($('[name=""_StartDate""]').val())) {
            var date = moment($('[name=""_StartDate""]').val(), 'MM/YYYY')._d;
            var now = new Date();

            if (date.getYear() > now.getYear() || (date.getYear() == now.getYear() && date.getMonth() >= now.getMonth())) {
                $('[name=""");
                WriteLiteral("_StartDate\"]\').val(\'");
                EndContext();
                BeginContext(6557, 39, false);
#line 133 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                          Write($"{DateTime.Now.AddMonths(-1):MM/yyyy}");

#line default
#line hidden
                EndContext();
                BeginContext(6597, 523, true);
                WriteLiteral(@"');
                date = moment($('[name=""_StartDate""]').val(), 'MM/YYYY')._d;
            }

            $('[name=""StartDate""]').val(date.toISOString());
        }

        if (!IsNullOrWhiteSpace($('[name=""_EndDate""]').val())) {
            var date = moment($('[name=""_EndDate""]').val(), 'MM/YYYY')._d;
            var now = new Date();

            if (date.getYear() > now.getYear() || (date.getYear() == now.getYear() && date.getMonth() >= now.getMonth())) {
                $('[name=""_EndDate""]').val('");
                EndContext();
                BeginContext(7122, 39, false);
#line 145 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                        Write($"{DateTime.Now.AddMonths(-1):MM/yyyy}");

#line default
#line hidden
                EndContext();
                BeginContext(7162, 1544, true);
                WriteLiteral(@"');
                date = moment($('[name=""_EndDate""]').val(), 'MM/YYYY')._d;
            }

            $('[name=""EndDate""]').val(date.toISOString());
        }

        if (!validateFilter()) return;

        typeof reloadChargeList == 'function' && reloadChargeList(callback);
    }

    function validateFilter() {
        $('.financial-filter-error').remove();

        var startDate, endDate;

        if (!fieldHasValue('[name=""RealEstateId""]'))
            $('#financial-filter-real-estate-agency-area').after('<div class=""text-danger financial-filter-error"">Escolha uma imobiliária.</div>');

        if (!fieldHasValue('[name=""StartDate""]'))
            $('#financial-filter-date-area').after('<div class=""text-danger financial-filter-error"">Preencha a Data Inicial.</div>');
        else
            startDate = new Date($('[name=""StartDate""]').val());

        if (!fieldHasValue('[name=""EndDate""]'))
            $('#financial-filter-date-area').after('<div class=""text-danger financia");
                WriteLiteral(@"l-filter-error"">Preencha a Data Final.</div>');
        else
            endDate = new Date($('[name=""EndDate""]').val());

        if (startDate != null && endDate != null && startDate.getTime() > endDate.getTime())
            $('#financial-filter-date-area').after('<div class=""text-danger financial-filter-error"">A Data Inicial não pode ser posterior a Data Final.</div>');

        return $('.financial-filter-error').length == 0;
    }

    function set12months() {
        $('[name=""_StartDate""]').val('");
                EndContext();
                BeginContext(8708, 40, false);
#line 182 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                  Write($"{DateTime.Now.AddMonths(-13):MM/yyyy}");

#line default
#line hidden
                EndContext();
                BeginContext(8749, 41, true);
                WriteLiteral("\');\r\n        $(\'[name=\"_EndDate\"]\').val(\'");
                EndContext();
                BeginContext(8792, 39, false);
#line 183 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\Financial\ExtractFilter.cshtml"
                                Write($"{DateTime.Now.AddMonths(-1):MM/yyyy}");

#line default
#line hidden
                EndContext();
                BeginContext(8832, 46, true);
                WriteLiteral("\');\r\n\r\n        tryReloadChargeList();\r\n    }\r\n");
                EndContext();
            }
            );
            __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut = CreateTagHelper<global::AMaisImob_WEB.Helpers.Javascript.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __AMaisImob_WEB_Helpers_Javascript_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
        public Microsoft.AspNetCore.Identity.UserManager<AMaisImob_DB.Models.User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.UserCompanyFunctions userCompanyFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.CompanyTypeFunctions companyTypeFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.CompanyFunctions companyFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.Charge.FinancialFilterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
