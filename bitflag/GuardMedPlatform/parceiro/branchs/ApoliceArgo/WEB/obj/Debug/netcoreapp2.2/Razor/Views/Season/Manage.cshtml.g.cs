#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae3bd3b2e7a356449006420ce671d8d1bceca0b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Season_Manage), @"mvc.1.0.view", @"/Views/Season/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Season/Manage.cshtml", typeof(AspNetCore.Views_Season_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae3bd3b2e7a356449006420ce671d8d1bceca0b5", @"/Views/Season/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Season_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Temporadas";

#line default
#line hidden
            BeginContext(69, 278, true);
            WriteLiteral(@"

<div class=""card shadow bg-light"">
    <div class=""card-header""><span id=""_SeasonManageCardHeaderTitle"">Cria????o de temporada</span></div>
    <div class=""card-body"">
        <div id=""SeasonManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 347, "\"", 383, 1);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
WriteAttributeValue("", 354, Url.Action("Index","Season"), 354, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(384, 373, true);
            WriteLiteral(@" class=""btn btn-secondary float-left"" style=""color:white;""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""_SeasonManageButtonSubmit"" class=""btn btn-success float-right""><i class=""fa fa-cloud-upload-alt""></i>&nbsp;Criar Temporada</button>
    </div>
</div>

<script type=""text/javascript"">
    $('#SeasonManageViewComponent').load('");
            EndContext();
            BeginContext(758, 45, false);
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                                     Write(Url.Action("SeasonManageComponent", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(803, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                                                                                                    if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(838, 5, false);
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                                                                                                                     Write(Model);

#line default
#line hidden
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                                                                                                                                 } else { 

#line default
#line hidden
            BeginContext(859, 4, true);
            WriteLiteral("null");
            EndContext();
#line 19 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                                                                                                                                                            }

#line default
#line hidden
            BeginContext(872, 170, true);
            WriteLiteral(" });\r\n\r\n    $(\'#_SeasonManageButtonSubmit\').click(function () {\r\n        if (_SeasonManageValidate()) {\r\n            _SeasonManageSave();\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 27 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
 if (Model.HasValue)
{
    

#line default
#line hidden
            BeginContext(1077, 209, true);
            WriteLiteral("\r\n        <script type=\"text/javascript\">\r\n            $(\'#_SeasonManageButtonSubmit\').text(\"Salvar\");\r\n            $(\'#_SeasonManageCardHeaderTitle\').text(\'Atualiza????o de temporada\');\r\n        </script>\r\n    ");
            EndContext();
#line 34 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(1298, 109, true);
            WriteLiteral("<script type=\"text/javascript\">\r\n    function _SeasonManageCallBack(data) {\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1408, 30, false);
#line 38 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Season\Manage.cshtml"
                           Write(Url.Action("Manage", "Season"));

#line default
#line hidden
            EndContext();
            BeginContext(1438, 49, true);
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
