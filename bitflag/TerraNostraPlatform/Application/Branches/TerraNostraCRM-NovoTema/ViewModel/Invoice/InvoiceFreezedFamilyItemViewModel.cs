using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoiceFreezedFamilyItemViewModel
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

        public int QtdBirthItems
        {
            get
            {
                var qtdItems = 0;
                if (BirthCertificateBra) qtdItems++;
                if (BirthCertificateIta) qtdItems++;
                if (BirthCertificateTranslation) qtdItems++;
                if (BirthCertificateHaiaHandout) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdMarriageItems
        {
            get
            {
                var qtdItems = 0;
                if (MarriageCertificateBra) qtdItems++;
                if (MarriageCertificateIta) qtdItems++;
                if (MarriageCertificateTranslation) qtdItems++;
                if (MarriageCertificateHaiaHandout) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdDeathItems
        {
            get
            {
                var qtdItems = 0;
                if (DeathCertificateBra) qtdItems++;
                if (DeathCertificateIta) qtdItems++;
                if (DeathCertificateTranslation) qtdItems++;
                if (DeathCertificateHaiaHandout) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdCertBRA
        {
            get
            {
                var qtdItems = 0;
                if (BirthCertificateBra) qtdItems++;
                if (MarriageCertificateBra) qtdItems++;
                if (DeathCertificateBra) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdCertITA
        {
            get
            {
                var qtdItems = 0;
                if (BirthCertificateIta) qtdItems++;
                if (MarriageCertificateIta) qtdItems++;
                if (DeathCertificateIta) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdTranslation
        {
            get
            {
                var qtdItems = 0;
                if (BirthCertificateTranslation) qtdItems++;
                if (MarriageCertificateTranslation) qtdItems++;
                if (DeathCertificateTranslation) qtdItems++;

                return qtdItems;
            }
        }
        public int QtdHaiaHandout
        {
            get
            {
                var qtdItems = 0;
                if (BirthCertificateHaiaHandout) qtdItems++;
                if (MarriageCertificateHaiaHandout) qtdItems++;
                if (DeathCertificateHaiaHandout) qtdItems++;

                return qtdItems;
            }
        }
    }
}
