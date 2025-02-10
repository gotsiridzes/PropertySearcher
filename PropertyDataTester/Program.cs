using System.Net.Mime;
using PropertyDataTester;

//var response = await new RealEstateApiClient().GetRealEstateStatementsAsync();

//var statementCounts = await new RealEstateApiClient().GetRealEstateStatementsCountAsync();
var realEstateApiClient = new RealEstateApiClient();
var statements = await realEstateApiClient.GetFilteredRealEstateStatementsAsync();

var images = realEstateApiClient.GetRealEstateImages(statements.First());
Console.ReadLine();