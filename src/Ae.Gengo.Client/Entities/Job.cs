using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public abstract class Job : JobPrimitive
    {
        /// <summary>
        /// Original body of text (to be translated)
        /// </summary>
        [DataMember(Name = "body_src")]
        public string SourceBody { get; set; }

        /// <summary>
        /// The full URL to which we will send system updates (completed jobs, new comments, etc.)
        /// </summary>
        [DataMember(Name = "callback_url", IsRequired = false)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Whether to automatically approve jobs after they’ve been translated. Default is false.
        /// If false, completed jobs will await review and approval by customer for 72 hours
        /// </summary>
        [DataMember(Name = "auto_approve")]
        public bool? AutoApprove { get; set; }

        /// <summary>
        /// Up to 1K of storage for client-specific data that may be helpful for you to have mapped to this job
        /// </summary>
        [DataMember(Name = "custom_data", IsRequired = false)]
        public string CustomData { get; set; }

        /// <summary>
        /// Plus service
        /// </summary>
        [DataMember(Name = "services")]
        public TranslationServices[] Services { get; set; }

        /// <summary>
        /// Job title. For internally storing, can be generic
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// The position of the job in a group of jobs. Starts at 1. When the job group is displayed to translators, this ensures that ordering is maintained.
        /// </summary>
        [DataMember(Name = "position")]
        public int? Position { get; set; }
    }
}
