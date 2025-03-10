using System.Text.Json.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public sealed record PaginationInfo
{
	[JsonPropertyName("total")] public int Total { get; set; }

	[JsonPropertyName("per_page")] public int PerPage { get; set; }

	[JsonPropertyName("last_page")] public int LastPage { get; set; }

	[JsonPropertyName("from")] public int From { get; set; }

	[JsonPropertyName("to")] public int To { get; set; }

	[JsonPropertyName("page")] public int Page { get; set; }

	[JsonPropertyName("first_page_url")] public string FirstPageUrl { get; set; } = null!;

	[JsonPropertyName("last_page_url")] public string LastPageUrl { get; set; } = null!;

	[JsonPropertyName("prev_page_url")]
	public string? NextPageUrl { get; set; } // bug on their side, prev page is actually next page

	[JsonPropertyName("next_page_url")]
	public string? PrevPageUrl { get; set; } // bug on their side, next page is actually prev page
}