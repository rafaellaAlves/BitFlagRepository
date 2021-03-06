#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\RegistryOffice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e225b638206a8da6b28668c77fc0906be8ca6df6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RegistryOffice_Index), @"mvc.1.0.view", @"/Views/RegistryOffice/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RegistryOffice/Index.cshtml", typeof(AspNetCore.Views_RegistryOffice_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e225b638206a8da6b28668c77fc0906be8ca6df6", @"/Views/RegistryOffice/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_RegistryOffice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\RegistryOffice\Index.cshtml"
  
    ViewData["Title"] = "Cartórios";
   

#line default
#line hidden
            BeginContext(50, 55, true);
            WriteLiteral("\r\n<div id=\"RegistryOfficeIndexViewComponent\"></div>\r\n\r\n");
            EndContext();
            DefineSection("Modals", async() => {
                BeginContext(122, 1051, true);
                WriteLiteral(@"
    <div id=""RegistryOfficeManageModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Dados do Cartório</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div id=""RegistryOfficeManageViewComponent""></div>
                </div>
                <div class=""modal-footer"">
                    <button id=""RegistryOfficeManageButton"" class=""btn btn-success float-right"" type=""button""><i class=""simple-icon-cloud-upload""></i>&nbsp;Salvar</button>
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Fechar</button>
                </div>
            </div>
 ");
                WriteLiteral("       </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1176, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1197, 92, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(\'#RegistryOfficeIndexViewComponent\').load(\'");
                EndContext();
                BeginContext(1290, 64, false);
#line 33 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\RegistryOffice\Index.cshtml"
                                                Write(Url.Action("RegistryOfficeIndexViewComponent", "RegistryOffice"));

#line default
#line hidden
                EndContext();
                BeginContext(1354, 119, true);
                WriteLiteral("\');\r\n        function openRegistryOfficeManageModal(id) {\r\n\r\n            $(\'#RegistryOfficeManageViewComponent\').load(\'");
                EndContext();
                BeginContext(1474, 65, false);
#line 36 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\RegistryOffice\Index.cshtml"
                                                     Write(Url.Action("RegistryOfficeManageViewComponent", "RegistryOffice"));

#line default
#line hidden
                EndContext();
                BeginContext(1539, 741, true);
                WriteLiteral(@"', { id });
            $('#RegistryOfficeManageModal').modal('show');
        }
        $('#RegistryOfficeManageButton').click(function () {
            $('#RegistryOfficeManageButton').prop('disabled', true);
            RegistryOfficeManageFormSave(function () {
                if ($.fn.DataTable.isDataTable('#_registryOfficeIndexTable')) {
                    $('#_registryOfficeIndexTable').DataTable().ajax.reload();
                }
                $('#RegistryOfficeManageModal').modal('hide');
                $('#RegistryOfficeManageButton').prop('disabled', false);
            }, function () {
                $('#RegistryOfficeManageButton').prop('disabled', false);
            });
        });
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
