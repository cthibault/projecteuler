using System;
using System.Diagnostics;

namespace ProjectEuler.Solutions
{
    public class Approach
    {
        public string Title { get; set; }
        public int WarmupRounds { get; set; }
        public int BenchmarkRounds { get; set; }
        public IAlgorithm Algorithm { get; set; }

        public Approach()
        {
            Title = "Unnamed";
            WarmupRounds = 5;
            BenchmarkRounds = 1000;
        }
        public Approach(string title, int warmupRounds, int benchmarkRounds)
        {
            Title = title;
            WarmupRounds = warmupRounds;
            BenchmarkRounds = benchmarkRounds;
        }
        public Approach(string title, int warmupRounds, int benchmarkRounds, IAlgorithm algorithm)
        {
            Title = title;
            WarmupRounds = warmupRounds;
            BenchmarkRounds = benchmarkRounds;
            Algorithm = algorithm;
        }

        public void Run(Stopwatch watch)
        {
            Run(watch, WarmupRounds, BenchmarkRounds);
        }
        public void Run(Stopwatch watch, int warmupRounds, int benchmarkRounds)
        {
            watch = Algorithm.Run(watch, warmupRounds, benchmarkRounds);

            Console.WriteLine("{0}: {1}", this.Title, Algorithm.GetResult);
            Console.Write("Elapsed Time: ");
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0} ms ({1} ticks)",
                watch.ElapsedMilliseconds / benchmarkRounds, watch.ElapsedTicks / benchmarkRounds);
            Console.ForegroundColor = previousColor;
            //Console.WriteLine(" on {0} rounds average. D={1}", benchmarkRounds, Algorithm.GetDummy & 0x1);
            Console.WriteLine(" on {0} rounds average.", benchmarkRounds);
            Console.WriteLine();

            /*
            Func<long> algorithm = Algorithm;
            long result = 0;

            //dummy variable trying to ensure nothing is optimized away
            long dummy = long.MaxValue;

            //JIT/Warmup
            for (int i = 0; i < warmupRounds; i++)
            {
                result = algorithm();
                dummy ^= result;
            }

            //Try to prevent GC run during execution
            GC.Collect();       //QUESTION: Why run collection twice? Is it because of generation GC?
            GC.Collect();

            watch.Reset();
            watch.Start();
            for (int i = 0; i < benchmarkRounds; i++)
            {
                result = algorithm();
                dummy ^= result;
            }
            watch.Stop();

            Console.WriteLine("{0}: {1}", this.Title, result);
            Console.Write("Elapsed Time: ");
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0} ms ({1} ticks)",
                watch.ElapsedMilliseconds / benchmarkRounds, watch.ElapsedTicks / benchmarkRounds);
            Console.ForegroundColor = previousColor;
            Console.WriteLine(" on {0} rounds average. D={1}", benchmarkRounds, dummy & 0x1);
            Console.WriteLine();
            */
        }
    }
}
