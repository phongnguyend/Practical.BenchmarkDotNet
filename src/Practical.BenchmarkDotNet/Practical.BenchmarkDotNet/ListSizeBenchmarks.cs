using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[WarmupCount(0)]
[IterationCount(1)]
[InvocationCount(1)]
[MemoryDiagnoser]
public class ListSizeBenchmarks
{
    [Benchmark]
    public void Bool()
    {
        var x = new List<bool>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Int()
    {
        var x = new List<int>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Float()
    {
        var x = new List<float>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Long()
    {
        var x = new List<long>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Decimal()
    {
        var x = new List<decimal>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void String()
    {
        var x = new List<string>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Struct()
    {
        var x = new List<PersonStruct>(Array.MaxLength / 2);
    }

    [Benchmark]
    public void Class()
    {
        var x = new List<PersonClass>(Array.MaxLength / 2);
    }

    private struct PersonStruct
    {
        public int Int { get; set; }

        public decimal Decimal { get; set; }
    }

    private class PersonClass
    {
        public int Int { get; set; }

        public decimal Decimal { get; set; }
    }
}
