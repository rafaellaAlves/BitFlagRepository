using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Message
{
    public class MessageListViewModel
    {
        public int MessageId { get; set; }
        public int TicketId { get; set; }
        public int? ReferencedMessageId { get; set; }
        public int From { get; set; }
        public int? To { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToString("dd/MM/yyyy"); } }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.HasValue ? DeletedDate.Value.ToString("dd/MM/yyyy") : ""; } }
        public string LastMessageSender { get; set; }
        public string LastMessage { get; set; }
    }
}
