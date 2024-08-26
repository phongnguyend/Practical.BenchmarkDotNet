using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace Practical.BenchmarkDotNet;

[MemoryDiagnoser]
public partial class CheckAlphanumericBenchmarks
{
    private static readonly Regex _regex = new Regex("^[a-zA-Z0-9]*$");
    private const string LARGE = "fhalfhalkfhlkfhklahfklashfklashfklashflaskfhowiuroiywroywoiqryoqiwryiowy1321312o4yoi4y1oi4y1oi4y12oi4y1oi4y1o2i4y1o2i4y1oi4y12oi4y12oi4y12oi4y12oi4y1o2i4y12oi4yo12i4yo12i4y1o2i4y12io4y12io4y12io4y12io4y12io4y12io4yo12i4yo12i4y12io4y12io4y1412oi4y21oi4y12oi";
    private const string LARGE_INPUT = LARGE + LARGE + LARGE + LARGE;
    private const string LARGE_INPUT2 = LARGE_INPUT + "#";

    [Params("abc", "123", "abc/", LARGE_INPUT, LARGE_INPUT2)]
    public string Input { get; set; }

    [Benchmark]
    public bool IsLetterOrDigit()
    {
        foreach (char c in Input)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    [Benchmark]
    public bool Regex()
    {
        var regex = new Regex("^[a-zA-Z0-9]*$");
        return regex.IsMatch(Input);
    }

    [Benchmark]
    public bool CachedRegex()
    {
        return _regex.IsMatch(Input);
    }

    [Benchmark]
    public bool GeneratedRegex()
    {
        return AlphanumericGeneratedRegex().IsMatch(Input);
    }

    [GeneratedRegex("^[a-zA-Z0-9]*$")]
    private static partial Regex AlphanumericGeneratedRegex();
}


