#pragma checksum "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b488741e7e3e7149db2785c4b2f34e929975af62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Workbench_JobFamilyInfoManage), @"mvc.1.0.view", @"/Views/Workbench/JobFamilyInfoManage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Workbench/JobFamilyInfoManage.cshtml", typeof(AspNetCore.Views_Workbench_JobFamilyInfoManage))]
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
#line 1 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\_ViewImports.cshtml"
using DTO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b488741e7e3e7149db2785c4b2f34e929975af62", @"/Views/Workbench/JobFamilyInfoManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bc2528675d6df6a8850aaaa1a29809989fa4e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Workbench_JobFamilyInfoManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Workbench.JobFamilyInfoManageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
 if (Context.Request.Query.ContainsKey("success"))
{

#line default
#line hidden
            BeginContext(106, 111, true);
            WriteLiteral("    <div id=\"alert-success\" class=\"alert alert-success\">\r\n        Informa????es salvas com sucesso!\r\n    </div>\r\n");
            EndContext();
#line 7 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
}

#line default
#line hidden
#line 8 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
 if (Context.Request.Query.ContainsKey("error"))
{

#line default
#line hidden
            BeginContext(273, 117, true);
            WriteLiteral("    <div id=\"alert-error\" class=\"alert alert-success\">\r\n        Houve um erro ao salvar as informa????es.\r\n    </div>\r\n");
            EndContext();
#line 13 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
}

#line default
#line hidden
            BeginContext(393, 205, true);
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div id=\"JobFreezedFamilyItemInfoManageViewComponent\">\r\n                    ");
            EndContext();
            BeginContext(600, 213, false);
#line 19 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
                Write(await Component.InvokeAsync<Web.ViewComponents.Job.JobFreezedFamilyItemInfoManageViewComponent>(new { id = Model.JobId, title = Model.Title, columns = Model.Columns, modules = Model.Modules, block = Model.Block }));

#line default
#line hidden
            EndContext();
            BeginContext(814, 105, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 25 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
             if (Model.Block)
            {

#line default
#line hidden
            BeginContext(965, 62, true);
            WriteLiteral("                <div class=\"col-md-6\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1027, "\"", 1118, 1);
#line 28 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
WriteAttributeValue("", 1034, Url.Action("GetSteps", "Workbench", new { jobId = Context.Request.Query["jobId"] }), 1034, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1119, 187, true);
            WriteLiteral(" class=\"btn btn-secondary\"><span class=\"simple-icon-action-undo\"></span>&nbsp;Voltar</a>\r\n                </div>\r\n                <div class=\"col-md-6 text-right\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1306, "\"", 1471, 1);
#line 31 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
WriteAttributeValue("", 1313, Url.Action("JobFamilyInfoManagePrint", "Workbench", new { jobId = Context.Request.Query["jobId"], workflowStepId = Context.Request.Query["workflowStepId"] }), 1313, 158, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1472, 124, true);
            WriteLiteral(" target=\"_blank\" class=\"btn btn-light\"><span class=\"simple-icon-printer\"></span>&nbsp;Imprimir</a>\r\n                </div>\r\n");
            EndContext();
#line 33 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1644, 62, true);
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1706, "\"", 1797, 1);
#line 37 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
WriteAttributeValue("", 1713, Url.Action("GetSteps", "Workbench", new { jobId = Context.Request.Query["jobId"] }), 1713, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1798, 188, true);
            WriteLiteral(" class=\"btn btn-secondary\"><span class=\"simple-icon-action-undo\"></span>&nbsp;Voltar</a>\r\n                </div>\r\n                <div class=\"col-md-4 text-center\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1986, "\"", 2151, 1);
#line 40 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
WriteAttributeValue("", 1993, Url.Action("JobFamilyInfoManagePrint", "Workbench", new { jobId = Context.Request.Query["jobId"], workflowStepId = Context.Request.Query["workflowStepId"] }), 1993, 158, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2152, 368, true);
            WriteLiteral(@" target=""_blank"" class=""btn btn-light""><span class=""simple-icon-printer""></span>&nbsp;Imprimir</a>
                </div>
                <div class=""col-md-4 text-right"">
                    <button id=""button-save"" onclick=""save()"" type=""button"" class=""btn btn-success""><span class=""simple-icon-cloud-upload""></span>&nbsp;Salvar</button>
                </div>
");
            EndContext();
#line 45 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
            }

#line default
#line hidden
            BeginContext(2535, 38, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
#line 50 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
 if (!Model.Block)
{
    

#line default
#line hidden
            BeginContext(2606, 347, true);
            WriteLiteral(@"
        <script type=""text/javascript"">
            function save() {
                $('#button-save').prop('disabled', true);
                jobFreezedFamilyItemInfoManageViewComponentSave(jobFreezedFamilyItemInfoManageViewComponentGetForm(), function (d) {
                    if (d) {
                        document.location.href = '");
            EndContext();
            BeginContext(2954, 74, false);
#line 58 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
                                             Write(Html.Raw(Url.Action("GetSteps", "Workbench", new { jobId = Model.JobId })));

#line default
#line hidden
            EndContext();
            BeginContext(3028, 84, true);
            WriteLiteral("\';\r\n                    } else {\r\n                        document.location.href = \'");
            EndContext();
            BeginContext(3113, 138, false);
#line 60 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
                                             Write(Html.Raw(Url.Action("JobFamilyInfoManage", "Workbench", new { jobId = Model.JobId, workflowStepId = Model.WorkflowStepId, error = true })));

#line default
#line hidden
            EndContext();
            BeginContext(3251, 86, true);
            WriteLiteral("\';\r\n                    }\r\n                });\r\n            }\r\n        </script>\r\n    ");
            EndContext();
#line 65 "C:\repositorios\bitflag\Nova pasta\TerraNostraPlatform\Application\Branches\TerraNostraCRM-NovoTema\Web\Views\Workbench\JobFamilyInfoManage.cshtml"
           
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Workbench.JobFamilyInfoManageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
