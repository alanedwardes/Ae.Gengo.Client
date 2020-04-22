using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class OrderById
    {
        [DataMember(Name = "order")]
        public Order Order { get; set; }
    }
}
