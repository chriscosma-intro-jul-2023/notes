
namespace Banking.UnitTests.BankAccounts
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectOpeningBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);

            decimal balance = account.GetBalance();

            Assert.Equal(5000, balance);
        }
    }
}
