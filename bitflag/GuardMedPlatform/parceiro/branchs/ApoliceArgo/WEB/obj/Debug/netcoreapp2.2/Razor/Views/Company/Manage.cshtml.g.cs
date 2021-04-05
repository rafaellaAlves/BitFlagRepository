#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1c761a4409114c608e85e13e9279fe100a15b5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Manage), @"mvc.1.0.view", @"/Views/Company/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/Manage.cshtml", typeof(AspNetCore.Views_Company_Manage))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1c761a4409114c608e85e13e9279fe100a15b5e", @"/Views/Company/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.CompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
  
    if (Model.CompanyTypeId == 1)
    {
        ViewData["Title"] = "Gerenciar " + WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName;
    }
    if (Model.CompanyTypeId == 2)
    {
        ViewData["Title"] = "Gerenciar " + WEB.Configuration.InsuranceConfiguration.PartnerDisplayName;
    }
    var companyTypeFunctions = new WEB.BLL.CompanyTypeFunctions(context);

    string companyTypeName = companyTypeFunctions.GetData().Single(x => x.CompanyTypeId == Model.CompanyTypeId).Name;

#line default
#line hidden
            BeginContext(601, 418, true);
            WriteLiteral(@"
<div class=""card shadow bg-light"">
    <div class=""card-body"">
        <nav>
            <div class=""nav nav-tabs"" id=""nav-tab"" role=""tablist"">
                <a class=""nav-item nav-link active"" id=""CompanyManageViewComponent-tab"" data-toggle=""tab"" href=""#CompanyManageViewComponent"" role=""tab"" aria-controls=""CompanyManageViewComponent"" aria-selected=""true""><span id=""_CompanyManageCardHeaderTitle"">Criação de ");
            EndContext();
            BeginContext(1020, 25, false);
#line 21 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                       Write(Html.Raw(companyTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(1045, 725, true);
            WriteLiteral(@"</span></a>
                <a class=""nav-item nav-link disabled"" id=""CompanyTermLogViewComponent-tab"" data-toggle=""tab"" href=""#CompanyTermLogViewComponent"" role=""tab"" aria-controls=""CompanyTermLogViewComponent"" aria-selected=""false"">Histórico de Contratos</a>
            </div>
        </nav>
        <div class=""tab-content"" id=""nav-tabContent"">
            <div class=""tab-pane fade show active"" id=""CompanyManageViewComponent"" role=""tabpanel"" aria-labelledby=""CompanyManageViewComponent-tab""></div>
            <div class=""tab-pane fade"" id=""CompanyTermLogViewComponent"" role=""tabpanel"" aria-labelledby=""CompanyTermLogViewComponent-tab""></div>
        </div>
    </div>
    <div class=""card-footer"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1770, "\"", 1933, 4);
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
WriteAttributeValue("", 1777, Url.Action("Index","Company"), 1777, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 1807, "?companyTypeId=", 1807, 15, true);
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
WriteAttributeValue("", 1822, Model.CompanyTypeId, 1822, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 1842, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                   if (Model.ParentCompanyId.HasValue) {

#line default
#line hidden
                BeginContext(1886, 17, true);
                WriteLiteral("&parentCompanyId=");
                EndContext();
                BeginContext(1904, 21, false);
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                          Write(Model.ParentCompanyId);

#line default
#line hidden
                EndContext();
#line 31 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                            }

#line default
#line hidden
                PopWriter();
            }
            ), 1842, 91, false);
            EndWriteAttribute();
            BeginContext(1934, 276, true);
            WriteLiteral(@" class=""btn btn-secondary float-left""><i class=""fa fa-arrow-left""></i>&nbsp;Voltar</a>

        <div id=""save-button-area"">
            <button type=""button"" id=""buttonSubmit"" class=""btn btn-success float-right""><i class=""fas fa-cloud-upload-alt""></i>&nbsp;Criar</button>
");
            EndContext();
#line 35 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
             if (Model.CompanyId.HasValue && Model.CompanyTypeId == 2 && !Model.TermAccepted)
            {

#line default
#line hidden
            BeginContext(2320, 197, true);
            WriteLiteral("                <button type=\"button\" id=\"send-accepted-term-button\" class=\"btn btn-warning float-right\" style=\"margin-right: 15px;\"><i class=\"fas fa-paper-plane\"></i>&nbsp;Enviar Termos</button>\r\n");
            EndContext();
#line 38 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
            }

#line default
#line hidden
            BeginContext(2532, 424, true);
            WriteLiteral(@"        </div>
        <script type=""text/javascript"">
            $('#buttonSubmit').click(function () {
                if (_CompanyManageValidate() && VerificarValorMaximo() &&
                    (typeof validarTaxasComissoes != 'function' || typeof validarTaxasComissoes == 'function' && validarTaxasComissoes())) {
                    _CompanyManageSave();
                }
            });
        </script>
");
            EndContext();
#line 48 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
         if (Model.CompanyId.HasValue && Model.CompanyTypeId == 2 && !Model.TermAccepted)
        {

#line default
#line hidden
            BeginContext(3058, 558, true);
            WriteLiteral(@"            <script type=""text/javascript"">
                $('#send-accepted-term-button').click(function () {
                    if (!confirm('Deseja salvar os dados e enviar os termos novamente?')) return;

                    if (_CompanyManageValidate() && VerificarValorMaximo() &&
                        (typeof validarTaxasComissoes != 'function' || typeof validarTaxasComissoes == 'function' && validarTaxasComissoes())) {
                        _CompanyManageSave(true);
                    }
                });
            </script>
");
            EndContext();
#line 60 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
        }

#line default
#line hidden
            BeginContext(3627, 123, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        $(\'#CompanyManageViewComponent\').load(\'");
            EndContext();
            BeginContext(3751, 47, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                          Write(Url.Action("CompanyManageComponent", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(3798, 11, true);
            WriteLiteral("\', { \"id\": ");
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                           if (Model.CompanyId.HasValue) { 

#line default
#line hidden
            BeginContext(3843, 15, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                      Write(Model.CompanyId);

#line default
#line hidden
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                            } else { 

#line default
#line hidden
            BeginContext(3874, 4, true);
            WriteLiteral("null");
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                       }

#line default
#line hidden
            BeginContext(3887, 20, true);
            WriteLiteral(", \"companyTypeId\": \'");
            EndContext();
            BeginContext(3908, 19, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                       Write(Model.CompanyTypeId);

#line default
#line hidden
            EndContext();
            BeginContext(3927, 21, true);
            WriteLiteral("\',\"parentCompanyId\": ");
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                      if (Model.ParentCompanyId.HasValue) { 

#line default
#line hidden
            BeginContext(3988, 21, false);
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                       Write(Model.ParentCompanyId);

#line default
#line hidden
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                                                   } else { 

#line default
#line hidden
            BeginContext(4025, 4, true);
            WriteLiteral("null");
            EndContext();
#line 66 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                                                                                                                                                                                                                                              }

#line default
#line hidden
            BeginContext(4038, 8, true);
            WriteLiteral(" });\r\n\r\n");
            EndContext();
#line 68 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
         if (Model.CompanyId.HasValue)
        {
            

#line default
#line hidden
            BeginContext(4115, 122, true);
            WriteLiteral("\r\n        $(\'#CompanyTermLogViewComponent-tab\').removeClass(\'disabled\');\r\n        $(\'#CompanyTermLogViewComponent\').load(\'");
            EndContext();
            BeginContext(4238, 52, false);
#line 72 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                           Write(Url.Action("CompanyTermLogViewComponent", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(4290, 19, true);
            WriteLiteral("\', { \"companyId\": \'");
            EndContext();
            BeginContext(4310, 15, false);
#line 72 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                                                                                   Write(Model.CompanyId);

#line default
#line hidden
            EndContext();
            BeginContext(4325, 292, true);
            WriteLiteral(@"' });

        $('#CompanyManageViewComponent-tab').on('show.bs.tab', function () {
            $('#save-button-area').show();
        });
        $('#CompanyTermLogViewComponent-tab').on('show.bs.tab', function () {
            $('#save-button-area').hide();
        });
            ");
            EndContext();
#line 80 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                   
        }

#line default
#line hidden
            BeginContext(4637, 11, true);
            WriteLiteral("    });\r\n\r\n");
            EndContext();
#line 84 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
     if (Model.CompanyTypeId == 1) {
        

#line default
#line hidden
            BeginContext(4700, 140, true);
            WriteLiteral("\r\n                function _CompanyManageCallBack(data) {\r\n                if (data != null) {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(4841, 34, false);
#line 88 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                       Write(Url.Action("Plataforma","Company"));

#line default
#line hidden
            EndContext();
            BeginContext(4875, 81, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n                    }\r\n                }\r\n        ");
            EndContext();
#line 91 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(4972, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 94 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
     if (Model.CompanyTypeId == 2)
    {
        

#line default
#line hidden
            BeginContext(5031, 140, true);
            WriteLiteral("\r\n                function _CompanyManageCallBack(data) {\r\n                if (data != null) {\r\n                    window.location.href = \'");
            EndContext();
            BeginContext(5172, 34, false);
#line 99 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                       Write(Url.Action("Escritorio","Company"));

#line default
#line hidden
            EndContext();
            BeginContext(5206, 81, true);
            WriteLiteral("?id=\' + data + \'&saved=true\';\r\n                    }\r\n                }\r\n        ");
            EndContext();
#line 102 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(5303, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 106 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
     if (Model.CompanyId.HasValue)
    {
        

#line default
#line hidden
            BeginContext(5364, 111, true);
            WriteLiteral("\r\n        $(\'#buttonSubmit\').text(\"Salvar\");\r\n        $(\'#_CompanyManageCardHeaderTitle\').text(\'Atualização de ");
            EndContext();
            BeginContext(5476, 25, false);
#line 110 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
                                                            Write(Html.Raw(companyTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(5501, 13, true);
            WriteLiteral("\');\r\n        ");
            EndContext();
#line 111 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Company\Manage.cshtml"
               
    }

#line default
#line hidden
            BeginContext(5530, 11, true);
            WriteLiteral("\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public DB.Models.Insurance_HomologContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
