﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
    }
}
