using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreatedJobs
    {
        [DataMember(Name = "jobs")]
        public IDictionary<string, CreatedJob[]> Jobs { get; set; }

        [DataMember(Name = "order_id")]
        public int OrderId { get; set; }

        [DataMember(Name = "job_count")]
        public int JobCount { get; set; }

        [DataMember(Name = "credits_used")]
        public float CreditsUsed { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
