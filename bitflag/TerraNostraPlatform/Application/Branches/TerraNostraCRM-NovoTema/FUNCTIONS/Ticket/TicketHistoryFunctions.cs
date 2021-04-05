using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Ticket;
using FUNCTIONS.AuditLog;

namespace FUNCTIONS.Ticket
{
    public class TicketHistoryFunctions : BasicFunctions<DB.TicketHistory, DTO.Ticket.TicketHistoryViewModel>
    {
        public TicketHistoryFunctions(TerraNostraContext context) 
            : base(context, "TicketHistoryId")
        {
        }

        public override int Create(TicketHistoryViewModel model)
        {
            var ticketHistory = new TicketHistory
            {
                AttendentId = model.AttendentId,
                Description = model.Description,
                EndBy = model.EndBy,
                EndDate = model.EndDate,
                OwnerId = model.OwnerId,
                StatusId = model.StatusId,
                Subject = model.Subject,
                TicketAreaId = model.TicketAreaId,
                TicketId = model.TicketId,
                ActionType = model.ActionType,
                From = model.From,
                MessageId = model.MessageId,
                MessageText = model.MessageText,
                To = model.To
            };

            this.dbSet.Add(ticketHistory);
            this.context.SaveChanges();

            return ticketHistory.TicketHistoryId;
        }

        public int Create(TicketViewModel ticket, DBActionType actionType)
        {
            var ticketHistory = new TicketHistory
            {
                AttendentId = ticket.AttendentId,
                Description = ticket.Description,
                EndBy = ticket.EndBy,
                EndDate = ticket.EndDate,
                OwnerId = ticket.OwnerId.Value,
                StatusId = ticket.StatusId.Value,
                Subject = ticket.Subject,
                TicketAreaId = ticket.TicketAreaId.Value,
                TicketId = ticket.TicketId.Value,
                ActionType = actionType.ToString()
            };

            this.dbSet.Add(ticketHistory);
            this.context.SaveChanges();

            return ticketHistory.TicketHistoryId;
        }

        public int Create(TicketViewModel ticket, DTO.Message.MessageViewModel message, DBActionType actionType)
        {
            var ticketHistory = new TicketHistory
            {
                AttendentId = ticket.AttendentId,
                Description = ticket.Description,
                EndBy = ticket.EndBy,
                EndDate = ticket.EndDate,
                OwnerId = ticket.OwnerId.Value,
                StatusId = ticket.StatusId.Value,
                Subject = ticket.Subject,
                TicketAreaId = ticket.TicketAreaId.Value,
                TicketId = ticket.TicketId.Value,
                ActionType = actionType.ToString(),
                From = message.From,
                MessageId = message.MessageId,
                MessageText = message.Text,
                To = message.To
            };

            this.dbSet.Add(ticketHistory);
            this.context.SaveChanges();

            return ticketHistory.TicketHistoryId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TicketHistoryViewModel> GetDataViewModel(IEnumerable<TicketHistory> data)
        {
            return (from y in data
                    select new TicketHistoryViewModel
                    {
                        TicketHistoryId = y.TicketHistoryId,
                        AttendentId = y.AttendentId,
                        Description = y.Description,
                        EndBy = y.EndBy,
                        EndDate = y.EndDate,
                        ModificationDate = y.ModificationDate,
                        OwnerId = y.OwnerId,
                        StatusId = y.StatusId,
                        Subject = y.Subject,
                        TicketAreaId = y.TicketAreaId,
                        TicketId = y.TicketId,
                        ActionType = y.ActionType,
                        From = y.From,
                        MessageId = y.MessageId,
                        MessageText = y.MessageText,
                        To = y.To
                    }).ToList();
        }

        public override TicketHistoryViewModel GetDataViewModel(TicketHistory data)
        {
            return new TicketHistoryViewModel
            {
                TicketHistoryId = data.TicketHistoryId,
                AttendentId = data.AttendentId,
                Description = data.Description,
                EndBy = data.EndBy,
                EndDate = data.EndDate,
                ModificationDate = data.ModificationDate,
                OwnerId = data.OwnerId,
                StatusId = data.StatusId,
                Subject = data.Subject,
                TicketAreaId = data.TicketAreaId,
                TicketId = data.TicketId,
                ActionType = data.ActionType,
                From = data.From,
                MessageId = data.MessageId,
                MessageText = data.MessageText,
                To = data.To
            };
        }

        public override void Update(TicketHistoryViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.TicketHistory;
        }
    }
}
