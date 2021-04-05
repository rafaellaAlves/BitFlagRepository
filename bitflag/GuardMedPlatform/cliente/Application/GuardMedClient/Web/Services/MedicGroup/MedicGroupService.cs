using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;

namespace Web.Services.MedicGroup
{
    public class MedicGroupService : Shared.BaseListServices<VendasDbContext.Models.MedicGroup, VendasDbContext.Models.MedicGroup, int>
    {
        private readonly MedicGroupCRMService medicGroupCRMService;
        public MedicGroupService(VendasContext context, MedicGroupCRMService medicGroupCRMService) : base(context, "MedicGroupId")
        {
            this.medicGroupCRMService = medicGroupCRMService;
        }

        public async Task<List<VendasDbContext.Models.MedicGroup>> GetMedicGroupsByCRM(string crm, string crmEstado)
        {
            var medicGroupIds = (await medicGroupCRMService.GetDataAsNoTrackingAsync(x => x.Crm  == crm && x.Crmestado == crmEstado)).Select(x => x.MedicGroupId);

            var retorno = medicGroupIds.Count() == 0 ? null : (await this.GetDataAsNoTrackingAsync(x => medicGroupIds.Contains(x.MedicGroupId))).OrderByDescending(x => x.Discount).ToList();
            return retorno;
        }
    }
}
