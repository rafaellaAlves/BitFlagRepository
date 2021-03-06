#pragma checksum "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Shared\Components\PresentialSituation\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d666817c1a99ed541d26aeb1c6c6586a803c994"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PresentialSituation_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PresentialSituation/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d666817c1a99ed541d26aeb1c6c6586a803c994", @"/Views/Shared/Components/PresentialSituation/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d696fd1738781d019df1cdd42730c77709c1c8d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_PresentialSituation_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""row"">
    <div class=""col"">
        <table id=""PresentialSituationTable"" class=""display table table-striped table-bordered table-condensed"" style=""border-collapse: collapse !important; width:100%;"">
            <thead>
                <tr>
                    <th>M??dulo</th>
                    <th>S??bado</th>
                    <th>Domingo</th>
                    <th>Progresso (%)</th>
                    <th>Nota Prova</th>
                    <th>Nota Atividade</th>
                    <th>Observa????es</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
</div>
<script type=""text/javascript"">
        var datatables;
        $(document).ready(function () {
            datatables = $('#PresentialSituationTable').DataTable({
                serverSide: false,
                proccessing: true,
                searching: true,
                lengthChange: true,
                //dom: ");
            WriteLiteral("\'tip\',\r\n                ajax: {\r\n                    url: \'");
#nullable restore
#line 31 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Shared\Components\PresentialSituation\Default.cshtml"
                     Write(Url.Action("ListPresentialSituation", "ClassStudent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                    data: function (d) {\r\n                        d.classStudentId = \'");
#nullable restore
#line 33 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Shared\Components\PresentialSituation\Default.cshtml"
                                       Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    },
                    type: 'POST'
                },
                columns: [
                    { render: function (data, type, row) { return 'M??dulo ' + row.module; } },
                    { render: function (data, type, row) { return row.saturdayOptionPresence + (isNullOrWhiteSpace(row.saturdayDateFormatted) ? '' : ' (' + (row.saturdayDateFormatted) + ')'); } },
                    { render: function (data, type, row) { return row.sundayOptionPresence + (isNullOrWhiteSpace(row.sundayDateFormatted) ? '' : ' (' + (row.sundayDateFormatted) + ')'); } },
                    { render: function (data, type, row) { return row.completionPercent ?? ""-""; } },
                    { render: function (data, type, row) { return row.testGradeFormatted ?? ""-""; } },
                    { render: function (data, type, row) { return row.activityGradeFormatted ?? ""-""; } },
                    { render: function (data, type, row) { return row.comments ?? ""-""; } },
                    {
 ");
            WriteLiteral(@"                       render: function (data, type, row)
                        {
                            return '<div class=""text-center"">' +
                                '<a href=\'javascript:editSituation(' + JSON.stringify(row) + ')\'><span class=""badge badge-primary"">Editar</span></a>&nbsp;' +
                                '<a style = ""display: none;"" href=""javascript:removeSituation(' + row.studentPresenceId + ')""><span class=""badge badge-danger"">Excluir</span></a>' +
                                '</div>';
                        }
                    }
                ]
            });
        });

    function reloadPresentialSituationTable() {
        $('#PresentialSituationTable').DataTable().ajax.reload();
    }

    function editSituation(d) {
        $('[name=""StudentPresenceId""]').val(d.studentPresenceId);
        $('[name=""ClassStudentId""]').val(d.classStudentId);
        $('[name=""Module""]').val(d.module);
        $('[name=""CompletionPercent""]').val(d.completi");
            WriteLiteral(@"onPercent);
        $('[name=""Saturday""]').val(d.saturday);
        $('[name=""SaturdayDate""]').val(d.saturdayDateFormatted);
        $('[name=""SaturdayComments""]').val(d.saturdayComments);
        $('[name=""SundayDate""]').val(d.sundayDateFormatted);
        $('[name=""Sunday""]').val(d.sunday);
        $('[name=""SundayComments""]').val(d.sundayComments);
        $('[name=""TestGrade""]').val(d.testGradeFormatted);
        $('[name=""ActivityGrade""]').val(d.activityGradeFormatted);
        $('[name=""Comments""]').val(d.comments);

        $('#add-situation-modal').modal('show');
    }

    function removeSituation(studentPresenceId) {
        bootboxConfirm(""Deseja realmente excluir este item?"", function(result){
            if (!result) return;

            $.post('");
#nullable restore
#line 84 "C:\repositorios\bitflag\PortalDoAlunoPlatform\Application\PortalDoAluno\PortalDoAluno\Views\Shared\Components\PresentialSituation\Default.cshtml"
               Write(Url.Action("RemovePresentialSituation", "ClassStudent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\', { studentPresenceId }, function () {\r\n                alert(\'Presen??a exclu??da com sucesso!\');\r\n                reloadPresentialSituationTable();\r\n            });\r\n        });\r\n    }\r\n</script>\r\n");
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
