using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class CreateJobs
    {
        [DataMember(Name = "jobs")]
        public IDictionary<string, CreateJob> Jobs { get; set; }
    }
}
