using Ae.Gengo.Client.Entities;
using Ae.Gengo.Client.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
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
        private readonly HashAlgorithm _hasher;

        /// <summary>
        /// Create a new instance of the <see cref="GengoHandlerV2"/> with the specified <see cref="IGengoConfigV2"/>.
        /// </summary>
        /// <param name="config"></param>
        public GengoHandlerV2(IGengoConfigV2 config)
        {
            _config = config;
            _hasher = new HMACSHA1(Encoding.UTF8.GetBytes(config.Secret));
        }

        protected override void Dispose(bool disposing)
        {
            _hasher?.Dispose();
            base.Dispose(disposing);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            // Gengo authentication - https://developers.gengo.com/v2/authentication/
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string signature = string.Concat(_hasher.ComputeHash(Encoding.UTF8.GetBytes(timestamp)).Select(x => x.ToString("x2")));

            // Used for both POST and GET requests
            var payload = new NameValueCollection
            {
                {"api_key", _config.Key},
                {"api_sig", signature},
                {"ts", timestamp}
            };

            // Pick whether to use query string or form data authentication
            bool hasStringBody = request.Content is StringContent && request.Content != null;
            if (hasStringBody)
            {
                // We can't use FormUrlEncodedContent because it breaks if the content gets too big
                // https://stackoverflow.com/questions/38440631/httpclient-the-uri-string-is-too-long
                payload.Add("data", await request.Content.ReadAsStringAsync());
                request.Content = new StringContent(payload.ToFormData(), null, "application/x-www-form-urlencoded");
            }
            else
            {
                request.RequestUri = request.RequestUri.AddQueryItems(payload);
            }

            var response = await base.SendAsync(request, token);

            var wrappedResponse = JsonConvert.DeserializeObject<WrappedResponse>(await response.Content.ReadAsStringAsync());
            if (wrappedResponse.Status != OperationStatus.Ok)
            {
                throw new GengoExceptionV2(wrappedResponse.Error);
            }

            response.Content = new StringContent(JsonConvert.SerializeObject(wrappedResponse.Response), Encoding.UTF8);

            return response;
        }
    }
}
