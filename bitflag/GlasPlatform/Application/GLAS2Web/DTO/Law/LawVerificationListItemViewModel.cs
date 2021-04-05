using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utils;

namespace DTO.Law
{
    public class LawVerificationListItemViewModel
    {
        public int? LawVerificationListItemId { get; set; }
        public int LawVerificationListId { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
    }
}
