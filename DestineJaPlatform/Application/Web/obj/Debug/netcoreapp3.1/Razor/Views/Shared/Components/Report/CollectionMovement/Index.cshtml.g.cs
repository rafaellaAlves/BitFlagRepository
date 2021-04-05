#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f3302c0c9fa647f061435c8320f988a1063c922"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_CollectionMovement_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Report/CollectionMovement/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f3302c0c9fa647f061435c8320f988a1063c922", @"/Views/Shared/Components/Report/CollectionMovement/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_CollectionMovement_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Shared.EntityViewMode<List<DTO.Client.Report.ClientReportCollectionMovementViewModel>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""card"">
    <div class=""card-header card-header-default card-header-destineja-green tx-uppercase justify-content-between  bg-gray-400"">
        <h6 class=""mg-b-0 tx-14 tx-inverse""><i class=""fa fa-table""></i>&nbsp;Tabela</h6>
        <div class=""card-option d-flex"">
            <button type=""button"" class=""btn btn-sm btn-primary d-flex mr-2"" style=""border-radius: 3px;""");
            BeginWriteAttribute("onclick", " onclick=\"", 481, "\"", 547, 3);
            WriteAttributeValue("", 491, "printReport(\'", 491, 13, true);
#nullable restore
#line 8 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 504, Url.Action("CollectionMovementDownload"), 504, 41, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 545, "\')", 545, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"simple-icon-cloud-download\"></i><span class=\"d-none d-sm-block\">&nbsp;Download</span></button>\n            <button type=\"button\" class=\"btn btn-sm btn-primary d-flex\" style=\"border-radius: 3px;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 753, "\"", 816, 3);
            WriteAttributeValue("", 763, "printReport(\'", 763, 13, true);
#nullable restore
#line 9 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 776, Url.Action("CollectionMovementPrint"), 776, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 814, "\')", 814, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"simple-icon-printer\"></i><span class=\"d-none d-sm-block\">&nbsp;Imprimir</span></button>\n            <a");
            BeginWriteAttribute("href", " href=\"", 930, "\"", 937, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""tx-gray-600 hover-white mg-l-10"" data-toggle=""collapse"" aria-expanded=""true"" data-target=""#collection-year-map-table-area""><i class=""simple-icon-arrow-up lh-0""></i></a>
        </div>
    </div>
    <div class=""card-body bd collapse show"" id=""collection-year-map-table-area"">
        <div class=""row"">
            <div class=""col table-responsive"">
                <table class=""table nowrap table-condensed table-bordered w-100 tablesizeline"" id=""collection-movement-table"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Data</th>
                            <th class=""text-center"">MTR</th>
                            <th class=""text-center"">Peso</th>
                            <th class=""text-center"">Família de Resíduos</th>
                            <th class=""text-center"">Cert. de Coleta</th>
                            <th class=""text-center"">Destinador</th>
                            <th class=""text-center"">MTR Destinação</th>
        ");
            WriteLiteral("                    <th class=\"text-center\">Destinado em</th>\n                            <th class=\"text-center\">Cert. de Dest.</th>\n                        </tr>\n                    </thead>\n                    <tbody>\n");
#nullable restore
#line 31 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                          
                            var i = 0;

                            var demandGroups = Model.Model.GroupBy(x => x.DemandId);
                            foreach (var demandGroup in demandGroups)
                            {
                                var count = demandGroup.Count();
                                int j = 0;
                                foreach (var item in demandGroup)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr");
            BeginWriteAttribute("class", " class=\"", 2683, "\"", 2726, 1);
#nullable restore
#line 42 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 2691, i % 2 == 0? "tr-pair" : "tr-odd", 2691, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 43 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                         if (j == 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"text-center\" style=\"vertical-align: middle;\"");
            BeginWriteAttribute("rowspan", " rowspan=\"", 2923, "\"", 2939, 1);
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 2933, count, 2933, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                                                                                Write(item._DemandVisitedDate.IfNullChange("-"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                            <td class=\"text-center\" style=\"vertical-align: middle;\"");
            BeginWriteAttribute("rowspan", " rowspan=\"", 3088, "\"", 3104, 1);
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 3098, count, 3098, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 46 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                                                                                Write(item.DestineJaDemandId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 47 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class=\"text-center\">");
#nullable restore
#line 48 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item._Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        <td class=\"text-center\">");
#nullable restore
#line 49 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item.ResidueFamilyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 50 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                         if (j == 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td style=\"vertical-align: middle;\" class=\"text-center\"");
            BeginWriteAttribute("rowspan", " rowspan=\"", 3547, "\"", 3563, 1);
#nullable restore
#line 52 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
WriteAttributeValue("", 3557, count, 3557, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                                                                                Write(item.DestineJaCertificateId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 53 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class=\"text-center\">");
#nullable restore
#line 54 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item.RecipientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        <td class=\"text-center\">");
#nullable restore
#line 55 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item.DestineJaDemandDestinationId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        <td class=\"text-center\">");
#nullable restore
#line 56 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item._DemandDestinationArrivedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        <td class=\"text-center\">");
#nullable restore
#line 57 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                                           Write(item.CDF.IfNullChange("AGUARDANDO"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    </tr>\n");
#nullable restore
#line 59 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                    j++;
                                }
                                if (i < demandGroups.Count() - 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\n                                        <td colspan=\"9\" style=\"background: white; border:0;\"></td>\n                                    </tr>\n");
#nullable restore
#line 66 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                                }

                                i++;
                            }
                            if (Model.Model.Count == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td class=\"text-center\" colspan=\"9\">Nenhum dado encontrado</td>\n                                </tr>\n");
#nullable restore
#line 75 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\n                </table>\n            </div>\n        </div>\n    </div>\n</div>\n<hr />\n<div class=\"row\">\n    <div class=\"col-12 col-sm text-center\" style=\"color: black;\">\n        Total de MTRs: ");
#nullable restore
#line 86 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                  Write(Model.Model.Select(x => x.DemandId).Distinct().Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div class=\"col-12 col-sm text-center\" style=\"color: black;\">\n        Quantidade coletada: ");
#nullable restore
#line 89 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Shared\Components\Report\CollectionMovement\Index.cshtml"
                        Write(Model.Model.Sum(x => x.Weight).ToWeightPtBr());

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kg\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Shared.EntityViewMode<List<DTO.Client.Report.ClientReportCollectionMovementViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
