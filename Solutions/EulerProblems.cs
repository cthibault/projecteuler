using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Oyster.Math;

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
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem1_1))
                    }
                },
                new Problem(2, "What is the sum of all the even-valued terms in the Fibonacci Sequence which do not exceed 4,000,000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce", 
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem2_1))
                    }
                },
                new Problem(3, "What is the largest prime factor of the number 600851475143?")
                {
                    new Approach 
                    { 
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem3_1))
                    }
                },
                new Problem(4, "What is the largest palindrome made from the product of two 3-digit numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<int>(new Func<int>(EulerSolutions.problem4_1))
                    }
                },
                new Problem(5, "What is the smallest number that is evenly divisible by all of the numbers from 1 to 20?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem5_1))
                    }
                },
                new Problem(6, "What is the difference between the sum of the squares and the square of the sums for the firt 100 natural numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce 1",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem6_1))
                    },
                    new Approach
                    {
                        Title = "Bruteforce 2",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem6_2))
                    }
                },
                new Problem(7, "What is the 10,001st prime number?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem7_1))
                    }
                },
                new Problem(8, "What is the greatest product of five consecutive digits in the 1000 digit number?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem8_1))
                    }
                },
                new Problem(9, "Find the product of abc where: a<b<c, a^2 + b^2 = c^2, and a + b + c = 1000.")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<string>(new Func<string>(EulerSolutions.problem9_1))
                    }
                },
                new Problem(10, "What is the sum of all the primes below two million?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem10_1))
                    },
                    new Approach
                    {
                        Title = "Eratosthenes Sieve 1",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem10_2))
                    }
                },
                new Problem(11, "What is the greatest product of four adjacent numbers in any direction in the 20x20 grid?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem11_1))
                    }
                },
                new Problem(12, "What is the first triangle number to have over 500 divisors?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem12_1))
                    }
                },
                new Problem(13, "What are the first 10 digits of the sum of the 100 50-digit numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce (String Manipulation)",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem13_1))
                    }
                },
                new Problem(14, string.Format("{1}{0}{2}{0}{0}{3}", Environment.NewLine, "n -> n/2 (n is even)", "n -> 3n + 1 (n is odd)", "Which starting number under 1,000,000 produces the longest chain?"))
                {
                    new Approach
                    {
                        //TODO: Add Title
                        Algorithm = new Algorithm<string>(new Func<string>(EulerSolutions.problem14_1))
                    }
                },
                new Problem(15, "How many routes (w/o backtracking) are there from the top left corner to the bottom right corner of a 20x20 grid?")
                {
                    new Approach
                    {
                        Title = "Pascal's Triangle",
                        Algorithm = new Algorithm<double>(new Func<double>(EulerSolutions.problem15_1))
                    }
                },
                new Problem(16, "What is the sum of the digits of the number 2^1000?")
                {
                    new Approach
                    {
                        //TODO: Add Title
                        Algorithm = new Algorithm<IntX>(new Func<IntX>(EulerSolutions.problem16_1))
                    }
                },
                new Problem(17, "How many letters would be used to write out the numbers 1 through 1000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<int>(new Func<int>(EulerSolutions.problem17_1))
                    }
                },
                new Problem(19, "How many Sundays fell on the first of the month during the twentieth century (Jan 1, 1901 to Dec 31, 2000)?")
                {
                    new Approach
                    {
                        Title = "Gregorian Calendar",
                        Algorithm = new Algorithm<long>(new Func<long>(EulerSolutions.problem19_1))
                    }
                },
                new Problem(20, "Find the sum of the digits of the number 100!")
                {
                    new Approach
                    {
                        Algorithm = new Algorithm<IntX>(new Func<IntX>(EulerSolutions.problem20_1))
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
    }
}
