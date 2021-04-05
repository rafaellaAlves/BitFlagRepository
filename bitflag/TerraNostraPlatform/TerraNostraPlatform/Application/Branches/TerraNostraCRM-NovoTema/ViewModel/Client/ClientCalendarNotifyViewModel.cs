using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Client
{
    public class ClientCalendarNotifyViewModel
    {
        public int ClientId { get; set; }
        public int ClientTaskId { get; set; }
        public int ClientTaskNotificationId { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public DateTime TaskDate { get; set; }
        public string _TaskDate { get { return TaskDate.ToBrazilianDateFormat(); } }
        public string _TaskDateTime { get { return TaskDate.ToBrazilianTime1Format(); } }
    }
}
