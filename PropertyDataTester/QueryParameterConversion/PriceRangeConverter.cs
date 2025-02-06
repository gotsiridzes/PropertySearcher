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
			new("price_from", priceRange.PriceFrom.ToString(CultureInfo.InvariantCulture)),
			new("price_to", priceRange.PriceTo.ToString(CultureInfo.InvariantCulture))
		];
	}
}