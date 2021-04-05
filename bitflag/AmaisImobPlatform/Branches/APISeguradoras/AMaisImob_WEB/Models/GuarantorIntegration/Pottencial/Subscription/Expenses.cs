using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Subscription
{
    public class Expenses
    {
        [JsonPropertyName("rentAmount")]
        public double RentAmount { get; set; }

        [JsonPropertyName("condominium")]
        public double Condominium { get; set; }

        [JsonPropertyName("iptuAmount")]
        public double IptuAmount { get; set; }

        [JsonPropertyName("waterBill")]
        public double WaterBill { get; set; }

        [JsonPropertyName("electricalBill")]
        public double ElectricalBill { get; set; }

        [JsonPropertyName("gasBill")]
        public double GasBill { get; set; }

        [JsonPropertyName("airConditionerBill")]
        public double AirConditionerBill { get; set; }

        [JsonPropertyName("promotionFund")]
        public double PromotionFund { get; set; }
    }

}
