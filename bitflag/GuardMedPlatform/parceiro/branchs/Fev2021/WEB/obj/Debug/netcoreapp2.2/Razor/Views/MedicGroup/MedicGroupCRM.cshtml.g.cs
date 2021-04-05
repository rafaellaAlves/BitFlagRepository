#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f5f95df125c761b50c697f5f599a142d252778d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicGroup_MedicGroupCRM), @"mvc.1.0.view", @"/Views/MedicGroup/MedicGroupCRM.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MedicGroup/MedicGroupCRM.cshtml", typeof(AspNetCore.Views_MedicGroup_MedicGroupCRM))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f5f95df125c761b50c697f5f599a142d252778d", @"/Views/MedicGroup/MedicGroupCRM.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicGroup_MedicGroupCRM : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/modeloImportacao/ModeloExportacaoProfissional.xlsx"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("download", new global::Microsoft.AspNetCore.Html.HtmlString("ImportacaoCRMs.xlsx"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary input-group-btn input-group-style"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("CRMForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(12, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
  
    ViewData["Title"] = $"{medicGroupFunctions.GetDataByID(Model).MedicGroupName}";

#line default
#line hidden
            BeginContext(165, 910, true);
            WriteLiteral(@"
<div class=""row"">
	<div class=""col-md-12"">
		<div class=""card"" style=""background-color:#e8e8e8;"">
			<div class=""card-body"">
				<div class=""row"">
					<div class=""col-md-10"">
						<div class=""input-group"">
							<div class=""input-group-prepend"">
								<span class=""input-group-text""><i class=""fa fa-search guardmed-blue""></i></span>
							</div>
							<input id=""MedicGroupCRMListSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
						</div>
					</div>
					<div class=""col-md-2"">
						<div class=""btn-group"" role=""group"" aria-label=""Basic example"">
							<a href=""javascript:void(0)"" class=""btn btn-primary w-100"" id=""ImportarCRMBotao""><i class=""fas fa-file-excel""></i>&nbsp;Importar</a>
							<a href=""javascript:void(0)"" class=""btn btn-success w-100"" id=""NovoCRMBotao""><i class=""fas fa-plus""></i>&nbsp;Novo</a>
						</div>

					</div>
				</div>
				");
            EndContext();
            BeginContext(1075, 3241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f5f95df125c761b50c697f5f599a142d252778d6928", async() => {
                BeginContext(1094, 54, true);
                WriteLiteral("\r\n\t\t\t\t\t<input id=\"CRMMedicGroupId\" name=\"MedicGroupId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1148, "\"", 1162, 1);
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
WriteAttributeValue("", 1156, Model, 1156, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1163, 1117, true);
                WriteLiteral(@" type=""hidden"" />
					<div class=""row"" style=""display:none;"" id=""AreaNovoCRM"">
						<div class=""col-md-12"">
							<hr />
							<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"" id=""AlertaErroCRM"" style=""display:none;"">
								<b>Insira o CRM e o Estado do CRM!</b>
								<button type=""button"" class=""close"" onclick=""function EsconderAlerta() { $('#AlertaErroCRM').hide(); }; EsconderAlerta()"">
									<span aria-hidden=""true"">&times;</span>
								</button>
							</div>
						</div>
						<div class=""col-md-6 form-group"">
							<input id=""Nome"" name=""Nome"" type=""text"" class=""form-control"" placeholder=""Digite o Nome."" />
						</div>
						<div class=""col-md-6 form-group"">
							<input id=""CPF"" name=""CPF"" type=""text"" class=""form-control cpf"" placeholder=""Digite o CPF."" />
						</div>
						<div class=""col-md-6 form-group"">
							<input id=""CRM"" name=""CRM"" type=""text"" class=""form-control"" placeholder=""Digite o CRM."" />
						</div>
						<div class=""col-md-6");
                WriteLiteral(" form-group\">\r\n\t\t\t\t\t\t\t<select class=\"form-control\" id=\"CRMEstado\" name=\"CRMEstado\">\r\n\t\t\t\t\t\t\t\t");
                EndContext();
                BeginContext(2280, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f5f95df125c761b50c697f5f599a142d252778d9055", async() => {
                    BeginContext(2297, 19, true);
                    WriteLiteral("Selecione um Estado");
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
                BeginContext(2325, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 54 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
                                 foreach (var item in WEB.Utils.StatesUtils.GetEstados())
								{

#line default
#line hidden
                BeginContext(2405, 9, true);
                WriteLiteral("\t\t\t\t\t\t\t\t\t");
                EndContext();
                BeginContext(2414, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f5f95df125c761b50c697f5f599a142d252778d10916", async() => {
                    BeginContext(2446, 16, false);
#line 56 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
                                                              Write(item.Description);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 56 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
                                       WriteLiteral(item.EstadoId);

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
                BeginContext(2471, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 57 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
								}

#line default
#line hidden
                BeginContext(2484, 1383, true);
                WriteLiteral(@"							</select>
						</div>
						<div class=""col-md-6 form-group"">
							<button type=""button"" class=""btn btn-secondary"" id=""CancelarCRMBotao""><i class=""fas fa-times""></i>&nbsp;Cancelar</button>
						</div>
						<div class=""col-md-6 form-group text-right"">
							<button type=""button"" class=""btn btn-success"" id=""SalvarCRMBotao""><i class=""fas fa-upload""></i>&nbsp;Salvar</button>
						</div>
					</div>
					<div class=""row"" style=""display:none;"" id=""AreaImportarCRM"">
						<div class=""col-md-12"">
							<hr />
							<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"" id=""AlertaErroImportacaoCRM"" style=""display:none;"">
								<b id=""AlertaErroImportacaoCRMTexto"">Insira o CRM e o Estado do CRM!</b>
								<button type=""button"" class=""close"" onclick=""function EsconderAlerta() { $('#AlertaErroImportacaoCRM').hide(); }; EsconderAlerta()"">
									<span aria-hidden=""true"">&times;</span>
								</button>
							</div>
						</div>
						<div class=""col-md-12 form-gr");
                WriteLiteral(@"oup"">
							<div class=""input-group"">
								<input id=""Arquivo"" name=""Arquivo"" type=""file"" class=""form-control"" placeholder=""Insira o arquivo."" />
								<div class=""input-group-append"">
									<button type=""button"" class=""btn btn-danger input-group-btn"" id=""CancelarImportacaoCRMBotao""><i class=""fas fa-times""></i>&nbsp;Cancelar</button>
									");
                EndContext();
                BeginContext(3867, 218, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f5f95df125c761b50c697f5f599a142d252778d14814", async() => {
                    BeginContext(4026, 55, true);
                    WriteLiteral("<i class=\"fas fa-file-download\"></i>&nbsp;Modelo (xlsx)");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4085, 224, true);
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<button type=\"button\" class=\"btn btn-success input-group-btn\" id=\"SalvarImportacaoCRMBotao\"><i class=\"fas fa-file-upload\"></i>&nbsp;Importar</button>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4316, 984, true);
            WriteLiteral(@"
			</div>
		</div>
	</div>
	<div class=""col-md-12"" style=""margin-top:1em;"">
		<div class=""card"">
			<div class=""card-body"">
				<div class=""alert alert-success"" id=""AlertaSucessoCRM"" style=""display:none;"" role=""alert"">
					<b>CRM adicionado com sucesso!</b>
				</div>
				<div class=""row"">
					<div class=""col-md-12"">
						<table class=""table table-striped table-borderer"" id=""MedicGroupCRMListTable"" style=""width:100%;"">
							<thead>
								<tr>
									<td>Nome</td>
									<td>CPF</td>
									<td>CRM</td>
									<td>UF</td>
									<td>&nbsp;</td>
								</tr>
							</thead>
							<tbody></tbody>
						</table>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>

<script type=""text/javascript"">

    MedicGroupCRMDatatables = $('#MedicGroupCRMListTable').DataTable({
	    proccessing: true,
        serverSide: true,
	    searching: true,
	    lengthChange: false,
	    dom: 'tip',
	    ajax: {
            url: '");
            EndContext();
            BeginContext(5301, 45, false);
#line 128 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
             Write(Url.Action("MedicGroupCRMList", "MedicGroup"));

#line default
#line hidden
            EndContext();
            BeginContext(5346, 72, true);
            WriteLiteral("\',\r\n            data: function (d) {\r\n                d.medicGroupId = \'");
            EndContext();
            BeginContext(5419, 5, false);
#line 130 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
                             Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(5424, 1352, true);
            WriteLiteral(@"'
            },
		    type: 'POST'
        },
        columns: [
            {
                data: 'Nome',
                render: function (data, type, row) {
                    return row.nome != null? row.nome : '-';
                }
            },
            {
                data: 'CPF',
                render: function (data, type, row) {
                    return row.cpf != null ? row.cpf : '-';
                }
            },
            {
                data: 'CRM',
                render: function (data, type, row) {
                    return row.crm;
                }
            },
            {
                data: 'CRMEstado',
                render: function (data, type, row) {
                    return row.crmEstado;
                }
            },
            {
                data: '',
                orderable: false,
                render: function (data, type, row) {
                    return '<div class=""text-center""><a href=""javascript:voi");
            WriteLiteral(@"d(0)"" class=""fas fa-trash guardmed-blue"" onclick=""RemoverCRM(' + row.medicGroupCRMId + ',' + row.crm + ')""></a></div>';
                }
            }
	    ]
	});


    function RemoverCRM(medicGroupCRMId, crm) {
        if (confirm(""Deseja remover o CRM: "" + crm + ""?"")) {
            $.ajax({
                url: '");
            EndContext();
            BeginContext(6777, 38, false);
#line 173 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
                 Write(Url.Action("RemoverCRM", "MedicGroup"));

#line default
#line hidden
            EndContext();
            BeginContext(6815, 1422, true);
            WriteLiteral(@"',
                type: 'POST',
                datatype: 'JSON',
                data: { medicGroupCRMId: medicGroupCRMId },
                success: function (data) {
                    $('#MedicGroupCRMListTable').DataTable().ajax.reload();
                    $('#MedicGroupListTable').DataTable().ajax.reload();
                    alert('CRM excluído com sucesso!');
                }
            });
        }
	}


    $('#SalvarCRMBotao').click(function () {

        if (ValidarCRM()) {
            SalvarCRM();
        }
    });

    function ValidarCRM() {
        var crm = false;
        var estado = false;


        $('#CRMForm .text-danger').remove();
        $('#AlertaErroCRM').hide();

        if (IsNullOrWhiteSpace($('#CRM').val())) {
            crm = true;
        }
        if (IsNullOrWhiteSpace($('#CRMEstado').val())) {
            estado = true;
        }

        var temErro = crm || estado;

        if (temErro) {
            $('#AlertaErroCRM').show(");
            WriteLiteral(@");

            var text = 'Insira o CRM e Estado do CRM';

            if (crm && !estado) text = 'Insira o CRM';
            if (!crm && estado) text = 'Insira o Estado do CRM';

            $('#AlertaErroCRM b').text(text);
        }

        return !temErro;
    }

    function SalvarCRM() {
        var d = $('#CRMForm').serializeArray();

        $.ajax({
            url: '");
            EndContext();
            BeginContext(8238, 37, false);
#line 229 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
             Write(Url.Action("SalvarCRM", "MedicGroup"));

#line default
#line hidden
            EndContext();
            BeginContext(8275, 2644, true);
            WriteLiteral(@"',
            type: 'POST',
            datatype: 'JSON',
            data: d,
            success: function (data) {
                if (!data.temErro) {
                    $(""#AreaNovoCRM"").slideUp(""slow"");
                    ClearAllInputs();
                    $('#MedicGroupCRMListTable').DataTable().ajax.reload();
                    $('#MedicGroupListTable').DataTable().ajax.reload();
                    $('#AlertaSucessoCRM').show();
                    var contadorCRM;

                    clearTimeout(contadorCRM);
                    contadorCRM = setTimeout(EsconderAlertaCRM, 4000);

                    function EsconderAlertaCRM() {
                        $('#AlertaSucessoCRM').hide();
                    }
                }
                else {
                    alert(data.mensagem);
                }
            }
        });
	}


	function MedicGroupCRMListDoneTyping() {
		if ($.fn.DataTable.isDataTable('#MedicGroupCRMListTable')) {
			MedicGroupCRMDatatab");
            WriteLiteral(@"les.search($('#MedicGroupCRMListSearch').val()).draw();
		}
	}
	$('#MedicGroupCRMListSearch').keyup(function () {
		clearTimeout(MedicGroupCRMListTypingTimer);
		MedicGroupCRMListTypingTimer = setTimeout(MedicGroupCRMListDoneTyping, MedicGroupCRMListDoneTypingInterval);
	});
	$('#MedicGroupCRMListSearch').keydown(function () {
		clearTimeout(MedicGroupCRMListTypingTimer);
	});

	$('#NovoCRMBotao').click(function () {
		$(""#AreaImportarCRM"").slideUp(""slow"");
		$(""#AreaNovoCRM"").slideDown(""slow"");
		ClearAllInputs();
	});

	$('#ImportarCRMBotao').click(function () {
		$(""#AreaNovoCRM"").slideUp(""slow"");
		$(""#AreaImportarCRM"").slideDown(""slow"");
		ClearAllInputs();
	});

	$('#CancelarCRMBotao').click(function () {
		$('#CRMForm .text-danger').remove();
		$('#AlertaErroCRM').hide();
		ClearAllInputs();
		$(""#AreaNovoCRM"").slideUp(""slow"");
	});

	$('#CancelarImportacaoCRMBotao').click(function () {
		$('#AlertaErroImportacaoCRM').hide();
		ClearAllInputs();
		$(""#AreaImportarCRM"").");
            WriteLiteral(@"slideUp(""slow"");
	});


    $('#SalvarImportacaoCRMBotao').click(function () {

        var datafile = new FormData();
        $('#AlertaErroImportacaoCRM').hide();

        if (document.getElementById('Arquivo').files.length <= 0) {
            $('#AlertaErroImportacaoCRMTexto').text('Insira um Arquivo.');
            $('#AlertaErroImportacaoCRM').show();
            return;
        }

        datafile.append(""Arquivo"", document.getElementById('Arquivo').files[0]);
        datafile.append(""medicGroupId"", $('#CRMMedicGroupId').val());

        $.ajax({
            url: '");
            EndContext();
            BeginContext(10920, 40, false);
#line 311 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\MedicGroup\MedicGroupCRM.cshtml"
             Write(Url.Action("ImportarCRMs", "MedicGroup"));

#line default
#line hidden
            EndContext();
            BeginContext(10960, 980, true);
            WriteLiteral(@"',
            type: 'POST',
            contentType: false,
            processData: false,
            data: datafile,
            success: function (data) {
                ClearAllInputs();
                if (data.temErro == false) {
                    $('#AlertaErroImportacaoCRM').hide();
                    $('#MedicGroupCRMListTable').DataTable().ajax.reload();
                    $('#MedicGroupListTable').DataTable().ajax.reload();
                    alert(data.mensagem);
                    $(""#AreaImportarCRM"").slideUp(""slow"");
                } else {
                    $('#AlertaErroImportacaoCRM').show();
                    $('#AlertaErroImportacaoCRMTexto').text(data.mensagem);
                }
            }
        });
    });

    function ClearAllInputs() {
        $(""#CRM"").val("""");
        $(""#CRMEstado"").val("""");
        $(""#Nome"").val("""");
        $(""#CPF"").val("""");
        $(""#Arquivo"").val("""");
    }
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public WEB.BLL.MedicGroupFunctions medicGroupFunctions { get; private set; }
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
