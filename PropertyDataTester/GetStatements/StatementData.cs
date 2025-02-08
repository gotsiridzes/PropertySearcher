using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public class StatementData
{
	[JsonPropertyName("data")] public IReadOnlyCollection<RealEstateStatement> Statements { get; set; } = [];
}