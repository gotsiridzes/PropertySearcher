namespace PropertyDataTester.GetStatements;

public static class OrderBy
{
	public static OrderFieldSelector Price => new(OrderByField.Price);
	public static OrderFieldSelector Date => new(OrderByField.Date);
}