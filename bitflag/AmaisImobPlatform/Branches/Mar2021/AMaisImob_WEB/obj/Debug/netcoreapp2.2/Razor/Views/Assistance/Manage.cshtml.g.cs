#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf8cb575d2931283d23e16e690ff3f97a7f67af7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assistance_Manage), @"mvc.1.0.view", @"/Views/Assistance/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Assistance/Manage.cshtml", typeof(AspNetCore.Views_Assistance_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf8cb575d2931283d23e16e690ff3f97a7f67af7", @"/Views/Assistance/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Assistance_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Assistências";

#line default
#line hidden
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(469, 286, true);
            WriteLiteral(@"
<div class=""card shadow bg-light"">
    <div class=""card-header""><span id=""_AssistanceManageCardHeaderTitle"">Criação de assistência</span></div>
    <div class=""card-body"">
        <div id=""AssistanceManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 755, "\"", 795, 1);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
WriteAttributeValue("", 762, Url.Action("Index","Assistance"), 762, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(796, 383, true);
            WriteLiteral(@" class=""btn btn-secondary float-left"" style=""color:white;""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""_AssistanceManageButtonSubmit"" class=""btn btn-success float-right""><i class=""fa fa-cloud-upload-alt""></i>&nbsp;Criar Assistência</button>
    </div>
</div>

<script type=""text/javascript"">
    $('#AssistanceManageViewComponent').load('");
            EndContext();
            BeginContext(1180, 53, false);
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                                         Write(Url.Action("AssistanceManageComponent", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                                                                                                                if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(1268, 5, false);
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                                                                                                                                 Write(Model);

#line default
#line hidden
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                                                                                                                                             } else { 

#line default
#line hidden
            BeginContext(1289, 4, true);
            WriteLiteral("null");
            EndContext();
#line 30 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                                                                                                                                                                        }

#line default
#line hidden
            BeginContext(1302, 182, true);
            WriteLiteral(" });\r\n\r\n    $(\'#_AssistanceManageButtonSubmit\').click(function () {\r\n        if (_AssistanceManageValidate()) {\r\n            _AssistanceManageSave();\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 38 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
            BeginContext(1519, 219, true);
            WriteLiteral("\r\n        <script type=\"text/javascript\">\r\n            $(\'#_AssistanceManageButtonSubmit\').text(\"Salvar\");\r\n            $(\'#_AssistanceManageCardHeaderTitle\').text(\'Atualização de assistência\');\r\n        </script>\r\n    ");
            EndContext();
#line 45 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(1750, 113, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function _AssistanceManageCallBack(data) {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1864, 34, false);
#line 49 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Mar2021\AMaisImob_WEB\Views\Assistance\Manage.cshtml"
                           Write(Url.Action("Manage", "Assistance"));

#line default
#line hidden
            EndContext();
            BeginContext(1898, 49, true);
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
