using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class StopwatchBenchmarks
{
    [Benchmark]
    public TimeSpan StartNew()
    {
        var watch = Stopwatch.StartNew();

        DoWork();

        return watch.Elapsed;
    }

    [Benchmark]
    public TimeSpan GetTimestamp()
    {
        var start = Stopwatch.GetTimestamp();

        DoWork();

        return Stopwatch.GetElapsedTime(start);
    }

    private void DoWork()
    {

    }
}
