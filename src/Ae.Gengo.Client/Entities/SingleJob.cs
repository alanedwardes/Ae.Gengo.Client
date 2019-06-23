using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class SingleJob
    {
        [DataMember(Name = "job")]
        public CreatedJob Job { get; set; }
    }
}
