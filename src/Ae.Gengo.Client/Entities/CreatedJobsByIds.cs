using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreatedJobsByIds
    {
        [DataMember(Name = "jobs")]
        public CreatedJob[] Jobs { get; set; }
    }
}
