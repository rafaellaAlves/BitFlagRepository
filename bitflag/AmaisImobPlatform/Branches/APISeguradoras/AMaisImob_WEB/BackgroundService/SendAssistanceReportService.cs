using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BackgroundService
{
    public class SendAssistanceReportService
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IConfiguration Configuration;

        public SendAssistanceReportService(IServiceScopeFactory ScopeFactory, IConfiguration Configuration)
        {
            this.ScopeFactory = ScopeFactory;
            this.Configuration = Configuration;
        }

        public void Init()
        {
            BackgroundService.Container.SendAssistanceReportService = new BackgroundServices.SendAssistanceReportService(Configuration.GetConnectionString("DefaultConnection"));
            BackgroundService.Container.SendAssistanceReportService.Iniciar();
        }
    }
}
