using System.Web;
using PropertyDataTester.QueryParameterConversion;

namespace PropertyDataTester.GetStatements;

public static class QueryStringConverter
{
	private static readonly Dictionary<string, string> FieldMappings = new()
	{
		{ "DealTypes", "deal_types" },
		{ "RealEstateTypes", "real_estate_types" },
		{ "Districts", "districts" },
		{ "Currency", "currency_id"},
		{ "Price", "price" },
		{ "Area", "area" },
		//{ "Owner", "owner_type" }
	};

	private static readonly List<IQueryParameterValueConverter> Converters =
	[
		new EnumListConverter(),
		new EnumConverter(),
		new PriceRangeConverter(),
		new AreaRangeConverter(),
		//new OwnerTypeConverter()
	];

	public static string ToQueryString(this object self)
	{
		var queryParams = new List<string>();

		foreach (var prop in self.GetType().GetProperties())
		{
			if (!FieldMappings.TryGetValue(prop.Name, out var key))
				throw new InvalidOperationException($"Field '{prop.Name}' is not mapped to a query parameter.");

			var value = prop.GetValue(self);
			if (value == null)
				continue;

			var converter = Converters.FirstOrDefault(c => c.CanConvert(value)) ?? throw new InvalidOperationException($"No converter found for property '{prop.Name}' of type '{value.GetType()}'.");

			queryParams.AddRange(converter.Convert(value, key).Select(pair => $"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}"));
		}

		return string.Join("&", queryParams);
	}
}