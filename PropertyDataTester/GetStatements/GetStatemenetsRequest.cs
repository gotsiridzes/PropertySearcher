namespace PropertyDataTester.GetStatements;

public sealed record GetStatementsRequest(
	List<DealType> DealTypes,
	List<RealEstateType> RealEstateTypes,
	List<Districts> Districts,
	Currency Currency,
	PriceRange Price,
	AreaRange Area);