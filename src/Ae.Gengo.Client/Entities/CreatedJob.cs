using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreatedJob : Job
    {
        /// <summary>
        /// Order ID
        /// </summary>
        [DataMember(Name = "job_id")]
        public uint JobId { get; set; }

        /// <summary>
        /// Order ID
        /// </summary>
        [DataMember(Name = "order_id")]
        public uint OrderId { get; set; }

        /// <summary>
        /// Translated body of text (if available).
        /// </summary>
        [DataMember(Name = "body_tgt")]
        public string TargetBody { get; set; }

        /// <summary>
        /// Count of source language units (either words or characters depending on source language)
        /// </summary>
        [DataMember(Name = "unit_count")]
        public int UnitCount { get; set; }

        /// <summary>
        /// Credit price based on language pair and tier.
        /// </summary>
        [DataMember(Name = "credits")]
        public float Credits { get; set; }

        /// <summary>
        /// Current status of job
        /// </summary>
        [DataMember(Name = "status")]
        public JobStatus Status { get; set; }

        /// <summary>
        /// Estimated seconds until completion.
        /// </summary>
        [DataMember(Name = "eta")]
        public TimeSpan? Eta { get; set; }

        /// <summary>
        /// Unix Timestamp for when this job was submitted (by you - not by the translator).
        /// </summary>
        [DataMember(Name = "ctime")]
        public DateTimeOffset SubmitTime { get; set; }

        /// <summary>
        /// The full URL of source file (returned with the callback).
        /// </summary>
        [DataMember(Name = "file_url_src", IsRequired = false)]
        public string SourceFileUrl { get; set; }

        /// <summary>
        /// The full URL of translated file (returned with the callback).
        /// </summary>
        [DataMember(Name = "file_url_tgt", IsRequired = false)]
        public string TargetFileUrl { get; set; }
    }
}
