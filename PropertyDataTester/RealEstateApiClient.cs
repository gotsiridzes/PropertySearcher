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

	public async Task<List<RealEstateStatement>> GetRealEstateStatementsAsync()
	{
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			Price: new(0, 140_000),
			Area: new(40, 70),
			OwnerType.Agent,
			StatementPosition.Create(true, true, false),
			[BuildingStatus.Old],
			OrderBy.Price.Asc, Page: 1);

		var paginationInfo = await GetPaginationInfoAsync(request);
		Console.WriteLine("Need to process {0} pages and {1} records", paginationInfo.Data.LastPage,
			paginationInfo.Data.Total);
		var result = new List<RealEstateStatement>();

		for (var page = paginationInfo.Data.Page; page <= paginationInfo.Data.LastPage; page++)
		{
			var pageData = await GetStatementsByPageAsync(request, page);
			result.AddRange(pageData);
			Console.WriteLine("Processing {0} page", page);
		}

		return result;
	}

	private async Task<IReadOnlyCollection<RealEstateStatement>> GetStatementsByPageAsync(GetStatementsRequest request,
		int page)
	{
		request = request with { Page = page };
		var response = await _httpClient.GetAsync($"{BaseUrl}/statements?{request.ToQueryString()}");
		response.EnsureSuccessStatusCode();

		var statementsResponse =
			JsonSerializer.Deserialize<GetStatementsResponse>(await response.Content.ReadAsStringAsync());

		return statementsResponse?.Data.Statements ??
		       throw new("Error occured during response mapping");
	}

	private async Task<GetStatementsCountResponse> GetPaginationInfoAsync(GetStatementBaseRequest request)
	{
		var req = new GetStatementsCountRequests(request.DealTypes, request.RealEstateTypes, request.Districts,
			request.Currency, request.Price, request.Area, request.Owner, request.StatementPosition,
			request.BuildingStatuses, request.Order, request.Page);

		var response = await _httpClient.GetAsync($"{BaseUrl}/statements/count?{req.ToQueryString()}");
		response.EnsureSuccessStatusCode();

		return JsonSerializer.Deserialize<GetStatementsCountResponse>(await response.Content.ReadAsStringAsync()) ??
		       throw new("Error occured during response mapping");
	}
}