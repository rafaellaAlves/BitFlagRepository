using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers.Shared
{
    public class JobBaseController : Controller
    {
        protected FUNCTIONS.Job.JobFunctions jobFunctions;
        public JobBaseController(FUNCTIONS.Job.JobFunctions jobFunctions)
        {
            this.jobFunctions = jobFunctions;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query.ContainsKey("jobId"))
            {
                var jobId = Convert.ToInt32(context.HttpContext.Request.Query["jobId"].ToString());
                ViewData["JobId"] = jobId;
                ViewData["WorkflowId"] = this.jobFunctions.GetWorkflowIdByJobId(jobId);
                ViewData["ClientId"] = this.jobFunctions.GetClientIdByJobId(jobId);
            }

            base.OnActionExecuting(context);
        }
    }
}