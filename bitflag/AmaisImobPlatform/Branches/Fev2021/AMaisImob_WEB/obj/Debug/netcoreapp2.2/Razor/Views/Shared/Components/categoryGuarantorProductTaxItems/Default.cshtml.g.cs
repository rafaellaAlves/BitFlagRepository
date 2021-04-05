#pragma checksum "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c3208e4689b6597c6fe3179bc818ee6eb7ec760"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_categoryGuarantorProductTaxItems_Default), @"mvc.1.0.view", @"/Views/Shared/Components/categoryGuarantorProductTaxItems/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/categoryGuarantorProductTaxItems/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_categoryGuarantorProductTaxItems_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c3208e4689b6597c6fe3179bc818ee6eb7ec760", @"/Views/Shared/Components/categoryGuarantorProductTaxItems/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a27643b72aabcaca727c0b17e64178cf180f7a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_categoryGuarantorProductTaxItems_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AMaisImob_WEB.Models.CategoryGuarantorProductTaxViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
  
    double value = 0;
    var hasValue = double.TryParse(ViewData["Price"]?.ToString(), out value);

    bool.TryParse(ViewData["OnlyReadable"]?.ToString(), out bool onlyReadable);

    var annualTypeId = paymentTypeFunctions.GetByExternalCode("ANUAL").PaymentTypeId;

    int i = 1;

