using PropertyDataTester.MyHomeApi.GetStatements.Models;
using PropertyDataTester.MyHomeApi.QueryParameterConversion.Abstractions;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion.Implementations;

public sealed class OwnerTypeConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is OwnerType;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key) =>
		[
			new(key, ((OwnerType)value).ToString().ToLower())
		];
}