using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.SignalRHubs
{
    public class NotificationHub : Hub
    {
        private IHubContext<NotificationHub> hubContext;
        private readonly FUNCTIONS.Client.ClientCalendarFunctions clientCalendarFunctions;
        public NotificationHub(IHubContext<NotificationHub> hubContext, FUNCTIONS.Client.ClientCalendarFunctions clientCalendarFunctions)
        {
            this.hubContext = hubContext;
            this.clientCalendarFunctions = clientCalendarFunctions;
        }

        public async Task SendNotificationToUser(IEnumerable<int> codUsuario, DB.ClientTaskNotification notification)
        {
            DTO.Client.ClientCalendarViewModel task = null;

            if (notification != null)
                task = clientCalendarFunctions.GetDataViewModel(clientCalendarFunctions.GetDataByID(notification.ClientTaskId));

            await this.hubContext.Clients.Users(codUsuario.Select(x => x.ToString()).ToList()).SendAsync("UpdateNotifications", task);
        }
    }
}
