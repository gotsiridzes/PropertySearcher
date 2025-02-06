
using System.Net.Http;
using PropertyDataTester;

//var httpClient = new HttpClient();
//var apiUrl = @"https://api-statements.tnet.ge/v1/statements?deal_types=1&real_estate_types=1&cities=1&urbans=38%2C40%2C41%2C42%2C43%2C44%2C45%2C46%2C47%2C101%2C28&districts=4&currency_id=2&price_from=10000&price_to=70000&area_from=40&area_types=1&page=1";
////httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
//httpClient.DefaultRequestHeaders.Add("X-Website-Key", "myhome");

//var response = await httpClient.GetStringAsync(apiUrl);

var client =new RealEstateApiClient();
var response = await client.GetRealEstateStatementsAsync();

Console.WriteLine(response);
