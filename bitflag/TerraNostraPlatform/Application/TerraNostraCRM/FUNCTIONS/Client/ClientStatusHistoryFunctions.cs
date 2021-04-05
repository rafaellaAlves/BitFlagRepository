using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Client
{
    public class ClientStatusHistoryFunctions : BasicFunctions<ClientStatusHistory, ClientStatusHistory>
    {
        public ClientStatusHistoryFunctions(TerraNostraContext context) 
            : base(context, "ClientStatusHistoryId") { }

        public override int Create(ClientStatusHistory model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.ClientStatusHistoryId;
        }

        public int Create(int statusId, int clientId)
        {
            var clientStatusHistory = new ClientStatusHistory
            {
                ClientId = clientId,
                ClientStatusId = statusId
            };

            this.dbSet.Add(clientStatusHistory);
            this.context.SaveChanges();

            return clientStatusHistory.ClientStatusHistoryId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<ClientStatusHistory> GetDataViewModel(IEnumerable<ClientStatusHistory> data)
        {
            return data.ToList();
        }

        public override ClientStatusHistory GetDataViewModel(ClientStatusHistory data)
        {
            return data;
        }

        public override void Update(ClientStatusHistory model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientStatusHistory;
        }
    }
}
