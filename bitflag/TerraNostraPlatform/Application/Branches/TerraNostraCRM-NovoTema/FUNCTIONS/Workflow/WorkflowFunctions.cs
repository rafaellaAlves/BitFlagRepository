using DB;
using DTO.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Workflow
{
    public class WorkflowFunctions : BasicFunctions<DB.Workflow, DTO.Workflow.WorkflowViewModel>
    {
        public WorkflowFunctions(TerraNostraContext context)
            : base(context, "WorkflowId")
        {
        }

        public override int Create(WorkflowViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<WorkflowViewModel> GetDataViewModel(IEnumerable<DB.Workflow> data)
        {
            return (from d in data
                    select new WorkflowViewModel()
                    {
                        WorkflowId = d.WorkflowId,
                        Name = d.Name,
                        Description = d.Description
                    }).ToList();
        }

        public override WorkflowViewModel GetDataViewModel(DB.Workflow data)
        {
            return new WorkflowViewModel()
            {
                WorkflowId = data.WorkflowId,
                Name = data.Name,
                Description = data.Description
            };
        }

        public override void Update(WorkflowViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.Workflow;
        }

        public List<object> GetSteps(int workflowId)
        {
            var q = (from w1 in context.WorkflowStep
                     where w1.WorkflowId == workflowId
                     orderby w1.Order ascending
                     select w1);

            return q.ToList<object>();
        }

        public int? GetCurrentStepIdByJob(int jobId)
        {
            var job = context.Job.SingleOrDefault(x => x.JobId.Equals(jobId));

            return (job == null ? null : (int?)job.CurrentStepId);
        }

        public int? GetWorkflowIdByJob(int jobId)
        {
            var job = context.Job.SingleOrDefault(x => x.JobId.Equals(jobId));

            return (job == null ? null : (int?)job.WorkflowId);
        }
    }
}
