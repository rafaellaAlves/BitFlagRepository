using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace FUNCTIONS.Invoice
{
    public class InvoiceViewFunctions : BasicListFunctions<DB.InvoiceView, DB.InvoiceView>
    {
        public InvoiceViewFunctions(TerraNostraContext context) : base(context, "InvoiceId")
        {
        }

        public override List<InvoiceView> GetDataViewModel(IEnumerable<InvoiceView> data)
        {
            throw new NotImplementedException();
        }

        public override InvoiceView GetDataViewModel(InvoiceView data)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InvoiceView;
        }
    }
}
