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

	public async Task<string> GetRealEstateStatementsAsync()
	{
		var endpoint = $"{BaseUrl}/statements";

		var notFirstNotLast = StatementPosition.Create(true, true, false);
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			Price: new(10_000, 140_000),
			Area: new(40, 70),
			OwnerType.Physical,
			notFirstNotLast,
			[BuildingStatus.New, BuildingStatus.Old],
			OrderBy.Price.Asc);

		return await _httpClient.GetStringAsync($"{endpoint}?{request.ToQueryString()}");
	}

	public async Task<string> GetRealEstateStatementsCountAsync()
	{
		var endpoint = $"{BaseUrl}/statements/count";

		var notFirstNotLast = StatementPosition.Create(true, true, false);
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			Price: new(10_000, 140_000),
			Area: new(40, 70),
			OwnerType.Physical,
			notFirstNotLast,
			[BuildingStatus.New, BuildingStatus.Old],
			OrderBy.Price.Asc);

		return await _httpClient.GetStringAsync($"{endpoint}?{request.ToQueryString()}");
	}
}