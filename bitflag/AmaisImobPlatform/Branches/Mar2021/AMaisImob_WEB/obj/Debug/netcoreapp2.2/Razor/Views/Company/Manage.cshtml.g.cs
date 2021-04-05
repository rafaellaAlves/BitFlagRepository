#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e514a13cfdd868b5e500a2f9b8dbfcfa9dfbc1a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Manage), @"mvc.1.0.view", @"/Views/Company/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/Manage.cshtml", typeof(AspNetCore.Views_Company_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e514a13cfdd868b5e500a2f9b8dbfcfa9dfbc1a2", @"/Views/Company/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.CompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Associado";
    var companyTypeFunctions = new AMaisImob_WEB.BLL.CompanyTypeFunctions(context);

    string companyTypeName = companyTypeFunctions.GetData().Single(x => x.CompanyTypeId == Model.CompanyTypeId).Name;

#line default
#line hidden
            BeginContext(369, 119, true);
            WriteLiteral("\r\n<div class=\"card shadow bg-light\">\r\n    <div class=\"card-header\"><span id=\"_CompanyManageCardHeaderTitle\">Criação de ");
            EndContext();
            BeginContext(489, 25, false);
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                            Write(Html.Raw(companyTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(514, 150, true);
            WriteLiteral("</span></div>\r\n    <div class=\"card-body\">\r\n        <div id=\"CompanyManageViewComponent\"></div>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 664, "\"", 827, 4);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
WriteAttributeValue("", 671, Url.Action("Index","Company"), 671, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 701, "?companyTypeId=", 701, 15, true);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
WriteAttributeValue("", 716, Model.CompanyTypeId, 716, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 736, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                   if (Model.ParentCompanyId.HasValue) {

#line default
#line hidden
                BeginContext(780, 17, true);
                WriteLiteral("&parentCompanyId=");
                EndContext();
                BeginContext(798, 21, false);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                          Write(Model.ParentCompanyId);

#line default
#line hidden
                EndContext();
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                            }

#line default
#line hidden
                PopWriter();
            }
            ), 736, 91, false);
            EndWriteAttribute();
            BeginContext(828, 555, true);
            WriteLiteral(@" class=""btn btn-secondary float-left""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""buttonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</button>
        <script type=""text/javascript"">
            $('#buttonSubmit').click(function () {
                if (_CompanyManageValidate()) _CompanyManageSave();
            });
        </script>
    </div>
</div>

<script type=""text/javascript"">
    $(function () {
        $('#CompanyManageViewComponent').load('");
            EndContext();
            BeginContext(1384, 47, false);
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                          Write(Url.Action("CompanyManageComponent", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(1431, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                           if (Model.CompanyId.HasValue) { 

#line default
#line hidden
            BeginContext(1476, 15, false);
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                      Write(Model.CompanyId);

#line default
#line hidden
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                            } else { 

#line default
#line hidden
            BeginContext(1507, 4, true);
            WriteLiteral("null");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                       }

#line default
#line hidden
            BeginContext(1520, 20, true);
            WriteLiteral(", \"companyTypeId\": \'");
            EndContext();
            BeginContext(1541, 19, false);
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                       Write(Model.CompanyTypeId);

#line default
#line hidden
            EndContext();
            BeginContext(1560, 21, true);
            WriteLiteral("\',\"parentCompanyId\": ");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                      if (Model.ParentCompanyId.HasValue) { 

#line default
#line hidden
            BeginContext(1621, 21, false);
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                       Write(Model.ParentCompanyId);

#line default
#line hidden
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                                                   } else { 

#line default
#line hidden
            BeginContext(1658, 4, true);
            WriteLiteral("null");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                                                                              }

#line default
#line hidden
            BeginContext(1671, 127, true);
            WriteLiteral(" });\r\n    });\r\n\r\n    function _CompanyManageCallBack(data) {\r\n        if (data != null) {\r\n            window.location.href = \'");
            EndContext();
            BeginContext(1799, 30, false);
#line 33 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                               Write(Url.Action("Manage","Company"));

#line default
#line hidden
            EndContext();
            BeginContext(1829, 51, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n        }\r\n    }\r\n\r\n");
            EndContext();
#line 37 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
     if (Model.CompanyId.HasValue) {
        

#line default
#line hidden
            BeginContext(1932, 63, true);
            WriteLiteral("\r\n    $(\'#_CompanyManageCardHeaderTitle\').text(\'Atualização de ");
            EndContext();
            BeginContext(1996, 25, false);
#line 39 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
                                                        Write(Html.Raw(companyTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(2021, 13, true);
            WriteLiteral("\');\r\n        ");
            EndContext();
#line 40 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Company\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(2050, 9, true);
            WriteLiteral("</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
