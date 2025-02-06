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
		const string endpoint = $"{BaseUrl}/statements";

		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			Price: new(10_000, 40_000),
			Area: new(40, 70),
			OwnerType.Physical);

		var apiUrl = $"{endpoint}?{request.ToQueryString()}";

		var response = await _httpClient.GetStringAsync(apiUrl);
		return response;
	}
}