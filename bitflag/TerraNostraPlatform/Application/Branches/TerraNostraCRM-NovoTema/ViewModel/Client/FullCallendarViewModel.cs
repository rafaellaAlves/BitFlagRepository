using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Client
{
    public class FullCallendarViewModel
    {
        public int? ClientId { get; set; }
        public int? ClientTaskId { get; set; }
        public DateTime? NoticeDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string _Title { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }
    }
}
