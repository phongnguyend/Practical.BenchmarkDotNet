using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ArrayBoundsCheckBenchmarks
{
    private const int SIZE = 1_000_000;
    private static readonly string[] _array = new string[SIZE];

    static ArrayBoundsCheckBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _array[i] = random.Next().ToString();
        }
    }

    [Benchmark]
    public string BoundsCheckEnabled()
    {
        var result = string.Empty;

        for (int i = 0; i < _array.Length; i++)
        {
            result = _array[i];
        }

        return result;
    }

    [Benchmark]
    public string BoundsCheckDisabled()
    {
        var array = _array;
        var result = string.Empty;

        for (int i = 0; i < array.Length; i++)
        {
            result = array[i];
        }

        return result;
    }
}
