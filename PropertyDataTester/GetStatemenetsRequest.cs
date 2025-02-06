using System.Collections;
using System.Web;

namespace PropertyDataTester;

public sealed record GetStatementsRequest(List<DealType> DealTypes, List<RealEstateType> RealEstateTypes, List<Districts> Districts);

public enum DealType
{
	Sale = 1,
	Rent = 2,
	Collateral = 3,
	DailyRent = 7
}

public enum RealEstateType
{
	Flat = 1,
	House = 2,
	Cottage = 3,
	Land = 4,
	Commercial = 5,
	Hotel
}

public enum Districts
{
	GldaniNadzaladevi = 1,
	AroundTbilisi = 2,
	DidubeChugureti = 3,
	VakeSaburtalo = 4,
	IsaniSamgori = 5,
	OldTbilisi = 6
}

public enum Currency
{
	Gel = 1,
	Usd = 2
}

public static class QueryStringConverter
{
	private static readonly Dictionary<string, string> FieldMappings = new()
	{
		{ "DealTypes", "deal_types" },
		{ "RealEstateTypes", "real_estate_type" },
		{ "Districts", "districts" },
		//{"Currency", "currency_id"}
	};

	public static string ToQueryString(this GetStatementsRequest self)
	{
		var queryParams = new List<string>();

		foreach (var prop in self.GetType().GetProperties())
		{
			if (!FieldMappings.TryGetValue(prop.Name, out var key))
				throw new InvalidOperationException($"Field '{prop.Name}' is not mapped to a query parameter.");

			var value = prop.GetValue(self);

			if (value is IEnumerable enumList && enumList.Cast<object>().All(x => x is Enum))
			{
				var values = string.Join(",", enumList.Cast<Enum>().Select(e => Convert.ToInt32(e)));
				queryParams.Add($"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(values)}");
			}
		}

		return string.Join("&", queryParams);
	}
}