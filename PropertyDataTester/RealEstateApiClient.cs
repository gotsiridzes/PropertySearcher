using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PropertyDataTester;

public sealed class RealEstateApiClient
{
	private readonly HttpClient _httpClient;
	private const string BaseUrl = "https://api-statements.tnet.ge/v1";

	public RealEstateApiClient()
	{
		_httpClient = new HttpClient();
		_httpClient.DefaultRequestHeaders.Add("X-Website-Key", "myhome");
	}

	public async Task<string> GetRealEstateStatementsAsync()
	{
		var endpoint = Path.Combine(BaseUrl, "statements");
		//var query = new Dictionary<string, string>
		//{
		//	{ "deal_types", "1" }, //
		//	{ "real_estate_types", "1" }, //
		//	{ "cities", "1" },
		//	{ "urbans", "38,40,41,42,43,44,45,46,47,101,28" },
		//	{ "districts", "4" },
		//	{ "currency_id", "2" },
		//	{ "price_from", "10000" },
		//	{ "price_to", "70000" },
		//	{ "area_from", "40" },
		//	{ "area_types", "1" },
		//	{ "page", "1" }
		//};
		var request = new GetStatementsRequest(
			[DealType.Sale],
			[RealEstateType.Flat],
			[Districts.VakeSaburtalo, Districts.IsaniSamgori]);

		var queryString = request.ToQueryString();
		var apiUrl = $"{endpoint}?{queryString}";
		//var apiUrl2 = @"https://api-statements.tnet.ge/v1/statements?deal_types=1,2&real_estate_types=1&cities=1&urbans=38%2C40%2C41%2C42%2C43%2C44%2C45%2C46%2C47%2C101%2C28&districts=4&currency_id=2&price_from=10000&price_to=70000&area_from=40&area_types=1&page=1";

		var response = await _httpClient.GetStringAsync(apiUrl);
		return response;
	}
}
