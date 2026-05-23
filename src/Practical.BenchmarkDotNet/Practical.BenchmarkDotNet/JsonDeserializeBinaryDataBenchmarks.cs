using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class JsonDeserializeBinaryDataBenchmarks
{
    private static readonly BinaryData _binaryData = BinaryData.FromString("{\"stargazers_count\": 123}");

    static JsonDeserializeBinaryDataBenchmarks()
    {
    }

    [IterationSetup]
    public void Setup()
    {
    }

    [Benchmark]
    public async Task StringDeserialize()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            var response = JsonSerializer.Deserialize<ApiRepsonse>(_binaryData.ToString());
        }
    }

    [Benchmark]
    public async Task StreamDeserialize()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            var response = JsonSerializer.Deserialize<ApiRepsonse>(_binaryData.ToStream());
        }
    }

    [Benchmark]
    public async Task BinaryDataDeserialize()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            var response = JsonSerializer.Deserialize<ApiRepsonse>(_binaryData);
        }
    }

    private class ApiRepsonse
    {
        public int stargazers_count { get; set; }
    }
}
