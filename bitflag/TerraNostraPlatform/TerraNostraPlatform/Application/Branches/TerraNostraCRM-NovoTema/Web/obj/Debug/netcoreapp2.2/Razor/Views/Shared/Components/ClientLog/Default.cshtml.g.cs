#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91bfd001fcd5f76b062ed00acf64a012003ffaf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ClientLog_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ClientLog/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ClientLog/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ClientLog_Default))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91bfd001fcd5f76b062ed00acf64a012003ffaf7", @"/Views/Shared/Components/ClientLog/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ClientLog_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.ClientLogDetalhadoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 1331, true);
            WriteLiteral(@"<style type=""text/css"">
    .list-item {
        display: none;
    }
</style>

<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""card m-b-30"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-10"">
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <span class=""input-group-text"" id=""basic-addon1""><i class=""simple-icon-magnifier""></i></span>
                            </div>
                            <input class=""form-control"" style=""width:40%;"" id=""_ClientLogSearch"" placeholder=""Pesquisar..."" />
                        </div>
                    </div>
                    <div class=""col-md-2"">
                        <button type=""button"" class=""btn btn-success w-100"" onclick=""OpenNewLogModal()""><i class=""simple-icon-plus""></i>&nbsp;<span style=""padding:3px;"">Novo</span></button>
                    </div>
          ");
            WriteLiteral(@"      </div>
                <hr />
                <div class=""table-responsive"">
                    <table class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
                        <thead>
                            <tr>
");
            EndContext();
            BeginContext(1425, 312, true);
            WriteLiteral(@"                                <th>Assunto</th>
                                <th>Mensagem / Anexo</th>
                                <th>Respons??vel</th>
                                <th>Data</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 38 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                             for (int i = 0; i < Model.ClientLogs.Count; i++)
                            {

#line default
#line hidden
            BeginContext(1847, 83, true);
            WriteLiteral("                                <tr class=\"email-unread list-item search-active\">\r\n");
            EndContext();
            BeginContext(2386, 77, true);
            WriteLiteral("                                    <td style=\"cursor:pointer;\" data-search=\"");
            EndContext();
            BeginContext(2464, 25, false);
#line 47 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                        Write(Model.ClientLogs[i].Title);

#line default
#line hidden
            EndContext();
            BeginContext(2489, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2490, "\"", 2551, 3);
            WriteAttributeValue("", 2500, "OpenNewLogModal(\'", 2500, 17, true);
#line 47 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 2517, Model.ClientLogs[i].ClientLogId, 2517, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 2549, "\')", 2549, 2, true);
            EndWriteAttribute();
            BeginContext(2552, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2554, 25, false);
#line 47 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                                                                                  Write(Model.ClientLogs[i].Title);

#line default
#line hidden
            EndContext();
            BeginContext(2579, 84, true);
            WriteLiteral("</td>\r\n                                    <td style=\"cursor:pointer;\" data-search=\"");
            EndContext();
            BeginContext(2664, 29, false);
#line 48 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                        Write(Model.ClientLogs[i].PlainText);

#line default
#line hidden
            EndContext();
            BeginContext(2693, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2694, "\"", 2755, 3);
            WriteAttributeValue("", 2704, "OpenNewLogModal(\'", 2704, 17, true);
#line 48 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 2721, Model.ClientLogs[i].ClientLogId, 2721, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 2753, "\')", 2753, 2, true);
            EndWriteAttribute();
            BeginContext(2756, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 49 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                         if (Model.ClientLogs[i].PlainText.Length > 50)
                                        {
                                            

#line default
#line hidden
            BeginContext(2937, 64, false);
#line 51 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                        Write(Html.Raw(Model.ClientLogs[i].PlainText.Substring(0, 50) + "..."));

#line default
#line hidden
            EndContext();
#line 51 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                               
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
            BeginContext(3182, 39, false);
#line 55 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                        Write(Html.Raw(Model.ClientLogs[i].PlainText));

#line default
#line hidden
            EndContext();
#line 55 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                      
                                        }

#line default
#line hidden
            BeginContext(3267, 142, true);
            WriteLiteral("                                    </td>\r\n                                    <td style=\"cursor:pointer;  white-space: nowrap;\" data-search=\"");
            EndContext();
            BeginContext(3410, 32, false);
#line 58 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                              Write(Model.ClientLogs[i].UserFullName);

#line default
#line hidden
            EndContext();
            BeginContext(3442, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3443, "\"", 3504, 3);
            WriteAttributeValue("", 3453, "OpenNewLogModal(\'", 3453, 17, true);
#line 58 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 3470, Model.ClientLogs[i].ClientLogId, 3470, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 3502, "\')", 3502, 2, true);
            EndWriteAttribute();
            BeginContext(3505, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 59 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                         if (string.IsNullOrWhiteSpace(Model.ClientLogs[i].UserFullName))
                                        {

#line default
#line hidden
            BeginContext(3658, 3, false);
#line 60 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                     Write("-");

#line default
#line hidden
            EndContext();
#line 60 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                               }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3746, 32, false);
#line 62 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                 Write(Model.ClientLogs[i].UserFullName);

#line default
#line hidden
            EndContext();
#line 62 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                        }

#line default
#line hidden
            BeginContext(3782, 43, true);
            WriteLiteral("                                    </td>\r\n");
            EndContext();
#line 64 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                     if (DateTime.Now.Year == Model.ClientLogs[i].CreatedDate.Year && DateTime.Now.Month == Model.ClientLogs[i].CreatedDate.Month && DateTime.Now.Day == Model.ClientLogs[i].CreatedDate.Day)
                                    {

#line default
#line hidden
            BeginContext(4087, 102, true);
            WriteLiteral("                                        <td style=\"cursor:pointer; white-space: nowrap;\" data-search=\"");
            EndContext();
            BeginContext(4190, 36, false);
#line 66 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                 Write(Model.ClientLogs[i]._CreatedDateHour);

#line default
#line hidden
            EndContext();
            BeginContext(4226, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4227, "\"", 4288, 3);
            WriteAttributeValue("", 4237, "OpenNewLogModal(\'", 4237, 17, true);
#line 66 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 4254, Model.ClientLogs[i].ClientLogId, 4254, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 4286, "\')", 4286, 2, true);
            EndWriteAttribute();
            BeginContext(4289, 7, true);
            WriteLiteral(">Hoje, ");
            EndContext();
            BeginContext(4297, 36, false);
#line 66 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                                                                                                                            Write(Model.ClientLogs[i]._CreatedDateHour);

#line default
#line hidden
            EndContext();
            BeginContext(4333, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 67 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(4460, 102, true);
            WriteLiteral("                                        <td style=\"cursor:pointer; white-space: nowrap;\" data-search=\"");
            EndContext();
            BeginContext(4563, 32, false);
#line 70 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                 Write(Model.ClientLogs[i]._CreatedDate);

#line default
#line hidden
            EndContext();
            BeginContext(4595, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4596, "\"", 4657, 3);
            WriteAttributeValue("", 4606, "OpenNewLogModal(\'", 4606, 17, true);
#line 70 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 4623, Model.ClientLogs[i].ClientLogId, 4623, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 4655, "\')", 4655, 2, true);
            EndWriteAttribute();
            BeginContext(4658, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4660, 36, false);
#line 70 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                                                                                                                  Write(Model.ClientLogs[i]._CreatedDateTime);

#line default
#line hidden
            EndContext();
            BeginContext(4696, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 71 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                    }

#line default
#line hidden
            BeginContext(4742, 39, true);
            WriteLiteral("                                </tr>\r\n");
            EndContext();
#line 73 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(4812, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 74 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                             if (Model.ClientLogs.Count == 0)
                            {

#line default
#line hidden
            BeginContext(4906, 175, true);
            WriteLiteral("                                <tr class=\"email-unread\">\r\n                                    <td colspan=\"4\"><i>Nenhum Item</i></td>\r\n                                </tr>\r\n");
            EndContext();
#line 79 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(5112, 430, true);
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
                <div class=""row"">
                    <div class=""col-6 col-md-6 align-self-center"">
                        <div class=""email-show-label"">
                            <span>
                                Mostrando de <span id=""startPagination""></span> at?? <span id=""endPagination""></span> de <span id=""totalPagination"">");
            EndContext();
            BeginContext(5543, 22, false);
#line 87 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                                                              Write(Model.ClientLogs.Count);

#line default
#line hidden
            EndContext();
            BeginContext(5565, 1360, true);
            WriteLiteral(@"</span>
                            </span>
                        </div>
                    </div>
                    <div class=""col-6 col-md-6 align-self-center"">
                        <div class=""email-pagination float-right"">
                            <ul class=""pagination mb-0"">
                                <li class=""page-item"">
                                    <a class=""page-link"" href=""#"" onclick=""PrevPage()"" aria-label=""Previous"">
                                        <span aria-hidden=""true"">&laquo;</span>
                                        <span class=""sr-only"">Anterior</span>
                                    </a>
                                </li>
                                <li class=""page-item"">
                                    <a class=""page-link"" href=""#"" onclick=""NextPage()"" aria-label=""Next"">
                                        <span aria-hidden=""true"">&raquo;</span>
                                        <span class=""sr-only"">Pr??ximo</s");
            WriteLiteral(@"pan>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <hr />
                <div class=""row"">
                    <div class=""col-md-12"">
                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6925, "\"", 6962, 1);
#line 113 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
WriteAttributeValue("", 6932, Url.Action("Index", "Client"), 6932, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6963, 2413, true);
            WriteLiteral(@" class=""btn btn-secondary""><i class=""simple-icon-arrow-left""></i> Voltar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalNewLog"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""modalNewLogTitle"">Novo Registro</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Fechar"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""alert alert-warning"" id=""ErrorAlert"" style=""display:none;"" role=""alert"">
                    <label id=""ErrorAlertText""></label>
                </div>
                <div class=""alert alert-success"" id=""SuccessAlert"" sty");
            WriteLiteral(@"le=""display:none;"" role=""alert"">
                    <label id=""SuccessAlertText""></label>
                </div>
                <div id=""ClientLogManageViewComponent""></div>
            </div>
            <div class=""modal-footer"" id=""modalNewLogFooter"">
                <div class=""row"" style=""width: 100%; margin: 0;"">
                    <div class=""col-md-6"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal""><i class=""fa fa-times""></i> Fechar</button>
                    </div>
                    <div class=""col-md-6"">
                        <button type=""button"" class=""btn btn-success float-right"" id=""SaveClientLogButton""><i class=""simple-icon-cloud-upload""></i> Salvar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    var itemsPerPage = 10;
    var page = 1;

    $('#modalNewLog').on('hidden.bs.modal', function () {
        $('#title').val(");
            WriteLiteral(@"'');
        $(""#message"").summernote(""reset"");
    })

    function OpenNewLogModal(id) {
        $('#ErrorAlert').hide();
        $('#SuccessAlert').hide();

        if (id != null) {
            $('#modalNewLogFooter').hide();
        } else {
            $('#modalNewLogFooter').show();
        }

        $('#ClientLogManageViewComponent').load('");
            EndContext();
            BeginContext(9377, 48, false);
#line 172 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                            Write(Url.Action("ClientLogManageComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(9425, 24, true);
            WriteLiteral("\', { id: id, clientId: \'");
            EndContext();
            BeginContext(9450, 21, false);
#line 172 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
                                                                                                                     Write(Model.Client.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(9471, 2766, true);
            WriteLiteral(@"' });
        $('#modalNewLog').modal('show');
    }

    $('#SaveClientLogButton').click(function () {
        if (_ClientLogManageValidate()) {
            _ClientLogManageSave(_ClientLogManageCallback);
        }
    });

    function _ClientLogManageCallback(d) {
        if (d.hasError) {
            $('#ErrorAlert').show();
            $('#ErrorAlertText').text(d.message);
        } else {
            window.location.reload();
        }
    }

    function SelectAllChecks() {
        var checks = $('input[type=""checkbox""]');

        if ($('#PrincipalCheckbox').hasClass('active')) {
            $('#PrincipalCheckbox').find('i').removeClass('mdi-checkbox-marked-outline').addClass('mdi-checkbox-blank-outline');
            $('#PrincipalCheckbox').removeClass('active');

            for (var i = 0; i < checks.length; i++) {
                checks[i].checked = false;
            }

        } else {
            $('#PrincipalCheckbox').find('i').removeClass('mdi-checkbox-blank-ou");
            WriteLiteral(@"tline').addClass('mdi-checkbox-marked-outline');
            $('#PrincipalCheckbox').addClass('active');
            for (var i = 0; i < checks.length; i++) {
                if ($(checks[i]).parents('tr').is("":visible"")) {
                    checks[i].checked = true;
                }
            }
        }
    }

    $('input[type=""checkbox""]').change(function () {
        var on = 0;
        for (var i = 0; i < $('input[type=""checkbox""]').length; i++) {
            if ($('input[type=""checkbox""]')[i].checked == true) on++;
        }

        if ($('input[type=""checkbox""]').length == on) {
            if (!$('#PrincipalCheckbox').hasClass('active')) {
                $('#PrincipalCheckbox').addClass('active');
                $('#PrincipalCheckbox').find('i').removeClass('mdi-checkbox-blank-outline').addClass('mdi-checkbox-marked-outline');
            }
        } else {
            if ($('#PrincipalCheckbox').hasClass('active')) {
                $('#PrincipalCheckbox').find('i').re");
            WriteLiteral(@"moveClass('mdi-checkbox-marked-outline').addClass('mdi-checkbox-blank-outline');
                $('#PrincipalCheckbox').removeClass('active');
            }
        }
    });

    function Delete() {
        var ids = [];
        for (var i = 0; i < $('input[type=""checkbox""]').length; i++) {
            if ($('input[type=""checkbox""]')[i].checked == true) {
                ids.push({ name: 'clientLogIds', value: $($('input[type=""checkbox""]')[i]).attr('id') });
            }
        }

        if (ids.length == 0) {
            alert('Nenhum Item Selecionado.');
            return;
        }

        if (!confirm('Deseja realmente excluir os itens selecionados?')) return;

        $.post('");
            EndContext();
            BeginContext(12238, 39, false);
#line 247 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientLog\Default.cshtml"
           Write(Url.Action("DeleteClientLog", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(12277, 3285, true);
            WriteLiteral(@"', ids, function (d) {
            alert(d.message);
            if (!d.hasError) {
                window.location.reload();
            }
        });

    }

    function NextPage() {
        if (page * itemsPerPage < $('.list-item.search-active').length) {
            page++;
            ShowLines();
        }
    }
    function PrevPage() {
        if (page > 1) {
            page--;
            ShowLines();
        }
    }

    function ShowLines() {
        HideAllChecks();

        var finishIndex = page * itemsPerPage;

        if (finishIndex - itemsPerPage + 1 > $('.list-item.search-active').length) {
            $('#startPagination').text($('.list-item.search-active').length);
        } else {
            $('#startPagination').text(finishIndex - itemsPerPage + 1);
        }

        $('#totalPagination').text($('.list-item.search-active').length);

        if (finishIndex > $('.list-item.search-active').length) {
            $('#endPagination').text($('.list-item");
            WriteLiteral(@".search-active').length);
        } else {
            $('#endPagination').text(finishIndex);
        }

        for (var i = 0; i < $('.list-item').length; i++) {
            $($('.list-item')[i]).hide();
        }

        var itemList = $('.list-item.search-active');
        for (var i = 0; i < itemList.length; i++) {
            if (i >= finishIndex - itemsPerPage && i < finishIndex) {
                $(itemList[i]).show();
            }
        }
    }

    $(document).ready(function () {
        ShowLines();
    });

    function HideAllChecks() {
        if ($('#PrincipalCheckbox').hasClass('active')) {
            $('#PrincipalCheckbox').find('i').removeClass('mdi-checkbox-marked-outline').addClass('mdi-checkbox-blank-outline');
            $('#PrincipalCheckbox').removeClass('active');
        }
        for (var i = 0; i < $('input[type=""checkbox""]').length; i++) {
            $('input[type=""checkbox""]')[i].checked = false;
        }
    }

    function Search() {
    ");
            WriteLiteral(@"    page = 1;
        var s = $('#_ClientLogSearch').val();
        var item = $('.list-item');

        for (var i = 0; i < item.length; i++) {
            var childs = $(item[i]).children('td');
            if ($(item[i]).hasClass('search-active')) {
                $(item[i]).removeClass('search-active'); // remove a classe q valida o item para adicionar futuramente
            }

            for (var j = 0; j < childs.length; j++) {
                var _s = $(childs[j]).data('search');
                if (_s != null && _s.toString().toUpperCase().indexOf(s.toUpperCase()) != -1) {
                    if (!$(item[i]).hasClass('search-active')) {
                        $(item[i]).addClass('search-active');
                        break;
                    }
                }
            }

        }

        ShowLines();
    }

    var _ClientLogTypingTimer;
    var _ClientLogDoneTypingInterval = 500;
    $('#_ClientLogSearch').keyup(function () {
        clearTimeout(_ClientLog");
            WriteLiteral("DoneTypingInterval);\r\n        _ClientLogTypingTimer = setTimeout(Search, _ClientLogDoneTypingInterval);\r\n    });\r\n    $(\'#_ClientLogSearch\').keydown(function () {\r\n        clearTimeout(Search);\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Client.ClientLogDetalhadoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
