using System;
using System.Text;

namespace NumericUtils
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Returns IEEE754 binary representation of <paramref name="number"/>
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>IEEE754 binary representation of <paramref name="number"/></returns>
        public static string ToBinary(this double number)
        {
            var stringBuilder = new StringBuilder();

            char signBit = GetSignBinaryRepresentation(number);
            stringBuilder.Append(signBit);

            if (signBit == CHAR_BIT_TRUE)
            {
                number = -number;
            }

            int exponent = GetDoublesExponent(number, out double fraction);

            stringBuilder.Append(GetExponentBinaryRepresentation(exponent));
            stringBuilder.Append(GetFractionBinaryRepresentation(fraction));

            return stringBuilder.ToString();
        }

        #region Private fields

        const char CHAR_BIT_FALSE = '0';
        const char CHAR_BIT_TRUE  = '1';

        const int EXPONENT_BIT_LENGTH = 11;
        const int FRACTION_BIT_LENGTH = 52;
        const int EXPONENT_BIAS       = 1023;
        const int SUBNORMAL_EXPONENT  = -1022;

        #endregion

        #region Private methods

        private static char GetSignBinaryRepresentation(double number)
        {
            if (number < 0 || IsNegativeZero(number))
            {
                return CHAR_BIT_TRUE;
            }

            return CHAR_BIT_FALSE;
        }

        private static string GetExponentBinaryRepresentation(int number)
        {
            char[] bits = new char[EXPONENT_BIT_LENGTH];

            for (int i = 0; i < EXPONENT_BIT_LENGTH; i++)
            {
                if ((number & 1) == 1)
                {
                    bits[EXPONENT_BIT_LENGTH - i - 1] = CHAR_BIT_TRUE;
                }
                else
                {
                    bits[EXPONENT_BIT_LENGTH - i - 1] = CHAR_BIT_FALSE;
                }

                number >>= 1;
            }

            return new string(bits);        
        }

        private static string GetFractionBinaryRepresentation(double fraction)
        {
            char[] bits = new char[FRACTION_BIT_LENGTH];

            for (int i = 0; i < bits.Length; i++)
            {
                fraction *= 2;

                if (fraction < 1)
                {
                    bits[i] = CHAR_BIT_FALSE;
                }
                else
                {
                    bits[i] = CHAR_BIT_TRUE;
                    fraction -= 1;
                }
            }

            return new string(bits);
        }

        private static int GetDoublesExponent(double number, out double fraction)
        {
            if (double.IsNaN(number))
            {
                fraction = 1;
                return (int)Math.Pow(2, EXPONENT_BIT_LENGTH) - 1;
            }

            int power = 0;
            
            fraction = number / Math.Pow(2, power) - 1;

            while (fraction < 0 || fraction >= 1)
            {
                power = fraction < 1 ? --power : ++power;
                fraction = number / Math.Pow(2, power) - 1;
            }

            power += EXPONENT_BIAS;

            if (power <= 0)
            {
                power = 0;
                fraction = number / Math.Pow(2, SUBNORMAL_EXPONENT);
            }

            if (double.IsNaN(fraction))
            {
                fraction = 0;
            }

            return power;
        }

        private static bool IsNegativeZero(double x)
        {
            return x == 0.0 && double.IsNegativeInfinity(1.0 / x);
        }

        #endregion
    }
}
