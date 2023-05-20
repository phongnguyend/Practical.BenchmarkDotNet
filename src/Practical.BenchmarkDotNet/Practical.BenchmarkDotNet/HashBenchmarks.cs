using BenchmarkDotNet.Attributes;
using CryptographyHelper;
using CryptographyHelper.HashAlgorithms;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public class HashBenchmarks
{
    [Benchmark]
    public void Md5()
    {
        const string originalMessage = "Original Message to hash";
        var hashed = originalMessage.UseMd5().ComputeHash().ToHashedString();
    }

    [Benchmark]
    public void Sha1()
    {
        const string originalMessage = "Original Message to hash";
        var hashed = originalMessage.UseSha1().ComputeHash().ToHashedString();
    }

    [Benchmark]
    public void Sha256()
    {
        const string originalMessage = "Original Message to hash";
        var hashed = originalMessage.UseSha256().ComputeHash().ToHashedString();
    }

    [Benchmark]
    public void Sha384()
    {
        const string originalMessage = "Original Message to hash";
        var hashed = originalMessage.UseSha384().ComputeHash().ToHashedString();
    }

    [Benchmark]
    public void Sha512()
    {
        const string originalMessage = "Original Message to hash";
        var hashed = originalMessage.UseSha512().ComputeHash().ToHashedString();
    }
}
