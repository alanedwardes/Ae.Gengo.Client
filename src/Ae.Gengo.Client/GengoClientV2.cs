using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Internal;
using Ae.Gengo.Client.Operations;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
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
        public async Task<CreatedJobs> CreateJobs(CreateJobs jobs, CancellationToken token)
        {
            var response = await httpClient.PostAsync("v2/translate/jobs", jobs.Serialize(), token);
            return await response.Deserialize<CreatedJobs>();
        }

        /// <inheritdoc/>
        public Task<CreatedJobSummary[]> GetJobs(CancellationToken token) => GetJobs(new GetJobs(), token);

        /// <inheritdoc/>
        public async Task<CreatedJobSummary[]> GetJobs(GetJobs getJobs, CancellationToken token)
        {
            var query = new NameValueCollection();

            if (getJobs.Status.HasValue)
            {
                query.Add("status", getJobs.Status.Value.ToString().ToLower());
            }

            if (getJobs.After.HasValue)
            {
                query.Add("timestamp_after", getJobs.After.Value.ToUnixTimeSeconds().ToString());
            }

            if (getJobs.Count.HasValue)
            {
                query.Add("count", getJobs.Count.Value.ToString());
            }

            var response = await httpClient.GetAsync($"v2/translate/jobs{query.ToQueryString()}", token);
            return await response.Deserialize<CreatedJobSummary[]>();
        }

        /// <inheritdoc/>
        public async Task<LanguagePair[]> GetLanguagePairs(CancellationToken token)
        {
            var response = await httpClient.GetAsync("v2/translate/service/language_pairs", token);
            return await response.Deserialize<LanguagePair[]>();
        }

        /// <inheritdoc/>
        public async Task<SingleJob> GetJob(int jobId, CancellationToken token)
        {
            var response = await httpClient.GetAsync($"v2/translate/job/{jobId}", token);
            return await response.Deserialize<SingleJob>();
        }

        /// <inheritdoc/>
        public async Task<MeResponse> GetMe(CancellationToken token)
        {
            var response = await httpClient.GetAsync("v2/account/me", token);
            return await response.Deserialize<MeResponse>();
        }
    }
}
