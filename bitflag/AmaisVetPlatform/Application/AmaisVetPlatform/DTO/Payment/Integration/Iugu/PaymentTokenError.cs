using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Payment.Integration.Iugu
{
    public class PaymentTokenError
    {
        public List<string> Number { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public List<string> FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public List<string> LastName { get; set; }

        public List<string> Month { get; set; }

        public List<string> Year { get; set; }

        [JsonProperty(PropertyName = "verification_value")]
        public List<string> VerificationValue { get; set; }
    }
}
