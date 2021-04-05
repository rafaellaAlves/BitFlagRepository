using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Client
{
    public class ClientTypeFunctions : BasicFunctions<DB.ClientType, DB.ClientType>
    {
        public ClientTypeFunctions(TerraNostraContext context) 
            : base(context, "ClientTypeId")
        {
        }

        public override int Create(ClientType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<ClientType> GetDataViewModel(IEnumerable<ClientType> data)
        {
            return data.ToList();
        }

        public override ClientType GetDataViewModel(ClientType data)
        {
            return data;
        }

        public ClientType GetDataByExternalCode(string ec)
        {
            return this.dbSet.Single(x => x.ExternalCode == ec);
        }

        public override void Update(ClientType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientType;
        }
    }
}
