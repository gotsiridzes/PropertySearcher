using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.GetStatements.Requests;

public abstract record GetStatementBaseRequest(
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
	int Page);