using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var newBalance = balance - amount;
                var balanceDiff = amount * -1;

                if (newBalance <= 0)
                {
                    Console.WriteLine("You don't have enough funds.");
                    return false;
                }

                var transaction = new Transaction()
                {
                    AccountNumber = _accountNum,
                    TransactionType = "Withdrawal",
                    BalanceDifference = balanceDiff,
                    TransactionDate = DateTime.Now
                };

                query.Balance = newBalance;
                context.Transactions.Add(transaction);
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

                var balance = query.Balance;
                var newBalance = balance + amount;
                var balanceDiff = amount;

                var transaction = new Transaction()
                {
                    AccountNumber = _accountNum,
                    TransactionType = "Deposit",
                    BalanceDifference = balanceDiff,
                    TransactionDate = DateTime.Now
                };

                query.Balance += amount;
                context.Transactions.Add(transaction);
                return context.SaveChanges() == 1;
            }
        }

        public bool Transfer(int target, decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                var origin = context
                                  .Accounts
                                  .Where(e => e.AccountNumber == _accountNum)
                                  .SingleOrDefault();

                var destination = context
                                  .Accounts
                                  .Where(e => e.AccountNumber == target)
                                  .SingleOrDefault();

                var originBalance = origin.Balance;
                var destinationBalance = destination.Balance;

                var newOriginBalance = originBalance - amount;
                var newDestinationBalance = destinationBalance + amount;

                var originDifference = amount * -1;
                var destinationDifference = amount;

                var originTransaction = new Transaction()
                {
                    AccountNumber = _accountNum,
                    TransactionType = "Transfer",
                    BalanceDifference = originDifference,
                    TransactionDate = DateTime.Now
                };

                var destinationTransaction = new Transaction()
                {
                    AccountNumber = target,
                    TransactionType = "Transfer",
                    BalanceDifference = destinationDifference,
                    TransactionDate = DateTime.Now
                };

                origin.Balance = newOriginBalance;
                destination.Balance = newDestinationBalance;
                context.Transactions.Add(originTransaction);
                context.Transactions.Add(destinationTransaction);

                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<Transaction> AccountHistory()
        {
            using (BankEntities context = new BankEntities())
            {
                var query = context
                                   .Transactions
                                   .Where(e => e.AccountNumber == _accountNum)
                                   .ToList();
                return query;
            }
        }
 
    }
}
