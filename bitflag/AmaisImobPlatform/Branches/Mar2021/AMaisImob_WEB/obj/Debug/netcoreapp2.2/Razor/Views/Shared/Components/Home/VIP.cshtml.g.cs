#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27e70403c11bd949c33bda7694cb90fe05e35996"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Home_VIP), @"mvc.1.0.view", @"/Views/Shared/Components/Home/VIP.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Home/VIP.cshtml", typeof(AspNetCore.Views_Shared_Components_Home_VIP))]
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
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
using AMaisImob_WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27e70403c11bd949c33bda7694cb90fe05e35996", @"/Views/Shared/Components/Home/VIP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Home_VIP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.Home.HomeVIPViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/Doc.jpeg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 24px; width: 24px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(80, 1101, true);
            WriteLiteral(@"
<style type=""text/css"">
    .home-vip-info-col {
        /*        border: 1px solid #d1d1d1;
            border-radius: 10px;*/
        padding: 0;
        margin-left: 5px;
        margin-right: 5px;
    }

    .home-vip-info-main-div {
        padding: 10px;
        text-align: center;
        border-radius: 10px 10px 0 0;
        background: white;
    }

        .home-vip-info-main-div b {
            font-size: 1.1em;
        }


    .home-vip-info-secondary-div {
        border-top: 1px solid #d1d1d1;
        padding: 6px;
        background: #efefef;
        border-radius: 0 0 10px 10px;
    }
</style>

<div class=""row"" style=""background-image: linear-gradient(to right, transparent, #5f7f7a 2%, #5f7f7a 98%, transparent); padding: 10px; padding-left: 15px; padding-right: 15px;"">
    <div class=""col-md home-vip-info-col"">
        <div class=""home-vip-info-main-div"">
            <img src=""/image/Incendio.png"" style=""height: 24px; width: 24px;"">
            <br />
     ");
            WriteLiteral("       <label>Certificados Cotação</label>\r\n            <br>\r\n            <b>");
            EndContext();
            BeginContext(1182, 32, false);
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
          Write(Model.CertificateSimulationCount);

#line default
#line hidden
            EndContext();
            BeginContext(1214, 94, true);
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"home-vip-info-secondary-div\">\r\n            Ganhe <b>");
            EndContext();
            BeginContext(1309, 33, false);
#line 43 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                Write(Model.CertificateSimulationPoints);

#line default
#line hidden
            EndContext();
            BeginContext(1342, 13, true);
            WriteLiteral("</b> Pontos\r\n");
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(1411, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1429, "\"", 1550, 1);
#line 46 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 1436, Url.Action("Index", "Certificate", new { CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Simulacao }), 1436, 114, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1551, 36, true);
            WriteLiteral(" style=\"float: right;\">Acessar</a>\r\n");
            EndContext();
#line 47 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1635, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1653, "\"", 1820, 1);
#line 50 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 1660, Url.Action("Index", "Certificate", new { Model.RealEstateId, Model.RealEstateAgencyId, CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Simulacao }), 1660, 160, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1821, 37, true);
            WriteLiteral("  style=\"float: right;\">Acessar</a>\r\n");
            EndContext();
#line 51 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(1873, 302, true);
            WriteLiteral(@"        </div>
    </div>
    <div class=""col-md home-vip-info-col"">
        <div class=""home-vip-info-main-div"">
            <img src=""/image/Incendio.png"" style=""height: 24px; width: 24px;"">
            <br />
            <label>Certificados à Renovar</label>
            <br>
            <b>");
            EndContext();
            BeginContext(2176, 27, false);
#line 60 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
          Write(Model.CertificateRenewCount);

#line default
#line hidden
            EndContext();
            BeginContext(2203, 94, true);
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"home-vip-info-secondary-div\">\r\n            Ganhe <b>");
            EndContext();
            BeginContext(2298, 28, false);
#line 63 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                Write(Model.CertificateRenewPoints);

#line default
#line hidden
            EndContext();
            BeginContext(2326, 13, true);
            WriteLiteral("</b> Pontos\r\n");
            EndContext();
#line 64 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(2395, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2413, "\"", 2534, 1);
#line 66 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 2420, Url.Action("Index", "Certificate", new { CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Renovacao }), 2420, 114, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2535, 36, true);
            WriteLiteral(" style=\"float: right;\">Acessar</a>\r\n");
            EndContext();
#line 67 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(2619, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2637, "\"", 2804, 1);
#line 70 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 2644, Url.Action("Index", "Certificate", new { Model.RealEstateId, Model.RealEstateAgencyId, CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Renovacao }), 2644, 160, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2805, 36, true);
            WriteLiteral(" style=\"float: right;\">Acessar</a>\r\n");
            EndContext();
#line 71 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(2856, 323, true);
            WriteLiteral(@"        </div>
    </div>
    <div class=""col-md home-vip-info-col"">
        <div class=""home-vip-info-main-div"">
            <img src=""/image/Incendio.png"" style=""height: 24px; width: 24px;"">
            <br />
            <label>Certificados Ativos</label>
            <br>
            <b style=""color: #f39a2d;"">");
            EndContext();
            BeginContext(3180, 28, false);
#line 80 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                                  Write(Model.CertificateActiveCount);

#line default
#line hidden
            EndContext();
            BeginContext(3208, 95, true);
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"home-vip-info-secondary-div\">\r\n            Ganhou <b>");
            EndContext();
            BeginContext(3304, 29, false);
#line 83 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                 Write(Model.CertificateActivePoints);

#line default
#line hidden
            EndContext();
            BeginContext(3333, 13, true);
            WriteLiteral("</b> Pontos\r\n");
            EndContext();
#line 84 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(3402, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3420, "\"", 3540, 1);
#line 86 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 3427, Url.Action("Index", "Certificate", new { CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Emitidos }), 3427, 113, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3541, 36, true);
            WriteLiteral("  style=\"float:right;\">Acessar</a>\r\n");
            EndContext();
#line 87 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(3625, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3643, "\"", 3809, 1);
#line 90 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 3650, Url.Action("Index", "Certificate", new { Model.RealEstateId, Model.RealEstateAgencyId, CertificateType = (int)AMaisImob_WEB.Utils.CertificateTypes.Emitidos }), 3650, 159, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3810, 36, true);
            WriteLiteral("  style=\"float:right;\">Acessar</a>\r\n");
            EndContext();
#line 91 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(3861, 130, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"col-md home-vip-info-col\">\r\n        <div class=\"home-vip-info-main-div\">\r\n            ");
            EndContext();
            BeginContext(3991, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "27e70403c11bd949c33bda7694cb90fe05e3599615430", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4056, 109, true);
            WriteLiteral("\r\n            <br />\r\n            <label>Contratos Novos Pendentes</label>\r\n            <br>\r\n            <b>");
            EndContext();
            BeginContext(4166, 36, false);
#line 100 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
          Write(Model.CertificateContractualNewCount);

#line default
#line hidden
            EndContext();
            BeginContext(4202, 94, true);
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"home-vip-info-secondary-div\">\r\n            Ganhe <b>");
            EndContext();
            BeginContext(4297, 37, false);
