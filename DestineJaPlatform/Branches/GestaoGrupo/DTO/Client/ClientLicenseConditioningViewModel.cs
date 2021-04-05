using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientLicenseConditioningViewModel
    {
        public int? ClientLicenseConditioningId { get; set; }
        public int ClientLicenseId { get; set; }
        [Update]
        public string Number { get; set; }
        [Update]
        public string Description { get; set; }
        [Update]
        public int? DaysToRegularize { get; set; }
        [Update]
        public int? DaysToNotify { get; set; }
        [Update]
        public int ClientLicenseConditioningPeriodicityId { get; set; }
        [Update]
        public string Protocol { get; set; }
        [Update]
        public DateTime? ProtocolDate { get; set; }
        public string ProtocolDateFormated { get => ProtocolDate.ToBrazilianDateFormat(); set => ProtocolDate = value.FromBrazilianDateFormatNullable(); }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
