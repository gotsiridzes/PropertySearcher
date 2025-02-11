using System.Text.Json;
using PropertyDataTester.GetStatements;

namespace PropertyDataTester;

public sealed class RealEstateApiClient
{
	private const string BaseUrl = "https://api-statements.tnet.ge/v1";
	private readonly HttpClient _httpClient;

	public RealEstateApiClient()
	{
		_httpClient = new HttpClient();
		_httpClient.DefaultRequestHeaders.Add("X-Website-Key", "myhome");
	}

	public async Task<List<RealEstateStatement>> GetFilteredRealEstateStatementsAsync()
	{
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo],
			Currency.Usd,
			new PriceRange(0, 65000),
			new AreaRange(35, 100),
			OwnerType.Physical,
			StatementPosition.Create(true, false, false),
			[BuildingStatus.Old, BuildingStatus.New],
			OrderBy.Price.Asc, 1);

		var paginationInfo = await GetPaginationInfoAsync();
		Console.WriteLine("Need to process {0} pages and {1} records", paginationInfo.Data.LastPage,
			paginationInfo.Data.Total);
		var result = new List<RealEstateStatement>();

		for (var page = paginationInfo.Data.Page; page <= paginationInfo.Data.LastPage; page++)
		{
			var dateTimeOffset = DateTimeOffset.UtcNow;
			var pageData = await GetStatementsByPageAsync(page);
			Console.WriteLine("Page {0} took {1} ms", page, (DateTimeOffset.UtcNow - dateTimeOffset).TotalMilliseconds);
			result.AddRange(pageData);
			Console.WriteLine("Processing {0} page", page);
		}

		return result;

		async Task<IReadOnlyCollection<RealEstateStatement>> GetStatementsByPageAsync(
			int page)
		{
			request = request with { Page = page };
			var response = await _httpClient.GetAsync($"{BaseUrl}/statements?{request.ToQueryString()}");
			response.EnsureSuccessStatusCode();

			var statementsResponse =
				JsonSerializer.Deserialize<GetStatementsResponse>(await response.Content.ReadAsStringAsync());

			return statementsResponse?.Data.Statements ??
			       throw new Exception("Error occured during response mapping");
		}

		async Task<GetStatementsCountResponse> GetPaginationInfoAsync()
		{
			var req = new GetStatementsCountRequests(
				request.DealTypes,
				request.RealEstateTypes,
				request.Districts,
				request.Currency,
				request.Price,
				request.Area,
				request.Owner,
				request.StatementPosition,
				request.BuildingStatuses,
				request.Order, request.Page);

			var response = await _httpClient.GetAsync($"{BaseUrl}/statements/count?{req.ToQueryString()}");
			response.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<GetStatementsCountResponse>(await response.Content.ReadAsStringAsync()) ??
			       throw new Exception("Error occured during response mapping");
		}
	}

	public async Task<List<byte[]>> GetRealEstateImagesAsync(RealEstateStatement statement) =>
		(await Task.WhenAll(statement.Images
			.Select(async x => await _httpClient.GetByteArrayAsync(x.Large))))
		.ToList();
}