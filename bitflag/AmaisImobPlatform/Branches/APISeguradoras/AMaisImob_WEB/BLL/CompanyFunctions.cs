using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace AMaisImob_WEB.BLL
{
    public class CompanyFunctions : BLLBasicFunctions<Company, CompanyViewModel>
    {
        private readonly CompanyTypeFunctions companyTypeFunctions;
        public CompanyFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "CompanyId")
        {
            this.companyTypeFunctions = new CompanyTypeFunctions(context);
        }

        public override int Create(CompanyViewModel model)
        {
            var Company = new Company
            {
                Cnpj = model.Cnpj,
                Ie = model.Ie,
                RazaoSocial = model.RazaoSocial,
                NomeFantasia = model.NomeFantasia,
                Cpf = model.Cpf,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyTypeId = model.CompanyTypeId,
                CompanyOwnerTypeId = model.CompanyOwnerTypeId,
                Email = model.Email,
                Telefone = model.Telefone,
                Cep = model.Cep,
                Endereco = model.Endereco,
                Numero = model.Numero,
                Complemento = model.Complemento,
                Bairro = model.Bairro,
                Uf = model.Uf,
                Cidade = model.Cidade,
                IsActive = true,
                Observation = model.Observation,
                LastHandler = model.LastHandler,
                ParentCompanyId = model.ParentCompanyId,
                CategoryId = model.CategoryId,
                UserPartnerId = model.UserPartnerId,
                ChargeCertificate = model.ChargeCertificate,
                ChargeContractualGuarantee = model.ChargeContractualGuarantee,
                ChargeDocuSign = model.ChargeDocuSign,
                ChargeFinancialProtection = model.ChargeFinancialProtection,
                CompanyReference = Guid.NewGuid().ToString()
            };

            this.dbSet.Add(Company);
            this.context.SaveChanges();

            return Company.CompanyId;
        }

        public override void Delete(object id)
        {
            var company = this.GetDataByID(id);

            company.IsDeleted = true;
            company.IsActive = false;

            this.context.Update(company);
            this.context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<int> ids)
        {
            var companies = this.GetData(x => ids.Contains(x.CompanyId));
            foreach (var company in companies)
            {
                company.IsDeleted = true;
                company.IsActive = false;

                this.context.Update(company);
            }
            this.context.SaveChanges();
        }

        public override List<Models.CompanyViewModel> GetDataViewModel(IEnumerable<Company> data)
        {
            return data.Select(x => x.CopyToEntity<CompanyViewModel>()).ToList();
        }

        public override Models.CompanyViewModel GetDataViewModel(Company data)
        {
            return data.CopyToEntity<CompanyViewModel>();
        }

        public List<Models.CompanyListViewModel> GetDataListViewModel(IEnumerable<Company> data)
        {
            var companies = this.dbSet.ToList();

            return (from y in data
                    join pc in companies on y.ParentCompanyId equals pc.CompanyId into _pc
                    from __pc in _pc.DefaultIfEmpty()
                    select new Models.CompanyListViewModel
                    {
                        CompanyId = y.CompanyId,
                        Bairro = y.Bairro,
                        Cep = y.Cep,
                        Cidade = y.Cidade,
                        Cnpj = y.Cnpj,
                        CompanyOwnerTypeId = y.CompanyOwnerTypeId,
                        CompanyTypeId = y.CompanyTypeId,
                        Complemento = y.Complemento,
                        Cpf = y.Cpf,
                        CreatedDate = y.CreatedDate,
                        Email = y.Email,
                        Endereco = y.Endereco,
                        FirstName = y.FirstName,
                        IsActive = y.IsActive,
                        Ie = y.Ie,
                        IsDeleted = y.IsDeleted,
                        LastHandler = y.LastHandler,
                        LastName = y.LastName,
                        ModifiedDate = y.ModifiedDate,
                        NomeFantasia = y.NomeFantasia,
                        Numero = y.Numero,
                        Observation = y.Observation,
                        RazaoSocial = y.RazaoSocial,
                        Uf = y.Uf,
                        Telefone = y.Telefone,
                        ParentCompanyId = y.ParentCompanyId,
                        ParentFirstName = __pc != null ? __pc.FirstName : "",
                        ParentLastName = __pc != null ? __pc.LastName : "",
                        ParentNomeFantasia = __pc != null ? __pc.NomeFantasia : "",
                        ParentRazaoSocial = __pc != null ? __pc.RazaoSocial : "",
                        TermAccepted = y.TermAccepted,
                        CompanyReference = y.CompanyReference,
                        TermAcceptToken = y.TermAcceptToken
                    }).ToList();
        }

        public override void Update(Models.CompanyViewModel model)
        {
            var Company = this.GetDataByID(model.CompanyId);

            Company.Bairro = model.Bairro;
            Company.Cep = model.Cep;
            Company.Cnpj = model.Cnpj;
            Company.Complemento = model.Complemento;
            Company.Email = model.Email;
            Company.Endereco = model.Endereco;
            Company.Numero = model.Numero;
            Company.RazaoSocial = model.RazaoSocial;
            Company.Telefone = model.Telefone;
            Company.Uf = model.Uf;
            Company.Cidade = model.Cidade;
            Company.Observation = model.Observation;
            Company.IsActive = model.IsActive.Value;
            Company.LastHandler = model.LastHandler;
            Company.Ie = model.Ie;
            Company.NomeFantasia = model.NomeFantasia;
            Company.Cpf = model.Cpf;
            Company.FirstName = model.FirstName;
            Company.LastName = model.LastName;
            Company.CompanyTypeId = model.CompanyTypeId;
            Company.CompanyOwnerTypeId = model.CompanyOwnerTypeId;
            Company.ParentCompanyId = model.ParentCompanyId;
            Company.CategoryId = model.CategoryId;
            Company.UserPartnerId = model.ParentCompanyId;
            Company.ChargeCertificate = model.ChargeCertificate;
            Company.ChargeContractualGuarantee = model.ChargeContractualGuarantee;
            Company.ChargeDocuSign = model.ChargeDocuSign;
            Company.ChargeFinancialProtection = model.ChargeFinancialProtection;

            this.context.Update(Company);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Company;
        }

        public string GetCNPJByCompanyId(int CompanyId)
        {
            var Company = GetDataByID(CompanyId);
            if (Company != null)
                return Company.Cnpj;
            return null;
        }

        public bool ExistCNPJ(string cnpj)
        {
            return dbSet.Any(x => x.Cnpj == cnpj && x.IsDeleted == false);
        }

        public List<Company> GetRealEstatesByRealEstateAgencyId(int id)
        {
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;

            return this.dbSet.Where(x => x.ParentCompanyId == id && x.CompanyTypeId == realEstateId && !x.IsDeleted).ToList();
        }

        public int? GetCategory(int id)
        {
            return GetData().SingleOrDefault(x => x.CompanyId == id).CategoryId;
        }

        public List<Company> GetRealEstate()
        {
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            return this.dbSet.Where(x => x.CompanyTypeId == realEstateId && !x.IsDeleted).ToList();
        }

        public List<Company> GetRealEstateAgency()
        {
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            return this.dbSet.Where(x => x.CompanyTypeId == realEstateAgencyId && !x.IsDeleted).ToList();
        }

        public Company GetDataByCNPJ(string cnpj)
        {
            return GetData().SingleOrDefault(x => x.Cnpj == cnpj && x.IsDeleted == false);
        }

        public bool IsInCertificate(int id)
        {
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var company = GetDataByID(id);

            if(company.CompanyTypeId == realEstateAgencyId)
                return this.context.Certificate.Any(x => x.RealEstateAgencyId == id && !x.IsDeleted);
            else
                return this.context.Certificate.Any(x => x.RealEstateId == id && !x.IsDeleted);
        }

        public void Accept(int companyId, string ipAddress)
        {
            var company = GetDataByID(companyId);

            company.TermAcceptToken = "";
            company.TermAccepted = true;
            company.TermAcceptedDate = DateTime.Now;
            company.TermAcceptedIP = ipAddress;

            this.dbSet.Update(company);
            this.context.SaveChanges();
        }

        public bool ValidateTermAcceptToken(int companyId, string token)
        {
            var company = GetDataByID(companyId);

            return company.TermAcceptToken.ToUpper() == token.ToUpper();
        }

        public string NewTermAcceptToken(int companyId)
        {
            var company = GetDataByID(companyId);
            company.TermAcceptToken = Guid.NewGuid().ToString();

            this.dbSet.Update(company);
            this.context.SaveChanges();

            return company.TermAcceptToken;
        }

        public async Task AddUserPartner(int companyId, int userId)
        {
            var company = await this.dbSet.SingleAsync(x => x.CompanyId == companyId);
            company.UserPartnerId = userId;

            this.dbSet.Update(company);
            await this.context.SaveChangesAsync();
        }

        public async Task TryClearUserPartner(int userId)
        {
            foreach (var company in this.dbSet.Where(x => x.UserPartnerId == userId))
            {
                company.UserPartnerId = null;
                this.dbSet.Update(company);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<Company> GetDataByCompanyReference(string companyReference) => await this.dbSet.SingleAsync(x => x.CompanyReference == companyReference);
        public async Task<string> GetCompanyReference(int companyId) => (await this.dbSet.SingleAsync(x => x.CompanyId == companyId)).CompanyReference;
    }
}
