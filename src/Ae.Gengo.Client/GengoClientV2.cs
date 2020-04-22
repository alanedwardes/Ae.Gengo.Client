using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Internal;
using Ae.Gengo.Client.Operations;
using System.Collections.Specialized;
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
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<CreatedJobs> CreateJobs(CreateJobs jobs, CancellationToken token)
        {
            var response = await _httpClient.PostAsync("v2/translate/jobs", jobs.Serialize(), token);
            return await response.Deserialize<CreatedJobs>();
        }

        /// <inheritdoc/>
        public async Task<QuotedJobs> QuoteJobs(QuoteJobs jobs, CancellationToken token)
        {
            var response = await _httpClient.PostAsync("v2/translate/service/quote", jobs.Serialize(), token);
            return await response.Deserialize<QuotedJobs>();
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
        public async Task<OrderById> GetOrderById(uint orderId, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"v2/translate/order/{orderId}", CancellationToken.None);
            return await response.Deserialize<OrderById>();
        }

        /// <inheritdoc/>
        public async Task<CreatedJobsByIds> GetJobsByIds(uint[] jobIds, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"v2/translate/jobs/{string.Join(",", jobIds)}", token);
            return await response.Deserialize<CreatedJobsByIds>();
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
        public async Task<AccountInformation> GetAccountInformation(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/account/me", token);
            return await response.Deserialize<AccountInformation>();
        }

        /// <inheritdoc/>
        public async Task<AccountBalance> GetAccountBalance(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/account/balance", token);
            return await response.Deserialize<AccountBalance>();
        }

        /// <inheritdoc/>
        public async Task<AccountStats> GetAccountStats(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/account/stats", token);
            return await response.Deserialize<AccountStats>();
        }

        /// <inheritdoc/>
        public async Task<PreferredTranslator[]> GetPreferredTranslators(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/account/preferred_translators", token);
            return await response.Deserialize<PreferredTranslator[]>();
        }

        /// <inheritdoc/>
        public async Task<Language[]> GetLanguages(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v2/translate/service/languages", token);
            return await response.Deserialize<Language[]>();
        }
    }
}
