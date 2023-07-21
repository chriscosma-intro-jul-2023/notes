
namespace StringCalculatorKata;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        int result = 0;
        if (numbers != "")
        {
            result = numbers
                .Split(',')
                .Select(int.Parse)
                .Sum();
        }

        try
        {
            _logger.Log($"{result}");
        }
        catch (CalculatorLoggerException) {
            _webService.NotifyOfLoggerFailure("Blammo!");
        }

        return result;
    }
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}