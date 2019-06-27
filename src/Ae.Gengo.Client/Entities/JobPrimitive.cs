using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public class JobPrimitive
    {
        /// <summary>
        /// Source language code. Gengo uses IETF codes to define languages and language pairs
        /// </summary>
        [DataMember(Name = "lc_src")]
        public string SourceLanguageCode { get; set; }

        /// <summary>
        /// Target language code
        /// </summary>
        [DataMember(Name = "lc_tgt")]
        public string TargetLanguageCode { get; set; }

        /// <summary>
        /// Quality level (“standard” or “pro”)
        /// </summary>
        [DataMember(Name = "tier")]
        public QualityLevel Tier { get; set; }
    }
}
