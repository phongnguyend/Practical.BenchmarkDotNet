using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class JsonSerializerOptionsBenchmarks
{
    [Params("{}")]
    public string Input { get; set; }

    [Benchmark]
    public void NoOptions()
    {
        for (var i = 0; i < 1_000; i++)
        {
            JsonSerializer.Serialize(Input);
        }
    }

    [Benchmark]
    public void NewOptions()
    {
        for (var i = 0; i < 1_000; i++)
        {
            JsonSerializer.Serialize(Input, new JsonSerializerOptions());
        }
    }

    [Benchmark]
    public void ReuseOptions()
    {
        
        var options = new JsonSerializerOptions();

        for (var i = 0; i < 1_000; i++)
        {
            JsonSerializer.Serialize(Input, options);
        }
    }

    private static readonly JsonSerializerOptions _options = new();

    [Benchmark]
    public void ReuseStaticOptions()
    {
        for (var i = 0; i < 1_000; i++)
        {
            JsonSerializer.Serialize(Input, _options);
        }
    }
}

/*
https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/configure-options?pivots=dotnet-8-0#reuse-jsonserializeroptions-instances
*/