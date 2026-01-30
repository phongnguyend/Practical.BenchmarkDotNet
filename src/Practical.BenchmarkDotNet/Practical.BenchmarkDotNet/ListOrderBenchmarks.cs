using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ListOrderBenchmarks
{
    private const int _size = 1_000;
    private int[] _array = new int[_size];

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(2024);

        for (int i = 0; i < _size; i++)
        {
            _array[i] = random.Next();
        }
    }

    [Benchmark]
    public void LINQ_Order()
    {
        var list = new List<int>(_array);

        list = list.Order().ToList();
    }

    [Benchmark]
    public void LINQ_OrderBy()
    {
        var list = new List<int>(_array);

        list = list.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public void List_Sort()
    {
        var list = new List<int>(_array);

        list.Sort();
    }

    [Benchmark]
    public void LINQ_OrderDescending()
    {
        var list = new List<int>(_array);

        list = list.OrderDescending().ToList();
    }

    [Benchmark]
    public void LINQ_OrderByDescending()
    {
        var list = new List<int>(_array);

        list = list.OrderByDescending(x => x).ToList();
    }

    [Benchmark]
    public void List_SortDescending()
    {
        var list = new List<int>(_array);

        list.Sort((a, b) => b.CompareTo(a));
    }

    [Benchmark]
    public void List_SortAndReverse()
    {
        var list = new List<int>(_array);

        list.Sort();
        list.Reverse();
    }
}
