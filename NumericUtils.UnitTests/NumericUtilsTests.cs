using NUnit.Framework;
using System;

namespace NumericUtils.UnitTests
{
    [TestFixture]
    public class NumericUtilsTests
    {
        [TestCase(0, 3, ExpectedResult = 3)]
        [TestCase(0, -1000, ExpectedResult = 1000)]
        [TestCase(5123, 11823981, ExpectedResult = 1)]
        [TestCase(725418, 6126, ExpectedResult = 6)]
        [TestCase(-888888, 77274168, ExpectedResult = 24)]
        [TestCase(5641, 31820881, ExpectedResult = 5641)]
        public int EuclidGCD_TwoCorrectValuesPassed_WorksCorrectly(int first, int second)
        {
            return NumericUtils.EuclidGCD(first, second);
        }

        public void EuclidGCD_TwoZeroesPassed_ArgumentExceptionThrown()
        {
            int first = 0, second = 0;

            Assert.Throws<ArgumentException>(() => NumericUtils.EuclidGCD(first, second));
        }

        [TestCase(0, 1, 2, ExpectedResult = 1)]
        [TestCase(-1728, 12489, 82489395, ExpectedResult = 3)]
        [TestCase(6234262, 3453225, 234252, ExpectedResult = 1)]
        [TestCase(666, 888, 999, ExpectedResult = 111)]
        [TestCase(297388, -95956, -984196, ExpectedResult = 4)]
        public int EuclidGCD_ThreeCorrectValuesPassed_WorksCorrectly(int first, int second, int third)
        {
            return NumericUtils.EuclidGCD(first, second, third);
        }

        public void EuclidGCD_ThreeZeroesPassed_ArgumentExceptionThrown()
        {
            int first = 0, second = 0, third = 0;

            Assert.Throws<ArgumentException>(() => NumericUtils.EuclidGCD(first, second, third));
        }

        [TestCase(0, 2, 4, 6, 100000, ExpectedResult = 2)]
        [TestCase(27394, 72348, 28392, 273874, 83743, 92983, 82839492, 29834, 27344, ExpectedResult = 1)]
        [TestCase(5, 25, 625, 3125, 15625, 78125, 390625, ExpectedResult = 5)]
        [TestCase(29384896, 9849828, 282984, 9898, 67434, ExpectedResult = 2)]
        [TestCase(-288, 28934, 882838, 5627384, -78534, 0, 178236, ExpectedResult = 2)]
        public int EuclidGCD_ArrayOfCorrectValuesPassed_WorksCorrectly(params int[] numbers)
        {
            return NumericUtils.EuclidGCD(numbers);
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void EuclidGCD_ArrayOfZeroesPassed_ArgumentExceptionThrown(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => NumericUtils.EuclidGCD(numbers));
        }

        [TestCase(-1)]
        [TestCase()]
        public void EuclidGCD_LessThanTwoArgumentsPassed_ArgumentExceptionThrown(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => NumericUtils.EuclidGCD(numbers));
        }

        [TestCase(0, 3, ExpectedResult = 3)]
        [TestCase(0, -1000, ExpectedResult = 1000)]
        [TestCase(5123, 11823981, ExpectedResult = 1)]
        [TestCase(725418, 6126, ExpectedResult = 6)]
        [TestCase(-888888, 77274168, ExpectedResult = 24)]
        [TestCase(5641, 31820881, ExpectedResult = 5641)]
        public int SteinGCD_TwoCorrectValuesPassed_WorksCorrectly(int first, int second)
        {
            return NumericUtils.SteinGCD(first, second);
        }

        public void SteinGCD_TwoZeroesPassed_ArgumentExceptionThrown()
        {
            int first = 0, second = 0;

            Assert.Throws<ArgumentException>(() => NumericUtils.SteinGCD(first, second));
        }

        [TestCase(0, 1, 2, ExpectedResult = 1)]
        [TestCase(-1728, 12489, 82489395, ExpectedResult = 3)]
        [TestCase(6234262, 3453225, 234252, ExpectedResult = 1)]
        [TestCase(666, 888, 999, ExpectedResult = 111)]
        [TestCase(297388, -95956, -984196, ExpectedResult = 4)]
        public int SteinGCD_ThreeCorrectValuesPassed_WorksCorrectly(int first, int second, int third)
        {
            return NumericUtils.SteinGCD(first, second, third);
        }

        public void SteinGCD_ThreeZeroesPassed_ArgumentExceptionThrown()
        {
            int first = 0, second = 0, third = 0;

            Assert.Throws<ArgumentException>(() => NumericUtils.SteinGCD(first, second, third));
        }

        [TestCase(0, 2, 4, 6, 100000, ExpectedResult = 2)]
        [TestCase(27394, 72348, 28392, 273874, 83743, 92983, 82839492, 29834, 27344, ExpectedResult = 1)]
        [TestCase(5, 25, 625, 3125, 15625, 78125, 390625, ExpectedResult = 5)]
        [TestCase(29384896, 9849828, 282984, 9898, 67434, ExpectedResult = 2)]
        [TestCase(-288, 28934, 882838, 5627384, -78534, 0, 178236, ExpectedResult = 2)]
        public int SteinGCD_ArrayOfCorrectValuesPassed_WorksCorrectly(params int[] numbers)
        {
            return NumericUtils.SteinGCD(numbers);
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void SteinGCD_ArrayOfZeroesPassed_ArgumentExceptionThrown(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => NumericUtils.SteinGCD(numbers));
        }

        [TestCase(-1)]
        [TestCase()]
        public void SteinGCD_LessThanTwoArgumentsPassed_ArgumentExceptionThrown(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => NumericUtils.SteinGCD(numbers));
        }
    }
}
