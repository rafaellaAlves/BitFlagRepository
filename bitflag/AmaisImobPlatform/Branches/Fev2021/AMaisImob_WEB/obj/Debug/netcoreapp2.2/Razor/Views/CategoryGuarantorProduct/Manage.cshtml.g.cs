#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5378209a11641913c693a5b08a3543c63a815d7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CategoryGuarantorProduct_Manage), @"mvc.1.0.view", @"/Views/CategoryGuarantorProduct/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CategoryGuarantorProduct/Manage.cshtml", typeof(AspNetCore.Views_CategoryGuarantorProduct_Manage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5378209a11641913c693a5b08a3543c63a815d7c", @"/Views/CategoryGuarantorProduct/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_CategoryGuarantorProduct_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
  
    ViewData["Title"] = "Produto e Categoria da Garantidora";

#line default
#line hidden
            BeginContext(83, 347, true);
            WriteLiteral(@"<div id=""_SuccessDiv"" class=""alert alert-success fade show text-center"" role=""alert"" style=""display: none;"">
    Os dados foram salvos com sucesso.
</div>
<div class=""card shadow bg-light"">
    <div class=""card-body"">
        <div id=""_CategoryGuarantorProductManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 430, "\"", 484, 1);
#line 13 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
WriteAttributeValue("", 437, Url.Action("Index","CategoryGuarantorProduct"), 437, 47, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(485, 393, true);
            WriteLiteral(@" class=""btn btn-secondary float-left"" style=""color:white;""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""CategoryGuarantorProductSubmitButton"" class=""btn btn-success float-right""><i class=""fa fa-cloud-upload-alt""></i>&nbsp;Criar</button>
    </div>
</div>

<script type=""text/javascript"">
    $('#_CategoryGuarantorProductManageViewComponent').load('");
            EndContext();
            BeginContext(879, 81, false);
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
                                                        Write(Url.Action("CategoryGuarantorProductManageComponent", "CategoryGuarantorProduct"));

#line default
#line hidden
            EndContext();
            BeginContext(960, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
                                                                                                                                                           if (Model.HasValue) { 

#line default
#line hidden
            BeginContext(995, 5, false);
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
                                                                                                                                                                            Write(Model);

#line default
#line hidden
            EndContext();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
                                                                                                                                                                                        } else { 

#line default
#line hidden
            BeginContext(1016, 4, true);
            WriteLiteral("null");
            EndContext();
#line 19 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\CategoryGuarantorProduct\Manage.cshtml"
                                                                                                                                                                                                                   }

#line default
#line hidden
            BeginContext(1029, 259, true);
            WriteLiteral(@" });

    $('#CategoryGuarantorProductSubmitButton').click(function () {
        if (CamposSelecionados()) {
            if (VerificarCamposTaxas()) {
                CategoryGuarantorProductManageSave();
            }
        }

    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int?> Html { get; private set; }
    }
}
#pragma warning restore 1591
