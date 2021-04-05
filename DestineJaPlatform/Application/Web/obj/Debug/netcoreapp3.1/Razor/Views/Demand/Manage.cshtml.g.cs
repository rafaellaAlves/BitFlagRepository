#pragma checksum "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7ce6c8b2030b858cdbbc5e1028f118475bd12b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demand_Manage), @"mvc.1.0.view", @"/Views/Demand/Manage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ce6c8b2030b858cdbbc5e1028f118475bd12b4", @"/Views/Demand/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42406f827f578580248b07848ae56f582b2639c", @"/Views/_ViewImports.cshtml")]
    public class Views_Demand_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Demand.DemandViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "demand-manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "demand-client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "demand-client-selection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-paste-key", "demand-client-family", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
   ViewData["Title"] = "Abertura de Demanda"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<form id=\"demand-manage-form\"");
            BeginWriteAttribute("action", " action=\"", 113, "\"", 158, 1);
#nullable restore
#line 5 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
WriteAttributeValue("", 122, Url.Action("_ManageForm", "Demand"), 122, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" method=\"post\">\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 199, "\"", 222, 1);
#nullable restore
#line 6 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
WriteAttributeValue("", 207, Model.DemandId, 207, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""DemandId"" />
    <div class=""card"">
        <div class=""card-body"">
            <div class=""card "">
                <div class=""card-header card-header-default tx-uppercase justify-content-between  bg-gray-400"">
                    <h6 class=""mg-b-0 tx-14 tx-inverse""><i class=""simple-icon-note""></i>&nbsp;Dados Gerais de Coleta e Transporte</h6>
                    <div class=""card-option"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 649, "\"", 656, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"tx-gray-600 hover-white mg-l-10\" data-toggle=\"collapse\" aria-expanded=\"true\" data-target=\"#demand-area\"><i class=\"simple-icon-arrow-up lh-0\"></i></a>\n                    </div>\n");
            WriteLiteral("                </div>\n                <div class=\"card-body bd collapse show\" id=\"demand-area\">\n                    ");
#nullable restore
#line 25 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                Write(await Component.InvokeAsync<Web.ViewComponents.Demand.DemandManageViewComponent>(new { id = Model.DemandId, viewMode = DTO.Shared.ViewMode.Editable }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <br />
            <div class=""card "">
                <div class=""card-header card-header-default tx-uppercase justify-content-between  bg-gray-400"">
                    <h6 class=""mg-b-0 tx-14 tx-inverse""><i class=""simple-icon-location-pin""></i>&nbsp;Planejamento da Rota</h6>
                    <div class=""card-option"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 2032, "\"", 2039, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"tx-gray-600 hover-white mg-l-10\" data-toggle=\"collapse\" aria-expanded=\"true\" data-target=\"#demand-route-area\"><i class=\"simple-icon-arrow-up lh-0\"></i></a>\n                    </div>\n");
            WriteLiteral("                </div>\n                <div class=\"card-body bd collapse show\" id=\"demand-route-area\">\n                    <div id=\"demand-client-no-route\" class=\"w-100 text-center\"");
            BeginWriteAttribute("style", " style=\"", 2925, "\"", 2981, 1);
