using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Company
{
    public class CompanyFunctions : BLLBasicFunctions<DAL.Company, DTO.Company.CompanyViewModel>
    {
        public CompanyFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyId")
        {

        }

        public List<DAL.Identity.User> GetSupervisorsByCompanyIds(List<int> companyIds)
        {
            return (from cl in this.context.CompanyLaw
                    join _companyIds in companyIds on cl.CompanyId equals _companyIds
                    join cla in this.context.CompanyLawAction on cl.CompanyLawId equals cla.CompanyLawId
                    join u in this.context.User on cla.SupervisorId equals u.Id
                    select u).Distinct().ToList();
        }

        public List<DAL.Identity.User> GetResponsiblesByCompanyIds(List<int> companyIds)
        {
            return (from cl in this.context.CompanyLaw
                    join _companyIds in companyIds on cl.CompanyId equals _companyIds
                    join cla in this.context.CompanyLawAction on cl.CompanyLawId equals cla.CompanyLawId
                    join u in this.context.User on cla.ResponsibleId equals u.Id
                    select u).Distinct().ToList();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Company;
        }
        public override List<DTO.Company.CompanyViewModel> GetDataViewModel(IQueryable<DAL.Company> data)
        {
            var r = (from y in data.ToList()
                     join ci in this.context.City on y.CityId equals ci.CityId into _ci
                     from city in _ci.DefaultIfEmpty()
                     join s in this.context.State on y.StateId equals s.StateId into _s
                     from st in _s.DefaultIfEmpty()
                     select new DTO.Company.CompanyViewModel()
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
                         Cidade = city == null ? null : city.Name,
                         CountryId = y.CountryId,
                         StateId = y.StateId,
                         CityId = y.CityId,
                         Uf = st == null ? null : st.ExternalCode,
                         HasLogo = y.HasLogo,
                         IsActive = y.IsActive,
                         IsDeleted = y.IsDeleted,
                         EndedQuestions = y.EndedQuestions,
                         QuestionEmailSendDate = y.QuestionEmailSendDate,
                         QuestionEmailSended = y.QuestionEmailSended,
                         CompanyQuestionToken = y.CompanyQuestionToken

                     }).ToList();

            return r;
        }

        public List<DTO.Company.CopyCompanyLawCompanyViewModel> GetCopyCompanyLawViewModel(IQueryable<DAL.Company> data)
        {
            return (from y in data.ToList()
                    select new DTO.Company.CopyCompanyLawCompanyViewModel()
                    {
                        CompanyId = y.CompanyId,
                        NomeFantasia = y.NomeFantasia,
                    }).ToList();
        }

        public override DTO.Company.CompanyViewModel GetDataViewModel(DAL.Company data)
        {
            var r = new DTO.Company.CompanyViewModel()
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
                Cidade = data.CityId == null ? null : this.context.City.Where(c => c.CityId == data.CityId).First().Name,
                CountryId = data.CountryId,
                StateId = data.StateId,
                CityId = data.CityId,
                Uf = data.StateId == null ? null : this.context.State.Where(c => c.StateId == data.StateId).First().ExternalCode,
                HasLogo = data.HasLogo,
                IsActive = data.IsActive,
                EndedQuestions = data.EndedQuestions,
                QuestionEmailSendDate = data.QuestionEmailSendDate,
                QuestionEmailSended = data.QuestionEmailSended,
                CompanyQuestionToken =  data.CompanyQuestionToken
            };
            return r;
        }
        public override int Create(DTO.Company.CompanyViewModel companyModel)
        {
            var company = new DAL.Company
            {
                Cnpj = companyModel.Cnpj,
                Ie = companyModel.Ie,
                RazaoSocial = companyModel.RazaoSocial,
                NomeFantasia = companyModel.NomeFantasia,
                Email = companyModel.Email,
                Telefone = companyModel.Telefone,
                Cep = companyModel.Cep,
                Endereco = companyModel.Endereco,
                Numero = companyModel.Numero,
                Complemento = companyModel.Complemento,
                Bairro = companyModel.Bairro,
                //Cidade = companyModel.Cidade,
                CountryId = companyModel.CountryId,
                StateId = companyModel.StateId,
                CityId = companyModel.CityId,
                Uf = companyModel.Uf,
                HasLogo = companyModel.HasLogo,
                IsActive = companyModel.IsActive
            };

            this.dbSet.Add(company);
            this.context.SaveChanges();

            return company.CompanyId;
        }
        public override void Update(DTO.Company.CompanyViewModel companyModel)
        {
            var company = this.GetDataByID(companyModel.CompanyId);

            company.Cnpj = companyModel.Cnpj;
            company.Ie = companyModel.Ie;
            company.RazaoSocial = companyModel.RazaoSocial;
            company.NomeFantasia = companyModel.NomeFantasia;
            company.Email = companyModel.Email;
            company.Telefone = companyModel.Telefone;
            company.Cep = companyModel.Cep;
            company.Endereco = companyModel.Endereco;
            company.Numero = companyModel.Numero;
            company.Complemento = companyModel.Complemento;
            company.Bairro = companyModel.Bairro;
            //company.Cidade = companyModel.Cidade;
            company.CountryId = companyModel.CountryId;
            company.StateId = companyModel.StateId;
            company.CityId = companyModel.CityId;
            company.Uf = companyModel.Uf;
            company.HasLogo = companyModel.HasLogo;
            company.IsActive = companyModel.IsActive;
            company.LastHandler = -1;
            company.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }
        public override void Delete(object id)
        {
            var company = this.GetDataByID(id);

            company.IsDeleted = true;
            company.LastHandler = -1;
            company.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public async Task CreateCompanyQuestion(int companyId)
        {
            this.context.CompanyQuestion.RemoveRange(this.context.CompanyQuestion.Where(x => x.CompanyId == companyId));
            this.context.CompanyQuestionAnswer.RemoveRange(this.context.CompanyQuestionAnswer.Where(x => x.CompanyId == companyId));
            await this.context.SaveChangesAsync();//remove os itens já criados

            var questionIds = await this.context.Question.AsNoTracking().Where(x => !x.IsDeleted).Select(x => x.QuestionId).ToListAsync();

            var questionAnswers = context.QuestionAnswer.AsNoTracking().Where(x => !x.IsDeleted && questionIds.Contains(x.QuestionId));

            questionIds = await questionAnswers.Select(x => x.QuestionId).Distinct().ToListAsync(); //Coloca os questionIds das respostas, pq caso alguma pergunta não tenha resposta ela não será inserida;

            await this.context.CompanyQuestion.AddRangeAsync(questionIds.Select(x => new DAL.CompanyQuestion
            {
                CompanyId = companyId,
                QuestionId = x
            }));

            await this.context.CompanyQuestionAnswer.AddRangeAsync(questionAnswers.Select(x => new DAL.CompanyQuestionAnswer
            {
                CompanyId = companyId,
                QuestionAnswerId = x.QuestionAnswerId
            }));

            await this.context.SaveChangesAsync();
        }

        public async Task SetCompanyQuestionToken(int companyId)
        {
            var entity = GetDataByID(companyId);

            entity.CompanyQuestionToken = Guid.NewGuid();

            this.dbSet.Update(entity);

            await this.context.SaveChangesAsync();
        }
        public async Task<bool> ValidateCompanyQuestionToken(int companyId, string companyQuestionToken) => await this.dbSet.AnyAsync(x => x.CompanyQuestionToken == new Guid(companyQuestionToken) && x.CompanyId == companyId);


        public async Task UpdateSendedQuestionEmail(int companyId)
        {
            var entity = GetDataByID(companyId);

            entity.QuestionEmailSended = true;
            entity.QuestionEmailSendDate = DateTime.Now;

            this.dbSet.Update(entity);

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEndedQuestion(int companyId)
        {
            var entity = GetDataByID(companyId);

            entity.EndedQuestions = true;

            this.dbSet.Update(entity);

            await this.context.SaveChangesAsync();
        }
    }
}
