using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ASAAS.Payment
{
    public class PaymentModel : Shared.BaseObject
    {
        public DateTime DateCreated { get; set; }
        public string Customer { get; set; }
        public double Value { get; set; }
        public double NetValue { get; set; }
        public double? OriginalValue { get; set; }
        public double? InterestValue { get; set; }
        public string Description { get; set; }
        public string BillingType { get; set; }
        public string Status { get; set; }
        public string _Status
        {
            get
            {
                switch (Status.ToUpper())
                {
                    case "PENDING": return "Aguardando pagamento";
                    case "RECEIVED": return "Recebida";
                    case "CONFIRMED": return "Pagamento confirmado";
                    case "OVERDUE": return "Vencida";
                    case "REFUNDED": return "Estornada";
                    case "RECEIVED_IN_CASH": return "Recebida em dinheiro";
                    case "REFUND_REQUESTED": return "Estorno solicitado";
                    case "CHARGEBACK_REQUESTED": return "Recebido chargeback";
                    case "CHARGEBACK_DISPUTE": return "Em disputa de chargeback";
                    case "AWAITING_CHARGEBACK_REVERSAL": return "Disputa vencida, aguardando repasse da adquirente";
                    case "DUNNING_REQUESTED": return "Em processo de recuperação";
                    case "DUNNING_RECEIVED": return "Recuperada";
                    case "AWAITING_RISK_ANALYSIS": return "Pagamento em análise";
                    default:
                        break;
                }

                return "-";
            }
        }
        public bool IsPayed
        {
            get
            {
                switch (Status.ToUpper())
                {
                    case "RECEIVED":
                    case "CONFIRMED":
                    case "RECEIVED_IN_CASH":
                        return true;
                    default:
                        return false;
                }
            }
        }
        public bool IsOverdue
        {
            get
            {
                return (Status.ToUpper()) switch
                {
                    "OVERDUE" => true,
                    _ => false,
                };
            }
        }
        public DateTime DueDate { get; set; }
        public DateTime OriginalDueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ClientPaymentDate { get; set; }
        public string InvoiceUrl { get; set; }
        public string InvoiceNumber { get; set; }
        public string ExternalReference { get; set; }
        public bool Deleted { get; set; }
        public string BankSlipUrl { get; set; }
        public bool PostalService { get; set; }
        public bool Anticipated { get; set; }
    }
}
