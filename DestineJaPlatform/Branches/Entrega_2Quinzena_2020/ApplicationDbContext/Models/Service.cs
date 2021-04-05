using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Code { get; set; }
        public int ClientId { get; set; }
        public string ContactName { get; set; }
        public string ContactCpf { get; set; }
        public string ContactRole { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobilePhone { get; set; }
        public string ContactEmail { get; set; }
        public string Observation { get; set; }
        public double FreightPrice { get; set; }
        public int ServiceFreightPaymentTermId { get; set; }
        public int ServiceResidualPaymentTermId { get; set; }
        public int ServiceSituationId { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime? CreationConfirmedDate { get; set; }
        public int? CreationConfirmedBy { get; set; }

        #region [ACCEPTED TERM]
        public Guid? AcceptTermToken { get; set; }
        public bool AcceptTermEmailSended { get; set; }
        public DateTime? AcceptTermEmailSendedDate { get; set; }
        public bool TermAccepted { get; set; }
        public DateTime? TermAcceptedDate { get; set; }
        #endregion

        #region [SERVICE ORDER FILE]
        public string ServiceOrderFileGuidName { get; set; }
        public string ServiceOrderFileName { get; set; }
        public string ServiceOrderMimeType { get; set; }
        #endregion

        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; } //Serviços criados até 18/08/2020 estão com IsActive = false, dessa forma não aparecem na listagem (Pedido do Ruan).
    }
}
