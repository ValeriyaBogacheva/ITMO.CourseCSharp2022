using Constructors;
using System;

class CreateAccount
{
    static BankAccount NewBankAccount()
    {
        BankAccount created;
        //created.accType = AccountType.Checking;
        //created.accBal = (decimal)3200.00;
        Console.Write("Enter balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());
        //Console.Write("Enter account number: ");
        //long number = BankAccount.NextNumber( );
        //created.accNo = number; // Error here
        created = new BankAccount(balance);

        return created;
    }

    static void Write(BankAccount acc)
    {
        Console.WriteLine("Account number is {0}", acc.Number());
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type());
        Console.WriteLine("Transactions:");
        foreach (BankTransaction tran in acc.Transactions())
        {
            Console.WriteLine("Date/Time: {0}\tAmount: {1}", tran.When(), tran.Amount());
        }
        Console.WriteLine();
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

    public static void Main()
    {
        BankAccount acc1, acc2, acc3, acc4;

        acc1 = new BankAccount();
        acc2 = new BankAccount(AccountType.Deposit);
        acc3 = new BankAccount(100);
        acc4 = new BankAccount(AccountType.Deposit, 500);

        acc1.Deposit(200);
        acc1.Withdraw(50);
        acc2.Deposit(43);
        acc2.Withdraw(10);
        acc3.Deposit(266);
        acc3.Withdraw(487);
        acc4.Deposit(32);
        acc4.Withdraw(31);
        Write(acc1);
        Write(acc2);
        Write(acc3);
        Write(acc4);
    }

}