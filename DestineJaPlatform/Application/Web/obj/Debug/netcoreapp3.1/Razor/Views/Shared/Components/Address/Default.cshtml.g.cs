#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7cdb35e3bd6843d7c91dd393fd5d6079c2c45c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Address_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Address/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7cdb35e3bd6843d7c91dd393fd5d6079c2c45c2", @"/Views/Shared/Components/Address/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Address_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.AddressBaseViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-md-2\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">CEP</label>\n            <input class=\"form-control cep\" placeholder=\"CEP\" name=\"CEP\"");
            BeginWriteAttribute("value", " value=\"", 302, "\"", 320, 1);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 310, Model.CEP, 310, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onblur", " onblur=\"", 321, "\"", 516, 15);
            WriteAttributeValue("", 330, "getAddress(\'", 330, 12, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 342, Model.FormId, 342, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 355, "[name=\\\'CEP\\\']\',", 356, 17, true);
            WriteAttributeValue(" ", 372, "\'", 373, 2, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 374, Model.FormId, 374, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 387, "[name=\\\'Address\\\']\',", 388, 21, true);
            WriteAttributeValue(" ", 408, "\'", 409, 2, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 410, Model.FormId, 410, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 423, "[name=\\\'Neighborhood\\\']\',", 424, 26, true);
            WriteAttributeValue(" ", 449, "\'", 450, 2, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 451, Model.FormId, 451, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 464, "[name=\\\'City\\\']\',", 465, 18, true);
            WriteAttributeValue(" ", 482, "\'", 483, 2, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 484, Model.FormId, 484, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 497, "[name=\\\'State\\\']\')", 498, 19, true);
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-6\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">Endere??o</label>\n            <input class=\"form-control\" placeholder=\"Endere??o\" name=\"Address\"");
            BeginWriteAttribute("value", " value=\"", 742, "\"", 764, 1);
#nullable restore
#line 15 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 750, Model.Address, 750, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-2\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">N??mero</label>\n            <input class=\"form-control\" placeholder=\"N??mero\" name=\"Number\"");
            BeginWriteAttribute("value", " value=\"", 985, "\"", 1006, 1);
#nullable restore
#line 21 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 993, Model.Number, 993, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-2\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">Complemento</label>\n            <input class=\"form-control\" placeholder=\"Complemento\" name=\"Complement\"");
            BeginWriteAttribute("value", " value=\"", 1241, "\"", 1266, 1);
#nullable restore
#line 27 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 1249, Model.Complement, 1249, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-3\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">Bairro</label>\n            <input class=\"form-control\" placeholder=\"Bairro\" name=\"Neighborhood\"");
            BeginWriteAttribute("value", " value=\"", 1493, "\"", 1520, 1);
#nullable restore
#line 33 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 1501, Model.Neighborhood, 1501, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-4\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">Cidade</label>\n            <input class=\"form-control\" placeholder=\"Cidade\" name=\"City\"");
            BeginWriteAttribute("value", " value=\"", 1739, "\"", 1758, 1);
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
WriteAttributeValue("", 1747, Model.City, 1747, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"col-md-2\">\n        <div class=\"form-group\">\n            <label class=\"control-label\">Estado</label>\n            ");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Address\Default.cshtml"
       Write(Html.DropDownList("State", dropDownListHelper.GetStates(Model.State), "Selecione", new { Class = "form-control w-100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Web.Helpers.DropDownListHelper dropDownListHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.AddressBaseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
