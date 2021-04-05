using System;
using System.Collections.Generic;

namespace DB
{
    public partial class TicketHistory
    {
        public int TicketHistoryId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ActionType { get; set; }
        public int TicketId { get; set; }
        public int TicketAreaId { get; set; }
        public int OwnerId { get; set; }
        public int? AttendentId { get; set; }
        public int StatusId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EndBy { get; set; }
        public int? MessageId { get; set; }
        public string MessageText { get; set; }
        public int? To { get; set; }
        public int? From { get; set; }
    }
}
