using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class OrderBenchmarks
{
    private readonly int _size = 1_000;

    [Benchmark]
    public List<int> LINQ_Order()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        return list.Order().ToList();
    }

    [Benchmark]
    public List<int> LINQ_OrderBy()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        return list.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<int> List_Sort()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        list.Sort();

        return list;
    }

    [Benchmark]
    public List<int> LINQ_OrderDescending()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        return list.OrderDescending().ToList();
    }

    [Benchmark]
    public List<int> LINQ_OrderByDescending()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        return list.OrderByDescending(x => x).ToList();
    }

    [Benchmark]
    public List<int> List_SortDescending()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        list.Sort((a, b) => b.CompareTo(a));

        return list;
    }

    [Benchmark]
    public List<int> List_SortAndReverse()
    {
        var random = new Random(2024);
        var list = new List<int>(_size);

        for (int i = 0; i < _size; i++)
        {
            list.Add(random.Next());
        }

        list.Sort();
        list.Reverse();

        return list;
    }
}
