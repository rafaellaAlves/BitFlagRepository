using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.User
{
    public class UserViewFunctions : BLLBasicFunctions<DAL.UserView, DAL.UserView>
    {
        public UserViewFunctions(DAL.GLAS2Context context)
            : base(context, "UserId")
        {
        }

        public override int Create(UserView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<UserView> GetDataViewModel(IQueryable<UserView> data)
        {
            throw new NotImplementedException();
        }

        public override UserView GetDataViewModel(UserView data)
        {
            throw new NotImplementedException();
        }

        public override void Update(UserView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.UserView;
        }
    }
}
