using DB;
using DTO.Client;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Client
{
    public class ClientTaskNotificationFunctions : BasicFunctions<ClientTaskNotification, ClientTaskNotificationViewModel>
    {
        public ClientTaskNotificationFunctions(TerraNostraContext context) 
            : base(context, "ClientTaskNotificationId")
        {
        }

        public override int Create(ClientTaskNotificationViewModel model)
        {
            var clientTaskNotification = model.CopyToEntity<ClientTaskNotification>();
            this.dbSet.Add(clientTaskNotification);
            this.context.SaveChanges();

            return clientTaskNotification.ClientTaskNotificationId;
        }

        public void CreateRange(IEnumerable<ClientTaskNotification> model)
        {
            this.dbSet.AddRange(model);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<ClientTaskNotificationViewModel> GetDataViewModel(IEnumerable<ClientTaskNotification> data)
        {
            return data.Select(x => x.CopyToEntity<ClientTaskNotificationViewModel>()).ToList();
        }

        public override ClientTaskNotificationViewModel GetDataViewModel(ClientTaskNotification data)
        {
            return data.CopyToEntity<ClientTaskNotificationViewModel>();
        }

        public override void Update(ClientTaskNotificationViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientTaskNotification;
        }

        public void Readed(int clientTaskNotificationId)
        {
            var clientTaskNotification = GetDataByID(clientTaskNotificationId);

            clientTaskNotification.Readed = true;
            this.dbSet.Update(clientTaskNotification);
            this.context.SaveChanges();
        }

        public IEnumerable<ClientTaskNotificationViewModel> GetNotifications(int userId)
        {
            return from x in this.dbSet
                   where !x.Readed && x.UserId == userId
                   select x.CopyToEntity<ClientTaskNotificationViewModel>();

        }
    }
}
