using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class CertificateContractualListViewModel
    {
        public string Reference { get; set; }
        public int CertificateContractualId { get; set; }
        public int RealEstateAgencyId { get; set; }
        public string RealEstateAgencyName { get; set; }
        public string RealEstateAgencyDocument { get; set; }
        public string _RealEstateAgencyDocument { get { return RealEstateAgencyDocument.CNPJOrCPFmask(); } }
        public string RealEstateAgencyEmail { get; set; }
        public string RealEstateAgencyPhone { get; set; }
        public int RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public string RealEstateNomeFantasia { get; set; }
        public string RealEstateDocument { get; set; }
        public string _RealEstateDocument { get { return RealEstateDocument.CNPJOrCPFmask(); } }
        public string RealEstateEmail { get; set; }
        public string RealEstatePhone { get; set; }
        public int ClientStatusId { get; set; }
        public string ClientFullName { get; set; }
        public string CPFCNPJ { get; set; }
        public string _CPFCNPJ { get { return CPFCNPJ.CNPJOrCPFmask(); } }
        public string CertificateContratualDocument { get; set; }
        public string _CertificateContratualDocument { get { return CertificateContratualDocument.CNPJMask(); } }
        public int ResidenceTypeId { get; set; }
        public double? RendaMensal { get; set; }
        public string _RendaMensal => RendaMensal.ToPtBR();
        public string Occupation { get; set; }
        public string OldZipCode { get; set; }
        public string ResidenceTypeName { get; set; }
        public int? CategoryGuarantorProductTaxId { get; set; }
        public int? GuarantorId { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorProductName { get; set; }
        public double Aluguel { get; set; }
        public string _Aluguel { get { return Aluguel.ToPtBR(); } }
        public int StatusTypeId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? VigenceDate { get; set; }
        public DateTime? VigenceEndDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate => BirthDate.ToDatePtBR();
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
        public string _PriceQuote { get { return PriceQuote.ToPtBR(); } }
        public int? PaymentWayId { get; set; }
        public string PaymentWayName { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string _CEP { get { return CEP.CEPMask(); } }
        public string UtilizacaoName { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string MartialStatusName { get; set; }
        public string CertificateContractualIncomeTypeName { get; set; }
        public string PendencyDescription { get; set; }
        public string PaymentTypeName { get; set; }
        public bool AllInstallmentsPaided { get; set; }
        public double? InstallmentPrice { get; set; }
        public string _InstallmentPrice => InstallmentPrice.ToPtBR();
        public int? InstallmentCount { get; set; }
        public string DevolutionReason { get; set; }
        public double? TotalPrice { get; set; }
    }
}
