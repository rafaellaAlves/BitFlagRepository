using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using Utils;

namespace BLL.Law
{
    public class LawVerificationListItemFunctions : BLLBasicFunctions<DAL.LawVerificationListItem, DTO.Law.LawVerificationListItemViewModel>
    {
        public LawVerificationListItemFunctions(DAL.GLAS2Context context)
            : base(context, "LawVerificationListItemId")
        {
        }

        public override int Create(LawVerificationListItemViewModel model)
        {
            var lawVerificationListItem = new DAL.LawVerificationListItem();

            lawVerificationListItem.LawVerificationListId = model.LawVerificationListId;
            lawVerificationListItem.Reference = model.Reference;
            lawVerificationListItem.Description = model.Description;

            this.dbSet.Add(lawVerificationListItem);
            this.context.SaveChanges();

            return lawVerificationListItem.LawVerificationListItemId;
        }

        public override void Delete(object id)
        {
            var lawVerificationListItem = this.GetDataByID(id);

            lawVerificationListItem.IsDeleted = true;
            lawVerificationListItem.LastHandler = -1;
            lawVerificationListItem.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<LawVerificationListItemViewModel> GetDataViewModel(IQueryable<DAL.LawVerificationListItem> data)
        {
            var r = (from y in data
                     select new DTO.Law.LawVerificationListItemViewModel()
                     {
                         LawVerificationListItemId = y.LawVerificationListItemId,
                         LawVerificationListId = y.LawVerificationListId,
                         Reference = y.Reference,
                         Description = y.Description,
                     }).ToList();

            return r;
        }

        public override LawVerificationListItemViewModel GetDataViewModel(DAL.LawVerificationListItem data)
        {
            return new DTO.Law.LawVerificationListItemViewModel()
            {
                LawVerificationListItemId = data.LawVerificationListItemId,
                LawVerificationListId = data.LawVerificationListId,
                Reference = data.Reference,
                Description = data.Description
            };
        }

        public override void Update(LawVerificationListItemViewModel model)
        {
            var lawVerificationListItem = this.GetDataByID(model.LawVerificationListItemId);

            lawVerificationListItem.LawVerificationListId = model.LawVerificationListId;
            lawVerificationListItem.Reference = model.Reference;
            lawVerificationListItem.Description = model.Description;

            lawVerificationListItem.LastHandler = -1;
            lawVerificationListItem.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public IEnumerable<DAL.LawVerificationListItem> ItemsInList(int lawVerificationListId)
        {
            return this.dbSet.Where(x => x.LawVerificationListId == lawVerificationListId);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawVerificationListItem;
        }
    }
}
