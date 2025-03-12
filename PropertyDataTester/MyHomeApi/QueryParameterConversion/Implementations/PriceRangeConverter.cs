using System.Globalization;
using PropertyDataTester.MyHomeApi.GetStatements.Models;
using PropertyDataTester.MyHomeApi.QueryParameterConversion.Abstractions;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion.Implementations;

public sealed class PriceRangeConverter : IQueryParameterValueConverter
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