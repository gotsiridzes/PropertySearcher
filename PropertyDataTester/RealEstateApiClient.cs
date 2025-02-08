using System.Text.Json;
using PropertyDataTester.GetStatements;

namespace PropertyDataTester;

public sealed class RealEstateApiClient
{
	private const string BaseUrl = "https://api-statements.tnet.ge/v1";
	private readonly HttpClient _httpClient;

	public RealEstateApiClient()
	{
		_httpClient = new();
		_httpClient.DefaultRequestHeaders.Add("X-Website-Key", "myhome");
	}

	public async Task<GetStatementsResponse> GetRealEstateStatementsAsync()
	{
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			Price: new(0, 140_000),
			Area: new(40, 70),
			OwnerType.Physical,
			StatementPosition.Create(true, true, false),
			[BuildingStatus.Old],
			OrderBy.Price.Asc);

		var response = await _httpClient.GetAsync($"{BaseUrl}/statements?{request.ToQueryString()}");
		response.EnsureSuccessStatusCode();

		return JsonSerializer.Deserialize<GetStatementsResponse>(await response.Content.ReadAsStringAsync()) ??
		       throw new("Error occured during response mapping");
	}

	public async Task<string> GetPaginationInfoAsync(GetStatementBaseRequest request)
	{
		var req = request as GetStatementsCountRequests;

		return await _httpClient.GetStringAsync($"{BaseUrl}/statements/count?{req.ToQueryString()}");
	}
}