using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class DictionaryLoopBenchmarks
{
    private static readonly Dictionary<int, Person> _peopleDic = new Dictionary<int, Person>();
    private static readonly List<Person> _peopleList = new(1_000_000);

    static DictionaryLoopBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < 1_000_000; i++)
        {
            var person = new Person { Id = i, Age = random.Next() };
            _peopleList.Add(person);
            _peopleDic[person.Id] = person;
        }
    }

    [Benchmark]
    public void DictionaryLookup()
    {
        int personId = 999_999;
        var person = _peopleDic[personId];
    }

    [Benchmark]
    public void ListLookup()
    {
        int personId = 999_999;
        var person = _peopleList.First(x => x.Id == personId);
    }

    [Benchmark]
    public void DictionaryLoop()
    {
        var count = _peopleDic.Count(x => x.Value.Age > 18);
    }

    [Benchmark]
    public void DictionaryValuesLoop()
    {
        var count = _peopleDic.Values.Count(x => x.Age > 18);
    }

    [Benchmark]
    public void ListLoop()
    {
        var count = _peopleList.Count(x => x.Age > 18);
    }

    [Benchmark]
    public void ListAsSpanLoop()
    {
        var span = CollectionsMarshal.AsSpan(_peopleList);
        int count = 0;

        foreach (var person in span)
        {
            if (person.Age > 18)
            {
                count++;
            }
        }
    }


    public class Person
    {
        public int Id { get; set; }

        public int Age { get; set; }
    }
}
