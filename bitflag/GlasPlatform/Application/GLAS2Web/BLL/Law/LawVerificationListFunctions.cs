using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using Utils;

namespace BLL.Law
{
    public class LawVerificationListFunctions : BLLBasicFunctions<DAL.LawVerificationList, DTO.Law.LawVerificationListViewModel>
    {
        public LawVerificationListFunctions(DAL.GLAS2Context context)
            : base(context, "LawVerificationListId")
        {
        }

        public override int Create(LawVerificationListViewModel model)
        {
            var lawVerificationList = new DAL.LawVerificationList();

            lawVerificationList.LawId = model.LawId;
            lawVerificationList.Name = model.Name;
            lawVerificationList.Description = model.Description;

            this.dbSet.Add(lawVerificationList);
            this.context.SaveChanges();

            return lawVerificationList.LawVerificationListId;
        }

        public override void Delete(object id)
        {
            var lawVerificationList = this.GetDataByID(id);

            lawVerificationList.IsDeleted = true;
            lawVerificationList.LastHandler = -1;
            lawVerificationList.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<LawVerificationListViewModel> GetDataViewModel(IQueryable<DAL.LawVerificationList> data)
        {
            var r = (from y in data
                     select new DTO.Law.LawVerificationListViewModel()
                     {
                         LawVerificationListId = y.LawVerificationListId,
                         LawId = y.LawId,
                         Name = y.Name,
                         Description = y.Description,
                     }).ToList();

            return r;
        }

        public override LawVerificationListViewModel GetDataViewModel(DAL.LawVerificationList data)
        {
            return new DTO.Law.LawVerificationListViewModel()
            {
                LawVerificationListId = data.LawVerificationListId,
                LawId = data.LawId,
                Name = data.Name,
                Description = data.Description
            };
        }

        public override void Update(LawVerificationListViewModel model)
        {
            var lawVerificationList = this.GetDataByID(model.LawId);

            lawVerificationList.LawId = model.LawId;
            lawVerificationList.Name = model.Name;
            lawVerificationList.Description = model.Description;

            lawVerificationList.LastHandler = -1;
            lawVerificationList.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public DAL.LawVerificationList GetLawVerificationListByLawId(int lawId)
        {
            return this.dbSet.FirstOrDefault(x => x.LawId == lawId);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawVerificationList;
        }
    }
}
