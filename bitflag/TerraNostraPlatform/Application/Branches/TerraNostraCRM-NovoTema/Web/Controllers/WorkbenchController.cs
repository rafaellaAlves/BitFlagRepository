using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Salesman, Financial, Administrative, Administrative Assistant")]
    public class WorkbenchController : Shared.JobBaseController
    {
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly FUNCTIONS.Workflow.WorkflowFunctions workflowFunctions;
        private readonly FUNCTIONS.Workbench.WorkbenchListFunctions workbenchListFunctions;

        public WorkbenchController(FUNCTIONS.Job.JobFunctions jobFunctions, FUNCTIONS.User.UserFunctions userFunctions, FUNCTIONS.Workbench.WorkbenchListFunctions workbenchListFunctions)
            : base(jobFunctions)
        {
            this.userFunctions = userFunctions;
            this.workbenchListFunctions = workbenchListFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetSteps()
        {
            return View();
        }
        public IActionResult JobFamilyInfoManage(int jobId, int workflowStepId, bool block)
        {
            var jobFamilyInfoManageViewModel = jobFunctions.GetJobFamilyInfoManageViewModel(jobId, workflowStepId);
            jobFamilyInfoManageViewModel.Block = block;
            jobFamilyInfoManageViewModel.IsPrintMode = false;

            return View(jobFamilyInfoManageViewModel);
        }
        public IActionResult JobFamilyInfoManagePrint(int jobId, int workflowStepId, bool block)
        {
            var jobFamilyInfoManageViewModel = jobFunctions.GetJobFamilyInfoManageViewModel(jobId, workflowStepId);
            jobFamilyInfoManageViewModel.Block = block;
            jobFamilyInfoManageViewModel.IsPrintMode = true;

            return View(jobFamilyInfoManageViewModel);
        }
        public IActionResult CertificateStatus(int jobId)
        {
            return View(jobId);
        }
        public IActionResult CertificateStatusPrint(int jobId)
        {
            return View(jobId);
        }
        public IActionResult GetJobFreezedFamilyItemInfoRegistryOffice(int jobFreezedFamilyItemInfoId)
        {
            return Json(jobFunctions.GetJobFreezedFamilyItemInfoRegistryOffice(jobFreezedFamilyItemInfoId));
        }
        [HttpPost]
        public IActionResult SaveJobFreezedFamilyItemInfoRegistryOffice(int jobFreezedFamilyItemInfoId, string message)
        {
            try
            {
                jobFunctions.SaveJobFreezedFamilyItemInfoRegistryOffice(jobFreezedFamilyItemInfoId, message);
                return Json(true);
            }
            catch (Exception exception)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public IActionResult ItalyProtocolModuleSaveSentDate(int jobId)
        {
            try
            {
                jobFunctions.ItalyProtocolModuleSaveSentDate(jobId, userFunctions.GetUserIdByEmail(User.Identity.Name).Value);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        [HttpPost]
        public IActionResult SaveItalyProtocolAdditionalDocuments(int jobId, string documents)
        {
            try
            {
                jobFunctions.SaveItalyProtocolAdditionalDocuments(jobId, documents);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }

        #region [ViewComponents]
        public IActionResult ActiveJobsViewComponent()
        {
            return ViewComponent(typeof(ViewComponents.Workbench.ActiveJobsViewComponent));
        }
        public IActionResult LatestJobInfoViewComponent(int jobId)
        {
            return ViewComponent(typeof(ViewComponents.Job.LatestJobInfoViewComponent), new { model = this.jobFunctions.GetCurrentStepDetails(jobId) });
        }
        public IActionResult JobInfoHistoryViewComponent(int jobId)
        {
            return ViewComponent(typeof(ViewComponents.Job.JobInfoHistoryViewComponent), new { model = this.jobFunctions.GetJobStepsDetails(jobId) });
        }
        public IActionResult JobFreezedFamilyItemInfoManageViewComponent(int id, string title, List<string> columns, bool block)
        {
            return ViewComponent(typeof(ViewComponents.Job.JobFreezedFamilyItemInfoManageViewComponent), new { id, title, columns, block });
        }
        #endregion

        #region [XHR]
        public async Task<IActionResult> GetActiveJobs(DTO.Shared.DataTablesAjaxPostModel filter, int? responsibleId)
        {
            string query = "";
            List<SqlParameter> param = new List<SqlParameter>();

            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();
                query += "ResponsibleId = @ResponsibleId";
                param.Add(new SqlParameter("@ResponsibleId", userId.Value));
            }
            else
            {
                if (responsibleId.HasValue)
                {
                    query += $" {(!string.IsNullOrWhiteSpace(query) ? "AND" : "")} ResponsibleId = @ResponsibleId";
                    param.Add(new SqlParameter("@ResponsibleId", responsibleId.Value));
                }
            }

            var r = workbenchListFunctions.GetActiveJobsViewModel(this.workbenchListFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }
        public IActionResult GetCurrentStepId(int jobId)
        {
            var currentStepId = this.jobFunctions.GetCurrentStepIdByJob(jobId);
            return Json(currentStepId);
        }
        public IActionResult GetCurrentStepDetails(int jobId)
        {
            return Json(this.jobFunctions.GetCurrentStepDetails(jobId));
        }
        public IActionResult SaveCurrentStepMessage(int jobId, string message)
        {
            var userId = this.userFunctions.GetUserIdByEmail(User.Identity.Name).Value;
            var result = this.jobFunctions.SaveCurrentStepMessage(jobId, userId, message);

            return Json(result);
        }
        public IActionResult GoToNextStep(int jobId, string message)
        {
            var currentStepId = jobFunctions.GetCurrentStepIdByJob(jobId);
            var workflowStep = jobFunctions.GetWorkflowStep(currentStepId.Value);


            if (string.IsNullOrWhiteSpace(workflowStep.Role) || User.IsInRole("Administrator"))
            {
                return Json(new { hasError = !this.jobFunctions.GoToNextStep(jobId, this.userFunctions.GetUserIdByEmail(User.Identity.Name).Value, message), message = "Houve um erro ao ir para a próxima etapa." });
            }

            foreach (var role in workflowStep.Role.Split(','))
            {
                if (User.IsInRole(role.Trim()))
                {
                    return Json(new { hasError = !this.jobFunctions.GoToNextStep(jobId, this.userFunctions.GetUserIdByEmail(User.Identity.Name).Value, message), message = "Houve um erro ao ir para a próxima etapa." });
                }
            }

            return Json(new { hasError = true, message = "Você não tem permissão para a próxima etapa, verifique suas permissões" });
        }

        public IActionResult CanManageStep(int jobId)
        {
            var currentStepId = jobFunctions.GetCurrentStepIdByJob(jobId);
            var workflowStep = jobFunctions.GetWorkflowStep(currentStepId.Value);

            if (string.IsNullOrWhiteSpace(workflowStep.Role) || User.IsInRole("Administrator"))
                return Json(true);

            foreach (var role in workflowStep.Role.Split(','))
            {
                if (User.IsInRole(role.Trim()))
                    return Json(true);
            }

            return Json(false);
        }

        public IActionResult GoToPreviousStep(int jobId, string message)
        {
            var userId = this.userFunctions.GetUserIdByEmail(User.Identity.Name).Value;
            var result = this.jobFunctions.GoToPreviousStep(jobId, userId, message);

            return Json(result);
        }

        [HttpPost]
        public IActionResult SaveJobFreezedFamilyItemInfo(List<DTO.Job.JobFreezedFamilyItemInfoViewModel> model)
        {
            jobFunctions.SaveJobFreezedFamilyInfo(model);

            return Json(true);
        }
        #endregion
    }
}