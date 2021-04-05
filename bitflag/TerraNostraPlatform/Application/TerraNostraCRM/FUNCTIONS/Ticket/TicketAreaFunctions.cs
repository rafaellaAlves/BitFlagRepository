using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Ticket
{
    public class TicketAreaFunctions : BasicFunctions<DB.TicketArea, DB.TicketArea>
    {
        public TicketAreaFunctions(TerraNostraContext context) 
            : base(context, "TicketAreaId")
        {
        }

        public override int Create(TicketArea model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TicketArea> GetDataViewModel(IEnumerable<TicketArea> data)
        {
            return data.ToList();
        }

        public override TicketArea GetDataViewModel(TicketArea data)
        {
            return data;
        }

        public override void Update(TicketArea model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.TicketArea;
        }
    }
}
