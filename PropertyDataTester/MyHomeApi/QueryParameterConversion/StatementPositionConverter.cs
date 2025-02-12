using PropertyDataTester.MyHomeApi.GetStatements.Models;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion;

public class StatementPositionConverter : IQueryParameterValueConverter
{
	public bool CanConvert(object value) => value is StatementPosition;

	public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key)
	{
		var position = (StatementPosition)value;

		var queryParams = new List<KeyValuePair<string, string>>();

		if (position.NotFirst == true) queryParams.Add(new("not_first", "true"));
		if (position.NotLast == true) queryParams.Add(new("not_last", "true"));
		if (position.IsLast == true) queryParams.Add(new("is_last", "true"));

		return queryParams;
	}
}