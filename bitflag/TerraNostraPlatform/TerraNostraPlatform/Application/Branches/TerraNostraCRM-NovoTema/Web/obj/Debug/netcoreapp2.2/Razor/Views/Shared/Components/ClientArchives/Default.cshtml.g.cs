#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "253074b82c37dad60a0ce69fbc9fddffaf8d5f1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ClientArchives_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ClientArchives/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ClientArchives/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_ClientArchives_Default))]
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
#line 3 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"253074b82c37dad60a0ce69fbc9fddffaf8d5f1d", @"/Views/Shared/Components/ClientArchives/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ClientArchives_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_RepresentativeListForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(12, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
  
    ViewData["Title"] = "Arquivos";
    int? clientApplicantId = null;

    if (ViewBag.clientApplicantId != null)
    {
        clientApplicantId = (int)ViewBag.clientApplicantId;
    }

#line default
#line hidden
            BeginContext(235, 123, true);
            WriteLiteral("<style type=\"text/css\">\r\n    tr.group,\r\n    tr.group:hover {\r\n        background-color: #ddd !important;\r\n    }\r\n</style>\r\n");
            EndContext();
            BeginContext(358, 7882, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "253074b82c37dad60a0ce69fbc9fddffaf8d5f1d4970", async() => {
                BeginContext(393, 27, true);
                WriteLiteral("\r\n    <div class=\"row\">\r\n\r\n");
                EndContext();
#line 23 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
         if (User.ClientCanAccessEdition())
        {

#line default
#line hidden
                BeginContext(476, 643, true);
                WriteLiteral(@"            <div class=""col-md-10"">
                <div class=""input-group mb-3"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text""><i class=""simple-icon-magnifier""></i></span>
                    </div>
                    <input id=""_AttachmentListSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
                </div>
            </div>
            <div class=""col-md-2"">
                <a href=""#"" class=""btn btn-success w-100"" data-toggle=""modal"" data-target=""#AttachmentModal""><i class=""simple-icon-plus""></i>&nbsp;Novo</a>
            </div>
");
                EndContext();
#line 36 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(1155, 430, true);
                WriteLiteral(@"            <div class=""col-md-12"">
                <div class=""input-group mb-3"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text""><i class=""simple-icon-magnifier""></i></span>
                    </div>
                    <input id=""_AttachmentListSearch"" type=""text"" class=""form-control"" placeholder=""Procurar..."" />
                </div>
            </div>
");
                EndContext();
#line 47 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
        }

#line default
#line hidden
                BeginContext(1596, 376, true);
                WriteLiteral(@"    </div>
    <hr />
    <div class=""table-wrapper"">
        <table id=""_AttachmentListTable"" class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Tamanho</th>
                    <th>Data</th>
");
                EndContext();
#line 57 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                     if (User.ClientCanAccessEdition())
                    {

#line default
#line hidden
                BeginContext(2052, 41, true);
                WriteLiteral("                        <th>&nbsp;</th>\r\n");
                EndContext();
#line 60 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                    }

#line default
#line hidden
                BeginContext(2116, 174, true);
                WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody></tbody>\r\n        </table>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2290, "\"", 2327, 1);
#line 67 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
WriteAttributeValue("", 2297, Url.Action("Index", "Client"), 2297, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2328, 333, true);
                WriteLiteral(@" class=""btn btn-secondary""><i class=""simple-icon-arrow-left""></i> Voltar</a>
            </div>
        </div>
    </div>
    <script type=""text/javascript"">
        var attachmentIds = [];
        var _id;
        var _AttachmentListTypingTimer;
        var _AttachmentListDoneTypingInterval = 500;
        d = { ownerId: '");
                EndContext();
                BeginContext(2662, 5, false);
#line 76 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                   Write(Model);

#line default
#line hidden
                EndContext();
                BeginContext(2667, 33, true);
                WriteLiteral("\', clientApplicantId: null };\r\n\r\n");
                EndContext();
#line 78 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
         if (clientApplicantId.HasValue)
        {
            

#line default
#line hidden
                BeginContext(2771, 32, true);
                WriteLiteral("\r\n        d.clientApplicantId = ");
                EndContext();
                BeginContext(2804, 17, false);
#line 81 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                         Write(clientApplicantId);

#line default
#line hidden
                EndContext();
                BeginContext(2821, 15, true);
                WriteLiteral(";\r\n            ");
                EndContext();
#line 82 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                   
        }

#line default
#line hidden
                BeginContext(2856, 349, true);
                WriteLiteral(@"        var _AttachmentListDatatables = $('#_AttachmentListTable').DataTable({
            order: [[2, 'asc']],
            drawCallback: function (settings) {
            SetTooltip();
        },
		proccessing: true,
		serverSide: true,
		searching: true,
		lengthChange: false,
        dom: 'tip',
            ajax: {
            url: '");
                EndContext();
                BeginContext(3206, 36, false);
#line 95 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
             Write(Url.Action("ListArchives", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(3242, 476, true);
                WriteLiteral(@"',
                type: 'POST',
                data: d
        },
		columns: [
            {
            data: 'Name',
                render: function (data, type, row) {
                    var _id = row.clientArchiveId;
                    if (row.isImage) {
                        var index = attachmentIds.indexOf(_id);
                        if (index === -1) attachmentIds.push(_id);
                    var imgTag = ""<img width='100' height='100' src='");
                EndContext();
                BeginContext(3719, 37, false);
#line 107 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(3756, 75, true);
                WriteLiteral("?id=\" + _id + \"\'>\";\r\n                    return \'<div><a class=\"pop\" href=\"");
                EndContext();
                BeginContext(3832, 37, false);
#line 108 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                 Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(3869, 184, true);
                WriteLiteral("?id=\' + _id + \'\" data-popover=\"true\" data-html=true data-content=\"\' + imgTag + \'\" >\' + row.name + \'</a></div>\';\r\n                            }\r\n\r\n                return \'<div><a href=\"");
                EndContext();
                BeginContext(4054, 37, false);
#line 111 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                 Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(4091, 563, true);
                WriteLiteral(@"?id=' + _id + '""  id=""' + _id + '"">' + row.name + '</a></div>';
            }
                    },
            {
            data: 'Length',
                render: function (data, type, row) {
                        return '<div> ' + (row.length / 1000000).toFixed(2) + ' MB</div>';
                    }
                },
            {
                data: 'CreatedDate',
                render: function (data, type, row) {
                    console.log(row);
                    return row._CreatedDate;
                }
            }
");
                EndContext();
#line 127 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
             if(User.ClientCanAccessEdition())
            {
                

#line default
#line hidden
                BeginContext(4739, 482, true);
                WriteLiteral(@"
            , {
                orderable: false,
                data: 'ClientArchiveId',
                render: function (data, type, row) {
                    console.log(row);
                    var _id = row.clientArchiveId;
                    return '<div class=""text-center""><a href=""javascript:void(0)"" onclick=""_AttachmentListRemove(' + _id + ')"" title=""Excluir"" ><i class=""simple-icon-trash""></i></a></div>';
                }
            }
                ");
                EndContext();
#line 139 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                       
            }

#line default
#line hidden
                BeginContext(5245, 2602, true);
                WriteLiteral(@"		]
        });


        function SetTooltip() {
            $('.pop').popover({
                selector: '[data-popover]',
                placement: 'top',
                trigger: 'manual',
                html: true,
                animation: false
            }).on('mouseenter', function () {
                var _this = this;
                $(this).popover('show');
                $('.popover').on('mouseleave', function () {
                    $(_this).popover('hide');
                });
            }).on('mouseleave', function () {
                var _this = this;
                setTimeout(function () {
                    if (!$('.popover:hover').length) {
                        $(_this).popover('hide');
                    }
                }, 100);
            });
        }

        $('#_AttachmentListTable tbody').on('click', 'tr.group', function () {
            var currentOrder = table.order()[0];
            if (currentOrder[0] === _AttachmentGroupColumn && c");
                WriteLiteral(@"urrentOrder[1] === 'asc') {
                table.order([_AttachmentGroupColumn, 'desc']).draw();
            }
            else {
                table.order([_AttachmentGroupColumn, 'asc']).draw();
            }
        });

    function _AttachmentListDoneTyping() {
        if ($.fn.DataTable.isDataTable('#_AttachmentListTable')) {
            _AttachmentListDatatables.search($('#_AttachmentListSearch').val()).draw();
        }
    }

        $('#_AttachmentListSearch').keyup(function () {
            clearTimeout(_AttachmentListTypingTimer);
            _AttachmentListTypingTimer = setTimeout(_AttachmentListDoneTyping, _AttachmentListDoneTypingInterval);
    });

        $('#_AttachmentListSearch').keydown(function () {
            clearTimeout(_AttachmentListTypingTimer);
    });


        function _AttachmentListRemove(ownerId) {
		if (confirm(""Deseja realmente excluir este anexo?"")) {
            __AttachmentListRemove(ownerId, function (d) {
                if (d) {
       ");
                WriteLiteral(@"             $('#_AttachmentListTable').DataTable().ajax.reload();
                    alert(""Anexo exclu??do com sucesso!"");
                    index = attachmentIds.indexOf(ownerId);
                    if (index !== -1)
                        attachmentIds.splice(index, 1);
                } else {
                    alert(""Houve um erro ao excluir o anexo"");
                }
			});
		}
	}

        function __AttachmentListRemove(_ownerId, callback) {
            var d = { id: _ownerId };
            $.ajax({
            url: '");
                EndContext();
                BeginContext(7848, 40, false);
#line 213 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
             Write(Url.Action("RemoveAttachment", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(7888, 216, true);
                WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\',\r\n\t\t\tsuccess: callback\r\n\t\t});\r\n        }\r\n\r\n        function AttachmentCallBack(ownerId) {\r\n            var d = { id: ownerId };\r\n\t\t\t$.ajax({\r\n            url: \'");
                EndContext();
                BeginContext(8105, 37, false);
#line 224 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
             Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
                EndContext();
                BeginContext(8142, 91, true);
                WriteLiteral("\',\r\n\t\t\ttype: \'POST\',\r\n\t\t\tdata: d,\r\n\t\t\tdataType: \'Json\'\r\n\t\t});\r\n        }\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8240, 1618, true);
            WriteLiteral(@"
<div class=""modal fade"" id=""AttachmentModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h6 class=""tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold"">Gerenciar Anexo</h6>
                <button type=""button"" id=""AttachmentCloseButton"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""AttachmentViewComponent"">
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-6"">
                    <button class=""btn btn-secondary"" data-dismiss=""modal"" aria-label=""Close""><i class=""simple-icon-action-undo""></i>&nbsp;Voltar</button>
                </div>
                <div class=""col-md-6 text-right"">
                    <a href=""#"" class=""btn btn-success float-right"" id=""");
            WriteLiteral(@"AttachmentSaveButton""><i class=""simple-icon-cloud-upload""></i>&nbsp;Criar</a>
                </div>
            </div>
            <script type=""text/javascript"">

                $('#AttachmentSaveButton').click(function () {
                    if (_AttachmentManagementValidate()) {
                        _AttachmentManagementSave();
                        $('#_AttachmentListTable').DataTable().ajax.reload();
                    }
                });
                $('#AttachmentViewComponent').ready(function () {
                    $('#AttachmentViewComponent').load('");
            EndContext();
            BeginContext(9859, 52, false);
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                   Write(Url.Action("ClientArchiveManageComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(9911, 18, true);
            WriteLiteral("\', { \"clientId\": \"");
            EndContext();
            BeginContext(9930, 5, false);
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                                                                          Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(9935, 24, true);
            WriteLiteral("\", \'clientApplicantId\': ");
            EndContext();
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                                                                                                              if(clientApplicantId.HasValue) { 

#line default
#line hidden
            BeginContext(9999, 1, true);
            WriteLiteral("\'");
            EndContext();
            BeginContext(10001, 17, false);
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                                                                                                                                                 Write(clientApplicantId);

#line default
#line hidden
            EndContext();
            BeginContext(10018, 1, true);
            WriteLiteral("\'");
            EndContext();
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                                                                                                                                                                                 }else{ 

#line default
#line hidden
            BeginContext(10040, 4, true);
            WriteLiteral("null");
            EndContext();
#line 261 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                                                                                                                                                                                                                          }

#line default
#line hidden
            BeginContext(10053, 454, true);
            WriteLiteral(@" });
                });
                function CloseAttachmentModal() {
                    $('#AttachmentCloseButton').click();
                }
            </script>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function OpenImg(id) {
        if (attachmentIds.length == 1) {
            $('#imgcontainer').show();
            $('#carouselExampleControls').hide();
            $('#imgcontainer').attr('src', '");
            EndContext();
            BeginContext(10508, 37, false);
#line 276 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                       Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(10545, 308, true);
            WriteLiteral(@"?id=' + id);
        }
        else {
            $('#imgcontainer').hide();
            $('#carouselExampleControls').show();
            $('#carouselContents').empty();
            $('#carouselContents').append('<div class=""carousel-item active"">' +
                '<img class=""d-block w-100"" src=""");
            EndContext();
            BeginContext(10854, 37, false);
#line 283 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                            Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(10891, 357, true);
            WriteLiteral(@"?id=' + id + '"" style=""min-width:200px;min-height:200px; max-width:400px;max-height:400px;"">' +
                    '</div>');
            $.each(attachmentIds, function (i, e) {
                if (e == id) return true;
                $('#carouselContents').append('<div class=""carousel-item"">' +
                    '<img class=""d-block w-100"" src=""");
            EndContext();
            BeginContext(11249, 37, false);
#line 288 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\ClientArchives\Default.cshtml"
                                                Write(Url.Action("GetAttachment", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(11286, 1357, true);
            WriteLiteral(@"?id=' + e + '"" style=""min-width:200px;min-height:200px; max-width:400px;max-height:400px;"">' +
                    '</div>');
            });
        }

        $('#ImgModal').modal('show');
    }
</script>

<div class=""modal fade"" id=""ImgModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div>
            <img id=""imgcontainer"" style=""min-width:200px;min-height:200px; max-width:400px;max-height:400px; display:none;"">
            <div id=""carouselExampleControls"" class=""carousel "" data-ride=""carousel"" style=""display:none;"">
                <div class=""carousel-inner"" id=""carouselContents"">
                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button"" data-slide=""prev"">
                    <span style=""color:black;"" class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a clas");
            WriteLiteral(@"s=""carousel-control-next"" href=""#carouselExampleControls"" role=""button"" data-slide=""next"">
                    <span style=""color:black;"" class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
