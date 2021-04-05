using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class InsurancePolicyListViewModel
    {
        public int? InsurancePolicyId { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public int? CompanyId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public string _StartDate { get { return StartDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public DateTime? EndDate { get; set; }
        public string _EndDate { get { return EndDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public DateTime? ModifiedDate { get; set; }
        public string _ModifiedDate { get { return ModifiedDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public DateTime? StartRegisteredDate { get; set; }
        public string _StartRegisteredDate { get { return StartRegisteredDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public DateTime? EndRegisteredDate { get; set; }
        public string _EndRegisteredDate { get { return EndRegisteredDate.ToDatePtBR(); } set { StartDate = value.FromDatePtBR(); } }
        public bool IsDeleted { get; set; }
        public string ProductName { get; set; }
        public string CorretoraName { get; set; }
    }
}
