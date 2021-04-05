using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CategoryProductFunctions : BLLBasicFunctions<CategoryProduct, CategoryProductViewModel>
    {
        private readonly GuarantorProductFunctions guarantorProductFunctions;
        private readonly CategoryFunctions categoryFunctions;
        public CategoryProductFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
           : base(context, "Id")
        {
            this.guarantorProductFunctions = new BLL.GuarantorProductFunctions(context);
            this.categoryFunctions = new BLL.CategoryFunctions(context);
        }

        public override int Create(CategoryProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CategoryProductViewModel> GetDataViewModel(IEnumerable<CategoryProduct> data)
        {
            var categories = categoryFunctions.GetData();
            var guarantorProducts = guarantorProductFunctions.GetData();

            var q = (from y in data.ToList()
                     join c in categories on y.CategoryId equals c.CategoryId
                     join g in guarantorProducts on y.GuarantorProductId equals g.GuarantorProductId
                     select new Models.CategoryProductViewModel()
                     {
                       Id = y.Id,
                       CategoryId = y.CategoryId,
                       GuarantorProductId = y.GuarantorProductId,
                       CategoryProductDescription = c.Description,
                       GuarantorProductDescription = g.Description

                     }).ToList();

            return q;
        }

        public override CategoryProductViewModel GetDataViewModel(CategoryProduct data)
        {
            throw new NotImplementedException();
        }

        public override void Update(CategoryProductViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CategoryProduct;
        }
    }
}
