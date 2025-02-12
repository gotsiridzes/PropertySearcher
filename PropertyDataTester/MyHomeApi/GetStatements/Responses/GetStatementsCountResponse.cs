using System.Text.Json.Serialization;
using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.GetStatements.Responses;

public record GetStatementsCountResponse
{
	[JsonPropertyName("result")] public bool Result { get; set; }

	[JsonPropertyName("data")] public PaginationInfo Data { get; set; }
}