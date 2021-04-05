#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndYear.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbd40c40240a2d54c8f97e5c1af7707b4872b9f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_Filter_StartAndEndYear), @"mvc.1.0.view", @"/Views/Shared/Components/Report/Filter/StartAndEndYear.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbd40c40240a2d54c8f97e5c1af7707b4872b9f5", @"/Views/Shared/Components/Report/Filter/StartAndEndYear.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_Filter_StartAndEndYear : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<label class=""required"">Ano Inicial e Final</label>
<div class=""input-group mx-auto"" id=""start-and-end-year-input-group-filter"">
    <input class=""form-control year required filter-input"" data-filter-name=""Ano Inicial"" data-target=""#start-and-end-year-input-group-filter"" data-error-message=""O Ano Inicial deve ser preenchido."" autocomplete=""off"" name=""StartYear""");
            BeginWriteAttribute("value", " value=\"", 363, "\"", 389, 1);
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndYear.cshtml"
WriteAttributeValue("", 371, ViewBag.StartYear, 371, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    <div class=""input-group-addon"">
        <i class=""simple-icon-calendar""></i>
    </div>
    <input class=""form-control year required filter-input"" data-filter-name=""Ano Final"" data-target=""#start-and-end-year-input-group-filter"" data-error-message=""O Ano Final deve ser preenchido."" autocomplete=""off"" name=""EndYear""");
            BeginWriteAttribute("value", " value=\"", 714, "\"", 738, 1);
#nullable restore
#line 7 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndYear.cshtml"
WriteAttributeValue("", 722, ViewBag.EndYear, 722, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
</div>

<script type=""text/javascript"">
    function validateStartAndEndYear() {
        if ($('[name=""StartYear""]').val() > $('[name=""EndYear""]').val()) {
            $('#start-and-end-year-input-group-filter').after('<div class=""text-danger"">O ano inicial não pode ser posterior ao ano final.<div>');
            return false;
        }

        return true;
    }
</script>");
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
