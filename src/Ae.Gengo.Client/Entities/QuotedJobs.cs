using System.Linq;
using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    [DataContract]
    public sealed class QuotedJobs : JobDictionaryContainer<JobQuote>
    {
        public float TotalCredits => Jobs.Values.Sum(x => x.Credits);
    }
}
