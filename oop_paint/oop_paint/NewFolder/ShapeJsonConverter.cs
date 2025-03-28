using oop_paint.shapes.oop_paint.shapes;
using oop_paint.shapes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace oop_paint.NewFolder
{
    public class ShapeJsonConverter : JsonConverter<Shape>
    {
        public override Shape Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("$type", out var typeProp))
                {
                    string typeDiscriminator = typeProp.GetString();
                    return typeDiscriminator switch
                    {
                        "circle" => JsonSerializer.Deserialize<Circle>(root.GetRawText(), options),
                        "triangle" => JsonSerializer.Deserialize<Triangle>(root.GetRawText(), options),
                        _ => throw new JsonException($"Unknown type discriminator: {typeDiscriminator}")
                    };
                }
                throw new JsonException("Type discriminator ($type) not found");
            }
        }

        public override void Write(Utf8JsonWriter writer, Shape value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
