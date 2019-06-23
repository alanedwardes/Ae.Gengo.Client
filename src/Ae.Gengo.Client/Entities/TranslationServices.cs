using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public enum TranslationServices
    {
        [EnumMember(Value = "translation")]
        Translation,
        [EnumMember(Value = "edit")]
        Edit
    }
}
