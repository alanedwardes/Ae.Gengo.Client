using System.Diagnostics;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DebuggerDisplay("{SourceLanguage,nq} -> {TargetLanguage,nq} ({Tier} - {UnitPrice} {Currency,nq})")]
    [DataContract]
    public sealed class LanguagePair
    {
        [DataMember(Name = "lc_src")]
        public string SourceLanguage { get; set; }
        [DataMember(Name = "lc_tgt")]
        public string TargetLanguage { get; set; }
        [DataMember(Name = "unit_price")]
        public decimal UnitPrice { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "tier")]
        public QualityLevel Tier { get; set; }
    }
}
