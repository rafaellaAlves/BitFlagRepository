using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class HealthQuestionnaireQuestion
    {
        public int HealthQuestionnaireQuestionaId { get; set; }
        public int HealthQuestionnaireId { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
