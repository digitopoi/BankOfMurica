using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public interface ITransactionService
    {
        Task<Account> GetAccountAsync(BankEntities context);
        Task<bool> WithdrawAsync(decimal amount);
        Task<bool> DepositAsync(decimal amount);
        Task<bool> TransferAsync(int target, decimal amount);
        Task<IEnumerable<Transaction>> GetAccountHistoryAsync();
    }
}
