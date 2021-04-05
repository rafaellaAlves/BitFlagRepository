using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Client;
using Microsoft.EntityFrameworkCore;

namespace FUNCTIONS.Client
{
    public class ClientCalendarFunctions : BasicFunctions<DB.ClientCalendar, DTO.Client.ClientCalendarViewModel>
    {
        public ClientCalendarFunctions(TerraNostraContext context)
             : base(context, "ClientTaskId")
        {
        }

        public override int Create(ClientCalendarViewModel model)
        {
            var clientCalendar = new DB.ClientCalendar
            {
                ClientId = model.ClientId,
                UserId = model.UserId,
                NoticeDate = model.NoticeDate,
                TaskDate = model.TaskDate,
                Title = model.Title,
                Message = model.Message,
                IsDeleted = model.IsDeleted,
                DeletedDate = model.DeletedDate,
                CreatedDate = DateTime.Now,
            };

            this.dbSet.Add(clientCalendar);
            this.context.SaveChanges();

            return clientCalendar.ClientTaskId;
        }

        public override void Delete(object id)
        {
            var clientCalendar = this.GetDataByID(id);

            clientCalendar.IsDeleted = true;
            clientCalendar.DeletedDate = DateTime.Now;
            clientCalendar.CreatedDate = DateTime.Now;

            this.dbSet.Update(clientCalendar);
            this.context.SaveChanges();
        }

        public void Delete(object id, int userId)
        {
            var clientCalendar = this.GetDataByID(id);

            clientCalendar.IsDeleted = true;
            clientCalendar.DeletedDate = DateTime.Now;
            clientCalendar.UserId = userId;

            this.dbSet.Update(clientCalendar);
            this.context.SaveChanges();
        }

        public override List<ClientCalendarViewModel> GetDataViewModel(IEnumerable<ClientCalendar> data)
        {
            var user = this.context.User.ToList();

            return (from y in data
                    join c in this.context.Client on y.ClientId equals c.ClientId
                    select new ClientCalendarViewModel
                    {
                        ClientTaskId = y.ClientTaskId,
                        ClientId = y.ClientId,
                        ClientName = c.FirstName + " " + c.LastName,
                        UserId = y.UserId,
                        NoticeDate = y.NoticeDate,
                        TaskDate = y.TaskDate,
                        Title = y.Title,
                        Message = y.Message,
                        IsDeleted = y.IsDeleted,
                        DeletedDate = y.DeletedDate,
                        CreatedDate = y.CreatedDate,
                    }).ToList();
        }

        public override ClientCalendarViewModel GetDataViewModel(ClientCalendar data)
        {
            var client = this.context.Client.SingleOrDefault(x => x.ClientId == data.ClientId);

            return new ClientCalendarViewModel
            {
                ClientTaskId = data.ClientTaskId,
                ClientId = data.ClientId,
                ClientName = client.FirstName + " " + client.LastName,
                UserId = data.UserId,
                NoticeDate = data.NoticeDate,
                TaskDate = data.TaskDate,
                Title = data.Title,
                Message = data.Message,
                IsDeleted = data.IsDeleted,
                DeletedDate = data.DeletedDate,
                CreatedDate = data.CreatedDate,
            };
        }

        public List<ClientCalendar> GetDataByClientId(int clientId)
        {
            return this.context.ClientCalendar.Where(x => x.ClientId == clientId && !x.IsDeleted).ToList();
        }

        public List<ClientCalendarViewModel> GetDataByClientResponsibleId(int userId)
        {
            var client = this.context.Client.AsNoTracking();

            return (from x in this.context.ClientCalendar
                    join c in client on x.ClientId equals c.ClientId
                    where !x.IsDeleted && c.ResponsibleId == userId
                    select new ClientCalendarViewModel {
                        ClientId = x.ClientId,
                        ClientTaskId = x.ClientTaskId,
                        IsDeleted = x.IsDeleted,
                        ClientName = $"{c.FirstName} {c.LastName}",
                        CreatedDate = x.CreatedDate,
                        DeletedDate = x.DeletedDate,
                        Message = x.Message,
                        NoticeDate = x.NoticeDate,
                        TaskDate = x.TaskDate,
                        Title = x.Title,
                        UserId = x.UserId
                    }).ToList();
        }

        public List<ClientCalendar> GetDataByClientTaskId(int clientTaskId)
        {

            return this.context.ClientCalendar.Where(x => x.ClientTaskId == clientTaskId).ToList();
        }

        public FullCallendarViewModel GetFullCallendarViewModel(ClientCalendar data, string className = null, int? clientTaskId = null, bool titleWithClientName = false)
        {
            //if (!data.TaskDate || !data.NoticeDate.HasValue) return new FullCallendarViewModel();

            var client = this.context.Client.Single(x => x.ClientId == data.ClientId);

            return new FullCallendarViewModel
            {
                ClientId = data.ClientId,
                ClassName = (className ?? "fc-bg-deepskyblue") + (clientTaskId.HasValue && data.ClientTaskId == clientTaskId? " active" : ""),
                NoticeDate = data.NoticeDate.Value,
                End = data.TaskDate,
                Start = data.TaskDate,
                Title = (titleWithClientName ? $"{client.FirstName} {client.LastName} - " : "") + data.Title,
                _Title = data.Title,
                Description = data.Message,
            };
        }

