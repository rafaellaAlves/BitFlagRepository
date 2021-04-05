using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class CompanyAcceptTermsViewModel
    {
        public int CompanyAcceptTermsId { get; set; }
        public int CompanyId { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDateTimePtBR(); } }
        public int SentBy { get; set; }
    }
}
