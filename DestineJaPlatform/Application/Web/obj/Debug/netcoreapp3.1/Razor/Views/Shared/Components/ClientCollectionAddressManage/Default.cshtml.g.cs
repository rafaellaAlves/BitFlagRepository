#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientCollectionAddressManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "425eee34eb17440fdb337a5dab4881cfeb5e7bbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ClientCollectionAddressManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ClientCollectionAddressManage/Default.cshtml")]
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
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientCollectionAddressManage\Default.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"425eee34eb17440fdb337a5dab4881cfeb5e7bbe", @"/Views/Shared/Components/ClientCollectionAddressManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ClientCollectionAddressManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n<form id=\"form-client-collection-address\">\n    <input type=\"hidden\" name=\"ClientId\"");
            BeginWriteAttribute("value", " value=\"", 171, "\"", 185, 1);
#nullable restore
#line 7 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientCollectionAddressManage\Default.cshtml"
WriteAttributeValue("", 179, Model, 179, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <input type=\"hidden\" name=\"ClientCollectionAddressId\" />\n    <div class=\"address-sm w-100\">\n        ");
#nullable restore
#line 10 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientCollectionAddressManage\Default.cshtml"
    Write( await Component.InvokeAsync<Web.ViewComponents.Shared.AddressViewComponent>(new { model = Model.CopyToEntity<DTO.Shared.AddressBaseViewModel>(), formId = "#form-client-collection-address" }) );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
         <div class=""col-md-6"" id=""main-address-area"">
            <div class=""form-group"">
                <label class=""control-label"">Endere??o Principal?</label>
                    <select class=""form-control"" name=""Main"">
                        <option value=""false"">N??o</option>
                        <option value=""true"">Sim</option>
                    </select>
                </div>
            </div>
    </div>
</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
