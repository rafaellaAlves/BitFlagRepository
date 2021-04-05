using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.SignalRHubs;

namespace Web.BackgroundService
{
    public class ClientTaskNotificationService
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IConfiguration Configuration;

        public ClientTaskNotificationService(IServiceScopeFactory ScopeFactory, IConfiguration Configuration)
        {
            this.ScopeFactory = ScopeFactory;
            this.Configuration = Configuration;
        }

        public void Init(int intervalo)
        {
            BackgroundService.Container.ClientTaskNotificationService = new BackgroundServices.ClientTaskNotificationService(intervalo, Configuration.GetConnectionString("DefaultConnection"));
            BackgroundService.Container.ClientTaskNotificationService.FinalizadoEvent += async (List<DB.ClientTaskNotification> sender, bool erro) =>
            {
                try
                {
                    using (var scopeFactory = ScopeFactory.CreateScope())
                    {
                        var notificationHub = scopeFactory.ServiceProvider.GetRequiredService<NotificationHub>();

                        await notificationHub.SendNotificationToUser(sender.Select(x => x.UserId), sender.FirstOrDefault());
                    }
                }
                catch { }
            };
            BackgroundService.Container.ClientTaskNotificationService.Iniciar();
        }
    }
}
