using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Law
{
    public class LawVerificationListViewModel
    {
        public int? LawVerificationListId { get; set; }
        public int LawId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
