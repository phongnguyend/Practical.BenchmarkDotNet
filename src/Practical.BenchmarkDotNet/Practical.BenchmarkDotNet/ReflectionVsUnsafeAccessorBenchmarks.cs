using BenchmarkDotNet.Attributes;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class ReflectionVsUnsafeAccessorBenchmarks
{
    private readonly Person _person = new Person { Id = 1 };
    private static readonly MethodInfo _methodInfo = typeof(Person).GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly Func<Person, string, string> _methodDelegate = (Func<Person, string, string>)Delegate.CreateDelegate(typeof(Func<Person, string, string>), _methodInfo);

    [Benchmark]
    public void PrivateMethodReflection()
    {
        var rs = typeof(Person).GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(_person, [""]);
    }

    [Benchmark]
    public void PrivateMethodReflectionCached()
    {
        var rs = _methodInfo.Invoke(_person, [""]);
    }

    [Benchmark]
    public void PrivateMethodDelegate()
    {
        var rs = _methodDelegate(_person, "");
    }

    [Benchmark]
    public void PrivateMethodUnsafeAccessor()
    {
        var rs = PrivateMethod(_person, "");
    }

    public class Person
    {
        public int Id { get; set; }

        private string PrivateMethod(string name)
        {
            return name;
        }
    }

    [UnsafeAccessor(UnsafeAccessorKind.Method)]
    extern static string PrivateMethod(Person person, string name);
}
