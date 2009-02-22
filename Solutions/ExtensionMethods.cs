using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oyster.Math;

namespace ProjectEuler
{
    static class ExtensionMethods
    {
        public static double[] getPrimeFactors(this double number)
        {
            List<double> primeFactors = new List<double>();
            while (!number.IsPrime())
            {
                for (double i = 2; i < number; i++)
                {
                    if (i.IsPrime())
                    {
                        if (number % i == 0)
                        {
                            primeFactors.Add(i);
                            number /= i;
                            break;
                        }
                    }
                }
            }
            primeFactors.Add(number);

            return primeFactors.ToArray();
        }

        public static bool IsMultiple(this int number, int baseMultiple)
        {
            if (number % baseMultiple == 0)
                return true;
            return false;
        }
        public static bool IsMultiple(this double number, double baseMultiple)
        {
            if (number % baseMultiple == 0)
                return true;
            return false;
        }

        public static bool IsPalindrom(this int number)
        {
            string strTerm = number.ToString();
            char[] charTerm = strTerm.ToCharArray();

            for (int i = 0; i < charTerm.Length / 2; i++)
            {
                if (charTerm[i] != charTerm[charTerm.Length - (i + 1)])
                    return false;
            }
         
            return true;           
        }

        public static bool IsPrime(this int number)
        {
            if (number < 2)
                return false;

            double maxSearch = Math.Sqrt(number);
            for (int i = 2; i < maxSearch; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        public static bool IsPrime(this double number)
        {
            if (number < 2)
                return false;

            double maxSearch = Math.Sqrt(number);
            for (int i = 2; i <= maxSearch; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static double SquareOfSums(this int number)
        {
            double sum = 0;
            for (double i = 1; i <= number; i++)
                sum += i;

            return Math.Pow(sum, 2);
        }
        public static double SquareOfSums(this double number)
        {
            double sum = 0;
            for (double i = 1; i <= number; i++)
                sum += i;

            return Math.Pow(sum, 2);
        }

        public static double SumOfSquares(this int number)
        {
            double sum = 0;
            for (int i = 1; i <= number; i++)
                sum += i * i;

            return sum;
        }
        public static double SumOfSquares(this double number)
        {
            double sum = 0;
            for (double i = 1; i <= number; i++)
                sum += Math.Pow(i, 2);

            return sum;
        }

        public static double TriangleNumber(this double term)
        {
            //UNDONE: Error: ran into StackOverflow error on term 10308
            //chose to use recursion for fun
            //return _triangleNumberRecursive(term);

            return _triangleNumberIterative(term);
        }
        private static double _triangleNumberRecursive(double term)
        {
            if (term == 1)
                return term;
            else
                return term + _triangleNumberRecursive(term - 1);
        }
        private static double _triangleNumberIterative(double term)
        {
            double triangleNumber = 0;
            while (term > 0)
            {
                triangleNumber += term;
                term--;
            }

            return triangleNumber;
        }

        public static double NumberOfDivisors(this double number)
        {
            double numberOfDivisors = 1;
            List<TermWithExponent> primeFactors = number.PrimeFactorization();

            foreach (TermWithExponent term in primeFactors)
                numberOfDivisors *= (term.Exponent + 1);

            return numberOfDivisors;
        }

        public static List<TermWithExponent> PrimeFactorization(this double number)
        {
            List<TermWithExponent> primeFactors = new List<TermWithExponent>();

            while (!number.IsPrime() && number > 1)
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        if (primeFactors.Exists(term => term.Term == i))
                        {
                            primeFactors.Find(term => term.Term == i).IncreaseExponent();
                        }
                        else
                            primeFactors.Add(new TermWithExponent(i, 1));

                        number /= i;
                        break;
                    }
                }
            }

            if (primeFactors.Exists(term => term.Term == number))
                primeFactors.Find(term => term.Term == number).IncreaseExponent();
            else
                primeFactors.Add(new TermWithExponent(number, 1));

            return primeFactors;
        }

        public static IntX Factorial(this IntX number)
        {
            if (number < 0)
                return 0;
            return (number == 0) ? 1 : number * Factorial(number - 1);
        }

        public static IntX SumOfDigits(this IntX number)
        {
            IntX sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        public static long SumOfDigits(this long number)
        {
            long sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}
