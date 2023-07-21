using Banking.Domain;

// Composition root
var account = new BankAccount(new StandardBonusCalculator(new RegularBusinessClock(new SystemTime())));

Console.Write("How much do you want to deposit?: ");

var amountEntered = Console.ReadLine();
if (amountEntered != null)
{
    var amount = decimal.Parse(amountEntered);
    account.Deposit(amount);
    Console.WriteLine($"Your new balance is {account.GetBalance():c}");
}