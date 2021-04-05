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
    public class QuestionThemeFunctions : BLLBasicFunctions<QuestionTheme, QuestionThemeViewModel>
    {
        public QuestionThemeFunctions(GLAS2Context context) : base(context, "QuestionThemeId")
        {
        }

        public override int Create(QuestionThemeViewModel model)
        {
            var entity = model.CopyToEntity<QuestionTheme>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.QuestionThemeId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);
            entity.IsDeleted = true;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public override List<QuestionThemeViewModel> GetDataViewModel(IQueryable<QuestionTheme> data) => data.Select(x => x.CopyToEntity<QuestionThemeViewModel>()).ToList();

        public override QuestionThemeViewModel GetDataViewModel(QuestionTheme data) => data.CopyToEntity<QuestionThemeViewModel>();

        public override void Update(QuestionThemeViewModel model)
        {
            var entity = GetDataByID(model.QuestionThemeId);

            entity.Name = model.Name;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionTheme;

        public async Task<bool> ValidateUpdate(int questionThemeId)
        {
            return await (from cq in this.context.CompanyQuestion
                          join q in this.context.Question on cq.QuestionId equals q.QuestionId
                          where q.QuestionThemeId == questionThemeId
                          select cq.CompanyQuestionId).CountAsync() == 0;
        }
    }
}
