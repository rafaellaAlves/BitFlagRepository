﻿using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class Benefit
    {
        public int BenefitId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Discount { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
