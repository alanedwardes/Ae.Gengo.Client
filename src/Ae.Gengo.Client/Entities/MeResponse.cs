using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class MeResponse
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }
        [DataMember(Name = "display_name")]
        public string DisplayName { get; set; }
        [DataMember(Name = "language_code")]
        public string LanguageCode { get; set; }
    }
}
