using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class StartSubscriptionViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string CRMV { get; set; }
        public string CRMVState { get; set; }
        public int OccupationAreaId { get; set; }
        public int ProfessionalSpecialtyId { get; set; }
        public int GraudationYear { get; set; }

    }
}
