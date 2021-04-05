#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01cbda8983ce6a28767e29cd1e981540f531dd69"
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
using AMaisImob_WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01cbda8983ce6a28767e29cd1e981540f531dd69", @"/Views/Shared/Components/CertificateReport/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CertificateReport_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ReportCertificateForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
  
	var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;

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
            BeginContext(512, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(514, 1537, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01cbda8983ce6a28767e29cd1e981540f531dd695475", async() => {
                BeginContext(609, 1435, true);
                WriteLiteral(@"
	<div class=""row"">
		<div class=""col-md-9"">
			<div class=""form-group"">
				<div class=""input-group"">
					<div class=""input-group-prepend"">
						<span class=""input-group-text"">Pesquisar</span>
					</div>
					<input placeholder=""Pesquisar..."" class=""form-control"" data-toggle=""search-datatable"" data-target=""#certificate-report-company-table"" />
				</div>
			</div>
			<table id=""certificate-report-company-table"" class=""table display responsive"" style=""border-collapse: collapse !important; width:100%;"">
				<thead>
					<tr>
						<th><input type=""checkbox"" id=""certificate-checkbox-select-all-companies"" /></th>
						<th>Corretora</th>
						<th>Razão social/Nome</th>
						<th>CNPJ/CPF</th>
					</tr>
				</thead>
				<tbody></tbody>
			</table>
		</div>
		<div class=""col-md-3"">
			<div class=""form-group"">
				<div class=""input-group"" id=""_CertificateManageReferenceMonthArea"">
					<div class=""input-group-prepend"">
						<span class=""input-group-text"">Mês de Referência</span>
		");
                WriteLiteral(@"			</div>
					<input type=""text"" class=""form-control monthYear"" name=""_refMonth"" id=""_CertificateManageReferenceMonth"" placeholder=""Mês de Referência"">
				</div>
			</div>
			<div class=""form-group"">
				<button type=""button"" class=""btn btn-primary"" style=""width: 100%;"" id=""_CertificateIndexGetReportButton""><i class=""fas fa-file-excel""></i>&nbsp;Gerar Relatório</button>
			</div>
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
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
AddHtmlAttributeValue("", 528, Url.Action("GetReport","Certificate"), 528, 38, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2051, 337, true);
            WriteLiteral(@"
<script type=""text/javascript"">
	var certificate_datatables = $('#certificate-report-company-table').DataTable({
		proccessing: true,
		serverSide: false,
		searching: true,
		lengthChange: false,
        dom: 'tip',
        paging: false,
        scrollY: '250px',
        scrollCollapse: true,
		ajax: {
            url: '");
            EndContext();
            BeginContext(2389, 29, false);
#line 68 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
             Write(Url.Action("List", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(2418, 73, true);
            WriteLiteral("\',\r\n            data: function (d) {\r\n                d.companyTypeId = \'");
            EndContext();
            BeginContext(2492, 12, false);
#line 70 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\Shared\Components\CertificateReport\Default.cshtml"
                              Write(realEstateId);

#line default
#line hidden
            EndContext();
            BeginContext(2504, 3471, true);
            WriteLiteral(@"'
            },
			type: 'POST'
        },
        drawCallback: function () {
            _MaskData();
        },
        columns: [
            {
                data: 'Check',
                render: function (data, type, row) {
                    return '<input type=""checkbox"" data-company-id=""' + row.companyId + '"" />';
                }
            },
            {
                data: 'ParentCompany',
                render: function (data, type, row) {
                    if (row.parentRazaoSocial != null)
                        return '<i>' + row.parentRazaoSocial + '</i>';
                    else
                        return '<i>' + row.parentFirstName + ' ' + row.parentLastName + '</i>';
                }
            },
			{ data: 'firstName',
                render: function (data, type, row) {
                    return !IsNullOrWhiteSpace(row.razaoSocial) ? row.razaoSocial : row.firstName + "" "" + row.lastName;
                }
            },
            {
   ");
            WriteLiteral(@"             data: 'CNPJ',
                render: function (data, type, row) {
                    return !IsNullOrWhiteSpace(row.cnpj) ? '<span class=""cnpj"">' + row.cnpj + '</span>' : '<span class=""cpf"">' + row.cpf + '</span>';
                }
            }
        ]
    });

	$('#certificate-checkbox-select-all-companies').change(function () {
		var checked = this.checked;
		$('#certificate-report-company-table input[type=""checkbox""]').each(function (i, e) { e.checked = checked });
    });

    function certificateReportValidate() {
		var _CertificateReportHasError = false;
		$('.text-danger').remove();

		if (IsNullOrWhiteSpace($('#_CertificateManageReferenceMonth').val())) {
			$('#_CertificateManageReferenceMonthArea').after('<div class=""text-danger"">Preencha o mês referente.</div>');
			_CertificateReportHasError = true;
		} else {
			var dSplit = $('#_CertificateManageReferenceMonth').val().split('/'),
				month = dSplit[0],
				year = dSplit[1];

			var currentDate = new Da");
            WriteLiteral(@"te(),
				currentMonth = currentDate.getMonth() + 1, // getMonth() = 0 ~ 11
				currentYear = currentDate.getFullYear();

			if (year > currentYear || (month > currentMonth && year >= currentYear)) {
				$('#_CertificateManageReferenceMonthArea').after('<div class=""text-danger"">A data não pode ser posterior ao mês atual.</div>');
				_CertificateReportHasError = true;
			}
		}

		return !_CertificateReportHasError;
    }

    $('#_CertificateIndexGetReportButton').click(function () {
		if (!certificateReportValidate()) return;

        var newElements = [];

        $('#certificate-report-company-table tbody input[type=""checkbox""]:checked').each(function (i, e) {
            var element = $('<input>', { type: 'hidden', name: 'CompanyIds.Index', value: i });
            var element1 = $('<input>', { type: 'hidden', name: 'CompanyIds[' + i + ']', value: $(e).data('company-id') });
            newElements.push(element, element1);

            $('#ReportCertificateForm').append(element);
 ");
            WriteLiteral(@"           $('#ReportCertificateForm').append(element1);
        });

        $('#ReportCertificateForm').submit();

        newElements.forEach(function (e, i) { $(e).remove(); });
    });

    $('#_CertificateIndexFilterButton').click(function(){
        datatables.ajax.reload();
    });

	$(window).ready(function () {
		_MaskData();
		initializeDatatableSearch();
	});
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.CompanyTypeFunctions companyTypeFunctions { get; private set; }
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