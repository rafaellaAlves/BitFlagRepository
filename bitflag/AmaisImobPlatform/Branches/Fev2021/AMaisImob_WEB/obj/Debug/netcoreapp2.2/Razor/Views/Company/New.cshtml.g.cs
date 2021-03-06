#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c92366ded2dd43852da01723ba01c1c58f6cd9f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_New), @"mvc.1.0.view", @"/Views/Company/New.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/New.cshtml", typeof(AspNetCore.Views_Company_New))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c92366ded2dd43852da01723ba01c1c58f6cd9f7", @"/Views/Company/New.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("company-new-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(147, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
  
    ViewData["Title"] = "Nova Imobili??ria";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

    int companyTypeId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
    var company = await companyFunctions.GetDataByCompanyReference(Model);

#line default
#line hidden
            BeginContext(429, 1120, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c92366ded2dd43852da01723ba01c1c58f6cd9f74738", async() => {
                BeginContext(471, 50, true);
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"CompanyReference\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 521, "\"", 535, 1);
#line 14 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
WriteAttributeValue("", 529, Model, 529, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(536, 384, true);
                WriteLiteral(@" />
    <div class=""card shadow bg-light mt-3"">
        <div class=""card-header""><span id=""_CompanyManageCardHeaderTitle"">Cria????o de Imobili??ria</span></div>
        <div class=""card-body"">
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label>Corretora:</label>
                    <input class=""form-control"" disabled");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 920, "\"", 1044, 1);
#line 21 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
WriteAttributeValue("", 928, string.IsNullOrWhiteSpace(company.RazaoSocial) ? company.FirstName + " " + company.LastName : company.RazaoSocial, 928, 116, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1045, 81, true);
                WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n            <hr />\r\n            ");
                EndContext();
                BeginContext(1128, 171, false);
#line 25 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
        Write(await Component.InvokeAsync<AMaisImob_WEB.ViewComponents.Company.CompanyManageViewComponent>(new AMaisImob_WEB.Models.CompanyViewModel() { CompanyTypeId = companyTypeId }));

#line default
#line hidden
                EndContext();
                BeginContext(1300, 242, true);
                WriteLiteral("\r\n        </div>\r\n        <div class=\"card-footer\">\r\n            <button type=\"button\" id=\"company-new-save-button\" class=\"btn btn-success float-right\"><i class=\"fas fa-cloud-upload-alt\"></i>&nbsp;Salvar</button>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1549, 326, true);
            WriteLiteral(@"

<script type=""text/javascript"">
    $('#company-new-save-button').click(function () {
        if (!_CompanyManageValidate()) return;

        if (IsNullOrWhiteSpace($('#compay-manage-user-partner-first-name').val())) {
            alert('Insira um usu??rio s??cio.');
            return;
        }

        $.post('");
            EndContext();
            BeginContext(1876, 25, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
           Write(Url.Action("ValidateNew"));

#line default
#line hidden
            EndContext();
            BeginContext(1901, 564, true);
            WriteLiteral(@"', $('#company-new-form').serializeArray(), function (d) {
            if (d.hasError) {
                alert(d.message);
                return;
            }

            var inputs = [];
            $('#_AccountManageForm').serializeArray().forEach(function (e) {
                inputs.push($('<input>', { type: 'hidden', name: 'user.' + e.name, value: e.value }));
            });

            $('#company-new-form').append(inputs);
            $('#company-new-form').submit();
            //inputs.remove();
        });
    });
</script>

");
            EndContext();
#line 60 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
 if (Context.Request.Query.ContainsKey("newRealState"))
{

#line default
#line hidden
            BeginContext(2525, 649, true);
            WriteLiteral(@"<script type=""text/javascript"">
    bootbox.dialog({
        message: ""Cadastro realizado com sucesso!<br />Clique em prosseguir para assinar o Termo de Aceite<br />Caso queira assinar depois, enviaremos no seu e-mail o termo de ades??o."",
        size: 'large',
        buttons: {
            cancel: {
                label: ""Sair"",
                className: 'btn-secondary mr-auto float-left',
                callback: function () { }
            },
            ok: {
                label: ""Prosseguir"",
                className: 'btn-success',
                callback: function () {
                    window.location.href = '");
            EndContext();
            BeginContext(3175, 22, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
                                       Write(Context.Request.Scheme);

#line default
#line hidden
            EndContext();
            BeginContext(3197, 3, true);
            WriteLiteral("://");
            EndContext();
            BeginContext(3201, 20, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
                                                                 Write(Context.Request.Host);

#line default
#line hidden
            EndContext();
            BeginContext(3222, 35, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
                                                                                      Write(Url.Action("AcceptTerm", "Company"));

#line default
#line hidden
            EndContext();
            BeginContext(3257, 11, true);
            WriteLiteral("?companyId=");
            EndContext();
            BeginContext(3269, 34, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
                                                                                                                                     Write(Context.Request.Query["companyId"]);

#line default
#line hidden
            EndContext();
            BeginContext(3303, 7, true);
            WriteLiteral("&token=");
            EndContext();
            BeginContext(3311, 30, false);
#line 76 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
                                                                                                                                                                               Write(Context.Request.Query["token"]);

#line default
#line hidden
            EndContext();
            BeginContext(3341, 70, true);
            WriteLiteral("\';\r\n                }\r\n            },\r\n        }\r\n    });\r\n</script>\r\n");
            EndContext();
#line 82 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Company\New.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.CompanyFunctions companyFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.CompanyTypeFunctions companyTypeFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
