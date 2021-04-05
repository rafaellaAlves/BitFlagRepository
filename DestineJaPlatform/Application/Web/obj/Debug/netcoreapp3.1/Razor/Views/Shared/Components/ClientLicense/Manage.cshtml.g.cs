#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a189d5654e9507eb9ec069c8aef50822146ba3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ClientLicense_Manage), @"mvc.1.0.view", @"/Views/Shared/Components/ClientLicense/Manage.cshtml")]
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
#line 1 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using Web.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\_ViewImports.cshtml"
using DTO.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a189d5654e9507eb9ec069c8aef50822146ba3f", @"/Views/Shared/Components/ClientLicense/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ClientLicense_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<DTO.Client.ClientLicenseViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-cut-key", "client-license-manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Web.Utils.TagHelperScriptCut __Web_Utils_TagHelperScriptCut;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<form id=\"client-license-manage-form\" method=\"post\">\n    <input type=\"hidden\" name=\"ClientLicenseId\"");
            BeginWriteAttribute("value", " value=\"", 169, "\"", 205, 1);
#nullable restore
#line 4 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 177, Model.Model.ClientLicenseId, 177, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <div class=\"row\">\n        <div class=\"col-md-12 form-group\">\n            <label class=\"required\">Nome do Documento</label>\n            <input class=\"form-control\" placeholder=\"Nome do Documento\" name=\"Name\" maxlength=\"200\"");
            BeginWriteAttribute("value", " value=\"", 436, "\"", 461, 1);
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 444, Model.Model.Name, 444, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-12 form-group\">\n            <label class=\"required\">Nome ou Atividade</label>\n            <input class=\"form-control\" placeholder=\"Nome ou Atividade\" name=\"Activity\" maxlength=\"200\"");
            BeginWriteAttribute("value", " value=\"", 689, "\"", 718, 1);
#nullable restore
#line 12 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 697, Model.Model.Activity, 697, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-6 form-group\">\n            <label class=\"required\">Órgão Emissor</label>\n            <input class=\"form-control\" placeholder=\"Órgão Emissor\" name=\"Issuer\"");
            BeginWriteAttribute("value", " value=\"", 919, "\"", 946, 1);
#nullable restore
#line 16 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 927, Model.Model.Issuer, 927, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-6 form-group\">\n            <label>Data de Emissão</label>\n            <input class=\"form-control date\" placeholder=\"Data de Emissão\" name=\"_IssueDate\"");
            BeginWriteAttribute("value", " value=\"", 1143, "\"", 1174, 1);
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 1151, Model.Model._IssueDate, 1151, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-6 form-group\">\n            <label class=\"required\">Data de Vencimento</label>\n            <input class=\"form-control date\" placeholder=\"Data de Vencimento\" name=\"_DueDate\"");
            BeginWriteAttribute("value", " value=\"", 1392, "\"", 1421, 1);
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 1400, Model.Model._DueDate, 1400, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-6 form-group\">\n            <label class=\"required\">Dias para o Vencimento</label>\n            <input class=\"form-control number\" placeholder=\"Dias para o Vencimento\" id=\"daysForDueDate\"");
            BeginWriteAttribute("value", " value=\"", 1653, "\"", 1685, 1);
