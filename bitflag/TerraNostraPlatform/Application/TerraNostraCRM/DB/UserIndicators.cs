using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public partial class UserIndicators
    {

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ServiceType { get; set; }
        [Key]
        public int JobId { get; set; }
        public DateTime JobCreatedDate { get; set; }
        public int StepId { get; set; }
        public string Step { get; set; }
        public DateTime StepCreatedDate { get; set; }
        public bool Finished { get; set; }
        public int? ResponsibleId { get; set; }
    }
}
