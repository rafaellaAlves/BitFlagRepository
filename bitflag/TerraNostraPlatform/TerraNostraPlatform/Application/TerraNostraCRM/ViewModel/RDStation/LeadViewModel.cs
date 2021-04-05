using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.RDStation
{
    public class LeadViewModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string job_title { get; set; }
        public string bio { get; set; }
        public string public_url { get; set; }
        public DateTime created_at { get; set; }
        public bool opportunity { get; set; }
        public int number_conversions { get; set; }
        public string user { get; set; }
        public ConversionViewModel first_conversion { get; set; }
        public ConversionViewModel last_conversion { get; set; }
        public Dictionary<string, object> custom_fields { get; set; }
        public string website { get; set; }
        public string personal_phone { get; set; }
        public string mobile_phone { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public List<string> tags { get; set; }
        public string lead_stage { get; set; }
        public DateTime? last_marked_opportunity_date { get; set; }
        public string uuid { get; set; }
        public string fit_score { get; set; }
        public int interest { get; set; }
    }
}
