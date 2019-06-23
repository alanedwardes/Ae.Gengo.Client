using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public enum OperationStatus
    {
        [EnumMember(Value = "ok")]
        Ok,
        [EnumMember(Value = "error")]
        Error
    }
}
