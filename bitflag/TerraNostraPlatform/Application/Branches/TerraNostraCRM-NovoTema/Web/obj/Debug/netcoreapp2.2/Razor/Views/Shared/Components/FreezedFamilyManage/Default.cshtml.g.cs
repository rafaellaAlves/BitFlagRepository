#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6547693bbac14c9d557958e731a454bcf3e129a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FreezedFamilyManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FreezedFamilyManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FreezedFamilyManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FreezedFamilyManage_Default))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6547693bbac14c9d557958e731a454bcf3e129a", @"/Views/Shared/Components/FreezedFamilyManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FreezedFamilyManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.FreezedFamily.FreezedFamilyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FamilyFreezeForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
  
    int applicantFamilyStructureId = (int)ViewBag.ApplicantFamilyStructureId;

#line default
#line hidden
            BeginContext(137, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(139, 2202, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6547693bbac14c9d557958e731a454bcf3e129a4721", async() => {
                BeginContext(181, 459, true);
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-md-12"">

            <table class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
                <thead>
                    <tr>
                        <th>Parentesco</th>
                        <th>Nome</th>
                        <th>Local</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 20 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                     foreach (var item in Model.FreezedFamilyItemViewModel.OrderByDescending(x => x.FamilyStructureId))
                    {

#line default
#line hidden
                BeginContext(784, 62, true);
                WriteLiteral("                        <tr>\r\n                            <td>");
                EndContext();
                BeginContext(847, 31, false);
#line 23 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                           Write(item.FamilyStructureDescription);

#line default
#line hidden
                EndContext();
                BeginContext(878, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(918, 13, false);
#line 24 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                           Write(item.FullName);

#line default
#line hidden
                EndContext();
                BeginContext(931, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
#line 25 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                             if (item.FamilyStructureId == applicantFamilyStructureId) //Caso seja requerente mostra apenas o e-mail
                            {

#line default
#line hidden
                BeginContext(1103, 167, true);
                WriteLiteral("                                <td>\r\n                                    <div class=\"row\"><div class=\"col-sm-4 text-right\"><b>E-mail: </b></div><div class=\"col-sm-8\">");
                EndContext();
                BeginContext(1271, 10, false);
#line 28 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                            Write(item.Email);

#line default
#line hidden
                EndContext();
                BeginContext(1281, 53, true);
                WriteLiteral("</div></div>\r\n                                </td>\r\n");
                EndContext();
#line 30 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                            }
                            else
                            {

#line default
#line hidden
                BeginContext(1430, 171, true);
                WriteLiteral("                                <td>\r\n                                    <div class=\"row\"><div class=\"col-sm-4 text-right\"><b>Nascimento: </b></div><div class=\"col-sm-8\">");
                EndContext();
                BeginContext(1602, 15, false);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                                Write(item.BirthPlace);

#line default
#line hidden
                EndContext();
                BeginContext(1617, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1620, 54, false);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                                                  Write(item.BirthDate.HasValue ? "em " + item._BirthDate : "");

#line default
#line hidden
                EndContext();
                BeginContext(1675, 146, true);
                WriteLiteral("</div></div>\r\n                                    <div class=\"row\"><div class=\"col-sm-4 text-right\"><b>Casamento: </b></div><div class=\"col-sm-8\">");
                EndContext();
                BeginContext(1822, 18, false);
#line 35 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                               Write(item.MarriagePlace);

#line default
#line hidden
                EndContext();
                BeginContext(1840, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1843, 60, false);
#line 35 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                                                    Write(item.MarriageDate.HasValue ? "em " + item._MarriageDate : "");

#line default
#line hidden
                EndContext();
                BeginContext(1904, 142, true);
                WriteLiteral("</div></div>\r\n                                    <div class=\"row\"><div class=\"col-sm-4 text-right\"><b>??bito: </b></div><div class=\"col-sm-8\">");
                EndContext();
                BeginContext(2047, 15, false);
#line 36 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                           Write(item.DeathPlace);

#line default
#line hidden
                EndContext();
                BeginContext(2062, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2065, 54, false);
#line 36 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                                                                                                                                             Write(item.DeathDate.HasValue ? "em " + item._DeathDate : "");

#line default
#line hidden
                EndContext();
                BeginContext(2120, 53, true);
                WriteLiteral("</div></div>\r\n                                </td>\r\n");
                EndContext();
#line 38 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                            }

#line default
#line hidden
                BeginContext(2204, 31, true);
                WriteLiteral("                        </tr>\r\n");
                EndContext();
#line 40 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyManage\Default.cshtml"
                    }

#line default
#line hidden
                BeginContext(2258, 76, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.FreezedFamily.FreezedFamilyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
