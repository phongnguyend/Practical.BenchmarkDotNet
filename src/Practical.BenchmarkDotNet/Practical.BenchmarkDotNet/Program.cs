using BenchmarkDotNet.Running;
using Practical.BenchmarkDotNet;


_ = BenchmarkRunner.Run<DictionaryBenmarks>();
//_ = BenchmarkRunner.Run<HashBenchmarks>();
//_ = BenchmarkRunner.Run<JsonSerializerOptionsBenchmarks>();
//_ = BenchmarkRunner.Run<LoopBenchmarks>();
//_ = BenchmarkRunner.Run<OrderBenchmarks>();
//_ = BenchmarkRunner.Run<StopwatchBenchmarks>();
//_ = BenchmarkRunner.Run<TryParseVsTryCatchParseBenchmarks>();