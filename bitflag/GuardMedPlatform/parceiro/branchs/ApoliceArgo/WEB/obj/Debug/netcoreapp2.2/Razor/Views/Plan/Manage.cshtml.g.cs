#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73543fca1fd1956306775d21affee2c910b8eb85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_Manage), @"mvc.1.0.view", @"/Views/Plan/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Plan/Manage.cshtml", typeof(AspNetCore.Views_Plan_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73543fca1fd1956306775d21affee2c910b8eb85", @"/Views/Plan/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Plan_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.PlanViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Plano";

#line default
#line hidden
            BeginContext(84, 270, true);
            WriteLiteral(@"

<div class=""card shadow bg-light"">
    <div class=""card-header""><span id=""_PlanManageCardHeaderTitle"">Criação de plano</span></div>
    <div class=""card-body"">
        <div id=""PlanManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 354, "\"", 415, 3);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
WriteAttributeValue("", 361, Url.Action("Index","Plan"), 361, 27, false);

#line default
#line hidden
            WriteAttributeValue("", 388, "?productId=", 388, 11, true);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
WriteAttributeValue("", 399, Model.ProductId, 399, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(416, 546, true);
            WriteLiteral(@" class=""btn btn-secondary float-left""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""buttonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</button>
        <script type=""text/javascript"">
            $('#buttonSubmit').click(function () {
                if (_PlanManageValidate()) _PlanManageSave();
            });
        </script>
    </div>
</div>

<script type=""text/javascript"">
    $(function () {
        $('#PlanManageViewComponent').load('");
            EndContext();
            BeginContext(963, 41, false);
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                       Write(Url.Action("PlanManageComponent", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(1004, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                                                                                  if (Model.PlanId.HasValue) { 

#line default
#line hidden
            BeginContext(1046, 12, false);
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                                                                                                          Write(Model.PlanId);

#line default
#line hidden
            EndContext();
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                                                                                                                             } else { 

#line default
#line hidden
            BeginContext(1074, 4, true);
            WriteLiteral("null");
            EndContext();
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                                                                                                                                                        }

#line default
#line hidden
            BeginContext(1087, 16, true);
            WriteLiteral(", \"productId\": \'");
            EndContext();
            BeginContext(1104, 15, false);
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                                                                                                                                                                                    Write(Model.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(1119, 125, true);
            WriteLiteral("\' });\r\n    });\r\n\r\n    function _PlanManageCallBack(data) {\r\n        if (data != null) {\r\n            window.location.href = \'");
            EndContext();
            BeginContext(1245, 27, false);
#line 30 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
                               Write(Url.Action("Manage","Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(1272, 51, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n        }\r\n    }\r\n\r\n");
            EndContext();
#line 34 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
     if (Model.PlanId.HasValue) {
        

#line default
#line hidden
            BeginContext(1372, 78, true);
            WriteLiteral("\r\n    $(\'#_PlanManageCardHeaderTitle\').text(\'Atualização de plano\');\r\n        ");
            EndContext();
#line 37 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Plan\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(1466, 9, true);
            WriteLiteral("</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.PlanViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
