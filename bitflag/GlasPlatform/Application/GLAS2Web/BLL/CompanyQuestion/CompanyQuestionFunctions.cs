using BLL.Utils;
using DAL;
using DTO.CompanyQuestion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CompanyQuestion
{
    public class CompanyQuestionFunctions : BLLBasicFunctions<DAL.CompanyQuestion, CompanyQuestionViewModel>
    {
        public CompanyQuestionFunctions(GLAS2Context context) : base(context, "CompanyQuestionId")
        {
        }

        public override int Create(CompanyQuestionViewModel model)
        {
            var entity = model.CopyToEntity<DAL.CompanyQuestion>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CompanyQuestionId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyQuestionViewModel> GetDataViewModel(IQueryable<DAL.CompanyQuestion> data) => data.Select(x => x.CopyToEntity<CompanyQuestionViewModel>()).ToList();

        public override CompanyQuestionViewModel GetDataViewModel(DAL.CompanyQuestion data) => data.CopyToEntity<CompanyQuestionViewModel>();

        public override void Update(CompanyQuestionViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyQuestionAnswerVisualizationViewModel>> GetCompanyQuestionAnswers(int companyId)
        {

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "pr_GetCompanyQuestionAnswers @CompanyId = @_CompanyId";

                command.Parameters.Add(new SqlParameter("@_CompanyId", companyId));

                await context.Database.OpenConnectionAsync();

                var results = new List<CompanyQuestionAnswerVisualizationViewModel>();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read())
                        results.Add(new CompanyQuestionAnswerVisualizationViewModel
                        {
                            QuestionId = (int)result["QuestionId"],
                            QuestionOrder = (int)result["QuestionOrder"],
                            QuestionText = (string)result["QuestionText"],

                            QuestionAnswerId = (int)result["QuestionAnswerId"],
                            QuestionAnswerText = (string)result["QuestionAnswerText"],
                            QuestionAnswerOrder = (int)result["QuestionAnswerOrder"],

                            QuestionThemeId = (int)result["QuestionThemeId"],
                            QuestionThemeName = (string)result["QuestionThemeName"],

                            QuestionSubThemeId = (int)result["QuestionSubThemeId"],
                            QuestionSubThemeName = (string)result["QuestionSubThemeName"],

                            Selected = (bool)result["Selected"],
                            Observation = result["Observation"] == DBNull.Value ? null : (string)result["Observation"],
                        });
                }

                return results;
            }
        }

        protected override void SetDbSet() => this.dbSet = context.CompanyQuestion;

        public async Task<CompanyQuestionLawDetailViewModel> GetCompanyQuestionLawDetailViewModel(int companyId, List<int> questionAnswerIds)
        {
            var company = await this.context.Company.SingleAsync(x => x.CompanyId == companyId);

            #region [ESFERAS]
            var esferas = await this.context.Esfera.ToListAsync();
            var countryId = (esferas.Single(x => x.ExternalCode == "FEDERAL")).EsferaId;
            var stateId = (esferas.Single(x => x.ExternalCode == "ESTADUAL")).EsferaId;
            var cityId = (esferas.Single(x => x.ExternalCode == "MUNICIPAL")).EsferaId;
            #endregion

            #region [POTENTIALITY]
            var lawPotentialityTypes = await this.context.LawPotentialityType.ToListAsync();
            var oportunityId = lawPotentialityTypes.Single(x => x.ExternalCode == "OPORTUNITY").LawPotentialityTypeId;
            var notApplicableId = lawPotentialityTypes.Single(x => x.ExternalCode == "NOTAPPLICABLE").LawPotentialityTypeId;
            var inspectionId = lawPotentialityTypes.Single(x => x.ExternalCode == "RISCODEFISCALIZACAO").LawPotentialityTypeId;
            var interdictionId = lawPotentialityTypes.Single(x => x.ExternalCode == "RISCODEINTERDICAO").LawPotentialityTypeId;
            var fineId = lawPotentialityTypes.Single(x => x.ExternalCode == "RISCODEMULTA").LawPotentialityTypeId;
            #endregion

            #region [SEGMENT]
            var lawSegments = await this.context.Segmento.ToListAsync();
            var segurancaDoTrabalhoId = lawSegments.Single(x => x.SegmentoId == 1).SegmentoId;
            var meioAmbienteId = lawSegments.Single(x => x.SegmentoId == 2).SegmentoId;
            var assuntosRegulatoriosId = lawSegments.Single(x => x.SegmentoId == 7).SegmentoId;
            #endregion

            var themes = (from qa in this.context.QuestionAnswer
                          join q in this.context.QuestionSubThemeList on qa.QuestionSubThemeId equals q.QuestionSubThemeId
                          where questionAnswerIds.Contains(qa.QuestionAnswerId)
                          select new
                          {
                              ThemeId = q.QuestionThemeId,
                              ThemeName = q.QuestionThemeName,
                              SubThemeId = qa.QuestionSubThemeId,
                              SubThemeName = q.Name,
                              Control = q.Control
                          }).Distinct();

            List<DAL.Law> laws = new List<DAL.Law>();

            foreach (var item in themes)
                laws.AddRange(this.context.Law.Where(x =>
                    x.QuestionThemeId == item.ThemeId && x.QuestionSubThemeId == item.SubThemeId &&
                    (
                        (x.EsferaId == countryId && x.CountryId == company.CountryId) ||
                        (x.EsferaId == stateId && x.StateId == company.StateId) ||
                        (x.EsferaId == cityId && x.CityId == company.CityId)
                    )
                ));

            return new CompanyQuestionLawDetailViewModel
            {
                AmountCountryLaws = laws.Count(x => x.EsferaId == countryId),
                AmountStateLaws = laws.Count(x => x.EsferaId == stateId),
                AmountCityLaws = laws.Count(x => x.EsferaId == cityId),
                AmountPotentialityInspection = laws.Count(x => x.LawPotentialityTypeId == inspectionId),
                AmountPotentialityFine = laws.Count(x => x.LawPotentialityTypeId == fineId),
                AmountPotentialityInterdiction = laws.Count(x => x.LawPotentialityTypeId == interdictionId),
                AmountPotentialityOthers = laws.Count(x => (x.LawPotentialityTypeId == oportunityId) || (x.LawPotentialityTypeId == notApplicableId)),
                AmountSegmentSegurancaDoTrabalho = laws.Count(x => x.SegmentoId == segurancaDoTrabalhoId),
                AmountSegmentMeioAmbiente = laws.Count(x => x.SegmentoId == meioAmbienteId),
                AmountSegmentAssuntosRegulatorios = laws.Count(x => x.SegmentoId == assuntosRegulatoriosId),
                AmountSegmentOthers = laws.Count(x => (x.SegmentoId != assuntosRegulatoriosId && x.SegmentoId != meioAmbienteId && x.SegmentoId != segurancaDoTrabalhoId)),

                Themes = await (from themeId in themes.Select(x => x.ThemeId).Distinct()
                                join x in themes on themeId equals x.ThemeId
                                group x by new { x.ThemeId, x.ThemeName } into _x
                                select new CompanyQuestionLawDetailThemeViewModel { ThemeName = _x.Key.ThemeName, ThemeId = _x.Key.ThemeId, Amount = laws.Count(c => c.QuestionThemeId == _x.Key.ThemeId) }).ToListAsync(),

                Subthemes = await themes.Select(x => new CompanyQuestionLawDetailSubthemeViewModel { ThemeId = x.ThemeId, SubThemeName = x.SubThemeName, SubThemeId = x.SubThemeId, Control = x.Control, Amount = laws.Count(c => c.QuestionSubThemeId == x.SubThemeId) }).ToListAsync()
            };

        }
    }
}