#line default
#line hidden
            BeginContext(440, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
 if (!onlyReadable)
{

#line default
#line hidden
            BeginContext(466, 29, true);
            WriteLiteral("    <div class=\"row w-100\">\r\n");
            EndContext();
#line 17 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
         foreach (var item in Model.OrderBy(x => x.TaxaMes))
        {
            var offset = "";

            if (Model.Count == i && (i + 2) % 3 == 0) { offset = "offset-md-4"; }
            if (Model.Count == i + 1 && (i + 2) % 3 == 0) { offset = "offset-md-2"; }

            var valor = (hasValue && value != 0 ? (item.TaxaMes * value / 100d) : 0);
            bool isAnnual = item.GuarantorPaymentTypeId == annualTypeId;
            if (isAnnual)
            {
                valor *= 12;
            }
            var _valor = valor.ToString("#,##0.00");

            var img = Convert.ToBase64String(item.GuarantorLogoTipo ?? System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "image", "noimage.png")));


#line default
#line hidden
            BeginContext(1282, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1298, "\"", 1339, 4);
#line 34 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 1306, offset, 1306, 7, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1313, "col-md-4", 1314, 9, true);
            WriteAttributeValue(" ", 1322, "text-center", 1323, 12, true);
            WriteAttributeValue(" ", 1334, "mt-4", 1335, 5, true);
            EndWriteAttribute();
            BeginContext(1340, 237, true);
            WriteLiteral(">\r\n                <div class=\"card h-100 box-shadow\">\r\n                    <div class=\"card-header\" style=\"background: white;\">\r\n                        <label style=\"position: absolute; left: 8px; top: 6px; text-transform: uppercase;\">");
            EndContext();
            BeginContext(1578, 22, false);
#line 37 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                      Write(item.GuarantorTypeName);

#line default
#line hidden
            EndContext();
            BeginContext(1600, 38, true);
            WriteLiteral("</label>\r\n                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1638, "\"", 1710, 4);
            WriteAttributeValue("", 1644, "data:", 1644, 5, true);
#line 38 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 1649, item.GuarantorLogoTipoMimeType ?? "image/png", 1649, 48, false);

#line default
#line hidden
            WriteAttributeValue("", 1697, ";base64,", 1697, 8, true);
#line 38 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue(" ", 1705, img, 1706, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1711, 232, true);
            WriteLiteral(" height=\"75\" style=\"max-width: 100%;\" />\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div class=\"row\">\r\n                            <input class=\"valor-final\" data-guarantor-id=\"");
            EndContext();
            BeginContext(1944, 16, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                     Write(item.GuarantorId);

#line default
#line hidden
            EndContext();
            BeginContext(1960, 19, true);
            WriteLiteral("\" data-product-id=\"");
            EndContext();
            BeginContext(1980, 23, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                         Write(item.GuarantorProductId);

#line default
#line hidden
            EndContext();
            BeginContext(2003, 42, true);
            WriteLiteral("\" data-category-guarantor-product-tax-id=\"");
            EndContext();
            BeginContext(2046, 34, false);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                                                                                           Write(item.CategoryGuarantorProductTaxId);

#line default
#line hidden
            EndContext();
            BeginContext(2080, 15, true);
            WriteLiteral("\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2095, "\"", 2109, 1);
#line 42 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 2103, valor, 2103, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2110, 135, true);
            WriteLiteral(" />\r\n                            <div class=\"col-md-12 text-center\">\r\n                                <h4 class=\"w-100 mb-1 font-bold\">");
            EndContext();
            BeginContext(2246, 25, false);
#line 44 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                            Write(item.GuarantorProductName);

#line default
#line hidden
            EndContext();
            BeginContext(2271, 92, true);
            WriteLiteral("</h4>\r\n                                <hr class=\"mt-1\" />\r\n                                ");
            EndContext();
            BeginContext(2364, 26, false);
#line 46 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                           Write(Html.Raw(item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(2390, 86, true);
            WriteLiteral("\r\n                                <label class=\"w-100\"><b style=\"font-size: 16px;\">R$ ");
            EndContext();
            BeginContext(2477, 6, false);
#line 47 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                               Write(_valor);

#line default
#line hidden
            EndContext();
            BeginContext(2483, 11, true);
            WriteLiteral("</b><small>");
            EndContext();
            BeginContext(2496, 26, false);
#line 47 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                  Write(isAnnual ? "/Ano" : "/Mês");

#line default
#line hidden
            EndContext();
            BeginContext(2523, 114, true);
            WriteLiteral("</small></label>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 51 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                     if (!User.IsInRole("ImobiliariaVendas"))
                    {

#line default
#line hidden
            BeginContext(2723, 188, true);
            WriteLiteral("                        <div class=\"card-footer text-center category-guarantor-product-tax-select-button-footer\">\r\n                            <button type=\"button\" class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2911, "\"", 2992, 5);
            WriteAttributeValue("", 2921, "Contract(", 2921, 9, true);
#line 54 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 2930, item.CategoryGuarantorProductTaxId, 2930, 35, false);

#line default
#line hidden
            WriteAttributeValue("", 2965, ",", 2965, 1, true);
#line 54 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue(" ", 2966, item.GuarantorProductId, 2967, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 2991, ")", 2991, 1, true);
            EndWriteAttribute();
            BeginContext(2993, 90, true);
            WriteLiteral("><i class=\"fas fa-check\"></i> Solicitar Análise</button>\r\n                        </div>\r\n");
            EndContext();
#line 56 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(3106, 44, true);
            WriteLiteral("                </div>\r\n            </div>\r\n");
            EndContext();
#line 59 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
            i++;
        }

#line default
#line hidden
            BeginContext(3179, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 62 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
}
else
{
    string offsetAndWidth = "w-100", tdWidth = "33%";
    if (Model.Count == 2) { offsetAndWidth = "w-80 offset-md-2"; tdWidth = "50%"; }
    if (Model.Count == 1) { offsetAndWidth = "w-40 offset-md-4"; tdWidth = "100%"; }


#line default
#line hidden
            BeginContext(3431, 10, true);
            WriteLiteral("    <table");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3441, "\"", 3475, 2);
#line 69 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 3449, offsetAndWidth, 3449, 15, false);

#line default
#line hidden
            WriteAttributeValue(" ", 3464, "mediumFont", 3465, 11, true);
            EndWriteAttribute();
            BeginContext(3476, 73, true);
            WriteLiteral(" style=\"padding:0;\" cellspacing=\"0\">\r\n        <thead>\r\n            <tr>\r\n");
            EndContext();
#line 72 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                 foreach (var item in Model.OrderBy(x => x.TaxaMes))
                {
                    var imgBytes = item.GuarantorLogoTipo ?? System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "image", "noimage.png"));
                    var img = Convert.ToBase64String(imgBytes);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBytes));

#line default
#line hidden
            BeginContext(4017, 23, true);
            WriteLiteral("                    <th");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4040, "\"", 4078, 5);
            WriteAttributeValue("", 4048, "width:", 4048, 6, true);
