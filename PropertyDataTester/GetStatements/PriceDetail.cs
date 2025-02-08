using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public record PriceDetail
{
	[JsonPropertyName("price_total")] public decimal PriceTotal { get; set; }

	[JsonPropertyName("price_square")] public decimal PriceSquare { get; set; }
}