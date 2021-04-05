using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Transporter
{
    public class TransporterVehicleViewModel
    {

        public int? TransporterVehicleId { get; set; }
        public int TransporterId { get; set; }
        [Update]
        public string LicensePlate { get; set; }
        [Update]
        public string LicensePlateGuidName { get; set; }
        [Update]
        public string LicensePlateFileName { get; set; }
        [Update]
        public string LicensePlateMimeType { get; set; }
        [Update]
        public string DUT { get; set; }
        [Update]
        public string DUTGuidName { get; set; }
        [Update]
        public string DUTFileName { get; set; }
        [Update]
        public string DUTMimeType { get; set; }
        [Update]
        public string Model { get; set; }
        [Update]
        public string Manufacturer { get; set; }
        [Update]
        public string ManufacturingDate { get; set; }
        [Update]
        public string CIV { get; set; }
        [Update]
        public string CIVGuidName { get; set; }
        [Update]
        public string CIVFileName { get; set; }
        [Update]
        public string CIVMimeType { get; set; }
        [Update]
        public DateTime? CIVDueDate { get; set; }
        public string _CIVDueDate { get { return CIVDueDate.ToBrazilianDateFormat(); } set { CIVDueDate = value.FromBrazilianDateFormatNullable(); } }
        [Update]
        public string CIPPModel { get; set; }
        [Update]
        public string CIPPFileName { get; set; }
        [Update]
        public string CIPPGuidName { get; set; }
        [Update]
        public string CIPPMimeType { get; set; }
        [Update]
        public DateTime? CIPPDueDate { get; set; }
        public string _CIPPDueDate { get { return CIPPDueDate.ToBrazilianDateFormat(); } set { CIPPDueDate = value.FromBrazilianDateFormatNullable(); } }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
