using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CategoryFunctions : BLLBasicFunctions<Category, Category>
    {

        public CategoryFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "CategoryId")
        {
           
        }

        public override int Create(Category model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<Category> GetDataViewModel(IEnumerable<Category> data)
        {
            return data.ToList();
        }

        public override Category GetDataViewModel(Category data)
        {
            return data;
        }

        public override void Update(Category model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Category;
        }
    }
}
