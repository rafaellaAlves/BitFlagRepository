using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LawAttachment : Shared.BaseEntity
    {
        public int LawAttachmentId { get; set; }
        public int LawId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Lei na íntegra
        /// </summary>
        public bool FullLaw { get; set; }
    }
}
