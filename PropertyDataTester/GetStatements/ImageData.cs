using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public record ImageData
{
	[JsonPropertyName("large")] public string Large { get; set; } = null!;

	[JsonPropertyName("thumb")] public string Thumb { get; set; } = null!;

	[JsonPropertyName("large_webp")] public string LargeWebP { get; set; } = null!;

	[JsonPropertyName("thumb_webp")] public string ThumbWebP { get; set; } = null!;
}