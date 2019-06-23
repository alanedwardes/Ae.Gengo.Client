using Ae.Gengo.Client.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Gengo.Client
{
    /// <summary>
    /// Provides authentication services around the Gengo API, including request and response wrapping / unwrapping.
    /// </summary>
    public sealed class GengoHandlerV2 : DelegatingHandler
    {
        private readonly IGengoConfigV2 _config;

        /// <summary>
        /// Create a new instance of the <see cref="GengoHandlerV2"/> with the specified <see cref="IGengoConfigV2"/>.
        /// </summary>
        /// <param name="config"></param>
        public GengoHandlerV2(IGengoConfigV2 config)
        {
            _config = config;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Accept", "application/json");

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

            string signature;
            using (HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(_config.Secret)))
            {
                signature = string.Concat(hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp)).Select(x => x.ToString("x2")));
            }

            if (request.Method == HttpMethod.Get)
            {
                var separator = string.IsNullOrWhiteSpace(request.RequestUri.Query) ? '?' : '&';

                var uriBuilder = new UriBuilder(request.RequestUri);
                uriBuilder.Query += $"{separator}api_key={_config.Key}&api_sig={signature}&ts={timestamp}";

                request.RequestUri = uriBuilder.Uri;
            }

            if (request.Method == HttpMethod.Post && request.Content is StringContent)
            {
                var json = await request.Content.ReadAsStringAsync();
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"api_key", _config.Key},
                    {"api_sig", signature},
                    {"ts", timestamp},
                    {"data", json}
                });
            }

            var response = await base.SendAsync(request, cancellationToken);

            var responseContent = await response.Content.ReadAsStringAsync();

            var wrappedResponse = JsonConvert.DeserializeObject<WrappedResponse>(responseContent);
            if (wrappedResponse.Status != OperationStatus.Ok)
            {
                throw new Exception($"Exception from API: {JsonConvert.SerializeObject(wrappedResponse.Error)}");
            }

            response.Content = new StringContent(JsonConvert.SerializeObject(wrappedResponse.Response), Encoding.UTF8);

            return response;
        }
    }
}
