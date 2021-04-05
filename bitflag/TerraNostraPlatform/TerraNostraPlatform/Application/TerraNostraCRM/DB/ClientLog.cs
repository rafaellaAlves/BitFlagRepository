using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientLog
    {
        public int ClientLogId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModificatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string Title { get; set; }
        public string PlainText { get; set; }
    }
}
