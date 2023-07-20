
namespace Banking.UnitTests.BankAccounts
{
    public class GoldAccountScratch
    {
        [Fact]
        public void GoldAccountsGetBonusOnDeposit()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + 110, account.GetBalance());
        }
    }
}
