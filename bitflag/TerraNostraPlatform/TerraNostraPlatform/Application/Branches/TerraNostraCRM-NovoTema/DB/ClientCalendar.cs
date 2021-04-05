using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientCalendar
    {
        public int ClientTaskId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime? NoticeDate { get; set; }
        public DateTime TaskDate { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Notified { get; set; }
    }
}
