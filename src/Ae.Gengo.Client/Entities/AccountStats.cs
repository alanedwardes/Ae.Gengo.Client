using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class AccountStats
    {
        [DataMember(Name = "credits_spent")]
        public decimal CreditsSpent { get; set; }
        [DataMember(Name = "user_since")]
        public DateTimeOffset UserSince { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "billing_type")]
        public string BillingType { get; set; }
        [DataMember(Name = "customer_type")]
        public string CustomerType { get; set; }
    }
}
