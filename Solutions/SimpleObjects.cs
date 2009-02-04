using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class TermWithExponent
    {
        public double Term;
        public double Exponent;

        public TermWithExponent(double term, double exponent)
        {
            Term = term;
            Exponent = exponent;
        }
        public void IncreaseExponent()
        {
            IncreaseExponent(Exponent + 1);
        }
        public void IncreaseExponent(double toValue)
        {
            if (toValue > Exponent)
                Exponent = toValue;
        }

        public void DecreaseExponent()
        {
            DecreaseExponent(Exponent - 1);
        }
        public void DecreaseExponent(double toValue)
        {
            if (toValue < Exponent)
                Exponent = toValue;
        }
    }
    public struct Triangle
    {
        public double SideA;
        public double SideB;
        public double SideC;
        public Triangle(int a, int b, int c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        public double SumOfSides()
        {
            return SideA + SideB + SideC;
        }
        public double ProductOfSides()
        {
            return SideA * SideB * SideC;
        }
        public bool IsPythagoreanTriplet()
        {
            bool retVal = true;

            if ((SideA > SideB) || (SideB > SideC))
                retVal = false;

            if (Math.Pow(SideA, 2) + Math.Pow(SideB, 2) != Math.Pow(SideC, 2))
                retVal = false;

            return retVal;
        }
    }
}
