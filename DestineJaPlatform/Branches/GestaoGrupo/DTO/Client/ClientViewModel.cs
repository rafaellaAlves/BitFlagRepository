using DTO.Shared;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientViewModel : CompanyBaseViewModel
    {
        public int? ClientId { get; set; }
        [Update]
        public int ClientActivityId { get; set; }
        [Update]
        public string ActivityDescription { get; set; }
        [Update]
        public string Phone { get; set; }
        [Update]
        public string CentralEmail { get; set; }
        public bool Solicitation { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateFormated => CreatedDate.ToBrazilianDateFormat();
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DemandFeedbackEmailSendedDate { get; set; }
    }
}
