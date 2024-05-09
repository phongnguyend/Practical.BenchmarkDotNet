using BenchmarkDotNet.Running;
using Practical.BenchmarkDotNet;


//_ = BenchmarkRunner.Run<HashBenchmarks>();
//_ = BenchmarkRunner.Run<LoopBenchmarks>();
_ = BenchmarkRunner.Run<OrderBenchmarks>();
//_ = BenchmarkRunner.Run<StopwatchBenchmarks>();