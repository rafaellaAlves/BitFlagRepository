#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce52af2c0dab22e90e6a020626e1058106bb1454"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Family_Freeze), @"mvc.1.0.view", @"/Views/Family/Freeze.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Family/Freeze.cshtml", typeof(AspNetCore.Views_Family_Freeze))]
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
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce52af2c0dab22e90e6a020626e1058106bb1454", @"/Views/Family/Freeze.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Family_Freeze : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Client.ClientViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
  
    ViewData["Title"] = "Gerar Nova ??rvore de Or??amento";



#line default
#line hidden
            BeginContext(123, 517, true);
            WriteLiteral(@"<div class=""alert alert-primary"">
    Selecione na tabela abaixo os membros da fam??lia que ser??o parte dessa vers??o da ??rvore de or??amento.
</div>
<div class=""alert alert-danger"" id=""alert-error"" style=""display:none;"">
    <span id=""alert-error-text""></span>
</div>
<div class=""alert alert-success"" id=""alert-success"" style=""display:none;"">
    <b>??rvore gerada com sucesso!</b>
</div>
<div id=""_FamilyFreezeManageViewComponent""></div>
<div class=""row"">
    <div class=""col-12"">
        <hr />
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 640, "\"", 702, 3);
#line 21 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
WriteAttributeValue("", 647, Url.Action("Index", "Family"), 647, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 677, "?clientId=", 677, 10, true);
#line 21 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
WriteAttributeValue("", 687, Model.ClientId, 687, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(703, 94, true);
            WriteLiteral(" class=\"btn btn-secondary pull-left\"><i class=\"simple-icon-action-undo\"></i>&nbsp;Voltar</a>\r\n");
            EndContext();
#line 22 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
         if (!User.InvoiceCanAccessEdition())
        {

#line default
#line hidden
            BeginContext(855, 191, true);
            WriteLiteral("            <button class=\"btn btn-primary float-right\" id=\"FamilyFreezeSaveButton\" style=\"display:none\">Gerar Nova ??rvore de Or??amento&nbsp;<i class=\"simple-icon-action-redo\"></i></button>\r\n");
            EndContext();
#line 25 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1082, 170, true);
            WriteLiteral("            <button class=\"btn btn-primary float-right\" id=\"FamilyFreezeSaveButton\">Gerar Nova ??rvore de Or??amento&nbsp;<i class=\"simple-icon-action-redo\"></i></button>\r\n");
            EndContext();
#line 29 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
        }

#line default
#line hidden
            BeginContext(1263, 104, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_FamilyFreezeManageViewComponent\').load(\'");
            EndContext();
            BeginContext(1368, 55, false);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
                                            Write(Url.Action("FamilyFreezeManageViewComponent", "Family"));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 16, true);
            WriteLiteral("\', { clientId: \'");
            EndContext();
            BeginContext(1440, 14, false);
#line 34 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
                                                                                                                    Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(1454, 522, true);
            WriteLiteral(@"' });

    function FamilyFreezeValidation() {
        var hasError = false;

        if ($('#FamilyFreezeForm input:checked').length == 0) {
            $('#alert-error-text').text('Selecione ao menos um item.');
            $('html, body').animate({ scrollTop: 0 }, 'slow');
            $('#alert-error').show().fadeOut(5000);
            hasError = true;
        }

        return !hasError;
    }

    function FamilyFreezeSave() {
        var data = [];
        data.push({ name: 'clientId', value: '");
            EndContext();
            BeginContext(1977, 14, false);
#line 51 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
                                         Write(Model.ClientId);

#line default
#line hidden
            EndContext();
            BeginContext(1991, 414, true);
            WriteLiteral(@"' });

        $.each($('#FamilyFreezeForm input:checked'), function (i, e) {
            data.push({ name: '[' + i + '].FamilyMemberId', value: $(e).val() });
            data.push({ name: '[' + i + '].ClientApplicantId', value: $(e).data('client-applicant-id') });
            data.push({ name: '[' + i + '].FamilyMemberTypeId', value: $(e).data('family-member-type-id') });
        });

        $.post('");
            EndContext();
            BeginContext(2406, 36, false);
#line 59 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
           Write(Url.Action("FreezeFamily", "Family"));

#line default
#line hidden
            EndContext();
            BeginContext(2442, 93, true);
            WriteLiteral("\', data, function (d) {\r\n            if (d > 0) {\r\n                document.location.href = \'");
            EndContext();
            BeginContext(2536, 31, false);
#line 61 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
                                     Write(Url.Action("Manage", "Invoice"));

#line default
#line hidden
            EndContext();
            BeginContext(2567, 10, true);
            WriteLiteral("?clientId=");
            EndContext();
            BeginContext(2578, 33, false);
#line 61 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Family\Freeze.cshtml"
                                                                               Write(Context.Request.Query["clientId"]);

#line default
#line hidden
            EndContext();
            BeginContext(2611, 361, true);
            WriteLiteral(@"&freezedFamilyId=' + d + '&saved=true';
            } else {
                alert('Houve um erro ao gerar a ??rvore de or??amento.');
                return false;
            }
        });
    }

    $('#FamilyFreezeSaveButton').click(function () {
        if (FamilyFreezeValidation()) {
            FamilyFreezeSave();
        }
    });
</script>");
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
