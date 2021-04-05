using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Workbench
{
    public class JobFamilyInfoManageViewModel
    {
        public int JobId { get; set; }
        public int WorkflowStepId { get; set; }
        public string Title { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Modules { get; set; }
        public bool Block { get; set; }
        public bool IsPrintMode { get; set; }
    }
}
