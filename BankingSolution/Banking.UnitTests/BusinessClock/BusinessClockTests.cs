
using Banking.Domain;

namespace Banking.UnitTests.Businessclock;

public class BusinessClockTests
{
    [Fact]
    public void WeAreClosedBeforeOpening()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2001, 5, 1, 8, 59, 59));
        IProvideTheBusinessClock clock = new RegularBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void WeAreOpenAfterNine()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2001, 5, 1, 9, 0, 0));
        IProvideTheBusinessClock clock = new RegularBusinessClock(stubbedClock.Object);

        Assert.True(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void WeAreClosedAfterFive()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2001, 5, 1, 17, 0, 0));
        IProvideTheBusinessClock clock = new RegularBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }
}
