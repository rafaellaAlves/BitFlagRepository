using ApplicationDbContext.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Client : CompanyBase
    {
        public int ClientId { get; set; }
        public int ClientActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public string Phone { get; set; }
        public string CentralEmail { get; set; }
        public bool Solicitation { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DemandFeedbackEmailSendedDate { get; set; }
    }                               
}
