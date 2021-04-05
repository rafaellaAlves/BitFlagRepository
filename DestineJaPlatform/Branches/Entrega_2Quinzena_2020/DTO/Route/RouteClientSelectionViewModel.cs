using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Route
{
    public class RouteClientSelectionViewModel
    {
        public int ClientId { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsContract { get => ContractId.HasValue; }
        public int ClientCollectionAddressId { get; set; }
        public string ContractCode { get; set; }
        public string ServiceCode { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public bool InOtherRoute { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string ContractSituationName { get; set; }
        public string RowColor { get; set; }
    }
}
