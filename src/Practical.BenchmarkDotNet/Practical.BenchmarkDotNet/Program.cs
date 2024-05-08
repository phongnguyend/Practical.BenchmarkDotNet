using BenchmarkDotNet.Running;

namespace Practical.BenchmarkDotNet;

internal class Program
{
    static void Main(string[] args)
    {
        //_ = BenchmarkRunner.Run<HashBenchmarks>();
        _ = BenchmarkRunner.Run<LoopBenchmarks>();
    }
}