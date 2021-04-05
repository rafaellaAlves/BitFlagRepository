using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class TransporterVehicle
    {
        public int TransporterVehicleId { get; set; }
        public int TransporterId { get; set; }
        public string LicensePlate { get; set; }
        public string LicensePlateFileName { get; set; }
        public string LicensePlateGuidName { get; set; }
        public string LicensePlateMimeType { get; set; }
        public string DUT { get; set; }
        public string DUTFileName { get; set; }
        public string DUTGuidName { get; set; }
        public string DUTMimeType { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturingDate { get; set; }
        public string CIV { get; set; }
        public string CIVFileName { get; set; }
        public string CIVGuidName { get; set; }
        public string CIVMimeType { get; set; }
        public DateTime? CIVDueDate { get; set; }
        public string CIPPModel { get; set; }
        public string CIPPFileName { get; set; }
        public string CIPPGuidName { get; set; }
        public string CIPPMimeType { get; set; }
        public DateTime? CIPPDueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
