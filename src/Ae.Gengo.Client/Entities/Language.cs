using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class Language
    {
        [DataMember(Name = "unit_type")]
        public string UnitType { get; set; }

        [DataMember(Name = "lc")]
        public string LanguageCode { get; set; }

        [DataMember(Name = "localized_name")]
        public string LanguageNameLocalized { get; set; }

        [DataMember(Name = "language")]
        public string LanguageName { get; set; }
    }
}
