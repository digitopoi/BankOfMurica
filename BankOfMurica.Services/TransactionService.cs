using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public class TransactionService
    {
        private readonly int _accountNum;

        public TransactionService(int accountNum)
        {
            _accountNum = accountNum;
        }

        public bool Withdraw(decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                var query = context
                                   .Accounts
                                   .Where(e => e.AccountNumber == _accountNum)
                                   .SingleOrDefault();

                var balance = query.Balance;
                var newBalance = balance -= amount;
                var balanceDiff = newBalance - balance;

                if (newBalance <= 0)
                {
                    Console.WriteLine("You don't have enough funds.");
                    return false;
                }
                query.Balance = newBalance;

                // TODO: implement saving transactions
                var transaction = new Transaction()
                {
                    
                };

                context.SaveChanges();
                return context.SaveChanges() == 1;
            }
        }

        public bool Deposit(decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                var query = context
                                   .Accounts
                                   .Where(e => e.AccountNumber == _accountNum)
                                   .SingleOrDefault();

                query.Balance += amount;

                return context.SaveChanges() == 1;
            }
        }
    }
}
