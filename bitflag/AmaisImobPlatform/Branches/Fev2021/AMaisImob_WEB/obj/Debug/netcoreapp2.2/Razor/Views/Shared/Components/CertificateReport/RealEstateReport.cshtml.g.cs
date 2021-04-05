#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d3e86b2d1c1525ac88770ced3fb237a690ab89b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CertificateReport_RealEstateReport), @"mvc.1.0.view", @"/Views/Shared/Components/CertificateReport/RealEstateReport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CertificateReport/RealEstateReport.cshtml", typeof(AspNetCore.Views_Shared_Components_CertificateReport_RealEstateReport))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
using AMaisImob_WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d3e86b2d1c1525ac88770ced3fb237a690ab89b", @"/Views/Shared/Components/CertificateReport/RealEstateReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CertificateReport_RealEstateReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ReportCertificateRealEstateForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
  
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
            BeginContext(345, 2491, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3e86b2d1c1525ac88770ced3fb237a690ab89b5644", async() => {
                BeginContext(460, 333, true);
                WriteLiteral(@"
	<div class=""row"">
		<div class=""col-md"">
			<div class=""input-group"" id=""_CertificateManageRealEstateAgencyArea"">
				<div class=""input-group-prepend"">
					<span class=""input-group-text"">Corretora</span>
				</div>
				<select class=""form-control"" id=""_CertificateManageRealEstateAgencyId"" name=""RealEstateAgencyId"">
					");
                EndContext();
                BeginContext(793, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3e86b2d1c1525ac88770ced3fb237a690ab89b6375", async() => {
                    BeginContext(810, 5, true);
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
                BeginContext(824, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 23 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
                     foreach (var item in (List<AMaisImob_DB.Models.Company>)ViewData["RealEstateAgency"])
					{
						var companyName = string.IsNullOrWhiteSpace(item.RazaoSocial) ? item.FirstName + " " + item.LastName : item.RazaoSocial;

#line default
#line hidden
                BeginContext(1055, 6, true);
                WriteLiteral("\t\t\t\t\t\t");
                EndContext();
                BeginContext(1061, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3e86b2d1c1525ac88770ced3fb237a690ab89b8386", async() => {
                    BeginContext(1094, 11, false);
#line 26 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
                                                   Write(companyName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 26 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
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
                BeginContext(1114, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 27 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
					}

#line default
#line hidden
                BeginContext(1124, 36, true);
                WriteLiteral("\t\t\t\t</select>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
                EndContext();
                BeginContext(1566, 274, true);
                WriteLiteral(@"		<div class=""form-group col-md"">
			<div class=""input-group"">
				<div class=""input-group-prepend"">
					<span class=""input-group-text"">Produto</span>
				</div>
				<select class=""form-control"" id=""_CertificateManageInsurancePolicyId"" name=""insurancePolicyId"">
					");
                EndContext();
                BeginContext(1840, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d3e86b2d1c1525ac88770ced3fb237a690ab89b11307", async() => {
                    BeginContext(1857, 23, true);
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
                BeginContext(1889, 691, true);
                WriteLiteral(@"
				</select>
			</div>
		</div>
		<div class=""form-group col-md"">
			<div class=""input-group"" id=""_CertificateRealEstateReportReferenceMonthArea"">
				<div class=""input-group-prepend"">
					<span class=""input-group-text"">Mês de Referência</span>
				</div>
				<input type=""text"" class=""form-control monthYear"" name=""_refMonth"" id=""_CertificateRealEstateReportReferenceMonth"" placeholder=""Mês de Referência"">
			</div>
		</div>
		<div class=""form-group col-md"">
			<button type=""button"" class=""btn btn-primary"" style=""width: 100%;"" id=""_CertificateRealEstateReportButton""><i class=""fas fa-file-excel""></i>&nbsp;Gerar Relatório</button>
		</div>
	</div>
	<div class=""row"">
");
                EndContext();
                BeginContext(2820, 9, true);
                WriteLiteral("\t</div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
AddHtmlAttributeValue("", 359, Url.Action("GetRealEStateReport","Certificate"), 359, 48, false);

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
            BeginContext(2836, 1839, true);
            WriteLiteral(@"
<script type=""text/javascript"">
	$('#_CertificateRealEstateReportButton').click(function () {
        var _CertificateReportHasError = false;

        $('.text-danger').remove();

		if (IsNullOrWhiteSpace($('#_CertificateRealEstateReportReferenceMonth').val())) {
			$('#_CertificateRealEstateReportReferenceMonthArea').after('<div class=""text-danger"">Preencha o mês referente.</div>');
            _CertificateReportHasError = true;
        } else {
			var dSplit = $('#_CertificateRealEstateReportReferenceMonth').val().split('/'),
                month = dSplit[0],
                year = dSplit[1];

            var currentDate = new Date(),
                currentMonth = currentDate.getMonth() + 1, // getMonth() = 0 ~ 11
                currentYear = currentDate.getFullYear();

            if (year > currentYear || (month > currentMonth && year >= currentYear)) {
				$('#_CertificateRealEstateReportReferenceMonthArea').after('<div class=""text-danger"">A data não pode ser posterior ao mês atua");
            WriteLiteral(@"l.</div>');
                _CertificateReportHasError = true;
            }
        }

        if (!_CertificateReportHasError)
			$('#ReportCertificateRealEstateForm').submit();

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
            BeginContext(4676, 59, false);
#line 114 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
                 Write(Url.Action("GetRealEstatesByRealEstateAgencyId", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(4735, 1524, true);
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
            BeginContext(6260, 73, false);
#line 143 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
                 Write(Url.Action("GetInsurancePoliciesByRealEstateAgencyId", "InsurancePolicy"));

#line default
#line hidden
            EndContext();
            BeginContext(6333, 1201, true);
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
            WriteLiteral("urancePolicyId\').append(option);\r\n                        }\r\n                    }\r\n                }\r\n            });\r\n        }\r\n    }\r\n\r\n    $(window).ready(_MaskData);\r\n\r\n\r\n");
            EndContext();
#line 169 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
     if (userRealEstateAgencyId.HasValue)
    {
        

#line default
#line hidden
            BeginContext(7598, 70, true);
            WriteLiteral("\r\n        GetRealEstates();\r\n        GetInsurancePolicies();\r\n        ");
            EndContext();
#line 174 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateReport\RealEstateReport.cshtml"
               
    }

#line default
#line hidden
            BeginContext(7684, 9, true);
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