#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bd7dbe43afbfc13cf8eb86638b79992dcdbec2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Index), @"mvc.1.0.view", @"/Views/Company/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/Index.cshtml", typeof(AspNetCore.Views_Company_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bd7dbe43afbfc13cf8eb86638b79992dcdbec2f", @"/Views/Company/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.CompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
  
    var companyTypeFunctions = new WEB.BLL.CompanyTypeFunctions(context);
    string companyTypeName = companyTypeFunctions.GetData().Single(x => x.CompanyTypeId == Model.CompanyTypeId).Name;

    if(Model.CompanyTypeId == 1) { 
    ViewData["Title"] = WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName;
        }
    if(Model.CompanyTypeId == 2) { 
    ViewData["Title"] = WEB.Configuration.InsuranceConfiguration.PartnerDisplayName;
        }

#line default
#line hidden
            BeginContext(563, 132, true);
            WriteLiteral("\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-body\">\r\n        <div id=\"_CompanyIndexViewComponent\"></div>\r\n    </div>\r\n");
            EndContext();
#line 20 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
     if (Model.ParentCompanyId.HasValue){

#line default
#line hidden
            BeginContext(738, 41, true);
            WriteLiteral("    <div class=\"card-footer\">\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 779, "\"", 821, 1);
#line 22 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
WriteAttributeValue("", 786, Url.Action("Plataforma","Company"), 786, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 100, true);
            WriteLiteral(" class=\"btn btn-secondary float-left\"><i class=\"fa fa-arrow-left\"></i>&nbsp;Voltar</a>\r\n    </div>\r\n");
            EndContext();
#line 24 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(929, 86, true);
            WriteLiteral("</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_CompanyIndexViewComponent\').load(\'");
            EndContext();
            BeginContext(1016, 46, false);
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                      Write(Url.Action("CompanyIndexComponent", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(1062, 23, true);
            WriteLiteral("\', { \"companyTypeId\": \'");
            EndContext();
            BeginContext(1086, 19, false);
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                                                                                            Write(Model.CompanyTypeId);

#line default
#line hidden
            EndContext();
            BeginContext(1105, 22, true);
            WriteLiteral("\', \"parentcompanyId\": ");
            EndContext();
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                                                                                                                                            if(Model.ParentCompanyId.HasValue) {

#line default
#line hidden
            BeginContext(1171, 21, false);
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                                                                                                                                                                                 Write(Model.ParentCompanyId);

#line default
#line hidden
            EndContext();
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                                                                                                                                                                                                                   }else{

#line default
#line hidden
            BeginContext(1211, 4, true);
            WriteLiteral("null");
            EndContext();
#line 28 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Company\Index.cshtml"
                                                                                                                                                                                                                                                          }

#line default
#line hidden
            BeginContext(1223, 20, true);
            WriteLiteral("});\r\n</script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
