using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Internal;
using Ae.Gengo.Client.Operations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Gengo.Client
{
    /// <inheritdoc/>
    public sealed class GengoClientV2 : IGengoClientV2
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Create a new <see cref="GengoClientV2"/> with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient"></param>
        public GengoClientV2(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<CreatedJobs> CreateJobs(CreateJobs jobs, CancellationToken token)
        {
            var response = await _httpClient.PostAsync("v2/translate/jobs", jobs.Serialize(), token);
            return await response.Deserialize<CreatedJobs>();
        }

        /// <inheritdoc/>
        public async Task<CreatedJobSummary[]> GetJobsPage(GetJobs getJobs, CancellationToken token)
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

            var response = await _httpClient.GetAsync($"v2/translate/jobs{query.ToQueryString()}", token);
            return await response.Deserialize<CreatedJobSummary[]>();
        }

        /// <inheritdoc/>
        public async Task<CreatedJobsByIds> GetJobsByIds(uint[] jobIds, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"v2/translate/jobs/{string.Join(",", jobIds)}", token);
            return await response.Deserialize<CreatedJobsByIds>();
        }

        /// <inheritdoc/>
        public async Task<CreatedJob[]> GetAllJobs(CancellationToken token)
        {
            return await GetAllJobs(null, token);
        }

        /// <inheritdoc/>
        public async Task<CreatedJob[]> GetAllJobs(JobStatus? status, CancellationToken token)
        {
            // This is half of the actual size
            // since the get by IDs operation uses
            // the query string
            const int batchSize = 100;

            var jobs = new List<CreatedJob>();

            // Start when Gengo was founded
            DateTimeOffset after = new DateTime(2008, 12, 01);

            do
            {
                CreatedJobSummary[] summaries = await GetJobsPage(new GetJobs
                {
                    Count = batchSize,
                    After = after,
                    Status = status
                }, token);
                if (!summaries.Any())
                {
                    break;
                }

                var jobBatch = await GetJobsByIds(summaries.Select(x => x.JobId).ToArray(), token);
                jobs.AddRange(jobBatch.Jobs);
                after = summaries.OrderBy(x => x.SubmitTimeMarshaled).Last().SubmitTimeMarshaled;
            }
            while (true);

            return jobs.OrderBy(x => x.SubmitTimeMarshaled).ToArray();
        }

        /// <inheritdoc/>
        public async Task<LanguagePair[]> GetLanguagePairs(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/translate/service/language_pairs", token);
            return await response.Deserialize<LanguagePair[]>();
        }

        /// <inheritdoc/>
        public async Task<SingleJob> GetJob(uint jobId, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"v2/translate/job/{jobId}", token);
            return await response.Deserialize<SingleJob>();
        }

        /// <inheritdoc/>
        public async Task DeleteJob(uint jobId, CancellationToken token)
        {
            await _httpClient.DeleteAsync($"v2/translate/job/{jobId}", token);
        }

        /// <inheritdoc/>
        public async Task<MeResponse> GetMe(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/account/me", token);
            return await response.Deserialize<MeResponse>();
        }
    }
}
