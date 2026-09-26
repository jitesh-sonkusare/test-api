using System.Text.Json.Serialization;

namespace TestAPI.ApiEndpoints.V1;

public record HealthResponse(
    [property: JsonPropertyName("status")]    string   Status,
    [property: JsonPropertyName("version")]   string   Version,
    [property: JsonPropertyName("timestamp")] DateTime Timestamp
);
