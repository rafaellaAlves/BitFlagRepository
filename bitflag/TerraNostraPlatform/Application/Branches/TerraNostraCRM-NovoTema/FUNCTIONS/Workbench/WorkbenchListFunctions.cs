using DB;
using DTO.Workbench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Workbench
{
    public class WorkbenchListFunctions : BasicListFunctions<WorkbenchList, WorkbenchList>
    {
        public WorkbenchListFunctions(TerraNostraContext context)
            : base(context, "JobId")
        {
        }

        public override List<WorkbenchList> GetDataViewModel(IEnumerable<WorkbenchList> data)
        {
            return data.ToList();
        }

        public override WorkbenchList GetDataViewModel(WorkbenchList data)
        {
            return data;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.WorkbenchList;
        }

        public List<ActiveJobsViewModel> GetActiveJobsViewModel(IEnumerable<WorkbenchList> data)
        {

            return (from j in data
                    orderby j.JobId descending
                    select new DTO.Workbench.ActiveJobsViewModel
                    {
                        JobId = j.JobId,
                        JobTerraNostraId = j.JobTerraNostraId,
                        ClientName = j.ClientName,
                        JobDescription = j.JobDescription,
                        CreatedDate = j.JobCreatedDate,
                        JobInteractionViewModel = !j.JobInteractionCreatedDate.HasValue ? null :
                        new DTO.Job.JobInteractionViewModel
                        {
                            UserName = j.UserName,
                            CreatedDate = j.JobInteractionCreatedDate.Value,
                            StepDescription = j.StepDescription,
                            Message = j.Message
                        }
                    }).ToList();
        }
    }
}
