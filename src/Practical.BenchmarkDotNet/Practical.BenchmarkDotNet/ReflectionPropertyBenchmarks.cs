using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ReflectionPropertyBenchmarks
{
    private readonly Person _person = new Person { Id = 1 };
    private static readonly PropertyInfo _propertyInfo = typeof(Person).GetProperty("Id");
    private static readonly Func<Person, int> _getIdDelegate = (Func<Person, int>)Delegate.CreateDelegate(typeof(Func<Person, int>), _propertyInfo.GetGetMethod());
    private static readonly Action<Person, int> _setIdDelegate = (Action<Person, int>)Delegate.CreateDelegate(typeof(Action<Person, int>), _propertyInfo.GetSetMethod());

    [Benchmark]
    public void GetId()
    {
        var id = _person.Id;
    }

    [Benchmark]
    public void GetIdReflection()
    {
        var id = (int)typeof(Person).GetProperty("Id").GetValue(_person);
    }

    [Benchmark]
    public void GetIdReflectionCached()
    {
        var id = (int)_propertyInfo.GetValue(_person);
    }

    [Benchmark]
    public void GetIdDelegate()
    {
        var id = _getIdDelegate(_person);
    }

    [Benchmark]
    public void SetId()
    {
        _person.Id = 2;
    }

    [Benchmark]
    public void SetIdReflection()
    {
        typeof(Person).GetProperty("Id").SetValue(_person, 2);
    }

    [Benchmark]
    public void SetIdReflectionCached()
    {
        _propertyInfo.SetValue(_person, 2);
    }

    [Benchmark]
    public void SetIdDelegate()
    {
        _setIdDelegate(_person, 2);
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
