#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5a317a6d2d937090d9df6d0245e878c0d931e8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Certificate_Manage), @"mvc.1.0.view", @"/Views/Certificate/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Certificate/Manage.cshtml", typeof(AspNetCore.Views_Certificate_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5a317a6d2d937090d9df6d0245e878c0d931e8b", @"/Views/Certificate/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Certificate_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
  
    int? certificateType = null;
    if (ViewData.ContainsKey("CertificateType") && ViewData["CertificateType"] != null)
    {
        certificateType = int.Parse(ViewData["CertificateType"].ToString());

        if (certificateType == (int)AMaisImob_WEB.Utils.CertificateTypes.Simulacao)
        {
            ViewData["Title"] = "Novo/Notificação";
        }
    }
    else
    {
        ViewData["Title"] = "Gerenciar Certificado";
    }

#line default
#line hidden
            BeginContext(475, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
 if (!string.IsNullOrWhiteSpace(Context.Request.Query["saved"]))
{
    

#line default
#line hidden
            BeginContext(556, 303, true);
            WriteLiteral(@"
        <div id=""_CertificateManageAlertSuccess"" class=""alert alert-success fade show text-center"">
            <b>Os dados foram salvos com sucesso!</b>
        </div>
        <script type=""text/javascript"">
            $('#_CertificateManageAlertSuccess').fadeOut(5000);
        </script>
    ");
            EndContext();
#line 28 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(871, 576, true);
            WriteLiteral(@"
<div class=""alert"" role=""alert"" style=""display:none; background-color: rgba(243, 154, 45, .6);"" id=""warningBox"">
    <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
        <span aria-hidden=""true"">×</span>
    </button>
    <strong class=""d-block d-sm-inline-block-force"">Atenção!</strong> <span id=""warningBoxText""></span>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div id=""CertificateManageViewComponent""></div>
    </div>
</div>
<script type=""text/javascript"">
    $('#CertificateManageViewComponent').load('");
            EndContext();
            BeginContext(1448, 55, false);
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                          Write(Url.Action("CertificateManageComponent", "Certificate"));

#line default
#line hidden
            EndContext();
            BeginContext(1503, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                   if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(1538, 5, false);
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                    Write(Model);

#line default
#line hidden
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                } else { 

#line default
#line hidden
            BeginContext(1559, 4, true);
            WriteLiteral("null");
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                           }

#line default
#line hidden
            BeginContext(1572, 21, true);
            WriteLiteral(", \"certificateType\": ");
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                  if (certificateType.HasValue) { 

#line default
#line hidden
            BeginContext(1627, 15, false);
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                             Write(certificateType);

#line default
#line hidden
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                                                   } else { 

#line default
#line hidden
            BeginContext(1658, 4, true);
            WriteLiteral("null");
            EndContext();
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                                                                              }

#line default
#line hidden
            BeginContext(1671, 185, true);
            WriteLiteral(" });\r\n\r\n    $(\'#_CertificateManageButtonSubmit\').click(function () {\r\n        if (_CertificateManageValidate()) {\r\n            _CertificateManageSave();\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 52 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
            BeginContext(1891, 221, true);
            WriteLiteral("\r\n        <script type=\"text/javascript\">\r\n            $(\'#_CertificateManageButtonSubmit\').text(\"Salvar\");\r\n            $(\'#_CertificateManageCardHeaderTitle\').text(\'Atualização de certificado\');\r\n        </script>\r\n    ");
            EndContext();
#line 59 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(2124, 169, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function _CertificateManageCallBack(data, planId, freePlan) {\r\n        if (freePlan) {\r\n            $.ajax({\r\n                url: \'");
            EndContext();
            BeginContext(2294, 50, false);
#line 65 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                 Write(Url.Action("SetFreePlanSaveCertificateId", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(2344, 186, true);
            WriteLiteral("\',\r\n                type: \'POST\',\r\n                dataType: \'JSON\',\r\n                data: { planId: planId, certificateId: data }\r\n            });\r\n        }\r\n        var param = \"\";\r\n");
            EndContext();
#line 72 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
         if(certificateType.HasValue){
        

#line default
#line hidden
            BeginContext(2584, 36, true);
            WriteLiteral("\r\n        param = \"?certificateType=");
            EndContext();
            BeginContext(2621, 15, false);
#line 74 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                             Write(certificateType);

#line default
#line hidden
            EndContext();
            BeginContext(2636, 12, true);
            WriteLiteral("\";\r\n        ");
            EndContext();
#line 75 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
               
        }

#line default
#line hidden
            BeginContext(2668, 32, true);
            WriteLiteral("        window.location.href = \'");
            EndContext();
            BeginContext(2701, 34, false);
#line 77 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Certificate\Manage.cshtml"
                           Write(Url.Action("Index", "Certificate"));

#line default
#line hidden
            EndContext();
            BeginContext(2735, 374, true);
            WriteLiteral(@"' + param;
    }

    function _CertificateManageIsLocked(message) {
        $('#_CertificateManageButtonSubmit').remove();
        $('#warningBox').show();
        $('#warningBoxText').text(message);
    }

    function _CertificateManageShowWarningBox(message) {
        $('#warningBox').show();
        $('#warningBoxText').text(message);
    }

</script>
");
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
