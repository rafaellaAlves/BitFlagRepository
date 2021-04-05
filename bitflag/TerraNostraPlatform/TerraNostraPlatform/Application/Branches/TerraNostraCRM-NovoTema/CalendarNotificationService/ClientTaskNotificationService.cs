using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DB;

namespace BackgroundServices
{
    public class ClientTaskNotificationService : BackgroundServices.Bases.ServicoProcessamentoFila<List<DB.ClientTaskNotification>>
    {
        #region [EVENTOS]
        public delegate void FinalizadoHandler(List<DB.ClientTaskNotification> sender, bool erro);
        public event FinalizadoHandler FinalizadoEvent;
        #endregion

        #region [Propriedades]
        private class Retorno
        {
            public string Version { get; set; }
            public int StatusCode { get; set; }
            public bool Success { get; set; }
            public object Content { get; set; }
        }

        private DB.TerraNostraContext context;
        private FUNCTIONS.Client.ClientTaskNotificationFunctions clientTaskNotificationFunctions;
        private FUNCTIONS.Client.ClientCalendarFunctions clientCalendarFunctions;
        #endregion

        public ClientTaskNotificationService(int intervalo, string connectionString) : base(intervalo)
        {
            Init(connectionString);
        }

        public ClientTaskNotificationService(string connectionString, int intervalo, Dictionary<string, object> parametros) : base(intervalo, parametros)
        {
            Init(connectionString);
        }

        public void Init(string connectionString)
        {
            var options = new DbContextOptionsBuilder<DB.TerraNostraContext>();
            options.UseSqlServer(connectionString);
            this.context = new DB.TerraNostraContext(options.Options);

            this.clientTaskNotificationFunctions = new FUNCTIONS.Client.ClientTaskNotificationFunctions(context);
            this.clientCalendarFunctions = new FUNCTIONS.Client.ClientCalendarFunctions(context);
        }

        private void VerifyNotification()
        {
            var notifications = from x in this.context.ClientCalendar
                                join c in this.context.Client on x.ClientId equals c.ClientId
                                join u in this.context.User on c.ResponsibleId equals u.UserId
                                where x.NoticeDate.HasValue && x.NoticeDate <= DateTime.Now && !x.IsDeleted && !x.Notified
                                select new
                                {
                                    clientTask = x,
                                    client = c,
                                    responsible = u
                                };

            if (notifications.Count() == 0) return;

            foreach (var notification in notifications)
            {
                clientTaskNotificationFunctions.Create(new DTO.Client.ClientTaskNotificationViewModel
                {
                    CreatedDate = DateTime.Now,
                    Title = notification.clientTask.Title,
                    UserId = notification.responsible.UserId,
                    ClientTaskId = notification.clientTask.ClientTaskId
                });
            }
        }

        public override List<ClientTaskNotification> ObterItem()
        {
            var notifications = new List<ClientTaskNotification>();

            var notification = (from x in this.context.ClientCalendar
                                join c in this.context.Client on x.ClientId equals c.ClientId
                                join u in this.context.User on c.ResponsibleId equals u.UserId
                                where x.NoticeDate.HasValue && x.NoticeDate <= DateTime.Now && !x.IsDeleted && !x.Notified
                                select new ClientTaskNotification
                                {
                                    ClientName = c.FirstName + " " + c.LastName,
                                    ClientTaskId = x.ClientTaskId,
                                    ClientId = x.ClientId,
                                    TaskDate = x.TaskDate,
                                    Readed = false,
                                    Title = x.Title,
                                    UserId = u.UserId,
                                    CreatedDate = DateTime.Now
                                }).FirstOrDefault();

            if (notification != null)
            {
                notifications.Add(notification);

                foreach (var item in GetAdministrators())
                {
                    notifications.Add(new ClientTaskNotification
                    {
                        ClientName = notification.ClientName,
                        ClientId = notification.ClientId,
                        ClientTaskId = notification.ClientTaskId,
                        TaskDate = notification.TaskDate,
                        Readed = notification.Readed,
                        Title = notification.Title,
                        UserId = item.UserId,
                        CreatedDate = DateTime.Now
                    });
                }
            }

            return notifications;
        }

        public IEnumerable<DB.User> GetAdministrators()
        {
            return (from r in this.context.Role
                    join ur in this.context.AspNetUserRoles on r.Id equals ur.RoleId
                    join u in this.context.User on ur.UserId equals u.UserId
                    where r.NormalizedName == "ADMINISTRATOR" && !u.IsDeleted
                    select u);
        }

        public override void ProcessarItem(List<ClientTaskNotification> item)
        {
            clientTaskNotificationFunctions.CreateRange(item);
            if (item.Count > 0) clientCalendarFunctions.Notified(item.First().ClientTaskId);
        }

        public override void Progresso(List<ClientTaskNotification> item)
        {
            throw new NotImplementedException();
        }

        public override void Finalizar(List<ClientTaskNotification> item)
        {
            FinalizadoEvent(item, false);
        }
    }
}
