

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            // Given
            var calculator = new StringCalculator();

            // When
            int result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("108", 108)]
        public void SingleDigit(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            int result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("13,3", 16)]
        [InlineData("108,200", 308)]
        public void TwoDigits(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            int result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        public void ArbitraryNumbers(string numbers, int expected)
        {
            // Given
            var calculator = new StringCalculator();

            // When
            int result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}
