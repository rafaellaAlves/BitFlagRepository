#pragma checksum "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5066c1aab68ed2ad5929df7edae097cb0968aecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutMenuAdmin), @"mvc.1.0.view", @"/Views/Shared/_LayoutMenuAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5066c1aab68ed2ad5929df7edae097cb0968aecd", @"/Views/Shared/_LayoutMenuAdmin.cshtml")]
    public class Views_Shared__LayoutMenuAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row mt-lg-5 mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 99, "\"", 146, 1);
#nullable restore
#line 6 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 106, Url.Action("UserRegistration", "Admin"), 106, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-success\">\r\n           Cadastro de Usuários\r\n        </a>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 315, "\"", 350, 1);
#nullable restore
#line 13 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 322, Url.Action("Index", "Home"), 322, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-secondary\">\r\n            Nova Assinatura\r\n        </a>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 517, "\"", 566, 1);
#nullable restore
#line 20 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 524, Url.Action("UpgradeSubscription", "Home"), 524, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-success\">\r\n            Certificado 2°via\r\n        </a>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 733, "\"", 782, 1);
#nullable restore
#line 27 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 740, Url.Action("Unsubscribe", "Subscription"), 740, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-secondary\">\r\n            Cancelamento de Assinatura\r\n        </a>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 960, "\"", 1003, 1);
#nullable restore
#line 34 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 967, Url.Action("UpdateAccount", "Home"), 967, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-success\">\r\n            Atualização Cadastral\r\n        </a>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-lg-5\">\r\n    <div class=\" col-12\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1174, "\"", 1213, 1);
#nullable restore
#line 41 "C:\repositorios\bitflag\AmaisVetPlatform\Application\AmaisVetPlatform\WEB\Views\Shared\_LayoutMenuAdmin.cshtml"
WriteAttributeValue("", 1181, Url.Action("Campaign", "Admin"), 1181, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-secondary\">\r\n           Campanha\r\n        </a>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591