
namespace Banking.UnitTests.BankAccounts;

public class DepositUseTheBonusCalculator
{
    [Fact]
    public void BonusCalculatorIsUsedAndBonusAppliedToBalance()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICanCalculateBonusesForBankAccountDeposits>();
        var account = new BankAccount(stubbedBonusCalculator.Object);

        var openingBalance = account.GetBalance();
        var amountToDeposit = 112.23M;
        var amountOfBonusToReturn = 69.23M;
        // If CalculateBonusForDeposit(openingBalance, 112.23) is called, return 69.23M, else, return 0
        stubbedBonusCalculator
            .Setup(b => b.CalculateBonusForDeposit(openingBalance, amountToDeposit))
            .Returns(amountOfBonusToReturn);

        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit + amountOfBonusToReturn, account.GetBalance());
    }
}
