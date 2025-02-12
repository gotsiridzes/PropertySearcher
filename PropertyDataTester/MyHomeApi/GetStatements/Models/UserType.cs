using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public record UserType
{
	[JsonPropertyName("type")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public OwnerType Type { get; set; }
}