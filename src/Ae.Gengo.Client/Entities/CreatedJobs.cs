using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreatedJobs : JobDictionaryContainer<CreatedJob[]>
    {
        [DataMember(Name = "order_id")]
        public uint OrderId { get; set; }

        [DataMember(Name = "job_count")]
        public int JobCount { get; set; }

        [DataMember(Name = "credits_used")]
        public float CreditsUsed { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
