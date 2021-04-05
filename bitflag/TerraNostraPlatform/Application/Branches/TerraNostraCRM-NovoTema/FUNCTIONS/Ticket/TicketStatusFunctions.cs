using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Ticket
{
    public class TicketStatusFunctions : BasicFunctions<DB.TicketStatus, DB.TicketStatus>
    {
        public TicketStatusFunctions(TerraNostraContext context) 
            : base(context, "TicketStatusId")
        {
        }

        public override int Create(TicketStatus model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TicketStatus> GetDataViewModel(IEnumerable<TicketStatus> data)
        {
            return data.ToList();
        }

        public override TicketStatus GetDataViewModel(TicketStatus data)
        {
            return data;
        }

        public TicketStatus GetDataByExternalCode(string ec)
        {
            return this.dbSet.SingleOrDefault(x => x.ExternalCode == ec);
        }

        public override void Update(TicketStatus model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.TicketStatus;
        }
    }
}
