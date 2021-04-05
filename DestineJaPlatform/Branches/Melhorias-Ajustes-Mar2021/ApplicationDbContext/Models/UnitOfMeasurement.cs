using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class UnitOfMeasurement : Shared.ListBase
    {
        public int UnitOfMeasurementId { get; set; }
        public int Order { get; set; }
        public string Initials { get; set; }
    }
}
