using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientArchive
    {
        public int ClientArchiveId { get; set; }
        public int ClientId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ClientApplicantId { get; set; }
    }
}
