using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Client
{
    public class ClientTaskNotificationViewModel
    {
        public int ClientTaskNotificationId { get; set; }
        public int ClientTaskId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime TaskDate { get; set; }
        public string _TaskDate { get { return TaskDate.ToBrazilianDateFormat(); } }
        public string _TaskDateTime { get { return TaskDate.ToBrazilianTime1Format(); } }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToBrazilianDateFormat(); } set { CreatedDate = value.FromBrazilianDateFormat(); } }
        public bool Readed { get; set; }
    }
}
