using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class Order
    {
        [DataMember(Name = "order_id")]
        public uint OrderId { get; set; }
        [DataMember(Name = "total_credits")]
        public decimal TotalCredits { get; set; }
        [DataMember(Name = "total_units")]
        public uint TotalUnits { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "jobs_queued")]
        public uint JobsQueued { get; set; }
        [DataMember(Name = "total_jobs")]
        public uint TotalJobs { get; set; }
        [DataMember(Name = "jobs_available")]
        public uint[] JobsAvailable { get; set; } = new uint[0];
        [DataMember(Name = "jobs_pending")]
        public uint[] JobsPending { get; set; } = new uint[0];
        [DataMember(Name = "jobs_reviewable")]
        public uint[] JobsReviewable { get; set; } = new uint[0];
        [DataMember(Name = "jobs_approved")]
        public uint[] JobsApproved { get; set; } = new uint[0];
        [DataMember(Name = "jobs_revising")]
        public uint[] JobsRevising { get; set; } = new uint[0];
        [DataMember(Name = "jobs_cancelled")]
        public uint[] JobsCancelled { get; set; } = new uint[0];
        [DataMember(Name = "jobs_rejected")]
        public uint[] JobsRejected { get; set; } = new uint[0];
        [DataMember(Name = "jobs_held")]
        public uint[] JobsHeld { get; set; } = new uint[0];
    }
}
