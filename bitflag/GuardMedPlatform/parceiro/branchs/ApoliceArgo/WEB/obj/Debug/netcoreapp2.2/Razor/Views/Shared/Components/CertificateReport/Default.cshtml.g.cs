#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc2090e4e2897da95a401d0687911f8bc13fb9cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CertificateReport_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CertificateReport/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CertificateReport/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CertificateReport_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
using WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc2090e4e2897da95a401d0687911f8bc13fb9cf", @"/Views/Shared/Components/CertificateReport/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CertificateReport_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ReportCertificateForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
  
    int? userRealEstateAgencyId = null, userRealEstateId = null;
    if (ViewData.ContainsKey("UserRealEstateAgencyId"))
    {
        userRealEstateAgencyId = (int)ViewData["UserRealEstateAgencyId"];
    }
    if (ViewData.ContainsKey("UserRealEstateId"))
    {
        userRealEstateId = (int)ViewData["UserRealEstateId"];
    }

#line default
#line hidden
            BeginContext(366, 2782, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc2090e4e2897da95a401d0687911f8bc13fb9cf5277", async() => {
                BeginContext(461, 242, true);
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <div class=\"input-group\" id=\"_CertificateManageRealEstateAgencyArea\">\r\n                <div class=\"input-group-prepend\">\r\n                    <span class=\"input-group-text\">");
                EndContext();
                BeginContext(704, 61, false);
