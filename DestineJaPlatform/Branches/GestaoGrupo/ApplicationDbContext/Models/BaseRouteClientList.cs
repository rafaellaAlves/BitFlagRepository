using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class BaseRouteClientList
    {
        public string ContractCode { get; set; }
        public string ServiceCode { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public int ClientId { get; set; }
        [Key]
        public int ClientCollectionAddressId { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public bool IsCompany { get; set; }
        public bool InOtherRoute { get => InOtherRoutesCount > 0; }
        public int InOtherRoutesCount { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string SituationName { get; set; }
        public string PeriodicityName { get; set; }
        public int? PeriodicityId { get; set; }
        public string RowColor { get; set; }
        public bool ClientIsDeleted { get; set; }
    }
}
