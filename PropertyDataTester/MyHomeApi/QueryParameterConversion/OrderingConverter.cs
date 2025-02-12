using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion;

public class OrderingConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is OrderCriteria;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key)
	{
		var order = (OrderCriteria)value;
		return new List<KeyValuePair<string, string>>
		{
			new("order_by", order.Field.ToString().ToLower()),
			new("sequence", order.Sequence.ToString().ToLower())
		};
	}
}