using PropertyDataTester.MyHomeApi;
using PropertyDataTester.MyHomeApi.GetStatements.Models;
using PropertyDataTester.MyHomeApi.GetStatements.Requests;
using PropertyDataTester.Services;

var realEstateApiClient = new RealEstateStatementsApiClient();

var statements = await realEstateApiClient.GetFilteredRealEstateStatementsAsync(new GetStatementsRequest(
    [DealType.Sale],
    [RealEstateType.Flat],
    [Districts.VakeSaburtalo],
    Currency.Usd,
    new PriceRange(0, 65000),
    new AreaRange(35, 100),
    OwnerType.Physical,
    StatementPosition.NotFirstPosition,
    [BuildingStatus.Old, BuildingStatus.New, BuildingStatus.UnderConstruction],
    OrderBy.Price.Asc, 1));

await DownloadAllImagesAsync();

Console.WriteLine("Press any key to exit");
Console.ReadLine();

async Task DownloadAllImagesAsync()
{
    foreach (var statement in statements)
    {
        var images = await realEstateApiClient.GetRealEstateImagesAsync(statement.Images);
        var folderPath = $"{statement.Price[statement.Currency].PriceTotal}-{statement.DynamicTitle}-{statement.Uuid}";
        await ImageFileWriterService.WriteImagesAsync(folderPath, images);
    }
}