using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion;

public class OwnerTypeConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is OwnerType;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key) =>
		[new(key, ((OwnerType)value).ToString().ToLower())];
}