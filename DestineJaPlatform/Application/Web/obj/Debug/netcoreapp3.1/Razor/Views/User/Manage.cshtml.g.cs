#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff630342ca159f7858e689cd844bceef87930a15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Manage), @"mvc.1.0.view", @"/Views/User/Manage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff630342ca159f7858e689cd844bceef87930a15", @"/Views/User/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int?>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "user-manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Web.Utils.TagHelperScriptPaste __Web_Utils_TagHelperScriptPaste;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
  
    ViewData["Title"] = "Gerenciar usu??rio";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-body"">
        <div id=""UserManageError"" class=""alert alert-danger"" role=""alert"" style=""display: none;"">
            <b>Houve um erro ao salvar o usu??rio:</b> <span id=""UserManageErrorMessage"">Teste</span>
        </div>
        <form id=""UserManageForm"" method=""post"">
            <div id=""UserManageViewComponent"">
                ");
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
            Write(await Component.InvokeAsync<Web.ViewComponents.User.UserManageViewComponent>(new { id = Model }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </form>\n    </div>\n    <div class=\"card-footer\">\n        <div class=\"row\">\n            <div class=\"col\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 686, "\"", 720, 1);
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
WriteAttributeValue("", 693, Url.Action("Index","User"), 693, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-secondary float-left""><i class=""simple-icon-action-undo""></i>&nbsp;Voltar</a>
            </div>
            <div class=""col"">
                <button type=""button"" id=""UserManageSubmitButton"" class=""btn btn-success float-right""><i class=""simple-icon-cloud-upload""></i>&nbsp;Criar Usu??rio</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff630342ca159f7858e689cd844bceef87930a155737", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n    <script type=\"text/javascript\">\n        $(\'#UserManageSubmitButton\').click(function () {\n            \n            $(\'#UserManageError\').hide();\n            $.post(\'");
#nullable restore
#line 36 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
               Write(Url.Action("Manage", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', $(\'#UserManageForm\').serializeArray(), function (d) {\n                if (d.hasError) {\n                    $(\'#UserManageError\').show();\n                    $(\'#UserManageError\').html(d.message);\n                } else {\n");
#nullable restore
#line 41 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                     if (!User.IsClient()) {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        if ($(\'#RoleName\').val() == \"Cliente\")\n                            document.location.href = \"");
#nullable restore
#line 44 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                                                 Write(Url.Action("Index", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?success=true&userType=");
#nullable restore
#line 44 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                                                                                                     Write((int)DTO.User.UserType.Client);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\n                        else\n                            document.location.href = \"");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                                                 Write(Url.Action("Index", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?success=true&userType=");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                                                                                                     Write((int)DTO.User.UserType.Adminsitrator);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\n                        ");
#nullable restore
#line 47 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                               
                    } else {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            document.location.href = \"");
#nullable restore
#line 50 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                                                 Write(Url.Action("Index", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?success=true\";\n                        ");
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
                               
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                }\n            });\n        });\n\n    </script>\n");
#nullable restore
#line 58 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
     if (Model.HasValue)
    {
        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <script type=""text/javascript"">
                $('#UserManageSubmitButton').html('<i class=""simple-icon-cloud-upload""></i>&nbsp;Atualizar Usu??rio');
                $('#UserManageCardHeaderTitle').text('Atualizar usu??rio');
            </script>
        ");
#nullable restore
#line 65 "C:\repositorios\DestineJaPlatform\Application\Web\Views\User\Manage.cshtml"
               
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int?> Html { get; private set; }
    }
}
#pragma warning restore 1591
