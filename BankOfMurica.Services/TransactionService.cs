using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly int _accountNum;

        public TransactionService(int accountNum)
        {
            _accountNum = accountNum;
        }

        public async Task<Account> GetAccountAsync(BankEntities context)
        {
            return await context
                               .Accounts
                               .Where(e => e.AccountNumber == _accountNum)
                               .SingleOrDefaultAsync();
        }

        public async Task<bool> WithdrawAsync(decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                Account query = await GetAccountAsync(context);

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
                return await context.SaveChangesAsync() == 1;
            }
        }


        public async Task<bool> DepositAsync(decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                Account query = GetAccountAsync(context).Result;

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
                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> TransferAsync(int target, decimal amount)
        {
            using (BankEntities context = new BankEntities())
            {
                var origin = await context
                                          .Accounts
                                          .Where(e => e.AccountNumber == _accountNum)
                                          .SingleOrDefaultAsync();

                var destination = await context
                                            .Accounts
                                            .Where(e => e.AccountNumber == target)
                                            .SingleOrDefaultAsync();

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

                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAccountHistoryAsync()
        {
            using (BankEntities context = new BankEntities())
            {
                return await context
                                    .Transactions
                                    .Where(e => e.AccountNumber == _accountNum)
                                    .ToListAsync();
            }
        }
 
    }
}
