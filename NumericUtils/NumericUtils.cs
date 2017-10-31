using System;
using System.Diagnostics;
using System.Linq;

namespace NumericUtils
{
    public static class NumericUtils
    {
        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/> and <paramref name="second"/> using
        /// classic Euclidean algorithm
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int first, int second)
        {
            ValidateZeroValues(first, second);

            return EuclidGCDValidNumbers(first, second);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/> and <paramref name="second"/> using
        /// classic Euclidean algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int first, int second, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = EuclidGCD(first, second);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/>, <paramref name="second"/> and <paramref name="third"/>
        /// using classic Euclidean algorithm
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int first, int second, int third)
        {
            ValidateZeroValues(first, second, third);

            return EuclidGCDValidNumbers(EuclidGCDValidNumbers(first, second), third);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/>, <paramref name="second"/> and <paramref name="third"/>
        /// using classic Euclidean algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int EuclidGCD(int first, int second, int third, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = EuclidGCD(first, second, third);
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

            return numbers.Aggregate((first, second) => EuclidGCDValidNumbers(first, second));
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
        /// Find greatest common divisor of <paramref name="first"/> and <paramref name="second"/> using
        /// Stein (or binary Euclidean) algorithm
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int first, int second)
        {
            ValidateZeroValues(first, second);

            return SteinGCDValidNumbers(first, second);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/> and <paramref name="second"/> using
        /// Stein (or binary Euclidean) algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of two values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int first, int second, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = SteinGCD(first, second);
            stopwatch.Stop();

            methodExecutionMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/>, <paramref name="second"/> and <paramref name="third"/>
        /// using Stein (or binary Euclidean) algorithm
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int first, int second, int third)
        {
            ValidateZeroValues(first, second, third);

            return SteinGCDValidNumbers(SteinGCDValidNumbers(first, second), third);
        }

        /// <summary>
        /// Find greatest common divisor of <paramref name="first"/>, <paramref name="second"/> and <paramref name="third"/>
        /// using Stein (or binary Euclidean) algorithm. Also counts method execution time in milliseconds
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <param name="methodExecutionMilliseconds">Method execution time in milliseconds</param>
        /// <returns>Greatest common divisor of three values</returns>
        /// <exception cref="ArgumentException">All the values are zero</exception>
        public static int SteinGCD(int first, int second, int third, out long methodExecutionMilliseconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = SteinGCD(first, second, third);
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

            return numbers.Aggregate((first, second) => SteinGCDValidNumbers(first, second));
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

        private static int EuclidGCDValidNumbers(int first, int second)
        {
            first = first < 0 ? -first : first;
            second = second < 0 ? -second : second;

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            while (first != second)
            {
                if (first > second)
                {
                    first -= second;
                }
                else
                {
                    second -= first;
                }
            }

            return first;
        }

        private static int SteinGCDValidNumbers(int first, int second)
        {
            first = first < 0 ? -first : first;
            second = second < 0 ? -second : second;

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            int shift;
            for (shift = 0; ((first | second) & 1) == 0; shift++)
            {
                first >>= 1;
                second >>= 1;
            }

            while ((first & 1) == 0) first >>= 1;
            do
            {
                while ((second & 1) == 0) second >>= 1;
                if (first > second)
                {
                    Swap(ref first, ref second);
                }
                second -= first;
            } while (second != 0);

            return first << shift;
        }

        private static void ValidateArrayLength(int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("The number of values must be greater than one.");
            }
        }

        private static void ValidateZeroValues(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("All the values cannot be zero.");
            }
        }

        private static void ValidateZeroValues(int first, int second, int third)
        {
            if (first == 0 && second == 0 && third == 0)
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
