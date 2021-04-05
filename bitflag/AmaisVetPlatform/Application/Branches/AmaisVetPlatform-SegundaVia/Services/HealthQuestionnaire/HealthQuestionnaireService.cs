using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTO.HealthQuestionnaire;

namespace Services.HealthQuestionnaire
{
    public class HealthQuestionnaireService
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;
        public HealthQuestionnaireService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> GetLatestHealthQuestionnaireQuestionCountAsync(int healthQuestionnaireId) => await context.HealthQuestionnaireQuestion.Where(x => x.HealthQuestionnaireId == healthQuestionnaireId && x.IsActive).CountAsync();
        public async Task<HealthQuestionnaireViewModel> GetLatestHealthQuestionnaireAsync(int healthQuestionnaireId)
        {
            var latestHealthQuestionnaire = await context.HealthQuestionnaire.SingleAsync(x => x.HealthQuestionnaireId == healthQuestionnaireId);
            if (latestHealthQuestionnaire == null) throw new Exception("Nenhum questionário de saúde cadastrado.");

            var healthQuestionnaireViewModel = new HealthQuestionnaireViewModel()
            {
                Name = latestHealthQuestionnaire.Name,
                Description = latestHealthQuestionnaire.Description,
                Version = latestHealthQuestionnaire.Version
            };

            var questions = await context.HealthQuestionnaireQuestion.Where(x => x.HealthQuestionnaireId == latestHealthQuestionnaire.HealthQuestionnaireId && x.IsActive).OrderBy(x => x.Order).ToListAsync();
            foreach (var question in questions)
            {
                var healthQuestionnaireQuestionViewModel = new HealthQuestionnaireQuestionViewModel()
                {
                    HealthQuestionnaireQuestionId = question.HealthQuestionnaireQuestionaId,
                    Description = question.Description
                };
                healthQuestionnaireViewModel.Questions.Add(healthQuestionnaireQuestionViewModel);

                var options = await context.HealthQuestionnaireOption.Where(x => x.HealthQuestionnaireQuestionId == question.HealthQuestionnaireQuestionaId && x.IsActive).OrderBy(x => x.Order).ToListAsync();
                foreach (var option in options)
                {
                    var healthQuestionnaireOptionViewModel = new HealthQuestionnaireOptionViewModel()
                    {
                        HealthQuestionnaireOptionId = option.HealthQuestionnaireOptionId,
                        Name = option.Name,
                        Value = option.Value
                    };
                    healthQuestionnaireQuestionViewModel.Options.Add(healthQuestionnaireOptionViewModel);
                }
            }

            return healthQuestionnaireViewModel;
        }
        public async Task<int> GetLastestHealthQuestionnaireIdAysnc()
        {
            return await context.HealthQuestionnaire.OrderByDescending(x => x.Version).Select(x => x.HealthQuestionnaireId).FirstAsync();
        }
    }
}
