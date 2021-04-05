#pragma checksum "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fea9575344354c8b8b80b33d8567ca412d261771"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FreePlanCoverage_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FreePlanCoverage/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FreePlanCoverage/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FreePlanCoverage_Default))]
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
#line 1 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
using WEB.Utils;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fea9575344354c8b8b80b33d8567ca412d261771", @"/Views/Shared/Components/FreePlanCoverage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FreePlanCoverage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB.Models.PlanViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
  
    var notFreePlan = !Model.Certificate.CertificateId.HasValue && Model.PlanId.HasValue;

    var isUpdate = Model.Certificate.CertificateId.HasValue;

    //o certificado esta como renovação
    var isRenovation = isUpdate && (Model.Certificate.VigencyDate.IsInTimeToRenovate());
    bool isSimulation = !Model.Certificate.IsSimulation.HasValue || (Model.Certificate.IsSimulation.HasValue && Model.Certificate.IsSimulation.Value);

#line default
#line hidden
            BeginContext(501, 1588, true);
            WriteLiteral(@"<div id=""_FreePlanCoverageAlertError"" class=""alert alert-danger fade show text-center"" role=""alert"" style=""display: none;"">
    <strong>Atenção!</strong> Deve ser preenchido a garantia de todas cobertura que serão utilizadas.
</div>
<div class=""table-wrapper"">
    <table id=""_FreePlanCoverageIndexTable"" class=""table display responsive"" style=""border-collapse: collapse !important; width:100%;"">
        <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Básica</th>
                <th>Usadas</th>
                <th>Nome</th>
                <th>Taxa (%)</th>
                <th>Mínimo (R$)</th>
                <th>Maximo (R$)</th>
                <th>Franquias</th>
                <th>Garantia (R$)</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
<script type=""text/javascript"">
    var total = 0;
    var index = 1;
    var _FreePlanCoverageIndexTypingTimer;
    var _FreePlanCoverageIndexDoneTypingInterval = 500;
    var data");
            WriteLiteral(@"tables = $('#_FreePlanCoverageIndexTable').DataTable({
        ""order"": [[0, ""desc""]],
        columnDefs: [{
            targets: [0],
            orderData: [1, 0, 2]
        },
        {
            targets: [1],
            ""visible"": false
        },
        {
            targets: [2],
            ""visible"": false
        }],
		proccessing: true,
		serverSide: false,
		searching: true,
        lengthChange: false,
        bPaginate: false,
        info: false,
        iDisplayLength: 100,
		dom: 'tip',
		ajax: {
            url: '");
            EndContext();
            BeginContext(2090, 38, false);
#line 62 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
             Write(Url.Action("PlanCoverageList", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(2128, 69, true);
            WriteLiteral("\',\r\n            data: function (d) {\r\n                d.productId = \'");
            EndContext();
            BeginContext(2198, 15, false);
#line 64 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                          Write(Model.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(2213, 31, true);
            WriteLiteral("\',\r\n                d.planId = ");
            EndContext();
#line 65 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                            if(Model.PlanId.HasValue){

#line default
#line hidden
            BeginContext(2277, 1, true);
            WriteLiteral("\'");
            EndContext();
            BeginContext(2279, 12, false);
#line 65 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                        Write(Model.PlanId);

#line default
#line hidden
            EndContext();
            BeginContext(2291, 1, true);
            WriteLiteral("\'");
            EndContext();
#line 65 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                  }else{

#line default
#line hidden
            BeginContext(2311, 4, true);
            WriteLiteral("null");
            EndContext();
#line 65 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                                         }

#line default
#line hidden
            BeginContext(2325, 267, true);
            WriteLiteral(@"            },
			type: 'POST'
		},
        columns: [
            {
                data: 'IsOptional',
                render: function (data, type, row) {
                    var disabled = false;
                    if (!row.isOptional) disabled = true;
");
            EndContext();
#line 75 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                     if (notFreePlan) { 

#line default
#line hidden
            BeginContext(2638, 16, true);
            WriteLiteral("disabled = true;");
            EndContext();
#line 75 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                      }

#line default
#line hidden
            BeginContext(2665, 2885, true);
            WriteLiteral(@"                    var used = false;
                    if (row.used != null) {
                        used = row.used;
                    }
                    return '<input id=""ProductCoverageId_' + index + '"" value=""' + row.productCoverageId + '"" data-minimum=""' + row.realMinimum + '"" data-maximum=""' + row.realMaximum + '"" data-current-maximum=""' + row.realMaximum + '"" data-basic=""' + row.isBasic + '"" data-basic-limit=""' + row.basicLimit + '"" data-taxes=""' + row.taxes + '"" type=""hidden"" /><div style=""text-align:center;""><input id=""Used_' + index + '"" type=""checkbox"" ' + (disabled ? ' disabled ' : ' ') + (!row.isOptional || used ? ' checked ' : ' ') + ' onchange=""_FreePlanCoverageChangeUsed(' + index + ');"" /><span style=""display:none;"">' + !row.isOptional + '</span></div>';
                }
            },
            {
                data: 'IsBasic',
                render: function (data, type, row) {
                    return row.isBasic;
                }
            },
            ");
            WriteLiteral(@"{
                data: 'Used',
                render: function (data, type, row) {
                    var used = false;
                    if (row.used != null) {
                        used = row.used;
                    }
                    return used;
                }
            },
			{ data: 'Name',
                render: function (data, type, row) {
                    return row.name;
                }
            },
            {
                data: 'Taxes',
            render: function (data, type, row) {
                return '<span class=""percent"">' + row._Taxes + '</span>';
                }
            },
            {
                data: 'RealMinimum',
                render: function (data, type, row) {
                    return (row.realMinimum != null ? '<span id=""MinimumLabel_' + index + '"" class=""money"">' + row._RealMinimum + '</span>' : '-');
                }
            },
            {
                data: 'RealMaximum',
                rend");
            WriteLiteral(@"er: function (data, type, row) {
                    return (row.realMaximum != null ? '<span id=""MaximumLabel_' + index + '"" class=""money"">' + row._RealMaximum + '</span>' : '-');
                }
            },
            {
                data: 'Franquias',
                render: function (data, type, row) {
                    return row.franquias != null ? row.franquias : '-';
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    var disabled = false;
                    var isFreePlan = false;

                    var used = false;
                    if (row.used != null) {
                        used = row.used;
                    }

                    if (row.isOptional && !used) disabled = true;
");
            EndContext();
#line 140 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                     if (notFreePlan) { 

#line default
#line hidden
            BeginContext(5596, 16, true);
            WriteLiteral("disabled = true;");
            EndContext();
#line 140 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                      }

#line default
#line hidden
            BeginContext(5623, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 141 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                     if (!notFreePlan) { 

#line default
#line hidden
            BeginContext(5670, 18, true);
            WriteLiteral("isFreePlan = true;");
            EndContext();
#line 141 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                         }

#line default
#line hidden
            BeginContext(5699, 951, true);
            WriteLiteral(@"
                    var onblur = 'onblur=""' + (row.isBasic ? 'ChangeBasicGarantia(' + index + ');' : 'ValidateGarantia(' + index + ');') + (isFreePlan ? ' _FreePlanCoverageGetFreePlanPrice();' : '' ) + '""';

                    var r = '<div style=""text-align:center; width:100%;""><input id=""Garantia_' + index + '"" style=""padding: 0.090rem 0.75rem;"" type=""text"" class=""form-control money"" Placeholder=""Garantia de ' + row.name + '"" ' + (row._Garantia != null ? 'value=""' + row._Garantia + '""' : '') + onblur + (disabled? 'disabled' : '') + ' /></div>';

                    index++;
                    return r;
                }
            }
        ],
        initComplete: function (settings, json) {
            total = json.recordsFiltered;

            _MaskData();

            //função só existe quando a tela esta bloqueada
            if (typeof LockScreen == 'function') {
                LockScreen();
            }
");
            EndContext();
#line 161 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
             if (!notFreePlan) { 

#line default
#line hidden
            BeginContext(6689, 68, true);
            WriteLiteral("\r\n                _FreePlanCoverageGetFreePlanPrice();\r\n            ");
            EndContext();
#line 163 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(6768, 209, true);
            WriteLiteral("\r\n\r\n            $(\'#_CertificateManagePlanCoverageViewComponent\').css(\'height\', ($(\'#_FreePlanCoverageIndexTable\').height() + 20) + \'px\' );\r\n        },\r\n        \"rowCallback\": function (row, data, index) {\r\n\r\n");
            EndContext();
#line 170 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
             if (notFreePlan) { 

#line default
#line hidden
            BeginContext(7015, 260, true);
            WriteLiteral(@"
            var used = false;
            if (data.used != null) {
                used = data.used;
            }
            if (data.isOptional && !used) {
                console.log(row);
                $(row).hide();
            }
            ");
            EndContext();
#line 179 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(7286, 3417, true);
            WriteLiteral(@"
        }
    });

    function ChangeBasicGarantia(index) {
        var garantiaBasica = ValidateGarantia(index);

        for (var i = 1; i <= total; i++) {
            if (i == index) continue;

            var selector = $('#ProductCoverageId_' + i);

            var _max = selector.data('maximum');
            var basicLimit = selector.data('basic-limit');

            var max = _max > (garantiaBasica * basicLimit / 100) ? parseFloat(garantiaBasica * basicLimit / 100) : parseFloat(_max)

            selector.data('current-maximum', max);

            var maxString = $('.money').masked(max.toFixed(2));

            $('#MaximumLabel_' + i).text(maxString);

            //limpar todas as garantias
            $('#Garantia_' + i).val('');
        }
        //alert('Os valores máximos foram alterados de acordo com a garantia da cobertura básica.');

    }

    function ValidateGarantia(index) {
        var _garantia = $('#Garantia_' + index).val();

        garantia = MoneyTo");
            WriteLiteral(@"Float(_garantia)

        var basicMax = $('#ProductCoverageId_' + index).data('current-maximum');
        var basicMin = $('#ProductCoverageId_' + index).data('minimum');

        if (garantia > basicMax) {
            $('#Garantia_' + index).val($('.money').masked(basicMax.toFixed(2)));
            garantia = basicMax;
            //alert('A garantia foi alterada respeitando respeitando o valor máximo e mínimo.');
        }

        if (garantia < basicMin) {
            $('#Garantia_' + index).val($('.money').masked(basicMin.toFixed(2)));
            garantia = basicMin;
            //alert('A garantia foi alterada respeitando respeitando o valor máximo e mínimo.');
        }

        return garantia;
    }

    function _FreePlanCoverageGetFreePlanPrice() {

        var freePlanPrice = 0.00;

        for (var i = 1; i <= total; i++) {
            var used = $('#Used_' + i)[0].checked;
            if (!used) continue;

            var selector = $('#ProductCoverageId_' + i);
  ");
            WriteLiteral(@"          var taxes = selector.data('taxes');
            var garantia = MoneyToFloat($('#Garantia_' + i).val());

            freePlanPrice += (taxes / 100 * garantia);
        }

        if (typeof _CertificateManageGetFreePlanPrice == 'function') {
            _CertificateManageGetFreePlanPrice(freePlanPrice);
        }
    }

    function _FreePlanCoverageChangeUsed(index) {
        var used = $('#Used_' + index)[0].checked;

        if (used) {
            $('#Garantia_' + index).removeAttr('disabled');
        } else {
            $('#Garantia_' + index).val('').attr('disabled', 'disabled');
        }
        _FreePlanCoverageGetFreePlanPrice();
    }

    function _FreePlanCoverageValidacao() {
        var _FreePlanCoverageHasError = false;
        $('.text-danger').remove();

        for (var i = 1; i <= total; i++) {
            if ($('#Used_' + i)[0].checked && IsNullOrWhiteSpace($('#Garantia_' + i).val())) {
                _FreePlanCoverageHasError = true;
            ");
            WriteLiteral(@"}
        }

        if (_FreePlanCoverageHasError) {
            $('#_FreePlanCoverageAlertError').show();
        } else {
            $('#_FreePlanCoverageAlertError').hide();
        }

        return (!_FreePlanCoverageHasError);
    }

    function _FreePlanCoverageSavePlan(callback, isSumulation) {
        var planId = 0;
");
            EndContext();
#line 285 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
     if (Model.PlanId.HasValue) {

#line default
#line hidden
            BeginContext(10742, 19, true);
            WriteLiteral("\r\n        planId = ");
            EndContext();
            BeginContext(10762, 12, false);
#line 286 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
            Write(Model.PlanId);

#line default
#line hidden
            EndContext();
            BeginContext(10774, 114, true);
            WriteLiteral(";\r\n        _FreePlanCoverageSave(planId, callback, isSumulation);\r\n        //callback(planId, isSumulation);\r\n    ");
            EndContext();
#line 289 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
           }
    else {

#line default
#line hidden
            BeginContext(10914, 38, true);
            WriteLiteral("\r\n        $.ajax({\r\n            url: \'");
            EndContext();
            BeginContext(10953, 34, false);
#line 292 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
             Write(Url.Action("FreePlanSave", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(10987, 93, true);
            WriteLiteral("\',\r\n            type: \'POST\',\r\n            dataType: \'JSON\',\r\n            data: { productId: ");
            EndContext();
            BeginContext(11081, 15, false);
#line 295 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                          Write(Model.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(11096, 223, true);
            WriteLiteral(" },\r\n            success: function (data) {\r\n                planId = data.code;\r\n                _FreePlanCoverageSave(planId, callback, isSumulation);\r\n                //callback(planId);\r\n            }\r\n        });\r\n    ");
            EndContext();
#line 302 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
           }

#line default
#line hidden
            BeginContext(11329, 569, true);
            WriteLiteral(@"    }

    function _FreePlanCoverageSave(planId, callback, isSumulation) {
        var model = [];
        for (var i = 1; i <= total; i++) {
            model.push({
                'ProductCoverageId': $('#ProductCoverageId_' + i).val(), 'Used': $('#Used_' + i)[0].checked, 'Garantia': $('#Garantia_' + i).val().replace(/\./g, '').replace(/\,/g, '.'), 'PlanId': planId, 'PlanCoverageId': null
            });
        }
        if (total == 0) {
            model.push({
                'ProductCoverageId': null, 'Used': null, 'Garantia': null, 'PlanId': ");
            EndContext();
#line 314 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                      if (Model.PlanId.HasValue) {

#line default
#line hidden
            BeginContext(11933, 1, true);
            WriteLiteral("\'");
            EndContext();
            BeginContext(11935, 12, false);
#line 314 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                                                    Write(Model.PlanId);

#line default
#line hidden
            EndContext();
            BeginContext(11947, 1, true);
            WriteLiteral("\'");
            EndContext();
#line 314 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                                                                              }else{

#line default
#line hidden
            BeginContext(11967, 4, true);
            WriteLiteral("null");
            EndContext();
#line 314 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
                                                                                                                                                                     }

#line default
#line hidden
            BeginContext(11979, 92, true);
            WriteLiteral(", \'PlanCoverageId\': null\r\n            });\r\n        }\r\n\r\n        $.ajax({\r\n            url: \'");
            EndContext();
            BeginContext(12072, 38, false);
#line 319 "C:\repositorios\bitflag\GuardMedPlatform\parceiro\branchs\ApoliceArgo\WEB\Views\Shared\Components\FreePlanCoverage\Default.cshtml"
             Write(Url.Action("PlanCoverageSave", "Plan"));

#line default
#line hidden
            EndContext();
            BeginContext(12110, 294, true);
            WriteLiteral(@"',
            type: 'POST',
            data: JSON.stringify(model),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                callback(planId, isSumulation);
            }
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB.Models.PlanViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
