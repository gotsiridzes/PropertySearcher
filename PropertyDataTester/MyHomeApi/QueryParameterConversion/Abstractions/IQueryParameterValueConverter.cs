namespace PropertyDataTester.MyHomeApi.QueryParameterConversion.Abstractions;

public interface IQueryParameterValueConverter
{
	/// <summary>
	/// Determines whether this converter can handle the given value
	/// </summary>
	bool CanConvert(object value);

	/// <summary>
	/// Converts the value to its query string representation
	/// </summary>
	IEnumerable<KeyValuePair<string, string>> Convert(object value, string key);
}