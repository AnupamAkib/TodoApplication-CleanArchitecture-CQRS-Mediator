using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Serialization;

public class CustomDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? dateString = reader.GetString();

        if (string.IsNullOrWhiteSpace(dateString))
        {
            throw new JsonException("Invalid or missing date value.");
        }

        return DateTimeOffset.Parse(dateString);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToOffset(TimeSpan.FromHours(6)).ToString("dd MMM, yyyy | hh:mm tt (BST)"));
    }
}
