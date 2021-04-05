using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public class WorkbenchList
    {
        [Key]
        public int JobId { get; set; }
        public int? JobTerraNostraId { get; set; }
        public string ClientName { get; set; }
        public string JobDescription { get; set; }
        public DateTime JobCreatedDate { get; set; }
        public int? ResponsibleId { get; set; }
        public string UserName { get; set; }
        public DateTime? JobInteractionCreatedDate { get; set; }
        public string StepDescription { get; set; }
        public string Message { get; set; }
    }
}
