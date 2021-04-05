using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class InsurancePolicyViewModel
    {
        public int? InsurancePolicyId { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public int? CompanyId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public string _StartDate
        {
            get
            {
                return StartDate.HasValue ? StartDate.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    StartDate = o;
                else
                    StartDate = null;
            }
        }
        public DateTime? EndDate { get; set; }
        public string _EndDate
        {
            get { return EndDate.HasValue ? EndDate.Value.ToString("dd/MM/yyyy") : ""; }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    EndDate = o;
                else
                    EndDate = null;
            }
        }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate
        {
            get { return CreatedDate.HasValue ? CreatedDate.Value.ToString("dd/MM/yyyy") : ""; }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    CreatedDate = o;
                else
                    CreatedDate = null;
            }
        }
        public DateTime? ModifiedDate { get; set; }
        public string _ModifiedDate
        {
            get { return ModifiedDate.HasValue ? ModifiedDate.Value.ToString("dd/MM/yyyy") : ""; }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    ModifiedDate = o;
                else
                    ModifiedDate = null;
            }
        }
        public DateTime? StartRegisteredDate { get; set; }
        public string _StartRegisteredDate
        {
            get { return StartRegisteredDate.HasValue ? StartRegisteredDate.Value.ToString("dd/MM/yyyy") : ""; }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    StartRegisteredDate = o;
                else
                    StartRegisteredDate = null;
            }
        }
        public DateTime? EndRegisteredDate { get; set; }
        public string _EndRegisteredDate
        {
            get { return EndRegisteredDate.HasValue ? EndRegisteredDate.Value.ToString("dd/MM/yyyy") : ""; }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    EndRegisteredDate = o;
                else
                    EndRegisteredDate = null;
            }
        }
        public bool IsDeleted { get; set; }
    }
}
