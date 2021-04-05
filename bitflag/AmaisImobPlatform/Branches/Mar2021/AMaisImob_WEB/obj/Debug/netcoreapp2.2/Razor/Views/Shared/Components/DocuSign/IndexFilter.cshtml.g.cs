#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cb2e8fde439a7083f7d0019c8d2dff63ec603f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DocuSign_IndexFilter), @"mvc.1.0.view", @"/Views/Shared/Components/DocuSign/IndexFilter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/DocuSign/IndexFilter.cshtml", typeof(AspNetCore.Views_Shared_Components_DocuSign_IndexFilter))]
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
#line 7 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
using AMaisImob_WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cb2e8fde439a7083f7d0019c8d2dff63ec603f4", @"/Views/Shared/Components/DocuSign/IndexFilter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DocuSign_IndexFilter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("docu-sign-filter-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "docusign-index-filter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(351, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(382, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
  
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
            BeginContext(1174, 2958, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f46699", async() => {
                BeginContext(1207, 25, true);
                WriteLiteral("\r\n    <div class=\"row\">\r\n");
                EndContext();
#line 29 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
         if (User.IsInRole("Administrator"))
        {

#line default
#line hidden
                BeginContext(1289, 178, true);
                WriteLiteral("            <div class=\"col\">\r\n                <select class=\"form-control\" name=\"RealEstateAgencyId\" onchange=\"hideRealEstateOptionsByRealEstateAgency();\">\r\n                    ");
                EndContext();
                BeginContext(1467, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f47639", async() => {
                    BeginContext(1484, 9, true);
                    WriteLiteral("Corretora");
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
                BeginContext(1502, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 34 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                     foreach (var item in companyFunctions.GetDataAsNoTracking(x => x.CompanyTypeId == realEstateAgencyTypeId && !x.IsDeleted && x.IsActive))
                    {

#line default
#line hidden
                BeginContext(1686, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1710, 100, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f49594", async() => {
                    BeginContext(1744, 56, false);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                                                    Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
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
                BeginContext(1810, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 37 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                    }

#line default
#line hidden
                BeginContext(1835, 47, true);
                WriteLiteral("                </select>\r\n            </div>\r\n");
                EndContext();
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(1918, 58, true);
                WriteLiteral("            <input type=\"hidden\" name=\"RealEstateAgencyId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1976, "\"", 2003, 1);
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
WriteAttributeValue("", 1984, realEstateAgencyId, 1984, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2004, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
        }

#line default
#line hidden
                BeginContext(2020, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 45 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
         if (!User.IsInRealEstate())
        {

#line default
#line hidden
                BeginContext(2069, 118, true);
                WriteLiteral("            <div class=\"col\">\r\n                <select class=\"form-control\" name=\"RealEstateId\">\r\n                    ");
                EndContext();
                BeginContext(2187, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f413743", async() => {
                    BeginContext(2204, 11, true);
                    WriteLiteral("Imobiliária");
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
                BeginContext(2224, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 50 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                     foreach (var item in companyFunctions.GetDataAsNoTracking(x => x.CompanyTypeId == realEstateTypeId && x.ParentCompanyId.HasValue && !x.IsDeleted && x.IsActive))
                    {
                        if (realEstateAgencyId == item.CompanyId)
                        {

#line default
#line hidden
                BeginContext(2526, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(2554, 148, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f415824", async() => {
                    BeginContext(2636, 56, false);
#line 54 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
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
#line 54 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                                        WriteLiteral(item.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 54 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
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
                BeginContext(2702, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 55 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                            continue;
                        }


#line default
#line hidden
                BeginContext(2772, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(2796, 139, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f419379", async() => {
                    BeginContext(2869, 56, false);
#line 58 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                                                                                           Write(item.NomeFantasia ?? $"{item.FirstName} {item.LastName}");

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 58 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                           WriteLiteral(item.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 58 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
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
                BeginContext(2935, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 59 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                    }

#line default
#line hidden
                BeginContext(2960, 182, true);
                WriteLiteral("                </select>\r\n            </div>\r\n            <div class=\"col\">\r\n                <select class=\"form-control\" name=\"CategoryId\" placeholder=\"Data\">\r\n                    ");
                EndContext();
                BeginContext(3142, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f422701", async() => {
                    BeginContext(3159, 9, true);
                    WriteLiteral("Categoria");
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
                BeginContext(3177, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 65 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                     foreach (var item in categoryFunctions.GetDataAsNoTracking(x => !x.IsDeleted))
                    {

#line default
#line hidden
                BeginContext(3303, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(3327, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f424598", async() => {
                    BeginContext(3361, 16, false);
#line 67 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                                                    Write(item.Description);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 67 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                           WriteLiteral(item.CategoryId);

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
                BeginContext(3386, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 68 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
                    }

#line default
#line hidden
                BeginContext(3411, 47, true);
                WriteLiteral("                </select>\r\n            </div>\r\n");
                EndContext();
#line 71 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(3494, 52, true);
                WriteLiteral("            <input type=\"hidden\" name=\"RealEstateId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3546, "\"", 3567, 1);
#line 74 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
WriteAttributeValue("", 3554, realEstateId, 3554, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3568, 69, true);
                WriteLiteral(" />\r\n            <input type=\"hidden\" name=\"CategoryId\" value=\"\" />\r\n");
                EndContext();
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
        }

#line default
#line hidden
                BeginContext(3648, 188, true);
                WriteLiteral("\r\n        <div class=\"col-3\">\r\n            <input type=\"hidden\" name=\"ReferenceDate\" />\r\n            <input class=\"form-control monthYear required\" name=\"_ReferenceDate\" placeholder=\"Data\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3836, "\"", 3872, 1);
#line 80 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\DocuSign\IndexFilter.cshtml"
WriteAttributeValue("", 3844, $"{DateTime.Now:MM/yyyy}", 3844, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3873, 252, true);
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-auto\" style=\"min-width: 100px;\">\r\n            <button class=\"btn btn-primary w-100\" type=\"button\" id=\"docu-sign-filter-button\"><i class=\"fa fa-filter\"></i>&nbsp;Filtrar</button>\r\n        </div>\r\n    </div>\r\n");
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
            BeginContext(4132, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(4136, 1053, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cb2e8fde439a7083f7d0019c8d2dff63ec603f430418", async() => {
                BeginContext(4203, 977, true);
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

    $('#docu-sign-filter-button').click(function () {
        if (!validateInputs('docu-sign-filter-form')) return;

        if (!IsNullOrWhiteSpace($('[name=""_ReferenceDate""]').val())) {
            var date = moment($('[name=""_ReferenceDate""]').val(), 'MM/YYYY')._d;
            $('[name=""ReferenceDate""]').val(date.toISOString());
        }

        typeof reloadDocuSignList == 'function' && reloadDocuSignList($('#docu-sign-filter-form').serializeArray())
    });
");
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
        public AMaisImob_WEB.BLL.CategoryFunctions categoryFunctions { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
