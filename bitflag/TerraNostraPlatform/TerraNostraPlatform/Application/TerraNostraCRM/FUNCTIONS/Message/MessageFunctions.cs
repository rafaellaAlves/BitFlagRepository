using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Message;

namespace FUNCTIONS.Message
{
    public class MessageFunctions : BasicFunctions<DB.Message, DTO.Message.MessageViewModel>
    {
        public MessageFunctions(TerraNostraContext context) : 
            base(context, "MessageId")
        {
        }

        public override int Create(MessageViewModel model)
        {
            var message = new DB.Message
            {
                TicketId = model.TicketId.Value,
                From = model.From.Value,
                To = model.To,
                Text = model.Text,
                ReferencedMessageId = model.ReferencedMessageId,
            };

            this.dbSet.Add(message);
            this.context.SaveChanges();

            return message.MessageId;
        }

        public override void Delete(object id)
        {
            var message = GetDataByID(id);
            message.IsDeleted = true;
            message.DeletedDate = DateTime.Now;

            this.dbSet.Update(message);
            this.context.SaveChanges();
        }

        public override List<MessageViewModel> GetDataViewModel(IEnumerable<DB.Message> data)
        {
            var users = this.context.User.ToList();

            return (from y in data
                    join f in users on y.From equals f.UserId into _f
                    from __f in _f.DefaultIfEmpty()
                    join t in users on y.To equals t.UserId into _t
                    from __t in _t.DefaultIfEmpty()
                    select new MessageViewModel {
                        TicketId = y.TicketId,
                        CreatedDate = y.CreatedDate,
                        DeletedDate = y.DeletedDate,
                        From = y.From,
                        From_Name = __f != null? __f.FirstName + " " + __f.LastName : "",
                        IsDeleted = y.IsDeleted,
                        MessageId = y.MessageId,
                        ReferencedMessageId = y.ReferencedMessageId,
                        Text = y.Text,
                        To = y.To,
                        To_Name = __t != null ? __t.FirstName + " " + __t.LastName : ""
                    }).ToList();
        }

        public override MessageViewModel GetDataViewModel(DB.Message data)
        {
            var users = this.context.User.ToList();
            var f = users.SingleOrDefault(x => x.UserId == data.From);
            DB.User t = null;
            if(data.To.HasValue) t = users.SingleOrDefault(x => x.UserId == data.To);
            return new MessageViewModel
            {
                TicketId = data.TicketId,
                CreatedDate = data.CreatedDate,
                DeletedDate = data.DeletedDate,
                From = data.From,
                From_Name = f != null ?f.FirstName + " " + f.LastName : "",
                IsDeleted = data.IsDeleted,
                MessageId = data.MessageId,
                ReferencedMessageId = data.ReferencedMessageId,
                Text = data.Text,
                To = data.To,
                To_Name = t != null ? t.FirstName + " " + t.LastName : "",
            };
        }

        public List<MessageListViewModel> GetDataListViewModel(IEnumerable<DB.Message> data)
        {
            var users = this.context.User.ToList();
            var userRoles = this.context.AspNetUserRoles.ToList();
            var roles = this.context.Role.ToList();

            return (from y in data
                    join ufrom in users on y.From equals ufrom.UserId
                    join urfrom in userRoles on ufrom.UserId equals urfrom.UserId
                    join rfrom in roles on urfrom.RoleId equals rfrom.Id
                    group new { y, ufrom, rfrom } by new { y.TicketId } into c
                    select new MessageListViewModel
                    {
                        TicketId = c.Last().y.TicketId,
                        CreatedDate = c.Last().y.CreatedDate,
                        DeletedDate = c.Last().y.DeletedDate,
                        From = c.Last().y.From,
                        IsDeleted = c.Last().y.IsDeleted,
                        MessageId = c.Last().y.MessageId,
                        ReferencedMessageId = c.Last().y.ReferencedMessageId,
                        Text = c.Last().y.Text,
                        To = c.Last().y.To,
                        LastMessageSender = c.Last().ufrom.FirstName + " " + c.Last().ufrom.LastName,
                        LastMessage = c.Last().y.Text
                    }).ToList();
        }

        public override void Update(MessageViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Message;
        }
    }
}
