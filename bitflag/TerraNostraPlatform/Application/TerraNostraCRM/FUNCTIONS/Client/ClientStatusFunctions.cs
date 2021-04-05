using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Client
{
    public class ClientStatusFunctions : BasicFunctions<DB.ClientStatus, DB.ClientStatus>
    {
        public ClientStatusFunctions(TerraNostraContext context) 
            : base(context, "ClientStatusId") { }

        public override int Create(DB.ClientStatus model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<DB.ClientStatus> GetDataViewModel(IEnumerable<DB.ClientStatus> data)
        {
            return data.ToList();
        }

        public override DB.ClientStatus GetDataViewModel(DB.ClientStatus data)
        {
            return data;
        }

        public override void Update(DB.ClientStatus model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientStatus;
        }

        public List<DB.ClientStatus> GetDataByExternalCode(params string[] externalCode)
        {
            return this.dbSet.Where(x => externalCode.Contains(x.ExternalCode)).ToList();
        }
    }
}
