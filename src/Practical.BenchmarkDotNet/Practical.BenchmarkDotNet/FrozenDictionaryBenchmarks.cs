using BenchmarkDotNet.Attributes;
using System.Collections.Frozen;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class FrozenDictionaryBenchmarks
{
    private static readonly List<Person> _peopleList = new(1_000);
    private static readonly Dictionary<int, Person> _dic;
    private static readonly FrozenDictionary<int, Person> _frozenDic;

    static FrozenDictionaryBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < 1_000; i++)
        {
            var person = new Person { Id = i, Age = random.Next() };
            _peopleList.Add(person);
        }

        _dic = _peopleList.ToDictionary(x => x.Id, x => x);
        _frozenDic = _peopleList.ToFrozenDictionary(x => x.Id, x => x);
    }

    [Benchmark]
    public void ToDictionary()
    {
        var dic = _peopleList.ToDictionary(x => x.Id, x => x);
    }

    [Benchmark]
    public void ToFrozenDictionary()
    {
        var dic = _peopleList.ToFrozenDictionary(x => x.Id, x => x);
    }

    [Benchmark]
    public void Dictionary_ContainsKey()
    {
        var x = _dic.ContainsKey(999);
    }

    [Benchmark]
    public void FrozenDictionary_ContainsKey()
    {
        var x = _frozenDic.ContainsKey(999);
    }

    [Benchmark]
    public void Dictionary_TryGetValue()
    {
        var x = _dic.TryGetValue(999, out var person);
    }

    [Benchmark]
    public void FrozenDictionary_TryGetValue()
    {
        var x = _frozenDic.TryGetValue(999, out var person);
    }

    [Benchmark]
    public void Dictionary_Indexer()
    {
        var person = _dic[999];
    }

    [Benchmark]
    public void FrozenDictionary_Indexer()
    {
        var person = _frozenDic[999];
    }

    public class Person
    {
        public int Id { get; set; }

        public int Age { get; set; }
    }
}
