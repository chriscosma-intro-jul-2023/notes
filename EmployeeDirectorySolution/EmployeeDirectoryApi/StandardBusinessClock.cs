using EmployeeDirectoryApi.Controllers;

namespace EmployeeDirectoryApi;

public class StandardBusinessClock : IProvideTheBusinessesClock
{
    private readonly ISystemTime _systemTime;

    public StandardBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public bool AreWeOpen()
    {
        var now = _systemTime.GetCurrent();
        return (now.Hour >= 9 && now.Hour < 15);
    }
}

public interface ISystemTime
{
    DateTime GetCurrent();
}

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent() => DateTime.Now;
}