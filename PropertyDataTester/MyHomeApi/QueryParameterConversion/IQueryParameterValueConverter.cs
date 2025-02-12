namespace PropertyDataTester.MyHomeApi.QueryParameterConversion;

public interface IQueryParameterValueConverter
{
	/// <summary>
	/// Determines whether this converter can handle the given value
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	bool CanConvert(object value);

	/// <summary>
	/// Converts the value to its query string representation
	/// </summary>
	/// <param name="value"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	IEnumerable<KeyValuePair<string, string>> Convert(object value, string key);
}