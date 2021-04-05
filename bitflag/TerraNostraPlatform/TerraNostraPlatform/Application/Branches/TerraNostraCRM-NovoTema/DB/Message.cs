using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int TicketId { get; set; }
        public int? ReferencedMessageId { get; set; }
        public int From { get; set; }
        public int? To { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