#nullable restore
#line 28 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 1661, Model.Model.DueDateDays, 1661, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label class=""required"">Notificar o vencimento em quantos dias</label>
            <input class=""form-control"" name=""DaysToNotify"" placeholder=""Notificar o vencimento em quantos dias""");
            BeginWriteAttribute("value", " value=\"", 1975, "\"", 2008, 1);
#nullable restore
#line 34 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 1983, Model.Model.DaysToNotify, 1983, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n        <div class=\"col-md-6 form-group\">\n            <label class=\"required\">E-mail para notificar (Separar os e-mails por <b>;</b>)</label>\n            <input class=\"form-control\" name=\"Email\" placeholder=\"E-mail\"");
            BeginWriteAttribute("value", " value=\"", 2243, "\"", 2269, 1);
#nullable restore
#line 38 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 2251, Model.Model.Email, 2251, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6 form-group"">
            <label class=""required"">Este é o documento de licença?</label>
            <select class=""form-control"" name=""IsRSSFile"">
                <option value=""false"" ");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
                                  Write(string.IsNullOrWhiteSpace(Model.Model.License) ? "selected" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(">Não</option>\n                <option value=\"true\" ");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
                                 Write(!string.IsNullOrWhiteSpace(Model.Model.License) ? "selected" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(">Sim</option>\n            </select>\n        </div>\n        <div class=\"col-md-6 form-group\"");
            BeginWriteAttribute("style", " style=\"", 2813, "\"", 2895, 1);
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 2821, !string.IsNullOrWhiteSpace(Model.Model.License) ? "" : "display: none;", 2821, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"transporter-environmental-documentation-license-area\">\n            <label>Licença</label>\n            <input class=\"form-control\" name=\"License\" placeholder=\"Licença\"");
            BeginWriteAttribute("value", " value=\"", 3067, "\"", 3095, 1);
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
WriteAttributeValue("", 3075, Model.Model.License, 3075, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        </div>\n    </div>\n    <div class=\"row\">\n        <div class=\"col-md-12 form-group\">\n            <label class=\"control-label\">Upload</label>\n            <input class=\"form-control\" type=\"file\" name=\"Archive\">\n        </div>\n    </div>\n</form>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a189d5654e9507eb9ec069c8aef50822146ba3f11994", async() => {
                WriteLiteral(@"
    InitializeFunctions();

    $('#client-license-manage-form [name=\'_DueDate\'], #daysForDueDate').on('change', function () {

        if ($(this).is($('#client-license-manage-form input[name=\'_DueDate\']'))) {
            if (isNullOrWhiteSpace($('#client-license-manage-form input[name=\'_DueDate\']').val())) {
                $('#daysForDueDate').val('');
                return;
            }
            var r = getDaysFromToday(moment($('#client-license-manage-form [name=\'_DueDate\']').val(), 'DD/MM/YYYY')._d, true);
            if (r == null) {
                $(this).val('');
                $('#daysForDueDate').val('');
            }

            $('#daysForDueDate').val(parseInt(r));
        }
        else {
            var now = new Date();
            now.setHours(0,0,0,0);

            $('#client-license-manage-form [name=\'_DueDate\']').val(moment(now).add($(this).val(), 'days').format('DD/MM/YYYY'));
        }
    });

    function saveClientLicense(callback)
    {
        if (!validateInput");
                WriteLiteral(@"s('client-license-manage-form')) return;

        if (isNullOrWhiteSpace($('#client-license-manage-form [name=\'ClientLicenseId\']').val()) && $('#client-license-manage-form [name=\'Archive\']')[0].files.length == 0) {
            bootbox.alert('Insira um arquivo.');
            return;
        }

        var _d = new FormData();
        _d.append('Archive', $('#client-license-manage-form [name=\'Archive\']')[0].files[0]);
        $('#client-license-manage-form').serializeArray().forEach(function (e) {
            _d.append(e.name, e.value);
        });

        $.ajax({
            url: '");
#nullable restore
#line 104 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
             Write(Url.Action("ManageAjax", "ClientLicense"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
			type: 'POST',
			contentType: false,
			processData: false,
			data: _d,
            success: function (d) {
                bootbox.alert(d.message);
                if (d.hasError) return;

                if (typeof callback == 'function') callback(d.id);
            }
        });
    }

    $('#client-license-manage-form [name=""IsRSSFile""]').change(function () {
        if ($(this).val() == 'false') {
            $('#transporter-environmental-documentation-license-area').hide();
            $('#transporter-environmental-documentation-family-area').hide();

            $('#client-license-manage-form [name=\'License\']').val('');
            $('#client-license-manage-form [name=\'LicenseResidueFamilyIds\']').val([]).trigger(""change"");
        } else {
            $('#transporter-environmental-documentation-license-area').show();
            $('#transporter-environmental-documentation-family-area').show();
            $(""#client-license-manage-form [name=\""LicenseResidueFamilyIds\""]"").select2({ width: ");
                WriteLiteral("\'resolve\' });\n        }\n    });\n");
            }
            );
            __Web_Utils_TagHelperScriptCut = CreateTagHelper<global::Web.Utils.TagHelperScriptCut>();
            __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptCut);
            __Web_Utils_TagHelperScriptCut.CutKey = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 62 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\ClientLicense\Manage.cshtml"
__Web_Utils_TagHelperScriptCut.LoadFromController = Model.LoadFromController;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-cut-key-load-from-controller", __Web_Utils_TagHelperScriptCut.LoadFromController, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<DTO.Client.ClientLicenseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
