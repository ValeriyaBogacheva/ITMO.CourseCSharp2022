using System;

public enum AccountType { Checking, Deposit }

class CreateAccount
{
    static void Main()
    {
        BankAccount berts = NewBankAccount();
        Write(berts);

        BankAccount freds = NewBankAccount();
        Write(freds);
    }

    static BankAccount NewBankAccount()
    {
        BankAccount created = new BankAccount();
        //created.accType = AccountType.Checking;
        //created.accBal = (decimal)3200.00;
        Console.Write("Enter balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());
        //Console.Write("Enter account number: ");
        //long number = BankAccount.NextNumber( );
        //created.accNo = number; // Error here
        created.Populate(balance);

        return created;
    }

    static void Write(BankAccount toWrite)
    {
        Console.WriteLine("Account number is {0}", toWrite.Number());
        Console.WriteLine("Account balance is {0}", toWrite.Balance());
        Console.WriteLine("Account type is {0}", toWrite.Type());
    }

    public static void TestDeposit(BankAccount acc)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        acc.Deposit(amount);
    }

    public static void TestWithdraw(BankAccount acc)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (!acc.Withdraw(amount))
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

class BankAccount
{
    public void Populate(decimal balance)
    {
        accNo = NextNumber();
        accBal = balance;
        accType = AccountType.Checking;
    }

    public long Number()
    {
        return accNo;
    }

    public decimal Balance()
    {
        return accBal;
    }

    public string Type()
    {
        return accType.ToString();
    }

    private static long NextNumber()
    {
        return nextAccNo++;
    }

    public decimal Deposit(decimal amount)
    {
        if (amount > 0)
            accBal += amount;
        return accBal;
    }

    public bool Withdraw(decimal amount)
    {
        bool sufficientFunds = accBal >= amount;
        if (sufficientFunds)
        {
            accBal -= amount;
        }
        return sufficientFunds;
    }

    public void TransferFrom(BankAccount accFrom, decimal amount)
    {
        if (accFrom.Withdraw(amount))
            this.Deposit(amount);
    }

    private long accNo;
    private decimal accBal;
    private AccountType accType;

    private static long nextAccNo = 123;
}