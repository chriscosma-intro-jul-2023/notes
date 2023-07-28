
using EmployeeDirectoryApi.Controllers;
using Moq;

namespace EmployeeDirectoryApi.UnitTests;

public class BusinessClockTests
{
    [Fact]
    public void ClosedBeforeNine()
    {
        var stubbedSystemTime = new Mock<ISystemTime>();
        stubbedSystemTime.Setup(x => x.GetCurrent()).Returns(new DateTime(2001, 05, 01, 8, 59, 59));
        IProvideTheBusinessesClock standardBusinessClock = new StandardBusinessClock(stubbedSystemTime.Object);

        Assert.False(standardBusinessClock.AreWeOpen());
    }

    [Fact]
    public void OpenAtNine()
    {
        var stubbedSystemTime = new Mock<ISystemTime>();
        stubbedSystemTime.Setup(x => x.GetCurrent()).Returns(new DateTime(2001, 05, 01, 9, 00, 01));
        IProvideTheBusinessesClock standardBusinessClock = new StandardBusinessClock(stubbedSystemTime.Object);
        Assert.True(standardBusinessClock.AreWeOpen());
    }
}
