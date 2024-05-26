using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class StringStartsWithBenchmarks
{
    [Params("abc", "/abc", "abc/")]
    public string Input { get; set; }

    [Benchmark]
    public void StartsWithString()
    {
        Input.StartsWith("/");
    }

    [Benchmark]
    public void StartsWithChar()
    {
        Input.StartsWith('/');
    }
}
