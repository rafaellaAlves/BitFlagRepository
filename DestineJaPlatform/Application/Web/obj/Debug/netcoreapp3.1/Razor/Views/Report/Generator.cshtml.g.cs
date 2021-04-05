#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4087e0188a7d04cb0a291e74df480b11d02ba9b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Generator), @"mvc.1.0.view", @"/Views/Report/Generator.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4087e0188a7d04cb0a291e74df480b11d02ba9b9", @"/Views/Report/Generator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Generator : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
   
    DTO.Client.ClientViewModel userClient = null;

    ViewData["Title"] = "Relatório - Geradores";

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
     if (User.IsClient())
    {
        userClient = await clientServices.GetViewModelByIdAsync(await clientServices.GetClientIdByLoggedUser(Context));
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
     

    DateTime? startDate = null;
    DateTime? endDate = null;
    string search = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 22 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
             if (User.IsClient())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
           Write(await Html.PartialAsync("Heading.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
                                                          ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>

        <div class=""row"">
            <div class=""col-12 text-center"" style=""font-size: 20px !important; color: black;"">
                Relatório - Geradores
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <form id=""client-generator-filter-form"">
");
#nullable restore
#line 36 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
              
                var filters = new List<ReportFilterModel>();
                filters.Add(ReportFilterModel.OptionalStartAndEndDateFilter(new { startDate, endDate }, 3));
                filters.Add(ReportFilterModel.SearchFilter(new { search })); 

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
                                                                         Write(await Component.InvokeAsync<Web.ViewComponents.Report.Filter.FilterViewComponent>(filters));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </form>\r\n        <hr />\r\n        <div class=\"w-100\" id=\"client-report-collection-list-view-component\">\r\n            ");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
        Write(await Component.InvokeAsync<Web.ViewComponents.Report.Generator.IndexViewComponent>(new { startDate, endDate, search }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1755, "\"", 1798, 1);
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
WriteAttributeValue("", 1761, Url.Content("~/assets/js/report.js"), 1761, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n    <script type=\"text/javascript\">\r\n        function reloadByFilter() {\r\n            $(\'#client-report-collection-list-view-component\').load(\'");
#nullable restore
#line 55 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Report\Generator.cshtml"
                                                                Write(Url.Action("LoadGeneratorViewComponent"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', $('#client-generator-filter-form').serializeArray());
        }

        function printReport(url) {
             var form = $('<form>', { target: ""_blank"", method: ""post"", action: url });

            form.append($('<input>', { type: 'hidden', value: (isNullOrWhiteSpace($('[name=""StartDate""]').val()) ? """" : $('[name=""StartDate""]').val()), name: 'startDate' }));
            form.append($('<input>', { type: 'hidden', value: (isNullOrWhiteSpace($('[name=""EndDate""]').val()) ? """" : $('[name=""EndDate""]').val()), name: 'endDate' }));
            form.append($('<input>', { type: 'hidden', value: (isNullOrWhiteSpace($('[name=""Search""]').val()) ? """" : $('[name=""Search""]').val()), name: 'search' }));

            setListPrintValuesIntoForm(form);

            $('body').append(form);

            form.submit();
            form.remove();
        }
        $(document).ready(function () {
            reloadByFilter();
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
        public Web.Helpers.DropDownListHelper dropDownListHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.Client.ClientReportServices clientReportServices { get; private set; }
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
