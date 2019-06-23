using Ae.Gengo.Client.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ae.Gengo.Client.Internal
{
    internal sealed class GengoClientV2 : IGengoClientV2
    {
        private readonly HttpClient httpClient;

        public GengoClientV2(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CreatedJobs> CreateJobs(CreateJobs jobs)
        {
            var response = await httpClient.PostAsync("v2/translate/jobs", jobs.Serialize());
            return await response.Deserialize<CreatedJobs>();
        }

        public async Task<CreatedJobSummary[]> GetJobs()
        {
            var response = await httpClient.GetAsync("v2/translate/jobs");
            return await response.Deserialize<CreatedJobSummary[]>();
        }

        public async Task<LanguagePair[]> GetLanguagePairs()
        {
            var response = await httpClient.GetAsync("v2/translate/service/language_pairs");
            return await response.Deserialize<LanguagePair[]>();
        }

        public async Task<SingleJob> GetJob(int jobId)
        {
            var response = await httpClient.GetAsync($"v2/translate/job/{jobId}");
            return await response.Deserialize<SingleJob>();
        }

        public async Task<MeResponse> GetMe()
        {
            var response = await httpClient.GetAsync("v2/account/me");
            return await response.Deserialize<MeResponse>();
        }
    }
}
