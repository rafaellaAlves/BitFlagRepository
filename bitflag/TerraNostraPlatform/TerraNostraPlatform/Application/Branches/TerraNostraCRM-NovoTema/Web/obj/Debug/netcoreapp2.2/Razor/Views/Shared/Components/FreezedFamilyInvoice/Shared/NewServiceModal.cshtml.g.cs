#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf44c80686fcd30fddb8a8f8f88bc8b47f7c5f32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FreezedFamilyInvoice_Shared_NewServiceModal), @"mvc.1.0.view", @"/Views/Shared/Components/FreezedFamilyInvoice/Shared/NewServiceModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FreezedFamilyInvoice/Shared/NewServiceModal.cshtml", typeof(AspNetCore.Views_Shared_Components_FreezedFamilyInvoice_Shared_NewServiceModal))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf44c80686fcd30fddb8a8f8f88bc8b47f7c5f32", @"/Views/Shared/Components/FreezedFamilyInvoice/Shared/NewServiceModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FreezedFamilyInvoice_Shared_NewServiceModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
  
    var invoiceItemServices = invoiceItemFunctions.GetInvoiceItemServiceTypeViewModel(invoiceItemFunctions.GetInvoiceItemServices(x => x.IsActive == true));

#line default
#line hidden
            BeginContext(234, 806, true);
            WriteLiteral(@"<div class=""modal fade"" id=""NewServiceModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Adicionar Item</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <input type=""hidden"" id=""ServiceIsCredit"" value=""true"" />
                <div class=""row"">
                    <div class=""col-md-6"">
                        <label>Descição</label>
                        <select class=""form-control"" id=""ServiceTypeId"">
");
            EndContext();
#line 20 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                             foreach (var item in invoiceItemServices.OrderBy(x => x.Order))
                            {

#line default
#line hidden
            BeginContext(1165, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(1197, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44c80686fcd30fddb8a8f8f88bc8b47f7c5f325370", async() => {
                BeginContext(1326, 9, false);
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                                                                                                                                                           Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                                   WriteLiteral(item.InvoiceItemServiceTypeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                                                                                          Write(item.IsCredit);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-is-credit", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                                                                                                                     Write(item.Name);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 22 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                                                                                                                                             Write(item._Value);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-value", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1344, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 23 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\FreezedFamilyInvoice\Shared\NewServiceModal.cshtml"
                            }

#line default
#line hidden
            BeginContext(1377, 1797, true);
            WriteLiteral(@"                        </select>
                    </div>
                    <div class=""col-md-6"">
                        <label>Valor</label>
                        <input class=""form-control money"" id=""ServiceValue"" placeholder=""Valor"" />
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <div class=""row"">
                    <div class=""col-md-6"">
                        <button type=""button"" class=""btn btn-secondary pull-left"" data-dismiss=""modal""><i class=""fas fa-times""></i>&nbsp;Fechar</button>
                    </div>
                    <div class=""col-md-6"">
                        <button type=""button"" class=""btn btn-success pull-right"" id=""save-new-service-button""><i class=""simple-icon-plus""></i>&nbsp;Adicionar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">
    $('#save-new-service-button').click(funct");
            WriteLiteral(@"ion () {
        if (serviceValidation()) {
            addServiceOnTable();
        }
    });

    $('#NewServiceModal').on('hidden.bs.modal', function () {
        $('#ServiceTypeId').val(1);
        $('#ServiceTypeId').change();
        $('.text-danger').remove();
    });

    $('#ServiceTypeId').change(function () {
        var option = $('#ServiceTypeId option[value=""' + $('#ServiceTypeId').val() + '""]');
        $('#ServiceIsCredit').val($(option).data('is-credit'));

        var value = $(option).data('value');
        if (value == null || value === undefined) {
            $('#ServiceValue').val('');
        } else {
            $('#ServiceValue').val(value);
        }
        $('#ServiceValue').select();
    }).change();
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FUNCTIONS.Invoice.InvoiceItemFunctions invoiceItemFunctions { get; private set; }
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