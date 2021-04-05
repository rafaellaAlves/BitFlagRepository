using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.IUGU
{

    public class Subscription
    {
        public List<SubscriptionItem> Items { get; set; }
    }
    public class SubscriptionItem
    {
        public string Id { get; set; }
        public string Customer_Id { get; set; }
        public bool Suspended { get; set; }
        public bool Active { get; set; }
        public int Price_Cents { get; set; }
        public DateTime? Expires_At { get; set; }
    }
}
