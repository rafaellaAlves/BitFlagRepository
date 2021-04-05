using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using WEB.Models;

namespace WEB.BLL
{
    public class CompanyFunctions : BLLBasicFunctions<Company, CompanyViewModel>
    {
        private readonly CompanyTypeFunctions companyTypeFunctions;
        private readonly UserFunctions userFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;


        public CompanyFunctions(DB.Models.Insurance_HomologContext context)
            : base(context, "CompanyId")
        {
            this.companyTypeFunctions = new CompanyTypeFunctions(context);
            this.userManager = userManager;
            this.userFunctions = new UserFunctions(context, userManager);
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
                NomeBanco = model.NomeBanco,
                AgenciaBanco = model.AgenciaBanco,
                ContaBanco = model.ContaBanco,
                Agenciamento = model.Agenciamento,
                Vitalicio = model.Vitalicio,
                Comissao = model.Comissao,
                Responsavel = model.Responsavel,
                CpfResponsavel = model.CpfResponsavel,
                DateAcceptTerm = model.DateAcceptTerm,
                Ip = model.IP

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

        //public void DeleteRangeAndUserCompany(IEnumerable<int> companyIds)
        //{
        //    var companies = this.GetData(x => companyIds.Contains(x.CompanyId));

        //    foreach (var company in companies)
        //    {
        //        company.IsDeleted = true;
        //        company.IsActive = false;

        //        this.context.Update(company);
        //    }

        //    var userCompanies = this.context.UserCompany.Where(x => companyIds.Contains(x.CompanyId));
        //    foreach (var userCompany in userCompanies)
        //        this.context.UserCompany.Remove(userCompany);

        //    this.context.SaveChanges();
        //}

        public override List<Models.CompanyViewModel> GetDataViewModel(IEnumerable<Company> data)
        {
            var q = (from y in data.ToList()
                     select new Models.CompanyViewModel()
                     {
                         CompanyId = y.CompanyId,
                         Cnpj = y.Cnpj,
                         Ie = y.Ie,
                         RazaoSocial = y.RazaoSocial,
                         NomeFantasia = y.NomeFantasia,
                         Email = y.Email,
                         Telefone = y.Telefone,
                         Cep = y.Cep,
                         Endereco = y.Endereco,
                         Numero = y.Numero,
                         Complemento = y.Complemento,
                         Bairro = y.Bairro,
                         Cidade = y.Cidade,
                         Uf = y.Uf,
                         IsActive = y.IsActive,
                         Observation = y.Observation,
                         Cpf = y.Cpf,
                         FirstName = y.FirstName,
                         LastName = y.LastName,
                         CompanyTypeId = y.CompanyTypeId,
                         CompanyOwnerTypeId = y.CompanyOwnerTypeId,
                         ParentCompanyId = y.ParentCompanyId,
                         NomeBanco = y.NomeBanco,
                         AgenciaBanco = y.AgenciaBanco,
                         ContaBanco = y.ContaBanco,
                         Agenciamento = y.Agenciamento,
                         Vitalicio = y.Vitalicio,
                         Comissao = y.Comissao,
                         Responsavel = y.Responsavel,
                         CpfResponsavel = y.CpfResponsavel,
                         DateAcceptTerm = y.DateAcceptTerm,
                         IP = y.Ip,
                         TermAccepted = y.TermAccepted

                     }).ToList();

            return q;
        }

        public override Models.CompanyViewModel GetDataViewModel(Company data)
        {
            return new Models.CompanyViewModel()
            {
                CompanyId = data.CompanyId,
                Cnpj = data.Cnpj,
                Ie = data.Ie,
                RazaoSocial = data.RazaoSocial,
                NomeFantasia = data.NomeFantasia,
                Email = data.Email,
                Telefone = data.Telefone,
                Cep = data.Cep,
                Endereco = data.Endereco,
                Numero = data.Numero,
                Complemento = data.Complemento,
                Bairro = data.Bairro,
                Uf = data.Uf,
                Cidade = data.Cidade,
                IsActive = data.IsActive,
                Observation = data.Observation,
                Cpf = data.Cpf,
                FirstName = data.FirstName,
                LastName = data.LastName,
                CompanyTypeId = data.CompanyTypeId,
                CompanyOwnerTypeId = data.CompanyOwnerTypeId,
                ParentCompanyId = data.ParentCompanyId,
                NomeBanco = data.NomeBanco,
                AgenciaBanco = data.AgenciaBanco,
                ContaBanco = data.ContaBanco,
                Agenciamento = data.Agenciamento,
                Vitalicio = data.Vitalicio,
                Comissao = data.Comissao,
                Responsavel = data.Responsavel,
                CpfResponsavel = data.CpfResponsavel,
                DateAcceptTerm = data.DateAcceptTerm,
                IP = data.Ip,
                TermAccepted = data.TermAccepted
            };
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
                        TermAccepted = y.TermAccepted

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
            Company.NomeBanco = model.NomeBanco;
            Company.AgenciaBanco = model.AgenciaBanco;
            Company.ContaBanco = model.ContaBanco;
            Company.Agenciamento = model.Agenciamento;
            Company.Vitalicio = model.Vitalicio;
            Company.Comissao = model.Comissao;
            Company.CpfResponsavel = model.CpfResponsavel;
            Company.Responsavel = model.Responsavel;
            Company.Ip = model.IP;
            Company.DateAcceptTerm = model.DateAcceptTerm;

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

        public bool ExistCNPJ(string cnpj, int companyTypeId)
        {
            return dbSet.Any(x => x.Cnpj == cnpj && x.CompanyTypeId == companyTypeId && x.IsDeleted == false);
        }

        public List<Company> GetRealEstatesByRealEstateAgencyId(int id)
        {
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;

            return this.dbSet.Where(x => x.ParentCompanyId == id && x.CompanyTypeId == realEstateId && !x.IsDeleted).ToList();
        }

        public int GetRealEstateAgencyId(int userLoggedId)
        {

            var user = userFunctions.GetPlataformaEscritorioByUserId(userLoggedId);

            return this.dbSet.SingleOrDefault(x => x.CompanyId == user.PlataformaId).CompanyId;

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

        //public Company GetDataByCNPJ(string cnpj)
        //{
        //    return GetData().SingleOrDefault(x => x.Cnpj == cnpj && x.IsDeleted == false);
        //}

        public bool IsInCertificate(int id)
        {
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var company = GetDataByID(id);

            if (company.CompanyTypeId == realEstateAgencyId)
                return this.context.Certificate.Any(x => x.RealEstateAgencyId == id && !x.IsDeleted);
            else
                return this.context.Certificate.Any(x => x.RealEstateId == id && !x.IsDeleted);
        }

        public void Accept(int companyId, string ip)
        {
            var company = GetDataByID(companyId);

            company.TermAccepted = true;
            company.TermAcceptedDate = DateTime.Now;
            company.TermAcceptToken = "";
            company.DateAcceptTerm = DateTime.Now;
            company.Ip = ip;

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

        public void UpdateComissao(Models.CompanyViewModel model)
        {
            var company = this.GetDataByID(model.CompanyId);

            company.Comissao = (model.Agenciamento / 12) + (model.Vitalicio * 11) / 12;

            this.context.SaveChanges();
        }
        //public void UpdateComissaoEscritorio(Models.CompanyViewModel model)
        //{
        //    var company = this.GetDataByID(model.CompanyId);

        //    company.ComissaoEscritorio = (model.AgenciamentoEscritorio / 12) + (model.VitalicioEscritorio * 11) / 12;

        //    this.context.SaveChanges();
        //}
        public DadosPlataforma GetDadosParent(int companyId)
        {
            var company = GetDataByID(companyId);
            if (company == null) return new DadosPlataforma();
            if (!company.ParentCompanyId.HasValue) return new DadosPlataforma();

            var parentCompany = GetDataByID(company.ParentCompanyId);
            if (parentCompany == null) return new DadosPlataforma();

            var dadosPlataforma = new DadosPlataforma();
            dadosPlataforma.Agenciamento = parentCompany.Agenciamento;
            dadosPlataforma.Vitalicio = parentCompany.Vitalicio;
            dadosPlataforma.Comissao = parentCompany.Comissao;


            return dadosPlataforma;
        }

        public void InsertCompanyTerms(DB.Models.CompanyAcceptTerms data)
        {
            this.context.CompanyAcceptTerms.Add(data);
            this.context.SaveChanges();
        }

        public void RemoveAcceptTerm(int companyId)
        {
            var company = GetDataByID(companyId);

            company.TermAccepted = false;
            company.TermAcceptedDate = null;
            company.TermAcceptToken = null;

            this.dbSet.Update(company);
            this.context.SaveChanges();
        }

        public void RemoveAcceptTermFromRealEstate(int realEstateAgencyId)
        {
            var realEstateAgency = GetDataByID(realEstateAgencyId);
            var realEstates = this.dbSet.Where(x => x.ParentCompanyId == realEstateAgencyId && (x.Vitalicio > realEstateAgency.Vitalicio  || x.Agenciamento > realEstateAgency.Agenciamento));

            foreach (var realEstate in realEstates)
            {
                realEstate.TermAccepted = false;
                realEstate.TermAcceptedDate = null;
                realEstate.TermAcceptToken = null;
            }

            this.dbSet.UpdateRange(realEstates);
            this.context.SaveChanges();
        }
    }
}
