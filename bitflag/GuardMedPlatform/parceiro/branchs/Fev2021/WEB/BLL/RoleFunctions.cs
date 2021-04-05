using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
using Microsoft.AspNetCore.Identity;

namespace WEB.BLL
{
    public class RoleFunctions : BLLBasicFunctions<DB.Models.Role, DB.Models.Role>
    {
        
        public RoleFunctions(DB.Models.Insurance_HomologContext context)
            : base(context, "Id")
        {
           
        }

        public override int Create(DB.Models.Role model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<DB.Models.Role> GetDataViewModel(IEnumerable<DB.Models.Role> data)
        {
            return data.ToList();
        }

        public override DB.Models.Role GetDataViewModel(DB.Models.Role data)
        {
            return data;
        }

        public override void Update(DB.Models.Role model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Role;
        }

        public IQueryable<DB.Models.Role> GetRoleByLevel(int userId)
        {
            var roleId = this.context.AspNetUserRoles.FirstOrDefault(x => x.UserId == userId);
            var userRole = this.context.Role.FirstOrDefault(x => x.Id == roleId.RoleId);
            return this.dbSet.Where(x => x.Nivel > userRole.Nivel);
        }

      
    }
}
