using PropertyDataTester;

//var response = await new RealEstateApiClient().GetRealEstateStatementsAsync();

//var statementCounts = await new RealEstateApiClient().GetRealEstateStatementsCountAsync();
var statements = await new RealEstateApiClient().GetRealEstateStatementsAsync();

Console.ReadLine();