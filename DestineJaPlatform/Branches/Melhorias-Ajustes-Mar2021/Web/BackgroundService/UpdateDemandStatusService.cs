using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BackgroundService
{
    public class UpdateDemandStatusService
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IConfiguration Configuration;

        public UpdateDemandStatusService(IServiceScopeFactory ScopeFactory, IConfiguration Configuration)
        {
            this.ScopeFactory = ScopeFactory;
            this.Configuration = Configuration;
        }

        public void Init()
        {
            BackgroundService.Container.UpdateDemandStatusService = new BackgroundServices.UpdateDemandStatusService(Configuration.GetConnectionString("DefaultConnection"));
            BackgroundService.Container.UpdateDemandStatusService.Iniciar();
        }
    }
}
