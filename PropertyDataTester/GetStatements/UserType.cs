using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public record UserType
{
	[JsonPropertyName("type")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public OwnerType Type { get; set; }
}