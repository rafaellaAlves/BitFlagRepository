using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Ticket;

namespace FUNCTIONS.Ticket
{
    public class TicketFunctions : BasicFunctions<DB.Ticket, DTO.Ticket.TicketViewModel>
    {
        private readonly Message.MessageFunctions messageFunctions;
        private readonly Client.ClientFunctions clientFunctions;

        public TicketFunctions(TerraNostraContext context, Client.ClientFunctions clientFunctions)
            : base(context, "TicketId")
        {
            messageFunctions = new Message.MessageFunctions(context);
            this.clientFunctions = clientFunctions;
        }

        public override int Create(TicketViewModel model)
        {
            var ticket = new DB.Ticket
            {
                CreatedBy = model.CreatedBy.Value,
                Description = model.Description,
                OwnerId = model.OwnerId.Value,
                StatusId = model.StatusId.Value,
                Subject = model.Subject,
                TicketAreaId = model.TicketAreaId.Value,
                AttendentId = model.AttendentId
            };

            this.dbSet.Add(ticket);
            this.context.SaveChanges();

            return ticket.TicketId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TicketViewModel> GetDataViewModel(IEnumerable<DB.Ticket> data)
        {
            return (from y in data
                    select new TicketViewModel
                    {
                        CreatedBy = y.CreatedBy,
                        Description = y.Description,
                        OwnerId = y.OwnerId,
                        StatusId = y.StatusId,
                        Subject = y.Subject,
                        TicketId = y.TicketId,
                        AttendentId = y.AttendentId,
                        CreatedDate = y.CreatedDate,
                        EndBy = y.EndBy,
                        EndDate = y.EndDate,
                        TicketAreaId = y.TicketAreaId,
                    }).ToList();
        }

        public override TicketViewModel GetDataViewModel(DB.Ticket data)
        {
            return new TicketViewModel
            {
                CreatedBy = data.CreatedBy,
                Description = data.Description,
                OwnerId = data.OwnerId,
                StatusId = data.StatusId,
                Subject = data.Subject,
                TicketId = data.TicketId,
                AttendentId = data.AttendentId,
                CreatedDate = data.CreatedDate,
                EndBy = data.EndBy,
                EndDate = data.EndDate,
                TicketAreaId = data.TicketAreaId
            };
        }

        public List<TicketListViewModel> GetDataListViewModel(IEnumerable<DB.Ticket> data)
        {
            var status = this.context.TicketStatus.ToList();
            var users = this.context.User.ToList();
            var areas = this.context.TicketArea.ToList();

            return (from y in data
                    join s in status on y.StatusId equals s.TicketStatusId
                    join a in areas on y.TicketAreaId equals a.TicketAreaId
                    join attendent in users on y.AttendentId equals attendent.UserId into _attendent
                    from __attendent in _attendent.DefaultIfEmpty()
                    join client in users on y.OwnerId equals client.UserId
                    select new TicketListViewModel
                    {
                        CreatedBy = y.CreatedBy,
                        Description = y.Description,
                        OwnerId = y.OwnerId,
                        OwnerName = client.FirstName + " " + client.LastName,
                        StatusId = y.StatusId,
                        StatusName = s.Name,
                        Subject = y.Subject,
                        TicketId = y.TicketId,
                        AttendentId = y.AttendentId,
                        AttendentName = __attendent != null ? __attendent.FirstName + " " + __attendent.LastName : "-",
                        CreatedDate = y.CreatedDate,
                        EndBy = y.EndBy,
                        EndDate = y.EndDate,
                        TicketAreaId = y.TicketAreaId,
                        TicketAreaName = a.Name
                    }).ToList();
        }

        public TicketMessageViewModel GetDataMessageViewModel(DB.Ticket data)
        {
            var users = this.context.User.ToList();

            var owner = users.Single(x => x.UserId == data.OwnerId);
            var attendent = users.SingleOrDefault(x => x.UserId == data.AttendentId);
            var stats = this.context.TicketStatus.Single(x => x.TicketStatusId == data.StatusId);
            var area = this.context.TicketArea.Single(x => x.TicketAreaId == data.TicketAreaId);

            return new TicketMessageViewModel
            {
                CreatedBy = data.CreatedBy,
                Description = data.Description,
                OwnerId = data.OwnerId,
                StatusId = data.StatusId,
                StatusName = stats.Name,
                Subject = data.Subject,
                TicketId = data.TicketId,
                AttendentId = data.AttendentId,
                AttendentName = attendent != null ? attendent.FirstName + " " + attendent.LastName : "-",
                CreatedDate = data.CreatedDate,
                EndBy = data.EndBy,
                EndDate = data.EndDate,
                Messages = messageFunctions.GetDataViewModel(messageFunctions.GetData(x => x.TicketId == data.TicketId)),
                TicketAreaId = data.TicketAreaId,
                TicketAreaName = area.Name,
                Client = new DTO.User.UserViewModel
                {
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Email = owner.Email,
                    Cpf = owner.Cpf
                }
            };
        }

        public override void Update(TicketViewModel model)
        {
            var ticket = GetDataByID(model.TicketId);

            ticket.CreatedBy = model.CreatedBy.Value;
            ticket.Description = model.Description;
            ticket.OwnerId = model.OwnerId.Value;
            ticket.StatusId = model.StatusId.Value;
            ticket.Subject = model.Subject;
            ticket.TicketAreaId = model.TicketAreaId.Value;
            ticket.AttendentId = model.AttendentId;

            this.dbSet.Update(ticket);
            this.context.SaveChanges();
        }

        public List<DB.User> GetUserAttendents(int userId)
        {
            var tickets = this.dbSet.Where(x => x.OwnerId == userId).ToList();
            var users = this.context.User.ToList();

            return (from y in tickets
                    join a in users on y.AttendentId equals a.UserId
                    select a).ToList();
        }

        public void TicketMessageUpdate(DTO.Ticket.TicketViewModel model)
        {
            var ticket = GetDataByID(model.TicketId);

            ticket.StatusId = model.StatusId.Value;

            this.dbSet.Update(ticket);
            this.context.SaveChanges();
        }

        public void SetAttendent(TicketViewModel model)
        {
            var ticket = GetDataByID(model.TicketId);
            var queueId = this.context.TicketStatus.Single(x => x.ExternalCode == "QUEUE").TicketStatusId;

            if (ticket.StatusId == queueId)
            {
                ticket.StatusId = this.context.TicketStatus.Single(x => x.ExternalCode == "ACTIVE").TicketStatusId;
            }

            ticket.AttendentId = model.AttendentId.Value;

            this.dbSet.Update(ticket);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Ticket;
        }
    }
}
