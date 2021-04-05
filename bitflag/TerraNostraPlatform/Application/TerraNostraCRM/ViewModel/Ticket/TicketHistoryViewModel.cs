using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Ticket
{
    public class TicketHistoryViewModel
    {
        public int TicketHistoryId { get; set; }
        public string ActionType { get; set; }
        public int TicketId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string _ModificationDate { get { return ModificationDate.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public int TicketAreaId { get; set; }
        public int OwnerId { get; set; }
        public int? AttendentId { get; set; }
        public int StatusId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string _EndDate { get { return EndDate.HasValue? EndDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : ""; } }
        public int? EndBy { get; set; }
        public int? MessageId { get; set; }
        public string MessageText { get; set; }
        public int? To { get; set; }
        public int? From { get; set; }
    }
}
