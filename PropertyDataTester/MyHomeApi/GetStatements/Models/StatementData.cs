using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public sealed record StatementData
{
	[JsonPropertyName("data")] public IReadOnlyCollection<RealEstateStatement> Statements { get; set; } = [];
}