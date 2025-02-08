namespace PropertyDataTester.GetStatements;

public record GetStatementsRequest(
	List<DealType> DealTypes,
	List<RealEstateType> RealEstateTypes,
	List<Districts> Districts,
	Currency Currency,
	PriceRange Price,
	AreaRange Area,
	OwnerType Owner,
	StatementPosition StatementPosition,
	List<BuildingStatus> BuildingStatuses,
	OrderCriteria Order,
	int Page) : GetStatementBaseRequest(DealTypes, RealEstateTypes, Districts, Currency, Price, Area, Owner,
	StatementPosition, BuildingStatuses, Order, Page);

// TODO: // After fulfilling this details - need to take care of paging to get all the data.
// After all of this - need to implement builder pattern because not all the parameters are required, and potential caller will be able to use only the ones he needs.