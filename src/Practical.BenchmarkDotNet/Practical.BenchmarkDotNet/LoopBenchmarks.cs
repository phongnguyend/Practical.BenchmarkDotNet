using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class LoopBenchmarks
{
    private readonly List<string> _list = new List<string>();
    private readonly int _size = 1_000_000;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);

        for (int i = 0; i < _size; i++)
        {
            _list.Add(random.Next().ToString());
        }
    }

    [Benchmark]
    public string For()
    {
        var result = string.Empty;

        for (int i = 0; i < _size; i++)
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
    public string ForEach()
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

        while (i < _size)
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
        while (i < _size);

        return result;
    }

    [Benchmark]
    public string GoTo()
    {
        var result = string.Empty;
        var i = 0;

        Start:
        if (i < _size)
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

        for (int i = 0; i < _size; i++)
        {
            result = span[i];
        }

        return result;
    }
}
