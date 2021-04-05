#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86b3c7131bf38629128543b8a314f40a5a591d96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TransporterVehicleManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TransporterVehicleManage/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86b3c7131bf38629128543b8a314f40a5a591d96", @"/Views/Shared/Components/TransporterVehicleManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TransporterVehicleManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "transporter-vehicle-manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Web.Utils.TagHelperScriptCut __Web_Utils_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<form id=\"form-transporter-vehicle\">\n    <input type=\"hidden\" name=\"TransporterId\"");
            BeginWriteAttribute("value", " value=\"", 94, "\"", 108, 1);
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\TransporterVehicleManage\Default.cshtml"
WriteAttributeValue("", 102, Model, 102, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    <input type=""hidden"" name=""TransporterVehicleId"" />
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Placa</label>
            <input class=""form-control"" placeholder=""Placa"" name=""LicensePlate"" maxlength=""7"" />
        </div>
        <div class=""col-md-6 form-group"">
            <label>Arquivo Placa</label>
           <input class=""form-control"" type=""file"" name=""LicensePlateArchive"">
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-4 form-group"">
            <label>Modelo</label>
            <input class=""form-control"" placeholder=""Modelo"" name=""Model"" />
        </div>
        <div class=""col-md-4 form-group"">
            <label>Fabricante</label>
            <input class=""form-control"" placeholder=""Fabricante"" name=""Manufacturer"" />
        </div>
        <div class=""col-md-4 form-group"">
            <label>Ano de Fabricação</label>
            <input class=""form-control number"" placeholder=""Ano de Fabricação"" name=""ManufacturingDate"" />
");
            WriteLiteral(@"        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Número DUT</label>
            <input class=""form-control"" placeholder=""Número DUT"" name=""DUT"" />
        </div>
        <div class=""col-md-6 form-group"">
            <label>Arquivo DUT</label>
           <input class=""form-control"" type=""file"" name=""DUTArchive"">
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Número CIV</label>
            <input class=""form-control"" placeholder=""Número CIV"" name=""CIV"" />
        </div>
        <div class=""col-md-6 form-group"">
            <label>Arquivo CIV</label>
           <input class=""form-control"" type=""file"" name=""CIVArchive"">
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Data de Vencimento</label>
            <input class=""form-control date"" placeholder=""Data de Vencimento"" name=""_CIVDueDate"" />
        </div>
     ");
            WriteLiteral(@"   <div class=""col-md-6 form-group"">
            <label>Dias para o Vencimento</label>
            <input class=""form-control number"" placeholder=""Dias para o Vencimento"" id=""CIV-days-for-due-date"" />
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Modelo CIPP</label>
            <input class=""form-control"" placeholder=""Modelo CIPP"" name=""CIPPModel"" />
        </div>
        <div class=""col-md-6 form-group"">
            <label>Arquivo CIPP</label>
           <input class=""form-control"" type=""file"" name=""CIPPArchive"">
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label>Data de Vencimento</label>
            <input class=""form-control date"" placeholder=""Data de Vencimento"" name=""_CIPPDueDate"" />
        </div>
        <div class=""col-md-6 form-group"">
            <label>Dias para o Vencimento</label>
            <input class=""form-control number"" placeholder=""Dias para o Vencimento"" i");
            WriteLiteral("d=\"CIPP-days-for-due-date\" />\n        </div>\n    </div>\n</form>\n\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86b3c7131bf38629128543b8a314f40a5a591d967883", async() => {
                WriteLiteral(@"
    $('#form-transporter-vehicle input[name=\'_CIPPDueDate\'], #CIPP-days-for-due-date').on('change', function () {

        if ($(this).is($('#form-transporter-vehicle input[name=\'_CIPPDueDate\']'))) {
            if (isNullOrWhiteSpace($('#form-transporter-vehicle input[name=\'_CIPPDueDate\']').val())) {
                $('#CIPP-days-for-due-date').val('');
                return;
            }

            var days = getDaysFromToday(moment($('#form-transporter-vehicle input[name=\'_CIPPDueDate\']').val(), 'DD/MM/YYYY')._d);
            if (days == null || isNaN(days)) {
                $(this).val('');
                $('#CIPP-days-for-due-date').val('');
            }

            $('#CIPP-days-for-due-date').val(parseInt(days));
        }
        else {
            var now = new Date();
            now.setHours(0, 0, 0, 0);

            $('#form-transporter-vehicle input[name=\'_CIPPDueDate\']').val(moment(now).add($(this).val(), 'days').format('DD/MM/YYYY'));
        }
    });

    $('#form-transport");
                WriteLiteral(@"er-vehicle input[name=\'_CIVDueDate\'], #CIV-days-for-due-date').on('change', function () {

        if ($(this).is($('#form-transporter-vehicle input[name=\'_CIVDueDate\']'))) {
            if (isNullOrWhiteSpace($('#form-transporter-vehicle input[name=\'_CIVDueDate\']').val())) {
                $('#CIV-days-for-due-date').val('');
                return;
            }

            var days = getDaysFromToday(moment($('#form-transporter-vehicle input[name=\'_CIVDueDate\']').val(), 'DD/MM/YYYY')._d);
            if (days == null || isNaN(days)) {
                $(this).val('');
                $('#CIV-days-for-due-date').val('');
            }

            $('#CIV-days-for-due-date').val(parseInt(days));
        }
        else {
            var now = new Date();
            now.setHours(0, 0, 0, 0);

            $('#form-transporter-vehicle input[name=\'_CIVDueDate\']').val(moment(now).add($(this).val(), 'days').format('DD/MM/YYYY'));
        }
    });
");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
