using System;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

public class NegativeAmountException : Exception
{
    public NegativeAmountException(string message) : base(message)
    {
    }
}

public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException($"Cannot deposit a negative amount ({amount}).");
        }
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException($"Cannot withdraw a negative amount ({amount}).");
        }
        if (balance - amount < 0)
        {
            throw new InsufficientFundsException($"Insufficient funds. Current balance: {balance}, Requested withdrawal: {amount}.");
        }
        balance -= amount;
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount account = new BankAccount();

        try
        {
            account.Deposit(1000.0m);
            account.Withdraw(500.0m);
            Console.WriteLine($"Current balance: {account.Balance}");

            account.Withdraw(600.0m);
            Console.WriteLine($"Current balance: {account.Balance}");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NegativeAmountException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}