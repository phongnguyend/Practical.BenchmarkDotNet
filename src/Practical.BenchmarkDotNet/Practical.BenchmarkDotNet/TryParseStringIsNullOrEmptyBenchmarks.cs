using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[ShortRunJob]
[MemoryDiagnoser]
public class TryParseStringIsNullOrEmptyBenchmarks
{
    [Params("123", "abc", null, "", "  ")]
    public string Input { get; set; }

    [Benchmark]
    public void TryParse()
    {
        if(int.TryParse(Input, out int result))
        {
        }    
    }

    [Benchmark]
    public void IsNullOrEmpty()
    {
        if (!string.IsNullOrEmpty(Input) && int.TryParse(Input, out int result))
        {
        }
    }

    [Benchmark]
    public void IsNullOrWhiteSpace()
    {
        if (!string.IsNullOrWhiteSpace(Input) && int.TryParse(Input, out int result))
        {
        }
    }
}
