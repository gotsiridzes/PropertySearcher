using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public class StatementData
{
	[JsonPropertyName("data")] public IReadOnlyCollection<RealEstateStatement> Statements { get; set; } = [];
}