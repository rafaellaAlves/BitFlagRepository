using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Demand
{
    public class DemandListViewModel
    {
        public string DestinaJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId) ? $"{(DemandId.ToString().Length > 4 ? DemandId.ToString() : DemandId.ToString("0000"))}/{CreatedDate.Year}" : AlternativeDemandId;

        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public DateTime ArriveDate { get; set; }
        public string _ArriveDate => ArriveDate.ToBrazilianDateFormat();
        public DateTime DepartureDate { get; set; }
        public string _DepartureDate => DepartureDate.ToBrazilianDateFormat();
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string DemandStatusName { get; set; }
        public int DemandStatusId { get; set; }
        public int TotalClient { get; set; }
        public bool Closed { get; set; }
        public double TotalWeight { get; set; }
        public string _TotalWeight => TotalWeight.ToWeightPtBr();
        public DateTime CreatedDate { get; set; }
        public string DemandDestinationIds { get; set; }
        public string DemandClientCompanyNames { get; set; }
        public string DemandClientTradeNames { get; set; }
        public bool Cancel { get; set; }
        public bool IsDeleted { get; set; }
    }
}
