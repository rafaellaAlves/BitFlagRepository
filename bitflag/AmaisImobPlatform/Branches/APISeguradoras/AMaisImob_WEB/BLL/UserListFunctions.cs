using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class UserListFunctions : BLL.Shared.BLLBasicListFunctions<UserList, UserListViewModel>
    {
        public UserListFunctions(AMaisImob_HomologContext context) : base(context, "UserId")
        {
        }

        public override List<UserListViewModel> GetDataViewModel(IEnumerable<UserList> data) => data.Select(x => x.CopyToEntity<UserListViewModel>()).ToList();

        public override UserListViewModel GetDataViewModel(UserList data) => data.CopyToEntity<UserListViewModel>();

        protected override void SetDbSet() => this.dbSet = context.UserList;
    }
}
