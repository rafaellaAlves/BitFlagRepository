#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09fc09e304fdfc4a23169319b86b884e9cfaf6cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FreezedFamily_Manage), @"mvc.1.0.view", @"/Views/FreezedFamily/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FreezedFamily/Manage.cshtml", typeof(AspNetCore.Views_FreezedFamily_Manage))]
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
#line 3 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
using Web.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09fc09e304fdfc4a23169319b86b884e9cfaf6cb", @"/Views/FreezedFamily/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_FreezedFamily_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.FreezedFamily.FreezedFamilyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
  
    ViewData["Title"] = "Aprovação de Árvore";
    ViewData["SubTitle"] = "Cliente <b>" + Model.ClientName + "</b> gerada por <b>" + Model._CreatedBy + "</b> em <b>" + Model._CreatedDate + "</b>";

#line default
#line hidden
            BeginContext(277, 55, true);
            WriteLiteral("<div>\r\n    <h2 class=\"mb-2\" style=\"font-size:25px;\"><b>");
            EndContext();
            BeginContext(333, 16, false);
#line 10 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                                           Write(Model.ClientName);

#line default
#line hidden
            EndContext();
            BeginContext(349, 27, true);
            WriteLiteral("</b></h2>\r\n</div>\r\n<br />\r\n");
            EndContext();
#line 13 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
 if (Model.AcceptedBy.HasValue && Model.Accepted.Value)
{

#line default
#line hidden
            BeginContext(436, 73, true);
            WriteLiteral("    <div class=\"alert alert-success\">\r\n        <b>Árvore aprovada por <b>");
            EndContext();
            BeginContext(510, 17, false);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                             Write(Model._AcceptedBy);

#line default
#line hidden
            EndContext();
            BeginContext(527, 11, true);
            WriteLiteral("</b> em <b>");
            EndContext();
            BeginContext(539, 19, false);
#line 16 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                                                          Write(Model._AcceptedDate);

#line default
#line hidden
            EndContext();
            BeginContext(558, 23, true);
            WriteLiteral("</b>.</b>\r\n    </div>\r\n");
            EndContext();
#line 18 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
}

#line default
#line hidden
#line 19 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
 if (Model.AcceptedBy.HasValue && !Model.Accepted.Value)
{

#line default
#line hidden
            BeginContext(645, 73, true);
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        <b>Árvore reprovada por <b>");
            EndContext();
            BeginContext(719, 17, false);
#line 22 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                              Write(Model._AcceptedBy);

#line default
#line hidden
            EndContext();
            BeginContext(736, 11, true);
            WriteLiteral("</b> em <b>");
            EndContext();
            BeginContext(748, 19, false);
#line 22 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                                                           Write(Model._AcceptedDate);

#line default
#line hidden
            EndContext();
            BeginContext(767, 23, true);
            WriteLiteral("</b>.</b>\r\n    </div>\r\n");
            EndContext();
#line 24 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
}

#line default
#line hidden
            BeginContext(793, 154, true);
            WriteLiteral("<div id=\"_FreezedFamilyManageViewComponent\"></div>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <a class=\"btn btn-secondary text-white\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 947, "\"", 991, 1);
#line 29 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
WriteAttributeValue("", 954, Url.Action("Index", "FreezedFamily"), 954, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(992, 70, true);
            WriteLiteral("><i class=\"simple-icon-action-undo\"></i>&nbsp;Voltar</a>\r\n    </div>\r\n");
            EndContext();
#line 31 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
     if (!Model.AcceptedBy.HasValue && User.FreezedFamilyCanAccessEdition())
    {

#line default
#line hidden
            BeginContext(1147, 455, true);
            WriteLiteral(@"        <div class=""col-md-6"">
            <div class=""btn-group float-right"" role=""group"">
                <a href=""javascript:void(0)"" id=""FreezeFamilyReproveButton"" class=""btn btn-danger text-white""><i class=""simple-icon-close""></i>&nbsp;Reprovar</a>
                <a href=""javascript:void(0)"" id=""FreezeFamilyAcceptButton"" class=""btn btn-success text-white""><i class=""simple-icon-check""></i>&nbsp;Aprovar</a>
            </div>
        </div>
");
            EndContext();
#line 39 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
    }

#line default
#line hidden
            BeginContext(1609, 93, true);
            WriteLiteral("</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#_FreezedFamilyManageViewComponent\').load(\'");
            EndContext();
            BeginContext(1703, 59, false);
#line 43 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                                             Write(Url.Action("FreezedFamilyManageComponent", "FreezedFamily"));

#line default
#line hidden
            EndContext();
            BeginContext(1762, 25, true);
            WriteLiteral("\', { \'freezedFamilyId\': \'");
            EndContext();
            BeginContext(1788, 21, false);
#line 43 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                                                                                                                                  Write(Model.FreezedFamilyId);

#line default
#line hidden
            EndContext();
            BeginContext(1809, 170, true);
            WriteLiteral("\'});\r\n\r\n    $(\'#FreezeFamilyAcceptButton\').click(function () {\r\n        if (!confirm(\'Deseja realmente aprovar esta árvore?\')) return;\r\n\r\n        window.location.href = \'");
            EndContext();
            BeginContext(1980, 99, false);
#line 48 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                           Write(Url.Action("AcceptFreezedFamily", "FreezedFamily", new { freezedFamilyId = Model.FreezedFamilyId }));

#line default
#line hidden
            EndContext();
            BeginContext(2079, 177, true);
            WriteLiteral("\';\r\n    });\r\n    $(\'#FreezeFamilyReproveButton\').click(function () {\r\n        if (!confirm(\'Deseja realmente reprovar esta árvore?\')) return;\r\n\r\n        window.location.href = \'");
            EndContext();
            BeginContext(2257, 100, false);
#line 53 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\FreezedFamily\Manage.cshtml"
                           Write(Url.Action("ReproveFreezedFamily", "FreezedFamily", new { freezedFamilyId = Model.FreezedFamilyId }));

#line default
#line hidden
            EndContext();
            BeginContext(2357, 26, true);
            WriteLiteral("\';\r\n    });\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.FreezedFamily.FreezedFamilyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
