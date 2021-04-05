using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class HealthQuestionnaireResponse
    {
        public int HealthQuestionnaireResponseId { get; set; }
        public int SubscriptionId { get; set; }
        public int HealthQuestionnaireQuestionId { get; set; }
        public string Response { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
