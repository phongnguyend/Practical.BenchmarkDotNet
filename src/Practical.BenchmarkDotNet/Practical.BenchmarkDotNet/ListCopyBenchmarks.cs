using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ListCopyBenchmarks
{
    private const int SIZE = 1_000_000;
    private readonly List<int> _list = new List<int>(SIZE);

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _list.Add(random.Next());
        }
    }

    [Benchmark]
    public void LoopAdd()
    {
        var newList = new List<int>();

        for (int i = 0; i < SIZE; i++)
        {
            newList.Add(_list[i]);
        }
    }

    [Benchmark]
    public void LoopAddCapacity()
    {
        var newList = new List<int>(SIZE);

        for (int i = 0; i < SIZE; i++)
        {
            newList.Add(_list[i]);
        }
    }

    [Benchmark]
    public void AddRange()
    {
        var newList = new List<int>();
        newList.AddRange(_list);
    }

    [Benchmark]
    public void AddRangeCapacity()
    {
        var newList = new List<int>(SIZE);
        newList.AddRange(_list);
    }

    [Benchmark]
    public void CopyConstructor()
    {
        var newList = new List<int>(_list);
    }

    [Benchmark]
    public void LINQ()
    {
        var newArray = _list.Select(x => x).ToList();
    }
}
