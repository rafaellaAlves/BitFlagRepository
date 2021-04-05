using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Client
{
    public class ClientDependentTypeFunctions : BasicListFunctions<ClientDependentType, ClientDependentType>
    {
        public ClientDependentTypeFunctions(TerraNostraContext context) 
            : base(context, "ClientDependentTypeId")
        {
        }

        public override List<ClientDependentType> GetDataViewModel(IEnumerable<ClientDependentType> data)
        {
            return data.ToList();
        }

        public override ClientDependentType GetDataViewModel(ClientDependentType data)
        {
            return data;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientDependentType;
        }
    }
}
