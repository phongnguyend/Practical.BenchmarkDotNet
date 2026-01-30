using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ArrayOrderBenchmarks
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
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        array = array.Order().ToArray();
    }

    [Benchmark]
    public void LINQ_OrderBy()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        array = array.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public void Array_Sort()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        Array.Sort(array);
    }

    [Benchmark]
    public void LINQ_OrderDescending()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        array = array.OrderDescending().ToArray();
    }

    [Benchmark]
    public void LINQ_OrderByDescending()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        array = array.OrderByDescending(x => x).ToArray();
    }

    [Benchmark]
    public void Array_SortDescending()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        Array.Sort(array, (a, b) => b.CompareTo(a));
    }

    [Benchmark]
    public void Array_SortAndReverse()
    {
        var array = new int[_size];
        Array.Copy(_array, array, _size);

        Array.Sort(array);
        Array.Reverse(array);
    }
}
