using System.Globalization;
using PropertyDataTester.GetStatements;

namespace PropertyDataTester.QueryParameterConversion;

public class PriceRangeConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is PriceRange;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key)
	{
		var priceRange = (PriceRange)value;
		return
		[
			new($"{key}_from", priceRange.PriceFrom.ToString(CultureInfo.InvariantCulture)),
			new($"{key}_to", priceRange.PriceTo.ToString(CultureInfo.InvariantCulture))
		];
	}
}

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