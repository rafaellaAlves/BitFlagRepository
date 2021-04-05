using System;
using System.Collections.Generic;

namespace DB
{
    public partial class WorkflowStep
    {
        public int WorkflowStepId { get; set; }
        public int WorkflowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public string Role { get; set; }
        public bool EnableJobFreezedFamilyInfo { get; set; }
        public string JobFreezedFamilyInfoTitle { get; set; }
        public string JobFreezedFamilyInfoColumns { get; set; }
        public string JobFreezedFamilyInfoModules { get; set; }
    }
}
