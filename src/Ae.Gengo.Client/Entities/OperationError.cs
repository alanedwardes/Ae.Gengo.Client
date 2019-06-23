using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class OperationError
    {
        [DataMember(Name = "code")]
        public uint Code { get; set; }

        [DataMember(Name = "msg")]
        public string Message { get; set; }
    }
}
