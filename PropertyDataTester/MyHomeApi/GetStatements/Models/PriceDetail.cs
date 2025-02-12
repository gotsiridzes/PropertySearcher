using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public record PriceDetail
{
	[JsonPropertyName("price_total")] public decimal PriceTotal { get; set; }

	[JsonPropertyName("price_square")] public decimal PriceSquare { get; set; }
}