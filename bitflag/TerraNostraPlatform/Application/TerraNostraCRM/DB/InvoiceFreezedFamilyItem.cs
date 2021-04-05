using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceFreezedFamilyItem
    {
        public int InvoiceFreezedFamilyItemId { get; set; }
        public int InvoiceId { get; set; }
        public int FreezedFamilyItemId { get; set; }
        public bool BirthCertificateBra { get; set; }
        public bool BirthCertificateIta { get; set; }
        public bool MarriageCertificateBra { get; set; }
        public bool MarriageCertificateIta { get; set; }
        public bool DeathCertificateBra { get; set; }
        public bool DeathCertificateIta { get; set; }
        public bool BirthCertificateTranslation { get; set; }
        public bool BirthCertificateHaiaHandout { get; set; }
        public bool MarriageCertificateTranslation { get; set; }
        public bool MarriageCertificateHaiaHandout { get; set; }
        public bool DeathCertificateTranslation { get; set; }
        public bool DeathCertificateHaiaHandout { get; set; }
        public bool Cnn { get; set; }
    }
}
