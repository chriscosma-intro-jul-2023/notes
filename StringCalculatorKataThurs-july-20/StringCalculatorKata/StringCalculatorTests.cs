

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
        [InlineData("9", 9)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void SingleDigitReturnsSame(string expression, int expected)
        {
            var calc = new StringCalculator();

            int result = calc.Add(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,1", 2)]
        [InlineData("0,1", 1)]
        [InlineData("9,8", 17)]
        [InlineData("1\n1", 2)]
        [InlineData("0\n1", 1)]
        [InlineData("9\n8", 17)]
        public void TwoDigits(string expression, int expected)
        {
            var calc = new StringCalculator();

            int result = calc.Add(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,1,10,34", 46)]
        [InlineData("1,1,10,34,1000", 1046)]
        [InlineData("1,1,10,34,1001", 46)]
        [InlineData("1,1,1,1,1,1,1,1", 8)]
        [InlineData("1\n1,10\n34", 46)]
        [InlineData("1,1\n1,1\n1\n1,1\n1", 8)]
        public void UnknownNumberOfDigits(string expression, int expected)
        {
            var calc = new StringCalculator();

            int result = calc.Add(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//-\n1-2", 3)]
        public void CustomDelimiter(string expression, int expected)
        {
            var calc = new StringCalculator();

            int result = calc.Add(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n-1;2")]
        [InlineData("//-\n1--2")]
        [InlineData("1,-1,10,34")]
        [InlineData("1,1,1,-1,1,1,-1,1")]
        [InlineData("-1\n1,10\n34")]
        [InlineData("1,-1\n1,1\n1\n1,1\n1")]
        [InlineData("1,-1")]
        [InlineData("0,-1")]
        [InlineData("-9,8")]
        [InlineData("1\n-1")]
        [InlineData("-0\n-1")]
        [InlineData("-9\n-8")]
        [InlineData("-1")]
        [InlineData("-1001")]
        public void NegativeNotAllowed(string expression)
        {
            var calc = new StringCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.Add(expression));
        }
    }
}