#line 18 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                                              Write(WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(765, 168, true);
                WriteLiteral("</span>\r\n                </div>\r\n                <select class=\"form-control\" id=\"_CertificateManageRealEstateAgencyId\" name=\"RealEstateAgencyId\">\r\n                    ");
                EndContext();
                BeginContext(933, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc2090e4e2897da95a401d0687911f8bc13fb9cf6582", async() => {
                    BeginContext(950, 5, true);
                    WriteLiteral("Todas");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(964, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 22 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                     foreach (var item in (List<DB.Models.Company>)ViewData["RealEstateAgency"])
                    {
                        var companyName = string.IsNullOrWhiteSpace(item.RazaoSocial) ? item.FirstName + " " + item.LastName : item.RazaoSocial;

#line default
#line hidden
                BeginContext(1233, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1257, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc2090e4e2897da95a401d0687911f8bc13fb9cf8621", async() => {
                    BeginContext(1290, 11, false);
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                                                   Write(companyName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 25 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                           WriteLiteral(item.CompanyId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1310, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 26 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                    }

#line default
#line hidden
                BeginContext(1335, 285, true);
                WriteLiteral(@"                </select>
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <div class=""input-group"" id=""_CertificateManageRealEstateArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">");
                EndContext();
                BeginContext(1621, 59, false);
#line 33 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                                              Write(WEB.Configuration.InsuranceConfiguration.PartnerDisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(1680, 156, true);
                WriteLiteral("</span>\r\n                </div>\r\n                <select class=\"form-control\" name=\"RealEstateId\" id=\"_CertificateManageRealEstateId\">\r\n                    ");
                EndContext();
                BeginContext(1836, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc2090e4e2897da95a401d0687911f8bc13fb9cf12026", async() => {
                    BeginContext(1853, 23, true);
                    WriteLiteral("Selecione uma corretora");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1885, 422, true);
                WriteLiteral(@"
                </select>
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <div class=""input-group"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">Produto</span>
                </div>
                <select class=""form-control"" id=""_CertificateManageInsurancePolicyId"" name=""insurancePolicyId"">
                    ");
                EndContext();
                BeginContext(2307, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc2090e4e2897da95a401d0687911f8bc13fb9cf13944", async() => {
                    BeginContext(2324, 23, true);
                    WriteLiteral("Selecione uma corretora");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2356, 785, true);
                WriteLiteral(@"
                </select>
            </div>
        </div>
        <div class=""form-group col-md-3"">
            <div class=""input-group"" id=""_CertificateManageReferenceMonthArea"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"">Mês de Referência</span>
                </div>
                <input type=""text"" class=""form-control monthYear"" name=""_refMonth"" id=""_CertificateManageReferenceMonth"" placeholder=""Mês de Referência"">
            </div>
        </div>
        <div class=""form-group col-md-2"">
            <button type=""button"" class=""btn btn-primary"" style=""width: 100%;"" id=""_CertificateIndexGetReportButton""><i class=""fas fa-file-excel""></i>&nbsp;Gerar Relatório</button>
        </div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 13 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
AddHtmlAttributeValue("", 380, Url.Action("GetReport","Certificate"), 380, 38, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3148, 1846, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    $('#_CertificateIndexGetReportButton').click(function () {
        var _CertificateReportHasError = false;

        $('.text-danger').remove();

        if (IsNullOrWhiteSpace($('#_CertificateManageReferenceMonth').val())) {
            $('#_CertificateManageReferenceMonthArea').after('<div class=""text-danger"">Preencha o mês referente.</div>');
            _CertificateReportHasError = true;
        } else {
            var dSplit = $('#_CertificateManageReferenceMonth').val().split('/'),
                month = dSplit[0],
                year = dSplit[1];

            var currentDate = new Date(),
                currentMonth = currentDate.getMonth() + 1, // getMonth() = 0 ~ 11
                currentYear = currentDate.getFullYear();

            if (year > currentYear || (month > currentMonth && year >= currentYear)) {
                $('#_CertificateManageReferenceMonthArea').after('<div class=""text-danger"">A data deve ser até o mês atual.</div>'); //");
            WriteLiteral(@" trocar esta frase.
                _CertificateReportHasError = true;
            }
        }

        if (!_CertificateReportHasError)
            $('#ReportCertificateForm').submit();

    });

    $('#_CertificateManageRealEstateAgencyId').change(function () {
        GetRealEstates();
        GetInsurancePolicies();
    });

    $('#_CertificateIndexFilterButton').click(function(){
        datatables.ajax.reload();
    });

    function GetRealEstates() {
        if (IsNullOrWhiteSpace($('#_CertificateManageRealEstateAgencyId').val())) {
            $('#_CertificateManageRealEstateId').empty();
            $('#_CertificateManageRealEstateId').append($('<option>', { value: '' }).append('Selecione um corretora.'));
        }
        else {
            $.ajax({
                url: '");
            EndContext();
            BeginContext(4995, 59, false);
#line 108 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                 Write(Url.Action("GetRealEstatesByRealEstateAgencyId", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(5054, 1524, true);
            WriteLiteral(@"',
                type: 'POST',
                datatype: 'JSON',
                data: { id: $('#_CertificateManageRealEstateAgencyId').val() },
                success: function (data) {
                    $('#_CertificateManageRealEstateId').empty();
                    if (data == false || data.length == 0) {
                        $('#_CertificateManageRealEstateId').append($('<option>', { value: '' }).append('Todas'));
                    }
                    if (data.length > 0) {
                        $('#_CertificateManageRealEstateId').append($('<option>', { value: '' }).append('Todas'));
                        for (var i = 0; i < data.length; i++) {
                            var companyName = IsNullOrWhiteSpace(data[i].razaoSocial) ? data[i].firstName + "" "" + data[i].lastName : data[i].razaoSocial;
                            var option = $('<option>', { value: data[i].companyId }).append(companyName);
                            $('#_CertificateManageRealEstateId').append(op");
            WriteLiteral(@"tion);
                        }
                    }
                }
            });
        }
    }

    function GetInsurancePolicies() {
        if (IsNullOrWhiteSpace($('#_CertificateManageRealEstateAgencyId').val())) {
            $('#_CertificateManageInsurancePolicyId').empty();
            $('#_CertificateManageInsurancePolicyId').append($('<option>', { value: '' }).append('Selecione um corretora.'));
        }
        else {
            $.ajax({
                url: '");
            EndContext();
            BeginContext(6579, 73, false);
#line 137 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                 Write(Url.Action("GetInsurancePoliciesByRealEstateAgencyId", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(6652, 1234, true);
            WriteLiteral(@"',
                type: 'POST',
                datatype: 'JSON',
                data: {
                    id: $('#_CertificateManageRealEstateAgencyId').val(), showExpired: true
                },
                success: function (data) {
                    $('#_CertificateManageInsurancePolicyId').empty();
                    if (data == false || data.length == 0) {
                        $('#_CertificateManageInsurancePolicyId').append($('<option>', { value: '' }).append('Todos'));
                    }
                    if (data.length > 0) {
                        $('#_CertificateManageInsurancePolicyId').append($('<option>', { value: '' }).append('Todos'));
                        for (var i = 0; i < data.length; i++) {
                            var option = $('<option>', { value: data[i].insurancePolicyId }).append(data[i].productName).data('ProductId', data[i].productId).data('external-code', data[i].productExternalCode);
                            $('#_CertificateManageIns");
            WriteLiteral("urancePolicyId\').append(option);\r\n                        }\r\n                    }\r\n                }\r\n            });\r\n        }\r\n    }\r\n\r\n    $(window).ready(function () {\r\n        _MaskData();\r\n    });\r\n\r\n\r\n");
            EndContext();
#line 165 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
     if (userRealEstateAgencyId.HasValue)
    {
        

#line default
#line hidden
            BeginContext(7950, 70, true);
            WriteLiteral("\r\n        GetRealEstates();\r\n        GetInsurancePolicies();\r\n        ");
            EndContext();
#line 170 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
               
    }

#line default
#line hidden
            BeginContext(8036, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
