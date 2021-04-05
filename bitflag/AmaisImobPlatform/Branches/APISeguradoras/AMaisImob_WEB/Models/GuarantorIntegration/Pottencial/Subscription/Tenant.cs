using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Subscription
{
    public class Tenant
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("sourceIncome")]
        public string SourceIncome { get; set; }

        [JsonPropertyName("income")]
        public double Income { get; set; }

        [JsonPropertyName("resident")]
        public bool Resident { get; set; }
    }
}
