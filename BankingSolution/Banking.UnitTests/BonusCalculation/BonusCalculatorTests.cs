

using Banking.Domain;

namespace Banking.UnitTests.BonusCalculation
{
    public class BonusCalculatorTests
    {
        [Theory]
        [InlineData(100, 10)]
        [InlineData(200, 20)]
        [InlineData(1000, 100)]
        [InlineData(40, 4)]
        public void HasSufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            duringBusinessHourClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);
            var balanceOnAccount = 6000M;

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(200, 0)]
        [InlineData(1000, 0)]
        [InlineData(40, 0)]
        public void HasInsufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            duringBusinessHourClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);
            var balanceOnAccount = 5999.99M;

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }

        [Fact]
        public void BonusIsHalfOutsideBusinessHours()
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            duringBusinessHourClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);

            var bonus = bonusCalculator.CalculateBonusForDeposit(6000, 100);

            Assert.Equal(5M, bonus);
        }
    }
}
