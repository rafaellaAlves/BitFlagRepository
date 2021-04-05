using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;

namespace Web.Services.MedicGroup
{
    public class MedicGroupCRMService : Shared.BaseListServices<MedicGroupCrm, MedicGroupCrm, int>
    {
        public MedicGroupCRMService(VendasContext context) : base(context, "MedicGroupCRMId")
        {
        }
    }
}
