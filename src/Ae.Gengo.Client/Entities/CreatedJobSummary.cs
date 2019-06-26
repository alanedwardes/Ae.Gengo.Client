using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreatedJobSummary
    {
        /// <summary>
        /// Job ID
        /// </summary>
        [DataMember(Name = "job_id")]
        public uint JobId { get; set; }

        /// <summary>
        /// Unix Timestamp for when this job was submitted (by you - not by the translator).
        /// </summary>
        [DataMember(Name = "ctime")]
        public DateTimeOffset SubmitTime { get; set; }
    }
}
