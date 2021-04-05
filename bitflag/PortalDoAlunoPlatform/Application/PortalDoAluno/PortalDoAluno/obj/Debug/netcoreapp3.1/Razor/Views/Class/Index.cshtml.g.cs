#pragma checksum "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd55e48ac41dbf3a147f46141d41b9f7d81f04a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Index), @"mvc.1.0.view", @"/Views/Class/Index.cshtml")]
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
#line 1 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd55e48ac41dbf3a147f46141d41b9f7d81f04a1", @"/Views/Class/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d696fd1738781d019df1cdd42730c77709c1c8d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Class_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Class.ClassViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
  
    ViewData["Title"] = "Turmas Cadastradas";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("HeaderButtons", async() => {
                WriteLiteral("\r\n    <button id=\"add-class-button-modal\" class=\"btn btn-success\"><i class=\"simple-icon-plus\"></i>&nbsp;Nova Turma</button>\r\n");
            }
            );
            WriteLiteral(@"
<table id=""classIndexTable"" class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
    <thead>
        <tr>
            <th>Descrição da Turma</th>
            <th>Quantidade de Alunos</th>
");
            WriteLiteral("            <th>&nbsp;</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody></tbody>\r\n</table>\r\n\r\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
    <div class=""modal fade"" id=""add-class-modal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"" style=""display: none;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Incluir nova turma</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">×</span></button>
                </div>
                <div class=""modal-body"">
                    <form id=""add-class-form"">
                        <div class=""form-group"">
                            <label class=""control-label"">Curso</label>
                            <select name=""CourseId"" class=""form-control"">
");
#nullable restore
#line 38 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                 foreach (var item in await courseService.List())
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <option data-default-module-count=\"");
#nullable restore
#line 40 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                                                  Write(item.DefaultModuleCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("value", " value=\"", 1841, "\"", 1863, 1);
#nullable restore
#line 40 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
WriteAttributeValue("", 1849, item.CourseId, 1849, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 40 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                                                                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</option>\r\n");
#nullable restore
#line 41 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </div>
                        <div class=""form-group"" style=""display: none;"">
                            <label class=""control-label required"">Módulos</label>
                            <input name=""ModuleCount"" type=""number"" required class=""form-control"" />
                        </div>
                        <div class=""form-group"">
                            <label class=""control-label"">Estado</label>
                            <select name=""State"" class=""form-control"">
                                <option value=""AC"">Acre</option>
                                <option value=""AL"">Alagoas</option>
                                <option value=""AP"">Amapá</option>
                                <option value=""AM"">Amazonas</option>
                                <option value=""BA"">Bahia</option>
                                <option value=""CE"">Ceará</option>
                                <option value=""DF"">Distrito Fe");
                WriteLiteral(@"deral</option>
                                <option value=""ES"">Espírito Santo</option>
                                <option value=""GO"">Goiás</option>
                                <option value=""MA"">Maranhão</option>
                                <option value=""MT"">Mato Grosso</option>
                                <option value=""MS"">Mato Grosso do Sul</option>
                                <option value=""MG"">Minas Gerais</option>
                                <option value=""PA"">Pará</option>
                                <option value=""PB"">Paraíba</option>
                                <option value=""PR"">Paraná</option>
                                <option value=""PE"">Pernambuco</option>
                                <option value=""PI"">Piauí</option>
                                <option value=""RJ"">Rio de Janeiro</option>
                                <option value=""RN"">Rio Grande do Norte</option>
                                <option value=""RS"">Rio Grande do Sul<");
                WriteLiteral(@"/option>
                                <option value=""RO"">Rondônia</option>
                                <option value=""RR"">Roraima</option>
                                <option value=""SC"">Santa Catarina</option>
                                <option value=""SP"">São Paulo</option>
                                <option value=""SE"">Sergipe</option>
                                <option value=""TO"">Tocantins</option>
                            </select>
                        </div>
                        <div class=""form-group"">
                            <label class=""control-label required"">Ano</label>
                            <input type=""text"" name=""Year"" class=""form-control year"" placeholder=""Ano"" />
                        </div>
                        <div class=""form-group"">
                            <label class=""control-label"">Observações</label>
                            <select name=""Info"" class=""form-control"">
");
#nullable restore
#line 87 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                 for (int i = 1; i <= 9; i++)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <option");
                BeginWriteAttribute("value", " value=\"", 5084, "\"", 5118, 1);
#nullable restore
#line 89 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
WriteAttributeValue("", 5092, string.Format("({0})", i), 5092, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 89 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                                                          Write(string.Format("({0})", i));

#line default
#line hidden
#nullable disable
                WriteLiteral("</option>\r\n");
#nullable restore
#line 90 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </div>
                    </form>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Fechar</button>
                    <button id=""add-class-button"" type=""button"" class=""btn btn-primary"">Salvar</button>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        var currentYear = parseInt(\'");
#nullable restore
#line 106 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                               Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
        $('#add-class-button-modal').click(function () {
            $('#add-class-modal').modal('show');
        });
        $('#add-class-button').click(function () {
            if (!validateInputs('add-class-form')) return;

            if (!isNullOrWhiteSpace($('[name=""ModuleCount""]').val()) && parseInt($('[name=""ModuleCount""]').val()) <= 0) {
                $('[name=""ModuleCount""]').after('<div class=""text-danger"">Preencha uma quantidade válida.</div>');
                return;
            }

            if (!isNullOrWhiteSpace($('[name=""Year""]').val()) && parseInt($('[name=""Year""]').val()) < currentYear) {
                $('[name=""Year""]').after('<div class=""text-danger"">O ano deve ser igual ou posterior a ' + currentYear + '</div>');
                return;
            }

            var model = $('#add-class-form').serializeArray();
            $.post('");
#nullable restore
#line 124 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
               Write(Url.Action("Add", "Class"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', model, function (d) {
                if (d.hasError) {
                    alert('Houve um erro ao criar a turma.');
                } else {
                    alert(d.message);
                    $('#classIndexTable').DataTable().ajax.reload();
                    $('#add-class-modal').modal('hide');
                }
            });
        });
        $('select[name=""CourseId""]').change(function () {
            $('input[name=""ModuleCount""').val($('select[name=""CourseId""] option:selected').data('default-module-count'));
        }).change();
    </script>
    <script type=""text/javascript"">
        var datatables;
        $(document).ready(function () {
            datatables = $('#classIndexTable').DataTable({
                serverSide: false,
                proccessing: true,
                searching: true,
                lengthChange: true,
                order: [],
                //dom: 'tip',
                ajax: {
                    url: '");
#nullable restore
#line 149 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                     Write(Url.Action("List", "Class"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type: 'GET'
                },
                columns: [
                    { render: function (data, type, row) { return row.classFullName; } },
                    { render: function (data, type, row) { return row.studentsCount; } },
                    //{ render: function (data, type, row) { return row.moduleCount; } },
                    { render: function (data, type, row) { return '<div class=""text-center""><a href=""");
#nullable restore
#line 156 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Class\Index.cshtml"
                                                                                                Write(Url.Action("Index", "ClassStudent"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?classId=\' + row.classId + \'\"><span class=\"badge badge-primary\">Matriculados</span></a></div>\'; } }\r\n                ]\r\n            });\r\n        });\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Course.CourseService courseService { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Class.ClassViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
