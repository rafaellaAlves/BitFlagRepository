using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateContractual
    {
        public int CertificateContractualId { get; set; }
        public string Reference { get; set; }
        public int RealEstateAgencyId { get; set; }
        public int RealEstateId { get; set; }
        public int ClientStatusId { get; set; }
        public int ResidenceTypeId { get; set; }
        public string ClientFullName { get; set; }
        public string CPFCNPJ { get; set; }      
        public double? RendaMensal { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double Aluguel { get; set; }
        public int StatusTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public double? ValorFinal { get; set; }
        public int? CategoryGuarantorProductTaxId { get; set; }
        public int? RegimeTributarioId { get; set; }
        public double? FaturamentoMedio { get; set; }
        public int? UtilizacaoId { get; set; }
        public int GuarantorProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? VigenceDate { get; set; }
        public DateTime? VigenceEndDate { get; set; }
        public string RefusedFileGUID { get; set; }
        public string RefusedFileName { get; set; }
        public string RefusedFileMimeType { get; set; }
        public string ApprovedFileGUID { get; set; }
        public string ApprovedFileName { get; set; }
        public string ApprovedFileMimeType { get; set; }
        public string ContractFileGUID { get; set; }
        public string ContractFileName { get; set; }
        public string ContractFileMimeType { get; set; }
        public string PolicyFileGUID { get; set; }
        public string PolicyFileName { get; set; }
        public string PolicyFileMimeType { get; set; }
        public double? PriceQuote { get; set; }
        public int? PaymentWayId { get; set; }
        public int? CertificateContractualIncomeTypeId { get; set; }
        public string CertificateContratualDocument { get; set; }
        public string Occupation { get; set; }
        public double IPTU { get; set; }
        public double CondominiumPrice { get; set; }
        public double Total { get; set; }
        public double LightPrice { get; set; }
        public double WaterPrice { get; set; }
        public DateTime? BirthDate { get; set; }
        public string OldZipCode { get; set; }
        public int? MartialStatusId { get; set; }
        public string DevolutionReason { get; set; }
        public string PendencyDescription { get; set; }
        public int? CertificateContractualPaymentTypeId { get; set; }
        public double? InstallmentPrice { get; set; }
        public DateTime? InstallmentDate { get; set; }
        public int? InstallmentCount { get; set; }
    }
}
