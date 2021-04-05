using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.BouncyCastle.Crypto.Prng;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualFunctions : BLLBasicFunctions<CertificateContractual, CertificateContractualViewModel>
    {
        private readonly BLL.GuarantorProductFunctions guarantorProductFunctions;
        private readonly BLL.GuarantorFunctions guarantorFunctions;
        private readonly BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly StatusTypeFunctions statusTypeFunctions;
        public CertificateContractualFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context, StatusTypeFunctions statusTypeFunctions)
            : base(context, "CertificateContractualId")
        {
            this.guarantorProductFunctions = new BLL.GuarantorProductFunctions(context);
            this.guarantorFunctions = new BLL.GuarantorFunctions(context);
            this.categoryGuarantorProductTaxFunctions = new BLL.CategoryGuarantorProductTaxFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.statusTypeFunctions = statusTypeFunctions;
        }
        public override int Create(CertificateContractualViewModel model)
        {
            var certificateContractual = model.CopyToEntity<CertificateContractual>();

            this.dbSet.Add(certificateContractual);
            this.context.SaveChanges();

            return certificateContractual.CertificateContractualId;
        }

        public override void Delete(object id)
        {
            var certificateContractual = this.GetDataByID(id);

            certificateContractual.IsDeleted = true;

            this.context.Update(certificateContractual);
            this.context.SaveChanges();
        }

        public override List<CertificateContractualViewModel> GetDataViewModel(IEnumerable<CertificateContractual> data)
        {
            //var categories = categoryFunctions.GetData();
            var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetData();
            var guarantor = guarantorFunctions.GetData();
            var guarantorProduct = guarantorProductFunctions.GetData();
            var realEstate = companyFunctions.GetData(x => x.ParentCompanyId != null);

            var q = (from y in data.ToList()
                     join gp in guarantorProduct on y.GuarantorProductId equals gp.GuarantorProductId
                     join r in realEstate on y.RealEstateId equals r.CompanyId
                     join __c in categoryGuarantorProductTax on y.CategoryGuarantorProductTaxId equals __c.CategoryGuarantorProductTaxId into _c
                     from c in _c.DefaultIfEmpty()
                     join __g in guarantor on c?.GuarantorId equals __g.GuarantorId into _g
                     from g in _g.DefaultIfEmpty()
                     select new Models.CertificateContractualViewModel()
                     {
                         CertificateContractualId = y.CertificateContractualId,
                         RealEstateAgencyId = y.RealEstateAgencyId,
                         RealEstateId = y.RealEstateId,
                         RealEstateName = r.RazaoSocial != null ? r.RazaoSocial : r.FirstName + ' ' + r.LastName,
                         GuarantorName = g?.NomeFantasia,
                         CategoryId = r.CategoryId,
                         GuarantorId = c?.GuarantorId,
                         GuarantorProductId = gp.GuarantorProductId,
                         GuarantorProductName = gp.Description,
                         ClientStatusId = y.ClientStatusId,
                         ResidenceTypeId = y.ResidenceTypeId,
                         ClientFullName = y.ClientFullName,
                         CPFCNPJ = y.CPFCNPJ,
                         RendaMensal = y.RendaMensal,
                         CEP = y.CEP,
                         Endereco = y.Endereco,
                         Numero = y.Numero,
                         Complemento = y.Complemento,
                         Bairro = y.Bairro,
                         Cidade = y.Cidade,
                         Estado = y.Estado,
                         Aluguel = y.Aluguel,
                         StatusTypeId = y.StatusTypeId,
                         ValorFinal = y.ValorFinal,
                         CategoryGuarantorProductTaxId = y.CategoryGuarantorProductTaxId,
                         RegimeTributarioId = y.RegimeTributarioId,
                         FaturamentoMedio = y.FaturamentoMedio,
                         UtilizacaoId = y.UtilizacaoId,
                         PriceQuote = y.PriceQuote,
                         PaymentWayId = y.PaymentWayId,
                         IsDeleted = y.IsDeleted,
                         Reference = y.Reference,
                         VigenceDate = y.VigenceDate,
                         VigenceEndDate = y.VigenceEndDate,
                         CertificateContractualIncomeTypeId = y.CertificateContractualIncomeTypeId,
                         Occupation = y.Occupation,
                         Total = y.Total,
                         CondominiumPrice = y.CondominiumPrice,
                         WaterPrice = y.WaterPrice,
                         LightPrice = y.LightPrice,
                         OldZipCode = y.OldZipCode,
                         BirthDate = y.BirthDate,
                         MartialStatusId = y.MartialStatusId,
                         CreatedBy = y.CreatedBy,
                         CertificateContractualPaymentTypeId = y.CertificateContractualPaymentTypeId,
                         CertificateContratualDocument = y.CertificateContratualDocument,
                       
                     }).ToList();

            return q;
        }

        public override CertificateContractualViewModel GetDataViewModel(CertificateContractual data)
        {
            return data.CopyToEntity<CertificateContractualViewModel>();
        }

        public override void Update(CertificateContractualViewModel model)
        {
            var certificateContractual = this.GetDataByID(model.CertificateContractualId);

            certificateContractual.RealEstateAgencyId = model.RealEstateAgencyId.Value;
            certificateContractual.RealEstateId = model.RealEstateId.Value;
            certificateContractual.ClientStatusId = model.ClientStatusId.Value;
            certificateContractual.ResidenceTypeId = model.ResidenceTypeId;
            certificateContractual.ClientFullName = model.ClientFullName;
            certificateContractual.CPFCNPJ = model.CPFCNPJ;
            certificateContractual.CertificateContratualDocument = model.CertificateContratualDocument;
            certificateContractual.RendaMensal = model.RendaMensal;
            certificateContractual.CEP = model.CEP;
            certificateContractual.Endereco = model.Endereco;
            certificateContractual.Numero = model.Numero;
            certificateContractual.Complemento = model.Complemento;
            certificateContractual.Bairro = model.Bairro;
            certificateContractual.Cidade = model.Cidade;
            certificateContractual.Estado = model.Estado;
            certificateContractual.Aluguel = model.Aluguel;
            certificateContractual.PriceQuote = model.PriceQuote;
            if (model.StatusTypeId != 0) certificateContractual.StatusTypeId = model.StatusTypeId;
            certificateContractual.RegimeTributarioId = model.RegimeTributarioId;
            certificateContractual.FaturamentoMedio = model.FaturamentoMedio;
            certificateContractual.UtilizacaoId = model.UtilizacaoId;
            certificateContractual.GuarantorProductId = model.GuarantorProductId;
            certificateContractual.ModifiedDate = DateTime.Now;
            certificateContractual.PaymentWayId = model.PaymentWayId;
            certificateContractual.CertificateContractualIncomeTypeId = model.CertificateContractualIncomeTypeId;
            certificateContractual.Occupation = model.Occupation;

            if (model.IPTU.HasValue) certificateContractual.IPTU = model.IPTU.Value;
            if (model.CondominiumPrice.HasValue) certificateContractual.CondominiumPrice = model.CondominiumPrice.Value;
            if (model.Total.HasValue) certificateContractual.Total = model.Total.Value;
            if (model.LightPrice.HasValue) certificateContractual.LightPrice = model.LightPrice.Value;
            if (model.WaterPrice.HasValue) certificateContractual.WaterPrice = model.WaterPrice.Value;

            certificateContractual.BirthDate = model.BirthDate;
            certificateContractual.OldZipCode = model.OldZipCode;
           
            //certificateContractual.MartialStatusId = model.MartialStatusId;

            if (model.CategoryGuarantorProductTaxId.HasValue)
            {
                certificateContractual.ValorFinal = model.ValorFinal;
                certificateContractual.CategoryGuarantorProductTaxId = model.CategoryGuarantorProductTaxId;
            }

            this.context.Update(certificateContractual);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractual;
        }

        public void SetStatus(int certificateId, int statusId)
        {
            var certificateContratual = GetDataByID(certificateId);
            certificateContratual.StatusTypeId = statusId;
            certificateContratual.ModifiedDate = DateTime.Now;

            this.dbSet.Update(certificateContratual);
            this.context.SaveChanges();
        }

        public async Task Contract(int id, int? paymentWayId = null, DateTime? vigenceEndDate = null)
        {
            var entity = GetDataByID(id);
            var status = statusTypeFunctions.GetByExternalCode("CONTRATADO");
            var paymentTypeId = (await this.context.CertificateContractualPaymentType.SingleAsync(x => x.ExternalCode == "MONTHLY")).CertificateContractualPaymentTypeId;

            entity.VigenceDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.CertificateContractualPaymentTypeId = paymentTypeId;

            entity.StatusTypeId = status.StatusTypeId;

            if (paymentWayId.HasValue) entity.PaymentWayId = paymentWayId;
            if (vigenceEndDate.HasValue) entity.VigenceEndDate = vigenceEndDate;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Devolution(int id, string devolutionReason)
        {
            var entity = GetDataByID(id);
            var status = statusTypeFunctions.GetByExternalCode("APROVADO");
            var paymentType = await this.context.CertificateContractualPaymentType.SingleAsync(x => x.ExternalCode == "MONTHLY");

            entity.DevolutionReason = devolutionReason;
            entity.StatusTypeId = status.StatusTypeId;
            entity.CertificateContractualPaymentTypeId = paymentType.CertificateContractualPaymentTypeId;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
        

        public async Task SetPendency(int id, string pendencyDescription)
        {
            var entity = GetDataByID(id);

            entity.PendencyDescription = pendencyDescription;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateVigenceDate(int id, DateTime vigenceDate, DateTime vigenceDateEnd)
        {
            var entity = GetDataByID(id);

            entity.VigenceDate = vigenceDate;
            entity.VigenceEndDate = vigenceDateEnd;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateInstallmentPrice(int id, double? price)
        {
            var entity = GetDataByID(id);

            entity.InstallmentPrice = price;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateInstallmentCount(int id, int count)
        {
            var entity = GetDataByID(id);

            entity.InstallmentCount = count;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePaymentWay(int id, int paymentWayId)
        {
            var entity = GetDataByID(id);

            entity.PaymentWayId = paymentWayId;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateInstallment(int id, int paymentTypeId, double installmentPrice, DateTime? installmentDate, int? installmentCount)
        {
            var entity = GetDataByID(id);

            entity.CertificateContractualPaymentTypeId = paymentTypeId;
            entity.InstallmentPrice = installmentPrice;
            entity.InstallmentDate = installmentDate;
            entity.InstallmentCount = installmentCount;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRefusedFile(CertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.CertificateContractualId);

            entity.RefusedFileGUID = model.RefusedFileGUID;
            entity.RefusedFileName = model.RefusedFileName;
            entity.RefusedFileMimeType = model.RefusedFileMimeType;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateApprovedFile(CertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.CertificateContractualId);

            entity.ApprovedFileGUID = model.ApprovedFileGUID;
            entity.ApprovedFileName = model.ApprovedFileName;
            entity.ApprovedFileMimeType = model.ApprovedFileMimeType;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePolicyFile(CertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.CertificateContractualId);

            entity.PolicyFileGUID = model.PolicyFileGUID;
            entity.PolicyFileName = model.PolicyFileName;
            entity.PolicyFileMimeType = model.PolicyFileMimeType;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePolicyFile(AMaisImob_DB.Models.CertificateContractualApolicyFile model)
        {
            var entity = GetDataByID(model.CertificateContractualId);

            entity.PolicyFileGUID = model.FileGUID;
            entity.PolicyFileName = model.FileName;
            entity.PolicyFileMimeType = model.FileMimeType;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateContractFile(CertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.CertificateContractualId);

            entity.ContractFileGUID = model.ContractFileGUID;
            entity.ContractFileName = model.ContractFileName;
            entity.ContractFileMimeType = model.ContractFileMimeType;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<CertificateContractual> Clone(int certificateContractualId, int userId)
        {
            var entity = GetDataViewModel(GetDataByID(certificateContractualId));
            entity.CertificateContractualId = null;

            var clone = entity.CopyToEntity<CertificateContractual>();

            #region [Limpa os dados de arquivos]
            clone.ApprovedFileGUID = null;
            clone.ApprovedFileMimeType = null;
            clone.ApprovedFileName = null;
            clone.ContractFileGUID = null;
            clone.ContractFileMimeType = null;
            clone.ContractFileName = null;
            clone.PolicyFileGUID = null;
            clone.PolicyFileMimeType = null;
            clone.PolicyFileName = null;
            clone.RefusedFileGUID = null;
            clone.RefusedFileMimeType = null;
            clone.RefusedFileName = null;
            #endregion

            do { clone.Reference = Utils.ReferenceUtils.GetReference(); } while (await this.dbSet.AnyAsync(x => x.Reference == clone.Reference));

            clone.StatusTypeId = (await this.context.StatusType.FirstAsync(x => x.ExternalCode == "COTACAO")).StatusTypeId;
            clone.CategoryGuarantorProductTaxId = null;
            clone.PriceQuote = null;
            clone.CreatedDate = DateTime.Now;
            clone.CreatedBy = userId;
            clone.ModifiedDate = null;

            await this.dbSet.AddAsync(clone);
            await context.SaveChangesAsync();

            await CloneMembers(certificateContractualId, clone.CertificateContractualId);

            return clone;
        }

        public async Task CloneMembers(int certificateContractualId, int clonedCertificateContractualId)
        {
            var members = await this.context.CertificateContractualMember.Where(x => x.CertificateContractualId == certificateContractualId).AsNoTracking().Select(x => x.CopyToEntity<CertificateContractualMemberViewModel>()).ToListAsync();

            members.ForEach(x =>
            {
                x.CertificateContractualId = clonedCertificateContractualId;
                x.CertificateContractualMemberId = null;
            });

            var cloneMembers = members.Select(x => x.CopyToEntity<CertificateContractualMember>());

            await this.context.CertificateContractualMember.AddRangeAsync(cloneMembers);
            await context.SaveChangesAsync();
        }

        public async Task SaveGuarantorProductId(int certificateContractualId, int guarantorProductId)
        {
            var entity = GetDataByID(certificateContractualId);

            entity.GuarantorProductId = guarantorProductId;

            this.dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
