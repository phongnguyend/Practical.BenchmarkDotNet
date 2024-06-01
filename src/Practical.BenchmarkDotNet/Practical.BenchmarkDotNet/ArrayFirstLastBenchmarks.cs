using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ArrayFirstLastBenchmarks
{
    private const int SIZE = 1_000_000;
    private static readonly int[] _array = new int[SIZE];

    static ArrayFirstLastBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _array[i] = random.Next();
        }
    }

    [Benchmark]
    public void FirstUsingLinq()
    {
        _ = _array.First();
    }

    [Benchmark]
    public void FirstUsingIndex()
    {
        _ = _array[0];
    }

    [Benchmark]
    public void LastUsingLinq()
    {
        _ = _array.Last();
    }

    [Benchmark]
    public void LastUsingIndex()
    {
        _ = _array[_array.Length - 1];
    }
}
