using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.DemandDestination
{
    public class DemandDestinationViewModel
    {
        public string DestineJaDemandDestinationId => string.IsNullOrWhiteSpace(AlternativeDemandDestinationId)? (!DemandDestinationId.HasValue ? null : DemandDestinationId.ToString().Length > 4 ? DemandDestinationId.ToString() : DemandDestinationId.Value.ToString("0000")) : AlternativeDemandDestinationId;
        public int? DemandDestinationId { get; set; }
        public int DemandDestinationStatusId { get; set; }
        [Update]
        public string AlternativeDemandDestinationId { get; set; }
        [Update]
        public int TransporterId { get; set; }
        [Update]
        public int TransporterVehicleId { get; set; }
        [Update]
        public int TransporterDriverId { get; set; }
        [Update]
        public int RecipientId { get; set; }
        [Update]
        public int ResidueFamilyId { get; set; }
        [Update]
        public DateTime? ArrivedDate { get; set; }
        public string _ArrivedDate { get => ArrivedDate.ToBrazilianDateFormat(); set => ArrivedDate = value.FromBrazilianDateFormat(); }
        [Update]
        public DateTime? DepartureDate { get; set; }
        public string _DepartureDate { get => DepartureDate.ToBrazilianDateFormat(); set => DepartureDate = value.FromBrazilianDateFormat(); }
        public string WeighingTicket { get; set; }
        public double? Weight { get; set; }
        public string _Weight { get => Weight?.ToWeightPtBr(); set => Weight = value.FromDoublePtBR(); }
        public TimeSpan? ArrivedTime { get; set; }
        public string _ArrivedTime { get => ArrivedTime.ToBrazilianTimeNoSecondsFormat(); set => ArrivedTime = value.FromBrazilianTimeNoSecondsFormat(); }
        public TimeSpan? DepartureTime { get; set; }
        public string _DepartureTime { get => DepartureTime.ToBrazilianTimeNoSecondsFormat(); set => DepartureTime = value.FromBrazilianTimeNoSecondsFormat(); }
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
        /// <summary>
        /// Data de abertura do MTR de Coleta (Obs: Um MTR de Coleta pode ser aberto após ele ter sido fechado/finalizado)
        /// </summary>
        public DateTime? OpenDate { get; set; }
        public int? OpenBy { get; set; }
        public string OpenReason { get; set; }
    }
}
