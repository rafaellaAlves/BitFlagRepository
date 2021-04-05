using API.Entities.TipoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ITipoServicoService
    {
        List<TipoServicoViewModel> List();
    }

    public class TipoServicoService : ITipoServicoService
    {
        private readonly DB.TerraNostraContext terraNostaContext;
        public TipoServicoService(DB.TerraNostraContext terraNostaContext)
        {
            this.terraNostaContext = terraNostaContext;
        }

        public List<TipoServicoViewModel> List()
        {
            var serviceTypeFunctions = new FUNCTIONS.ServiceType.ServiceTypeFunctions(terraNostaContext);
            return serviceTypeFunctions.GetData().Select(x => new TipoServicoViewModel() {
                Tipo_servico = x.ServiceTypeId,
                Nome_servico = x.Name
            }).ToList();
        }

        public string ObterNome(int serviceTypeId)
        {
            var serviceTypeFunctions = new FUNCTIONS.ServiceType.ServiceTypeFunctions(terraNostaContext);
            return serviceTypeFunctions.GetDataByID(serviceTypeId).Name;
        }
    }
}
