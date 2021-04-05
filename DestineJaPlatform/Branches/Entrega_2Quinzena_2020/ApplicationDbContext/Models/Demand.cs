using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Demand
    {
        public int DemandId { get; set; }
        public int TransporterId { get; set; }
        public int TransporterDriverId { get; set; }
        public int TransporterVehicleId { get; set; }
        public int RouteId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArriveDate { get; set; }
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
        public string AlternativeDemandId { get; set; }
        public bool NotValidateFamily { get; set; }
        /// <summary>
        /// Data de abertura do MTR de Coleta (Obs: Um MTR de Coleta pode ser aberto após ele ter sido fechado/finalizado)
        /// </summary>
        public DateTime? OpenDate { get; set; }
        public int? OpenBy { get; set; }
        public string OpenReason { get; set; }
    }
}
