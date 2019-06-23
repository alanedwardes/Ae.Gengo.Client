using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class WrappedRequest
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
