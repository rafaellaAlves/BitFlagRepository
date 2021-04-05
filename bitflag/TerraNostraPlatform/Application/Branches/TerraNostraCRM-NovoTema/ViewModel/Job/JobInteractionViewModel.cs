using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Job
{
    public class JobInteractionViewModel
    {
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return this.CreatedDate.ToDateTimePtBR(); } }
        public string StepDescription { get; set; }
        public string Message { get; set; }
        public int WorkflowStepId { get; set; }
        public object EnableJobFreezedFamilyInfo { get; set; }
    }
}
