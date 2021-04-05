using BLL.Utils;
using DAL;
using DTO.CompanyQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.CompanyQuestion
{
    public class CompanyQuestionAnswerFunctions : BLLBasicFunctions<DAL.CompanyQuestionAnswer, CompanyQuestionAnswerViewModel>
    {
        public CompanyQuestionAnswerFunctions(GLAS2Context context) : base(context, "CompanyQuestionId")
        {
        }

        public override int Create(CompanyQuestionAnswerViewModel model)
        {
            var entity = model.CopyToEntity<DAL.CompanyQuestionAnswer>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CompanyQuestionAnswerId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyQuestionAnswerViewModel> GetDataViewModel(IQueryable<DAL.CompanyQuestionAnswer> data) => data.Select(x => x.CopyToEntity<CompanyQuestionAnswerViewModel>()).ToList();

        public override CompanyQuestionAnswerViewModel GetDataViewModel(DAL.CompanyQuestionAnswer data) => data.CopyToEntity<CompanyQuestionAnswerViewModel>();

        public override void Update(CompanyQuestionAnswerViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet() => this.dbSet = context.CompanyQuestionAnswer;
    }
}
