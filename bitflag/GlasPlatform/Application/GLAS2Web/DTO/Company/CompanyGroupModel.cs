using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyGroupModel
    {
        public int CompanyGroupId { get; set; }
        public int CompanyId { get; set; }
        public int? GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
    }
}
