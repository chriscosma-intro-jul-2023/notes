namespace Banking.Domain
{
    public class StandardBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {
        private readonly IProvideTheBusinessClock _businessClock;

        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal CalculateBonusForDeposit(decimal balanceOnAccount, decimal amountOfDeposit)
        {
            return amountOfDeposit
                * (balanceOnAccount >= 6000 ? 1 : 0)
                * (_businessClock.IsDuringBusinessHours() ? 0.10M : 0.05M);
        }
    }
}