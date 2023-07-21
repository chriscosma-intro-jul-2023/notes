

using Moq;

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calculator;

        public StringCalculatorTests()
        {
            // We use a mock here because these tests don't have anything to do with logging
            _calculator = new(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = _calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]
        public void CommaSeparatedNumbers(string numbers, int expected)
        {
            int result = _calculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}
