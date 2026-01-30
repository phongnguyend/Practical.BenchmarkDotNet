using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class DictionaryKeyLookupBenchmarks
{
    [Params("1", "500", "1000")]
    public string Input { get; set; }

    private static readonly Dictionary<string, string> _dic = new Dictionary<string, string>();

    static DictionaryKeyLookupBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < 1_000; i++)
        {
            _dic[i.ToString()] = i.ToString();
        }
    }


    [Benchmark]
    public bool ContainsKey()
    {
        return _dic.ContainsKey(Input);
    }

    [Benchmark]
    public bool KeysContains()
    {
        return _dic.Keys.Contains(Input);
    }
}
