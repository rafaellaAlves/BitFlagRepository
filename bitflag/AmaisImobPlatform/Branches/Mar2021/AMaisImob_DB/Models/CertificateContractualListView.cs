using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateContractualListView
    {
        public string Reference { get; set; }
        [Key]
        public int CertificateContractualId { get; set; }
        public int RealEstateAgencyId { get; set; }
        public string RealEstateAgencyName { get; set; }
        public string RealEstateAgencyDocument { get; set; }
        public string RealEstateAgencyEmail { get; set; }
        public string RealEstateAgencyPhone { get; set; }
        public int RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public string RealEstateNomeFantasia { get; set; }
        public string RealEstateDocument { get; set; }
        public string RealEstateEmail { get; set; }
        public string RealEstatePhone { get; set; }
        public int ClientStatusId { get; set; }
        public string ClientFullName { get; set; }
        public string CPFCNPJ { get; set; }    
        public int ResidenceTypeId { get; set; }
        public string ResidenceTypeName { get; set; }
        public int? CategoryGuarantorProductTaxId { get; set; }
        public int? GuarantorId { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorProductName { get; set; }
        public double Aluguel { get; set; }
        public int StatusTypeId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? VigenceDate { get; set; }
        public DateTime? VigenceEndDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool OutOfVigency { get; set; }
        public string RefusedFileGUID { get; set; }
        public string RefusedFileName { get; set; }
        public string RefusedFileMimeType { get; set; }
        public string ApprovedFileGUID { get; set; }
        public string ApprovedFileName { get; set; }
        public string ApprovedFileMimeType { get; set; }
        public string PolicyFileGUID { get; set; }
        public string PolicyFileName { get; set; }
        public string PolicyFileMimeType { get; set; }
        public string ContractFileGUID { get; set; }
        public string ContractFileName { get; set; }
        public string ContractFileMimeType { get; set; }
        public double? PriceQuote { get; set; }
        public int? PaymentWayId { get; set; }
        public string PaymentWayName { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string UtilizacaoName { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public double? RendaMensal { get; set; }
        public string Occupation { get; set; }
        public string OldZipCode { get; set; }
        public string MartialStatusName { get; set; }
        public string CertificateContractualIncomeTypeName { get; set; }
        public string CertificateContratualDocument { get; set; }
        public string PendencyDescription { get; set; }
        public string PaymentTypeName { get; set; }
        public bool AllInstallmentsPaided { get; set; }
        public double? InstallmentPrice { get; set; }
        public int? InstallmentCount { get; set; }
        public string DevolutionReason { get; set; }
        public double? TotalPrice { get; set; }
    }
}
