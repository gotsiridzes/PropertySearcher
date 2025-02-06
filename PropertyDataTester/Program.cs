using PropertyDataTester;

var response = await new RealEstateApiClient().GetRealEstateStatementsAsync();

Console.WriteLine(response);