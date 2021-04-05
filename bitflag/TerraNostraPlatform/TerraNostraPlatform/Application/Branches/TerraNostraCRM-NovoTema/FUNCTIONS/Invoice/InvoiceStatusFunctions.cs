using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.Invoice
{
    public class InvoiceStatusFunctions : BasicFunctions<DB.InvoiceStatus, DB.InvoiceStatus>
    {
        public InvoiceStatusFunctions(TerraNostraContext context) 
            : base(context, "InvoiceStatusId")
        {
        }

        public override int Create(InvoiceStatus model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<InvoiceStatus> GetDataViewModel(IEnumerable<InvoiceStatus> data)
        {
            return data.ToList();
        }

        public override InvoiceStatus GetDataViewModel(InvoiceStatus data)
        {
            return data;
        }

        public override void Update(InvoiceStatus model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InvoiceStatus;
        }
    }
}
