#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88baa08d76527824ea022413f5825851220d7146"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InsurancePolicy_Manage), @"mvc.1.0.view", @"/Views/InsurancePolicy/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InsurancePolicy/Manage.cshtml", typeof(AspNetCore.Views_InsurancePolicy_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88baa08d76527824ea022413f5825851220d7146", @"/Views/InsurancePolicy/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_InsurancePolicy_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Apólices";

#line default
#line hidden
            BeginContext(67, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
 if (!string.IsNullOrWhiteSpace(Context.Request.Query["saved"]))
{
    

#line default
#line hidden
            BeginContext(148, 311, true);
            WriteLiteral(@"
        <div id=""_InsurancePolicyManageAlertSuccess"" class=""alert alert-success fade show text-center"">
            <b>Os dados foram salvos com sucesso!</b>
        </div>
        <script type=""text/javascript"">
            $('#_InsurancePolicyManageAlertSuccess').fadeOut(5000);
        </script>
    ");
            EndContext();
#line 15 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(471, 292, true);
            WriteLiteral(@"
<div class=""card shadow bg-light"">
    <div class=""card-header""><span id=""_InsurancePolicyManageCardHeaderTitle"">Criação de apólice</span></div>
    <div class=""card-body"">
        <div id=""InsurancePolicyManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 763, "\"", 808, 1);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
WriteAttributeValue("", 770, Url.Action("Index","InsurancePolicy"), 770, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(809, 389, true);
            WriteLiteral(@" class=""btn btn-secondary float-left"" style=""color:white;""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""_InsurancePolicyManageButtonSubmit"" class=""btn btn-success float-right""><i class=""fa fa-cloud-upload-alt""></i>&nbsp;Criar Apólice</button>
    </div>
</div>

<script type=""text/javascript"">
    $('#InsurancePolicyManageViewComponent').load('");
            EndContext();
            BeginContext(1199, 63, false);
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                                              Write(Url.Action("InsurancePolicyManageComponent", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(1262, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                                                                                                                               if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(1297, 5, false);
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                                                                                                                                                Write(Model);

#line default
#line hidden
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                                                                                                                                                            } else { 

#line default
#line hidden
            BeginContext(1318, 4, true);
            WriteLiteral("null");
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                                                                                                                                                                                       }

#line default
#line hidden
            BeginContext(1331, 197, true);
            WriteLiteral(" });\r\n\r\n    $(\'#_InsurancePolicyManageButtonSubmit\').click(function () {\r\n        if (_InsurancePolicyManageValidate()) {\r\n            _InsurancePolicyManageSave();\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 38 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
            BeginContext(1563, 225, true);
            WriteLiteral("\r\n        <script type=\"text/javascript\">\r\n            $(\'#_InsurancePolicyManageButtonSubmit\').text(\"Salvar\");\r\n            $(\'#_InsurancePolicyManageCardHeaderTitle\').text(\'Atualização de apólice\');\r\n        </script>\r\n    ");
            EndContext();
#line 45 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(1800, 118, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function _InsurancePolicyManageCallBack(data) {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1919, 39, false);
#line 49 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\InsurancePolicy\Manage.cshtml"
                           Write(Url.Action("Manage", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(1958, 49, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int?> Html { get; private set; }
    }
}
#pragma warning restore 1591
