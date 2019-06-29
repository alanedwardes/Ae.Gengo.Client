using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class AccountBalance
    {
        [DataMember(Name = "credits")]
        public float Credits { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
