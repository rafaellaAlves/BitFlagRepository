using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Message
{
    public class MessageViewModel
    {
        public int? MessageId { get; set; }
        public int? TicketId { get; set; }
        public int? ReferencedMessageId { get; set; }
        public int? From { get; set; }
        public string From_Name { get; set; }
        public int? To { get; set; }
        public string To_Name { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.HasValue ? CreatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : ""; } }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.HasValue ? DeletedDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : ""; } }
    }
}
