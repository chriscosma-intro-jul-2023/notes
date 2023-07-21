
namespace Banking.UnitTests.BankAccounts
{
    public class MakingWithdrawals
    {
        [Fact]
        public void MakingAWithdrawalDecreasesTheBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1.01M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void CanTakeEntireBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);

            account.Withdraw(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-6000)]
        public void InvalidAmountsAreNotAllowed(decimal amount)
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var startingbalance = account.GetBalance();


            Assert.Throws<InvalidBankAccountTransactionAmountException>(() =>
            {
                account.Withdraw(amount);
            });

            Assert.Equal(startingbalance, account.GetBalance());
        }
    }
}
