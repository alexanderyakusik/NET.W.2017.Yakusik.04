using System;
using System.Diagnostics;
using System.Linq;

namespace NumericUtils
{
    public static class NumericUtils
    {
        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/> and <paramref name="num2"/> using
        /// classic Euclidean algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int num1, int num2)
        {
            ValidateZeroValues(num1, num2);

            return EuclidGCDValidNumbers(num1, num2);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/> and <paramref name="num2"/> using
        /// classic Euclidean algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int num1, int num2, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = EuclidGCD(num1, num2);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/>, <paramref name="num2"/> and <paramref name="num3"/>
        /// using classic Euclidean algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int num1, int num2, int num3)
        {
            ValidateZeroValues(num1, num2, num3);

            return EuclidGCDValidNumbers(EuclidGCDValidNumbers(num1, num2), num3);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/>, <paramref name="num2"/> and <paramref name="num3"/>
        /// using classic Euclidean algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int num1, int num2, int num3, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = EuclidGCD(num1, num2, num3);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of an array of <paramref name="numbers"/>
        /// using classic Euclidean algorithm
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greatest common divisor of all the values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        /// <exception cref="ArgumentException">Array contains less than two values</exception>
        public static int EuclidGCD(params int[] numbers)
        {
            ValidateArrayLength(numbers);
            ValidateZeroValues(numbers);

            return numbers.Aggregate((num1, num2) => EuclidGCDValidNumbers(num1, num2));
        }

        /// <summary>
        /// Find greatest common divisor of an array of <paramref name="numbers"/>
        /// using classic Euclidean algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greatest common divisor of all the values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        /// <exception cref="ArgumentException">Array contains less than two values</exception>
        public static int EuclidGCD(out long methodExecutionMilliseconds, params int[] numbers)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = EuclidGCD(numbers);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/> and <paramref name="num2"/> using
        /// Stein (or binary Euclidean) algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int num1, int num2)
        {
            ValidateZeroValues(num1, num2);

            return SteinGCDValidNumbers(num1, num2);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/> and <paramref name="num2"/> using
        /// Stein (or binary Euclidean) algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int num1, int num2, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = SteinGCD(num1, num2);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/>, <paramref name="num2"/> and <paramref name="num3"/>
        /// using Stein (or binary Euclidean) algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int num1, int num2, int num3)
        {
            ValidateZeroValues(num1, num2, num3);

            return SteinGCDValidNumbers(SteinGCDValidNumbers(num1, num2), num3);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="num1"/>, <paramref name="num2"/> and <paramref name="num3"/>
        /// using Stein (or binary Euclidean) algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int num1, int num2, int num3, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = SteinGCD(num1, num2, num3);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of an array of <paramref name="numbers"/>
        /// using Stein (or binary Euclidean) algorithm
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greatest common divisor of all the values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        /// <exception cref="ArgumentException">Array contains less than two values</exception>
        public static int SteinGCD(params int[] numbers)
        {
            ValidateArrayLength(numbers);
            ValidateZeroValues(numbers);

            return numbers.Aggregate((num1, num2) => SteinGCDValidNumbers(num1, num2));
        }

        /// <summary>
        /// Find greatest common divisor of an array of <paramref name="numbers"/>
        /// using Stein (or binary Euclidean) algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greatest common divisor of all the values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        /// <exception cref="ArgumentException">Array contains less than two values</exception>
        public static int SteinGCD(out long methodExecutionMilliseconds, params int[] numbers)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = SteinGCD(numbers);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        #region Private methods

        private static int EuclidGCDValidNumbers(int num1, int num2)
        {
            num1 = num1 < 0 ? -num1 : num1;
            num2 = num2 < 0 ? -num2 : num2;

            if (num1 == 0)
            {
                return num2;
            }

            if (num2 == 0)
            {
                return num1;
            }

            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 -= num2;
                }
                else
                {
                    num2 -= num1;
                }
            }

            return num1;
        }

        private static int SteinGCDValidNumbers(int num1, int num2)
        {
            num1 = num1 < 0 ? -num1 : num1;
            num2 = num2 < 0 ? -num2 : num2;

            if (num1 == 0)
            {
                return num2;
            }

            if (num2 == 0)
            {
                return num1;
            }

            int shift;
            for (shift = 0; ((num1 | num2) & 1) == 0; shift++)
            {
                num1 >>= 1;
                num2 >>= 1;
            }

            while ((num1 & 1) == 0) num1 >>= 1;
            do
            {
                while ((num2 & 1) == 0) num2 >>= 1;
                if (num1 > num2)
                {
                    Swap(ref num1, ref num2);
                }
                num2 -= num1;
            } while (num2 != 0);

            return num1 << shift;
        }

        private static void ValidateArrayLength(int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("The number of values must be greater than one.");
            }
        }

        private static void ValidateZeroValues(int num1, int num2)
        {
            if (num1 == 0 && num2 == 0)
            {
                throw new ArgumentException("All the values cannot be zero.");
            }
        }

        private static void ValidateZeroValues(int num1, int num2, int num3)
        {
            if (num1 == 0 && num2 == 0 && num3 == 0)
            {
                throw new ArgumentException("All the values cannot be zero.");
            }
        }

        private static void ValidateZeroValues(params int[] numbers)
        {
            if (numbers.All(number => number == 0))
            {
                throw new ArgumentException("All the values cannot be zero.");
            }
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        #endregion
    }
}
