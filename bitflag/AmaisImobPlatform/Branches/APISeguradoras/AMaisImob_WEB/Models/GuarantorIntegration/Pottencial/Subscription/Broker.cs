using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Subscription
{
    public class Broker
    {
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }
    }

}
