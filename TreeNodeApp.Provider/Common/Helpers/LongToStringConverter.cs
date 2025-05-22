using System.Text.Json.Serialization;
using System.Text.Json;

namespace TreeNodeApp.Provider.Service.Interface.Common.Helpers
{
    public class LongToStringConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), out long value))
            {
                return value;
            }
            return reader.GetInt64();
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
