using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public enum JobType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "file")]
        File
    }
}
