using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
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
        private static readonly JsonSerializerSettings SERIALIZER_SETTINGS = new JsonSerializerSettings
        {
            Converters = new JsonConverter[] { new StringEnumConverter(), new BoolConverter(), new UnixDateTimeConverter(), new TimeSpanConverter() },
            NullValueHandling = NullValueHandling.Ignore
        };

        public static StringContent Serialize(this object payload)
        {
            var json = JsonConvert.SerializeObject(payload, SERIALIZER_SETTINGS);
            return new StringContent(json, Encoding.UTF8);
        }

        public static async Task<TResponse> Deserialize<TResponse>(this HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content, SERIALIZER_SETTINGS);
        }

        public static Uri AddQueryItems(this Uri uri, NameValueCollection queryItems)
        {
            var builder = new UriBuilder(uri);
            var separator = string.IsNullOrWhiteSpace(builder.Query) ? "?" : "&";
            builder.Query += separator + queryItems.ToFormData();
            return builder.Uri;
        }

        public static string ToQueryString(this NameValueCollection query)
        {
            return query.Count == 0 ? string.Empty : "?" + query.ToFormData();
        }

        public static string ToFormData(this NameValueCollection formData)
        {
            if (formData.Count == 0)
            {
                return string.Empty;
            }

            return string.Join("&", formData.AllKeys.SelectMany(key => formData.GetValues(key).Select(value => $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}")));
        }
    }
}
