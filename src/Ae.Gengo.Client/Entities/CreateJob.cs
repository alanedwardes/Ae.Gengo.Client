using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    /// <summary>
    /// Job Payload - for submissions
    /// </summary>
    [DataContract]
    public sealed class CreateJob : Job
    {
        /// <summary>
        /// Job type. Either ‘text’ (default) or ‘file’. Use ‘file’ for ordering file jobs via the API using job identifiers from the file quote function
        /// </summary>
        [DataMember(Name = "type")]
        public JobType Type { get; set; }

        /// <summary>
        /// The identifier returned as a response from the file quote method (e.g. identifier = ‘2ea3a2dbea3be97375ceaf03200fb184’)
        /// </summary>
        [DataMember(Name = "identifier")]
        public Guid? FileId { get; set; }

        /// <summary>
        /// Id of the glossary that you want to use
        /// </summary>
        [DataMember(Name = "glossary_id")]
        public int? GlossaryId { get; set; }

        /// <summary>
        /// Whether or not to override duplicate detection and force a new translation. (always returns a fresh translation, even if the term has been translated before)
        /// </summary>
        [DataMember(Name = "force", IsRequired = false)]
        public bool? Force { get; set; }

        /// <summary>
        /// Instructions or comments for translator to consider when translating. It is strongly encouraged to provide a detailed comment for the translator
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// External files providing extra context to a job
        /// </summary>
        [DataMember(Name = "attachments")]
        public JobAttachment[] Attchments { get; set; }

        /// <summary>
        /// Describing the purpose of the translation ex| “Personal use/Business/Online content/Web or app localization/Other...
        /// </summary>
        [DataMember(Name = "purpose", IsRequired = false)]
        public string Purpose { get; set; }

        /// <summary>
        /// Describing the tone for the translation ex| “Informal/Friendly/Business/Formal/Other...
        /// </summary>
        [DataMember(Name = "tone", IsRequired = false)]
        public string Tone { get; set; }

        /// <summary>
        /// Whether to use translators from the preferred translators list associated with the account
        /// </summary>
        [DataMember(Name = "use_preferred")]
        public bool? UsePreferred { get; set; }

        /// <summary>
        /// Expresses character limit of translation. Should always be greater than 0
        /// </summary>
        [DataMember(Name = "max_chars")]
        public int? MaxCharacters { get; set; }

        /// <summary>
        /// By default, jobs from the same language pair and tier will be grouped within a single collection which means that only one translator for this language pair and tier will be able to pick up the whole collection. If as_group is set to 0 each job can be picked up by a different translator.
        /// </summary>
        [DataMember(Name = "as_group")]
        public bool? AsGroup { get; set; }
    }
}
