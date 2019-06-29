using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class PreferredTranslator : JobPrimitive
    {
        [DataMember(Name = "translators")]
        public Translator[] Translators { get; set; }
    }
}
