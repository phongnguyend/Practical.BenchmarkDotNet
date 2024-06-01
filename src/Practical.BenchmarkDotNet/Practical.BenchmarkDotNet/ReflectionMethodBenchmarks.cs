using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ReflectionMethodBenchmarks
{
    private readonly Person _person = new Person { Id = 1 };
    private static readonly MethodInfo _methodInfo = typeof(Person).GetMethod("SomeMethod");
    private static readonly Func<Person, string, string> _methodDelegate = (Func<Person, string, string>)Delegate.CreateDelegate(typeof(Func<Person, string, string>), _methodInfo);

    [Benchmark]
    public void SomeMethod()
    {
        var rs = _person.SomeMethod("");
    }

    [Benchmark]
    public void SomeMethodReflection()
    {
        var rs = typeof(Person).GetMethod("SomeMethod").Invoke(_person, [""]);
    }

    [Benchmark]
    public void SomeMethodReflectionCached()
    {
        var rs = _methodInfo.Invoke(_person, [""]);
    }

    [Benchmark]
    public void SomeMethodDelegate()
    {
        var rs = _methodDelegate(_person, "");
    }

    public class Person
    {
        public int Id { get; set; }

        public string SomeMethod(string name)
        {
            return name;
        }
    }
}
