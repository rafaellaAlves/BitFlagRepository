#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a40f0d9fa4c6ed8c0ef29741b2da44cbb37050f"
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a40f0d9fa4c6ed8c0ef29741b2da44cbb37050f", @"/Views/Certificate/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Certificate_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
  
    int? certificateType = null;
    if (ViewData.ContainsKey("CertificateType") && ViewData["CertificateType"] != null)
    {
        certificateType = int.Parse(ViewData["CertificateType"].ToString());

        if (certificateType == (int)WEB.Utils.CertificateTypes.Simulacao)
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
            BeginContext(465, 578, true);
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
            BeginContext(1044, 55, false);
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                          Write(Url.Action("CertificateManageComponent", "Certificate"));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                   if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(1134, 5, false);
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                    Write(Model);

#line default
#line hidden
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                } else { 

#line default
#line hidden
            BeginContext(1155, 4, true);
            WriteLiteral("null");
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                           }

#line default
#line hidden
            BeginContext(1168, 21, true);
            WriteLiteral(", \"certificateType\": ");
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                  if (certificateType.HasValue) { 

#line default
#line hidden
            BeginContext(1223, 15, false);
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                             Write(certificateType);

#line default
#line hidden
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                                                   } else { 

#line default
#line hidden
            BeginContext(1254, 4, true);
            WriteLiteral("null");
            EndContext();
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                                                                                                                                                                                                                                                                              }

#line default
#line hidden
            BeginContext(1267, 185, true);
            WriteLiteral(" });\r\n\r\n    $(\'#_CertificateManageButtonSubmit\').click(function () {\r\n        if (_CertificateManageValidate()) {\r\n            _CertificateManageSave();\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 41 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
            BeginContext(1487, 221, true);
            WriteLiteral("\r\n        <script type=\"text/javascript\">\r\n            $(\'#_CertificateManageButtonSubmit\').text(\"Salvar\");\r\n            $(\'#_CertificateManageCardHeaderTitle\').text(\'Atualização de certificado\');\r\n        </script>\r\n    ");
            EndContext();
#line 48 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(1720, 169, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function _CertificateManageCallBack(data, planId, freePlan) {\r\n        if (freePlan) {\r\n            $.ajax({\r\n                url: \'");
            EndContext();
            BeginContext(1890, 50, false);
#line 54 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                 Write(Url.Action("SetFreePlanSaveCertificateId", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(1940, 186, true);
            WriteLiteral("\',\r\n                type: \'POST\',\r\n                dataType: \'JSON\',\r\n                data: { planId: planId, certificateId: data }\r\n            });\r\n        }\r\n        var param = \"\";\r\n");
            EndContext();
#line 61 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
         if(certificateType.HasValue){
        

#line default
#line hidden
            BeginContext(2180, 36, true);
            WriteLiteral("\r\n        param = \"?certificateType=");
            EndContext();
            BeginContext(2217, 15, false);
#line 63 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                             Write(certificateType);

#line default
#line hidden
            EndContext();
            BeginContext(2232, 12, true);
            WriteLiteral("\";\r\n        ");
            EndContext();
#line 64 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
               
        }

#line default
#line hidden
            BeginContext(2264, 32, true);
            WriteLiteral("        window.location.href = \'");
            EndContext();
            BeginContext(2297, 34, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Certificate\Manage.cshtml"
                           Write(Url.Action("Index", "Certificate"));

#line default
#line hidden
            EndContext();
            BeginContext(2331, 374, true);
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
