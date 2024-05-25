using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ArrayLoopBenchmarks
{
    private const int SIZE = 1_000_000;
    private readonly string[] _array = new string[SIZE];

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _array[i] = random.Next().ToString();
        }
    }

    [Benchmark]
    public string For()
    {
        var result = string.Empty;

        for (int i = 0; i < SIZE; i++)
        {
            result = _array[i];
        }

        return result;
    }

    [Benchmark]
    public string Foreach()
    {
        var result = string.Empty;

        foreach (var item in _array)
        {
            result = item;
        }

        return result;
    }

    [Benchmark]
    public string ForEachMethod()
    {
        var result = string.Empty;

        Array.ForEach(_array, item => result = item);

        return result;
    }

    [Benchmark]
    public string While()
    {
        var result = string.Empty;
        var i = 0;

        while (i < SIZE)
        {
            result = _array[i];
            i++;
        }

        return result;
    }

    [Benchmark]
    public string DoWhile()
    {
        var result = string.Empty;
        var i = 0;

        do
        {
            result = _array[i];
            i++;
        }
        while (i < SIZE);

        return result;
    }

    [Benchmark]
    public string GoTo()
    {
        var result = string.Empty;
        var i = 0;

        Start:
        if (i < SIZE)
        {
            result = _array[i];
            i++;
            goto Start;
        }

        return result;
    }

    [Benchmark]
    public string Span()
    {
        var result = string.Empty;
        var span = _array.AsSpan();

        for (int i = 0; i < SIZE; i++)
        {
            result = span[i];
        }

        return result;
    }
}
