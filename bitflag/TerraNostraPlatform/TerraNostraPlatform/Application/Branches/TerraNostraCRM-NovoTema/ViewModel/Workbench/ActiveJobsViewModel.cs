using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Workbench
{
    public class ActiveJobsViewModel
    {
        public int JobId { get; set; }
        public int? JobTerraNostraId { get; set; } //este dado esta vindo da uma View, para poder ser utilizado no filtro
        //public string JobTerraNostraId
        //{
        //    get
        //    {
        //        return $"{CreatedDate.Year.ToString("0000")}{CreatedDate.Month.ToString("00")}/{JobId}";
        //    }
        //}
        public string ClientName { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public int _CreatedDateYear { get { return CreatedDate.Year; } }
        
        public Job.JobInteractionViewModel JobInteractionViewModel { get; set; }
    }
}
