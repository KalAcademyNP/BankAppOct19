using System;

namespace BankAppOct19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Welcome to my bank!**********");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdrawal");
                Console.WriteLine("4. Print all accounts");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Email Address: ");
                            var email = Console.ReadLine();
                            Console.Write("Account name: ");
                            var accountName = Console.ReadLine();
                            Console.WriteLine("Account Type: ");
                            var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                            for (var i = 0; i < accountTypes.Length; i++)
                            {
                                Console.WriteLine($"{i}. {accountTypes[i]}");
                            }
                            var accountType = Enum.Parse<TypeOfAccount>(Console.ReadLine());
                            var account = Bank.CreateAccount(accountName, email, accountType);
                            Console.WriteLine($"AN: {account.AccountNumber}, Account Name: {account.AccountName}, EA: {account.EmailAddress}, AT: {account.AccountType}, B: {account.Balance:C}, CD: {account.CreatedDate}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error! {ax.Message}");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Account type is invalid! Please choose a valid account type");
                        }
                        catch
                        {
                            Console.WriteLine("Sorry something went wrong! Please try again!");
                        }
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit completed successfully!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, amount);
                        Console.WriteLine("Withdrawal completed successfully!");
                        break;
                    case "4":
                        PrintAllAccounts();

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!");
                        break;

                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var email = Console.ReadLine();

            var accounts = Bank.GetAllAccountsByEmailAddress(email);
            foreach (var myAccount in accounts)
            {
                Console.WriteLine($"AN: {myAccount.AccountNumber}, Account Name: {myAccount.AccountName}, EA: {myAccount.EmailAddress}, AT: {myAccount.AccountType}, B: {myAccount.Balance:C}, CD: {myAccount.CreatedDate}");
            }

        }
    }
}
