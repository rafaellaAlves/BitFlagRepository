﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawActionStatus
    {
        public int CompanyLawActionStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalCode { get; set; }
        public bool IsActive { get; set; }
    }
}
