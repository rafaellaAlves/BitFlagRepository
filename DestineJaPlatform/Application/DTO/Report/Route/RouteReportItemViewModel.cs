using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Report.Route
{
    public class RouteReportItemViewModel
    {
        public string DestinaJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId) ? $"{(DemandId.ToString().Length > 4 ? DemandId.ToString() : DemandId.ToString("0000"))}/{CreatedDate.Year}" : AlternativeDemandId;
        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureDateFormated => DepartureDate.ToBrazilianDateFormat();
        public DateTime ArriveDate { get; set; }
        public string ArriveDateFormated => ArriveDate.ToBrazilianDateFormat();
        public string DriverName { get; set; }
        public int ClientCount { get; set; }
        public int CollectedCount { get; set; }
        public double Weight { get; set; }
        public string WeightFormated => Weight.ToWeightPtBr();
    }
}
