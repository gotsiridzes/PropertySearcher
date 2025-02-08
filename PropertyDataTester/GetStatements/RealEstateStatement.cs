using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace PropertyDataTester.GetStatements;

public record RealEstateStatement
{
	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("deal_type_id")] public DealType DealType { get; set; }

	[JsonPropertyName("real_estate_type_id")]
	public RealEstateType RealEstateType { get; set; }

	[JsonPropertyName("status_id")] public BuildingStatus BuildingStatus { get; set; }

	[JsonPropertyName("uuid")] public Guid Uuid { get; set; }

	[JsonPropertyName("price")]
	public IReadOnlyDictionary<Currency, PriceDetail> Price { get; set; } =
		ImmutableDictionary<Currency, PriceDetail>.Empty;

	[JsonPropertyName("price_negotiable")] public bool PriceNegotiable { get; set; }

	[JsonPropertyName("lat")] public double Latitude { get; set; }

	[JsonPropertyName("lng")] public double Longitude { get; set; }

	[JsonPropertyName("images")] public IReadOnlyCollection<ImageData> Images { get; set; } = [];

	[JsonPropertyName("address")] public string Address { get; set; } = null!;

	[JsonPropertyName("area")] public double Area { get; set; }

	[JsonPropertyName("yard_area")] public double? YardArea { get; set; }

	[JsonPropertyName("bedroom")] public string? Bedroom { get; set; }

	[JsonPropertyName("room")] public string Room { get; set; } = null!;

	[JsonPropertyName("is_old")] public bool IsOld { get; set; }

	[JsonPropertyName("floor")] public int Floor { get; set; }

	[JsonPropertyName("total_floors")] public int TotalFloors { get; set; }

	[JsonPropertyName("street_id")] public int StreetId { get; set; }

	[JsonPropertyName("urban_id")] public int UrbanId { get; set; }

	[JsonPropertyName("urban_name")] public string UrbanName { get; set; } = null!;

	[JsonPropertyName("district_id")] public int DistrictId { get; set; }

	[JsonPropertyName("district_name")] public string DistrictName { get; set; } = null!;

	[JsonPropertyName("city_name")] public string CityName { get; set; } = null!;

	[JsonPropertyName("quantity_of_day")] public int QuantityOfDay { get; set; }

	[JsonPropertyName("user_id")] public int UserId { get; set; }

	[JsonPropertyName("user_title")] public string UserTitle { get; set; } = null!;

	[JsonPropertyName("statement_currency_id")]
	public Currency Currency { get; set; }

	[JsonPropertyName("grouped_street_id")]
	public int? GroupedStreetId { get; set; }

	[JsonPropertyName("comment")] public string? Comment { get; set; }

	[JsonPropertyName("user_type")] public UserType UserType { get; set; }

	[JsonPropertyName("parameters")] public IReadOnlyCollection<PropertyParameter> Parameters { get; set; } = [];
	[JsonPropertyName("dynamic_title")] public string DynamicTitle { get; set; }
	[JsonPropertyName("slug")] public string Slug { get; set; }
}