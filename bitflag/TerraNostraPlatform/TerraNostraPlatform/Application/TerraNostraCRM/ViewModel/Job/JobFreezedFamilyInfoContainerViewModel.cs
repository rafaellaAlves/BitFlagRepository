using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Job
{
    public class JobFreezedFamilyInfoContainerViewModel
    {
        public int JobId { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Modules { get; set; }
        public List<JobFreezedFamilyInfoViewModel> JobFreezedFamilyInfoViewModels { get; set; }
        public string Title { get; set; }
        public bool Block { get; set; }
        public bool IsPrintMode { get; set; }

        public JobFreezedFamilyInfoContainerViewModel()
        {
            this.Columns = new List<string>();
            this.Modules = new List<string>();
            this.JobFreezedFamilyInfoViewModels = new List<JobFreezedFamilyInfoViewModel>();
        }

        public string HideColumnStyle(string column)
        {
            return !Columns.Any(x => x.ToUpper().Equals(column.ToUpper())) ? "display: none;" : "";
        }
        public bool HasModule(string module)
        {
            return Modules.Any(x => x.ToUpper().Equals(module.ToUpper()));
        }
    }
}
