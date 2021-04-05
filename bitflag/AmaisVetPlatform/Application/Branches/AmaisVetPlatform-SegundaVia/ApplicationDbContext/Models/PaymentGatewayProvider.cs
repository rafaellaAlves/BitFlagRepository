using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class PaymentGatewayProvider
    {
        public int PaymentGatewayProviderId { get; set; }
        public string Name { get; set; }
    }
}
