#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "368af2227db02a3c5e36d36784d2247659e11df6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Family_Index), @"mvc.1.0.view", @"/Views/Family/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Family/Index.cshtml", typeof(AspNetCore.Views_Family_Index))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"368af2227db02a3c5e36d36784d2247659e11df6", @"/Views/Family/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Family_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
  
    ViewData["Title"] = Model.ClientName + ", bem-vindo(a) ?? ??rvore geneal??gica da sua fam??lia!";


    var clientApplicants = (List<DB.ClientApplicant>)ViewBag.ClientApplicants;
    int clientApplicantId = (int)ViewBag.ClientApplicantId;

#line default
#line hidden
            BeginContext(308, 76, true);
            WriteLiteral("<div class=\"row\">\r\n\r\n    <div class=\"col-md-12 text-right\">\r\n        <div>\r\n");
            EndContext();
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
             if (User.Identity.IsAuthenticated)
            {


#line default
#line hidden
            BeginContext(450, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 468, "\"", 531, 3);
#line 19 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 475, Url.Action("Freeze", "Family"), 475, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 506, "?clientId=", 506, 10, true);
#line 19 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 516, Model.ClientId, 516, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(532, 115, true);
            WriteLiteral(" class=\"btn btn-primary float-right\"><i class=\"simple-icon-organization\"></i>&nbsp;Montar ??rvore de Or??amento</a>\r\n");
            EndContext();
#line 20 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(662, 212, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<p>\r\n    N??o se preocupe, nesse primeiro momento preencha com as informa????es que tiver em m??os e encaminhe as certid??es dispon??veis.\r\n</p>\r\n<hr />\r\n<ul class=\"nav nav-pills\">\r\n");
            EndContext();
#line 29 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
     foreach (var item in clientApplicants)
    {

#line default
#line hidden
            BeginContext(926, 31, true);
            WriteLiteral("        <li class=\"nav-item\">\r\n");
            EndContext();
#line 32 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
             if (clientApplicantId == item.ClientApplicantId)
            {

#line default
#line hidden
            BeginContext(1035, 68, true);
            WriteLiteral("                <a class=\"nav-link active\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1103, "\"", 1140, 2);
            WriteAttributeValue("", 1108, "nav-link-", 1108, 9, true);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1117, item.ClientApplicantId, 1117, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1141, "\"", 1197, 3);
            WriteAttributeValue("", 1151, "changeClientApplicant(", 1151, 22, true);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1173, item.ClientApplicantId, 1173, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 1196, ")", 1196, 1, true);
            EndWriteAttribute();
            BeginContext(1198, 39, true);
            WriteLiteral("><i class=\"simple-icon-user\"></i>&nbsp;");
            EndContext();
            BeginContext(1238, 13, false);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                                                                                                     Write(item.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(1251, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 35 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1305, 61, true);
            WriteLiteral("                <a class=\"nav-link\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1366, "\"", 1403, 2);
            WriteAttributeValue("", 1371, "nav-link-", 1371, 9, true);
#line 38 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1380, item.ClientApplicantId, 1380, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1404, "\"", 1460, 3);
            WriteAttributeValue("", 1414, "changeClientApplicant(", 1414, 22, true);
#line 38 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1436, item.ClientApplicantId, 1436, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 1459, ")", 1459, 1, true);
            EndWriteAttribute();
            BeginContext(1461, 39, true);
            WriteLiteral("><i class=\"simple-icon-user\"></i>&nbsp;");
            EndContext();
            BeginContext(1501, 13, false);
#line 38 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                                                                                              Write(item.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(1514, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 39 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1535, 15, true);
            WriteLiteral("        </li>\r\n");
            EndContext();
#line 41 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1557, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 42 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
     if (User.ClientCanAccessEdition())
    {

#line default
#line hidden
            BeginContext(1605, 62, true);
            WriteLiteral("        <li class=\"nav-item\">\r\n            <a class=\"nav-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1667, "\"", 1752, 1);
#line 45 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1674, Url.Action("NewClientApplicant", "Family", new { clientId = Model.ClientId }), 1674, 78, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1753, 75, true);
            WriteLiteral("><i class=\"simple-icon-plus\"></i>&nbsp;Novo Requerente</a>\r\n        </li>\r\n");
            EndContext();
#line 47 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1835, 7, true);
            WriteLiteral("</ul>\r\n");
            EndContext();
#line 49 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
 if (clientApplicants.Count > 1)
{

#line default
#line hidden
            BeginContext(1879, 60, true);
            WriteLiteral("    <div>\r\n        <input type=\"hidden\" id=\"removeApplicant\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1939, "\"", 1965, 1);
#line 52 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
WriteAttributeValue("", 1947, clientApplicantId, 1947, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1966, 148, true);
            WriteLiteral(" />\r\n        <a class=\"float-right\" href=\"#\" onclick=\"removeApplicant()\"><i class=\"simple-icon-close\"></i>&nbsp;Excluir Requerente</a>\r\n    </div>\r\n");
            EndContext();
#line 55 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2117, 1459, true);
            WriteLiteral(@"<br /><br />
<div id=""accordion"">
    <div class=""card"">
        <div class=""card-header"" id=""headingOne"">
            <h5 class=""mb-0"">
                <button class=""btn btn-link"" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                    <h5><i class=""simple-icon-organization""></i>&nbsp;Genealogia</h5>
                </button>
            </h5>
        </div>
        <div id=""collapseOne"" class=""collapse"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
            <div class=""card-body"">
                <div id=""_FamilyInfoManageViewComponent""></div>
            </div>
        </div>
    </div>
    <br />
    <div class=""card"">
        <div class=""card-header"" id=""headingTwo"">
            <h5 class=""mb-0"">
                <button class=""btn btn-link"" data-toggle=""collapse"" data-target=""#collapseTwo"" aria-expanded=""false"" aria-controls=""collapseTwo"">
                    <h5><i class=""simple-icon-folder-alt""></i>&nbsp;A");
            WriteLiteral(@"rquivos do requerente</h5>
                </button>
            </h5>
        </div>
        <div id=""collapseTwo"" class=""collapse"" aria-labelledby=""headingTwo"" data-parent=""#accordion"">
            <div class=""card-body"">
                <div id=""_ClientArchiveIndexViewComponent""></div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    $('#_FamilyInfoManageViewComponent').load('");
            EndContext();
            BeginContext(3577, 53, false);
#line 90 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                          Write(Url.Action("FamilyInfoManageViewComponent", "Family"));

#line default
#line hidden
            EndContext();
            BeginContext(3630, 16, true);
            WriteLiteral("\', { clientId: \'");
            EndContext();
            BeginContext(3647, 14, false);
#line 90 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(3661, 23, true);
            WriteLiteral("\', clientApplicantId: \'");
            EndContext();
            BeginContext(3685, 17, false);
#line 90 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                                                      Write(clientApplicantId);

#line default
#line hidden
            EndContext();
            BeginContext(3702, 333, true);
            WriteLiteral(@"'}, function () {
        $('.date').datepicker({
            format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true, onSelect: function (dateText, inst, elem) {
                $(elem.el).change();
            }
        });
        $('.date').mask('99/99/9999');
    });

    $('#_ClientArchiveIndexViewComponent').load('");
            EndContext();
            BeginContext(4036, 46, false);
#line 99 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                            Write(Url.Action("ClientArchiveComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(4082, 15, true);
            WriteLiteral("\', {clientId: \'");
            EndContext();
            BeginContext(4098, 14, false);
#line 99 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                          Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(4112, 23, true);
            WriteLiteral("\', clientApplicantId: \'");
            EndContext();
            BeginContext(4136, 17, false);
#line 99 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                                                Write(clientApplicantId);

#line default
#line hidden
            EndContext();
            BeginContext(4153, 399, true);
            WriteLiteral(@"'});

    function changeClientApplicant(clientApplicantId) {
        $.each($('.nav-link'), function (i, e) {
            $(e).removeClass('active');
        });

        $('#removeApplicant').val(clientApplicantId);

        $('#nav-link-' + clientApplicantId).addClass('active');
        $('#_FamilyInfoManageViewComponent').empty();
        $('#_FamilyInfoManageViewComponent').load('");
            EndContext();
            BeginContext(4553, 53, false);
#line 110 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                              Write(Url.Action("FamilyInfoManageViewComponent", "Family"));

#line default
#line hidden
            EndContext();
            BeginContext(4606, 16, true);
            WriteLiteral("\', { clientId: \'");
            EndContext();
            BeginContext(4623, 14, false);
#line 110 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                                    Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(4637, 360, true);
            WriteLiteral(@"', clientApplicantId: clientApplicantId }, function () {
            $('.date').datepicker({
                format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true, onSelect: function (dateText, inst, elem) {
                    $(elem.el).change();
                }
            });
        });

        $('#_ClientArchiveIndexViewComponent').load('");
            EndContext();
            BeginContext(4998, 46, false);
#line 118 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                Write(Url.Action("ClientArchiveComponent", "Client"));

#line default
#line hidden
            EndContext();
            BeginContext(5044, 15, true);
            WriteLiteral("\', {clientId: \'");
            EndContext();
            BeginContext(5060, 14, false);
#line 118 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                                                                                                              Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(5074, 334, true);
            WriteLiteral(@"', clientApplicantId: clientApplicantId});
    }

    function removeApplicant() {
        if (IsNullOrWhiteSpace($('#removeApplicant').val())) {
            alert('Houve um erro na exclus??o, recarre a p??gina e tente novamente.');
            return;
        }

        $('#loading').show();
        window.location.href = '");
            EndContext();
            BeginContext(5409, 30, false);
#line 128 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Index.cshtml"
                           Write(Url.Action("Remove", "Family"));

#line default
#line hidden
            EndContext();
            BeginContext(5439, 71, true);
            WriteLiteral("?clientApplicantId=\' + $(\'#removeApplicant\').val();\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Client.ClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
