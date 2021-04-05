using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Role
{
    public class RoleFunctions : BasicIdentityFunctions<TerraNostraIdentityDbContext.Role, TerraNostraIdentityDbContext.Role>
    {
        public RoleFunctions(TerraNostraIdentityDbContext.ApplicationDbContext context)
            : base(context, "Id")
        {
        }

        public override int Create(TerraNostraIdentityDbContext.Role model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TerraNostraIdentityDbContext.Role> GetDataViewModel(IEnumerable<TerraNostraIdentityDbContext.Role> data)
        {
            return data.ToList();
        }

        public override TerraNostraIdentityDbContext.Role GetDataViewModel(TerraNostraIdentityDbContext.Role data)
        {
            return data;
        }

        public override void Update(TerraNostraIdentityDbContext.Role model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Roles;
        }
    }
}
