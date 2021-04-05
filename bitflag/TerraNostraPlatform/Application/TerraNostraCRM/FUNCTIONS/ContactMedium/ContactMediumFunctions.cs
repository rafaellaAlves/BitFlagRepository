using DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUNCTIONS.ContactMedium
{
    public class ContactMediumFunctions : BasicListFunctions<DB.ContactMedium, DB.ContactMedium>
    {
        public ContactMediumFunctions(TerraNostraContext context) : base(context, "ContactMediumId")
        {
        }

        public override List<DB.ContactMedium> GetDataViewModel(IEnumerable<DB.ContactMedium> data)
        {
            throw new NotImplementedException();
        }

        public override DB.ContactMedium GetDataViewModel(DB.ContactMedium data)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet() => this.dbSet = this.context.ContactMedium;
    }
}
