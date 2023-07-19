

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
    }
}
