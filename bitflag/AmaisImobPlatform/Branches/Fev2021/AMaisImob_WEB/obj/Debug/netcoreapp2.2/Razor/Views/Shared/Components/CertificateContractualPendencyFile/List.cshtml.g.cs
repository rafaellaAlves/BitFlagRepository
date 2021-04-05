#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58db1d3d029cd7068142fa027669416a23483d61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CertificateContractualPendencyFile_List), @"mvc.1.0.view", @"/Views/Shared/Components/CertificateContractualPendencyFile/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CertificateContractualPendencyFile/List.cshtml", typeof(AspNetCore.Views_Shared_Components_CertificateContractualPendencyFile_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58db1d3d029cd7068142fa027669416a23483d61", @"/Views/Shared/Components/CertificateContractualPendencyFile/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CertificateContractualPendencyFile_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AMaisImob_DB.Models.CertificateContractualPendencyFile>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(69, 247, true);
            WriteLiteral("\r\n<table class=\"table table-striped table-condensed table-bordered w-100\" id=\"certificate-contractual-pendency-file-table\">\r\n    <thead>\r\n        <tr>\r\n            <td>Arquivo</td>\r\n            <td></td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 11 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(365, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(404, 13, false);
#line 14 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
               Write(item.FileName);

#line default
#line hidden
            EndContext();
            BeginContext(417, 72, true);
            WriteLiteral("</td>\r\n                <td style=\"width: 40px;\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 489, "\"", 611, 1);
#line 16 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
WriteAttributeValue("", 496, Url.Action("DownloadPendencyFile", "ContractualGuarantee", new { id = item.CertificateContractualPendencyFileId }), 496, 115, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(612, 104, true);
            WriteLiteral(" target=\"_blank\"><i class=\"fas fa-download\"></i></a>\r\n                    &nbsp;\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 716, "\"", 836, 6);
            WriteAttributeValue("", 723, "javascript:removeCertificateContractualPendencyFile(", 723, 52, true);
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
WriteAttributeValue("", 775, item.CertificateContractualPendencyFileId, 775, 42, false);

#line default
#line hidden
            WriteAttributeValue("", 817, ",", 817, 1, true);
            WriteAttributeValue(" ", 818, "\'", 819, 2, true);
#line 18 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
WriteAttributeValue("", 820, item.FileName, 820, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 834, "\')", 834, 2, true);
            EndWriteAttribute();
            BeginContext(837, 77, true);
            WriteLiteral("><i class=\"fas fa-trash\"></i></a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 21 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
        }

#line default
#line hidden
            BeginContext(925, 462, true);
            WriteLiteral(@"    </tbody>
</table>

<script type=""text/javascript"">
    var datatables = $('#certificate-contractual-pendency-file-table').DataTable({
        proccessing: true,
        serverSide: false,
        searching: true,
        lengthChange: false,
        dom: 'tip'
    });

    function removeCertificateContractualPendencyFile(id, name)
    {
        if (!confirm('Deseja realmente remover o arquivo \'' + name + '\'')) return;

        $.post('");
            EndContext();
            BeginContext(1388, 56, false);
#line 38 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\CertificateContractualPendencyFile\List.cshtml"
           Write(Url.Action("RemovePendencyFile", "ContractualGuarantee"));

#line default
#line hidden
            EndContext();
            BeginContext(1444, 209, true);
            WriteLiteral("\', { id }, function () {\r\n            if (typeof loadCertificateContractualPendencyFileListViewComponent == \'function\') loadCertificateContractualPendencyFileListViewComponent();\r\n        });\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AMaisImob_DB.Models.CertificateContractualPendencyFile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
