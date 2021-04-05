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
    public class QuestionFunctions : BLLBasicFunctions<DAL.Question, QuestionViewModel>
    {
        public QuestionFunctions(GLAS2Context context) : base(context, "QuestionId")
        {
        }

        public override int Create(QuestionViewModel model)
        {
            model.Order = this.dbSet.Where(x => !x.IsDeleted).Count() == 0 ? 1 : this.dbSet.Where(x => !x.IsDeleted).Max(x => x.Order) + 1;

            var entity = model.CopyToEntity<DAL.Question>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.QuestionId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);
            entity.IsDeleted = true;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public override List<QuestionViewModel> GetDataViewModel(IQueryable<DAL.Question> data) => data.Select(x => x.CopyToEntity<QuestionViewModel>()).ToList();

        public override QuestionViewModel GetDataViewModel(DAL.Question data) => data.CopyToEntity<QuestionViewModel>();

        public override void Update(QuestionViewModel model)
        {
            var entity = GetDataByID(model.QuestionId);

            entity.QuestionThemeId = model.QuestionThemeId.Value;
            entity.QuestionText = model.QuestionText;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public void UpdateOrder(List<QuestionViewModel> models)
        {
            foreach (var model in models)
            {
                var entity = GetDataByID(model.QuestionId);

                entity.Order = model.Order;
                this.dbSet.Update(entity);
            }

            this.context.SaveChanges();
        }

        protected override void SetDbSet() => this.dbSet = context.Question;


        public async Task<bool> ValidateUpdate(int questionId) => !await this.context.CompanyQuestion.AnyAsync(x => x.QuestionId == questionId);
    }
}
