using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public string ContactName { get; set; }
        public string ContactCpf { get; set; }
        public string ContactRole { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobilePhone { get; set; }
        public string ContactEmail { get; set; }
        public double ParcelValue { get; set; }
        public DateTime StartContract { get; set; }
        public DateTime DueDate { get; set; }
        public int ContractSituationId { get; set; }
        public int ContractPeriodicityId { get; set; }
        public int ContractedWeight { get; set; }
        public int DueDay { get; set; }
        public string Observation { get; set; }
        public double? SuckerFreight { get; set; }
        public int ContractStatusId { get; set; }
        public DateTime? CreationConfirmedDate { get; set; }
        public int? CreationConfirmedBy { get; set; }
        public string ClosedReason { get; set; }
        public DateTime? ClosedDate { get; set; }


        #region [ACCEPTED TERM]
        public Guid? AcceptTermToken { get; set; }
        public bool AcceptTermEmailSended { get; set; }
        public DateTime? AcceptTermEmailSendedDate { get; set; }
        public bool TermAccepted { get; set; }
        public DateTime? TermAcceptedDate { get; set; }
        #endregion

        #region [CONTRACT FILE]
        public string FileGuidName { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
        #endregion

        public bool? Signed { get; set; }
        public int? SignedBy { get; set; }

        public DateTime? RenewDate { get; set; }
        public int? RenewFrom { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
