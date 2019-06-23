using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Internal;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ae.Gengo.Client
{
    /// <inheritdoc/>
    public sealed class GengoClientV2 : IGengoClientV2
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Create a new <see cref="GengoClientV2"/> with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient"></param>
        public GengoClientV2(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<CreatedJobs> CreateJobs(CreateJobs jobs)
        {
            var response = await httpClient.PostAsync("v2/translate/jobs", jobs.Serialize());
            return await response.Deserialize<CreatedJobs>();
        }

        /// <inheritdoc/>
        public async Task<CreatedJobSummary[]> GetJobs()
        {
            var response = await httpClient.GetAsync("v2/translate/jobs");
            return await response.Deserialize<CreatedJobSummary[]>();
        }

        /// <inheritdoc/>
        public async Task<LanguagePair[]> GetLanguagePairs()
        {
            var response = await httpClient.GetAsync("v2/translate/service/language_pairs");
            return await response.Deserialize<LanguagePair[]>();
        }

        /// <inheritdoc/>
        public async Task<SingleJob> GetJob(int jobId)
        {
            var response = await httpClient.GetAsync($"v2/translate/job/{jobId}");
            return await response.Deserialize<SingleJob>();
        }

        /// <inheritdoc/>
        public async Task<MeResponse> GetMe()
        {
            var response = await httpClient.GetAsync("v2/account/me");
            return await response.Deserialize<MeResponse>();
        }
    }
}
