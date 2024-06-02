using BenchmarkDotNet.Attributes;

namespace Practical.BenchmarkDotNet;

[WarmupCount(0)]
[IterationCount(1)]
[InvocationCount(1)]
[MemoryDiagnoser]
public class ArraySizeBenchmarks
{
    [Benchmark]
    public void Bool()
    {
        var x = new bool[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Int()
    {
        var x = new int[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Float()
    {
        var x = new float[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Long()
    {
        var x = new long[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Decimal()
    {
        var x = new decimal[Array.MaxLength / 2];
    }

    [Benchmark]
    public void String()
    {
        var x = new string[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Struct()
    {
        var x = new PersonStruct[Array.MaxLength / 2];
    }

    [Benchmark]
    public void Class()
    {
        var x = new PersonClass[Array.MaxLength / 2];
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