#nullable restore
#line 45 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
WriteAttributeValue("", 2933, Model.DemandId.HasValue? "display:none;" : "", 2933, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <hr />\n                        <i style=\"font-size: 20px;\">Selecione uma Rota.</i>\n                    </div>\n                    <div id=\"demand-client-view-component\">\n");
#nullable restore
#line 50 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                         if (Model.DemandId.HasValue)
                        {

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                     Write(await Component.InvokeAsync<Web.ViewComponents.Demand.DemandClientViewComponent>(new { routeId = Model.RouteId, demandId = Model.DemandId }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                                                                                                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"card-footer\">\n            <div class=\"row\">\n                <div class=\"col\">\n                    <a");
            BeginWriteAttribute("href", " href=\"", 3606, "\"", 3643, 1);
#nullable restore
#line 59 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
WriteAttributeValue("", 3613, Url.Action("Index", "Demand"), 3613, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-disabledAll=\"false\" class=\"btn btn-secondary\"><i class=\"simple-icon-arrow-left\"></i>&nbsp;Voltar</a>\n                </div>\n                <div class=\"col\">\n");
#nullable restore
#line 62 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                     if (Model.DemandId.HasValue && !Model.Cancel)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 3923, "\"", 3991, 1);
#nullable restore
#line 64 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
WriteAttributeValue("", 3930, Url.Action("MTRFile", "Demand", new { id = Model.DemandId }), 3930, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-primary float-right\"><i class=\"simple-icon-printer\"></i>&nbsp;Imprimir Rota</a>\n");
#nullable restore
#line 65 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                     if (!Model.Cancel)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button id=\"demand-save-button\" type=\"button\" class=\"btn btn-success float-right mr-sm-2 mt-2 mt-sm-0\"><i class=\"simple-icon-cloud-upload\"></i>&nbsp;Salvar</button>\n");
#nullable restore
#line 69 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n            </div>\n        </div>\n    </div>\n</form>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            InitializeFunctions();
        });

        $('#demand-save-button').click(function () {
          
            $('#demand-save-button').attr('disabled', '');

            $('#demand-manage-form-area [name=""FilterPeriodicity""]').val('');
            if (typeof demandClientTable != 'undefined') demandClientTable.draw(); //remove o filtro de periodicidade para salvar todos itens da tabela

            var r = validateInputs('demand-manage-form-area');

            if (r) { //validações extras
                var departureDate = moment($('#demand-manage-form input[name=\'_DepartureDate\']').val(), 'DD/MM/YYYY')._d;
                var arrivedDate = moment($('#demand-manage-form input[name=\'_ArriveDate\']').val(), 'DD/MM/YYYY')._d;

                if (arrivedDate < departureDate) {
                    $('#demand-manage-form input[name=\'_ArriveDate\']').after('<small class=""text-danger"">A data de chegada não pode ser anteri");
                WriteLiteral(@"or a data de saída.</small>');
                    r = false;
                }

            }
            if (r) { //validações extras
                if ($('#demand-client-table tr[data-address-id]').length == 0) {
                    bootbox.alert('Selecione ao menos um cliente para esta <b>Rota</b>.');
                    r = false;
                }
                else if ($('#demand-client-table tr[data-address-id]').length > addressFamilyIds.length) {
                    bootbox.alert('Selecione ao menos uma <b>Família</b> para cada <b>Cliente</b> desta <b>Rota</b>.');
                    r = false;
                }
            }

            if (!r) {
                $('#demand-save-button').removeAttr('disabled');
                return;
            }

            $.post('");
#nullable restore
#line 118 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
               Write(Url.Action("ValidateDemandCreation", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', $('#demand-manage-form').serializeArray(), function (d) {
                if (d.hasError) {
                    bootbox.alert(d.message);
                    $('#demand-save-button').removeAttr('disabled');

                    return;
                }

                insertDemandHiddenInputs();
                 $('#demand-manage-form').submit();
                
               
            });
        });

        function insertDemandHiddenInputs() {
            //adiciona ao form os clientes selecionados
            $.each($('#demand-not-used-client-table tr[data-address-id]'), function (i, e) {
                $('#demand-manage-form').append('<input type=""hidden"" name=""NotUsedClients.Index"" value=""' + i + '"" />');
                $('#demand-manage-form').append('<input type=""hidden"" name=""NotUsedClients[' + i + '].ClientCollectionAddressId"" value=""' + $(e).data('address-id') + '"" />');
            });

            $.each($('#demand-client-table tr[data-address-id]'), function (i, e) {

             ");
                WriteLiteral(@"   $('#demand-manage-form').append('<input type=""hidden"" name=""Clients.Index"" value=""' + i + '"" />');
                $('#demand-manage-form').append('<input type=""hidden"" name=""Clients[' + i + '].DemandClientId"" value=""' + $(e).data('demand-client-id') + '"" />');
                $('#demand-manage-form').append('<input type=""hidden"" name=""Clients[' + i + '].ClientCollectionAddressId"" value=""' + $(e).data('address-id') + '"" />');
                $('#demand-manage-form').append('<input type=""hidden"" name=""Clients[' + i + '].ContractId"" value=""' + $(e).data('contract-id') + '"" />');
                $('#demand-manage-form').append('<input type=""hidden"" name=""Clients[' + i + '].ServiceId"" value=""' + $(e).data('service-id') + '"" />');
                var rowIndex = demandClientTable.rows({ order: 'applied' }).nodes().indexOf(e) + 1;
                $('#demand-manage-form').append('<input type=""hidden"" name=""Clients[' + i + '].Order"" value=""' + rowIndex + '"" />');
            });

            $.each(addressFamilyIds");
                WriteLiteral(@", function (i, e) {
                $.each(e.familyIds, function (_i, _e) {
                    var index = $('#demand-manage-form [name=""DemandResidueFamily.Index""]').length;
                    $('#demand-manage-form').append('<input type=""hidden"" name=""DemandResidueFamily.Index"" value=""' + index + '"" />');
                    $('#demand-manage-form').append('<input type=""hidden"" name=""DemandResidueFamily[' + index + '].ClientCollectionAddressId"" value=""' + e.clientCollectionAddressId + '"" />');
                    $('#demand-manage-form').append('<input type=""hidden"" name=""DemandResidueFamily[' + index + '].ResidueFamilyId"" value=""' + _e + '"" />');
                });
            });

            $('#demand-manage-form-area [name=""NotValidateFamily""]').val($('#demand-manage-form-area [name=""NotValidateFamily""]')[0].checked);
        }

        $('#demand-manage-form-area [Name=""RouteId""]').change(function () {
            $('#demand-client-view-component').empty();

            if (isNullOrWhiteSpace($(thi");
                WriteLiteral("s).val())) {\n                $(\'#demand-client-no-route\').show();\n                return;\n            }\n\n            $(\'#demand-client-no-route\').hide();\n            $.post(\'");
#nullable restore
#line 172 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
               Write(Url.Action("GetResidueFamiliesByRouteId", "Route"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { id: $(this).val() }, function (d) {
                $('#demand-manage-form-area [Name=""Families""]').val($.distinct(d.map(function (e, i) { return isNull(e.nameAbbreviation, e.name); })).join(' / '));
            });

            $('#demand-client-view-component').load('");
#nullable restore
#line 176 "C:\repositorios\DestineJaPlatform\Application\Web\Views\Demand\Manage.cshtml"
                                                Write(Url.Action("LoadDemandClientViewComponent", "Demand"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', { routeId: $(this).val() });\n        });\n    </script>\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ce6c8b2030b858cdbbc5e1028f118475bd12b418773", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ce6c8b2030b858cdbbc5e1028f118475bd12b419883", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ce6c8b2030b858cdbbc5e1028f118475bd12b420993", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ce6c8b2030b858cdbbc5e1028f118475bd12b422103", async() => {
                }
                );
                __Web_Utils_TagHelperScriptPaste = CreateTagHelper<global::Web.Utils.TagHelperScriptPaste>();
                __tagHelperExecutionContext.Add(__Web_Utils_TagHelperScriptPaste);
                __Web_Utils_TagHelperScriptPaste.DeferDestinationId = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Demand.DemandViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591