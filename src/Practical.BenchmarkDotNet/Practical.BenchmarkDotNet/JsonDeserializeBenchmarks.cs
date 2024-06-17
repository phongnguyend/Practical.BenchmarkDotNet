using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace Practical.BenchmarkDotNet;

[WarmupCount(0)]
[IterationCount(1)]
[InvocationCount(1)]
[MemoryDiagnoser]
public class JsonDeserializeBenchmarks
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private HttpResponseMessage _httpResponseMessage1;
    private HttpResponseMessage _httpResponseMessage2;

    static JsonDeserializeBenchmarks()
    {
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");
    }

    [IterationSetup]
    public void Setup()
    {
        var url = $"https://api.github.com/repos/phongnguyend/Practical.BenchmarkDotNet";

        _httpResponseMessage1 = _httpClient.GetAsync(url).GetAwaiter().GetResult();
        _httpResponseMessage2 = _httpClient.GetAsync(url).GetAwaiter().GetResult();
    }

    [Benchmark]
    public async Task StringDeserialize()
    {
        var json = await _httpResponseMessage1.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<ApiRepsonse>(json);
    }

    [Benchmark]
    public async Task StreamDeserialize()
    {
        var stream = await _httpResponseMessage2.Content.ReadAsStreamAsync();
        var response = JsonSerializer.Deserialize<ApiRepsonse>(stream);
    }

    private class ApiRepsonse
    {
        public int stargazers_count { get; set; }
    }
}
