using Newtonsoft.Json;
using System;

namespace Ae.Gengo.Client.Internal
{
    internal sealed class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            double numericValue = double.Parse(reader.Value.ToString());
            if (objectType == typeof(TimeSpan?) && numericValue < 0f)
            {
                return null;
            }

            return TimeSpan.FromSeconds(numericValue);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }
    }
}
