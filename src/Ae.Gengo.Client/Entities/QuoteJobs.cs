using System.Linq;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class QuoteJobs : JobDictionaryContainer<JobPrimitive>
    {
        public static implicit operator QuoteJobs(CreateJobs create) => new QuoteJobs { Jobs = create.Jobs.ToDictionary(x => x.Key, y => (JobPrimitive)y.Value) };
    }
}
