using System.Threading.Tasks;
using Ae.Gengo.Client.Entities;

namespace Ae.Gengo.Client
{
    /// <summary>
    /// Represents a client to access the Gengo (https://gengo.com) API.
    /// </summary>
    internal interface IGengoClientV2
    {
        /// <summary>
        /// Creates a batch of translation jobs.
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns>
        Task<CreatedJobs> CreateJobs(CreateJobs jobs);
        /// <summary>
        /// Gets a single translation job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<SingleJob> GetJob(int jobId);
        /// <summary>
        /// Gets a set of job summary objects.
        /// </summary>
        /// <returns></returns>
        Task<CreatedJobSummary[]> GetJobs();
        /// <summary>
        /// Gets language pairs from the service.
        /// </summary>
        /// <returns></returns>
        Task<LanguagePair[]> GetLanguagePairs();
        /// <summary>
        /// Gets information about the current account.
        /// </summary>
        /// <returns></returns>
        Task<MeResponse> GetMe();
    }
}