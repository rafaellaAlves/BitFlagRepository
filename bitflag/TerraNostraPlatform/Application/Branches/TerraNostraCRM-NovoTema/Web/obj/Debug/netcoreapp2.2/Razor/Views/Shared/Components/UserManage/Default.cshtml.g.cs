#pragma checksum "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b9d9561e21387097679f1bef7152dd806025a3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserManage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserManage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/UserManage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_UserManage_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b9d9561e21387097679f1bef7152dd806025a3d", @"/Views/Shared/Components/UserManage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserManage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.User.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "True", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "False", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_UserManageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
  
    var isClient = Model.Role == "Cliente";

#line default
#line hidden
            BeginContext(83, 279, true);
            WriteLiteral(@"<script type=""text/javascript"">
    _MaskData();
</script>

<script type=""text/javascript"">

function _UserManageSave() {
    var d = $('#_UserManageForm').serializeArray();
    d.push({ 'name': 'RoleNormalizedName', 'value': $('#_UserManageRole').val() });
    $.post('");
            EndContext();
            BeginContext(363, 28, false);
#line 14 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
       Write(Url.Action("Manage", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(391, 1066, true);
            WriteLiteral(@"', d, function (data) {
        if (data.hasError) {
            $('#_UserManageAlertSuccess').hide();
            $('#alertErrorUser').show();
            $('#' + data.selector).after('<div class=""text-danger"">'+data.message+'</div>');
        }
        else {
            _UserManageCallBack(data.id);
		}
		
	});
    }

function _UserManageValidate() {

    var _UserManagehasError = false;
	$('.text-danger').remove();

    if (IsNullOrWhiteSpace($('#_UserManageFirstName').val())) {
        $('#_UserManageFirstName').after('<div class=""text-danger"">Preencha o primeiro nome.</div>');
        _UserManagehasError = true;
	}

 //   if (IsNullOrWhiteSpace($('#_UserManageLastName').val())) {
 //       $('#_UserManageLastName').after('<div class=""text-danger"">Preencha o sobrenome.</div>');
 //       _UserManagehasError = true;
	//}

    if (IsNullOrWhiteSpace($('#_UserManageEmail').val())) {
        $('#_UserManageEmail').after('<div class=""text-danger"">Preencha um e-mail.</div>');
    ");
            WriteLiteral("    _UserManagehasError = true;\r\n    }\r\n\r\n");
            EndContext();
#line 47 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
     if (Model.UserId == null)
    {
		

#line default
#line hidden
            BeginContext(1501, 696, true);
            WriteLiteral(@"
    if (IsNullOrWhiteSpace($('#_UserManagePassword').val())) {
        $('#_UserManagePassword').after('<div class=""text-danger"">Defina uma senha.</div>');
        _UserManagehasError = true;
			}

    if (IsNullOrWhiteSpace($('#_UserManagePasswordConfirmation').val())) {
        $('#_UserManagePasswordConfirmation').after('<div class=""text-danger"">Preencha a confirmação de senha.</div>');
        _UserManagehasError = true;
			}

    if ($('#_UserManagePasswordConfirmation').val() != $('#_UserManagePassword').val()) {
        $('#_UserManagePasswordConfirmation').after('<div class=""text-danger"">Senha de Confirmação errada.</div>');
				_UserManagehasError = true;
			}
		");
            EndContext();
#line 64 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
               
    }

#line default
#line hidden
            BeginContext(2213, 506, true);
            WriteLiteral(@"    if (_UserManagehasError) {
        $('#_UserManageAlertError').show();
    } else {
        $('#_UserManageAlertError').hide();
    }

    return (!_UserManagehasError);
}

</script>

<script type=""text/javascript"">
    function _UserTakeOffSuccessAlert() {
        $('#_UserManageAlertSuccess').hide();
    }
</script>

<div id=""_UserManageAlertSuccess"" class=""alert alert-success fade show text-center"" style=""display: none;"">
    <b>Os dados foram salvos com sucesso!</b>
</div>
");
            EndContext();
#line 86 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
 if (isClient)
{

#line default
#line hidden
            BeginContext(2738, 225, true);
            WriteLiteral("    <div id=\"_UserManageClientAlert\" class=\"alert alert-warning fade show text-center\">\r\n        <b>Atenção!</b> Este usuário é um cliente, por isso a maioria das  alterações devem ser feitas na tela de cliente.\r\n    </div>\r\n");
            EndContext();
#line 91 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
}

#line default
#line hidden
            BeginContext(2966, 185, true);
            WriteLiteral("<div id=\"_UserManageAlertError\" class=\"alert alert-danger fade show text-center\" role=\"alert\" style=\"display: none;\">\r\n    <strong>Atenção!</strong> O Formulário contém erros.\r\n</div>\r\n");
            EndContext();
            BeginContext(3151, 4527, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d10256", async() => {
                BeginContext(3192, 63, true);
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"_UserManageUserId\" name=\"UserId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3255, "\"", 3276, 1);
#line 96 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 3263, Model.UserId, 3263, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3277, 253, true);
                WriteLiteral(" />\r\n    <div class=\"form-row\">\r\n        <div class=\"form-group col-md-5\">\r\n            <label class=\"control-label\" for=\"_UserManageFirstName\">Nome*</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_UserManageFirstName\" name=\"FirstName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3530, "\"", 3554, 1);
#line 100 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 3538, Model.FirstName, 3538, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3555, 260, true);
                WriteLiteral(@" placeholder=""Nome"">
        </div>
        <div class=""form-group col-md-7"">
            <label class=""control-label"" for=""_UserManageLastName"">Sobrenome*</label>
            <input type=""text"" class=""form-control"" id=""_UserManageLastName"" name=""LastName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3815, "\"", 3838, 1);
#line 104 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 3823, Model.LastName, 3823, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3839, 268, true);
                WriteLiteral(@" placeholder=""Sobrenome"">
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-2"">
            <label class=""control-label"">CPF*</label>
            <input type=""email"" class=""form-control cpf"" id=""_UserManageCpf"" name=""Cpf""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4107, "\"", 4125, 1);
#line 110 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 4115, Model.Cpf, 4115, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4126, 248, true);
                WriteLiteral(" placeholder=\"CPF\">\r\n        </div>\r\n        <div class=\"form-group col-md-4\">\r\n            <label class=\"control-label\" for=\"_UserManageEmail\">E-mail*</label>\r\n            <input type=\"email\" class=\"form-control\" id=\"_UserManageEmail\" name=\"Email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4374, "\"", 4394, 1);
#line 114 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 4382, Model.Email, 4382, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4395, 888, true);
                WriteLiteral(@" placeholder=""E-mail"">
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"" for=""_UserManagePassword"">Senha*</label>
            <input type=""password"" class=""form-control"" id=""_UserManagePassword"" name=""Password"" value="""" placeholder=""Senha"">
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"" for=""_UserManagePasswordConfirmation"">Confirmação de Senha*</label>
            <input type=""password"" class=""form-control"" id=""_UserManagePasswordConfirmation"" value="""" placeholder=""Confirmação de Senha"">
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-3"">
            <label class=""control-label"" for=""_UserManagePhoneNumber"">Telefone</label>
            <input type=""text"" class=""form-control "" id=""_UserManagePhoneNumber"" name=""PhoneNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5283, "\"", 5309, 1);
#line 128 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 5291, Model.PhoneNumber, 5291, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5310, 274, true);
                WriteLiteral(@" placeholder=""Telefone"">
        </div>
        <div class=""form-group col-md-3"">
            <label class=""control-label"" for=""_UserManageMobileNumber"">Celular</label>
            <input type=""text"" class=""form-control "" id=""_UserManageMobileNumber"" name=""MobileNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5584, "\"", 5611, 1);
#line 132 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
WriteAttributeValue("", 5592, Model.MobileNumber, 5592, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5612, 205, true);
                WriteLiteral(" placeholder=\"Celular\">\r\n        </div>\r\n        <div class=\"form-group col-md-4\">\r\n            <label class=\"control-label\">Perfil</label>\r\n            <select class=\"form-control\" id=\"_UserManageRole\">\r\n");
                EndContext();
#line 137 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                 foreach (var role in ((List<TerraNostraIdentityDbContext.Role>)ViewData["Roles"]).OrderBy(x => x.Name))
                {
                    if (Model.RoleNormalizedName == role.NormalizedName)
                    {

#line default
#line hidden
                BeginContext(6055, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(6079, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d17230", async() => {
                    BeginContext(6126, 16, false);
#line 141 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                                                                 Write(role.Description);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 141 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                           WriteLiteral(role.NormalizedName);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6151, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 142 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                        continue;
                    }

#line default
#line hidden
                BeginContext(6211, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(6231, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d20130", async() => {
                    BeginContext(6269, 16, false);
#line 144 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                                                    Write(role.Description);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 144 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                       WriteLiteral(role.NormalizedName);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6294, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 145 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"

                }

#line default
#line hidden
                BeginContext(6317, 239, true);
                WriteLiteral("            </select>\r\n        </div>\r\n        <div class=\"form-group col-md-2\">\r\n            <label class=\"control-label\">Ativo?</label>\r\n            <select class=\"form-control\" id=\"_UserManageIsActive\" name=\"IsActive\">\r\n                ");
                EndContext();
                BeginContext(6556, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d22893", async() => {
                    BeginContext(6597, 3, true);
                    WriteLiteral("Sim");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6609, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(6627, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d24459", async() => {
                    BeginContext(6649, 3, true);
                    WriteLiteral("Não");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6661, 41, true);
                WriteLiteral("\r\n            </select>\r\n        </div>\r\n");
                EndContext();
#line 156 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
         if (Model != null && Model.UserId != null)
        {

#line default
#line hidden
                BeginContext(6766, 101, true);
                WriteLiteral("            <script type=\"text/javascript\">\r\n            $(\'#_UserManageIsActive\').find(\'[value=\' + \"");
                EndContext();
                BeginContext(6868, 14, false);
#line 159 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                                                   Write(Model.IsActive);

#line default
#line hidden
                EndContext();
                BeginContext(6882, 57, true);
                WriteLiteral("\" + \']\').attr(\'selected\', true);\r\n            </script>\r\n");
                EndContext();
#line 161 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
        }

#line default
#line hidden
                BeginContext(6950, 12, true);
                WriteLiteral("    </div>\r\n");
                EndContext();
#line 163 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
     if (Model.RoleNormalizedName == "ADMINISTRATOR" || Model.RoleNormalizedName == "SALESMAN")
    {

#line default
#line hidden
                BeginContext(7066, 272, true);
                WriteLiteral(@"        <div class=""form-row"">
            <div class=""form-group col-md-2"">
                <label class=""control-label"">Disponível para vendas?</label>
                <select class=""form-control"" id=""SalesmanAvailable"" name=""SalesmanAvailable"">
                    ");
                EndContext();
                BeginContext(7338, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d27975", async() => {
                    BeginContext(7359, 3, true);
                    WriteLiteral("Sim");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7371, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(7393, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b9d9561e21387097679f1bef7152dd806025a3d29458", async() => {
                    BeginContext(7415, 3, true);
                    WriteLiteral("Não");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7427, 125, true);
                WriteLiteral("\r\n                </select>\r\n               <script type=\"text/javascript\">\r\n                   $(\'#SalesmanAvailable\').val(\'");
                EndContext();
                BeginContext(7554, 42, false);
#line 173 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
                                            Write(Model.SalesmanAvailable ? "True" : "False");

#line default
#line hidden
                EndContext();
                BeginContext(7597, 67, true);
                WriteLiteral("\');\r\n               </script>\r\n            </div>\r\n        </div>\r\n");
                EndContext();
#line 177 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
    }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7678, 35, true);
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n");
            EndContext();
#line 180 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
     if (isClient)
    {
        

#line default
#line hidden
            BeginContext(7754, 343, true);
            WriteLiteral(@"
    var disableFields = ['_UserManageFirstName', '_UserManageLastName', '_UserManageEmail', '_UserManagePhoneNumber', '_UserManageMobileNumber', '_UserManageRole'];
            for (var i = 0; i < disableFields.length; i++) {
                $('#' + disableFields[i]).attr('disabled', 'disabled').attr('name', '');
            }
        ");
            EndContext();
#line 187 "C:\repositorios\bitflag\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Shared\Components\UserManage\Default.cshtml"
               
    }

#line default
#line hidden
            BeginContext(8113, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.User.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591