using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace WEB.BLL
{
    public class CertificateFunctions : BLLBasicFunctions<Certificate, CertificateViewModel>
    {
        private readonly BLL.ProductCoverageFunctions productCoverageFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.InsurancePolicyFunctions insurancePolicyFunctions;
        private readonly BLL.AssistanceFunctions assistanceFunctions;

        public CertificateFunctions(Insurance_HomologContext context)
            : base(context, "CertificateId")
        {
            this.productCoverageFunctions = new ProductCoverageFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.insurancePolicyFunctions = new BLL.InsurancePolicyFunctions(context);
            this.assistanceFunctions = new AssistanceFunctions(context);
        }

        public override int Create(CertificateViewModel model)
        {
            var certificate = new Certificate
            {
                Reference = model.Reference,
                ApprovedBy = model.ApprovedBy,
                ApprovedDate = model.ApprovedDate,
                Bairro = model.Bairro,
                Cep = model.Cep,
                ProductId = model.ProductId.Value,
                Cidade = model.Cidade,
                Complemento = model.Complemento,
                Endereco = model.Endereco,
                IsApproved = model.IsApproved ?? false,
                LocatorCpf = model.LocatorCpf,
                LocatorName = model.LocatorName,
                Numero = model.Numero,
                PropertyTypeDescription = model.PropertyTypeDescription,
                PropertyTypeId = model.PropertyTypeId.Value,
                RenterCpf = model.RenterCpf,
                RenterName = model.RenterName,
                Uf = model.Uf,
                PlanId = model.PlanId.Value,
                PaymentTimes = model.PaymentTimes.Value,
                AssistanceId = model.AssistanceId,
                InsurancePolicyId = model.InsurancePolicyId,
                RealEstateAgencyId = model.RealEstateAgencyId,
                RealEstateId = model.RealEstateId,
                TaxaInquilini = model.TaxaInquilini.Value,
                ConstructionTypeId = model.ConstructionTypeId,
                HabitationTypeId = model.HabitationTypeId,
                RenterEmail = model.RenterEmail,
                RenterPhone = model.RenterPhone,
                LocatorEmail = model.LocatorEmail,
                LocatorPhone = model.LocatorPhone,
                RealEstateReference = model.RealEstateReference,
                PlanPrice = model.PlanPrice.Value,
                IsSimulation = model.IsSimulation.Value,
                AdherenceDate = model.AdherenceDate,
                AdherenceBy = model.AdherenceBy,
                VigencyDate = model.VigencyDate,
                CreatedBy = model.CreatedBy
            };

            this.dbSet.Add(certificate);
            this.context.SaveChanges();

            return certificate.CertificateId;
        }

        public override void Delete(object id)
        {
            var certificate = GetDataByID(id);

            certificate.IsDeleted = true;
            certificate.DeletedDate = DateTime.Now;

            this.dbSet.Update(certificate);
            this.context.SaveChanges();
        }

        public void Delete(object id, int userId)
        {
            var certificate = GetDataByID(id);

            certificate.IsDeleted = true;
            certificate.DeletedDate = DateTime.Now;
            certificate.DeletedBy = userId;

            this.dbSet.Update(certificate);
            this.context.SaveChanges();
        }

        public override List<CertificateViewModel> GetDataViewModel(IEnumerable<Certificate> data)
        {
            return (from y in data
                    select new CertificateViewModel
                    {
                        Reference = y.Reference,
                        ApprovedBy = y.ApprovedBy,
                        ApprovedDate = y.ApprovedDate,
                        Bairro = y.Bairro,
                        Cep = y.Cep,
                        ProductId = y.ProductId,
                        Cidade = y.Cidade,
                        Complemento = y.Complemento,
                        Endereco = y.Endereco,
                        IsApproved = y.IsApproved,
                        LocatorCpf = y.LocatorCpf,
                        LocatorName = y.LocatorName,
                        Numero = y.Numero,
                        PropertyTypeDescription = y.PropertyTypeDescription,
                        PropertyTypeId = y.PropertyTypeId,
                        RenterCpf = y.RenterCpf,
                        RenterName = y.RenterName,
                        Uf = y.Uf,
                        CertificateId = y.CertificateId,
                        IsDeleted = y.IsDeleted,
                        PlanId = y.PlanId,
                        PaymentTimes = y.PaymentTimes,
                        AssistanceId = y.AssistanceId,
                        InsurancePolicyId = y.InsurancePolicyId,
                        RealEstateAgencyId = y.RealEstateAgencyId,
                        RealEstateId = y.RealEstateId,
                        TaxaInquilini = y.TaxaInquilini,
                        ConstructionTypeId = y.ConstructionTypeId,
                        HabitationTypeId = y.HabitationTypeId,
                        RenterPhone = y.RenterPhone,
                        RenterEmail = y.RenterEmail,
                        DeletedBy = y.DeletedBy,
                        DeletedDate = y.DeletedDate,
                        LocatorEmail = y.LocatorEmail,
                        LocatorPhone = y.LocatorPhone,
                        RealEstateReference = y.RealEstateReference,
                        CreatedDate = y.CreatedDate,
                        PlanPrice = y.PlanPrice,
                        CopiedBy = y.CopiedBy,
                        IsSimulation = y.IsSimulation,
                        AdherenceDate = y.AdherenceDate,
                        VigencyDate = y.VigencyDate,
                        CreatedBy = y.CreatedBy,
                        Locatorcpf = y.LocatorCpf,
                        Rentercpf = y.RenterCpf,
                        BlockRenew = y.BlockRenew
                    }).ToList();
        }

        public override CertificateViewModel GetDataViewModel(Certificate data)
        {
            string deleteUserName = "";
            if (data.DeletedBy.HasValue)
            {
                var user = this.context.User.SingleOrDefault(x => x.UserId == data.DeletedBy);
                deleteUserName = user.FirstName + " " + user.LastName;
            }

            return new CertificateViewModel
            {
                Reference = data.Reference,
                ApprovedBy = data.ApprovedBy,
                ApprovedDate = data.ApprovedDate,
                Bairro = data.Bairro,
                Cep = data.Cep,
                ProductId = data.ProductId,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                Endereco = data.Endereco,
                IsApproved = data.IsApproved,
                LocatorCpf = data.LocatorCpf,
                LocatorName = data.LocatorName,
                Numero = data.Numero,
                PropertyTypeDescription = data.PropertyTypeDescription,
                PropertyTypeId = data.PropertyTypeId,
                RenterCpf = data.RenterCpf,
                RenterName = data.RenterName,
                Uf = data.Uf,
                CertificateId = data.CertificateId,
                IsDeleted = data.IsDeleted,
                PlanId = data.PlanId,
                PaymentTimes = data.PaymentTimes,
                AssistanceId = data.AssistanceId,
                InsurancePolicyId = data.InsurancePolicyId,
                RealEstateAgencyId = data.RealEstateAgencyId,
                RealEstateId = data.RealEstateId,
                TaxaInquilini = data.TaxaInquilini,
                ConstructionTypeId = data.ConstructionTypeId,
                HabitationTypeId = data.HabitationTypeId,
                RenterPhone = data.RenterPhone,
                RenterEmail = data.RenterEmail,
                DeletedBy = data.DeletedBy,
                DeletedDate = data.DeletedDate,
                LocatorEmail = data.LocatorEmail,
                LocatorPhone = data.LocatorPhone,
                RealEstateReference = data.RealEstateReference,
                NameDeletedBy = deleteUserName,
                CreatedDate = data.CreatedDate,
                PlanPrice = data.PlanPrice,
                CopiedBy = data.CopiedBy,
                IsSimulation = data.IsSimulation,
                AdherenceDate = data.AdherenceDate,
                VigencyDate = data.VigencyDate,
                CreatedBy = data.CreatedBy,
                Locatorcpf = data.LocatorCpf,
                Rentercpf = data.RenterCpf,
                BlockRenew = data.BlockRenew
            };
        }


        public CertificateViewModel GetDataViewModelForAuditLog(Certificate data)
        {
            var product = this.context.Product.SingleOrDefault(x => x.ProductId == data.ProductId);
            var insurancePolicie = this.context.InsurancePolicy.SingleOrDefault(x => x.InsurancePolicyId == data.InsurancePolicyId);
            var realEstateAgencie = companyFunctions.GetDataViewModel(this.context.Company.SingleOrDefault(x => x.CompanyId == data.RealEstateAgencyId));
            var realEstate = companyFunctions.GetDataViewModel(this.context.Company.SingleOrDefault(x => x.CompanyId == data.RealEstateId));
            var assistance = this.context.Assistance.SingleOrDefault(x => x.AssistanceId == data.AssistanceId);
            var plan = this.context.Plan.SingleOrDefault(x => x.PlanId == data.PlanId);

            string deleteUserName = "";
            if (data.DeletedBy.HasValue)
            {
                var user = this.context.User.SingleOrDefault(x => x.UserId == data.DeletedBy);
                deleteUserName = user.FirstName + " " + user.LastName;
            }

            return new CertificateViewModel
            {
                Reference = data.Reference,
                ApprovedBy = data.ApprovedBy,
                ApprovedDate = data.ApprovedDate,
                Bairro = data.Bairro,
                Cep = data.Cep,
                ProductId = data.ProductId,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                Endereco = data.Endereco,
                IsApproved = data.IsApproved,
                LocatorCpf = data.LocatorCpf,
                LocatorName = data.LocatorName,
                Numero = data.Numero,
                PropertyTypeDescription = data.PropertyTypeDescription,
                PropertyTypeId = data.PropertyTypeId,
                RenterCpf = data.RenterCpf,
                RenterName = data.RenterName,
                Uf = data.Uf,
                CertificateId = data.CertificateId,
                IsDeleted = data.IsDeleted,
                PlanId = data.PlanId,
                PaymentTimes = data.PaymentTimes,
                AssistanceId = data.AssistanceId,
                InsurancePolicyId = data.InsurancePolicyId,
                RealEstateAgencyId = data.RealEstateAgencyId,
                RealEstateId = data.RealEstateId,
                TaxaInquilini = data.TaxaInquilini,
                ConstructionTypeId = data.ConstructionTypeId,
                HabitationTypeId = data.HabitationTypeId,
                RenterPhone = data.RenterPhone,
                RenterEmail = data.RenterEmail,
                DeletedBy = data.DeletedBy,
                DeletedDate = data.DeletedDate,
                LocatorEmail = data.LocatorEmail,
                LocatorPhone = data.LocatorPhone,
                RealEstateReference = data.RealEstateReference,
                NameDeletedBy = deleteUserName,
                CreatedDate = data.CreatedDate,
                PlanPrice = data.PlanPrice,
                CopiedBy = data.CopiedBy,
                IsSimulation = data.IsSimulation,
                AdherenceDate = data.AdherenceDate,
                VigencyDate = data.VigencyDate,
                CreatedBy = data.CreatedBy,
                AssistanceName = assistance?.Name,
                PlanName = plan?.Name,
                RealEstateAgencyName = realEstateAgencie.CompanyName,
                InsurancePolicyName = insurancePolicie.InsurancePolicyNumber,
                Locatorcpf = data.LocatorCpf,
                Rentercpf = data.RenterCpf,
                ProductName = product?.Name,
                RealEstateName = realEstate.CompanyName,
                BlockRenew = data.BlockRenew
            };
        }

        public override void Update(CertificateViewModel model)
        {
            var certificate = GetDataByID(model.CertificateId);

            certificate.Bairro = model.Bairro;
            certificate.Cep = model.Cep;
            certificate.Cidade = model.Cidade;
            certificate.Complemento = model.Complemento;
            certificate.Endereco = model.Endereco;
            certificate.Numero = model.Numero;
            certificate.RenterCpf = model.RenterCpf;
            certificate.RenterName = model.RenterName;
            certificate.Uf = model.Uf;
            certificate.RenterPhone = model.RenterPhone;
            certificate.RenterEmail = model.RenterEmail;
            certificate.LocatorCpf = model.LocatorCpf;
            certificate.LocatorName = model.LocatorName;
            certificate.LocatorEmail = model.LocatorEmail;
            certificate.LocatorPhone = model.LocatorPhone;
            certificate.RealEstateReference = model.RealEstateReference;
            certificate.IsSimulation = model.IsSimulation.Value;
            certificate.ModifiedBy = model.ModifiedBy;
            certificate.ModifiedDate = model.ModifiedDate;

            if (model.PlanId.HasValue)
            {
                certificate.PlanId = model.PlanId.Value;
                certificate.AssistanceId = model.AssistanceId;
            }
            if (model.PlanPrice.HasValue) certificate.PlanPrice = model.PlanPrice.Value;
            if (model.VigencyDate.HasValue) certificate.VigencyDate = model.VigencyDate;

            if (model.AdherenceDate.HasValue)
            {
                certificate.AdherenceDate = model.AdherenceDate;
                certificate.AdherenceBy = model.AdherenceBy;
            }
            if (model.IsApproved.HasValue)
            {
                certificate.IsApproved = model.IsApproved;
                certificate.ApprovedBy = model.ApprovedBy;
                certificate.ApprovedDate = model.ApprovedDate;
            }

            if (model.ProductId.HasValue)
            {
                certificate.ProductId = model.ProductId.Value;
                certificate.PropertyTypeDescription = model.PropertyTypeDescription;
                certificate.PropertyTypeId = model.PropertyTypeId.Value;
                certificate.PaymentTimes = model.PaymentTimes.Value;
                certificate.InsurancePolicyId = model.InsurancePolicyId;
                certificate.RealEstateAgencyId = model.RealEstateAgencyId;
                certificate.RealEstateId = model.RealEstateId;
                certificate.TaxaInquilini = model.TaxaInquilini.Value;
                certificate.ConstructionTypeId = model.ConstructionTypeId;
                certificate.HabitationTypeId = model.HabitationTypeId;
            }

            this.dbSet.Update(certificate);
            this.context.SaveChanges();
        }

        public _CertificateViewModel _GetDataViewModel(Certificate d)
        {
            return new Models._CertificateViewModel
            {
                Reference = d.Reference,
                Bairro = d.Bairro,
                Cep = d.Cep,
                ProductId = d.ProductId,
                Cidade = d.Cidade,
                Complemento = d.Complemento,
                Endereco = d.Endereco,
                IsApproved = d.IsApproved,
                LocatorCpf = d.LocatorCpf,
                LocatorName = d.LocatorName,
                Numero = d.Numero,
                PropertyTypeDescription = d.PropertyTypeDescription,
                PropertyTypeId = d.PropertyTypeId,
                RenterCpf = d.RenterCpf,
                RenterName = d.RenterName,
                Uf = d.Uf,
                CertificateId = d.CertificateId,
                IsDeleted = d.IsDeleted,
                InsurancePolicyId = d.InsurancePolicyId,
                RealEstateAgencyId = d.RealEstateAgencyId,
                RealEstateId = d.RealEstateId,
                ApprovedBy = d.ApprovedBy,
                ApprovedDate = d.ApprovedDate,
                AssistanceId = d.AssistanceId,
                ConstructionTypeId = d.ConstructionTypeId,
                HabitationTypeId = d.HabitationTypeId,
                PaymentTimes = d.PaymentTimes,
                PlanId = d.PlanId,
                TaxaInquilini = d.TaxaInquilini,
                RenterEmail = d.RenterEmail,
                RenterPhone = d.RenterPhone,
                CreatedDate = d.CreatedDate,
                LocatorEmail = d.LocatorEmail,
                LocatorPhone = d.LocatorPhone,
                RealEstateReference = d.RealEstateReference,
                PlanPrice = d.PlanPrice,
                CopiedFrom = d.CopiedFrom,
                AdherenceDate = d.AdherenceDate,
                VigencyDate = d.VigencyDate,
                BlockRenew = d.BlockRenew
            };
        }

        public List<CertificateListViewModel> GetCertificateListViewModel(IEnumerable<Certificate> d)
        {
            var certificates = this.context.Certificate.ToList();
            var products = productFunctions.GetData(c => !c.IsDeleted);
            var insurancePolicies = insurancePolicyFunctions.GetData(c => !c.IsDeleted);
            var realEstateAgencies = companyFunctions.GetRealEstateAgency();
            var realEstates = companyFunctions.GetRealEstate();
            var assistance = this.context.Assistance.ToList();
            var user = this.context.User.ToList();
            var plan = this.context.Plan.ToList();
            //var auditLog = this.context.AuditLog.Where(x => x.ActionType == DBActionType.UPDATE.ToString() && x.Entity == typeof(Models.CertificateViewModel).Name).ToList();

            return (from y in d
                    join _p in products on y.ProductId equals _p.ProductId
                    join i in insurancePolicies on y.InsurancePolicyId equals i.InsurancePolicyId
                    join r in realEstateAgencies on y.RealEstateAgencyId equals r.CompanyId
                    join _r in realEstates on y.RealEstateId equals _r.CompanyId

                    join cb in certificates on y.CopiedBy equals cb.CertificateId into _cb
                    from __cb in _cb.DefaultIfEmpty()

                    join db in user on y.DeletedBy equals db.UserId into _db
                    from __db in _db.DefaultIfEmpty()

                    join ab in user on y.AdherenceBy equals ab.UserId into _ab
                    from __ab in _ab.DefaultIfEmpty()

                    join rb in user on y.RenewBy equals rb.UserId into _rb
                    from __rb in _rb.DefaultIfEmpty()

                    join createdBy in user on y.CreatedBy equals createdBy.UserId into _createdBy
                    from __createdBy in _createdBy.DefaultIfEmpty()

                    join mb in user on y.ModifiedBy equals mb.UserId into _mb
                    from __mb in _mb.DefaultIfEmpty()

                        //join al in certificates on y.CopiedBy equals cb.CertificateId into _al
                        //from __al in _al.DefaultIfEmpty()
                    select new Models.CertificateListViewModel
                    {
                        Reference = y.Reference,
                        Bairro = y.Bairro,
                        Cep = y.Cep,
                        ProductId = y.ProductId,
                        ProductName = _p.Name,
                        Cidade = y.Cidade,
                        Complemento = y.Complemento,
                        Endereco = y.Endereco,
                        IsApproved = y.IsApproved,
                        LocatorCpf = y.LocatorCpf,
                        LocatorName = y.LocatorName,
                        Numero = y.Numero,
                        PropertyTypeDescription = y.PropertyTypeDescription,
                        PropertyTypeId = y.PropertyTypeId,
                        RenterCpf = y.RenterCpf,
                        RenterName = y.RenterName,
                        Uf = y.Uf,
                        CertificateId = y.CertificateId,
                        IsDeleted = y.IsDeleted,
                        InsurancePolicyId = y.InsurancePolicyId,
                        InsurancePolicyNumber = i.InsurancePolicyNumber,
                        RealEstateAgencyId = y.RealEstateAgencyId,
                        RealEstateAgencyName = string.IsNullOrWhiteSpace(r.NomeFantasia) ? r.FirstName + " " + r.LastName : r.NomeFantasia,
                        RealEstateAgencyHasCNPJ = !string.IsNullOrWhiteSpace(r.Cnpj),
                        RealEstateAgencyDocument = string.IsNullOrWhiteSpace(r.Cnpj) ? r.Cpf : r.Cnpj,
                        RealEstateId = y.RealEstateId,
                        RealEstateName = string.IsNullOrWhiteSpace(_r.NomeFantasia) ? _r.FirstName + " " + _r.LastName : _r.NomeFantasia,
                        RealEstateHasCNPJ = !string.IsNullOrWhiteSpace(_r.Cnpj),
                        RealEstateDocument = string.IsNullOrWhiteSpace(_r.Cnpj) ? _r.Cpf : _r.Cnpj,
                        RenterPhone = y.RenterPhone,
                        RenterEmail = y.RenterEmail,
                        CreatedDate = y.CreatedDate,
                        ApprovedBy = y.ApprovedBy,
                        ApprovedDate = y.ApprovedDate,
                        TotalPrice = y.PlanPrice + (((float)y.TaxaInquilini) / 12) + (y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Value : 0),
                        Taxes = ((float)y.TaxaInquilini) / 12,
                        RealEstateReference = y.RealEstateReference,
                        DeletedBy = y.DeletedBy,
                        DeletedDate = y.DeletedDate,
                        NameDeletedBy = __db != null ? __db.FirstName + " " + __db.LastName : "",
                        CopiedFrom = y.CopiedFrom,
                        CopiedBy = y.CopiedBy,
                        PlanPrice = y.PlanPrice,
                        PlanAssistancePrice = y.PlanPrice + (y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Value : 0),
                        PaymentTimes = y.PaymentTimes,
                        AdherenceDate = y.AdherenceDate,
                        VigencyDate = y.VigencyDate,
                        AdherenceBy = y.AdherenceBy,
                        NameAdherenceBy = __ab != null ? __ab.FirstName + " " + __ab.LastName : "",
                        CreatedBy = y.CreatedBy,
                        NameCreatedBy = __createdBy != null ? __createdBy.FirstName + " " + __createdBy.LastName : "",
                        RenewBy = y.RenewBy,
                        NameRenewBy = __rb != null ? __rb.FirstName + " " + __rb.LastName : "",
                        AssistanceName = y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Name : "",
                        PlanName = plan.Single(x => x.PlanId == y.PlanId).Name,
                        CopiedByReference = __cb != null ? __cb.Reference : "",
                        ModifiedBy = y.ModifiedBy,
                        ModifiedDate = y.ModifiedDate,
                        NameModifiedBy = __mb != null ? __mb.FirstName + " " + __mb.LastName : "",
                        BlockRenew = y.BlockRenew
                    }).ToList();
        }

        //public List<CertificateExportViewModel> GetCertificateExportViewModel(IEnumerable<Certificate> d)
        //{
        //    var constructionType = this.context.ConstructionType.ToList();
        //    var habitationType = this.context.HabitationType.ToList();
        //    var propertyTypes = propertyTypeFunctions.GetData();
        //    var products = productFunctions.GetData(c => !c.IsDeleted);
        //    var insurancePolicies = insurancePolicyFunctions.GetData(c => !c.IsDeleted);
        //    var realEstateAgencies = companyFunctions.GetRealEstateAgency();
        //    var realEstates = companyFunctions.GetRealEstate();
        //    var assistance = this.context.Assistance.ToList();
        //    var user = this.context.User.ToList();
        //    var plan = this.context.Plan.ToList();

        //    var res = (from y in d
        //               join p in propertyTypes on y.PropertyTypeId equals p.PropertyTypeId
        //               join _p in products on y.ProductId equals _p.ProductId
        //               join i in insurancePolicies on y.InsurancePolicyId equals i.InsurancePolicyId
        //               join r in realEstateAgencies on y.RealEstateAgencyId equals r.CompanyId
        //               join _r in realEstates on y.RealEstateId equals _r.CompanyId
        //               select new Models.CertificateExportViewModel
        //               {
        //                   Reference = y.Reference,
        //                   Bairro = y.Bairro,
        //                   Cep = y.Cep,
        //                   ProductId = y.ProductId,
        //                   ProductName = _p.Name,
        //                   Cidade = y.Cidade,
        //                   Complemento = y.Complemento,
        //                   Endereco = y.Endereco,
        //                   IsApproved = y.IsApproved,
        //                   LocatorCpf = y.LocatorCpf,
        //                   LocatorName = y.LocatorName,
        //                   Numero = y.Numero,
        //                   PropertyTypeDescription = y.PropertyTypeDescription,
        //                   PropertyTypeId = y.PropertyTypeId,
        //                   RenterCpf = y.RenterCpf,
        //                   RenterName = y.RenterName,
        //                   Uf = y.Uf,
        //                   CertificateId = y.CertificateId,
        //                   IsDeleted = y.IsDeleted,
        //                   PropertyTypeName = p.Name,
        //                   InsurancePolicyId = y.InsurancePolicyId,
        //                   InsurancePolicyNumber = i.InsurancePolicyNumber,
        //                   RealEstateAgencyId = y.RealEstateAgencyId,
        //                   RealEstateAgencyName = string.IsNullOrWhiteSpace(r.NomeFantasia) ? r.FirstName + " " + r.LastName : r.NomeFantasia,
        //                   RealEstateAgencyHasCNPJ = !string.IsNullOrWhiteSpace(r.Cnpj),
        //                   RealEstateAgencyDocument = string.IsNullOrWhiteSpace(r.Cnpj) ? r.Cpf : r.Cnpj,
        //                   RealEstateId = y.RealEstateId,
        //                   RealEstateName = string.IsNullOrWhiteSpace(_r.NomeFantasia) ? _r.FirstName + " " + _r.LastName : _r.NomeFantasia,
        //                   RealEstateHasCNPJ = !string.IsNullOrWhiteSpace(_r.Cnpj),
        //                   RealEstateDocument = string.IsNullOrWhiteSpace(_r.Cnpj) ? _r.Cpf : _r.Cnpj,
        //                   RenterPhone = y.RenterPhone,
        //                   RenterEmail = y.RenterEmail,
        //                   CreatedDate = y.CreatedDate,
        //                   ApprovedBy = y.ApprovedBy,
        //                   ApprovedDate = y.ApprovedDate,
        //                   TotalPrice = y.PlanPrice + (((float)y.TaxaInquilini) / 12) + (y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Value : 0),
        //                   Taxes = ((float)y.TaxaInquilini) / 12,
        //                   RealEstateReference = y.RealEstateReference,
        //                   DeletedBy = y.DeletedBy,
        //                   DeletedDate = y.DeletedDate,
        //                   NameDeletedBy = y.DeletedBy.HasValue ? user.Any(x => x.Id == y.DeletedBy) ? user.Single(x => x.Id == y.DeletedBy).FirstName + " " + user.Single(x => x.Id == y.DeletedBy).LastName : "" : "",
        //                   CopiedFrom = y.CopiedFrom,
        //                   CopiedBy = y.CopiedBy,
        //                   PlanPrice = y.PlanPrice,
        //                   PlanAssistancePrice = y.PlanPrice + (y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Value : 0),
        //                   PaymentTimes = y.PaymentTimes,
        //                   AdherenceDate = y.AdherenceDate,
        //                   AdherenceBy = y.AdherenceBy,
        //                   NameAdherenceBy = y.AdherenceBy.HasValue ? user.Any(x => x.Id == y.AdherenceBy) ? user.Single(x => x.Id == y.AdherenceBy).FirstName + " " + user.Single(x => x.Id == y.AdherenceBy).LastName : "" : "",
        //                   CreatedBy = y.CreatedBy,
        //                   NameCreatedBy = y.CreatedBy.HasValue ? user.Any(x => x.Id == y.CreatedBy) ? user.Single(x => x.Id == y.CreatedBy).FirstName + " " + user.Single(x => x.Id == y.CreatedBy).LastName : "" : "",
        //                   RenewBy = y.RenewBy,
        //                   NameRenewBy = y.RenewBy.HasValue ? user.Any(x => x.Id == y.RenewBy) ? user.Single(x => x.Id == y.RenewBy).FirstName + " " + user.Single(x => x.Id == y.RenewBy).LastName : "" : "",
        //                   AssistanceName = y.AssistanceId.HasValue ? assistance.Single(x => x.AssistanceId == y.AssistanceId).Name : "",
        //                   ConstructionTypeName = y.ConstructionTypeId.HasValue ? constructionType.Single(x => x.ConstructionTypeId == y.ConstructionTypeId).Name : "",
        //                   HabitationTypeName = y.HabitationTypeId.HasValue ? habitationType.Single(x => x.HabitationTypeId == y.HabitationTypeId).Name : "",
        //                   PlanName = plan.Single(x => x.PlanId == y.PlanId).Name,
        //                   PlanId = y.PlanId
        //               }).ToList();

        //    productCoverageFunctions.GetProductPlanCoverageInfoForExport(ref res);

        //    return res;
        //}

        public List<CertificateExportViewModel> GetCertificateExport(int? realEstateAgencyId, int? realEstateId, int? insurancePolicyId, DateTime refMonth)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCertificateExport]";

            var _realEstateAgencyId = command.CreateParameter();
            _realEstateAgencyId.ParameterName = "@RealEstateAgencyId";
            _realEstateAgencyId.Value = (object)realEstateAgencyId ?? DBNull.Value;
            command.Parameters.Add(_realEstateAgencyId);

            var _realEstateId = command.CreateParameter();
            _realEstateId.ParameterName = "@RealEstateId";
            _realEstateId.Value = (object)realEstateId ?? DBNull.Value;
            command.Parameters.Add(_realEstateId);

            var _insurancePolicyId = command.CreateParameter();
            _insurancePolicyId.ParameterName = "@InsurancePolicyId";
            _insurancePolicyId.Value = (object)insurancePolicyId ?? DBNull.Value;
            command.Parameters.Add(_insurancePolicyId);

            var _refMonth = command.CreateParameter();
            _refMonth.ParameterName = "@RefMonth";
            _refMonth.Value = refMonth;
            command.Parameters.Add(_refMonth);

            var reader = command.ExecuteReader();
            var certificates = new List<CertificateExportViewModel>();
            while (reader.Read())
            {
                var certificate = new CertificateExportViewModel
                {
                    Apolice = reader["Apolice"].GetString(),
                    ValorAssistencia = reader["ValorAssistencia"].GetDouble(),
                    Bairro = reader["Bairro"].GetString(),
                    CEP = reader["CEP"].GetString(),
                    Cidade = reader["Cidade"].GetString(),
                    Coberturas = reader["Coberturas"].GetString(),
                    Complemento = reader["Complemento"].GetString(),
                    Corretora = reader["Corretora"].GetString(),
                    CPFInquilino = reader["CPFInquilino"].GetString(),
                    CPFProprietario = reader["CPFProprietario"].GetString(),
                    DataDeInclusao = reader["DataDeInclusao"].GetString(),
                    Imobiliaria = reader["Imobiliaria"].GetString(),
                    LocalDeRisco = reader["LocalDeRisco"].GetString(),
                    NomeInquilino = reader["NomeInquilino"].GetString(),
                    NomeProprietario = reader["NomeProprietario"].GetString(),
                    NovoOuRenovado = reader["NovoOuRenovado"].GetString(),
                    Numero = reader["Numero"].GetString(),
                    Plano = reader["Plano"].GetString(),
                    PrecoPlano = reader["PrecoPlano"].GetDouble(),
                    Produto = reader["Produto"].GetString(),
                    Referencia = reader["Referencia"].GetString(),
                    TaxaInquilino = reader["TaxaInquilino"].GetInt(),
                    TipoDeImovel = reader["TipoDeImovel"].GetString(),
                    UF = reader["UF"].GetString(),
                    CoberturaBasica = reader["CoberturaBasica"].GetString()
                };
                certificates.Add(certificate);
            }
            connection.Close();

            return certificates;
        }
        
        public CertificatePrintViewModel GetCertificatePrintViewModel(int id)
        {
            var certificate = _GetDataViewModel(GetDataByID(id));
            var plan = this.context.Plan.Single(x => x.PlanId == certificate.PlanId);
            var productPlanCoverages = productCoverageFunctions.GetProductPlanCoverageViewModel(certificate.PlanId);
            Assistance planAssistance = null;
            AssistanceViewModel assistance = new AssistanceViewModel();
            if (plan.AssistanceId.HasValue)
                planAssistance = assistanceFunctions.GetDataByID(plan.AssistanceId);

            if (certificate.AssistanceId.HasValue)
                assistance = assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(certificate.AssistanceId));

            var _plan = new CertificatePlanViewModel
            {
                Description = plan.Description,
                IsDeleted = plan.IsDeleted,
                PlanId = plan.PlanId,
                ProductId = plan.ProductId,
                Name = plan.Name,
                AssistanceId = planAssistance != null ? (int?)planAssistance.AssistanceId : null,
                MonthlyPrice = productPlanCoverages.Sum(x => (!x.IsOptional || x.Used) && x.Garantia.HasValue ? (double)(x.Taxes / 100 * x.Garantia.Value) : 0),
                AnnualPrice = productPlanCoverages.Sum(x => (!x.IsOptional || x.Used) && x.Garantia.HasValue ? (double)(x.Taxes / 100 * x.Garantia.Value) : 0) * 12
            };

            return new CertificatePrintViewModel
            {
                Certificate = certificate,
                Plan = _plan,
                Coverages = productPlanCoverages,
                InsurancePolicy = insurancePolicyFunctions._GetDataViewModel(insurancePolicyFunctions.GetDataByID(certificate.InsurancePolicyId)),
                RealEstate = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(certificate.RealEstateId)),
                RealEstateAgency = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(certificate.RealEstateAgencyId)),
                Assistance = assistance
            };
        }

        public bool Approve(int id, int userId)
        {
            try
            {
                var certificate = GetDataByID(id);
                certificate.IsApproved = true;
                certificate.ApprovedBy = userId;
                certificate.ApprovedDate = DateTime.Now;
                certificate.VigencyDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                this.dbSet.Update(certificate);
                this.context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public int? Renew(int id, int userId, double planPrice)
        {
            try
            {
                var certificate = GetDataByID(id);

                var newCert = new Certificate
                {
                    ApprovedBy = userId,
                    ApprovedDate = DateTime.Now,
                    AssistanceId = certificate.AssistanceId,
                    Bairro = certificate.Bairro,
                    Cep = certificate.Cep,
                    Cidade = certificate.Cidade,
                    Complemento = certificate.Complemento,
                    ConstructionTypeId = certificate.ConstructionTypeId,
                    Endereco = certificate.Endereco,
                    HabitationTypeId = certificate.HabitationTypeId,
                    InsurancePolicyId = certificate.InsurancePolicyId,
                    IsApproved = certificate.IsApproved,
                    IsDeleted = certificate.IsDeleted,
                    LocatorCpf = certificate.LocatorCpf,
                    LocatorEmail = certificate.LocatorEmail,
                    LocatorName = certificate.LocatorName,
                    LocatorPhone = certificate.LocatorPhone,
                    Numero = certificate.Numero,
                    PaymentTimes = certificate.PaymentTimes,
                    PlanId = certificate.PlanId,
                    ProductId = certificate.ProductId,
                    PropertyTypeDescription = certificate.PropertyTypeDescription,
                    PropertyTypeId = certificate.PropertyTypeId,
                    RealEstateAgencyId = certificate.RealEstateAgencyId,
                    RealEstateId = certificate.RealEstateId,
                    RealEstateReference = certificate.RealEstateReference,
                    RenterCpf = certificate.RenterCpf,
                    RenterEmail = certificate.RenterEmail,
                    RenterName = certificate.RenterName,
                    RenterPhone = certificate.RenterPhone,
                    TaxaInquilini = certificate.TaxaInquilini,
                    Uf = certificate.Uf,
                    CopiedFrom = certificate.CertificateId,
                    PlanPrice = planPrice,
                    IsSimulation = false,
                    AdherenceDate = DateTime.Now,
                    RenewBy = userId,
                    AdherenceBy = userId,
                    VigencyDate = DateTime.Now
                };

                int maxTries = 10;
                for (int i = 0; i <= maxTries; i++)
                {
                    if (i == maxTries) throw new Exception("Reference max tries reached.");
                    var reference = Utils.ReferenceUtils.GetReference();
                    if (!ReferenceExiste(reference))
                    {
                        newCert.Reference = reference;
                        break;
                    }
                }

                this.dbSet.Add(newCert);
                this.context.SaveChanges();

                certificate.IsDeleted = true;
                certificate.DeletedDate = DateTime.Now;
                certificate.DeletedBy = userId;
                certificate.CopiedBy = newCert.CertificateId;

                this.dbSet.Update(certificate);

                this.context.SaveChanges();

                return newCert.CertificateId;
            }
            catch
            {
                return null;
            }
        }

        public bool ReferenceExiste(string reference)
        {
            return this.dbSet.Any(x => x.Reference == reference);
        }

        public Certificate GetDataByReference(string reference)
        {
            return this.dbSet.SingleOrDefault(x => x.Reference == reference);
        }

        public int CountAdherencesInMonth(DateTime monthRef)
        {
            return this.dbSet.Count(x => x.AdherenceDate.HasValue && x.AdherenceDate.Value.Year <= monthRef.Year && x.AdherenceDate.Value.Month <= monthRef.Month && 
            (!x.DeletedDate.HasValue || (x.DeletedDate.HasValue && DateTime.Compare(x.DeletedDate.Value, monthRef) > 0)) &&
            x.AdherenceDate.IsActive(monthRef));
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Certificate;
        }
    }
}