        public FullCallendarViewModel GetFullCallendarViewModel(ClientCalendarViewModel data, string className = null, int? clientTaskId = null, bool titleWithClientName = false)
        {
            //if (!data.TaskDate.HasValue || !data.NoticeDate.HasValue) return new FullCallendarViewModel();

            var client = this.context.Client.Single(x => x.ClientId == data.ClientId);

            return new FullCallendarViewModel
            {
                ClientId = data.ClientId,
                ClientTaskId = data.ClientTaskId,
                ClassName = (className ?? "fc-bg-deepskyblue") + (clientTaskId.HasValue && data.ClientTaskId == clientTaskId ? " active" : ""),
                NoticeDate = data.NoticeDate,
                End = data.TaskDate,
                Start = data.TaskDate,
                Title = (titleWithClientName ? $"{client.FirstName} {client.LastName} - " : "") + data.Title,
                _Title = data.Title,
                Description = data.Message,
            };
        }

        public List<FullCallendarViewModel> GetFullCallendarViewModel(IEnumerable<ClientCalendarViewModel> data, string className = null, int? clientTaskId = null, bool titleWithClientName = false)
        {
            return (from x in data
                        //where x.NoticeDate.HasValue
                    select new FullCallendarViewModel
                    {
                        ClientId = x.ClientId,
                        ClientTaskId = x.ClientTaskId,
                        ClassName = (className ?? "fc-bg-deepskyblue") + (clientTaskId.HasValue && x.ClientTaskId == clientTaskId ? " active" : ""),
                        NoticeDate = x.NoticeDate,
                        End = x.TaskDate,
                        Start = x.TaskDate,
                        Title = (titleWithClientName ? $"<b>{x.ClientName}</b> - " : "") + x.Title,
                        _Title = x.Title,
                        Description = x.Message,
                    }).ToList();
        }

        public override void Update(ClientCalendarViewModel model)
        {
            var clientCalendar = this.GetDataByID(model.ClientTaskId);

            clientCalendar.Title = model.Title;
            clientCalendar.Message = model.Message;
            clientCalendar.UserId = model.UserId;
            clientCalendar.NoticeDate = model.NoticeDate;
            clientCalendar.TaskDate = model.TaskDate;

            this.dbSet.Update(clientCalendar);
            this.context.SaveChanges();

        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientCalendar;
        }

        public List<ClientCalendarViewModel> GetByResponsibleId(int? responsibleId, DateTime? startDate, DateTime? endDate)
        {
            var q = (from cc in this.dbSet
                     join c in this.context.Client on cc.ClientId equals c.ClientId
                     join __u in this.context.User on c.ResponsibleId equals __u.UserId into _u
                     from u in _u.DefaultIfEmpty()
                     where cc.IsDeleted == false
                     select new { c, cc });

            if (responsibleId.HasValue) q = q.Where(x => x.c.ResponsibleId == responsibleId.Value);
            if (startDate.HasValue) q = q.Where(x => x.cc.TaskDate.Date >= startDate.Value.Date);
            if (endDate.HasValue) q = q.Where(x => x.cc.TaskDate.Date <= endDate.Value.Date);


            return GetDataViewModel(q.Select(x => x.cc));
        }

        //public IEnumerable<ClientCalendarNotifyViewModel> GetTodayNotice(int? responsibleId)
        //{
        //    return from x in this.dbSet
        //           join c in this.context.Client on x.ClientId equals c.ClientId
        //           where  
        //                x.NoticeDate.HasValue &&
        //                x.NoticeDate <= DateTime.Now && 
        //                new DateTime(x.NoticeDate.Value.Year, x.NoticeDate.Value.Month, x.NoticeDate.Value.Day) == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) && 
        //                (!responsibleId.HasValue || c.ResponsibleId == responsibleId) &&
        //                !x.IsDeleted
        //           select 
        //                new ClientCalendarNotifyViewModel
        //           {
        //               ClientTaskId = x.ClientTaskId,
        //               ClientId = x.ClientId,
        //               ClientName = $"{c.FirstName} {c.LastName}",
        //               Title = x.Title,
        //               TaskDate = x.TaskDate
        //           };
        //}

        public IEnumerable<ClientCalendarNotifyViewModel> GetTodayTask(int? responsibleId)
        {
            return from x in this.dbSet
                   join c in this.context.Client on x.ClientId equals c.ClientId
                   where
                        new DateTime(x.TaskDate.Year, x.TaskDate.Month, x.TaskDate.Day) == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) &&
                        (!responsibleId.HasValue || c.ResponsibleId == responsibleId) &&
                        !x.IsDeleted
                   select new ClientCalendarNotifyViewModel
                   {
                       ClientTaskId = x.ClientTaskId,
                       ClientId = x.ClientId,
                       ClientName = $"{c.FirstName} {c.LastName}",
                       Title = x.Title,
                       TaskDate = x.TaskDate
                   };
        }

        public void Notified(int clientTaskId, bool notified = true)
        {
            var clientTask = GetDataByID(clientTaskId);
            clientTask.Notified = notified;
            this.dbSet.Update(clientTask);

            //if(notified == false)
            //{
            //    this.context.ClientTaskNotification.RemoveRange(this.context.ClientTaskNotification.Where(x => x.ClientTaskId == client.ClientTaskId));
            //}

            this.context.SaveChanges();
        }

        public void CheckNoticeDate(ClientCalendarViewModel model)
        {
            if (!model.ClientTaskId.HasValue) return;

            var clientCalendar = GetDataByID(model.ClientTaskId);

            if(clientCalendar.NoticeDate != model.NoticeDate && clientCalendar.Notified)
            {
                Notified(model.ClientTaskId.Value, false);
            }
        }
    }
}
