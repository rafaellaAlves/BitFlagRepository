using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Admin
{
    public class CampaignViewModel
    {
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public int QuantityMonth { get; set; }
        public int StateCRMV { get; set; }
        public int Limit { get; set; }
        public int CampaignType { get; set; }
        public int FirstIndication { get; set; }
        public int SecondIndication { get; set; }
        public DateTime StartCampaign { get; set; }
        public DateTime FinishCampaign { get; set; }
        public DateTime StartDiscount { get; set; }
        public DateTime FinishDiscount { get; set; }

    }
}
