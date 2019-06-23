using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class WrappedResponse
    {
        [DataMember(Name = "opstat")]
        public OperationStatus Status { get; set; }
        [DataMember(Name = "response")]
        public object Response { get; set; }
        [DataMember(Name = "err", IsRequired = false)]
        public OperationError Error { get; set; }
    }
}
