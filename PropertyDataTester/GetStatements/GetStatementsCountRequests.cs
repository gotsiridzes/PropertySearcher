namespace PropertyDataTester.GetStatements;

public record GetStatementsCountRequests(
	List<DealType> DealTypes,
	List<RealEstateType> RealEstateTypes,
	List<Districts> Districts,
	Currency Currency,
	PriceRange Price,
	AreaRange Area,
	OwnerType Owner,
	StatementPosition StatementPosition,
	List<BuildingStatus> BuildingStatuses,
	OrderCriteria Order) : GetStatementBaseRequest(DealTypes, RealEstateTypes, Districts, Currency, Price, Area, Owner,
	StatementPosition, BuildingStatuses, Order);