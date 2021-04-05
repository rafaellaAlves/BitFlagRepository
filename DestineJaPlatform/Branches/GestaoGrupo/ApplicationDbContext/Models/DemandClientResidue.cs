using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandClientResidue
    {
        public int DemandClientResidueId { get; set; }
        public int DemandClientId { get; set; }
        public int ResidueId { get; set; }
        public double Weight { get; set; }
        public int UnitOfMeasurementId { get; set; }
    }
}
