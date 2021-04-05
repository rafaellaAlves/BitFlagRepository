using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class CertificateContractualViewModel
    {

        public int? CertificateContractualId { get; set; }
        public string Reference { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public int? GuarantorId { get; set; }
        public string GuarantorName { get; set; }
        public int? CategoryId { get; set; }
        public int GuarantorProductId { get; set; }
        public string GuarantorProductName { get; set; }
        public int? ClientStatusId { get; set; }
        public int ResidenceTypeId { get; set; }
        public string ClientFullName { get; set; }
        public string CPFCNPJ { get; set; }
        public string _CPFCNPJ { get { return CPFCNPJ.CNPJOrCPFmask(); } set { CPFCNPJ = value.NumbersOnly(); } }
        public string CertificateContratualDocument { get; set; }
        public string _CertificateContratualDocument { get { return CertificateContratualDocument.CNPJMask(); } set { CertificateContratualDocument = value.NumbersOnly(); } }
        public double? RendaMensal { get; set; }
        public string _RendaMensal { get { return RendaMensal.ToPtBR(); } set { RendaMensal = value.FromDoublePtBR(); } }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? Telefone { get; set; }
        public int? Celular { get; set; }
        public double Aluguel { get; set; }
        public string _Aluguel { get { return Aluguel.ToPtBR(); } set { Aluguel = value.FromDoublePtBR().Value; } }
        public double? PriceQuote { get; set; }
        public string _PriceQuote { get { return PriceQuote.ToPtBR(); } }
        public int StatusTypeId { get; set; }
        public double? ValorFinal { get; set; }
        public string _ValorFinal { get { return ValorFinal.ToPtBR(); } set { ValorFinal = value.FromDoublePtBR(); } }
        public int? CategoryGuarantorProductTaxId { get; set; }
        public int? RegimeTributarioId { get; set; }
        public int? UtilizacaoId { get; set; }
        public double? FaturamentoMedio { get; set; }
        public string _FaturamentoMedio { get { return FaturamentoMedio.ToPtBR(); } set { FaturamentoMedio = value.FromDoublePtBR(); } }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }   
        public DateTime? ModifiedDate { get; set; }    
        public DateTime? VigenceDate { get; set; }
        public DateTime? VigenceEndDate { get; set; }
        public bool OutOfVigence { get { return VigenceEndDate.HasValue && DateTime.Compare(VigenceEndDate.Value, DateTime.Now) < 1; } }
        public bool Inactive { get { return OutOfVigence || IsDeleted; } }
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
        public int? PaymentWayId { get; set; }
        public bool IsDeleted { get; set; }
        public int? CertificateContractualIncomeTypeId { get; set; }
        public string Occupation { get; set; }
        public double? IPTU { get; set; }
        public string _IPTU { get => IPTU.ToPtBR(); set => IPTU = value.FromDoublePtBR(); }
        public double? CondominiumPrice { get; set; }
        public string _CondominiumPrice { get => CondominiumPrice.ToPtBR(); set => CondominiumPrice = value.FromDoublePtBR(); }
        public double? Total { get; set; }
        public string _Total { get => Total.ToPtBR(); set => Total = value.FromDoublePtBR(); }
        public double? LightPrice { get; set; }
        public string _LightPrice { get => LightPrice.ToPtBR(); set => LightPrice = value.FromDoublePtBR(); }
        public double? WaterPrice { get; set; }
        public string _WaterPrice { get => WaterPrice.ToPtBR(); set => WaterPrice = value.FromDoublePtBR(); }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get => BirthDate.ToDateTimePtBR(); set => BirthDate = value.FromDatePtBR(); }
        public string OldZipCode { get; set; }
        public int? MartialStatusId { get; set; }
        public string DevolutionReason { get; set; }
        public string PendencyDescription { get; set; }
        public int? CertificateContractualPaymentTypeId { get; set; }
        public double? InstallmentPrice { get; set; }
        public string _InstallmentPrice { get => InstallmentPrice.ToPtBR(); set => InstallmentPrice = value.FromDoublePtBR(); }
        public DateTime? InstallmentDate { get; set; }
        public string _InstallmentDate => InstallmentDate.ToShortDatePtBR();
        public int? InstallmentCount { get; set; }
    }
}
