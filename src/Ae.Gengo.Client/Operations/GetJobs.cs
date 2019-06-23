using Ae.Gengo.Client.Entities;
using System;

namespace Ae.Gengo.Client.Operations
{
    /// <summary>
    /// Represents an operation to get multiple jobs.
    /// </summary>
    public sealed class GetJobs
    {
        /// <summary>
        /// Filter by status “available”, “pending”, “reviewable”, “approved”, “rejected”, or “canceled”
        /// </summary>
        public JobStatus? Status { get; set; }
        /// <summary>
        /// Epoch timestamp from which to filter submitted jobs
        /// </summary>
        public DateTimeOffset? After { get; set; }
        /// <summary>
        /// Defaults to 10 (maximum 200)
        /// </summary>
        public uint? Count { get; set; }
    }
}
