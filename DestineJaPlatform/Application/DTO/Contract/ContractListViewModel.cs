using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractListViewModel
    {

        public int ContractId { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public DateTime? StartContract { get; set; }
        public DateTime DueDate { get; set; }
        public int DayToEndDate => (int)(DueDate - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).TotalDays;
        public int ContractSituationId { get; set; }
        public string ContractSituationName { get; set; }
        public DateTime? RenewDate { get; set; }
        public int? RenewFrom { get; set; }
        public string RenewFromCode { get; set; }
        public bool UsedForRenew { get; set; }
        public string ClientName { get; set; }
        public string TradeName { get; set; }
        public int DueDay { get; set; }
        public double ParcelValue { get; set; }
        public string ParcelValueFormated => ParcelValue.ToPtBR();
        public string _StartContract { get { return StartContract.HasValue ? StartContract.ToBrazilianDateFormat() : DateTime.Now.ToBrazilianDateFormat(); } set { StartContract = value.FromBrazilianDateFormat(); } }
        public string _DueDate { get { return DueDate.ToBrazilianDateFormat(); } set { DueDate = value.FromBrazilianDateFormat(); } }
        public string _RenewDate { get { return RenewDate.ToBrazilianDateFormat(); } set { RenewDate = value.FromBrazilianDateFormat(); } }
        public int? ContractStatusId { get; set; }
        public string ContractStatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool HasFile { get; set; }
        public string DemandIds { get; set; }
        public string DemandDestinationIds { get; set; }
        public double? RemainingWeight { get; set; }
        public bool Regular { get; set; }
        public bool ToRenew { get; set; }
        public bool NewRenew { get; set; }
        public bool CanDelete { get; set; }
    }
}
