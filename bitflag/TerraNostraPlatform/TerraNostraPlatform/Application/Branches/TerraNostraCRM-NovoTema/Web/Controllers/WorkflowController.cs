using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FUNCTIONS.Job;
using FUNCTIONS.Workflow;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class WorkflowController : Controller
    {
        private WorkflowFunctions workflowFunctions;

        public WorkflowController(WorkflowFunctions workflowFunctions)
        {
            this.workflowFunctions = workflowFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ItalianCertificates()
        {
            return View();
        }

        public IActionResult CheckListOfCertificates()
        {
            return View();
        }

        public IActionResult RegistryOfficeUplift()
        {
            return View();
        }

        public IActionResult RegistryOfficePayment()
        {
            return View();
        }

        public IActionResult ForwardToTranslation()
        {
            return View();
        }

        public IActionResult ForwardToApostille()
        {
            return View();
        }

        public IActionResult ItalyDocumentProtocol()
        {
            return View();
        }

        public IActionResult DocumentStatus()
        {
            return View();
        }

        #region [ViewComponent]
        // TODO: depois retirar jobId daqui.
        public IActionResult WorkflowViewerViewComponent(int jobId, int? workflowId)
        {
            ViewData["JobId"] = jobId;
            ViewData["WorkflowId"] = workflowId;
            return ViewComponent(typeof(ViewComponents.Workflow.WorkflowViewerViewComponent));
        }
        #endregion

        #region [XHR]
        public IActionResult GetWorkflow(int workflowId)
        {
            return Json(workflowFunctions.GetSteps(workflowId));
        }
        #endregion
    }
}