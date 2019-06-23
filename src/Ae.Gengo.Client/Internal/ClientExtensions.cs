using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ae.Gengo.Client.Internal
{
    internal static class ClientExtensions
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

        public static string ToQueryString(this NameValueCollection query)
        {
            if (query.Count == 0)
            {
                return string.Empty;
            }

            var items = query.AllKeys.SelectMany(key => query.GetValues(key).Select(value => $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}"));

            return "?" + string.Join("&", items);
        }
    }
}
