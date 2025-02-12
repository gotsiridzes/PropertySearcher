using System.Collections;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion;

public class EnumListConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) =>
		value is IEnumerable list && list.Cast<object>().All(x => x is Enum);

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key) =>
	[
		new(key, string.Join(",", ((IEnumerable)value).Cast<Enum>().Select(System.Convert.ToInt32)))
	];
}