using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ae.Gengo.Client.Internal
{
    internal static class HttpResponseExtensions
    {
        private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            Converters = new JsonConverter[] { new StringEnumConverter(), new BoolConverter() },
            NullValueHandling = NullValueHandling.Ignore
        };

        public static StringContent Serialize(this object payload)
        {
            var json = JsonConvert.SerializeObject(payload, serializerSettings);
            return new StringContent(json, Encoding.UTF8);
        }

        public static async Task<TResponse> Deserialize<TResponse>(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content, serializerSettings);
        }
    }
}
