using PropertyDataTester.MyHomeApi;
using PropertyDataTester.MyHomeApi.GetStatements.Models;

var realEstateApiClient = new RealEstateStatementsApiClient();
var statements = await realEstateApiClient.GetFilteredRealEstateStatementsAsync();

await DownloadAllImagesAsync(statements);

async Task DownloadAllImagesAsync(List<RealEstateStatement> realEstateStatements)
{
	int counter = 1;
	foreach (var statement in realEstateStatements)
	{
		var images = await realEstateApiClient.GetRealEstateImagesAsync(statement);
		Console.WriteLine("Downloading {0} images for statement {1}. {2}/{3}", images.Count, statement.Uuid, counter,
			statements.Count);
		var path = $"{statement.Price[statement.Currency].PriceTotal}-{statement.DynamicTitle}-{statement.Uuid}";
		if (!Directory.Exists(path)) Directory.CreateDirectory(path);

		foreach (var (imageName, imageData) in images)
			File.WriteAllBytes(Path.Combine(path, imageName), imageData);
		counter++;
	}
}

Console.ReadLine();