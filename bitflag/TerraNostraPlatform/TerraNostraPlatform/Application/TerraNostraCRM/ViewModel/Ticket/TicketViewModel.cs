﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Ticket
{
    public class TicketViewModel
    {
        public int? TicketId { get; set; }
        public int? OwnerId { get; set; }
        public int? AttendentId { get; set; }
        public int? StatusId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EndBy { get; set; }
        public string Message { get; set; }
        public int? TicketAreaId { get; set; }
    }
}
