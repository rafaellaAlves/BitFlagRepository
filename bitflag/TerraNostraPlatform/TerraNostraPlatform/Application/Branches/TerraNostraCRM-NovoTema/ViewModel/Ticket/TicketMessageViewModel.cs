using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Ticket
{
    public class TicketMessageViewModel
    {
        public int TicketId { get; set; }
        public int OwnerId { get; set; }
        public int? AttendentId { get; set; }
        public string AttendentName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToString("dd/MM/yyyy"); } }
        public int CreatedBy { get; set; }
        public DateTime? EndDate { get; set; }
        public string _EndDate { get { return EndDate.HasValue ? EndDate.Value.ToString("dd/MM/yyyy") : ""; } }
        public int? EndBy { get; set; }
        public int TicketAreaId { get; set; }
        public string TicketAreaName { get; set; }

        public List<Message.MessageViewModel> Messages { get; set; }
        public User.UserViewModel Client { get; set; }
    }
}
