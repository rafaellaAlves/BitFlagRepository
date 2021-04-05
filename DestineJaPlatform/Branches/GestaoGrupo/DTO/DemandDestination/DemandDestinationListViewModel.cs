using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.DemandDestination
{
    public class DemandDestinationListViewModel
    {

        public string DestineJaDemandDestinationId => string.IsNullOrWhiteSpace(AlternativeDemandDestinationId) ? (DemandDestinationId.ToString().Length > 4 ? DemandDestinationId.ToString() : DemandDestinationId.ToString("0000")) : AlternativeDemandDestinationId;
        public int DemandDestinationId { get; set; }
        public string AlternativeDemandDestinationId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public string _ArrivedDate => ArrivedDate.ToBrazilianDateFormat();
        public DateTime DepartureDate { get; set; }
        public string _DepartureDate => DepartureDate.ToBrazilianDateFormat();
        public bool Finished { get; set; }
        public bool IsDeleted { get; set; }
        public string CompanyName { get; set; }
        public string ResidueFamilyName { get; set; }
        public string ResidueFamilyNameAbbreviation { get; set; }
        public string DemandDestintionStatusName { get; set; }
        public int demandDestintionStatusOrder { get; set; }
        public int? DemandDestinationStatusId { get; set; }
        public string CDF { get; set; }
        public string DemandIds { get; set; }
    }
}
