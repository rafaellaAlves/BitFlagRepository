using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class SeasonViewModel
    {
        public int? SeasonId { get; set; }
        public string Name { get; set; }
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
            get
            {
                return EndDate.HasValue ? EndDate.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    EndDate = o;
                else
                    EndDate = null;
            }
        }
        public bool IsDeleted { get; set; }
    }
}
