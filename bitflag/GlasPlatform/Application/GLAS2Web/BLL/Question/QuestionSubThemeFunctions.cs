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
    public class QuestionSubThemeFunctions : BLLBasicFunctions<QuestionSubTheme, QuestionSubThemeViewModel>
    {
        public QuestionSubThemeFunctions(GLAS2Context context) : base(context, "QuestionSubThemeId")
        {
        }

        public override int Create(QuestionSubThemeViewModel model)
        {
            var entity = model.CopyToEntity<QuestionSubTheme>();

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

        public override List<QuestionSubThemeViewModel> GetDataViewModel(IQueryable<QuestionSubTheme> data) => data.Select(x => x.CopyToEntity<QuestionSubThemeViewModel>()).ToList();

        public override QuestionSubThemeViewModel GetDataViewModel(QuestionSubTheme data) => data.CopyToEntity<QuestionSubThemeViewModel>();

        public override void Update(QuestionSubThemeViewModel model)
        {
            var entity = GetDataByID(model.QuestionSubThemeId);

            entity.Name = model.Name;
            entity.Cause = model.Cause;
            entity.Effect = model.Effect;
            entity.Control = model.Control;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        protected override void SetDbSet() => this.dbSet = context.QuestionSubTheme;

        public async Task<bool> ValidateUpdate(int questionSubThemeId)
        {
            return await (from cqa in this.context.CompanyQuestionAnswer
                    join qa in this.context.QuestionAnswer on cqa.QuestionAnswerId equals qa.QuestionAnswerId
                    where qa.QuestionSubThemeId == questionSubThemeId
                    select cqa.CompanyQuestionAnswerId).CountAsync() == 0;
        }
    }
}
