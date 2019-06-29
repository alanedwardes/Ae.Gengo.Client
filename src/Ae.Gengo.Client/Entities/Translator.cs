using System;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class Translator
    {
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        [DataMember(Name = "last_login")]
        public DateTimeOffset? LastLogin { get; set; }
    }
}
