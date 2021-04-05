using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.RDStation;
using FUNCTIONS.Client;
using FUNCTIONS.RDStation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class RDStationController : Controller
    {
        public ClientFunctions clientFunctions;
        public RDStationLogFunctions rdStationLogFunctions;

        public RDStationController(ClientFunctions clientFunctions, RDStationLogFunctions rdStationLogFunctions)
        {
            this.clientFunctions = clientFunctions;
            this.rdStationLogFunctions = rdStationLogFunctions;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> NewOpportunity(LeadsViewModel data)
        {
            if (data.leads == null || data.leads.Count == 0) return await Task.Run(() => Ok());

            foreach (var lead in data.leads)
            {
                try
                {
                    if (!lead.opportunity)
                    {
                        rdStationLogFunctions.Create(lead.uuid, null, false, "Contato não está como \"Oportunidade\".");
                        continue;
                    }

                    var r = await clientFunctions.CreateFromRDStationLead(lead);

                    rdStationLogFunctions.Create(lead.uuid, r.HasError ? null : (int?)r.Code, !r.HasError, r.HasError ? r.Message : null);
                }
                catch (Exception ex)
                {
                    rdStationLogFunctions.Create(lead.uuid, null, false, $"Houve um erro na importação (Erro: {ex.Message}).");
                }
            }

            return await Task.Run(() => Ok());
        }
    }
}