#line 77 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 4054, tdWidth, 4054, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4062, ";", 4062, 1, true);
            WriteAttributeValue(" ", 4063, "padding:", 4064, 9, true);
            WriteAttributeValue(" ", 4072, "10px;", 4073, 6, true);
            EndWriteAttribute();
            BeginContext(4079, 31, true);
            WriteLiteral(">\r\n                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4110, "\"", 4182, 4);
            WriteAttributeValue("", 4116, "data:", 4116, 5, true);
#line 78 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 4121, item.GuarantorLogoTipoMimeType ?? "image/png", 4121, 48, false);

#line default
#line hidden
            WriteAttributeValue("", 4169, ";base64,", 4169, 8, true);
#line 78 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue(" ", 4177, img, 4178, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4183, 13, true);
            WriteLiteral(" height=\"75\" ");
            EndContext();
            BeginContext(4198, 58, false);
#line 78 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                              Write(image.Width > 150 ? Html.Raw("width=\"150\"") : (object)"");

#line default
#line hidden
            EndContext();
            BeginContext(4257, 32, true);
            WriteLiteral(" />\r\n                    </th>\r\n");
            EndContext();
#line 80 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                    i++;
                }

#line default
#line hidden
            BeginContext(4334, 72, true);
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n");
            EndContext();
#line 86 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                   i = 1; 

#line default
#line hidden
            BeginContext(4435, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 87 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                 foreach (var item in Model.OrderBy(x => x.TaxaMes))
                {
                    var valor = (hasValue && value != 0 ? (item.TaxaMes * value / 100d) : 0);
                    bool isAnnual = item.GuarantorPaymentTypeId == annualTypeId;
                    if (isAnnual)
                    {
                        valor *= 12;
                    }
                    var _valor = valor.ToString("#,##0.00");

#line default
#line hidden
            BeginContext(4882, 43, true);
            WriteLiteral("                    <td class=\"text-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4925, "\"", 4961, 4);
            WriteAttributeValue("", 4933, "width:", 4933, 6, true);
#line 96 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
WriteAttributeValue("", 4939, tdWidth, 4939, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4947, ";", 4947, 1, true);
            WriteAttributeValue(" ", 4948, "padding:5px;", 4949, 13, true);
            EndWriteAttribute();
            BeginContext(4962, 87, true);
            WriteLiteral(">\r\n                        <div class=\"w-100 text-center\" style=\"min-height: 175px;\">\r\n");
            EndContext();
#line 98 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                             if (item.GuarantorProductId == 2)
                            {

#line default
#line hidden
            BeginContext(5144, 80, true);
            WriteLiteral("                                <div style=\"height:220px; padding-bottom:20px\"> ");
            EndContext();
            BeginContext(5225, 26, false);
#line 100 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                           Write(Html.Raw(item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(5251, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 101 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(5355, 80, true);
            WriteLiteral("                                <div style=\"height:140px; padding-bottom:20px\"> ");
            EndContext();
            BeginContext(5436, 26, false);
#line 104 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                           Write(Html.Raw(item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(5462, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 105 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(5501, 343, true);
            WriteLiteral(@"                            <br />
                            <div style=""position: relative; bottom: 0; width: 100%;"">
                                <div class=""bgamaisimob-green"" style=""padding-top: 5px; color: white; width: 125px; margin:auto;"">
                                    <label class=""w-100""><b style=""font-size: 16px;"">R$ ");
            EndContext();
            BeginContext(5845, 6, false);
#line 109 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                   Write(_valor);

#line default
#line hidden
            EndContext();
            BeginContext(5851, 11, true);
            WriteLiteral("</b><small>");
            EndContext();
            BeginContext(5864, 26, false);
#line 109 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                                                                                                      Write(isAnnual ? "/Ano" : "/Mês");

#line default
#line hidden
            EndContext();
            BeginContext(5891, 153, true);
            WriteLiteral("</small></label>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n");
            EndContext();
#line 114 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
                    i++;
                }

#line default
#line hidden
            BeginContext(6089, 51, true);
            WriteLiteral("            </tr>\r\n        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 119 "C:\repositorios\bitflag\AmaisImobPlatform\Branches\Fev2021\AMaisImob_WEB\Views\Shared\Components\categoryGuarantorProductTaxItems\Default.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AMaisImob_WEB.BLL.PaymentTypeFunctions paymentTypeFunctions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AMaisImob_WEB.Models.CategoryGuarantorProductTaxViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591