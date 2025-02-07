namespace PropertyDataTester.GetStatements;

public readonly struct OrderFieldSelector
{
	private readonly OrderByField _field;

	internal OrderFieldSelector(OrderByField field) => _field = field;

	public OrderCriteria Asc => new(_field, OrderSequence.Asc);
	public OrderCriteria Desc => new(_field, OrderSequence.Desc);
}