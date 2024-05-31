using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class DictionaryLookupVsPatternMatchingBenchmarks
{
    private static readonly Dictionary<string, string> _sharedDic = new()
    {
        { "VN", "Viet Nam" },
        { "US", "United States" },
        { "GB", "Great Britain" }
    };

    [Benchmark]
    public void DictionaryLookup()
    {
        var dic = new Dictionary<string, string>
        {
            { "VN", "Viet Nam" },
            { "US", "United States" },
            { "GB", "Great Britain" }
        };

        var country = dic["US"];
    }

    [Benchmark]
    public void SharedDictionaryLookup()
    {
        var country = _sharedDic["US"];
    }

    [Benchmark]
    public void PatternMatching()
    {
        var country = GetCountry("US");
    }

    private static string GetCountry(string code)
    {
        return code switch
        {
            "VN" => "Viet Nam",
            "US" => "United States",
            "GB" => "Great Britain",
            _ => throw new ArgumentException("Invalid Code", nameof(code)),
        };
    }
}
