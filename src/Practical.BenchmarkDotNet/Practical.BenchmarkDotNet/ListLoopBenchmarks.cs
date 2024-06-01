using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ListLoopBenchmarks
{
    private const int SIZE = 1_000_000;
    private static readonly List<string> _list = new List<string>(SIZE);

    static ListLoopBenchmarks()
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
        var list = _list;
        var result = string.Empty;

        for (int i = 0; i < list.Count; i++)
        {
            result = list[i];
        }

        return result;
    }

    [Benchmark]
    public string Foreach()
    {
        var list = _list;
        var result = string.Empty;

        foreach (var item in list)
        {
            result = item;
        }

        return result;
    }

    [Benchmark]
    public string ForEachMethod()
    {
        var list = _list;
        var result = string.Empty;

        list.ForEach(item => result = item);

        return result;
    }

    [Benchmark]
    public string While()
    {
        var list = _list;
        var result = string.Empty;
        var i = 0;

        while (i < list.Count)
        {
            result = list[i];
            i++;
        }

        return result;
    }

    [Benchmark]
    public string DoWhile()
    {
        var list = _list;
        var result = string.Empty;
        var i = 0;

        do
        {
            result = list[i];
            i++;
        }
        while (i < list.Count);

        return result;
    }

    [Benchmark]
    public string GoTo()
    {
        var list = _list;
        var result = string.Empty;
        var i = 0;

        Start:
        if (i < list.Count)
        {
            result = list[i];
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

        for (int i = 0; i < span.Length; i++)
        {
            result = span[i];
        }

        return result;
    }
}
