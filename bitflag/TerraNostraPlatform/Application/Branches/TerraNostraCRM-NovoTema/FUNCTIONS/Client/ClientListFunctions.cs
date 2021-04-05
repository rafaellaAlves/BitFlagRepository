using DB;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;
using System.Linq;

namespace FUNCTIONS.Client
{
    public class ClientListFunctions : BasicListFunctions<ClientList, ClientListViewModel>
    {
        public ClientListFunctions(TerraNostraContext context) 
            : base(context, "ClientId")
        {
        }

        public override List<ClientListViewModel> GetDataViewModel(IEnumerable<ClientList> data)
        {
            return data.Select(x => x.CopyToEntity<ClientListViewModel>()).ToList();
        }

        public override ClientListViewModel GetDataViewModel(ClientList data)
        {
            return data.CopyToEntity<ClientListViewModel>();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientList;
        }
    }
}
