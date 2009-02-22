using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Solutions.Algorithms
{
    public static class Sequences
    {
        public static IEnumerable<long> EnumerateFibonacci(long maxValue)
        {
            long a = 1;
            long b = 2;
            long c = 3;

            yield return a;
            yield return b;

            while ((c = a + b) <= maxValue)
            {
                yield return c;
                a = b;
                b = c;
            }
        }
    }
}
