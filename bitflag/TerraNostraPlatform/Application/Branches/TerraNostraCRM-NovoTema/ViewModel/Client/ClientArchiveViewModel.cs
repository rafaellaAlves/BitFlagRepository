using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Client
{
    public class ClientArchiveViewModel
    {
        public int? ClientArchiveId { get; set; }
        public int ClientId { get; set; }
        public int? ClientApplicantId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return this.CreatedDate.ToDatePtBR(); } }
        public bool IsDeleted { get; set; }
        public bool? IsImage { get; set; }
    }
}
