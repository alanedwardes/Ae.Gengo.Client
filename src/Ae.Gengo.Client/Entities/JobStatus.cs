using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    /// <summary>
    /// Each submitted job goes through a series of statuses before delivery. At any time when you request the contents of a job, it will be in one of the following states:
    /// </summary>
    [DataContract]
    public enum JobStatus
    {
        /// <summary>
        /// The jobs are being processed by our system but are not currently visible to our translators.
        /// </summary>
        [EnumMember(Value = "queued")]
        Queued,
        /// <summary>
        /// The jobs are now on our system and waiting for a translator to begin work.
        /// </summary>
        [EnumMember(Value = "available")]
        Available,
        /// <summary>
        /// A translator is now working on the content, but has not finished.
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,
        /// <summary>
        /// Unless the parameter “auto-approve” is set to 1, this is the status that indicates the translation has been finished by our team.
        /// </summary>
        [EnumMember(Value = "reviewable")]
        Reviewable,
        /// <summary>
        /// The job has been approved by the customer and the translator has been paid for their work (if “auto-approve” is set to 1, this happens as soon the content is submitted by the translator)
        /// </summary>
        [EnumMember(Value = "approved")]
        Approved,
        /// <summary>
        /// The customer has requested that some changes are made to the translation.
        /// </summary>
        [EnumMember(Value = "revising")]
        Revising,
        /// <summary>
        /// The customer has rejected the completed job and our support team has been triggered to follow up on the job.
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected,
        /// <summary>
        /// The job has been canceled before the translator has started working on the content.
        /// </summary>
        [EnumMember(Value = "cancelled")]
        Cancelled,
        /// <summary>
        /// The job has been temporarily held by Gengo customer support for review.
        /// </summary>
        [EnumMember(Value = "hold")]
        Hold,
        /// <summary>
        /// The job has been deleted.
        /// </summary>
        [EnumMember(Value = "deleted")]
        Deleted
    }
}
