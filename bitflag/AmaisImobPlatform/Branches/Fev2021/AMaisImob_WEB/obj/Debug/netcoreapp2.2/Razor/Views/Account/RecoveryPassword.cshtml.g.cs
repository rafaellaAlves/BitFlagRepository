#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4d6928be6808feecfda5aa20df6282b1c3efe38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_RecoveryPassword), @"mvc.1.0.view", @"/Views/Account/RecoveryPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/RecoveryPassword.cshtml", typeof(AspNetCore.Views_Account_RecoveryPassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4d6928be6808feecfda5aa20df6282b1c3efe38", @"/Views/Account/RecoveryPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_RecoveryPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMaisImob_WEB.Models.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
  
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";
    ViewData["Title"] = "Redefinição de senha";

    string tokenPassword = "";
    if (Context.Request.Query.ContainsKey("token"))
    {
        tokenPassword = Context.Request.Query["token"];
    }


#line default
#line hidden
            BeginContext(311, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(313, 4152, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4d6928be6808feecfda5aa20df6282b1c3efe384744", async() => {
                BeginContext(389, 329, true);
                WriteLiteral(@"
    <div id=""alertSuccessPasswordRecovery"" class=""alert alert-success fade show text-center"" role=""alert"" style=""display: none;"">
        <strong>Sua senha foi alterada com sucesso!</strong>
    </div>
    <div class=""card shadow"">
        <div class=""card-body"">
            <input type=""hidden"" id=""UserId"" name=""userId""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 718, "\"", 739, 1);
#line 20 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
WriteAttributeValue("", 726, Model.UserId, 726, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(740, 98, true);
                WriteLiteral(" />\r\n            <input type=\"hidden\" class=\"form-control\" id=\"TokenPassword\" name=\"TokenPassword\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 838, "\"", 860, 1);
#line 21 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
WriteAttributeValue("", 846, tokenPassword, 846, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(861, 2768, true);
                WriteLiteral(@">
            <div class=""row"">
                <div class=""col-md-4""></div>
                <div class=""col-md-4 form-control jumbotron"">
                    <div id=""card-error"" class=""text-warning"" style=""text-align:center; display:none;"">
                        <i class=""fas fa-exclamation-triangle"" style=""font-size: 5em;""></i>
                        <br /><br />
                        <h5 class=""control-label text-center""><strong>Página expirada!</strong></h5>
                    </div>
                    <div id=""card-data"">
                        <h5 class=""control-label text-center""><strong>Redefinição da senha</strong></h5>
                        <div class=""form-group col-md-12"">
                            <label class=""control-label"" for=""NewPassword"">Nova Senha</label>
                            <input type=""password"" class=""form-control"" id=""NewPassword"" name=""newPassword"" placeholder=""Nova Senha"">
                        </div>
                        <div class=""form-grou");
                WriteLiteral(@"p col-md-12"">
                            <label class=""control-label"" for=""NewPasswordConfirmation"">Confirmação da Nova Senha</label>
                            <input type=""password"" class=""form-control"" id=""NewPasswordConfirmation"" value="""" placeholder=""Confirmação de Senha"">
                        </div>
                        <div style=""width: 100%; text-align: center"">
                            <button type=""button"" id=""buttonSubmit"" class=""btn btn-primary""><i class=""fa fa-key""></i>&nbsp;Alterar Senha</button>
                        </div>
                        <script type=""text/javascript"">
					$('#buttonSubmit').click(function () {
						var hasError = false;
						$('#form .invalid-feedback').remove();
						$('#alertForm').hide();

						if (!IsNullOrWhiteSpace($('#NewPassword').val())) {

							// Password Confirmation
							if (IsNullOrWhiteSpace($('#NewPasswordConfirmation').val())) {
								$('#NewPasswordConfirmation').after('<div class=""invalid-feedback"">Preencha");
                WriteLiteral(@" a confirmação de senha.</div>');
								hasError = true;
							}

							// Wrong Passwords Confirmation
							else if ($('#NewPasswordConfirmation').val() != $('#NewPassword').val()) {
								$('#NewPasswordConfirmation').after('<div class=""invalid-feedback"">Confirmação de senha incorreta.</div>');
								hasError = true;
							}
						}

						else {
							$('#NewPassword').after('<div class=""invalid-feedback"">Preencha a nova senha.</div>');
							hasError = true;
						}

						if (hasError) {
							$('#alertForm').show();
							$(""html, body"").animate({ scrollTop: 0 }, ""slow"");
							$('#form .invalid-feedback').show();
						}
						else {
							var d = { TokenPassword: '");
                EndContext();
                BeginContext(3630, 13, false);
#line 75 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
                                                 Write(tokenPassword);

#line default
#line hidden
                EndContext();
                BeginContext(3643, 11, true);
                WriteLiteral("\', UserId: ");
                EndContext();
                BeginContext(3655, 12, false);
#line 75 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
                                                                          Write(Model.UserId);

#line default
#line hidden
                EndContext();
                BeginContext(3667, 74, true);
                WriteLiteral(",  NewPassword: $(\'#NewPassword\').val()};\r\n\t\t\t\t\t\t\t$.ajax({\r\n\t\t\t\t\t\t\t\turl: \'");
                EndContext();
                BeginContext(3742, 36, false);
#line 77 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
                                 Write(Url.Action("NewPassword", "Account"));

#line default
#line hidden
                EndContext();
                BeginContext(3778, 302, true);
                WriteLiteral(@"',
								type: 'POST',
								dataType: 'json',
								data: d,
								success: function (data) {
                                    if (data) {
                                        alert(""Senha alterada com sucesso!"");
                                        document.location.href = """);
                EndContext();
                BeginContext(4081, 30, false);
#line 84 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
                                                             Write(Url.Action("Login", "Account"));

#line default
#line hidden
                EndContext();
                BeginContext(4111, 347, true);
                WriteLiteral(@""";
									}
									else {
										$('#alertSuccessPasswordRecovery').hide();
										$('#card-error').show();
										$('#card-data').hide();
									}
								}
							});
						}
					});
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Account\RecoveryPassword.cshtml"
AddHtmlAttributeValue("", 337, Url.Action("NewPassword","Account"), 337, 36, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMaisImob_WEB.Models.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
