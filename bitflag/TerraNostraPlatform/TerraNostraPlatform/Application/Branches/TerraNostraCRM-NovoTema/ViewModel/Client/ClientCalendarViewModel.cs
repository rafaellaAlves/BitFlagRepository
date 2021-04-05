using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;
using System.Linq;
using System.Threading.Tasks;
using DTO.Utils;


namespace DTO.Client
{
    public class ClientCalendarViewModel
    {
        public int? ClientTaskId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int UserId { get; set; }
        public string _NoticeDate { get { return NoticeDate.ToBrazilianDateFormat(); } set { NoticeDate = value.FromBrazilianDateFormatNullable(); } }
        public DateTime? NoticeDate { get; set; }
        public string _TaskDate { get { return TaskDate.ToBrazilianDateFormat(); } set { TaskDate = value.FromBrazilianDateFormat(); } }
        public DateTime TaskDate { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
