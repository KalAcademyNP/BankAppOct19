using System;

namespace BankAppOct19
{
    class Program
    {
        static void Main(string[] args)
        {
            //object = instance of a class
            var account = new Account
            {
                AccountType = TypeOfAccount.Checking,
                EmailAddress = "test@test.com"
            };

            account.Deposit(1023.45M);
            Console.WriteLine($"AN: {account.AccountNumber}, EA: {account.EmailAddress}, B: {account.Balance:C}, AT: {account.AccountType}, CD: {account.CreatedDate}");

            var account2 = new Account();
            Console.WriteLine($"AN: {account2.AccountNumber}, EA: {account2.EmailAddress}, B: {account2.Balance:C}, AT: {account2.AccountType}, CD: {account2.CreatedDate}");

        }
    }
}
