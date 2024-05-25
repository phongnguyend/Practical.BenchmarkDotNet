using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ListLoopBenchmarks
{
    private const int SIZE = 1_000_000;
    private readonly List<string> _list = new List<string>(SIZE);

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _list.Add(random.Next().ToString());
        }
    }

    [Benchmark]
    public string For()
    {
        var result = string.Empty;

        for (int i = 0; i < SIZE; i++)
        {
            result = _list[i];
        }

        return result;
    }

    [Benchmark]
    public string Foreach()
    {
        var result = string.Empty;

        foreach (var item in _list)
        {
            result = item;
        }

        return result;
    }

    [Benchmark]
    public string ForEachMethod()
    {
        var result = string.Empty;

        _list.ForEach(item => result = item);

        return result;
    }

    [Benchmark]
    public string While()
    {
        var result = string.Empty;
        var i = 0;

        while (i < SIZE)
        {
            result = _list[i];
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
            result = _list[i];
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
            result = _list[i];
            i++;
            goto Start;
        }

        return result;
    }

    [Benchmark]
    public string Span()
    {
        var result = string.Empty;
        var span = CollectionsMarshal.AsSpan(_list);

        for (int i = 0; i < SIZE; i++)
        {
            result = span[i];
        }

        return result;
    }
}
