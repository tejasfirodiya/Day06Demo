var cust = new Customer();
cust.Start();

class Customer
{
    Bank account1, account2;

    public void Start()
    {
        account1 = new SavingsAccount("Tejas Firodiya", "123456", 's');
        account2 = new CurrentAccount("Tejas S Firodiya", "987654", 'c');

        Console.WriteLine("*************Savings Account*************");
        account1.Deposit(10000);
        account1.DisplayBalance();
        account1.Withdrawal();
        account1.DisplayBalance();

        Console.WriteLine("*************Current Account*************");
        account2.Deposit(10000);
        account2.DisplayBalance();
        account2.Withdrawal();
        account2.DisplayBalance();

    }
}

public interface Bank
{
    public void Deposit(int amount);
    public void Withdrawal();
    public void DisplayBalance();
    public void CalculateInterest();
}

public abstract class Account : Bank
{
    protected string _customerName;
    protected string _accountNumber;
    protected char _typeOfAccount;
    protected double _balance;

    public Account()
    {
    }

    public abstract void CalculateInterest();    

    public void Deposit(int amount)
    {
        _balance += amount;
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Balance of {_customerName} is {_balance}. ");
    }

    public virtual void Withdrawal()
    {
        //_balance -= amount;
    }
}

class SavingsAccount : Account
{
    double _rateOfInterest = 4.5;
    public SavingsAccount(string customerName, string accountNumber, char typeOfAccount)
    {
        _accountNumber = accountNumber;
        _typeOfAccount = typeOfAccount;
        _customerName = customerName;
        _balance = 0;
    }

    public override void CalculateInterest()
    {
        var interest = _balance * 3 * _rateOfInterest / 100;
        _balance += interest;
    }
}

class CurrentAccount : Account
{
    int minimumBalance = 1000;
    int penaltyAmount = 200;

    public CurrentAccount(string customerName, string accountNumber, char typeOfAccount)
    {
        _accountNumber = accountNumber;
        _typeOfAccount = typeOfAccount;
        _customerName = customerName;
        _balance = 0;
    }

    public override void CalculateInterest()
    {
    }

    public override void Withdrawal()
    {
        //base.Withdrawal(amount);

        Console.WriteLine("Enter amount to withdraw : ");
        var textWithdrawAmount = Console.ReadLine();
        int withdrawAmount = int.Parse(textWithdrawAmount);

        _balance -= withdrawAmount;
        if (_balance < minimumBalance)
        {
            _balance -= penaltyAmount;
            Console.WriteLine($"Your balance is less than minimum balance. So penalty of {penaltyAmount} is applied. ");
        }
    }
}