using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.GuarantorIntegration.Pottencial.Subscription
{
    public class SubscriptionRequest
    {
        [JsonPropertyName("policyOwner")]
        public PolicyOwner PolicyOwner { get; set; }

        [JsonPropertyName("broker")]
        public Broker Broker { get; set; }

        [JsonPropertyName("tenants")]
        public List<Tenant> Tenants { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("expenses")]
        public Expenses Expenses { get; set; }

        [JsonPropertyName("planType")]
        public string PlanType { get; set; }

        [JsonPropertyName("rentalType")]
        public string RentalType { get; set; }

        [JsonPropertyName("callbackUrl")]
        public string CallbackUrl { get; set; }

        public SubscriptionRequest()
        {
            this.PolicyOwner = new PolicyOwner();
            this.Broker = new Broker();
            this.Tenants = new List<Tenant>();
            this.Address = new Address();
            this.Expenses = new Expenses();
        }
    }
}
