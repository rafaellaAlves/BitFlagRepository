#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73b77f255bb2ca79cd5f493f7ad39b756a4ec239"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductCoverage_Manage), @"mvc.1.0.view", @"/Views/ProductCoverage/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProductCoverage/Manage.cshtml", typeof(AspNetCore.Views_ProductCoverage_Manage))]
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
#line 1 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Models;

#line default
#line hidden
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\_ViewImports.cshtml"
using AMaisImob_WEB.Helpers.Javascript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b77f255bb2ca79cd5f493f7ad39b756a4ec239", @"/Views/ProductCoverage/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductCoverage_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.ProductCoverageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar Cobertura";

#line default
#line hidden
            BeginContext(109, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
 if (!string.IsNullOrWhiteSpace(Context.Request.Query["saved"]))
{
    

#line default
#line hidden
            BeginContext(190, 319, true);
            WriteLiteral(@"
        <div id=""_ProductCoverageManagementAlertSuccess"" class=""alert alert-success fade show text-center"">
            <b>Os dados foram salvos com sucesso!</b>
        </div>
        <script type=""text/javascript"">
            $('#_ProductCoverageManagementAlertSuccess').fadeOut(5000);
        </script>
    ");
            EndContext();
#line 15 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
           
}

#line default
#line hidden
            BeginContext(521, 294, true);
            WriteLiteral(@"
<div class=""card shadow bg-light"">
    <div class=""card-header""><span id=""_ProductCoverageManageCardHeaderTitle"">Criação de cobertura</span></div>
    <div class=""card-body"">
        <div id=""ProductCoverageManageViewComponent""></div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 815, "\"", 887, 3);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
WriteAttributeValue("", 822, Url.Action("Index","ProductCoverage"), 822, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 860, "?productId=", 860, 11, true);
#line 24 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
WriteAttributeValue("", 871, Model.ProductId, 871, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(888, 579, true);
            WriteLiteral(@" class=""btn btn-secondary float-left""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>
        <button type=""button"" id=""buttonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Salvar</button>
        <script type=""text/javascript"">
            $('#buttonSubmit').click(function () {
                if (_ProductCoverageManageValidate()) _ProductCoverageManageSave();
            });
        </script>
    </div>
</div>

<script type=""text/javascript"">
    $(function () {
        $('#ProductCoverageManageViewComponent').load('");
            EndContext();
            BeginContext(1468, 63, false);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                  Write(Url.Action("ProductCoverageManageComponent", "ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(1531, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                                                                                                   if (Model.ProductCoverageId.HasValue) { 

#line default
#line hidden
            BeginContext(1584, 23, false);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                                                                                                                                      Write(Model.ProductCoverageId);

#line default
#line hidden
            EndContext();
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                                                                                                                                                                    } else { 

#line default
#line hidden
            BeginContext(1623, 4, true);
            WriteLiteral("null");
            EndContext();
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                                                                                                                                                                                               }

#line default
#line hidden
            BeginContext(1636, 16, true);
            WriteLiteral(", \"productId\": \'");
            EndContext();
            BeginContext(1653, 15, false);
#line 36 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                                                                                                                                                                                                                                           Write(Model.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(1668, 136, true);
            WriteLiteral("\' });\r\n    });\r\n\r\n    function _ProductCoverageManageCallBack(data) {\r\n        if (data != null) {\r\n            window.location.href = \'");
            EndContext();
            BeginContext(1805, 38, false);
#line 41 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
                               Write(Url.Action("Manage","ProductCoverage"));

#line default
#line hidden
            EndContext();
            BeginContext(1843, 51, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n        }\r\n    }\r\n\r\n");
            EndContext();
#line 45 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
     if (Model.ProductCoverageId.HasValue) {
        

#line default
#line hidden
            BeginContext(1954, 93, true);
            WriteLiteral("\r\n    $(\'#_ProductCoverageManageCardHeaderTitle\').text(\'Atualização de cobertura\');\r\n        ");
            EndContext();
#line 48 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\APISeguradoras\AMaisImob_WEB\Views\ProductCoverage\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(2063, 9, true);
            WriteLiteral("</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.ProductCoverageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
