using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class StringContainsBenchmarks
{
    [Params("abc", "/abc", "abc/")]
    public string Input { get; set; }

    [Benchmark]
    public void ContainsString()
    {
        Input.Contains("/");
    }

    [Benchmark]
    public void ContainsChar()
    {
        Input.Contains('/');
    }
}
