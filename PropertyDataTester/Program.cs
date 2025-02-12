using PropertyDataTester.MyHomeApi;
using PropertyDataTester.MyHomeApi.GetStatements.Models;
using PropertyDataTester.Services;

var realEstateApiClient = new RealEstateStatementsApiClient();
var statements = await realEstateApiClient.GetFilteredRealEstateStatementsAsync();

await DownloadAllImagesAsync();

async Task DownloadAllImagesAsync()
{
	foreach (var statement in statements)
	{
		var images = await realEstateApiClient.GetRealEstateImagesAsync(statement);
		var path = $"{statement.Price[statement.Currency].PriceTotal}-{statement.DynamicTitle}-{statement.Uuid}";
		await ImageFileWriterService.WriteImagesAsync(path, images);
	}
}


Console.ReadLine();