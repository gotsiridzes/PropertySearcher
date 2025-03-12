using PropertyDataTester.MyHomeApi.QueryParameterConversion.Abstractions;

namespace PropertyDataTester.MyHomeApi.QueryParameterConversion.Implementations;

public sealed class DefaultConverter : IQueryParameterValueConverter
{
    public bool CanConvert(object value) => true;

    public IEnumerable<KeyValuePair<string, string>> Convert(object value, string key)
    {
        yield return new(key, value.ToString());
    }
}