#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fdacf3b5b9ab98c04a0dfa5ce07a98a5e7f6491"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ChooseClient), @"mvc.1.0.view", @"/Views/Account/ChooseClient.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fdacf3b5b9ab98c04a0dfa5ce07a98a5e7f6491", @"/Views/Account/ChooseClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ChooseClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
  
    ViewData["Title"] = "Seleção de Cliente";
    Layout = "~/Views/Shared/_LayoutClientLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<a href=""http://www.destineja.com.br/"" target=""_blank"" class=""btn btn-destineja-orange client-login-more-info-button"">Saiba Mais</a>

<div id=""container-client-login"">
    <div class=""arrow""></div>
    <form method=""post"" autocomplete=""off"" id=""select-client-form"">
        <div class=""form-group text-center mb-3"">
            <h3 class=""control-label"" style="" font-weight: 300; color: black;"">Selecione um Gerador</h3>
        </div>
        <div class=""form-group"">
            <select name=""ClientId"" required class=""form-control"">
");
#nullable restore
#line 18 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
                 foreach (var item in (await clientServices.GetViewModelAsNoTrackingAsync(x => !x.IsDeleted)).OrderBy(x => x.Name))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <option");
            BeginWriteAttribute("value", " value=\"", 877, "\"", 899, 1);
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
WriteAttributeValue("", 885, item.ClientId, 885, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
                                                           Write(item.AlternativeName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 20 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
                                                                                  Write(item.DocumentFormated);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</option>\n");
#nullable restore
#line 21 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Account\ChooseClient.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </select>
        </div>
        <div class=""row mg-t-30"">
            <div class=""col"">
                <button type=""submit"" class=""btn btn-primary btn-custom""><i class=""simple-icon-check""></i>&nbsp;Continuar</button>
            </div>
        </div>
    </form>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $('#select-client-form').submit(function () {
            return validateInputs('select-client-form');
        });

        $('[name=""ClientId""]').select2({
            theme: ""bootstrap"",
            ""language"": {
                ""noResults"": function () {
                    return ""Nenhum resultado encontrado."";
                }
            }
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientServices clientServices { get; private set; }
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