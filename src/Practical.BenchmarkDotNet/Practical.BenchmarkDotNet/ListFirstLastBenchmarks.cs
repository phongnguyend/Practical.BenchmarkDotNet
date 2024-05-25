using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ListFirstLastBenchmarks
{
    private const int SIZE = 1_000_000;
    private readonly List<int> _list = new List<int>(SIZE);

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _list.Add(random.Next());
        }
    }

    [Benchmark]
    public void FirstUsingLinq()
    {
        _ = _list.First();
    }

    [Benchmark]
    public void FirstUsingIndex()
    {
        _ = _list[0];
    }

    [Benchmark]
    public void LastUsingLinq()
    {
        _ = _list.Last();
    }

    [Benchmark]
    public void LastUsingIndex()
    {
        _ = _list[_list.Count - 1];
    }
}
