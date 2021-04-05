using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandViewModel
    {
        public string DestinaJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId)? $"{(DemandId.ToString().Length > 4 ? DemandId.ToString() : DemandId.Value.ToString("0000"))}/{CreatedDate.Year}" : AlternativeDemandId;
        public int? DemandId { get; set; }
        [Update]
        public string AlternativeDemandId { get; set; }
        [Update]
        public int TransporterId { get; set; }
        [Update]
        public int TransporterDriverId { get; set; }
        [Update]
        public int TransporterVehicleId { get; set; }
        [Update]
        public int RouteId { get; set; }
        [Update]
        public DateTime? DepartureDate { get; set; }
        public string _DepartureDate { get => DepartureDate.ToBrazilianDateFormat(); set => DepartureDate = value.FromBrazilianDateFormatNullable(); }
        [Update]
        public DateTime? ArriveDate { get; set; }
        public string _ArriveDate { get => ArriveDate.ToBrazilianDateFormat(); set => ArriveDate = value.FromBrazilianDateFormatNullable(); }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Closed { get; set; }
        public bool Cancel { get; set; }
        public string CancelReason { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? ClosedBy { get; set; }
        public int DemandStatusId { get; set; }
        [Update]
        public bool NotValidateFamily { get; set; }
        public DateTime? OpenDate { get; set; }
        public int? OpenBy { get; set; }
        public string OpenReason { get; set; }
    }
}
