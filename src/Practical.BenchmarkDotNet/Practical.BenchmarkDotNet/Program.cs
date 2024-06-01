using BenchmarkDotNet.Running;
using Practical.BenchmarkDotNet;


//_ = BenchmarkRunner.Run<ArrayCopyBenchmarks>();
//_ = BenchmarkRunner.Run<ArrayFirstLastBenchmarks>();
//_ = BenchmarkRunner.Run<ArrayLoopBenchmarks>();
//_ = BenchmarkRunner.Run<DictionaryBenmarks>();
//_ = BenchmarkRunner.Run<DictionaryLookupVsPatternMatchingBenchmarks>();
//_ = BenchmarkRunner.Run<HashBenchmarks>();
//_ = BenchmarkRunner.Run<JsonSerializerOptionsBenchmarks>();
//_ = BenchmarkRunner.Run<ListCopyBenchmarks>();
//_ = BenchmarkRunner.Run<ListFirstLastBenchmarks>();
//_ = BenchmarkRunner.Run<ListLoopBenchmarks>();
//_ = BenchmarkRunner.Run<OrderBenchmarks>();
_ = BenchmarkRunner.Run<ReflectionMethodBenchmarks>();
//_ = BenchmarkRunner.Run<ReflectionPropertyBenchmarks>();
//_ = BenchmarkRunner.Run<StopwatchBenchmarks>();
//_ = BenchmarkRunner.Run<StringContainsBenchmarks>();
//_ = BenchmarkRunner.Run<StringEndsWithBenchmarks>();
//_ = BenchmarkRunner.Run<StringStartsWithBenchmarks>();
//_ = BenchmarkRunner.Run<TryParseVsTryCatchParseBenchmarks>();