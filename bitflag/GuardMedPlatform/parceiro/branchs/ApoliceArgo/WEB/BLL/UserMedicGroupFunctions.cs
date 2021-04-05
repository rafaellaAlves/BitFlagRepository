using BLL;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.BLL
{
    public class UserMedicGroupFunctions : BLLBasicFunctions<DB.Models.UserMedicGroup, DB.Models.UserMedicGroup>
    {
        public UserMedicGroupFunctions(Insurance_HomologContext context) : base(context, "UserMedicGroupId")
        {
        }

        public override int Create(UserMedicGroup model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.UserMedicGroupId;
        }

        public int? TryCreate(UserMedicGroup model)
        {
            if (this.dbSet.Any(x => x.UserId == model.UserId && x.MedicGroupId == model.MedicGroupId))
                return null;

            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.UserMedicGroupId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserId(int userId)
        {
            this.dbSet.RemoveRange(this.dbSet.Where(x => x.UserId == userId));
            this.context.SaveChanges();
        }

        public override List<UserMedicGroup> GetDataViewModel(IEnumerable<UserMedicGroup> data)
        {
            throw new NotImplementedException();
        }

        public override UserMedicGroup GetDataViewModel(UserMedicGroup data)
        {
            throw new NotImplementedException();
        }

        public override void Update(UserMedicGroup model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet() => this.dbSet = context.UserMedicGroup;

        public async Task<int?> GetMedicGroupIdByUserId(int userId) => (await this.dbSet.FirstOrDefaultAsync(x => x.UserId == userId))?.MedicGroupId;
    }
}
