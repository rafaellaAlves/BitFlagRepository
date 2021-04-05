using BLL.Utils;
using DAL;
using DTO.CompanyQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CompanyQuestion
{
    public class CompanyQuestionChoosenAnswerFunctions : BLLBasicFunctions<DAL.CompanyQuestionChoosenAnswer, CompanyQuestionChoosenAnswerViewModel>
    {
        public CompanyQuestionChoosenAnswerFunctions(GLAS2Context context) : base(context, "CompanyQuestionChoosenAnswerId")
        {
        }

        public override int Create(CompanyQuestionChoosenAnswerViewModel model)
        {
            var entity = model.CopyToEntity<DAL.CompanyQuestionChoosenAnswer>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CompanyQuestionChoosenAnswerId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByCompany(int companyId)
        {
            foreach (var item in this.dbSet.Where(x => x.CompanyId == companyId))
            {
                this.context.CompanyQuestionChoosenAnswerItem.RemoveRange(this.context.CompanyQuestionChoosenAnswerItem.Where(x => x.CompanyQuestionChoosenAnswerId == item.CompanyQuestionChoosenAnswerId));

                this.dbSet.Remove(item);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(IEnumerable<CompanyQuestionChoosenAnswerViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<CompanyQuestionChoosenAnswer>()));
            await this.context.SaveChangesAsync();
        }

        public override List<CompanyQuestionChoosenAnswerViewModel> GetDataViewModel(IQueryable<DAL.CompanyQuestionChoosenAnswer> data) => data.Select(x => x.CopyToEntity<CompanyQuestionChoosenAnswerViewModel>()).ToList();

        public override CompanyQuestionChoosenAnswerViewModel GetDataViewModel(DAL.CompanyQuestionChoosenAnswer data) => data.CopyToEntity<CompanyQuestionChoosenAnswerViewModel>();

        public override void Update(CompanyQuestionChoosenAnswerViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet() => this.dbSet = context.CompanyQuestionChoosenAnswer;
    }
}
