#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Certificate\SavedPrint.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d45e4b3bdecd7a09cbe9dae68643a02e8fe97be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Certificate_SavedPrint), @"mvc.1.0.view", @"/Views/Certificate/SavedPrint.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Certificate/SavedPrint.cshtml", typeof(AspNetCore.Views_Certificate_SavedPrint))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d45e4b3bdecd7a09cbe9dae68643a02e8fe97be", @"/Views/Certificate/SavedPrint.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Certificate_SavedPrint : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery/jquery-3.3.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Certificate\SavedPrint.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(35, 3825, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d45e4b3bdecd7a09cbe9dae68643a02e8fe97be4139", async() => {
                BeginContext(41, 23, true);
                WriteLiteral("\r\n    <style>\r\n        ");
                EndContext();
                BeginContext(65, 2430, true);
                WriteLiteral(@"@media print {
            page {
                margin: 0;
            }

            body {
                -webkit-print-color-adjust: exact !important;
                color-adjust: exact !important;
            }

            .no-print, .no-print * {
                display: none !important;
            }

            .smallFont {
                font-size: 10px;
            }

            .no-screen {
                display: block !important;
            }
        }


        html {
            height: 100%;
        }

        body {
            /*height: 100%;*/
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            /*background-color: #999;*/
        }

        .bgamaisimob-green {
            background-color: #5d817a !important;
        }

        .amaisimob-grey {
            color: #333333 !important;
        }

        .bgamaisimob-grey {
            background-color: #a1a1a1 !important;
        }

        .bgamaisimob");
                WriteLiteral(@"-darkgrey {
            background-color: #888888 !important;
        }

        .amaisimob-white {
            color: white !important;
        }

        .bgamaisimob-white {
            background-color: white !important;
        }

        .amaisimob-orange {
            color: orange; /*#f39a2d;*/
        }

        table {
            border-collapse: collapse;
        }

            table td {
                font-size: 0.7em;
                padding: 6px;
            }

        .impressao-subtitulo {
            font-size: 12px;
            white-space: nowrap;
        }

        .impressao-titulo {
            font-size: 18px;
        }

        .td-padding {
            padding-top: 1px;
            padding-bottom: 1px;
        }

        .row {
            width: 100%;
            display: flex;
        }

        .img-container {
            width: 20%;
            flex: 0 0 20%;
            -webkit-box-flex: 0;
            text-align: center;
     ");
                WriteLiteral(@"       margin-top: .4em;
        }

        .text-container {
            width: 80%;
            flex: 0 0 80%;
            -webkit-box-flex: 0;
        }
    </style>
    <link rel=""stylesheet"" href=""https://use.fontawesome.com/releases/v5.6.3/css/all.css"" integrity=""sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/"" crossorigin=""anonymous"">
    ");
                EndContext();
                BeginContext(2495, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d45e4b3bdecd7a09cbe9dae68643a02e8fe97be7168", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2550, 1303, true);
                WriteLiteral(@"
    <script src=""https://igorescobar.github.io/jQuery-Mask-Plugin/js/jquery.mask.min.js""></script>
    <script type=""text/javascript"">
        function _MaskData() {
            $('.quota').mask('#,0', { reverse: true });
            $('.date').mask('00/00/0000');
            $('.time').mask('00:00:00');
            $('.date-time').mask('00/00/0000 00:00:00');
            $('.monthYear').mask('00/0000');
            $('.cep').mask('00000-000');
            $('.mobile').mask('(00) #0000-0000');
            $('.phone').mask('(00) 0000-0000');
            $('.percent5').mask('##0,00000', { reverse: true });
            $('.percent2').mask('##0,00', { reverse: true });
            $('.cnpj').mask('00.000.000/0000-00', { reverse: true, clearIfNotMatch: true });
            $('.cpf').mask('000.000.000-00', { reverse: true, clearIfNotMatch: true });
            $('._cpf').mask('#000.000.000-00', { reverse: true, clearIfNotMatch: true });
            $('.money').mask('#.##0,00', { reverse: true });");
                WriteLiteral(@"
            $('.placa').mask('SSS-0000');
            $('.fipe').mask('000000-0');
            $('.renavam').mask('00000000-0');
            $('.year').mask('0000');
            $('.rg').mask('00.000.000-00');
            $('.number').mask('#');
        }
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3860, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3862, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d45e4b3bdecd7a09cbe9dae68643a02e8fe97be10563", async() => {
                BeginContext(3868, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 140 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\Fev2021\WEB\Views\Certificate\SavedPrint.cshtml"
       await Html.RenderPartialAsync("~/Views/Certificate/Shared/_savedPrint.cshtml"); 

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3967, 17, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
