using BLL.Utils;
using DAL;
using DTO.Question;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Question
{
    public class QuestionAnswerFunctions : BLLBasicFunctions<QuestionAnswer, QuestionAnswerViewModel>
    {
        public QuestionAnswerFunctions(GLAS2Context context) : base(context, "QuestionAnswerId")
        {
        }

        public override int Create(QuestionAnswerViewModel model)
        {
            model.Order = this.dbSet.Where(x => x.QuestionId == model.QuestionId && !x.IsDeleted).Count() == 0? 1 : this.dbSet.Where(x => x.QuestionId == model.QuestionId && !x.IsDeleted).Max(x => x.Order) + 1;

            var entity = model.CopyToEntity<QuestionAnswer>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.QuestionAnswerId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);
            entity.IsDeleted = true;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public override List<QuestionAnswerViewModel> GetDataViewModel(IQueryable<QuestionAnswer> data) => data.Select(x => x.CopyToEntity<QuestionAnswerViewModel>()).ToList();

        public override QuestionAnswerViewModel GetDataViewModel(QuestionAnswer data) => data.CopyToEntity<QuestionAnswerViewModel>();

        public override void Update(QuestionAnswerViewModel model)
        {
            var entity = GetDataByID(model.QuestionAnswerId);

            entity.Answer = model.Answer;
            entity.QuestionSubThemeId = model.QuestionSubThemeId.Value;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public void UpdateOrder(List<QuestionAnswerViewModel> models)
        {
            foreach (var model in models)
            {
                var entity = GetDataByID(model.QuestionAnswerId);

                entity.Order = model.Order;
                this.dbSet.Update(entity);
            }

            this.context.SaveChanges();
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionAnswer;


        public async Task<bool> ValidateUpdate(int questionAnswerId) => !await this.context.CompanyQuestionAnswer.AnyAsync(x => x.QuestionAnswerId == questionAnswerId);
    }
}
