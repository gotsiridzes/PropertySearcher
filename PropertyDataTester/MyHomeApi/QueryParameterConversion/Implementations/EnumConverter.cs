using PropertyDataTester.MyHomeApi.QueryParameterConversion.Abstractions;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion.Implementations;

public sealed class EnumConverter : IQueryParameterValueConverter
{
    public bool CanConvert(object value) => value is Enum;

    public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key) =>
        [new(key, System.Convert.ToInt32((Enum)value).ToString())];
}