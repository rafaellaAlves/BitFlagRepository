using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandDestination
    {
        public int DemandDestinationId { get; set; }
        public int DemandDestinationStatusId { get; set; }
        public int TransporterId { get; set; }
        public int TransporterVehicleId { get; set; }
        public int TransporterDriverId { get; set; }
        public int RecipientId { get; set; }
        public int ResidueFamilyId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string WeighingTicket { get; set; }
        public double? Weight { get; set; }
        public TimeSpan? ArrivedTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public string CDF { get; set; }
        public string CDFFileMimeType { get; set; }
        public string CDFFileGuidName { get; set; }
        public string CDFFileName { get; set; }
        public string MTRFileMimeType { get; set; }
        public string MTRFileGuidName { get; set; }
        public string MTRFileName { get; set; }
        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }
        public int? FinishedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string AlternativeDemandDestinationId { get; set; }
        /// <summary>
        /// Data de abertura do MTR de Coleta (Obs: Um MTR de Coleta pode ser aberto após ele ter sido fechado/finalizado)
        /// </summary>
        public DateTime? OpenDate { get; set; }
        public int? OpenBy { get; set; }
        public string OpenReason { get; set; }
    }
}
