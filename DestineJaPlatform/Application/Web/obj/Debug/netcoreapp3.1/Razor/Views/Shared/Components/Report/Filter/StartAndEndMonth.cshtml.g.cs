#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndMonth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dfec4ecae3270f03dea7aa871d077cf6a90711b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_Filter_StartAndEndMonth), @"mvc.1.0.view", @"/Views/Shared/Components/Report/Filter/StartAndEndMonth.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dfec4ecae3270f03dea7aa871d077cf6a90711b", @"/Views/Shared/Components/Report/Filter/StartAndEndMonth.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_Filter_StartAndEndMonth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<label class=""required"">Data Inicial e Final</label>
<div class=""input-group mx-auto"" id=""start-and-end-month-input-group-filter"">
    <input class=""form-control month-datepicker required filter-input"" data-filter-name=""Data Inicial"" data-target=""#start-and-end-month-input-group-filter"" data-error-message=""A Data Inicial deve ser preenchida. "" placeholder=""__/____"" autocomplete=""off"" name=""StartDate""");
            BeginWriteAttribute("value", " value=\"", 403, "\"", 472, 1);
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndMonth.cshtml"
WriteAttributeValue("", 411, ((DateTime)ViewBag.StartDate).ToBrazilianDateFormatNoDay(), 411, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    <div class=""input-group-addon"">
        <i class=""simple-icon-calendar""></i>
    </div>
    <input class=""form-control month-datepicker required filter-input"" data-filter-name=""Data Final"" data-target=""#start-and-end-month-input-group-filter"" data-error-message=""A Data Final deve ser preenchida."" placeholder=""__/____"" autocomplete=""off"" name=""EndDate""");
            BeginWriteAttribute("value", " value=\"", 834, "\"", 901, 1);
#nullable restore
#line 7 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\Filter\StartAndEndMonth.cshtml"
WriteAttributeValue("", 842, ((DateTime)ViewBag.EndDate).ToBrazilianDateFormatNoDay(), 842, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
</div>

<script type=""text/javascript"">
    function validateStartAndEndMonth() {
        var startDate = moment($('[name=""StartDate""]').val(), 'MM/YYYY');
        var endDate = moment($('[name=""EndDate""]').val(), 'MM/YYYY');

        if (startDate > endDate) {
            $('#start-and-end-month-input-group-filter').after('<div class=""text-danger"">A data inicial n??o pode ser posterior a data final.<div>');
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
