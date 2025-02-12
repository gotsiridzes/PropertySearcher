using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public record PropertyParameter
{
	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("key")] public string Key { get; set; } = null!;

	[JsonPropertyName("input_name")] public string? InputName { get; set; }

	[JsonPropertyName("select_name")] public string? SelectName { get; set; }

	[JsonPropertyName("display_name")] public string DisplayName { get; set; } = null!;
}