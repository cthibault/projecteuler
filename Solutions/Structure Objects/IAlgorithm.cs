using System;
using System.Diagnostics;

namespace ProjectEuler.Solutions
{
    public interface IAlgorithm
    {
        string GetResult { get; }
        string GetDummy { get; }
        Stopwatch Run(Stopwatch watch, int warmupRounds, int benmarkRounds);
    }
}
