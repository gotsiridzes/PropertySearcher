using System.Globalization;
using PropertyDataTester.GetStatements;

namespace PropertyDataTester.QueryParameterConversion;

public class AreaRangeConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is AreaRange;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key)
	{
		var areaRange = (AreaRange)value;
		return
		[
			new("area_from", areaRange.AreaFrom.ToString(CultureInfo.InvariantCulture)),
			new("area_to", areaRange.AreaTo.ToString(CultureInfo.InvariantCulture))
		];
	}
}

public class OwnerTypeConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is OwnerType;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key) =>
		[new(key, ((OwnerType)value).ToString())];
}