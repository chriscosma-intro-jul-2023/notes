namespace Banking.Domain;

public class RegularBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _systemTime;

    public RegularBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public bool IsDuringBusinessHours()
    {
        var now = _systemTime.GetCurrent();
        return now.Hour >= 9 && now.Hour < 17;
    }
}