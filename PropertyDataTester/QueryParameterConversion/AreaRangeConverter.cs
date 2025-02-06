﻿using System.Globalization;
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
			new($"{key}_from", areaRange.AreaFrom.ToString(CultureInfo.InvariantCulture)),
			new($"{key}_to", areaRange.AreaTo.ToString(CultureInfo.InvariantCulture))
		];
	}
}