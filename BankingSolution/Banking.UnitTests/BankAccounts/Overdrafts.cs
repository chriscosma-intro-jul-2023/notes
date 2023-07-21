
namespace Banking.UnitTests.BankAccounts
{
    public class Overdrafts
    {
        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdraw = openingBalance + 0.01M;

            Assert.Throws<AccountOverdraftException>(() => account.Withdraw(amountToWithdraw));
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
