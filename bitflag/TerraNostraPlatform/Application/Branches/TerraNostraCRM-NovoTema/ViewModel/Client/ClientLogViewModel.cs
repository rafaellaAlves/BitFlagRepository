using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Client
{
    public class ClientLogViewModel
    {
        public int? ClientLogId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string PlainText { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } }
        public string _CreatedDateTime { get { return CreatedDate.ToDateTimePtBR(); } }
        public string _CreatedDateHour { get { return CreatedDate.ToTimePtBR(); } }
        public DateTime? ModificatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
