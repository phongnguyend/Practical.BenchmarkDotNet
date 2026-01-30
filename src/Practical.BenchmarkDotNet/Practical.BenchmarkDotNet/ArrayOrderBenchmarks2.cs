using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[ShortRunJob]
[MemoryDiagnoser]
public class ArrayOrderBenchmarks2
{
    private const int _size = 1_000;
    private PersonClass[] _array = new PersonClass[_size];

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(2024);

        for (int i = 0; i < _size; i++)
        {
            _array[i] = new PersonClass { Id = random.Next() };
        }
    }

    [Benchmark]
    public void LINQ_OrderBy()
    {
        var array = new PersonClass[_size];
        Array.Copy(_array, array, _size);

        array = array.OrderBy(x => x.Id).ToArray();
    }

    [Benchmark]
    public void Array_Sort()
    {
        var array = new PersonClass[_size];
        Array.Copy(_array, array, _size);

        Array.Sort(array, (a, b) => a.Id.CompareTo(b.Id));
    }

    [Benchmark]
    public void LINQ_OrderByDescending()
    {
        var array = new PersonClass[_size];
        Array.Copy(_array, array, _size);

        array = array.OrderByDescending(x => x.Id).ToArray();
    }

    [Benchmark]
    public void Array_SortDescending()
    {
        var array = new PersonClass[_size];
        Array.Copy(_array, array, _size);

        Array.Sort(array, (a, b) => b.Id.CompareTo(a.Id));
    }

    private class PersonClass
    {
        public int Id { get; set; }
    }
}
