using BenchmarkDotNet.Running;

namespace Practical.BenchmarkDotNet;

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<HashBenchmarks>();
    }
}