#line 103 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                Write(Model.CertificateContractualNewPoints);

#line default
#line hidden
            EndContext();
            BeginContext(4334, 13, true);
            WriteLiteral("</b> Pontos\r\n");
            EndContext();
#line 104 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(4403, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4421, "\"", 4470, 1);
#line 106 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 4428, Url.Action("New", "ContractualGuarantee"), 4428, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4471, 35, true);
            WriteLiteral(" style=\"float:right;\">Acessar</a>\r\n");
            EndContext();
#line 107 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(4554, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4572, "\"", 4675, 1);
#line 110 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 4579, Url.Action("New", "ContractualGuarantee", new { Model.RealEstateId, Model.RealEstateAgencyId }), 4579, 96, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4676, 36, true);
            WriteLiteral("  style=\"float:right;\">Acessar</a>\r\n");
            EndContext();
#line 111 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(4727, 130, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"col-md home-vip-info-col\">\r\n        <div class=\"home-vip-info-main-div\">\r\n            ");
            EndContext();
            BeginContext(4857, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "27e70403c11bd949c33bda7694cb90fe05e3599619816", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4922, 124, true);
            WriteLiteral("\r\n            <br />\r\n            <label>Contratos Ativos</label>\r\n            <br>\r\n            <b style=\"color: #f39a2d;\">");
            EndContext();
            BeginContext(5047, 39, false);
