using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientTaskNotification
    {
        public int ClientTaskNotificationId { get; set; }
        public int ClientTaskId { get; set; }
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public DateTime TaskDate { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Readed { get; set; }
    }
}
