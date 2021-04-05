using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Service
{
    public class ServiceViewModel
    {
        public int? ServiceId { get; set; }
        public string Code { get; set; }
        public int? ClientId { get; set; }
        public string ContactName { get; set; }
        public string ContactCpf { get; set; }
        public string _ContactCpf { get => ContactCpf.NumbersOnly(); set => ContactCpf = value.NumbersOnly(); }
        public string ContactRole { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobilePhone { get; set; }
        public string ContactEmail { get; set; }
        [Update]
        public string Observation { get; set; }
        [Update]
        public double? FreightPrice { get; set; }
        public string _FreightPrice { get { return FreightPrice.ToPtBR(); } set { FreightPrice = value.FromDoublePtBR(); } }
        [Update]
        public int ServiceFreightPaymentTermId { get; set; }
        [Update]
        public int ServiceResidualPaymentTermId { get; set; }
        //[Update]
        public int ServiceSituationId { get; set; }
        [Update]
        public int ServiceStatusId { get; set; }
        public DateTime? CreationConfirmedDate { get; set; }
        public int? CreationConfirmedBy { get; set; }

        #region [ACCEPTED TERM]
        public Guid? AcceptTermToken { get; set; }
        public bool AcceptTermEmailSended { get; set; }
        public DateTime? AcceptTermEmailSendedDate { get; set; }
        public bool TermAccepted { get; set; }
        public DateTime? TermAcceptedDate { get; set; }
        public string _TermAcceptedDate => TermAcceptedDate.ToBrazilianDateFormat();
        public string TermAcceptedDateTime => TermAcceptedDate.ToBrazilianTimeNoSecondsFormat();
        #endregion

        #region [SERVICE ORDER FILE]
        public string ServiceOrderFileGuidName { get; set; }
        public string ServiceOrderFileName { get; set; }
        public string ServiceOrderMimeType { get; set; }
        #endregion

        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToBrazilianDateFormat(); } set { CreatedDate = value.FromBrazilianDateFormat(); } }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
