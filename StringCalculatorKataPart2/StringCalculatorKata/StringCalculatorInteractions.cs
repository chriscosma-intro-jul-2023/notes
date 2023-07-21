
using Moq;

namespace StringCalculatorKata;

public class StringCalculatorInteractions
{
    [Theory]
    [InlineData("15", 15)]
    [InlineData("1,2,3", 6)]
    [InlineData("10,9,9,1", 29)]
    public void ResultsAreLogged(string numbers, int expected)
    {
        var loggerMock = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerMock.Object, mockedWebService.Object);

        calculator.Add(numbers);

        // checks if logger.Log("15") was called and the web service was not called
        loggerMock.Verify(logger => logger.Log(expected.ToString()));
        mockedWebService.Verify(m => m.NotifyOfLoggerFailure(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void WebServiceIsCalledOnLoggerFailure()
    {
        // Given
        var loggerStub = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerStub.Object, mockedWebService.Object);
        loggerStub.Setup(m => m.Log(It.IsAny<string>())).Throws<CalculatorLoggerException>();

        // When
        calculator.Add("1");

        mockedWebService.Verify(m => m.NotifyOfLoggerFailure("Blammo!"), Times.Once);
    }
}
