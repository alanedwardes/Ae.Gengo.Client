using System.Threading;
using System.Threading.Tasks;
using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Operations;

namespace Ae.Gengo.Client
{
    /// <summary>
    /// Represents a client to access the Gengo (https://gengo.com) API.
    /// </summary>
    public interface IGengoClientV2
    {
        /// <summary>
        /// Creates a batch of translation jobs.
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns>
        Task<CreatedJobs> CreateJobs(CreateJobs jobs, CancellationToken token);
        /// <summary>
        /// Gets a quote for a batch of translation jobs.
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns>
        Task<QuotedJobs> QuoteJobs(QuoteJobs jobs, CancellationToken token);
        /// <summary>
        /// Deletes a single job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task DeleteJob(uint jobId, CancellationToken token);
        /// <summary>
        /// Gets a single translation job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<SingleJob> GetJob(uint jobId, CancellationToken token);
        /// <summary>
        /// Get a list of jobs by IDs.
        /// </summary>
        /// <param name="jobIds"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<CreatedJobsByIds> GetJobsByIds(uint[] jobIds, CancellationToken token);
        /// <summary>
        /// Gets a set of job summary objects.
        /// </summary>
        /// <param name="getJobs"></param>
        /// <returns></returns>
        Task<CreatedJobSummary[]> GetJobsPage(GetJobs getJobs, CancellationToken token);
        /// <summary>
        /// Page through all jobs on the account. Very expensive operation.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<CreatedJob[]> GetAllJobs(CancellationToken token);
        /// <summary>
        /// Page through all jobs on the account. Very expensive operation.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<CreatedJob[]> GetAllJobs(JobStatus? status, CancellationToken token);
        /// <summary>
        /// Gets language pairs from the service.
        /// </summary>
        /// <returns></returns>
        Task<LanguagePair[]> GetLanguagePairs(CancellationToken token);
        /// <summary>
        /// Gets information about the current account.
        /// </summary>
        /// <returns></returns>
        Task<MeResponse> GetMe(CancellationToken token);
    }
}