using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class DictionaryBenchmarks
{
    [Params("123", "abc")]
    public string Input { get; set; }

    private static readonly Dictionary<string, string> _dic = new Dictionary<string, string> { { "abc", "" } };

    [Benchmark]
    public void TryGetValue()
    {
        if (_dic.TryGetValue(Input, out string result))
        {
        }
    }

    [Benchmark]
    public void ContainsKey()
    {
        if (_dic.ContainsKey(Input))
        {
            var result = _dic[Input];
        }
    }

    [Benchmark]
    public void TryCatch()
    {
        try
        {
            var result = _dic[Input];
        }
        catch(KeyNotFoundException)
        {
        }
    }
}
