using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Oyster.Math;
using ProjectEuler.Solutions.Algorithms;

namespace ProjectEuler.Solutions
{
    public class EulerProblems
    {
        private List<Problem> _problems;
        private Dictionary<int, Problem> _problemsById;
        private Stopwatch _watch;

        public EulerProblems()
        {
            _problems = new List<Problem>
            {
                new Problem(1, "What is the sum of all the multiples of 3 or 5 below 1000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce", 
                        WarmupRounds = 5,
                        BenchmarkRounds = 1000,
                        Algorithm = new Func<long>(problem1_1)
                    },
                    new Approach
                    {
                        
                    }
                },
                new Problem(2, "What is the sum of all the even-valued terms in the Fibonacci Sequence which do not exceed 4,000,000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce", 
                        WarmupRounds = 5,
                        BenchmarkRounds = 1000, 
                        Algorithm = new Func<long>(problem2_1)
                    }
                },
                new Problem(3, "What is the largest prime factor of the number 600851475143?")
                {
                    new Approach 
                    { 
                        WarmupRounds = 5, 
                        BenchmarkRounds = 1000, 
                        Algorithm = new Func<long>(problem3_1)
                    }
                },

                new Problem(16, "What is the sum of the digits of the number 2^1000?")
                {
                    new Approach
                    {
                        WarmupRounds = 5,
                        BenchmarkRounds = 1000,
                        Algorithm = new Func<long>(problem16_1)
                    }
                }
            };

            _problemsById = _problems.ToDictionary(p => p.ID);
            _watch = new Stopwatch();
        }

        public void RunProblem(int id)
        {
            Problem problem;
            if (!_problemsById.TryGetValue(id, out problem))
            {
                Console.WriteLine("Problem {0} is not available.", id);
                return;
            }

            problem.Run(_watch);
        }

        #region Problems

        private long problem1_1()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                if (i.IsMultiple(3) || i.IsMultiple(5))
                    sum += 1;
            return sum;
        }
        private long problem2_1()
        {
            long sum = 0;
            IEnumerable<long> fibSeq = Sequences.EnumerateFibonacci(4000000);
            
            foreach (long term in fibSeq)
                if (term % 2 == 0)
                    sum += term;
            return sum;
        }
        private long problem3_1()
        {
            return Convert.ToInt64(600851475143d.getPrimeFactors().Max());
        }
        //private long problem4_1() { }

        private long problem16_1()
        {
            return 0;
        }

        #endregion
    }
}
