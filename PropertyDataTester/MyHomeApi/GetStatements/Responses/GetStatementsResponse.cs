using System.Text.Json.Serialization;
using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.GetStatements.Responses;

public sealed record GetStatementsResponse
{
	[JsonPropertyName("result")] public bool Result { get; set; }

	[JsonPropertyName("data")] public required StatementData Data { get; set; }
}