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
}
