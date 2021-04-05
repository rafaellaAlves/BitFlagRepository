using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BackgroundService
{
    public class UpdateDemandDestinationStatusService
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IConfiguration Configuration;

        public UpdateDemandDestinationStatusService(IServiceScopeFactory ScopeFactory, IConfiguration Configuration)
        {
            this.ScopeFactory = ScopeFactory;
            this.Configuration = Configuration;
        }

        public void Init()
        {
            BackgroundService.Container.UpdateDemandDestinationStatusService = new BackgroundServices.UpdateDemandDestinationStatusService(Configuration.GetConnectionString("DefaultConnection"));
            BackgroundService.Container.UpdateDemandDestinationStatusService.Iniciar();
        }
    }
}
