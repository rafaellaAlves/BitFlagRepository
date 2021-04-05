using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class ChargePriceItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int? AlternativeAmount { get; set; }
        public string Description => $"{AlternativeAmount ?? Amount} {(DocuSign? "envelopes" : "ativos")}";
        public double Price { get; set; }
        public string PriceFormated => Price.ToPtBR();
        public double? AlternativeTotalPrice { get; set; }
        public string AlternativeTotalPriceFormated => AlternativeTotalPrice.ToPtBR();

        public bool CertificateContractual { get; set; }
        public bool Certificate { get; set; }
        public bool DocuSign { get; set; }
        public int Order { get; set; }

        // Campo usados apenas para itens da garantia contratual
        public int? GuarantorId { get; set; }
        public int? ChargeCertificateContractualId { get; set; }
        public bool? CertificateContractualHasFile { get; set; }
        public bool? CertificateContractualHasInvoiceFile { get; set; }
        public DateTime? ChargeCreatedDate { get; set; }
        public string ChargeCreatedDateFormated => ChargeCreatedDate.ToDatePtBR();
    }
}
