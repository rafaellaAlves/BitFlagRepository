#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Client\CollectionRequestSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2c5ee4ac61a2ef51f67b2d310a26644329f47dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_CollectionRequestSuccess), @"mvc.1.0.view", @"/Views/Client/CollectionRequestSuccess.cshtml")]
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
#nullable restore
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2c5ee4ac61a2ef51f67b2d310a26644329f47dd", @"/Views/Client/CollectionRequestSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_CollectionRequestSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""card"">
    <div class=""card-body text-center"">
        <div class=""form-group"" style=""color: black;font-size: 25px !important"">
            Sua coleta foi realizada com sucesso!
            <br />
            Em breve entraremos em contato com você.
            <br />
            Se for urgente, entre em contato conosco pelo telefone
            <br />
            <a href=""https://api.whatsapp.com/send?1=pt_BR&phone=552730290907"" target=""_blank"" class=""text-destineja-lg"">+ 55 (27) 3029-0907</a>
            <br />
        </div>
        <div class=""form-group text-destineja-lg"" style=""color: black;"">
            Muito Obrigado!
        </div>
        <div class=""form-group"">
            <a class=""btn btn-destineja-orange""");
            BeginWriteAttribute("href", " href=\"", 742, "\"", 777, 1);
#nullable restore
#line 17 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Client\CollectionRequestSuccess.cshtml"
WriteAttributeValue("", 749, Url.Action("Index", "Home"), 749, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Voltar para a Home</a>\n        </div>\n    </div>\n</div>");
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