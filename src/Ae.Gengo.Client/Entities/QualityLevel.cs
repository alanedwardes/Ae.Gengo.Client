using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    /// <summary>
    /// Quality level (“standard” or “pro”)
    /// </summary>
    [DataContract]
    public enum QualityLevel
    {
        [EnumMember(Value = "machine")]
        Machine,
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "pro")]
        Pro
    }
}
