using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class JobQuote
    {
        [DataMember(Name = "unit_count")]
        public uint UnitCount { get; set; }

        [DataMember(Name = "eta")]
        public TimeSpan Eta { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "type")]
        public JobType Type { get; set; }

        [DataMember(Name = "lc_src_detected")]
        public string SourceLanguageDetected { get; set; }

        [DataMember(Name = "credits")]
        public decimal Credits { get; set; }

        [DataMember(Name = "custom_data")]
        public string CustomData { get; set; }
    }
}
