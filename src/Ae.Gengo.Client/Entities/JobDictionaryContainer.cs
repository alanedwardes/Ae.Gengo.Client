using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public abstract class JobDictionaryContainer<TJobType>
    {
        [DataMember(Name = "jobs")]
        public IDictionary<string, TJobType> Jobs { get; set; }
    }
}