#line 120 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                                  Write(Model.CertificateContractualActiveCount);

#line default
#line hidden
            EndContext();
            BeginContext(5086, 95, true);
            WriteLiteral("</b>\r\n        </div>\r\n        <div class=\"home-vip-info-secondary-div\">\r\n            Ganhou <b>");
            EndContext();
            BeginContext(5182, 40, false);
#line 123 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                 Write(Model.CertificateContractualActivePoints);

#line default
#line hidden
            EndContext();
            BeginContext(5222, 13, true);
            WriteLiteral("</b> Pontos\r\n");
            EndContext();
#line 124 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (User.IsInRealEstate())
            {

#line default
#line hidden
            BeginContext(5291, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5309, "\"", 5361, 1);
#line 126 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 5316, Url.Action("Active", "ContractualGuarantee"), 5316, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5362, 36, true);
            WriteLiteral(" style=\"float:right; \">Acessar</a>\r\n");
            EndContext();
#line 127 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(5446, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5464, "\"", 5570, 1);
#line 130 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 5471, Url.Action("Active", "ContractualGuarantee", new { Model.RealEstateId, Model.RealEstateAgencyId }), 5471, 99, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5571, 35, true);
            WriteLiteral(" style=\"float:right;\">Acessar</a>\r\n");
            EndContext();
#line 131 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(5621, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
#line 134 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
     if (Model.VIP.HasValue)
    {

#line default
#line hidden
            BeginContext(5686, 95, true);
            WriteLiteral("        <div class=\"col-md home-vip-info-col\">\r\n            <div class=\"home-vip-info-main-div\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 5781, "\"", 5838, 1);
#line 137 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
WriteAttributeValue("", 5789, !Model.VIP.Value ? "" : "border-radius: 10px;", 5789, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5839, 374, true);
            WriteLiteral(@">
                <div style=""height: 10px;"">
                    <i class=""fas fa-trophy"" style=""color: #f39a2d; font-size: 21px;""></i>
                </div>
                <br />
                <label style=""transform: translateY(-3px); margin-bottom: 5px;"">Pontuação e Classificação</label>
                <br>
                <span style=""color: #f39a2d;""><b>");
            EndContext();
            BeginContext(6214, 17, false);
#line 144 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                                            Write(Model.TotalPoints);

#line default
#line hidden
            EndContext();
            BeginContext(6231, 17, true);
            WriteLiteral("</b> pontos - <b>");
            EndContext();
            BeginContext(6250, 35, false);
#line 144 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                                                                                Write(Model.VIP.Value ? "VIP" : "CLASSIC");

#line default
#line hidden
            EndContext();
            BeginContext(6286, 33, true);
            WriteLiteral("</b></span>\r\n            </div>\r\n");
            EndContext();
#line 146 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
             if (!Model.VIP.Value)
            {

#line default
#line hidden
            BeginContext(6370, 89, true);
            WriteLiteral("                <div class=\"home-vip-info-secondary-div\">\r\n                    Faltam <b>");
            EndContext();
            BeginContext(6460, 18, false);
#line 149 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
                         Write(Model.NeededPoints);

#line default
#line hidden
            EndContext();
            BeginContext(6478, 53, true);
            WriteLiteral("</b> Pontos para <b>VIP</b>\r\n                </div>\r\n");
            EndContext();
#line 151 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
            }

#line default
#line hidden
            BeginContext(6546, 16, true);
            WriteLiteral("        </div>\r\n");
            EndContext();
#line 153 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Shared\Components\Home\VIP.cshtml"
    }

#line default
#line hidden
            BeginContext(6569, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.Home.HomeVIPViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
