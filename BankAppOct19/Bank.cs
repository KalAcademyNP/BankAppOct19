using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppOct19
{
    class Bank
    {
        public Account CreateAccount(string accountName, string emailAddress, TypeOfAccount accountType, decimal initialDeposit)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }

            return account;


        }
    }
}
