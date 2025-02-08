using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public record GetStatementsResponse
{
	[JsonPropertyName("result")] public bool Result { get; set; }

	[JsonPropertyName("data")] public StatementData Data { get; set; }
}