using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Law
{
    public class LawTypeFunctions : BLLBasicFunctions<DAL.LawType, DTO.Law.LawTypeViewModel>
    {

        public LawTypeFunctions(DAL.GLAS2Context context)
            : base(context, "LawTypeId")
        {

        }

        public override int Create(LawTypeViewModel model)
        {
            var lawType = new DAL.LawType();

            lawType.Name = model.Name;
            lawType.Description = model.Description;

            this.dbSet.Add(lawType);
            this.context.SaveChanges();

            return lawType.LawTypeId;
        }

        public override void Delete(object id)
        {
            var law = this.GetDataByID(id);

            law.IsDeleted = true;
            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<LawTypeViewModel> GetDataViewModel(IQueryable<DAL.LawType> data)
        {
            var r = (from y in data
                     select new DTO.Law.LawTypeViewModel()
                     {
                         LawTypeId = y.LawTypeId,
                         Name = y.Name,
                         Description = y.Description
                     }).ToList();

            return r;
        }

        public override LawTypeViewModel GetDataViewModel(DAL.LawType data)
        {
            return new DTO.Law.LawTypeViewModel()
            {
                LawTypeId = data.LawTypeId,
                Name = data.Name,
                Description = data.Description
            };
        }

        public override void Update(LawTypeViewModel model)
        {
            var law = this.GetDataByID(model.LawTypeId);

            law.Name = model.Name;
            law.Description = model.Description;
            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawType;
        }
    }
}
