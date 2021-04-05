using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyLogo
    {
        public int? CompanyLogoId { get; set; }
        public int CompanyId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
    }
}
