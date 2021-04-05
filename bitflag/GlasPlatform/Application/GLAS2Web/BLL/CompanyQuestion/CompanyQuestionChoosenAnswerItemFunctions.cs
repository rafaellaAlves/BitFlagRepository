using BLL.Utils;
using DAL;
using DTO.CompanyQuestion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CompanyQuestion
{
    public class CompanyQuestionChoosenAnswerItemFunctions : BLLBasicFunctions<CompanyQuestionChoosenAnswerItem, CompanyQuestionChoosenAnswerItemViewModel>
    {
        public CompanyQuestionChoosenAnswerItemFunctions(GLAS2Context context) : base(context, "CompanyQuestionChoosenAnswerItemId")
        {
        }

        public override int Create(CompanyQuestionChoosenAnswerItemViewModel model)
        {
            var entity = model.CopyToEntity<CompanyQuestionChoosenAnswerItem>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CompanyQuestionChoosenAnswerItemId;
        }

        public void CreateRange(IEnumerable<CompanyQuestionChoosenAnswerItemViewModel> models)
        {
            var entities = models.Select(x => x.CopyToEntity<CompanyQuestionChoosenAnswerItem>());

            this.dbSet.AddRange(entities);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            this.dbSet.Remove(this.GetDataByID(id));
            this.context.SaveChanges();
        }


        public void DeleteByCompanyQuestionChoosenAnswer(int companyQuestionChoosenAnswerId)
        {
            this.dbSet.RemoveRange(this.dbSet.Where(x => x.CompanyQuestionChoosenAnswerId == companyQuestionChoosenAnswerId));
            this.context.SaveChanges();
        }

        public override List<CompanyQuestionChoosenAnswerItemViewModel> GetDataViewModel(IQueryable<CompanyQuestionChoosenAnswerItem> data) => data.Select(x => x.CopyToEntity<CompanyQuestionChoosenAnswerItemViewModel>()).ToList();

        public override CompanyQuestionChoosenAnswerItemViewModel GetDataViewModel(CompanyQuestionChoosenAnswerItem data) => data.CopyToEntity<CompanyQuestionChoosenAnswerItemViewModel>();

        public override void Update(CompanyQuestionChoosenAnswerItemViewModel model) => throw new NotImplementedException();

        protected override void SetDbSet() => this.dbSet = context.CompanyQuestionChoosenAnswerItem;

        public async Task<List<int>> GetQuestionAnswersByCompanyId(int companyId) => await (from cqca in context.CompanyQuestionChoosenAnswer
                                                                                            join cqcai in dbSet on cqca.CompanyQuestionChoosenAnswerId equals cqcai.CompanyQuestionChoosenAnswerId
                                                                                            where cqca.CompanyId == companyId
                                                                                            select cqcai.QuestionAnswerId).ToListAsync();
    }
}
