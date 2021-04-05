using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Contract
{
    public class ContractViewModel
    {
        public int? ContractId { get; set; }
        public int? ClientId { get; set; }
        public string Code { get; set; }
        public string ContactName { get; set; }
        public string ContactRole { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobilePhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactCpf { get; set; }
        public string _ContactCpf { get => ContactCpf.NumbersOnly();  set => ContactCpf = value.NumbersOnly(); }
        [Update]
        public double? ParcelValue { get; set; }
        public string _ParcelValue { get { return ParcelValue.ToPtBR(); } set { ParcelValue = value.FromDoublePtBR(); } }
        [Update]
        public DateTime? StartContract { get; set; }
        public string _StartContract { get { return StartContract.HasValue? StartContract.ToBrazilianDateFormat() : DateTime.Now.ToBrazilianDateFormat(); } set { StartContract = value.FromBrazilianDateFormat(); } }
        [Update]
        public DateTime? DueDate { get; set; }
        public string _DueDate { get { return DueDate.ToBrazilianDateFormat(); } set { DueDate = value.FromBrazilianDateFormat(); } }
        [Update]
        public int ContractSituationId { get; set; }
        [Update]
        public int ContractPeriodicityId { get; set; }
        [Update]
        public double? ContractedWeight { get; set; }
        [Update]
        public int? DueDay { get; set; }
        [Update]
        public string Observation { get; set; }
        [Update]
        public double? SuckerFreight { get; set; }
        public string _SuckerFreight { get { return SuckerFreight.ToPtBR(); } set { SuckerFreight = value.FromDoublePtBR(); } }
        public DateTime? RenewDate { get; set; }
        public int? RenewFrom { get; set; }
        public int ContractStatusId { get; set; }
        public DateTime? CreationConfirmedDate { get; set; }
        public int? CreationConfirmedBy { get; set; }
        [Update]
        public string ClosedReason { get; set; }
        public DateTime? ClosedDate { get; set; }

        public bool? Signed { get; set; }
        public int? SignedBy { get; set; }

        #region [ACCEPTED TERM]
        public Guid? AcceptTermToken { get; set; }
        public bool AcceptTermEmailSended { get; set; }
        public DateTime? AcceptTermEmailSendedDate { get; set; }
        public bool TermAccepted { get; set; }
        public DateTime? TermAcceptedDate { get; set; }
        public string _TermAcceptedDate => TermAcceptedDate.ToBrazilianDateFormat();
        public string TermAcceptedDateTime => TermAcceptedDate.ToBrazilianTimeNoSecondsFormat();
        #endregion

        #region [CONTRACT FILE]
        public string FileGuidName { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
        #endregion

        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }

        public bool Renewing { get; set; }
    }
}
