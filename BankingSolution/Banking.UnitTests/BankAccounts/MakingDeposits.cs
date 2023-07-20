
namespace Banking.UnitTests.BankAccounts
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreaseTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100.23M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
