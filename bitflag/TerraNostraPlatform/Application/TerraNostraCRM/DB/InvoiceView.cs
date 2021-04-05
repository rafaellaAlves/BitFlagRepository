using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public partial class InvoiceView
    {
        [Key]
        public int InvoiceId { get; set; }
        public string JobTerraNostraId { get; set; }
        public int ClientId { get; set; }
        public int? ResponsibleId { get; set; }
        public string ClientName { get; set; }
        public int FreezedFamilyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get; set; }
        public string StatusName { get; set; }
        public double Cost { get; set; }
        public double Tax { get; set; }
        public double GrandTotal { get; set; }
        public int InvoiceStatusId { get; set; }
        public int? InvoicePaymentWayId { get; set; }
        public int InvoiceServiceTypeId { get; set; }
        public bool Started { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string _ApprovedDate { get; set; }
        public int? ExternalCode { get; set; }
    }
}
