using System.Web;
using PropertyDataTester.MyHomeApi.GetStatements.Models;
using PropertyDataTester.MyHomeApi.QueryParameterConversion;

namespace PropertyDataTester.MyHomeApi.Extensions;

public static class QueryStringConverter
{
	private static readonly Dictionary<string, string> FieldMappings = new()
	{
		{ "DealTypes", "deal_types" },
		{ "RealEstateTypes", "real_estate_types" },
		{ "Districts", "districts" },
		{ "Currency", "currency_id" },
		{ "Price", "price" },
		{ "Area", "area" },
		{ "Owner", "owner_type" },
		{ "StatementPosition", "not_available_in_this_context" },
		{ "BuildingStatuses", "statuses" },
		{ "Order", "order_by" },
		{ "Page", "page" }
	};

	private static readonly Dictionary<Type, IQueryParameterValueConverter> TypeConverterMapping = new()
	{
		{ typeof(PriceRange), new PriceRangeConverter() },
		{ typeof(AreaRange), new AreaRangeConverter() },
		{ typeof(OwnerType), new OwnerTypeConverter() },
		{ typeof(StatementPosition), new StatementPositionConverter() },
		{ typeof(OrderCriteria), new OrderingConverter() }
	};

	private static readonly List<IQueryParameterValueConverter> GenericConverters =
	[
		new EnumListConverter(),
		new EnumConverter(),
		new DefaultConverter()
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

			if (TypeConverterMapping.TryGetValue(prop.PropertyType, out var typeSpecificConverter))
			{
				AddQueryParameters(queryParams, typeSpecificConverter.Convert(value, key));
				continue;
			}

			var genericConverter = GenericConverters.FirstOrDefault(c => c.CanConvert(value));
			if (genericConverter != null)
			{
				AddQueryParameters(queryParams, genericConverter.Convert(value, key));
				continue;
			}

			throw new InvalidOperationException(
				$"No converter found for property '{prop.Name}' of type '{prop.PropertyType}'.");
		}

		return string.Join("&", queryParams);
	}

	private static void AddQueryParameters(List<string> queryParams, IEnumerable<KeyValuePair<string, string>> pairs) =>
		queryParams.AddRange(pairs.Select(pair =>
			$"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}"));
}